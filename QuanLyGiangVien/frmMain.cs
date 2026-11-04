using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmMain : Form
    {
        private Session session;

        internal frmMain(Session current) : this()
        {
            if (current == null)
                throw new ArgumentNullException(nameof(current));

            session = current;
            lblWelcome.Text = "Xin chào, " + session.Username;
            btnPhanQuyen.Click += btnPhanQuyen_Click;
            Shown += (s, e) => Ui.Run(this, RefreshAccountRights);
            btnChuyenmon.Click += (s, e) =>
            {
                Ui.Run(this, () =>
                {
                    if (!session.Can("frmSpecialization", ActionRight.View))
                        throw new UserMessage("Bạn không có quyền xem chuyên môn.");

                    using (var form = new frmSpecialization(session.UserId))
                    {
                        form.ShowDialog(this);
                    }
                });
            };

            btnHocphan.Click += (s, e) =>
            {
                Ui.Run(this, () =>
                {
                    if (!session.Can("frmCourse", ActionRight.View))
                        throw new UserMessage("Bạn không có quyền xem học phần.");

                    using (var form = new frmCourse(session.UserId))
                    {
                        form.ShowDialog(this);
                    }
                });
            };
            btnChucvu.Click += (s, e) =>
            {
                Ui.Run(this, () =>
                {
                    if (!session.Can("frmPosition", ActionRight.View))
                        throw new UserMessage("Bạn không có quyền xem chức vụ.");

                    using (var form = new frmPosition(session.UserId))
                    {
                        form.ShowDialog(this);
                    }
                });
            };
            btnHocVi.Click += (s, e) =>
            {
                Ui.Run(this, () =>
                {
                    if (!session.Can("frmDegree", ActionRight.View))
                        throw new UserMessage("Bạn không có quyền xem học vị.");

                    using (var form = new frmDegree(session.UserId))
                    {
                        form.ShowDialog(this);
                    }
                });
            };
            btnGV.Click += (s, e) =>
            {
                Ui.Run(this, () =>
                {
                    if (!session.Can("frmLecturer", ActionRight.View))
                        throw new UserMessage("Bạn không có quyền xem giảng viên.");

                    using (var form = new frmLecturer(session.UserId))
                    {
                        form.ShowDialog(this);
                    }
                });
            };
        }
        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        public frmMain()
        {
            InitializeComponent();

            // Cho phép Sidebar cuộn lên / xuống
            pnlSidebar.AutoScroll = true;

            // Không cho nội dung Sidebar tự co giãn
            pnlSidebar.AutoSize = false;

            // Gắn sự kiện cho các nút chính
            btnTongQuan.Click += btnTongQuan_Click;
            btnHeThong.Click += btnHeThong_Click;
            btnDanhMuc.Click += btnDanhMuc_Click;
            btnDaoTao.Click += btnDaoTao_Click;
            btnThongKe.Click += btnThongKe_Click;
            btnBaoCao.Click += btnBaoCao_Click;
            btnDanhsach.Click += (s, e) => OpenReport(() => new frmReportLecturer(), "frmReportLecturer");
            btnPc.Click += (s, e) => OpenReport(() => new frmReportTeachingAssignment(), "frmReportTeachingAssignment");
            btnBD.Click += (s, e) => OpenReport(() => new frmChartDashboard(), "frmChartDashboard");
            btnKLGD.Click += (s, e) => OpenReport(() => new frmTeachingWorkload(), "frmTeachingWorkload");
            btnPhanCong.Click += (s, e) => OpenReport(() => new frmTeachingAssignment(), "frmTeachingAssignment");

            // Nút đăng xuất
            btnDangXuat.Click += btnDangXuat_Click;
        }


        // ============================================================
        // FORM LOAD
        // ============================================================
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Khi mở chương trình:
            // Chỉ hiển thị các menu chính
            // Các menu con sẽ được ẩn đi
            pnlHeThong.Visible = false;
            pnlDanhMuc.Visible = false;
            pnlDaoTao.Visible = false;
            pnlTK.Visible = false;
            pnlBaoCao.Visible = false;

            // Sắp xếp lại Sidebar
            UpdateSidebarLayout();
        }


        // ============================================================
        // TỔNG QUAN
        // ============================================================
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Bạn đang ở trang Tổng quan.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        // ============================================================
        // HỆ THỐNG
        // ============================================================
        private void btnHeThong_Click(object sender, EventArgs e)
        {
            // Nếu đang mở thì đóng
            // Nếu đang đóng thì mở
            pnlHeThong.Visible = !pnlHeThong.Visible;

            // Cập nhật lại vị trí tất cả menu phía dưới
            UpdateSidebarLayout();
        }


        // ============================================================
        // DANH MỤC
        // ============================================================
        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            pnlDanhMuc.Visible = !pnlDanhMuc.Visible;

            UpdateSidebarLayout();
        }


        // ============================================================
        // ĐÀO TẠO
        // ============================================================
        private void btnDaoTao_Click(object sender, EventArgs e)
        {
            pnlDaoTao.Visible = !pnlDaoTao.Visible;

            UpdateSidebarLayout();
        }


        // ============================================================
        // THỐNG KÊ
        // ============================================================
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            pnlTK.Visible = !pnlTK.Visible;

            UpdateSidebarLayout();
        }


        // ============================================================
        // BÁO CÁO
        // ============================================================
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            pnlBaoCao.Visible = !pnlBaoCao.Visible;

            UpdateSidebarLayout();
        }


        // ============================================================
        // HÀM SẮP XẾP LẠI SIDEBAR
        // ============================================================
        private void UpdateSidebarLayout()
        {
            // Khoảng cách bắt đầu
            int y = 10;

            // Chiều cao các nút menu chính
            int mainButtonHeight = 45;

            // Khoảng cách nhỏ giữa các nhóm
            int spacing = 5;


            // ========================================================
            // 1. TỔNG QUAN
            // ========================================================
            btnTongQuan.Location = new Point(12, y);

            y += mainButtonHeight + spacing;


            // ========================================================
            // 2. HỆ THỐNG
            // ========================================================
            btnHeThong.Location = new Point(12, y);

            y += mainButtonHeight;

            if (pnlHeThong.Visible)
            {
                pnlHeThong.Location = new Point(9, y);

                y += pnlHeThong.Height + spacing;
            }


            // ========================================================
            // 3. DANH MỤC
            // ========================================================
            btnDanhMuc.Location = new Point(9, y);

            y += mainButtonHeight;

            if (pnlDanhMuc.Visible)
            {
                pnlDanhMuc.Location = new Point(9, y);

                y += pnlDanhMuc.Height + spacing;
            }


            // ========================================================
            // 4. ĐÀO TẠO
            // ========================================================
            btnDaoTao.Location = new Point(9, y);

            y += mainButtonHeight;

            if (pnlDaoTao.Visible)
            {
                pnlDaoTao.Location = new Point(9, y);

                y += pnlDaoTao.Height + spacing;
            }


            // ========================================================
            // 5. THỐNG KÊ
            // ========================================================
            btnThongKe.Location = new Point(9, y);

            y += mainButtonHeight;

            if (pnlTK.Visible)
            {
                pnlTK.Location = new Point(9, y);

                y += pnlTK.Height + spacing;
            }


            // ========================================================
            // 6. BÁO CÁO
            // ========================================================
            btnBaoCao.Location = new Point(9, y);

            y += mainButtonHeight;

            if (pnlBaoCao.Visible)
            {
                pnlBaoCao.Location = new Point(9, y);

                y += pnlBaoCao.Height + spacing;
            }


            // ========================================================
            // 7. ĐĂNG XUẤT
            // ========================================================
            btnDangXuat.Location = new Point(12, y);

            y += btnDangXuat.Height + 20;


            // ========================================================
            // Cập nhật vùng cuộn của Sidebar
            // ========================================================
            pnlSidebar.AutoScrollMinSize = new Size(0, y);
        }


        // ============================================================
        // ĐĂNG XUẤT
        // ============================================================
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            // Nếu người dùng bấm OK
            if (result == DialogResult.OK)
            {
                Close();
            }

            // Nếu bấm Cancel thì không làm gì
        }


        // ============================================================
        // CÁC EVENT CŨ TRONG DESIGNER
        // ============================================================
        // Các hàm dưới đây được giữ lại để Designer không báo lỗi.
        // Sau này Bo có thể dùng chúng để mở các Form tương ứng.


        private void lblTitle_Click(object sender, EventArgs e)
        {
            // Không xử lý gì
        }


        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {
            // Không xử lý gì
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            // Event cũ của btnDaoTao
            // Logic mở menu đã được xử lý bởi btnDaoTao_Click
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Không xử lý gì
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Ui.Run(this, () =>
            {
                if (session == null)
                    throw new UserMessage("Bạn chưa đăng nhập.");

                if (!session.Can("frmDepartment", ActionRight.View))
                    throw new UserMessage("Bạn không có quyền xem bộ môn.");

                using (var form = new frmDepartment(session.UserId))
                {
                    form.ShowDialog(this);
                }
            });
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Ui.Run(this, () =>
            {
                if (session == null)
                    throw new UserMessage("Bạn chưa đăng nhập.");

                if (!session.Can("frmFaculty", ActionRight.View))
                    throw new UserMessage("Bạn không có quyền xem khoa.");

                using (var form = new frmFaculty(session.UserId))
                {
                    form.ShowDialog(this);
                }
            });
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenAccountForm(AccountService.Accounts, () => new frmUserManagement(session));
        }


        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            OpenAccountForm(null, () => new frmChangePassword(session));
        }


        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            OpenAccountForm(AccountService.Roles, () => new frmRoleManagement(session));
        }

        // Đọc lại quyền khi mở Main và sau khi đóng màn hình tài khoản.
        private void RefreshAccountRights()
        {
            btnNguoiDung.Enabled = false;
            btnPhanQuyen.Enabled = false;
            btnDoiMatKhau.Enabled = false;
            if (session == null) return;

            using (var db = Session.Open())
            {
                var user = session.Current(db);
                btnNguoiDung.Enabled = Session.Allows(db, user.MaVaiTro,
                    AccountService.Accounts, ActionRight.View);
                btnPhanQuyen.Enabled = Session.Allows(db, user.MaVaiTro,
                    AccountService.Roles, ActionRight.View);
                // Người dùng có phiên hợp lệ được đổi mật khẩu của chính mình.
                btnDoiMatKhau.Enabled = true;
            }
        }

        private void OpenAccountForm(string formName, Func<Form> createForm)
        {
            Ui.Run(this, () =>
            {
                if (session == null)
                    throw new UserMessage("Bạn chưa đăng nhập.");

                // Kiểm tra lại tại lúc bấm, kể cả khi nút đang được bật.
                using (var db = Session.Open())
                {
                    var user = session.Current(db);
                    if (formName != null &&
                        !Session.Allows(db, user.MaVaiTro, formName, ActionRight.View))
                        throw new UserMessage("Bạn không có quyền mở chức năng này.");
                }

                try
                {
                    using (var form = createForm()) form.ShowDialog(this);
                }
                finally
                {
                    Ui.Run(this, RefreshAccountRights);
                }
            });
        }

        private void OpenReport(Func<Form> createForm, string formName)
        {
            Ui.Run(this, () =>
            {
                if (session != null && !session.Can(formName, ActionRight.View))
                    throw new UserMessage("Bạn không có quyền xem chức năng này.");
                using (var form = createForm()) form.ShowDialog(this);
            });
        }


        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            // Không xử lý gì
        }


        private void lblDashboard_Click(object sender, EventArgs e)
        {
            // Không xử lý gì
        }


        private void label13_Click(object sender, EventArgs e)
        {
            // Không xử lý gì
        }


        private void label15_Click(object sender, EventArgs e)
        {
            // Không xử lý gì
        }
    }
}