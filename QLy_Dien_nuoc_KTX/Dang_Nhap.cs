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

namespace QLy_Dien_nuoc_KTX
{
    public partial class Dang_Nhap : Form
    {

        string chuoiketnoi = @"Data Source=DESKTOP-HE3OLV6\MSSQLSERVER01;Initial Catalog=QLydiennuoc; Integrated Security = True; Encrypt=False";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        public Dang_Nhap()
        {
            InitializeComponent();
            ketnoi = new SqlConnection(chuoiketnoi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                ketnoi.Open();
                sql = "select * from Dang_nhap where username=@user and password=@pass";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.Parameters.AddWithValue("user", txtTK.Text);
                thuchien.Parameters.AddWithValue("pass", txtMK.Text);
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(thuchien);
                adapter.Fill(data);
                ketnoi.Close();
                if (data.Rows.Count > 0)
                {
                    fMain f = new fMain();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Thông báo");
                }
            }
        }
    }
}
