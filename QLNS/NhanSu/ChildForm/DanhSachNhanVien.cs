using Microsoft.Office.Interop.Excel;
using QLNS.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLNS.NhanSu.ChildForm
{
    public partial class formDanhSachNhanVien : Form
    {

        SqlConnection connection;

        public formDanhSachNhanVien()
        {
            InitializeComponent();
            connection = new SqlConnection(KetNoi.kn);
            txtMaNV.Enabled = false;
            txtNgayVaoLam.Enabled = false;
        }

        private void LoadData()
        {
            try
            {
                string query = "SELECT N.MaNV, N.HoTenNV, N.GioiTinh, N.NgaySinh, N.CCCD, N.Email, N.SoDienThoai, N.DiaChi, " +
                               "N.HocVan, N.ChungChiNN, " +
                               "L.MaLoai, L.TenLoai, N.NgayVaoLam " +  
                               "FROM NhanVien N " +
                               "JOIN MaLoaiNV L ON N.MaLoai = L.MaLoai " +
                               "WHERE N.MaLoai != 'NVNV'";


                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);
                dGVListNV.DataSource = dataTable;

                if (dGVListNV.Rows.Count > 0)
                {
                    dGVListNV.Rows[0].Selected = true;
                    dGVListNV.CurrentCell = dGVListNV.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                string loaiNVQuery = "SELECT MaLoai, TenLoai FROM MaLoaiNV";
                SqlDataAdapter loaiNVAdapter = new SqlDataAdapter(loaiNVQuery, connection);
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

        private void buttonThemNhanVien_Click(object sender, EventArgs e)
        {
            formThemNhanVien tnv = new formThemNhanVien();
            tnv.StartPosition = FormStartPosition.CenterScreen;
            tnv.ShowDialog();
        }

        private void formDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            dGVListNV.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
            dGVListNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            loadGioiTinh();
            LoadData();
            LoadComboBoxes();
            HideColumns();
            loadHocVan();
            loadCTNN();
            CustomizeColumnHeaders();
            CustomizeColumnHeadersStyle();
            DisableTextBox();
            btnCapNhat.Visible = false;
            btnHuy.Visible = false;
            if (dGVListNV.Rows.Count > 0)
            {
                dGVListNV.Rows[0].Selected = true;
                DisplaySelectedRowData(dGVListNV.Rows[0]);
            }
        }
        private void DisplaySelectedRowData(DataGridViewRow selectedRow)
        {
            txtMaNV.Text = selectedRow.Cells["MaNV"].Value?.ToString() ?? string.Empty;
            txtHoTen.Text = selectedRow.Cells["HoTenNV"].Value?.ToString() ?? string.Empty;

            if (DateTime.TryParse(selectedRow.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaySinh))
            {
                mTBNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
            }
            else
            {
                mTBNgaySinh.Text = string.Empty;
            }

            txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value?.ToString() ?? string.Empty;
            txtCCCD.Text = selectedRow.Cells["CCCD"].Value?.ToString() ?? string.Empty;
            txtSDT.Text = selectedRow.Cells["SoDienThoai"].Value?.ToString() ?? string.Empty;
            txtEmail.Text = selectedRow.Cells["Email"].Value?.ToString() ?? string.Empty;

            cBLoaiNV.SelectedItem = selectedRow.Cells["MaLoai"].Value?.ToString() ?? "NVTV";

            if (DateTime.TryParse(selectedRow.Cells["NgayVaoLam"].Value?.ToString(), out DateTime ngayVaoLam))
            {
                txtNgayVaoLam.Text = ngayVaoLam.ToString("dd/MM/yyyy");
            }
            else
            {
                txtNgayVaoLam.Text = string.Empty;
            }

            string gioiTinh = selectedRow.Cells["GioiTinh"].Value?.ToString();
            cBGioiTinh.SelectedItem = gioiTinh;

            string hocVan = selectedRow.Cells["HocVan"].Value?.ToString();
            if (cBHocVan.Items.Contains(hocVan))
            {
                cBHocVan.SelectedItem = hocVan;
            }
            else
            {
                cBHocVan.SelectedIndex = -1;
            }

            string chungChiNN = selectedRow.Cells["ChungChiNN"].Value?.ToString();
            if (cBCCNN.Items.Contains(chungChiNN))
            {
                cBCCNN.SelectedItem = chungChiNN;
            }
            else
            {
                cBCCNN.SelectedIndex = -1;
            }
        }


        private void CustomizeColumnHeadersStyle()
        {
            dGVListNV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dGVListNV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void HideColumns()
        {
            if (dGVListNV.Columns.Contains("MaLoai"))
            {
                dGVListNV.Columns["MaLoai"].Visible = false;
            }
        }

        private void dGVListNV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                e.CellStyle.Padding = new Padding(5, 0, 5, 0);
            }
        }

        private void dGVListNV_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVListNV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dGVListNV.SelectedRows[0];

                txtMaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = selectedRow.Cells["HoTenNV"].Value.ToString();

                DateTime ngaySinh;
                if (DateTime.TryParse(selectedRow.Cells["NgaySinh"].Value.ToString(), out ngaySinh))
                {
                    mTBNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                }
                else
                {
                    mTBNgaySinh.Text = string.Empty;
                    MessageBox.Show("Ngày sinh không hợp lệ.");
                }

                txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                txtCCCD.Text = selectedRow.Cells["CCCD"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                cBLoaiNV.SelectedValue = selectedRow.Cells["MaLoai"].Value;

                DateTime ngayVaoLam;
                if (DateTime.TryParse(selectedRow.Cells["NgayVaoLam"].Value.ToString(), out ngayVaoLam))
                {
                    txtNgayVaoLam.Text = ngayVaoLam.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgayVaoLam.Text = string.Empty;
                    MessageBox.Show("Ngày vào làm không hợp lệ.");
                }

                string gioiTinh = selectedRow.Cells["GioiTinh"].Value.ToString();
                if (cBGioiTinh.Items.Contains(gioiTinh))
                {
                    cBGioiTinh.SelectedItem = gioiTinh;
                }

                string hocVan = selectedRow.Cells["HocVan"].Value?.ToString();
                if (cBHocVan.Items.Contains(hocVan))
                {
                    cBHocVan.SelectedItem = hocVan;
                }
                else
                {
                    cBHocVan.SelectedIndex = -1;
                }

                string chungChiNN = selectedRow.Cells["ChungChiNN"].Value?.ToString();
                if (cBCCNN.Items.Contains(chungChiNN))
                {
                    cBCCNN.SelectedItem = chungChiNN;
                }
                else
                {
                    cBCCNN.SelectedIndex = -1;
                }
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

        private void dGVListNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn clickedColumn = dGVListNV.Columns[e.ColumnIndex];

                if (clickedColumn.Name == "MaNV")
                {
                    DataGridViewRow selectedRow = dGVListNV.Rows[e.RowIndex];

                    txtMaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                    txtHoTen.Text = selectedRow.Cells["HoTenNV"].Value.ToString();

                    DateTime ngaySinh;
                    if (DateTime.TryParse(selectedRow.Cells["NgaySinh"].Value.ToString(), out ngaySinh))
                    {
                        mTBNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        mTBNgaySinh.Text = string.Empty;
                        MessageBox.Show("Ngày sinh không hợp lệ.");
                    }

                    txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                    txtCCCD.Text = selectedRow.Cells["CCCD"].Value.ToString();
                    txtSDT.Text = selectedRow.Cells["SoDienThoai"].Value.ToString();
                    txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                    cBLoaiNV.SelectedValue = selectedRow.Cells["MaLoai"].Value;

                    DateTime ngayVaoLam;
                    if (DateTime.TryParse(selectedRow.Cells["NgayVaoLam"].Value.ToString(), out ngayVaoLam))
                    {
                        txtNgayVaoLam.Text = ngayVaoLam.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtNgayVaoLam.Text = string.Empty;
                        MessageBox.Show("Ngày vào làm không hợp lệ.");
                    }

                    string gioiTinh = selectedRow.Cells["GioiTinh"].Value.ToString();
                    if (cBGioiTinh.Items.Contains(gioiTinh))
                    {
                        cBGioiTinh.SelectedItem = gioiTinh;
                    }

                    string hocVan = selectedRow.Cells["HocVan"].Value?.ToString();
                    if (cBHocVan.Items.Contains(hocVan))
                    {
                        cBHocVan.SelectedItem = hocVan;
                    }
                    else
                    {
                        cBHocVan.SelectedIndex = -1;
                    }

                    string chungChiNN = selectedRow.Cells["ChungChiNN"].Value?.ToString();
                    if (cBCCNN.Items.Contains(chungChiNN))
                    {
                        cBCCNN.SelectedItem = chungChiNN;
                    }
                    else
                    {
                        cBCCNN.SelectedIndex = -1;
                    }
                }
            }
        }
        private void CustomizeColumnHeaders()
        {
            if (dGVListNV.Columns.Contains("MaNV"))
                dGVListNV.Columns["MaNV"].HeaderText = "Mã nhân viên";

            if (dGVListNV.Columns.Contains("HoTenNV"))
                dGVListNV.Columns["HoTenNV"].HeaderText = "Họ tên nhân viên";

            if (dGVListNV.Columns.Contains("GioiTinh"))
                dGVListNV.Columns["GioiTinh"].HeaderText = "Giới tính";

            if (dGVListNV.Columns.Contains("NgaySinh"))
                dGVListNV.Columns["NgaySinh"].HeaderText = "Ngày sinh";

            if (dGVListNV.Columns.Contains("DiaChi"))
                dGVListNV.Columns["DiaChi"].HeaderText = "Địa chỉ";

            if (dGVListNV.Columns.Contains("HocVan"))
                dGVListNV.Columns["HocVan"].HeaderText = "Trình độ học vấn";

            if (dGVListNV.Columns.Contains("CCCD"))
                dGVListNV.Columns["CCCD"].HeaderText = "Căn cước công dân";

            if (dGVListNV.Columns.Contains("SoDienThoai"))
                dGVListNV.Columns["SoDienThoai"].HeaderText = "Số điện thoại";

            if (dGVListNV.Columns.Contains("Email"))
                dGVListNV.Columns["Email"].HeaderText = "Email";

            if (dGVListNV.Columns.Contains("ChungChiNN"))
                dGVListNV.Columns["ChungChiNN"].HeaderText = "Chứng chỉ ngoại ngữ";

            if (dGVListNV.Columns.Contains("MaLoai"))
                dGVListNV.Columns["MaLoai"].HeaderText = "Mã loại nhân viên";

            if (dGVListNV.Columns.Contains("TenLoai"))
                dGVListNV.Columns["TenLoai"].HeaderText = "Loại nhân viên";

            if (dGVListNV.Columns.Contains("NgayVaoLam"))
                dGVListNV.Columns["NgayVaoLam"].HeaderText = "Ngày vào làm";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy thao tác sửa nhân viên", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DisableTextBox();
                btnSua.Enabled = true;
                btnCapNhat.Visible = false;
                btnHuy.Visible = false;
                btnExcel.Visible = true;
                btnAddNV.Visible = true;
                btnSubmit.Visible = true;
                txtSearch.Visible = true;
                label12.Visible = true;
                dGVListNV.CellClick += dGVListNV_CellClick;
                dGVListNV.SelectionChanged += dGVListNV_SelectionChanged;
            }
            else
            {
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtCCCD.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(mTBNgaySinh.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                cBGioiTinh.SelectedIndex == -1 || cBHocVan.SelectedIndex == -1 || cBCCNN.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string hoTen = txtHoTen.Text;
                    string cccd = txtCCCD.Text;
                    string gioiTinh = cBGioiTinh.SelectedItem.ToString();
                    DateTime ngaySinh = DateTime.Parse(mTBNgaySinh.Text);
                    string diaChi = txtDiaChi.Text;
                    string hocVan = cBHocVan.SelectedItem.ToString();
                    string chungChiNN = cBCCNN.SelectedItem.ToString();
                    string soDienThoai = txtSDT.Text;
                    string email = txtEmail.Text;

                    string maNV = txtMaNV.Text;

                    using (SqlConnection connection = new SqlConnection(KetNoi.kn))
                    {
                        string sqlUpdate = "UPDATE NhanVien SET " +
                                           "HoTenNV = @HoTenNV, " +
                                           "CCCD = @CCCD, " +
                                           "GioiTinh = @GioiTinh, " +
                                           "NgaySinh = @NgaySinh, " +
                                           "DiaChi = @DiaChi, " +
                                           "HocVan = @HocVan, " +
                                           "ChungChiNN = @ChungChiNN, " +
                                           "SoDienThoai = @SoDienThoai, " +
                                           "Email = @Email " +
                                           "WHERE MaNV = @MaNV";

                        SqlCommand command = new SqlCommand(sqlUpdate, connection);
                        command.CommandType = CommandType.Text;

                        command.Parameters.AddWithValue("@MaNV", maNV);
                        command.Parameters.AddWithValue("@HoTenNV", hoTen);
                        command.Parameters.AddWithValue("@CCCD", cccd);
                        command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        command.Parameters.AddWithValue("@DiaChi", diaChi);
                        command.Parameters.AddWithValue("@HocVan", hocVan);
                        command.Parameters.AddWithValue("@ChungChiNN", chungChiNN);
                        command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DisableTextBox();
                            btnSua.Enabled = true;
                            btnCapNhat.Visible = false;
                            btnHuy.Visible = false;
                            btnExcel.Visible = true;
                            btnAddNV.Visible = true;
                            btnSubmit.Visible = true;
                            txtSearch.Visible = true;
                            label12.Visible = true;
                            dGVListNV.CellClick += dGVListNV_CellClick;
                            dGVListNV.SelectionChanged += dGVListNV_SelectionChanged;
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DisableTextBox();
                    btnSua.Enabled = true;
                    btnCapNhat.Visible = false;
                    btnHuy.Visible = false;
                    btnExcel.Visible = true;
                    btnAddNV.Visible = true;
                    btnSubmit.Visible = true;
                    txtSearch.Visible = true;
                    label12.Visible = true;
                    dGVListNV.CellClick += dGVListNV_CellClick;
                    dGVListNV.SelectionChanged += dGVListNV_SelectionChanged;
                }
            }
            else
            {
                MessageBox.Show("Cập nhật bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                (dGVListNV.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("MaNV LIKE '%{0}%'", searchValue);
            }
            else
            {
                (dGVListNV.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchValue))
            {
                bool found = false;

                foreach (DataGridViewRow row in dGVListNV.Rows)
                {
                    if (row.Cells["MaNV"].Value != null &&
                        row.Cells["MaNV"].Value.ToString().Trim() == searchValue)
                    {
                        row.Selected = true;
                        dGVListNV.CurrentCell = row.Cells[0];
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("Không có nhân viên với mã NV này.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên để tìm.");
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;

                Workbook workBook = excelApp.Workbooks.Add();
                Worksheet workSheet = (Worksheet)workBook.Sheets[1];

                for (int i = 0; i < dGVListNV.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = dGVListNV.Columns[i].HeaderText;
                }

                for (int i = 0; i < dGVListNV.Rows.Count; i++)
                {
                    for (int j = 0; j < dGVListNV.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = dGVListNV.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                DateTime now = DateTime.Now;
                string formattedDateTime = now.ToString("yyyyMMdd_HHmmss");
                string filePath = $@"C:\Users\admin\Desktop\HUIT\Công nghệ .NET\FileExcel\DSNV_{formattedDateTime}.xlsx";

                workBook.SaveAs(filePath);

                workBook.Close(false);
                excelApp.Quit();

                MessageBox.Show("Dữ liệu được xuất sang Excel thành công!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisableTextBox()
        {
            txtHoTen.Enabled = false;
            mTBNgaySinh.Enabled = false;
            txtCCCD.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            cBGioiTinh.Enabled = false;
            txtDiaChi.Enabled = false;
            cBHocVan.Enabled = false;
            cBCCNN.Enabled = false;
            cBLoaiNV.Enabled = false;
        }
        private void EnabledTextBox()
        {
            txtHoTen.Enabled = true;
            mTBNgaySinh.Enabled = true;
            txtCCCD.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            cBGioiTinh.Enabled = true;
            txtDiaChi.Enabled = true;
            cBHocVan.Enabled = true;
            cBCCNN.Enabled = true;
            cBLoaiNV.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dGVListNV.CellClick -= dGVListNV_CellClick;
            dGVListNV.SelectionChanged -= dGVListNV_SelectionChanged;
            EnabledTextBox();
            btnSua.Enabled = false;
            btnCapNhat.Visible = true;
            btnHuy.Visible = true;
            btnExcel.Visible = false;
            btnAddNV.Visible = false;
            btnSubmit.Visible = false;
            txtSearch.Visible = false;
            label12.Visible = false;
        }
    }
}
