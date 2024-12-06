using QLNS.PhongBan;
using QLNS.TinhLuong.ChildForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS.TinhLuong
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doiMauText();
            button1.ForeColor = Color.Blue;
            panelPage.Controls.Clear();
            ChamCong cc = new ChamCong();
            cc.TopLevel = false;
            cc.FormBorderStyle = FormBorderStyle.None;
            cc.Dock = DockStyle.Fill;
            panelPage.Controls.Add(cc);
            cc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doiMauText();
            button2.ForeColor = Color.Blue;
            panelPage.Controls.Clear();
            ChuyenCan cc = new ChuyenCan();
            cc.TopLevel = false;
            cc.FormBorderStyle = FormBorderStyle.None;
            cc.Dock = DockStyle.Fill;
            panelPage.Controls.Add(cc);
            cc.Show();
        }
        public void doiMauText()
        {
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
        }
    }
}
