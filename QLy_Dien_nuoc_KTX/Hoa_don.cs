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
    public partial class Hoa_don : Form
    {
        string chuoiketnoi = @"Data Source=DESKTOP-HE3OLV6\MSSQLSERVER01;Initial Catalog=QLydiennuoc;Integrated Security=True;Encrypt=False";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        public Hoa_don()
        {
            InitializeComponent();
        }

        private void Hoa_don_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            lvQLyHoaDon.Items.Clear();
            ketnoi.Open();
            sql = @"SELECT * FROM Hoa_don";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvQLyHoaDon.Items.Add(docdulieu[0].ToString());
                lvQLyHoaDon.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvQLyHoaDon.Items[i].SubItems.Add(docdulieu[2].ToString());
                lvQLyHoaDon.Items[i].SubItems.Add(docdulieu[3].ToString());
                lvQLyHoaDon.Items[i].SubItems.Add(docdulieu[4].ToString());
                lvQLyHoaDon.Items[i].SubItems.Add(docdulieu[5].ToString());
                lvQLyHoaDon.Items[i].SubItems.Add(docdulieu[6].ToString());
                lvQLyHoaDon.Items[i].SubItems.Add(docdulieu[7].ToString());
                lvQLyHoaDon.Items[i].SubItems.Add(docdulieu[8].ToString());
                i++;
            }
            ketnoi.Close();
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            buttonThanhtien.Enabled = false;
            buttonIn.Enabled = false;
        }
        private void XoaThongTin()
        {
            textMaSV.Text = "";
            textMahd.Text = "";
            textHoten.Text = "";
            textNgaylap.Text = "";
            textSodien.Text = "";
            textSokhoi.Text = "";
            textMaphong.Text = "";
            textCtd.Text = " ";
            textCtn.Text = " ";
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            lvQLyHoaDon.Items.Clear();
            ketnoi.Open();
            sql = "insert into Hoa_don(MaHD, NgayHD, Sodien, Sonuoc, Macongtodien, Macongtonuoc, Maphong, MaSV, Hoten) " +
                "values(@MaHD, @NgayHD, @Sodien, @Sonuoc, @Macongtodien, @Macongtonuoc, @Maphong, @MaSV, @Hoten)";

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.AddWithValue("MaHD", textMahd.Text);
            thuchien.Parameters.AddWithValue("NgayHD", textNgaylap.Text);
            thuchien.Parameters.AddWithValue("Sodien", textSodien.Text);
            thuchien.Parameters.AddWithValue("Sonuoc", textSokhoi.Text);
            thuchien.Parameters.AddWithValue("Macongtodien", textCtd.Text);
            thuchien.Parameters.AddWithValue("Macongtonuoc", textCtn.Text);
            thuchien.Parameters.AddWithValue("Maphong", textMaphong.Text);
            thuchien.Parameters.AddWithValue("MaSV", textMaSV.Text);
            thuchien.Parameters.AddWithValue("Hoten", textHoten.Text);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
            XoaThongTin();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lvQLyHoaDon.Items.Clear();
            ketnoi.Open();
            sql = "update Hoa_don set NgayHD=@NgayHD, Hoten=@Hoten ,Sodien=@Sodien, Maphong=@Maphong, Sonuoc=@Sonuoc, Macongtodien=@Macongtodien, Macongtonuoc=@Macongtonuoc, MaSV = @MaSV where MaHD=@MaHD";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.AddWithValue("MaHD", textMahd.Text);
            thuchien.Parameters.AddWithValue("NgayHD", textNgaylap.Text);
            thuchien.Parameters.AddWithValue("Sodien", textSodien.Text);
            thuchien.Parameters.AddWithValue("Sonuoc", textSokhoi.Text);
            thuchien.Parameters.AddWithValue("Macongtodien", textCtd.Text);
            thuchien.Parameters.AddWithValue("Macongtonuoc", textCtn.Text);
            thuchien.Parameters.AddWithValue("Maphong", textMaphong.Text);
            thuchien.Parameters.AddWithValue("MaSV", textMaSV.Text);
            thuchien.Parameters.AddWithValue("Hoten", textHoten.Text);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            textMaSV.Enabled = true;
            buttonThem.Enabled = true;
            hienthi();
            XoaThongTin();
        }

        private void lvQLyHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textMaSV.Text = lvQLyHoaDon.SelectedItems[0].SubItems[7].Text;
                textNgaylap.Text = lvQLyHoaDon.SelectedItems[0].SubItems[1].Text;
                textHoten.Text = lvQLyHoaDon.SelectedItems[0].SubItems[8].Text;
                textSodien.Text = lvQLyHoaDon.SelectedItems[0].SubItems[2].Text;
                textSokhoi.Text = lvQLyHoaDon.SelectedItems[0].SubItems[3].Text;
                textCtd.Text = lvQLyHoaDon.SelectedItems[0].SubItems[5].Text;
                textCtn.Text = lvQLyHoaDon.SelectedItems[0].SubItems[4].Text;
                textMahd.Text = lvQLyHoaDon.SelectedItems[0].SubItems[0].Text;
                textMaphong.Text = lvQLyHoaDon.SelectedItems[0].SubItems[6].Text;
                buttonSua.Enabled = true;
                buttonXoa.Enabled = true;
                textMahd.Enabled = false;
            }
            catch
            {

            }
        }
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có muốn xóa hay không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (d == DialogResult.Yes)
            {
                lvQLyHoaDon.Items.Clear();
                ketnoi.Open();
                sql = "delete from Hoa_don where MaHD= @MaHD";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.Parameters.AddWithValue("MaHD", textMahd.Text);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                textMahd.Enabled = true;
                buttonThem.Enabled = true;
                hienthi();
            }
            XoaThongTin();
        }

    }
   }
