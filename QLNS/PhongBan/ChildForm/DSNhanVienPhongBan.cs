using QLNS.Helper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLNS.PhongBan
{
    public partial class DSNhanVienPhongBan : Form
    {
        SqlConnection connection;

        public DSNhanVienPhongBan()
        {
            InitializeComponent();
            connection = new SqlConnection(KetNoi.kn);
            txt_MaNV.Enabled = false;
        }

        private void LoadData()
        {
            try
            {
                string query = "SELECT N.MaNV, P.MaPB, N.HoTenNV, C.MaCV, P.TenPB, C.TenCV, L.TenLoai, N.MaLoai " +
                               "FROM NhanVien N " +
                               "JOIN PhongBan P ON N.MaPB = P.MaPB " +
                               "JOIN ChucVu C ON N.MaCV = C.MaCV " +
                               "JOIN MaLoaiNV L ON N.MaLoai = L.MaLoai " +
                               "WHERE N.MaLoai != 'NVNV'";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgv_DSNVPB.DataSource = dataTable;

                if (dgv_DSNVPB.Rows.Count > 0)
                {
                    dgv_DSNVPB.Rows[0].Selected = true;
                    dgv_DSNVPB.CurrentCell = dgv_DSNVPB.Rows[0].Cells[0];
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
                string pbQuery = "SELECT MaPB, TenPB FROM PhongBan";
                SqlDataAdapter pbAdapter = new SqlDataAdapter(pbQuery, connection);
                DataTable pbTable = new DataTable();
                pbAdapter.Fill(pbTable);
                cb_PhongBan.DataSource = pbTable;
                cb_PhongBan.DisplayMember = "TenPB";
                cb_PhongBan.ValueMember = "MaPB";

                string cvQuery = "SELECT MaCV, TenCV FROM ChucVu";
                SqlDataAdapter cvAdapter = new SqlDataAdapter(cvQuery, connection);
                DataTable cvTable = new DataTable();
                cvAdapter.Fill(cvTable);
                cb_ChucVu.DataSource = cvTable;
                cb_ChucVu.DisplayMember = "TenCV";
                cb_ChucVu.ValueMember = "MaCV";

                string loaiNVQuery = "SELECT MaLoai, TenLoai FROM MaLoaiNV";
                SqlDataAdapter loaiNVAdapter = new SqlDataAdapter(loaiNVQuery, connection);
                DataTable loaiNVTable = new DataTable();
                loaiNVAdapter.Fill(loaiNVTable);
                cb_LoaiNV.DataSource = loaiNVTable;
                cb_LoaiNV.DisplayMember = "TenLoai";
                cb_LoaiNV.ValueMember = "MaLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DSNhanVienPhongBan_Load(object sender, EventArgs e)
        {
            dgv_DSNVPB.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv_DSNVPB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DisableTextBox();
            LoadData();
            LoadComboBoxes();
            HideColumns();
            CustomizeColumnHeaders();
            CustomizeColumnHeadersStyle();
            SetColumnWidths();
        }

        private void dgv_DSNVPB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                e.CellStyle.Padding = new Padding(5, 0, 5, 0);
            }
        }

        private void dgv_DSNVPB_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DSNVPB.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_DSNVPB.SelectedRows[0];

                txt_MaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                txt_HoTen.Text = selectedRow.Cells["HoTenNV"].Value.ToString();

                cb_PhongBan.SelectedValue = selectedRow.Cells["MaPB"].Value;
                cb_ChucVu.SelectedValue = selectedRow.Cells["MaCV"].Value;
                cb_LoaiNV.SelectedValue = selectedRow.Cells["MaLoai"].Value;
            }
        }

        private void cgv_DSNVPB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn clickedColumn = dgv_DSNVPB.Columns[e.ColumnIndex];

                if (clickedColumn.Name == "MaNV")
                {
                    DataGridViewRow selectedRow = dgv_DSNVPB.Rows[e.RowIndex];

                    txt_MaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                    txt_HoTen.Text = selectedRow.Cells["HoTenNV"].Value.ToString();

                    cb_PhongBan.SelectedValue = selectedRow.Cells["MaPB"].Value;
                    cb_ChucVu.SelectedValue = selectedRow.Cells["MaCV"].Value;
                    cb_LoaiNV.SelectedValue = selectedRow.Cells["MaLoai"].Value;

                    string tenPB = selectedRow.Cells["TenPB"].Value.ToString();
                    string tenCV = selectedRow.Cells["TenCV"].Value.ToString();

                    if (cb_PhongBan.Items.Contains(tenPB))
                    {
                        cb_PhongBan.SelectedItem = tenPB;
                    }

                    if (cb_ChucVu.Items.Contains(tenCV))
                    {
                        cb_ChucVu.SelectedItem = tenCV;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dgv_DSNVPB.CellClick -= cgv_DSNVPB_CellClick;
            dgv_DSNVPB.SelectionChanged -= dgv_DSNVPB_SelectionChanged;
            btnUpdate.Enabled = false;
            EnableTextBox();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy thao tác?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DisableTextBox();
                btnUpdate.Enabled = true;
                dgv_DSNVPB.CellClick += cgv_DSNVPB_CellClick;
                dgv_DSNVPB.SelectionChanged += dgv_DSNVPB_SelectionChanged;
            }
            else
            {
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_MaNV.Text))
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"
                                UPDATE NhanVien
                                SET MaPB = @MaPB, MaCV = @MaCV
                                WHERE MaNV = @MaNV";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNV", txt_MaNV.Text);
                    cmd.Parameters.AddWithValue("@MaPB", cb_PhongBan.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaCV", cb_ChucVu.SelectedValue);

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        DisableTextBox();
                        btnUpdate.Enabled = true;
                        dgv_DSNVPB.CellClick += cgv_DSNVPB_CellClick;
                        dgv_DSNVPB.SelectionChanged += dgv_DSNVPB_SelectionChanged;
                    }
                    else
                    {
                        DisableTextBox();
                        btnUpdate.Enabled = true;
                        dgv_DSNVPB.CellClick += cgv_DSNVPB_CellClick;
                        dgv_DSNVPB.SelectionChanged += dgv_DSNVPB_SelectionChanged;
                        MessageBox.Show("Không tìm thấy nhân viên để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisableTextBox();
                btnUpdate.Enabled = true;
                dgv_DSNVPB.CellClick += cgv_DSNVPB_CellClick;
                dgv_DSNVPB.SelectionChanged += dgv_DSNVPB_SelectionChanged;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                (dgv_DSNVPB.DataSource as DataTable).DefaultView.RowFilter = string.Format("MaNV LIKE '%{0}%'", searchValue);
            }
            else
            {
                (dgv_DSNVPB.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchValue))
            {
                bool found = false;

                foreach (DataGridViewRow row in dgv_DSNVPB.Rows)
                {
                    if (row.Cells["MaNV"].Value != null &&
                        row.Cells["MaNV"].Value.ToString().Trim() == searchValue)
                    {
                        row.Selected = true;
                        dgv_DSNVPB.CurrentCell = row.Cells[0];
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
        private void EnableTextBox()
        {
            cb_ChucVu.Enabled = true;
            cb_PhongBan.Enabled = true;
        }
        private void DisableTextBox()
        {
            txt_HoTen.Enabled = false;
            cb_LoaiNV.Enabled = false;
            cb_ChucVu.Enabled = false;
            cb_PhongBan.Enabled = false;
        }

        private void CustomizeColumnHeaders()
        {
            if (dgv_DSNVPB.Columns.Contains("MaNV"))
                dgv_DSNVPB.Columns["MaNV"].HeaderText = "Mã nhân viên";

            if (dgv_DSNVPB.Columns.Contains("MaPB"))
                dgv_DSNVPB.Columns["MaPB"].HeaderText = "Mã phòng ban";

            if (dgv_DSNVPB.Columns.Contains("HoTenNV"))
                dgv_DSNVPB.Columns["HoTenNV"].HeaderText = "Họ tên nhân viên";

            if (dgv_DSNVPB.Columns.Contains("TenLoai"))
                dgv_DSNVPB.Columns["TenLoai"].HeaderText = "Loại nhân viên";

            if (dgv_DSNVPB.Columns.Contains("TenPB"))
                dgv_DSNVPB.Columns["TenPB"].HeaderText = "Phòng ban";

            if (dgv_DSNVPB.Columns.Contains("TenCV"))
                dgv_DSNVPB.Columns["TenCV"].HeaderText = "Chức vụ";
        }

        private void SetColumnWidths()
        {
            dgv_DSNVPB.Columns["MaNV"].Width = 150;
            dgv_DSNVPB.Columns["MaPB"].Width = 150;
            dgv_DSNVPB.Columns["HoTenNV"].Width = 250;
        }

        private void CustomizeColumnHeadersStyle()
        {
            dgv_DSNVPB.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv_DSNVPB.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void HideColumns()
        {
            if (dgv_DSNVPB.Columns.Contains("MaLoai"))
            {
                dgv_DSNVPB.Columns["MaLoai"].Visible = false;
            }
            if (dgv_DSNVPB.Columns.Contains("MaCV"))
            {
                dgv_DSNVPB.Columns["MaCV"].Visible = false;
            }
        }
    }
}
