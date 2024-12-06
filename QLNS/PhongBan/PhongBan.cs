using QLNS.Helper;
using QLNS.NhanSu.ChildForm;
using QLNS.PhongBan.ChildForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLNS.PhongBan
{
    public partial class formPhongBan : Form
    {
        public formPhongBan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doiMauText();
            button1.ForeColor = Color.Blue;
            panelPage.Controls.Clear();
            DanhSachPhongBan dspb = new DanhSachPhongBan();
            dspb.TopLevel = false;
            dspb.FormBorderStyle = FormBorderStyle.None;
            dspb.Dock = DockStyle.Fill;
            panelPage.Controls.Add(dspb);
            dspb.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            doiMauText();
            button2.ForeColor = Color.Blue;
            panelPage.Controls.Clear();
            DSNhanVienPhongBan nvpb = new DSNhanVienPhongBan();
            nvpb.TopLevel = false;
            nvpb.FormBorderStyle = FormBorderStyle.None;
            nvpb.Dock = DockStyle.Fill;
            panelPage.Controls.Add(nvpb);
            nvpb.Show();
        }
        public void doiMauText()
        {
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
        }

    }
}
