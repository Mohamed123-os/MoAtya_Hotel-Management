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
    public partial class Client : Form
    {
        SqlConnection con;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds;


        public Client()
        {
            InitializeComponent();

        }

        private void Client_Load(object sender, EventArgs e)
        {

            label2.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-LENJT7Q;Initial Catalog=db2;Integrated Security=True");
                con.Open();
               
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            // TODO: This line of code loads data into the 'db2DataSet.client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.db2DataSet.client);
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                SqlCommand c = new SqlCommand("insert into client(ClientID,ClientName,ClientPhone,ClientCountry)values('" + bunifuMaterialTextbox1.Text + "','" + bunifuMaterialTextbox2.Text + "','" + bunifuMaterialTextbox3.Text + "','" + comboBox1.Text + "')", con);
                c.ExecuteNonQuery();

                this.clientTableAdapter.Fill(this.db2DataSet.client);
               
                MessageBox.Show("Added successfully");
            }
            catch (Exception e2)
            {
                MessageBox.Show("Please enter valid values");
            }
        
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlCommand c1 = new SqlCommand(" Delete from client where ClientID=" + Convert.ToInt32(bunifuMaterialTextbox1.Text), con);
                c1.ExecuteNonQuery();
                this.clientTableAdapter.Fill(this.db2DataSet.client);
               
                MessageBox.Show("Deleted Sucessfully");

            }
            catch (Exception e3)
            {
                MessageBox.Show("please enter a valid ID");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand com4 = new SqlCommand("UPDATE client Set ClientName='" + bunifuMaterialTextbox2.Text + "',ClientPhone='" + bunifuMaterialTextbox3.Text + "',ClientCountry='" + comboBox1.SelectedItem.ToString() + "'where ClientID='"+bunifuMaterialTextbox1.Text+"'", con);
                com4.ExecuteNonQuery();
                this.clientTableAdapter.Fill(this.db2DataSet.client);
               
                MessageBox.Show(" Updated Successfully");
            }
            catch (Exception e4)
            {
                MessageBox.Show(" Please enter valid values");
            }          
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuMaterialTextbox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            bunifuMaterialTextbox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            bunifuMaterialTextbox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                da = new SqlDataAdapter("Select *from client where ClientName='" + bunifuMaterialTextbox4.Text + "' ", con);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception e5)
            {
                MessageBox.Show("Please enter a v alid name");
            }

            try { 

            SqlCommand  dd  = new SqlCommand("Select *from client where ClientName='" + bunifuMaterialTextbox4.Text + "' ", con);
                SqlDataReader rr = dd.ExecuteReader();
                if (rr.Read())
                {
                    bunifuMaterialTextbox1.Text= rr.GetValue(0).ToString();
                    bunifuMaterialTextbox2.Text = rr.GetValue(1).ToString();
                    bunifuMaterialTextbox3.Text = rr.GetValue(2).ToString();
                    comboBox1.Text = rr.GetValue(3).ToString();
                }
                 rr.Close();
            }
            catch (Exception e6)
            {
                MessageBox.Show(e6.Message);
            }     
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
            try
            {

                da = new SqlDataAdapter("Select *from client where ClientName ='" + bunifuMaterialTextbox4.Text + "' ", con);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception e5)
            {
                MessageBox.Show(e5.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 m = new Form2();
            m.Show();
            this.Close();
        }
    }
}         
