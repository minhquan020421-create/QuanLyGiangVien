using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyGiangVien
{
    internal static class DatabaseSchema
    {
        private const string MigrationResource = "QuanLyGiangVien.BoSungEmailKhoiPhuc.sql";
        private const string SchemaStart = "-- BEGIN RECOVERY EMAIL SCHEMA";
        private const string SchemaEnd = "-- END RECOVERY EMAIL SCHEMA";
        private const string CheckRecoveryEmail = @"
SELECT CAST(CASE WHEN EXISTS
(
    SELECT 1
    FROM sys.columns
    WHERE object_id = OBJECT_ID(N'dbo.NGUOI_DUNG', N'U')
      AND name = N'Email'
      AND system_type_id = TYPE_ID(N'varchar')
      AND max_length = 254
      AND is_nullable = 1
      AND collation_name = N'Latin1_General_100_CI_AS'
)
AND EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE object_id = OBJECT_ID(N'dbo.NGUOI_DUNG', N'U')
      AND name = N'UX_NGUOI_DUNG_Email'
      AND is_unique = 1
      AND has_filter = 1
      AND is_disabled = 0
)
THEN 1 ELSE 0 END AS bit);";

        internal static void EnsureRecoveryEmail(SqlConnection connection, bool allowAutomaticUpgrade)
        {
            using (var check = new SqlCommand(CheckRecoveryEmail, connection))
            {
                check.CommandTimeout = 15;
                if ((bool)check.ExecuteScalar())
                    return;
            }

            if (!allowAutomaticUpgrade)
                throw new UserMessage("Cơ sở dữ liệu cần cập nhật email khôi phục. Hãy nhờ quản trị viên chạy BoSungEmailKhoiPhuc.sql.");

            // Use only the schema block. The optional manual backfill stays outside it.
            // sp_executesql also keeps the migration's SET options local to its batch.
            using (var upgrade = new SqlCommand("EXEC sys.sp_executesql @Schema;", connection))
            {
                upgrade.CommandTimeout = 30;
                upgrade.Parameters.Add("@Schema", SqlDbType.NVarChar, -1).Value = ReadSchemaBlock();
                try
                {
                    upgrade.ExecuteNonQuery();
                }
                catch (SqlException error) when (error.Number >= 50002 && error.Number <= 50005)
                {
                    throw new UserMessage(error.Message);
                }
                catch (SqlException error) when (error.Number == 229 || error.Number == 262 || error.Number == 4902)
                {
                    throw new UserMessage("Tài khoản SQL Server chưa có quyền cập nhật cột email khôi phục.");
                }
                catch (SqlException error) when (error.Number == 1505)
                {
                    throw new UserMessage("Có email khôi phục trùng trong cơ sở dữ liệu. Hãy liên hệ quản trị viên.");
                }
            }
        }

        private static string ReadSchemaBlock()
        {
            using (var stream = typeof(DatabaseSchema).Assembly.GetManifestResourceStream(MigrationResource))
            {
                if (stream == null)
                    throw new InvalidOperationException("Không tìm thấy script cập nhật email trong ứng dụng.");

                using (var reader = new StreamReader(stream))
                {
                    string script = reader.ReadToEnd();
                    int start = script.IndexOf(SchemaStart, StringComparison.Ordinal);
                    int end = script.IndexOf(SchemaEnd, StringComparison.Ordinal);
                    if (start < 0 || end <= start + SchemaStart.Length)
                        throw new InvalidOperationException("Không đọc được phần cập nhật email trong ứng dụng.");

                    start += SchemaStart.Length;
                    return script.Substring(start, end - start);
                }
            }
        }
    }
}
