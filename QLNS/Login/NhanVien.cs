using QLNS.ChamCongg;
using QLNS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS.Login
{
    public partial class NhanVien : Form
    {

        SqlConnection connection;
        public NhanVien()
        {
            InitializeComponent();
            connection = new SqlConnection(KetNoi.kn);
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            loadcombobox();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            string userName = SessionManager.Username;
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Không tìm thấy UserID trong session.");
                return;
            }

            string query = @"SELECT DISTINCT
                        N.MaNV, N.HoTenNV, N.NgaySinh, N.GioiTinh, N.DiaChi, N.CCCD, 
                        N.SoDienThoai, N.Email, N.HocVan, N.ChungChiNN, 
                        L.TenLoai, N.NgayVaoLam, B.SoBHXH, H.MaHD, 
                        H.NgayBatDau, H.NgayKetThuc
                    FROM 
                        NhanVien N
                    LEFT JOIN 
                        MaLoaiNV L ON N.MaLoai = L.MaLoai
                    LEFT JOIN 
                        BaoHiemXaHoi B ON N.MaNV = B.MaNV
                    LEFT JOIN 
                        HopDongNhanVien H ON N.MaNV = H.MaNV
                    WHERE 
                        N.MaNV = @MaNV";

            using (SqlConnection conn = new SqlConnection(KetNoi.kn))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", userName);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txt_MaNV.Text = reader["MaNV"]?.ToString() ?? string.Empty;
                        txt_HoTen.Text = reader["HoTenNV"]?.ToString() ?? string.Empty;
                        txt_NgaySinh.Text = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]).ToString("dd/MM/yyyy") : string.Empty;
                        txt_GioiTinh.Text = reader["GioiTinh"]?.ToString() ?? string.Empty;
                        txt_DiaChi.Text = reader["DiaChi"]?.ToString() ?? string.Empty;
                        txt_CCCD.Text = reader["CCCD"]?.ToString() ?? string.Empty;
                        txt_SoDienThoai.Text = reader["SoDienThoai"]?.ToString() ?? string.Empty;
                        txt_Email.Text = reader["Email"]?.ToString() ?? string.Empty;
                        txt_TDHocVan.Text = reader["HocVan"]?.ToString() ?? string.Empty;
                        txt_CCNN.Text = reader["ChungChiNN"]?.ToString() ?? string.Empty;
                        txt_LoaiNV.Text = reader["TenLoai"]?.ToString() ?? string.Empty;
                        txt_NgayVaoLam.Text = reader["NgayVaoLam"] != DBNull.Value ? Convert.ToDateTime(reader["NgayVaoLam"]).ToString("dd/MM/yyyy") : string.Empty;
                        txt_SoBHXH.Text = reader["SoBHXH"]?.ToString() ?? string.Empty;
                        txt_MaHD.Text = reader["MaHD"]?.ToString() ?? string.Empty;
                        txt_BatDauHD.Text = reader["NgayBatDau"] != DBNull.Value ? Convert.ToDateTime(reader["NgayBatDau"]).ToString("dd/MM/yyyy") : string.Empty;
                        txt_KetThucHD.Text = reader["NgayKetThuc"] != DBNull.Value ? Convert.ToDateTime(reader["NgayKetThuc"]).ToString("dd/MM/yyyy") : string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu cho nhân viên.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.UserID = null;
            SessionManager.Username = null;
            SessionManager.UserRole = null;
        }
        public void loaddatagirdview(int selectedYear, int selectedMonth)
        {
            // Tạo danh sách các ngày trong tháng
            int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);
            string manv = SessionManager.Username;  // Lấy UserID của người dùng hiện tại

            // Chuỗi truy vấn SQL với điều kiện lọc theo MaNV (UserID)
            string query = @"
    SELECT nv.MaNV, 
           nv.HoTenNV, 
           pb.TenPB, 
           cc.NgayCC
    FROM ChamCong cc
    INNER JOIN NhanVien nv ON nv.MaNV = cc.MaNV
    INNER JOIN PhongBan pb ON nv.MaPB = pb.MaPB
    WHERE YEAR(cc.NgayCC) = @Year
      AND MONTH(cc.NgayCC) = @Month
      AND nv.MaNV = @MaNV";  // Thêm điều kiện lọc theo MaNV

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(KetNoi.kn))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand để thực thi truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho truy vấn
                        command.Parameters.AddWithValue("@Year", selectedYear);
                        command.Parameters.AddWithValue("@Month", selectedMonth);
                        command.Parameters.AddWithValue("@MaNV", manv);  // Thêm tham số cho MaNV

                        // Tạo SqlDataAdapter để điền dữ liệu vào DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        // Tạo DataTable để lưu kết quả
                        DataTable dataTable = new DataTable();

                        // Điền dữ liệu từ truy vấn vào DataTable
                        adapter.Fill(dataTable);

                        // Tạo bảng hiển thị kết quả
                        DataTable displayTable = new DataTable();
                        displayTable.Columns.Add("MaNV", typeof(string));
                        displayTable.Columns.Add("HoTenNV", typeof(string));
                        displayTable.Columns.Add("TenPB", typeof(string));

                        // Thêm các cột tương ứng với mỗi ngày
                        for (int day = 1; day <= daysInMonth; day++)
                        {
                            displayTable.Columns.Add($"Ngày {day}", typeof(string));
                        }

                        // Duyệt qua từng nhân viên và điền dữ liệu
                        var groupedData = dataTable.AsEnumerable().GroupBy(row => new
                        {
                            MaNV = row["MaNV"].ToString(),
                            HoTenNV = row["HoTenNV"].ToString(),
                            TenPB = row["TenPB"].ToString()
                        });

                        foreach (var group in groupedData)
                        {
                            DataRow newRow = displayTable.NewRow();
                            newRow["MaNV"] = group.Key.MaNV;
                            newRow["HoTenNV"] = group.Key.HoTenNV;
                            newRow["TenPB"] = group.Key.TenPB;

                            // Điền thông tin chấm công
                            foreach (var day in group.Select(g => g["NgayCC"]).Distinct())
                            {
                                if (day != DBNull.Value)
                                {
                                    DateTime chấmCôngDate = Convert.ToDateTime(day);
                                    int columnIndex = chấmCôngDate.Day; // Lấy ngày trong tháng
                                    newRow[$"Ngày {columnIndex}"] = "Đã chấm công";
                                }
                            }

                            // Các ngày không có dữ liệu chấm công
                            for (int day = 1; day <= daysInMonth; day++)
                            {
                                if (newRow[$"Ngày {day}"] == null)
                                {
                                    newRow[$"Ngày {day}"] = "Chưa chấm công";
                                }
                            }

                            displayTable.Rows.Add(newRow);
                        }

                        // Đổ dữ liệu vào DataGridView
                        dGVChamCong.DataSource = displayTable;
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi nếu xảy ra
                    MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void loadcombobox()
        {
            // Clear dữ liệu cũ (nếu có)
            cbx_thang.Items.Clear();
            cbx_nam.Items.Clear();

            // Load dữ liệu cho combobox tháng
            for (int i = 1; i <= 12; i++)
            {
                cbx_thang.Items.Add(i);
            }

            // Load dữ liệu cho combobox năm
            int currentYear = DateTime.Now.Year;
            for (int year = 2000; year <= currentYear; year++)
            {
                cbx_nam.Items.Add(year);
            }

            // Thiết lập giá trị mặc định nếu cần
            if (cbx_thang.Items.Count > 0)
                cbx_thang.SelectedIndex = 0;
            if (cbx_nam.Items.Count > 0)
                cbx_nam.SelectedIndex = cbx_nam.Items.Count - 1;
        }
        private void btn_ChamCong_Click(object sender, EventArgs e)
        {
            string maNV = SessionManager.Username;

            // Lấy thông tin từ giao diện
            DateTime ngayChamCong;
            TimeSpan gioVaoLam;
            TimeSpan gioTanLam;

            // Sử dụng thời gian hiện tại nếu không nhập dữ liệu
            ngayChamCong = DateTime.Now;
            gioVaoLam = DateTime.Now.TimeOfDay;
            gioTanLam = DateTime.Now.TimeOfDay;

            // Chuỗi truy vấn SQL để chèn dữ liệu vào bảng ChamCong
            string insertQuery = @"
    INSERT INTO ChamCong (MaNV, NgayCC, GioVaoLam, GioTanLam)
    VALUES (@MaNV, @NgayCC, @GioVaoLam, @GioTanLam)";

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(KetNoi.kn)) // ketNoi.kn là chuỗi kết nối của bạn
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand để thực thi truy vấn
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Thêm tham số cho truy vấn
                        command.Parameters.AddWithValue("@MaNV", maNV);
                        command.Parameters.AddWithValue("@NgayCC", ngayChamCong);
                        command.Parameters.AddWithValue("@GioVaoLam", gioVaoLam.ToString());
                        command.Parameters.AddWithValue("@GioTanLam", gioTanLam.ToString());

                        // Thực thi câu lệnh SQL
                        command.ExecuteNonQuery();
                    }

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Lưu thông tin chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi nếu có
                    MessageBox.Show($"Lỗi khi lưu thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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

        private void btn_xem_Click(object sender, EventArgs e)
        {
            int selectedYear = int.Parse(cbx_nam.SelectedItem.ToString());
            int selectedMonth = int.Parse(cbx_thang.SelectedItem.ToString());

            loaddatagirdview(selectedYear, selectedMonth);
        }
    }
}
