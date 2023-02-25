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
    public partial class room : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds=new DataSet();
        string isfree;
            
        public room()
        {
          
            InitializeComponent();
        }

        private void room_Load(object sender, EventArgs e)
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
            // TODO: This line of code loads data into the 'db2DataSet3.room' table. You can move, or remove it, as needed.
            this.roomTableAdapter.Fill(this.db2DataSet6.room);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                isfree = "Free";
            }
            else
            {
                isfree = "Busy";
            }
            try
            {
                SqlCommand c = new SqlCommand("insert into room(RoomNumber,RoomPhone,RoomFree)values('" + bunifuMaterialTextbox1.Text + "','" + bunifuMaterialTextbox2.Text + "','" +isfree+ "')", con);
                c.ExecuteNonQuery();
                this.roomTableAdapter.Fill(this.db2DataSet6.room);
                
                MessageBox.Show("Added Sucessfully");
            }
            catch (Exception e2)
            {
                MessageBox.Show("Please enter valid values");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuMaterialTextbox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            bunifuMaterialTextbox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if(dataGridView1.CurrentRow.Cells[2].Value.ToString()=="Free")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked= false;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand c1 = new SqlCommand(" Delete from room where RoomNumber=" + Convert.ToInt32(bunifuMaterialTextbox1.Text), con);
                c1.ExecuteNonQuery();
                this.roomTableAdapter.Fill(this.db2DataSet6.room);
               
                MessageBox.Show("Deleted Sucessfully");
            }
             
            catch (Exception e3)
            {
                MessageBox.Show("Please enter valid room number");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                isfree = "Free";
            }
            else
            {
                isfree = "Busy";
            }
            try
            {
               
             
                SqlCommand com4 = new SqlCommand("UPDATE room Set RoomPhone='" + bunifuMaterialTextbox2.Text + "',RoomFree='" + isfree+ "'where RoomNumber='" + bunifuMaterialTextbox1.Text + "'", con);
                com4.ExecuteNonQuery();
                this.roomTableAdapter.Fill(this.db2DataSet6.room);
               
                MessageBox.Show("Updated Successfully");

            }
            catch (Exception e4)
            {
                MessageBox.Show("Please enter valid values");
            }

           
            //bunifuImageButton1_Click(sender,e);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                da = new SqlDataAdapter("Select *from room where RoomNumber='" + bunifuMaterialTextbox5.Text + "' ", con);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception e5)
            {
                MessageBox.Show("Please enter a valid room number");
            }

            try
            {

                SqlCommand dd = new SqlCommand("Select *from room where RoomNumber='" +Convert.ToInt32(bunifuMaterialTextbox5.Text) + "' ", con);
                SqlDataReader rr = dd.ExecuteReader();
                if (rr.Read())
                {
                    bunifuMaterialTextbox1.Text = rr.GetValue(0).ToString();
                    bunifuMaterialTextbox2.Text = rr.GetValue(1).ToString();
                 
                    if (rr.GetValue(2).ToString() == "Free")
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                        radioButton1.Checked = false;
                    }
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

                da = new SqlDataAdapter("Select *from room  where RoomNumber='" + bunifuMaterialTextbox5.Text + "' ", con);
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
