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

namespace QLNS.TinhLuong.ChildForm
{
    public partial class ChuyenCan : Form
    {
        public ChuyenCan()
        {
            InitializeComponent();
        }

        public void loadcombobox()
        {

            // Clear dữ liệu cũ (nếu có)
            cbx_thang.Items.Clear();
            cbx_loai.Items.Clear();

            // Load dữ liệu cho combobox tháng
            for (int i = 1; i <= 12; i++)
            {
                cbx_thang.Items.Add(i);
            }

            // Load dữ liệu cho combobox loại
            string[] loai = { "A", "B", "C" };
            foreach (string item in loai)
            {
                cbx_loai.Items.Add(item);
            }

            // Thiết lập giá trị mặc định cho cbx_thang nếu cần
            if (cbx_thang.Items.Count > 0)
                cbx_thang.SelectedIndex = 0;

            // Thiết lập giá trị mặc định cho cbx_loai nếu cần
            if (cbx_loai.Items.Count > 0)
                cbx_loai.SelectedIndex = 0;

        }
        public void LoadChuyenCan()
        {
            string query = @"
SELECT 
    nv.MaNV, 
    nv.HoTenNV AS TenNhanVien, 
    COUNT(cc.MaCC) AS SoNgayCong, 
    CASE 
        WHEN COUNT(cc.MaCC) >= 26 THEN 'A'
        WHEN COUNT(cc.MaCC) >= 20 THEN 'B'
        ELSE 'C'
    END AS LoaiChuyenCan,
    CASE 
        WHEN COUNT(cc.MaCC) >= 26 THEN 300000
        WHEN COUNT(cc.MaCC) >= 20 THEN 150000
        ELSE 0
    END AS TienThuongChuyenCan
FROM NhanVien nv
INNER JOIN ChamCong cc ON nv.MaNV = cc.MaNV
GROUP BY nv.MaNV, nv.HoTenNV";

            using (SqlConnection conn = new SqlConnection(KetNoi.kn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                        // Tạo DataTable để lưu dữ liệu
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        // Kiểm tra nếu không có dữ liệu
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dGVChuyenCan.DataSource = null;
                            return;
                        }

                        

                        // Gán dữ liệu lên DataGridView
                        dGVChuyenCan.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChuyenCan_Load(object sender, EventArgs e)
        {
            loadcombobox();
            LoadChuyenCan();
            dGVChuyenCan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Tự động điều chỉnh hàng
            dGVChuyenCan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Mở rộng DataGridView theo khung hình
            dGVChuyenCan.Dock = DockStyle.Fill;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ combobox
            string loaiChuyenCan = cbx_loai.SelectedItem?.ToString();
            string thangText = cbx_thang.SelectedItem?.ToString();
            int thang = 0;

            // Nếu combobox tháng có giá trị, chuyển đổi sang số
            if (!string.IsNullOrEmpty(thangText))
            {
                thang = int.Parse(thangText);
            }

            // Truy vấn SQL
            string query = @"
SELECT 
    nv.MaNV, 
    nv.HoTenNV AS TenNhanVien, 
    COUNT(cc.MaCC) AS SoNgayCong, 
    CASE 
        WHEN COUNT(cc.MaCC) >= 26 THEN 'A'
        WHEN COUNT(cc.MaCC) >= 20 THEN 'B'
        ELSE 'C'
    END AS LoaiChuyenCan,
    CASE 
        WHEN COUNT(cc.MaCC) >= 26 THEN 300000
        WHEN COUNT(cc.MaCC) >= 20 THEN 150000
        ELSE 0
    END AS TienThuongChuyenCan
FROM NhanVien nv
INNER JOIN ChamCong cc ON nv.MaNV = cc.MaNV
WHERE (@Thang = 0 OR MONTH(cc.NgayCC) = @Thang)
GROUP BY nv.MaNV, nv.HoTenNV";

            using (SqlConnection conn = new SqlConnection(KetNoi.kn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số
                        cmd.Parameters.AddWithValue("@Thang", thang);

                        // Tạo DataTable để lưu dữ liệu
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        // Kiểm tra nếu không có dữ liệu
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Lọc dữ liệu theo loại chuyên cần nếu được chọn
                        if (!string.IsNullOrEmpty(loaiChuyenCan))
                        {
                            var filteredData = dt.AsEnumerable()
                                                 .Where(row => row["LoaiChuyenCan"].ToString() == loaiChuyenCan);

                            // Chỉ gán lại DataTable nếu có dữ liệu sau lọc
                            if (filteredData.Any())
                            {
                                dt = filteredData.CopyToDataTable();
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu phù hợp với loại chuyên cần đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        // Gán dữ liệu lên DataGridView
                        dGVChuyenCan.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
