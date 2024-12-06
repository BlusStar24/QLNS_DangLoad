using QLNS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLNS.PhongBan.ChildForm
{
    public partial class DanhSachPhongBan : Form
    {
        public Font NodeFont { get; private set; }

        public DanhSachPhongBan()
        {
            InitializeComponent();
        }
        private void LoadTreeViewWithEmployees()
        {
            string connectionString = KetNoi.kn;
            string query = @"
SELECT 
    pb.TenPB, 
    nv.HoTenNV, 
    cv.TenCV 
FROM 
    PhongBan pb
LEFT JOIN 
    NhanVien nv ON pb.MaPB = nv.MaPB
LEFT JOIN 
    ChucVu cv ON nv.MaCV = cv.MaCV
WHERE 
    (cv.TenCV IS NULL OR cv.TenCV NOT LIKE N'Nhân Viên')
ORDER BY 
    pb.TenPB, nv.HoTenNV";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            tv_PhongBan.Nodes.Clear();

                            // Thiết lập font "Segoe UI", 10pt cho TreeView
                            tv_PhongBan.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                            tv_PhongBan.ItemHeight = 30; // Tăng chiều cao nút

                            // Font riêng cho nút con
                            Font regularFont = new Font("Segoe UI", 10, FontStyle.Regular);

                            TreeNode currentDepartmentNode = null;
                            string lastDepartment = null;

                            while (reader.Read())
                            {
                                string departmentName = reader["TenPB"].ToString();
                                string employeeName = reader["HoTenNV"]?.ToString();
                                string roleName = reader["TenCV"]?.ToString();

                                // Nếu phòng ban thay đổi, tạo nút cha mới
                                if (lastDepartment != departmentName)
                                {
                                    currentDepartmentNode = new TreeNode(departmentName);
                                    tv_PhongBan.Nodes.Add(currentDepartmentNode);
                                    lastDepartment = departmentName;
                                }

                                // Thêm nhân viên vào nút con nếu có dữ liệu
                                if (!string.IsNullOrEmpty(employeeName))
                                {
                                    string displayText = $"{employeeName} - {roleName}";
                                    TreeNode employeeNode = new TreeNode(displayText)
                                    {
                                        NodeFont = regularFont // Đặt font thường cho nút con
                                    };
                                    currentDepartmentNode.Nodes.Add(employeeNode);
                                }
                            }

                            tv_PhongBan.ExpandAll(); // Mở rộng tất cả các nút
                        }
                    }

                    // Tự động điều chỉnh chiều rộng TreeView
                    AdjustTreeViewWidth(tv_PhongBan);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DanhSachPhongBan_Load(object sender, EventArgs e)
        {
            tv_PhongBan.AfterSelect += tv_PhongBan_AfterSelect;
            LoadTreeViewWithEmployees();
            loadCTNN();
            loadGioiTinh();
            loadHocVan();
            LoadComboBoxes();
            label_TenPB.Visible = false;
            txt_TenPB.Visible = false;
            btnOk.Visible = false;
            btnNo.Visible = false;

            label_ChonPB.Visible = false;
            cb_PhongBan.Visible = false;
            btnOk2.Visible = false;
            btnNo2.Visible = false;
            LoadComboTenPB(cb_PhongBan);
        }

        private void tv_PhongBan_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

        }
        private void AdjustTreeViewWidth(System.Windows.Forms.TreeView treeView)
        {
            int maxWidth = 0;
            foreach (TreeNode node in treeView.Nodes)
            {
                int width = TextRenderer.MeasureText(node.Text, treeView.Font).Width + 200; // Font mặc định là Segoe UI, 10
                maxWidth = Math.Max(maxWidth, width);

                foreach (TreeNode childNode in node.Nodes)
                {
                    width = TextRenderer.MeasureText(childNode.Text, childNode.NodeFont ?? treeView.Font).Width + 200;
                    maxWidth = Math.Max(maxWidth, width);
                }
            }

            treeView.Width = maxWidth; // Đặt chiều rộng tối ưu
        }

        private void tv_PhongBan_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1 && e.Node.Parent != null)
            {
                // Lấy thông tin nhân viên từ node
                string selectedEmployeeInfo = e.Node.Text; // Ví dụ: "Nguyễn Văn A - Trưởng Phòng"
                string[] details = selectedEmployeeInfo.Split('-');

                if (details.Length >= 2)
                {
                    string hoTen = details[0].Trim();
                    // Tìm kiếm dữ liệu trong cơ sở dữ liệu để lấy thêm thông tin nhân viên
                    LoadEmployeeDetails(hoTen);
                }
            }
        }
        private void LoadEmployeeDetails(string hoTenNV)
        {
            string connectionString = KetNoi.kn;
            string query = @"
    SELECT 
        nv.MaNV, nv.HoTenNV, nv.NgaySinh, nv.DiaChi, nv.CCCD, nv.SoDienThoai, nv.Email,
        nv.MaLoai, nv.NgayVaoLam, nv.GioiTinh, nv.HocVan, nv.ChungChiNN
    FROM NhanVien nv
    WHERE nv.HoTenNV = @HoTenNV";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HoTenNV", hoTenNV);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Gán dữ liệu vào các ô TextBox và ComboBox
                                txtMaNV.Text = reader["MaNV"].ToString();
                                txtHoTen.Text = reader["HoTenNV"].ToString();

                                if (DateTime.TryParse(reader["NgaySinh"].ToString(), out DateTime ngaySinh))
                                {
                                    mTBNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    mTBNgaySinh.Text = string.Empty;
                                }

                                txtDiaChi.Text = reader["DiaChi"].ToString();
                                txtCCCD.Text = reader["CCCD"].ToString();
                                txtSDT.Text = reader["SoDienThoai"].ToString();
                                txtEmail.Text = reader["Email"].ToString();

                                cBLoaiNV.SelectedItem = reader["MaLoai"].ToString() ?? "NVTV";

                                if (DateTime.TryParse(reader["NgayVaoLam"].ToString(), out DateTime ngayVaoLam))
                                {
                                    txtNgayVaoLam.Text = ngayVaoLam.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    txtNgayVaoLam.Text = string.Empty;
                                }

                                string gioiTinh = reader["GioiTinh"].ToString();
                                cBGioiTinh.SelectedItem = gioiTinh;

                                string hocVan = reader["HocVan"].ToString();
                                if (cBHocVan.Items.Contains(hocVan))
                                {
                                    cBHocVan.SelectedItem = hocVan;
                                }
                                else
                                {
                                    cBHocVan.SelectedIndex = -1;
                                }

                                string chungChiNN = reader["ChungChiNN"].ToString();
                                if (cBCCNN.Items.Contains(chungChiNN))
                                {
                                    cBCCNN.SelectedItem = chungChiNN;
                                }
                                else
                                {
                                    cBCCNN.SelectedIndex = -1;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void LoadComboBoxes()
        {
            try
            {
                string loaiNVQuery = "SELECT MaLoai, TenLoai FROM MaLoaiNV";
                SqlDataAdapter loaiNVAdapter = new SqlDataAdapter(loaiNVQuery, KetNoi.kn);
                System.Data.DataTable loaiNVTable = new System.Data.DataTable();
                loaiNVAdapter.Fill(loaiNVTable);
                cBLoaiNV.DataSource = loaiNVTable;
                cBLoaiNV.DisplayMember = "TenLoai";
                cBLoaiNV.ValueMember = "MaLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void loadGioiTinh()
        {
            cBGioiTinh.Items.Clear();
            cBGioiTinh.Items.Add("Nam");
            cBGioiTinh.Items.Add("Nữ");
        }

        private void loadHocVan()
        {
            cBHocVan.Items.Clear();
            cBHocVan.Items.Add("Không có");
            cBHocVan.Items.Add("Cao Đẳng");
            cBHocVan.Items.Add("Đại Học");
        }

        private void loadCTNN()
        {
            cBCCNN.Items.Clear();
            cBCCNN.Items.Add("Không có");
            cBCCNN.Items.Add("Tiếng Anh");
            cBCCNN.Items.Add("Tiếng Trung");
            cBCCNN.Items.Add("Tiếng Nhật");
            cBCCNN.Items.Add("Tiếng Pháp");
            cBCCNN.Items.Add("Tiếng Hàn");
            cBCCNN.Items.Add("Tiếng Nga");
        }

        private void btn_ThemPB_Click(object sender, EventArgs e)
        {
            label_TenPB.Visible = true;
            txt_TenPB.Visible = true;
            btnOk.Visible = true;
            btnNo.Visible = true;
            btn_XoaPB.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string connectionString = KetNoi.kn; // Chuỗi kết nối cơ sở dữ liệu
            string tenPB = txt_TenPB.Text.Trim();

            if (string.IsNullOrEmpty(tenPB))
            {
                MessageBox.Show("Vui lòng nhập tên phòng ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra trùng tên phòng ban
                    string checkQuery = "SELECT COUNT(*) FROM PhongBan WHERE TenPB = @TenPB";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@TenPB", tenPB);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Tên phòng ban đã tồn tại. Vui lòng nhập tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Thêm phòng ban mới
                    string insertQuery = "INSERT INTO PhongBan (TenPB) VALUES (@TenPB)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@TenPB", tenPB);

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Tải lại TreeView hoặc danh sách phòng ban
                            LoadComboTenPB(cb_PhongBan);
                            LoadTreeViewWithEmployees();
                            btn_XoaPB.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm phòng ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Ẩn các nút và TextBox
            ResetAddDepartmentControls();
        }


        private void btnNo_Click(object sender, EventArgs e)
        {
            // Hủy bỏ thao tác thêm phòng ban
            MessageBox.Show("Hủy thêm phòng ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Ẩn các nút và TextBox
            ResetAddDepartmentControls();
        }
        private void ResetAddDepartmentControls()
        {
            label_TenPB.Visible = false;
            txt_TenPB.Visible = false;
            btnOk.Visible = false;
            btnNo.Visible = false;
            txt_TenPB.Text = string.Empty; // Xóa dữ liệu trong TextBox
            btn_XoaPB.Visible = true;
        }

        private void LoadComboTenPB(System.Windows.Forms.ComboBox comboBox)
        {
            string connectionString = KetNoi.kn;
            string query = @"
        SELECT pb.MaPB, pb.TenPB 
        FROM PhongBan pb
        LEFT JOIN NhanVien nv ON pb.MaPB = nv.MaPB
        WHERE nv.MaPB IS NULL
        ORDER BY pb.TenPB";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox.Items.Clear();

                            while (reader.Read())
                            {
                                string maPB = reader["MaPB"].ToString();
                                string tenPB = reader["TenPB"].ToString();
                                comboBox.Items.Add(new KeyValuePair<string, string>(maPB, tenPB));
                            }

                            // Hiển thị `TenPB` trong ComboBox
                            comboBox.DisplayMember = "Value";
                            comboBox.ValueMember = "Key";

                            if (comboBox.Items.Count > 0)
                            {
                                comboBox.SelectedIndex = 0; // Chọn mục đầu tiên
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



        private void btn_XoaPB_Click(object sender, EventArgs e)
        {
            label_ChonPB.Visible = true;
            cb_PhongBan.Visible = true;
            btnOk2.Visible = true;
            btnNo2.Visible = true;
            btn_ThemPB.Visible = false;
        }

        private void btnOk2_Click(object sender, EventArgs e)
        {
            if (cb_PhongBan.SelectedItem is KeyValuePair<string, string> selectedPB)
            {
                string maPB = selectedPB.Key; // Lấy MaPB từ mục được chọn
                string tenPB = selectedPB.Value; // Lấy TenPB từ mục được chọn

                string connectionString = KetNoi.kn;
                string queryCheck = "SELECT COUNT(*) FROM NhanVien WHERE MaPB = @MaPB";
                string queryDelete = "DELETE FROM PhongBan WHERE MaPB = @MaPB";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@MaPB", maPB);
                            int employeeCount = (int)cmdCheck.ExecuteScalar();

                            if (employeeCount > 0)
                            {
                                MessageBox.Show($"Không thể xóa phòng ban '{tenPB}' vì vẫn có nhân viên trong phòng ban!",
                                                "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        using (SqlCommand cmdDelete = new SqlCommand(queryDelete, conn))
                        {
                            cmdDelete.Parameters.AddWithValue("@MaPB", maPB);
                            int rowsAffected = cmdDelete.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show($"Xóa thành công phòng ban '{tenPB}'!",
                                                "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadTreeViewWithEmployees();
                                LoadComboTenPB(cb_PhongBan);
                                CancelDeleteAction();
                                
                            }
                            else
                            {
                                MessageBox.Show($"Xóa không thành công phòng ban '{tenPB}'!",
                                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNo2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hủy xóa phòng ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CancelDeleteAction();

        }
        private void CancelDeleteAction()
        {
            label_ChonPB.Visible = false;
            cb_PhongBan.Visible = false;
            btnOk2.Visible = false;
            btnNo2.Visible = false;
            cb_PhongBan.SelectedIndex = -1;
            btn_ThemPB.Visible = true;
        }

    }
}
