using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLy_Dien_nuoc_KTX
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLyPhong f = new QLyPhong();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLySV f = new QLySV();
            f.ShowDialog();
        }

        private void buttonCongtodien_Click(object sender, EventArgs e)
        {
            QLy_cong_to_dien f = new QLy_cong_to_dien();
            f.ShowDialog();
        }

        private void buttonCongtonuoc_Click(object sender, EventArgs e)
        {
            QLy_cong_to_nuoc f = new QLy_cong_to_nuoc();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hoa_don f = new Hoa_don();
            f.ShowDialog();
        }

        private void buttonHopdong_Click(object sender, EventArgs e)
        {
            Hop_dong f = new Hop_dong();
            f.ShowDialog();
        }
    }
}
