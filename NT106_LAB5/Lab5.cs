using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_LAB5
{
    public partial class Lab5 : Form
    {
        public Lab5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bai1 frmBai1 = new Bai1();
            frmBai1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bai2 frmBai2 = new Bai2();
            frmBai2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bai3 frmBai3 = new Bai3();
            frmBai3.Show();
        }
    }
}
