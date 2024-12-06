using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QLNS.Helper;

namespace QLNS.ThongKe
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        private void LoadEmployeeStats()
        {
            string connectionString = KetNoi.kn;
            string query = @"
        SELECT pb.TenPB, COUNT(nv.MaNV) AS SoLuongNV
        FROM PhongBan pb
        LEFT JOIN NhanVien nv ON pb.MaPB = nv.MaPB
        GROUP BY pb.TenPB";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Xóa dữ liệu cũ trong biểu đồ trước khi thêm mới
                            chartNVPB.Series.Clear();

                            // Tạo một chuỗi mới cho biểu đồ cột
                            chartNVPB.Series.Add("Số Lượng Nhân Viên");
                            chartNVPB.Series["Số Lượng Nhân Viên"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                            // Lặp qua dữ liệu và thêm các điểm vào biểu đồ
                            while (reader.Read())
                            {
                                string departmentName = reader["TenPB"].ToString();
                                int employeeCount = Convert.ToInt32(reader["SoLuongNV"]);

                                // Thêm điểm dữ liệu vào biểu đồ (tên phòng ban, số lượng nhân viên)
                                chartNVPB.Series["Số Lượng Nhân Viên"].Points.AddXY(departmentName, employeeCount);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadEmployeeStatsToPanelWithGroupBox()
        {
            string connectionString = KetNoi.kn; // Thay bằng chuỗi kết nối của bạn
            string query = @"
        SELECT pb.TenPB, COUNT(nv.MaNV) AS SoLuongNV
        FROM PhongBan pb
        LEFT JOIN NhanVien nv ON pb.MaPB = nv.MaPB
        GROUP BY pb.TenPB";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Xóa các điều khiển cũ để tránh trùng lặp khi gọi lại
                            panel_ThongKe.Controls.Clear();

                            int yPosition = 10; // Vị trí Y cho GroupBox đầu tiên

                            // Lặp qua kết quả từ truy vấn và tạo GroupBox
                            while (reader.Read())
                            {
                                string departmentName = reader["TenPB"].ToString();
                                int employeeCount = Convert.ToInt32(reader["SoLuongNV"]);

                                // Tạo GroupBox
                                GroupBox groupBox = new GroupBox
                                {
                                    Text = departmentName, // Tiêu đề GroupBox là tên phòng ban
                                    Font = new Font("Segoe UI", 10, FontStyle.Bold), // Font cho tiêu đề in đậm
                                    Location = new Point(10, yPosition), // Vị trí trên panel
                                    Size = new Size(300, 70) // Kích thước cố định cho GroupBox
                                };

                                // Tạo Label để hiển thị số lượng nhân viên bên trong GroupBox
                                Label lblEmployeeCount = new Label
                                {
                                    Text = $"Số Lượng Nhân Viên: {employeeCount}",
                                    Location = new Point(10, 30), // Vị trí bên trong GroupBox
                                    AutoSize = true,
                                    Font = new Font("Segoe UI", 10, FontStyle.Regular)
                                };

                                // Thêm Label vào GroupBox
                                groupBox.Controls.Add(lblEmployeeCount);

                                // Thêm GroupBox vào panel_ThongKe
                                panel_ThongKe.Controls.Add(groupBox);

                                // Cập nhật vị trí Y cho GroupBox tiếp theo
                                yPosition += groupBox.Height + 10;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadEmployeeStatsToPanelWithGroupBox2()
        {
            string connectionString = KetNoi.kn; // Thay bằng chuỗi kết nối của bạn

            // Truy vấn để lấy số lượng nhân viên chính thức và thử việc
            string query = @"
    SELECT ml.TenLoai, COUNT(nv.MaNV) AS SoLuongNV
    FROM NhanVien nv
    JOIN MaLoaiNV ml ON nv.MaLoai = ml.MaLoai
    WHERE ml.TenLoai IN (N'Chính thức', N'Thử việc')
    GROUP BY ml.TenLoai";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Xóa các điều khiển cũ để tránh trùng lặp khi gọi lại
                            panel_LoaiNV.Controls.Clear();

                            // Tạo GroupBox cho "Thống Kê Loại Nhân Viên"
                            GroupBox groupBoxLoaiNV = new GroupBox
                            {
                                Text = "Thống Kê Loại Nhân Viên", // Tiêu đề GroupBox
                                Font = new Font("Segoe UI", 10, FontStyle.Bold), // Font cho tiêu đề in đậm
                                Location = new Point(10, 10), // Vị trí trên panel
                                Size = new Size(300, 100), // Kích thước cố định cho GroupBox
                                Padding = new Padding(10), // Padding cho GroupBox để tạo khoảng cách giữa các điều khiển bên trong
                            };

                            int chinhThucCount = 0;
                            int thuViecCount = 0;

                            // Lặp qua kết quả từ truy vấn và lấy số lượng nhân viên theo loại
                            while (reader.Read())
                            {
                                string loaiNhanVien = reader["TenLoai"].ToString();
                                int employeeCount = Convert.ToInt32(reader["SoLuongNV"]);

                                if (loaiNhanVien == "Chính thức")
                                {
                                    chinhThucCount = employeeCount;
                                }
                                else if (loaiNhanVien == "Thử việc")
                                {
                                    thuViecCount = employeeCount;
                                }
                            }

                            // Tạo Label để hiển thị số lượng nhân viên chính thức
                            Label lblChinhThuc = new Label
                            {
                                Text = $"Nhân viên Chính thức: {chinhThucCount}",
                                Location = new Point(10, 30), // Vị trí bên trong GroupBox
                                AutoSize = true,
                                Font = new Font("Segoe UI", 10, FontStyle.Regular)
                            };

                            // Tạo Label để hiển thị số lượng nhân viên thử việc
                            Label lblThuViec = new Label
                            {
                                Text = $"Nhân viên Thử việc: {thuViecCount}",
                                Location = new Point(10, 50), // Vị trí bên trong GroupBox
                                AutoSize = true,
                                Font = new Font("Segoe UI", 10, FontStyle.Regular)
                            };

                            // Thêm Labels vào GroupBox
                            groupBoxLoaiNV.Controls.Add(lblChinhThuc);
                            groupBoxLoaiNV.Controls.Add(lblThuViec);

                            // Thêm GroupBox vào panel_LoaiNV
                            panel_LoaiNV.Controls.Add(groupBoxLoaiNV);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void LoadEmployeeStatsToPieChart()
        {
            string connectionString = KetNoi.kn; // Thay bằng chuỗi kết nối của bạn
            string query = @"
            SELECT 
                ml.TenLoai AS LoaiNhanVien, 
                COUNT(nv.MaNV) AS SoLuong
            FROM 
                NhanVien nv
            JOIN 
                MaLoaiNV ml ON nv.MaLoai = ml.MaLoai
            WHERE 
                ml.TenLoai IN (N'Chính thức', N'Thử việc')
            GROUP BY 
                ml.TenLoai";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        // Dọn sạch dữ liệu cũ trên biểu đồ trước khi thêm dữ liệu mới
                        chartLoaiNV.Series.Clear();
                        chartLoaiNV.Legends.Clear();

                        // Thêm dữ liệu vào biểu đồ tròn
                        Series series = new Series
                        {
                            Name = "Employee Stats",
                            IsVisibleInLegend = true,
                            ChartType = SeriesChartType.Pie // Chọn kiểu biểu đồ tròn
                        };

                        while (reader.Read())
                        {
                            string category = reader["LoaiNhanVien"].ToString();
                            int count = Convert.ToInt32(reader["SoLuong"]);
                            series.Points.AddXY(category, count);
                        }

                        // Thêm series vào biểu đồ
                        chartLoaiNV.Series.Add(series);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            LoadEmployeeStats();
            LoadEmployeeStatsToPanelWithGroupBox();
            LoadEmployeeStatsToPanelWithGroupBox2();
            LoadEmployeeStatsToPieChart();
        }

        private void panel_LoaiNV_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
