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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QLy_Dien_nuoc_KTX
{
    public partial class QLy_cong_to_dien : Form
    {
        string chuoiketnoi = @"Data Source=DESKTOP-HE3OLV6\MSSQLSERVER01;Initial Catalog=QLydiennuoc;Integrated Security=True;Encrypt=False";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        public QLy_cong_to_dien()
        {
            InitializeComponent();
        }

        private void QLy_cong_to_dien_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            lvQLy_cong_to_dien.Items.Clear();
            ketnoi.Open();
            sql = @"SELECT * FROM Cong_to_dien";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvQLy_cong_to_dien.Items.Add(docdulieu[0].ToString());
                lvQLy_cong_to_dien.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvQLy_cong_to_dien.Items[i].SubItems.Add(docdulieu[2].ToString());
                lvQLy_cong_to_dien.Items[i].SubItems.Add(docdulieu[3].ToString());
                i++;
            }
            ketnoi.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lvQLy_cong_to_dien.Items.Clear();
            ketnoi.Open();
            sql = "update Cong_to_dien set Sodien=@Sodien, Dongia=@Dongia, Ngaytinh=@Ngaytinh where Macongtodien=@Macongtodien";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.AddWithValue("Sodien", textSodien.Text);
            thuchien.Parameters.AddWithValue("Dongia", textDongia.Text);
            thuchien.Parameters.AddWithValue("Ngaytinh", textNgaytinh.Text);
            thuchien.Parameters.AddWithValue("Macongtodien", textMacongtodien.Text);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            textMacongtodien.Enabled = true;
            hienthi();
            XoaThongTin();
        }
        private void XoaThongTin()
        {
            textMacongtodien.Text = "";
            textSodien.Text = "";
            textDongia.Text = "";
            textNgaytinh.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có muốn xóa hay không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (d == DialogResult.Yes)
            {
                lvQLy_cong_to_dien.Items.Clear();
                ketnoi.Open();
                sql = "delete from Cong_to_dien where Macongtodien= @Macongtodien";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.Parameters.AddWithValue("Macongtodien", textMacongtodien.Text);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                textMacongtodien.Enabled = true;
                btnUpdate.Enabled = true;
                hienthi();
            }
            XoaThongTin();
        }

        private void lvQLy_cong_to_dien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textMacongtodien.Text = lvQLy_cong_to_dien.SelectedItems[0].SubItems[0].Text;
                textSodien.Text = lvQLy_cong_to_dien.SelectedItems[0].SubItems[1].Text;
                textDongia.Text = lvQLy_cong_to_dien.SelectedItems[0].SubItems[2].Text;
                textNgaytinh.Text = lvQLy_cong_to_dien.SelectedItems[0].SubItems[3].Text;
                btnXoa.Enabled = true;
                textMacongtodien.Enabled = false;
            }
            catch
            {

            }
        }
    }
}
