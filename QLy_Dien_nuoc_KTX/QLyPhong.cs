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
    public partial class QLyPhong : Form
    {
        string chuoiketnoi = @"Data Source=DESKTOP-HE3OLV6\MSSQLSERVER01;Initial Catalog=QLydiennuoc;Integrated Security=True;Encrypt=False";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        public QLyPhong()
        {
            InitializeComponent();
        }

        private void QLyPhong_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            lvQLyPhong.Items.Clear();
            ketnoi.Open();
            sql = @"SELECT * FROM Phong";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvQLyPhong.Items.Add(docdulieu[0].ToString());
                lvQLyPhong.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvQLyPhong.Items[i].SubItems.Add(docdulieu[2].ToString());
                lvQLyPhong.Items[i].SubItems.Add(docdulieu[3].ToString());
                lvQLyPhong.Items[i].SubItems.Add(docdulieu[4].ToString());
                lvQLyPhong.Items[i].SubItems.Add(docdulieu[5].ToString());
                i++;
            }
            ketnoi.Close();
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            buttonTimKiem.Enabled = false;
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lvQLyPhong.Items.Clear();
            ketnoi.Open();
            sql = "update Phong set  Tenphong=@Tenphong ,Loaiphong=@Loaiphong, Giatien=@Giatien, Macongtodien=@Macongtodien, Macongtonuoc=@Macongtonuoc  where Maphong=@Maphong";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.AddWithValue("Maphong", textMaphong.Text);
            thuchien.Parameters.AddWithValue("Tenphong", textTenphong.Text);
            thuchien.Parameters.AddWithValue("Loaiphong", textLoaiphong.Text);
            thuchien.Parameters.AddWithValue("Giatien", textGiatien.Text);
            thuchien.Parameters.AddWithValue("Macongtodien", textMacongtodien.Text);
            thuchien.Parameters.AddWithValue("Macongtonuoc", textMacongtonuoc.Text);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            textMaphong.Enabled = true;
            buttonThem.Enabled = true;
            hienthi();
            XoaThongTin();
        }
        private void XoaThongTin()
        {
            textMaphong.Text = "";
            textTenphong.Text = "";
            textLoaiphong.Text = "";
            textGiatien.Text = "";
            textMacongtodien.Text = "";
            textMacongtonuoc.Text = "";
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            lvQLyPhong.Items.Clear();
            ketnoi.Open();
            sql = "insert into Phong(Maphong, Tenphong, Loaiphong, Giatien, Macongtodien, Macongtonuoc) " +
                "values(@Maphong, @Tenphong, @Loaiphong, @Giatien, @Macongtodien, @Macongtonuoc)";

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.AddWithValue("Maphong", textMaphong.Text);
            thuchien.Parameters.AddWithValue("Tenphong", textTenphong.Text);
            thuchien.Parameters.AddWithValue("Loaiphong", textLoaiphong.Text);
            thuchien.Parameters.AddWithValue("Giatien", textGiatien.Text);
            thuchien.Parameters.AddWithValue("Macongtodien", textMacongtodien.Text);
            thuchien.Parameters.AddWithValue("Macongtonuoc", textMacongtonuoc.Text);

            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
            XoaThongTin();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có muốn xóa hay không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (d == DialogResult.Yes)
            {
                lvQLyPhong.Items.Clear();
                ketnoi.Open();
                sql = "delete from Phong where Maphong= @Maphong";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.Parameters.AddWithValue("Maphong", textMaphong.Text);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                textMaphong.Enabled = true;
                buttonThem.Enabled = true;
                hienthi();
            }
            XoaThongTin();
        }

        private void lvQLyPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textMaphong.Text = lvQLyPhong.SelectedItems[0].SubItems[0].Text;
                textTenphong.Text = lvQLyPhong.SelectedItems[0].SubItems[1].Text;
                textLoaiphong.Text = lvQLyPhong.SelectedItems[0].SubItems[2].Text;
                textGiatien.Text = lvQLyPhong.SelectedItems[0].SubItems[3].Text;
                textMacongtodien.Text = lvQLyPhong.SelectedItems[0].SubItems[4].Text;
                textMacongtonuoc.Text = lvQLyPhong.SelectedItems[0].SubItems[5].Text;
                buttonSua.Enabled = true;
                buttonXoa.Enabled = true;
                textMaphong.Enabled = false;
            }
            catch
            {

            }
        }
    }
}
