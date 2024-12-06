using QLNS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLNS.NhanSu.ChildForm
{
    public partial class formBaoHiemXaHoi : Form
    {

        SqlConnection connection;
        public formBaoHiemXaHoi()
        {
            InitializeComponent();
            connection = new SqlConnection(KetNoi.kn);
        }
        private void LoadData()
        {
            try
            {
                string query = @"
                                SELECT 
                                    NV.MaNV,
                                    BH.MaBHXH,
                                    BH.SoBHXH,
                                    NV.HoTenNV,
                                    BH.NgayBatDau,
                                    BH.NgayKetThuc,
                                    BH.TyLeDong,
                                    BH.SoTienDong
                                FROM 
                                    BaoHiemXaHoi BH
                                INNER JOIN 
                                    NhanVien NV ON BH.MaNV = NV.MaNV";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                System.Data.DataTable dataTable = new System.Data.DataTable();

                dataAdapter.Fill(dataTable);

                dGVBHXH.DataSource = dataTable;

                if (dGVBHXH.Rows.Count > 0)
                {
                    dGVBHXH.Rows[0].Selected = true;
                    dGVBHXH.CurrentCell = dGVBHXH.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formBaoHiemXaHoi_Load(object sender, EventArgs e)
        {
            LoadData(); 
            CustomizeColumnHeadersStyle();
            CustomizeColumnHeaders();
            SetColumnWidths();
            dGVBHXH.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dGVBHXH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dGVBHXH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                e.CellStyle.Padding = new Padding(5, 0, 5, 0);
            }
        }

        private void dGVBHXH_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVBHXH.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dGVBHXH.SelectedRows[0];

                txtMaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                txtMaDongBHXH.Text = selectedRow.Cells["MaBHXH"].Value.ToString();
                txtMaBHXH.Text = selectedRow.Cells["SoBHXH"].Value.ToString();
                txtHoTen.Text = selectedRow.Cells["HoTenNV"].Value.ToString();

                DateTime ngayBatDau;
                if (DateTime.TryParse(selectedRow.Cells["NgayBatDau"].Value.ToString(), out ngayBatDau))
                {
                    txtNgayBD.Text = ngayBatDau.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgayBD.Text = string.Empty;
                    MessageBox.Show("Ngày sinh không hợp lệ.");
                }

                DateTime ngayKetThuc;
                if (DateTime.TryParse(selectedRow.Cells["NgayKetThuc"].Value.ToString(), out ngayKetThuc))
                {
                    txtNgayKT.Text = ngayKetThuc.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgayKT.Text = string.Empty;
                    MessageBox.Show("Ngày sinh không hợp lệ.");
                }

                txtTiLeDong.Text = selectedRow.Cells["TyLeDong"].Value.ToString();
                txtSoTienDong.Text = selectedRow.Cells["SoTienDong"].Value.ToString();
            }
        }

        private void dGVBHXH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn clickedColumn = dGVBHXH.Columns[e.ColumnIndex];

                if (clickedColumn.Name == "MaNV")
                {
                    DataGridViewRow selectedRow = dGVBHXH.Rows[e.RowIndex];

                    txtMaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                    txtMaDongBHXH.Text = selectedRow.Cells["MaBHXH"].Value.ToString();
                    txtMaBHXH.Text = selectedRow.Cells["SoBHXH"].Value.ToString();
                    txtHoTen.Text = selectedRow.Cells["HoTenNV"].Value.ToString();

                    DateTime ngayBatDau;
                    if (DateTime.TryParse(selectedRow.Cells["NgayBatDau"].Value.ToString(), out ngayBatDau))
                    {
                        txtNgayBD.Text = ngayBatDau.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtNgayBD.Text = string.Empty;
                        MessageBox.Show("Ngày sinh không hợp lệ.");
                    }

                    DateTime ngayKetThuc;
                    if (DateTime.TryParse(selectedRow.Cells["NgayKetThuc"].Value.ToString(), out ngayKetThuc))
                    {
                        txtNgayKT.Text = ngayKetThuc.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtNgayKT.Text = string.Empty;
                        MessageBox.Show("Ngày sinh không hợp lệ.");
                    }

                    txtTiLeDong.Text = selectedRow.Cells["TyLeDong"].Value.ToString();
                    txtSoTienDong.Text = selectedRow.Cells["SoTienDong"].Value.ToString();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchValue))
            {
                bool found = false;

                foreach (DataGridViewRow row in dGVBHXH.Rows)
                {
                    if (row.Cells["MaNV"].Value != null &&
                        row.Cells["MaNV"].Value.ToString().Trim() == searchValue)
                    {
                        row.Selected = true;
                        dGVBHXH.CurrentCell = row.Cells[0];
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                (dGVBHXH.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("MaNV LIKE '%{0}%'", searchValue);
            }
            else
            {
                (dGVBHXH.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Empty;
            }
        }
        private void CustomizeColumnHeadersStyle()
        {
            dGVBHXH.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dGVBHXH.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void CustomizeColumnHeaders()
        {
            if (dGVBHXH.Columns.Contains("MaNV"))
                dGVBHXH.Columns["MaNV"].HeaderText = "Mã nhân viên";

            if (dGVBHXH.Columns.Contains("HoTenNV"))
                dGVBHXH.Columns["HoTenNV"].HeaderText = "Họ tên nhân viên";

            if (dGVBHXH.Columns.Contains("MaBHXH"))
                dGVBHXH.Columns["MaBHXH"].HeaderText = "Mã đóng BHXH";

            if (dGVBHXH.Columns.Contains("SoBHXH"))
                dGVBHXH.Columns["SoBHXH"].HeaderText = "Mã BHXH";

            if (dGVBHXH.Columns.Contains("NgayBatDau"))
                dGVBHXH.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";

            if (dGVBHXH.Columns.Contains("NgayKetThuc"))
                dGVBHXH.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";

            if (dGVBHXH.Columns.Contains("TyLeDong"))
                dGVBHXH.Columns["TyLeDong"].HeaderText = "Tỷ lệ đóng";

            if (dGVBHXH.Columns.Contains("SoTienDong"))
                dGVBHXH.Columns["SoTienDong"].HeaderText = "Số tiền đóng";
        }

        private void SetColumnWidths()
        {
            dGVBHXH.Columns["MaNV"].Width = 150;
            dGVBHXH.Columns["MaBHXH"].Width = 150;
            dGVBHXH.Columns["SoBHXH"].Width = 250;
            dGVBHXH.Columns["HoTenNV"].Width = 350;
        }
    }
}
