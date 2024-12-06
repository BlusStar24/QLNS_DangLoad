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
using QLNS.Helper;

namespace QLNS.Login
{
    public partial class formDangNhap : Form
    {

        SqlConnection connection;
        public formDangNhap()
        {
            InitializeComponent();
            connection = new SqlConnection(KetNoi.kn);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void formDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát ứng dụng không?",
                    "Xác nhận thoát",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string query = "SELECT UserID, Username, Pass, UserRole FROM TaiKhoan WHERE Username = @Username";
            string username = txtUsername.Text.Trim();
            string password = txtPass.Text.Trim();

            using (SqlConnection conn = new SqlConnection(KetNoi.kn))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        string dbUsername = reader["Username"].ToString().Trim();
                        string dbPassword = reader["Pass"].ToString().Trim();
                        string userRole = reader["UserRole"].ToString().Trim();

                        if (username.Equals(dbUsername, StringComparison.OrdinalIgnoreCase) && password == dbPassword)
                        {

                            SessionManager.UserID = reader["UserID"].ToString().Trim();
                            SessionManager.Username = dbUsername;
                            SessionManager.UserRole = userRole;

                            if (userRole == "NhanVien")
                            {
                                this.Hide();
                                NhanVien nvForm = new NhanVien();
                                nvForm.Show();
                            }
                            else if (userRole == "Admin")
                            {
                                this.Hide();
                                formQLNS adminForm = new formQLNS();
                                adminForm.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username hoặc Password không đúng.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username không tồn tại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


    }

}
