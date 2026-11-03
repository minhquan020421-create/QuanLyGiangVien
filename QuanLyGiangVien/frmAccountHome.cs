using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmAccountHome : Form
    {
        private readonly Session session;

        // Constructor không truy cập database, dành cho WinForms Designer.
        public frmAccountHome()
        {
            InitializeComponent();
        }

        internal frmAccountHome(Session current) : this()
        {
            if (current == null) throw new ArgumentNullException(nameof(current));
            session = current;
            lblCurrentUser.Text = "Đã đăng nhập · " + session.Username;
            btnAccounts.Enabled = btnRoles.Enabled = false;

            Bind(btnAccounts, () =>
            {
                using (var form = new frmUserManagement(session)) form.ShowDialog(this);
            });
            Bind(btnRoles, () =>
            {
                using (var form = new frmRoleManagement(session)) form.ShowDialog(this);
            });
            Bind(btnPassword, () =>
            {
                using (var form = new frmChangePassword(session)) form.ShowDialog(this);
            });
            Bind(btnLogout, Close);
            Bind(btnTheme, Theme.Toggle);
            Shown += (sender, e) => RefreshRights();
            Theme.Apply(this);
        }

        private void Bind(Button button, Action action)
        {
            button.Click += (sender, e) =>
            {
                Ui.Run(this, action);
                if (!IsDisposed && Visible) RefreshRights();
            };
        }

        private void RefreshRights()
        {
            btnAccounts.Enabled = btnRoles.Enabled = false;
            try
            {
                btnAccounts.Enabled = session.Can(AccountService.Accounts, ActionRight.View);
                btnRoles.Enabled = session.Can(AccountService.Roles, ActionRight.View);
            }
            catch (UserMessage error)
            {
                MessageBox.Show(this, error.Message);
                Close();
            }
            catch (SqlException error)
            {
                Diagnostics.SqlFailure(error);
                MessageBox.Show(this, "Mất kết nối dữ liệu.");
                Close();
            }
        }
    }
}
