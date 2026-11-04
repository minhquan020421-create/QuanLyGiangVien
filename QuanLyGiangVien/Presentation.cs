using System;
using System.Configuration;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    internal sealed class Preferences : ApplicationSettingsBase
    {
        internal static readonly Preferences Values = new Preferences();
        [UserScopedSetting, DefaultSettingValue("True")]
        public bool Dark { get { return (bool)this["Dark"]; } set { this["Dark"]=value; } }
        [UserScopedSetting, DefaultSettingValue("")]
        public string RememberedName { get { return (string)this["RememberedName"]; } set { this["RememberedName"]=value; } }
    }

    internal static class Ui
    {
        internal static void Run(Form form, Action action, Label message=null)
        {
            try { if(message!=null) message.Text=""; action(); }
            catch(UserMessage e) { Feedback(form,message,e.Message); }
            catch(ChangeConflictException) { Feedback(form,message,"Dữ liệu đã thay đổi. Hãy làm mới rồi thử lại."); }
            catch(SqlException e)
            {
                string text = e.Number==2601 || e.Number==2627 ? "Giá trị đã tồn tại. Hãy kiểm tra lại." :
                    e.Number==547 ? "Dữ liệu đang được sử dụng hoặc đã thay đổi." :
                    e.Number == 4060 ? "Chưa mở được database QuanLyGiangVien. Hãy kiểm tra cấu hình." :
                    e.Number == 18456 ? "SQL Server từ chối tài khoản kết nối Windows." :
                    "Chưa kết nối được SQL Server. Hãy thử lại. Mã lỗi: " + e.Number;
                Diagnostics.SqlFailure(e);
                Feedback(form,message,text);
            }
            catch(ConfigurationErrorsException) { Feedback(form,message,"Không đọc hoặc lưu được cấu hình ứng dụng."); }
        }
        private static void Feedback(Form f,Label label,string message)
        {
            if(label!=null) label.Text=message;
            else MessageBox.Show(f,message,"Quản lý giảng viên",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        internal static bool Confirm(Form f,string message)
        {
            return MessageBox.Show(f,message,"Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2)==DialogResult.Yes;
        }
    }

    internal static class Theme
    {
        internal static void Toggle()
        {
            Preferences.Values.Dark=!Preferences.Values.Dark;
            Preferences.Values.Save();
            foreach(Form f in Application.OpenForms) Apply(f);
        }
        private static void DrawOption(object sender, DrawItemEventArgs e)
        {
            var combo=(ComboBox)sender;
            bool selected=(e.State & DrawItemState.Selected)!=0 && (e.State & DrawItemState.ComboBoxEdit)==0;
            Color background=selected ? SystemColors.Highlight : combo.BackColor;
            using (var brush=new SolidBrush(background)) e.Graphics.FillRectangle(brush,e.Bounds);
            if(e.Index>=0 && e.Index<combo.Items.Count)
            {
                var rect=e.Bounds; rect.Inflate(-3,0);
                TextRenderer.DrawText(e.Graphics,combo.GetItemText(combo.Items[e.Index]),combo.Font,rect,
                    selected ? SystemColors.HighlightText : combo.ForeColor,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
            }
            e.DrawFocusRectangle();
        }

        private static Color FieldColor(bool dark)
        {
            return dark ? Color.FromArgb(17,29,46) : Color.White;
        }

        private static Color MutedColor(bool dark)
        {
            return dark ? Color.FromArgb(181,199,220) : Color.FromArgb(71,87,108);
        }

        private static void DrawDisabledButton(object sender, PaintEventArgs e)
        {
            var button = (Button)sender;
            if (button.Enabled) return;

            bool dark = Preferences.Values.Dark;
            e.Graphics.Clear(FieldColor(dark));
            using (var pen = new Pen(button.FlatAppearance.BorderColor))
                e.Graphics.DrawRectangle(pen, 0, 0, button.ClientSize.Width - 1, button.ClientSize.Height - 1);

            var bounds = button.ClientRectangle;
            bounds.X += button.Padding.Left + 3;
            bounds.Width = Math.Max(0, bounds.Width - button.Padding.Horizontal - 6);
            var alignment = button.TextAlign == ContentAlignment.MiddleLeft ? TextFormatFlags.Left :
                button.TextAlign == ContentAlignment.MiddleRight ? TextFormatFlags.Right : TextFormatFlags.HorizontalCenter;
            TextRenderer.DrawText(e.Graphics, button.Text, button.Font, bounds, MutedColor(dark), alignment |
                TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.HidePrefix);
        }

        internal static void Apply(Form f)
        {
            bool dark=Preferences.Values.Dark;
            Color background=dark ? Color.FromArgb(16,23,37) : Color.FromArgb(239,243,249);
            Color surface=dark ? Color.FromArgb(27,39,58) : Color.White;
            Color field=FieldColor(dark);
            Color ink=dark ? Color.FromArgb(236,242,251) : Color.FromArgb(25,42,70);
            Color muted=MutedColor(dark);
            Color border=dark ? Color.FromArgb(62,82,110) : Color.FromArgb(194,207,221);
            Color accent=dark ? Color.FromArgb(144,211,240) : Color.FromArgb(23,96,132);
            Color alert=dark ? Color.FromArgb(255,165,157) : Color.Firebrick;
            f.BackColor=background; f.ForeColor=ink;
            Action<Control> visit=null;
            visit=c=>{
                if(c is DataGridView)
                {
                    var g=(DataGridView)c;
                    g.EnableHeadersVisualStyles=false; g.BackgroundColor=surface; g.BorderStyle=BorderStyle.None;
                    g.ColumnHeadersBorderStyle=DataGridViewHeaderBorderStyle.Single; g.CellBorderStyle=DataGridViewCellBorderStyle.SingleHorizontal;
                    g.GridColor=border; g.ColumnHeadersDefaultCellStyle.BackColor=field; g.ColumnHeadersDefaultCellStyle.ForeColor=accent;
                    g.ColumnHeadersDefaultCellStyle.SelectionBackColor=field; g.ColumnHeadersDefaultCellStyle.SelectionForeColor=accent;
                    g.DefaultCellStyle.BackColor=surface; g.DefaultCellStyle.ForeColor=ink;
                    g.AlternatingRowsDefaultCellStyle.BackColor=dark ? Color.FromArgb(31,45,65) : Color.FromArgb(245,248,252);
                    g.DefaultCellStyle.SelectionBackColor=dark ? Color.FromArgb(47,75,112) : Color.FromArgb(211,232,255);
                    g.DefaultCellStyle.SelectionForeColor=ink;
                    return;
                }
                if(c is Panel)
                {
                    bool dashboardBackground = f is frmMain && (c.Name == "pnlContent" ||
                        c.Name == "layoutDashboard" || c.Name == "layoutCounts" || c.Name == "pnlQuickActions");
                    c.BackColor = dashboardBackground ? background : surface;
                }
                else if(c is DateTimePicker)
                {
                    var picker = (DateTimePicker)c;
                    picker.CalendarMonthBackground = field;
                    picker.CalendarForeColor = ink;
                    picker.CalendarTitleBackColor = surface;
                    picker.CalendarTitleForeColor = accent;
                    picker.CalendarTrailingForeColor = muted;
                }
                else if(c is TextBox || c is ComboBox || c is ListBox || c is NumericUpDown) { c.BackColor=field; c.ForeColor=ink;
                    var combo=c as ComboBox; if(combo!=null)
                    {
                        combo.FlatStyle=FlatStyle.Flat;
                        combo.DrawMode=DrawMode.OwnerDrawFixed;
                        combo.DrawItem-=DrawOption;
                        combo.DrawItem+=DrawOption;
                    } }
                else if(c is Button)
                {
                    var b=(Button)c;
                    bool primary=b.Name=="btnDangNhap" || b.Name=="btnDoiMatKhau" && f is frmChangePassword ||
                                 b.Name.StartsWith("btnLuu") || (b.Name=="btnThem" || b.Name=="btnThemVaiTro") || b.Name=="btnAccounts";
                    b.FlatStyle=FlatStyle.Flat; b.UseVisualStyleBackColor=false; b.Cursor=Cursors.Hand;
                    b.BackColor=primary ? Color.FromArgb(49,91,190) : surface;
                    b.ForeColor=primary ? Color.White : b.Name.StartsWith("btnXoa") ? alert : ink;
                    b.FlatAppearance.BorderSize=primary ? 0 : 1; b.FlatAppearance.BorderColor=border;
                    b.FlatAppearance.MouseOverBackColor=primary ? Color.FromArgb(59,107,208) : field;
                    b.Paint -= DrawDisabledButton;
                    b.Paint += DrawDisabledButton;
                    if(b.Name=="btnTheme") b.Text=dark ? "Giao diện sáng" : "Giao diện tối";
                }
                else if(c is Label || c is CheckBox)
                {
                    c.BackColor=Color.Transparent;
                    c.ForeColor=c.Name=="lblThongBao" || c.Name=="lblDashboardMessage" ? alert :
                        c.Name.StartsWith("lblIcon") ? accent :
                        c.Name.Contains("TieuDe") || c.Name=="lblTenHeThong" || c.Name=="lblDangNhap" ||
                        f is frmMain && c.Name.StartsWith("lblSo") ? ink : muted;
                }
                foreach(Control child in c.Controls) visit(child);
            };
            foreach(Control child in f.Controls) visit(child);
        }
    }
}
