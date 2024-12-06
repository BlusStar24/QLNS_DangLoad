using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS.NhanSu.ChildForm;

namespace QLNS.NhanSu
{
    public partial class formNhanSu : Form
    {
        public formNhanSu()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            doiMauText();
            button1.ForeColor = Color.Blue;
            panelPage.Controls.Clear();
            formDanhSachNhanVien dsnv = new formDanhSachNhanVien();
            dsnv.TopLevel = false;
            dsnv.FormBorderStyle = FormBorderStyle.None;
            dsnv.Dock = DockStyle.Fill;
            panelPage.Controls.Add(dsnv);
            dsnv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doiMauText();
            button2.ForeColor = Color.Blue;
            panelPage.Controls.Clear();
            formHopDongNhanVien hdnv = new formHopDongNhanVien();
            hdnv.TopLevel = false;
            hdnv.FormBorderStyle = FormBorderStyle.None;
            hdnv.Dock = DockStyle.Fill;
            panelPage.Controls.Add(hdnv);
            hdnv.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doiMauText();
            button3.ForeColor = Color.Blue;
            panelPage.Controls.Clear();
            formBaoHiemXaHoi bhxh = new formBaoHiemXaHoi();
            bhxh.TopLevel = false;
            bhxh.FormBorderStyle = FormBorderStyle.None;
            bhxh.Dock = DockStyle.Fill;
            panelPage.Controls.Add(bhxh);
            bhxh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            doiMauText();
            button4.ForeColor = Color.Blue;
            panelPage.Controls.Clear();
            DanhSachNghiViec dsnv = new DanhSachNghiViec();
            dsnv.TopLevel = false;
            dsnv.FormBorderStyle = FormBorderStyle.None;
            dsnv.Dock = DockStyle.Fill;
            panelPage.Controls.Add(dsnv);
            dsnv.Show();
        }

        public void doiMauText()
        {
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.White;
        }
    }
}
