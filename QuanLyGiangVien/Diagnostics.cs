using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace QuanLyGiangVien
{
    internal static class Diagnostics
    {
        internal static void SqlFailure(SqlException error)
        {
            // Chỉ ghi mã chẩn đoán. Không ghi mật khẩu, salt, hash hoặc chuỗi kết nối.
            try
            {
                // Đường dẫn tương đối với thư mục làm việc của ứng dụng.
                string folder = "Logs";
                Directory.CreateDirectory(folder);
                string line = DateTime.UtcNow.ToString("O") + " SQL Number=" + error.Number +
                    " State=" + error.State + " Class=" + error.Class +
                    " ClientConnectionId=" + error.ClientConnectionId + Environment.NewLine;
                File.AppendAllText(Path.Combine(folder, "sql-" + DateTime.UtcNow.ToString("yyyyMMdd") + ".log"), line, Encoding.UTF8);
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
        }
    }
}
