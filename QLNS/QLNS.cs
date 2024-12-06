using QLNS.Helper;
using QLNS.Login;
using QLNS.NhanSu;
using QLNS.PhongBan;
using QLNS.TinhLuong;
using QLNS.ChamCongg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class formQLNS : Form
    {
        public formQLNS()
        {
            InitializeComponent();
        }
        private void formQLNS_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void btn_NhanSu_Click(object sender, EventArgs e)
        {
            doiMauSidebar();
            btn_NhanSu.BackColor = Color.DodgerBlue;
            panelContainer.Controls.Clear();
            formNhanSu ns = new formNhanSu();
            ns.TopLevel = false;
            ns.FormBorderStyle = FormBorderStyle.None;
            ns.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ns);
            ns.Show();
        }

        private void btn_PhongBan_Click(object sender, EventArgs e)
        {
            doiMauSidebar();
            btn_PhongBan.BackColor = Color.DodgerBlue;
            panelContainer.Controls.Clear();
            formPhongBan pb = new formPhongBan();
            pb.TopLevel = false;
            pb.FormBorderStyle = FormBorderStyle.None;
            pb.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(pb);
            pb.Show();
        }

        private void btn_TinhLuong_Click(object sender, EventArgs e)
        {
            doiMauSidebar();
            btn_TinhLuong.BackColor = Color.DodgerBlue;
            panelContainer.Controls.Clear();
            TinhLuong.ThongKe tl = new TinhLuong.ThongKe();
            tl.TopLevel = false;
            tl.FormBorderStyle = FormBorderStyle.None;
            tl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(tl);
            tl.Show();
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            doiMauSidebar();
            btn_ThongKe.BackColor = Color.DodgerBlue;
            panelContainer.Controls.Clear();
            ThongKe.ThongKe tk = new ThongKe.ThongKe();
            tk.TopLevel = false;
            tk.FormBorderStyle = FormBorderStyle.None;
            tk.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(tk);
            tk.Show();
        }

        public void doiMauSidebar()
        {

            btn_NhanSu.BackColor = Color.Blue;
            btn_PhongBan.BackColor = Color.Blue;
            btn_TinhLuong.BackColor = Color.Blue;
            btn_ThongKe.BackColor = Color.Blue;
            btn_ChamCong.BackColor = Color.Blue;
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn đăng xuất không?",
            "Xác nhận đăng xuất",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã đăng xuất thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                formDangNhap frmDangNhap = new formDangNhap();
                frmDangNhap.Show();
            }
            else
            {
                MessageBox.Show("Bạn đã hủy thao tác đăng xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void formQLNS_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.UserID = null;
            SessionManager.Username = null;
            SessionManager.UserRole = null;
        }

        private void btn_ChamCong_Click(object sender, EventArgs e)
        {
            doiMauSidebar();
            btn_ChamCong.BackColor = Color.DodgerBlue;
            panelContainer.Controls.Clear();
            frChamCong tl = new frChamCong();
            tl.TopLevel = false;
            tl.FormBorderStyle = FormBorderStyle.None;
            tl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(tl);
            tl.Show();
        }
    }
}
