using QLNS.Helper;
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

namespace QLNS.NhanSu.ChildForm
{
    public partial class formThemNhanVien : Form
    {
        SqlConnection connection;
        public formThemNhanVien()
        {
            InitializeComponent();
            connection = new SqlConnection(KetNoi.kn);
            txt_MaNV.Enabled = false;
            txt_NgayVaoLam.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void LoadComboBox(ComboBox comboBox, string query, string displayMember, string valueMember)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(KetNoi.kn))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        comboBox.DataSource = dataTable;
                        comboBox.DisplayMember = displayMember;
                        comboBox.ValueMember = valueMember;
                        comboBox.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu vào {comboBox.Name}: {ex.Message}");
            }
        }

        private void LoadPhongBan()
        {
            string query = "SELECT MaPB, TenPB FROM PhongBan";
            LoadComboBox(cb_PhongBan, query, "TenPB", "MaPB");
        }

        private void LoadChucVu()
        {
            string query = "SELECT MaCV, TenCV FROM ChucVu";
            LoadComboBox(cb_ChucVu, query, "TenCV", "MaCV");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_HoTen.Text) || string.IsNullOrWhiteSpace(txt_CCCD.Text) ||
                string.IsNullOrWhiteSpace(txt_SoDienThoai.Text) || string.IsNullOrWhiteSpace(txt_Email.Text) ||
                string.IsNullOrWhiteSpace(mtb_NgaySinh.Text) || string.IsNullOrWhiteSpace(txt_DiaChi.Text) ||
                cb_GioiTinh.SelectedIndex == -1 || cb_TDHocVan.SelectedIndex == -1 || cb_CCNN.SelectedIndex == -1 ||
                cb_PhongBan.SelectedIndex == -1 || cb_ChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm nhân viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                string maPB = cb_PhongBan.SelectedValue.ToString();
                string maCV = cb_ChucVu.SelectedValue.ToString();
                string hoTen = txt_HoTen.Text;
                string cccd = txt_CCCD.Text;
                string gioiTinh = cb_GioiTinh.SelectedItem.ToString();
                DateTime ngaySinh = DateTime.Parse(mtb_NgaySinh.Text);
                string diaChi = txt_DiaChi.Text;
                string hocVan = cb_TDHocVan.SelectedItem.ToString();
                string chungChiNN = cb_CCNN.SelectedItem.ToString();
                DateTime ngayVaoLam = DateTime.Parse(txt_NgayVaoLam.Text);
                double luongCoBan = 5000000;
                double heSoLuong = 1;
                string soDienThoai = txt_SoDienThoai.Text;
                string email = txt_Email.Text;

                using (SqlConnection connection = new SqlConnection(KetNoi.kn))
                {
                    SqlCommand command = new SqlCommand("sp_ThemNhanVien", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaPB", maPB);
                    command.Parameters.AddWithValue("@MaCV", maCV);
                    command.Parameters.AddWithValue("@MaLoai", "NVTV");
                    command.Parameters.AddWithValue("@HoTenNV", hoTen);
                    command.Parameters.AddWithValue("@CCCD", cccd);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@HocVan", hocVan);
                    command.Parameters.AddWithValue("@ChungChiNN", chungChiNN);
                    command.Parameters.AddWithValue("@NgayVaoLam", ngayVaoLam);
                    command.Parameters.AddWithValue("@LuongCoBan", luongCoBan);
                    command.Parameters.AddWithValue("@HeSoLuong", heSoLuong);
                    command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadGioiTinh()
        {
            cb_GioiTinh.Items.Clear();
            cb_GioiTinh.Items.Add("Nam");
            cb_GioiTinh.Items.Add("Nữ");
        }

        private void loadHocVan()
        {
            cb_TDHocVan.Items.Clear();
            cb_TDHocVan.Items.Add("Không có");
            cb_TDHocVan.Items.Add("Cao Đẳng");
            cb_TDHocVan.Items.Add("Đại Học");
        }

        private void loadCTNN()
        {
            cb_CCNN.Items.Clear();
            cb_CCNN.Items.Add("Không có");
            cb_CCNN.Items.Add("Tiếng Anh");
            cb_CCNN.Items.Add("Tiếng Trung");
            cb_CCNN.Items.Add("Tiếng Nhật");
            cb_CCNN.Items.Add("Tiếng Pháp");
            cb_CCNN.Items.Add("Tiếng Hàn");
            cb_CCNN.Items.Add("Tiếng Nga");
        }

        private void formThemNhanVien_Load(object sender, EventArgs e)
        {
            loadCTNN();
            loadGioiTinh();
            loadHocVan();
            LoadPhongBan();
            LoadChucVu();
        }
    }
}
