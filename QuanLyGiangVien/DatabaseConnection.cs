using System;
using System.Configuration;
using System.Data.SqlClient;

namespace QuanLyGiangVien
{
    internal static class DatabaseConnection
    {
        private const string SettingsName = "QuanLyGiangVien.Properties.Settings.QuanLyGiangVienConnectionString";
        private const string HoangLocalDb = @"(localdb)\HoangLocalDB";
        private static readonly object SetupLock = new object();
        private static string selectedConnectionString;

        internal static string CurrentConnectionString
        {
            get
            {
                lock (SetupLock)
                    return selectedConnectionString ?? GetConfiguredConnectionString();
            }
        }

        internal static string GetReadyConnectionString()
        {
            lock (SetupLock)
            {
                if (selectedConnectionString != null)
                    return selectedConnectionString;

                string configured = GetConfiguredConnectionString();
                string localCandidate = GetLocalDbCandidate(configured);
                string selected = configured;
                SqlConnection connection = null;
                SqlException localError = null;

                if (localCandidate != null)
                {
                    try
                    {
                        connection = Open(localCandidate);
                        selected = localCandidate;
                    }
                    catch (SqlException error)
                    {
                        localError = error;
                    }
                }

                if (connection == null)
                {
                    try { connection = Open(configured); }
                    catch (SqlException error) when (localError != null)
                    {
                        Diagnostics.SqlFailure(localError);
                        Diagnostics.SqlFailure(error);
                        throw new UserMessage($"Không mở được database QuanLyGiangVien trên {HoangLocalDb} " +
                            $"(mã {localError.Number}) hoặc localhost (mã {error.Number}).");
                    }
                }

                using (connection)
                    DatabaseSchema.EnsureRecoveryEmail(connection, IsLocalDatabase(selected));

                selectedConnectionString = selected;
                return selectedConnectionString;
            }
        }

        private static string GetConfiguredConnectionString()
        {
            var setting = ConfigurationManager.ConnectionStrings[SettingsName];
            if (setting == null || string.IsNullOrWhiteSpace(setting.ConnectionString))
                throw new UserMessage("Thiếu cấu hình kết nối dữ liệu.");

            return setting.ConnectionString;
        }

        private static string GetLocalDbCandidate(string configured)
        {
            var builder = new SqlConnectionStringBuilder(configured);
            // Tôn trọng địa chỉ đã cấu hình riêng. Chỉ thử LocalDB khi còn dùng cấu hình localhost của repo.
            if (!string.Equals(builder.DataSource, "localhost", StringComparison.OrdinalIgnoreCase) ||
                !string.Equals(builder.InitialCatalog, "QuanLyGiangVien", StringComparison.OrdinalIgnoreCase) ||
                !builder.IntegratedSecurity || builder.AttachDBFilename.Length != 0)
                return null;

            builder.DataSource = HoangLocalDb;
            return builder.ConnectionString;
        }

        private static bool IsLocalDatabase(string connectionString)
        {
            string server = new SqlConnectionStringBuilder(connectionString).DataSource;
            if (server.StartsWith(@"(localdb)\", StringComparison.OrdinalIgnoreCase))
                return IsPrivateLocalDb(connectionString);

            string host = server.Split('\\')[0].Trim();
            return string.Equals(host, "localhost", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(host, ".", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(host, "(local)", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(host, "127.0.0.1", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(host, "::1", StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsPrivateLocalDb(string connectionString)
        {
            string server = new SqlConnectionStringBuilder(connectionString).DataSource;
            return server.StartsWith(@"(localdb)\", StringComparison.OrdinalIgnoreCase) &&
                !server.StartsWith(@"(localdb)\.\", StringComparison.OrdinalIgnoreCase);
        }

        private static SqlConnection Open(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch
            {
                connection.Dispose();
                throw;
            }
        }
    }
}
