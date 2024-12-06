using QLNS.Helper;
using QLNS.TinhLuong.ChildForm;
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

namespace QLNS.ChamCongg
{
    public partial class ThemCongNV : Form
    {
       
        public ThemCongNV()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        private void btn_luu_Click(object sender, EventArgs e, KetNoi ketNoi)
        {
            string maNV = cbx_manv.SelectedItem?.ToString().Trim();
            // Kiểm tra mã nhân viên hợp lệ bằng SQL sử dụng DataSet
            var checkMaNVQuery = "SELECT COUNT(1) FROM NhanVien WHERE MaNV = @MaNV";
            DataSet ds = new DataSet();

            using (SqlDataAdapter da = new SqlDataAdapter(checkMaNVQuery,KetNoi.kn))
            {
                da.SelectCommand.Parameters.AddWithValue("@MaNV", maNV);
                da.Fill(ds);
            }

            // Kiểm tra kết quả truy vấn
            int result = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            if (result == 0)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy thông tin từ giao diện
            DateTime ngayChamCong;
            TimeSpan gioVaoLam = TimeSpan.Parse(masktxt_gvl.Text);
            TimeSpan gioTanLam = TimeSpan.Parse(masktxt_gtl.Text);

            // Kiểm tra dữ liệu nhập vào
            if (!DateTime.TryParse(dtP_ncc.Text, out ngayChamCong) ||
                !TimeSpan.TryParse(masktxt_gvl.Text, out gioVaoLam) ||
                !TimeSpan.TryParse(masktxt_gtl.Text, out gioTanLam))
            {
                MessageBox.Show("Dữ liệu không hợp lệ! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra giá trị GioVaoLam hợp lệ
            if (gioVaoLam < TimeSpan.FromHours(0) || gioVaoLam >= TimeSpan.FromHours(24))
            {
                MessageBox.Show("Giờ vào làm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sử dụng DataSet để thêm dữ liệu vào bảng ChamCong
            string insertQuery = @"
    INSERT INTO ChamCong (MaNV, NgayCC, GioVaoLam, GioTanLam)
    VALUES (@MaNV, @NgayCC, @GioVaoLam, @GioTanLam)";

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(KetNoi.kn)) // sử dụng SqlConnection từ ketNoi
            {
                // Mở kết nối
                connection.Open();

                // Tạo SqlDataAdapter và chỉ định kết nối
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Tạo câu lệnh Insert và chỉ định kết nối
                    da.InsertCommand = new SqlCommand(insertQuery, connection);

                    // Thêm tham số vào câu lệnh Insert
                    da.InsertCommand.Parameters.AddWithValue("@MaNV", maNV);
                    da.InsertCommand.Parameters.AddWithValue("@NgayCC", ngayChamCong);
                    da.InsertCommand.Parameters.AddWithValue("@GioVaoLam", gioVaoLam.ToString());
                    da.InsertCommand.Parameters.AddWithValue("@GioTanLam", gioTanLam.ToString());

                    // Cập nhật dữ liệu vào cơ sở dữ liệu (Không cần gọi Fill ở đây)
                    da.InsertCommand.ExecuteNonQuery(); // Dùng ExecuteNonQuery để thực thi câu lệnh Insert

                    MessageBox.Show("Lưu thông tin chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


            MessageBox.Show("Lưu thông tin chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa các trường nhập liệu
            cbx_manv.SelectedIndex = - 1;
            masktxt_gvl.Clear();
            masktxt_gtl.Clear();
        }
        public void LoadComboBoxMaNV(ComboBox comboBox)
        {
            string sql = "SELECT MaNV FROM NhanVien";
            using (SqlConnection conn = new SqlConnection(KetNoi.kn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox.Items.Clear(); // Xóa các mục cũ
                            while (reader.Read())
                            {
                                comboBox.Items.Add(reader["MaNV"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txt_mnv_TextChanged(object sender, EventArgs e)
        {
            string maNV = cbx_manv.SelectedItem?.ToString().Trim();

            // Chuỗi kết nối đến cơ sở dữ liệu


            // Câu truy vấn SQL
            string sql = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";

            using (SqlConnection conn = new SqlConnection(KetNoi.kn))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Thêm tham số vào truy vấn
                        cmd.Parameters.AddWithValue("@MaNV", maNV);

                        // Thực thi truy vấn và kiểm tra kết quả
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            cbx_manv.ForeColor = Color.Blue;
                        }
                        else
                        {
                            cbx_manv.ForeColor = Color.Red;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string maNV = cbx_manv.SelectedItem?.ToString().Trim();

            // Kiểm tra mã nhân viên hợp lệ bằng SQL sử dụng DataSet
            var checkMaNVQuery = "SELECT COUNT(1) FROM NhanVien WHERE MaNV = @MaNV";
            DataSet ds = new DataSet();

            using (SqlDataAdapter da = new SqlDataAdapter(checkMaNVQuery, KetNoi.kn))
            {
                da.SelectCommand.Parameters.AddWithValue("@MaNV", maNV);
                da.Fill(ds);
            }

            // Kiểm tra kết quả truy vấn
            int result = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            if (result == 0)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy thông tin từ giao diện
            DateTime ngayChamCong;
            TimeSpan gioVaoLam = TimeSpan.Parse(masktxt_gvl.Text);
            TimeSpan gioTanLam = TimeSpan.Parse(masktxt_gtl.Text);

            // Kiểm tra dữ liệu nhập vào
            if (!DateTime.TryParse(dtP_ncc.Text, out ngayChamCong) ||
                !TimeSpan.TryParse(masktxt_gvl.Text, out gioVaoLam) ||
                !TimeSpan.TryParse(masktxt_gtl.Text, out gioTanLam))
            {
                MessageBox.Show("Dữ liệu không hợp lệ! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra giá trị GioVaoLam hợp lệ
            if (gioVaoLam < TimeSpan.FromHours(0) || gioVaoLam >= TimeSpan.FromHours(24))
            {
                MessageBox.Show("Giờ vào làm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sử dụng DataSet để thêm dữ liệu vào bảng ChamCong
            string insertQuery = @"
    INSERT INTO ChamCong (MaNV, NgayCC, GioVaoLam, GioTanLam)
    VALUES (@MaNV, @NgayCC, @GioVaoLam, @GioTanLam)";

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(KetNoi.kn)) // sử dụng SqlConnection từ ketNoi
            {
                // Mở kết nối
                connection.Open();

                // Tạo SqlDataAdapter và chỉ định kết nối
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Tạo câu lệnh Insert và chỉ định kết nối
                    da.InsertCommand = new SqlCommand(insertQuery, connection);

                    // Thêm tham số vào câu lệnh Insert
                    da.InsertCommand.Parameters.AddWithValue("@MaNV", maNV);
                    da.InsertCommand.Parameters.AddWithValue("@NgayCC", ngayChamCong);
                    da.InsertCommand.Parameters.AddWithValue("@GioVaoLam", gioVaoLam.ToString());
                    da.InsertCommand.Parameters.AddWithValue("@GioTanLam", gioTanLam.ToString());

                    // Cập nhật dữ liệu vào cơ sở dữ liệu (Không cần gọi Fill ở đây)
                    da.InsertCommand.ExecuteNonQuery(); // Dùng ExecuteNonQuery để thực thi câu lệnh Insert

                    MessageBox.Show("Lưu thông tin chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


            MessageBox.Show("Lưu thông tin chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa các trường nhập liệu
            cbx_manv.Text = "";
            masktxt_gvl.Clear();
            masktxt_gtl.Clear();
        }

        private void ThemCongNV_Load(object sender, EventArgs e)
        {
            LoadComboBoxMaNV(cbx_manv);
        }
    }
}
