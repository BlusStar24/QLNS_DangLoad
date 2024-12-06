using QLNS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLNS.NhanSu.ChildForm
{
    public partial class ThemHopDong : Form
    {
        SqlConnection connection;
        public ThemHopDong()
        {
            InitializeComponent();
            connection = new SqlConnection(KetNoi.kn);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ThoiHanHD.Text) || string.IsNullOrWhiteSpace(txt_MucLuong.Text) ||
                string.IsNullOrWhiteSpace(txt_NgayBD.Text) || string.IsNullOrWhiteSpace(txt_NgayKT.Text) ||
                string.IsNullOrWhiteSpace(txt_MaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm hợp đồng này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                string maNV = txt_MaNV.Text;
                string thoiHanHopDong = txt_ThoiHanHD.Text;
                DateTime ngayBatDau = DateTime.Parse(txt_NgayBD.Text);
                DateTime ngayKetThuc = DateTime.Parse(txt_NgayKT.Text);
                double mucLuong = double.Parse(txt_MucLuong.Text);

                string query = "INSERT INTO HopDongNhanVien (MaNV, ThoiHanHopDong, NgayBatDau, NgayKetThuc, MucLuong) " +
                               "VALUES (@MaNV, @ThoiHanHopDong, @NgayBatDau, @NgayKetThuc, @MucLuong)";

                using (SqlConnection connection = new SqlConnection(KetNoi.kn))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@MaNV", maNV);
                    command.Parameters.AddWithValue("@ThoiHanHopDong", thoiHanHopDong);
                    command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                    command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                    command.Parameters.AddWithValue("@MucLuong", mucLuong);

                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Thêm hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy thao tác và đóng form?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
