using QLNS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS.NhanSu.ChildForm
{
    public partial class formHopDongNhanVien : Form
    {
        SqlConnection connection;
        public formHopDongNhanVien()
        {
            InitializeComponent();
            connection = new SqlConnection(KetNoi.kn);
            txt_MaNV.Enabled = false;
            txt_MaHD.Enabled = false;
        }

        private void formHopDongNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            CustomizeColumnHeadersStyle();
            dgv_HDNV.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv_HDNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CustomizeColumnHeaders();
            SetColumnWidths();
            DisableTextBox();
            btnCapNhat.Visible = false;
            btnHuy.Visible = false;
        }

        private void LoadData()
        {
            try
            {
                string query = @"
                            SELECT 
                                NV.MaNV,
                                HD.MaHD,
                                NV.HoTenNV,  
                                HD.ThoiHanHopDong, 
                                HD.NgayBatDau, 
                                HD.NgayKetThuc, 
                                HD.MucLuong
                            FROM 
                                NhanVien NV
                            INNER JOIN 
                                HopDongNhanVien HD ON NV.MaNV = HD.MaNV";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                System.Data.DataTable dataTable = new System.Data.DataTable();

                dataAdapter.Fill(dataTable);

                dgv_HDNV.DataSource = dataTable;

                if (dgv_HDNV.Rows.Count > 0)
                {
                    dgv_HDNV.Rows[0].Selected = true;
                    dgv_HDNV.CurrentCell = dgv_HDNV.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_HDNV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                e.CellStyle.Padding = new Padding(5, 0, 5, 0);
            }
        }

        private void dgv_HDNV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_HDNV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_HDNV.SelectedRows[0];

                txt_MaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                txt_MaHD.Text = selectedRow.Cells["MaHD"].Value.ToString();
                txt_HoTen.Text = selectedRow.Cells["HoTenNV"].Value.ToString();
                txt_ThoiHanHD.Text = selectedRow.Cells["ThoiHanHopDong"].Value.ToString();

                DateTime ngayBatDau;
                if (DateTime.TryParse(selectedRow.Cells["NgayBatDau"].Value.ToString(), out ngayBatDau))
                {
                    txt_NgayBD.Text = ngayBatDau.ToString("dd/MM/yyyy");
                }
                else
                {
                    txt_NgayBD.Text = string.Empty;
                    MessageBox.Show("Ngày sinh không hợp lệ.");
                }

                DateTime ngayKetThuc;
                if (DateTime.TryParse(selectedRow.Cells["NgayKetThuc"].Value.ToString(), out ngayKetThuc))
                {
                    txt_NgayKT.Text = ngayKetThuc.ToString("dd/MM/yyyy");
                }
                else
                {
                    txt_NgayKT.Text = string.Empty;
                    MessageBox.Show("Ngày sinh không hợp lệ.");
                }

                txt_MucLuong.Text = selectedRow.Cells["MucLuong"].Value.ToString();
            }
        }

        private void dgv_HDNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn clickedColumn = dgv_HDNV.Columns[e.ColumnIndex];

                if (clickedColumn.Name == "MaNV")
                {
                    DataGridViewRow selectedRow = dgv_HDNV.Rows[e.RowIndex];

                    txt_MaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                    txt_MaHD.Text = selectedRow.Cells["MaHD"].Value.ToString();
                    txt_HoTen.Text = selectedRow.Cells["HoTenNV"].Value.ToString();
                    txt_ThoiHanHD.Text = selectedRow.Cells["ThoiHanHopDong"].Value.ToString();

                    DateTime ngayBatDau;
                    if (DateTime.TryParse(selectedRow.Cells["NgayBatDau"].Value.ToString(), out ngayBatDau))
                    {
                        txt_NgayBD.Text = ngayBatDau.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txt_NgayBD.Text = string.Empty;
                        MessageBox.Show("Ngày sinh không hợp lệ.");
                    }

                    DateTime ngayKetThuc;
                    if (DateTime.TryParse(selectedRow.Cells["NgayKetThuc"].Value.ToString(), out ngayKetThuc))
                    {
                        txt_NgayKT.Text = ngayKetThuc.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txt_NgayKT.Text = string.Empty;
                        MessageBox.Show("Ngày sinh không hợp lệ.");
                    }

                    txt_MucLuong.Text = selectedRow.Cells["MucLuong"].Value.ToString();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            EnableTextBox();
            btnSua.Enabled = false;
            btnCapNhat.Visible = true;
            btnHuy.Visible = true;
            btnHuyHD.Visible = false;
            btnThemHD.Visible = false;
            dgv_HDNV.CellClick -= dgv_HDNV_CellClick;
            dgv_HDNV.SelectionChanged -= dgv_HDNV_SelectionChanged;
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            string maHD = txt_MaHD.Text.Trim();

            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng nhập mã hợp đồng để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy hợp đồng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(KetNoi.kn))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM HopDongNhanVien WHERE MaHD = @MaHD", connection);
                    command.Parameters.AddWithValue("@MaHD", maHD);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Hợp đồng đã bị hủy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hợp đồng với mã này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void EnableTextBox()
        {
            txt_HoTen.Enabled = true;
            txt_ThoiHanHD.Enabled = true;
            txt_NgayBD.Enabled = true;
            txt_NgayKT.Enabled = true;
            txt_MucLuong.Enabled = true;
        }

        private void DisableTextBox()
        {
            txt_HoTen.Enabled = false;
            txt_ThoiHanHD.Enabled = false;
            txt_NgayBD.Enabled = false;
            txt_NgayKT.Enabled = false;
            txt_MucLuong.Enabled = false;
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
                btnHuyHD.Visible = true;
                btnThemHD.Visible = true;
                dgv_HDNV.CellClick += dgv_HDNV_CellClick;
                dgv_HDNV.SelectionChanged += dgv_HDNV_SelectionChanged;
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
                if (string.IsNullOrWhiteSpace(txt_MaNV.Text) || string.IsNullOrWhiteSpace(txt_MaHD.Text))
                {
                    MessageBox.Show("Mã nhân viên và Mã hợp đồng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"
                                UPDATE HopDongNhanVien
                                SET 
                                    ThoiHanHopDong = @ThoiHanHopDong,
                                    NgayBatDau = @NgayBatDau,
                                    NgayKetThuc = @NgayKetThuc,
                                    MucLuong = @MucLuong
                                WHERE MaHD = @MaHD;

                                UPDATE NhanVien
                                SET 
                                    HoTenNV = @HoTenNV
                                WHERE MaNV = @MaNV;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNV", txt_MaNV.Text);
                    cmd.Parameters.AddWithValue("@MaHD", txt_MaHD.Text);
                    cmd.Parameters.AddWithValue("@HoTenNV", txt_HoTen.Text);
                    cmd.Parameters.AddWithValue("@ThoiHanHopDong", txt_ThoiHanHD.Text);

                    DateTime ngayBatDau;
                    if (DateTime.TryParse(txt_NgayBD.Text, out ngayBatDau))
                        cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                    else
                        cmd.Parameters.AddWithValue("@NgayBatDau", DBNull.Value);

                    DateTime ngayKetThuc;
                    if (DateTime.TryParse(txt_NgayKT.Text, out ngayKetThuc))
                        cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                    else
                        cmd.Parameters.AddWithValue("@NgayKetThuc", DBNull.Value);

                    decimal mucLuong;
                    if (decimal.TryParse(txt_MucLuong.Text, out mucLuong))
                        cmd.Parameters.AddWithValue("@MucLuong", mucLuong);
                    else
                        cmd.Parameters.AddWithValue("@MucLuong", 0);

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisableTextBox();
                        LoadData();
                        btnSua.Enabled = true;
                        btnCapNhat.Visible = false;
                        btnHuy.Visible = false;
                        btnHuyHD.Visible = true;
                        btnThemHD.Visible = true;
                        dgv_HDNV.CellClick += dgv_HDNV_CellClick;
                        dgv_HDNV.SelectionChanged += dgv_HDNV_SelectionChanged;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DisableTextBox();
                        btnSua.Enabled = true;
                        btnCapNhat.Visible = false;
                        btnHuy.Visible = false;
                        btnHuyHD.Visible = true;
                        btnThemHD.Visible = true;
                        dgv_HDNV.CellClick += dgv_HDNV_CellClick;
                        dgv_HDNV.SelectionChanged += dgv_HDNV_SelectionChanged;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisableTextBox();
                btnSua.Enabled = true;
                btnCapNhat.Visible = false;
                btnHuy.Visible = false;
                btnHuyHD.Visible = true;
                btnThemHD.Visible = true;
                dgv_HDNV.CellClick += dgv_HDNV_CellClick;
                dgv_HDNV.SelectionChanged += dgv_HDNV_SelectionChanged;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            ThemHopDong thd = new ThemHopDong();
            thd.StartPosition = FormStartPosition.CenterScreen;
            thd.ShowDialog();
        }
        private void CustomizeColumnHeadersStyle()
        {
            dgv_HDNV.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv_HDNV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void CustomizeColumnHeaders()
        {
            if (dgv_HDNV.Columns.Contains("MaNV"))
                dgv_HDNV.Columns["MaNV"].HeaderText = "Mã nhân viên";

            if (dgv_HDNV.Columns.Contains("HoTenNV"))
                dgv_HDNV.Columns["HoTenNV"].HeaderText = "Họ tên nhân viên";

            if (dgv_HDNV.Columns.Contains("MaHD"))
                dgv_HDNV.Columns["MaHD"].HeaderText = "Mã họp đồng";

            if (dgv_HDNV.Columns.Contains("ThoiHanHopDong"))
                dgv_HDNV.Columns["ThoiHanHopDong"].HeaderText = "Thời hạn họp đồng";

            if (dgv_HDNV.Columns.Contains("NgayBatDau"))
                dgv_HDNV.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";

            if (dgv_HDNV.Columns.Contains("NgayKetThuc"))
                dgv_HDNV.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";

            if (dgv_HDNV.Columns.Contains("MucLuong"))
                dgv_HDNV.Columns["MucLuong"].HeaderText = "Mức lương";
        }
        private void SetColumnWidths()
        {
            dgv_HDNV.Columns["MaNV"].Width = 150;
            dgv_HDNV.Columns["MaHD"].Width = 150;
            dgv_HDNV.Columns["HoTenNV"].Width = 250;
        }
    }
}
