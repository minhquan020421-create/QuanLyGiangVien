using System;
using System.Configuration;
using System.Data.SqlClient;

namespace QuanLyGiangVien
{
    internal static class DatabaseConnection
    {
        private const string SettingsName = "QuanLyGiangVien.Properties.Settings.QuanLyGiangVienConnectionString";
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
                // Dùng đúng database của từng máy, không tự chuyển sang máy chủ khác.
                using (var connection = Open(configured))
                    DatabaseSchema.EnsureRecoveryEmail(connection, IsLocalDatabase(configured));

                selectedConnectionString = configured;
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
