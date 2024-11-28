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
    public partial class QLy_cong_to_nuoc : Form
    {
        string chuoiketnoi = @"Data Source=DESKTOP-HE3OLV6\MSSQLSERVER01;Initial Catalog=QLydiennuoc;Integrated Security=True;Encrypt=False";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        public QLy_cong_to_nuoc()
        {
            InitializeComponent();
        }

        public void hienthi()
        {
            lvQLy_Cong_to_nuoc.Items.Clear();
            ketnoi.Open();
            sql = @"SELECT * FROM Cong_to_nuoc";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvQLy_Cong_to_nuoc.Items.Add(docdulieu[0].ToString());
                lvQLy_Cong_to_nuoc.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvQLy_Cong_to_nuoc.Items[i].SubItems.Add(docdulieu[2].ToString());
                lvQLy_Cong_to_nuoc.Items[i].SubItems.Add(docdulieu[3].ToString());
                i++;
            }
            ketnoi.Close();
        }
        private void QLy_cong_to_nuoc_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        private void XoaThongTin()
        {
            textMacongtonuoc.Text = "";
            textSokhoi.Text = "";
            textDongia.Text = "";
            textNgaytinh.Text = "";
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            lvQLy_Cong_to_nuoc.Items.Clear();
            ketnoi.Open();
            sql = "update Cong_to_nuoc set Sokhoi=@Sokhoi, Dongia=@Dongia, Ngaytinh=@Ngaytinh where Macongtonuoc=@Macongtonuoc";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.AddWithValue("Sokhoi", textSokhoi.Text);
            thuchien.Parameters.AddWithValue("Dongia", textDongia.Text);
            thuchien.Parameters.AddWithValue("Ngaytinh", textNgaytinh.Text);
            thuchien.Parameters.AddWithValue("Macongtonuoc", textMacongtonuoc.Text);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            textMacongtonuoc.Enabled = true;
            hienthi();
            XoaThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có muốn xóa hay không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (d == DialogResult.Yes)
            {
                lvQLy_Cong_to_nuoc.Items.Clear();
                ketnoi.Open();
                sql = "delete from Cong_to_nuoc where Macongtonuoc= @Macongtonuoc";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.Parameters.AddWithValue("Macongtonuoc", textMacongtonuoc.Text);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                textMacongtonuoc.Enabled = true;
                btnCapNhat.Enabled = true;
                hienthi();
            }
            XoaThongTin();
        }

        private void lvQLy_Cong_to_nuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textMacongtonuoc.Text = lvQLy_Cong_to_nuoc.SelectedItems[0].SubItems[0].Text;
                textDongia.Text = lvQLy_Cong_to_nuoc.SelectedItems[0].SubItems[1].Text;
                textSokhoi.Text = lvQLy_Cong_to_nuoc.SelectedItems[0].SubItems[2].Text;
                textNgaytinh.Text = lvQLy_Cong_to_nuoc.SelectedItems[0].SubItems[3].Text;
                btnXoa.Enabled = true;
                textMacongtonuoc.Enabled = false;
            }
            catch
            {

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
