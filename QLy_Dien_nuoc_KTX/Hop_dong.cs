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

    public partial class Hop_dong : Form
    {
        string chuoiketnoi = @"Data Source=DESKTOP-HE3OLV6\MSSQLSERVER01;Initial Catalog=QLydiennuoc;Integrated Security=True;Encrypt=False";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        public Hop_dong()
        {
            InitializeComponent();
        }
        public void hienthi()
        {
            lvHop_dong.Items.Clear();
            ketnoi.Open();
            sql = @"SELECT * FROM Hop_dong";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                lvHop_dong.Items.Add(docdulieu[0].ToString());
                lvHop_dong.Items[i].SubItems.Add(docdulieu[1].ToString());
                lvHop_dong.Items[i].SubItems.Add(docdulieu[2].ToString());
                lvHop_dong.Items[i].SubItems.Add(docdulieu[3].ToString());
                lvHop_dong.Items[i].SubItems.Add(docdulieu[4].ToString());
                lvHop_dong.Items[i].SubItems.Add(docdulieu[5].ToString());
                lvHop_dong.Items[i].SubItems.Add(docdulieu[6].ToString());
                i++;
            }
            ketnoi.Close();
            
        }
        private void Hop_dong_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }

        private void lvHop_dong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textMahopdong.Text = lvHop_dong.SelectedItems[0].SubItems[0].Text;
                textNgaykiHD.Text = lvHop_dong.SelectedItems[0].SubItems[1].Text;
                textMaphong.Text = lvHop_dong.SelectedItems[0].SubItems[2].Text;
                textMasinhvien.Text = lvHop_dong.SelectedItems[0].SubItems[3].Text;
                textHoten.Text = lvHop_dong.SelectedItems[0].SubItems[4].Text;
                textQuequan.Text = lvHop_dong.SelectedItems[0].SubItems[6].Text;
                textCCCD.Text = lvHop_dong.SelectedItems[0].SubItems[5].Text;
            }
            catch
            {

            }
        }
    }
}
