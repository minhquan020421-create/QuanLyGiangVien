using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Any(arg => string.Equals(arg, "--hao", StringComparison.OrdinalIgnoreCase)))
                Application.Run(new frmLogin());
            else
                Application.Run(new frmMain());
        }
    }
}