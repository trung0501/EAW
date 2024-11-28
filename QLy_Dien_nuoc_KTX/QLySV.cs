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
    public partial class QLySV : Form
    {
        string chuoiketnoi = @"Data Source=DESKTOP-HE3OLV6\MSSQLSERVER01;Initial Catalog=QLydiennuoc;Integrated Security=True;Encrypt=False";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        public QLySV()
        {
            InitializeComponent();
        }
        private void QLySV_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            lvQLSV.Items.Clear();
            ketnoi.Open();
            sql = @"SELECT * FROM Sinhvien";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvQLSV.Items.Add(docdulieu[0].ToString());
                lvQLSV.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvQLSV.Items[i].SubItems.Add(docdulieu[2].ToString());
                lvQLSV.Items[i].SubItems.Add(docdulieu[3].ToString());
                lvQLSV.Items[i].SubItems.Add(docdulieu[4].ToString());
                lvQLSV.Items[i].SubItems.Add(docdulieu[5].ToString());
                lvQLSV.Items[i].SubItems.Add(docdulieu[6].ToString());
                lvQLSV.Items[i].SubItems.Add(docdulieu[7].ToString());
                i++;
            }
            ketnoi.Close();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTimKiem.Enabled = false;
        }
        private void XoaThongTin()
        {
            textMaSV.Text = "";
            textMalop.Text = "";
            textHoten.Text = "";
            textEmail.Text = "";
            textSDT.Text = "";
            textQuequan.Text = "";
            textCCCD.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            lvQLSV.Items.Clear();
            ketnoi.Open();
            sql = "insert into Sinhvien(MaSV, Malop, Hoten, Ngaysinh, Email, SDT, Quequan, CCCD) " +
                "values(@MaSV, @Malop, @Hoten, @Ngaysinh, @Email, @SDT, @Quequan, @CCCD)";

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.AddWithValue("MaSV", textMaSV.Text);
            thuchien.Parameters.AddWithValue("Malop", textMalop.Text);
            thuchien.Parameters.AddWithValue("Hoten", textHoten.Text);
            thuchien.Parameters.AddWithValue("Ngaysinh", textNgaysinh.Text);
            thuchien.Parameters.AddWithValue("SDT", textSDT.Text);
            thuchien.Parameters.AddWithValue("Email", textEmail.Text);
            thuchien.Parameters.AddWithValue("Quequan", textQuequan.Text);
            thuchien.Parameters.AddWithValue("CCCD", textCCCD.Text);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
            XoaThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có muốn xóa hay không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (d == DialogResult.Yes)
            {
                lvQLSV.Items.Clear();
                ketnoi.Open();
                sql = "delete from Sinhvien where MaSV= @MaSV";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.Parameters.AddWithValue("MaSV", textMaSV.Text);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                textMaSV.Enabled = true;
                btnThem.Enabled = true;
                hienthi();
            }
            XoaThongTin();
        }

        private void lvQLSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textMaSV.Text = lvQLSV.SelectedItems[0].SubItems[0].Text;
                textNgaysinh.Text = lvQLSV.SelectedItems[0].SubItems[1].Text;
                textHoten.Text = lvQLSV.SelectedItems[0].SubItems[2].Text;
                textSDT.Text = lvQLSV.SelectedItems[0].SubItems[3].Text;
                textMalop.Text = lvQLSV.SelectedItems[0].SubItems[4].Text;
                textQuequan.Text = lvQLSV.SelectedItems[0].SubItems[5].Text;
                textCCCD.Text = lvQLSV.SelectedItems[0].SubItems[6].Text;
                textEmail.Text = lvQLSV.SelectedItems[0].SubItems[7].Text;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                textMaSV.Enabled = false;
            }
            catch
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            lvQLSV.Items.Clear();
            ketnoi.Open();
            sql = "update Sinhvien set Ngaysinh=@Ngaysinh, Hoten=@Hoten ,SDT=@SDT, Malop=@Malop, Quequan=@Quequan, CCCD=@CCCD, Email=@Email,  where MaSV=@MaSV";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.AddWithValue("MaSV", textMaSV.Text);
            thuchien.Parameters.AddWithValue("Ngaysinh", textNgaysinh.Text);
            thuchien.Parameters.AddWithValue("Hoten", textHoten.Text);
            thuchien.Parameters.AddWithValue("SDT", textSDT.Text);
            thuchien.Parameters.AddWithValue("Malop", textMalop.Text);
            thuchien.Parameters.AddWithValue("Quequan", textQuequan.Text);
            thuchien.Parameters.AddWithValue("CCCD", textCCCD.Text);
            thuchien.Parameters.AddWithValue("Email", textEmail.Text);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            textMaSV.Enabled = true;
            btnThem.Enabled = true;
            hienthi();
            XoaThongTin();
        }
    }
}
