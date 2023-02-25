using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace The_Project
{
    public partial class Form1 : Form
    {

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-LENJT7Q;Initial Catalog=db2;Integrated Security=True");
                con.Open();
               // MessageBox.Show("connectionn opend");  
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            try
            {
                SqlCommand c = new SqlCommand($"select *from Staff where Staff_Name='{bunifuMaterialTextbox1.Text}'and Staff_Password='{bunifuMaterialTextbox2.Text}'", con);
                   
                SqlDataReader dr = c.ExecuteReader();
                if (dr.Read())
                {
                    Form2 m = new Form2();
                    m.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid UserName Or Password");
                }  
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }
    }
}
