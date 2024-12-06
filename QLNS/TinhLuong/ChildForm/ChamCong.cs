using QLNS.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QLNS.TinhLuong.ChildForm
{
    public partial class ChamCong : Form
    {
        KetNoi kn = new KetNoi();
        public ChamCong()
        {
            InitializeComponent();
            
        }
        private void LoadNhanVien(string maNV)
        {
            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(KetNoi.kn))
            {
                try
                {
                    conn.Open();

                    // Câu lệnh SQL để lấy thông tin nhân viên
                    string query = @"
                SELECT NV.MaNV, NV.HoTenNV, NV.MaPB, NV.MaCV, NV.MaLoai, CV.TenCV, PB.TenPB, L.TenLoai
                FROM NhanVien NV
                INNER JOIN ChucVu CV ON NV.MaCV = CV.MaCV
                INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB
                INNER JOIN MaLoaiNV L ON NV.MaLoai = L.MaLoai
                WHERE NV.MaNV = @MaNV";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);

                    // Đọc dữ liệu trả về
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Hiển thị dữ liệu vào các control
                        txtHoTen.Text = reader["HoTenNV"].ToString(); // Họ tên nhân viên
                        txt_pb.Text = reader["TenPB"].ToString(); // Phòng ban
                        txt_cv.Text = reader["TenCV"].ToString(); // Chức vụ
                        txt_lnv.Text = reader["TenLoai"].ToString(); // Mã loại
                                                                              // Nếu muốn hiển thị tên loại nhân viên trong cBLoaiNV
                       
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên với mã: " + maNV, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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


        private void ChamCong_Load(object sender, EventArgs e)
        {
            LoadComboBoxMaNV(cbx_manv);
            dGVChamCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Tự động điều chỉnh hàng
            dGVChamCong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Mở rộng DataGridView theo khung hình
            dGVChamCong.Dock = DockStyle.Fill;
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string maNV = cbx_manv.Text.Trim();
            if (!string.IsNullOrEmpty(maNV))
            {
                LoadNhanVien(maNV);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string maNV = cbx_manv.Text; // Giả sử bạn có một TextBox để nhập mã nhân viên
            float thucLinh = 0;

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(KetNoi.kn))
            {
                try
                {
                    conn.Open();

                    // Thực thi procedure sp_TinhLuong
                    SqlCommand cmd = new SqlCommand("sp_TinhLuong", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số đầu vào và đầu ra
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    SqlParameter thucLinhParam = new SqlParameter("@ThucLinh", SqlDbType.Float);
                    thucLinhParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(thucLinhParam);

                    // Thực thi câu lệnh và lấy giá trị lương thực lĩnh từ output
                    cmd.ExecuteNonQuery();
                    thucLinh = Convert.ToSingle(thucLinhParam.Value);


                    // Hiển thị lương thực lĩnh nếu cần (có thể in ra ở một Label hoặc MessageBox)
                    MessageBox.Show("Lương thực lĩnh của nhân viên " + maNV + " là: " + thucLinh.ToString("N0") + " VNĐ");

                    // Sau khi tính xong, lấy toàn bộ dữ liệu từ bảng TempLuong và hiển thị lên DataGridView
                    string query = @"
                SELECT 
                    BL.MaBL, 
                    NV.MaNV, 
                    NV.HoTenNV AS TenNV, 
                    BHXH.SoTienDong AS SoTienDongBHXH, 
                    XL.MaXL, 
                    CV.TenCV, 
                    NV.LuongCoBan, 
                    BL.ThucLinh
                FROM 
                    BangLuong BL
                INNER JOIN NhanVien NV ON BL.MaNV = NV.MaNV
                INNER JOIN BaoHiemXaHoi BHXH ON BL.MaBHXH = BHXH.MaBHXH
                INNER JOIN XepLoai XL ON BL.MaXL = XL.MaXL
                INNER JOIN ChucVu CV ON BL.MaCV = CV.MaCV";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Hiển thị dữ liệu lên DataGridView
                    dGVChamCong.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy mã nhân viên từ một TextBox hoặc control nào đó
            string maNV = cbx_manv.Text;

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(KetNoi.kn))
            {
                try
                {
                    conn.Open();

                    // Câu lệnh SQL để đếm số ngày công của nhân viên
                    string query = @"
                SELECT COUNT(*) AS SoNgayCong
                FROM ChamCong
                WHERE MaNV = @MaNV";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);

                    // Thực thi truy vấn và lấy kết quả
                    object result = cmd.ExecuteScalar();

                    // Kiểm tra nếu có kết quả
                    if (result != null)
                    {
                        int soNgayCong = Convert.ToInt32(result);

                        // Hiển thị số ngày công vào TextBox hoặc Label
                        textBox1.Text = "Số ngày công: " + soNgayCong.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu chấm công cho nhân viên này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
