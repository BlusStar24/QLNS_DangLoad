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

namespace QLNS.ChamCongg
{
    public partial class frChamCong : Form
    {
       
        public frChamCong()
        {
            InitializeComponent();
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
        public void loaddatagirdview(int selectedYear, int selectedMonth)
        {
            // Tạo danh sách các ngày trong tháng
            int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);

            // Chuỗi truy vấn SQL
            string query = @"
    SELECT nv.MaNV, 
           nv.HoTenNV, 
           pb.TenPB, 
           cc.NgayCC
    FROM ChamCong cc
    INNER JOIN NhanVien nv ON nv.MaNV = cc.MaNV
    INNER JOIN PhongBan pb ON nv.MaPB = pb.MaPB
    WHERE YEAR(cc.NgayCC) = @Year
      AND MONTH(cc.NgayCC) = @Month";
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
                        dgv_chamcong.DataSource = displayTable;
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi nếu xảy ra
                    MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void frChamCong_Load(object sender, EventArgs e)
        {
            loadcombobox();
          

        }

        private void dgv_HDNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_xem_Click(object sender, EventArgs e)
        {
            int selectedYear = int.Parse(cbx_nam.SelectedItem.ToString());
            int selectedMonth = int.Parse(cbx_thang.SelectedItem.ToString());

            loaddatagirdview(selectedYear, selectedMonth);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemCongNV frthemcong = new ThemCongNV();
            frthemcong.Show();
        }

        private void dgv_chamcong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
