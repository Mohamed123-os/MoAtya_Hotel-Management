using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            staff m1 = new staff();
            m1.Show();
            this.Hide();
        }


        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            room m3 = new room();
            m3.Show();
            this.Hide();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            reservation m4 = new reservation();
            m4.Show();
            this.Hide();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Form1 m = new Form1();
            m.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Client aa = new Client();
            aa.Show();
            this.Hide();

        }
    }
}
