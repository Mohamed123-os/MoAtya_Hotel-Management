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
    public partial class staff : Form
    {
        SqlConnection con;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds;

        public staff()
        {
            InitializeComponent();
        }

        private void staff_Load(object sender, EventArgs e)
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
            // TODO: This line of code loads data into the 'db2DataSet2.staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.db2DataSet2.staff);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand c = new SqlCommand("insert into  staff(Staff_ID,Staff_Name,Staff_Phone,Staff_Gender,Staff_Password)values('" + bunifuMaterialTextbox1.Text + "','" + bunifuMaterialTextbox2.Text + "','" + bunifuMaterialTextbox3.Text + "','" + comboBox1.Text + "','"+ bunifuMaterialTextbox4.Text+"')", con);
                c.ExecuteNonQuery();
              
                this.staffTableAdapter.Fill(this.db2DataSet2.staff);
              
                MessageBox.Show("Added Successfully");
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
                SqlCommand c1 = new SqlCommand(" Delete from staff where Staff_ID=" + Convert.ToInt32(bunifuMaterialTextbox1.Text), con);
                c1.ExecuteNonQuery();
                this.staffTableAdapter.Fill(this.db2DataSet2.staff);
               
                MessageBox.Show("Deleted Successfully");
            }
            catch (Exception e3)
            {
                MessageBox.Show("Please enter valid ID");
            }
        }
    
        private void button2_Click(object sender, EventArgs e)
        {


            try
            {
                SqlCommand com4 = new SqlCommand("UPDATE staff Set Staff_Name='" + bunifuMaterialTextbox2.Text + "',Staff_Phone='" + bunifuMaterialTextbox3.Text + "',Staff_Gender='" + comboBox1.SelectedItem.ToString() + "',Staff_Password='" + bunifuMaterialTextbox4.Text + "'where Staff_ID='" + bunifuMaterialTextbox1.Text + "'", con);
                com4.ExecuteNonQuery();  
                this.staffTableAdapter.Fill(this.db2DataSet2.staff);
               
          
                MessageBox.Show("Updated Successfully");

            }
            catch (Exception e4)
            {
                MessageBox.Show("please enter valid valid values");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                da = new SqlDataAdapter("Select *from staff where Staff_Name='" + bunifuMaterialTextbox5.Text + "' ", con);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception e5)
            {
                MessageBox.Show("Please enter a valid name");
            }

            try
            {

                SqlCommand dd = new SqlCommand("Select *from staff where Staff_Name='" + bunifuMaterialTextbox5.Text + "' ", con);
                SqlDataReader rr = dd.ExecuteReader();
                if (rr.Read())
                {
                    bunifuMaterialTextbox1.Text = rr.GetValue(0).ToString();
                    bunifuMaterialTextbox2.Text = rr.GetValue(1).ToString();
                    bunifuMaterialTextbox3.Text = rr.GetValue(2).ToString();
                    comboBox1.Text = rr.GetValue(3).ToString();
                    bunifuMaterialTextbox4.Text = rr.GetValue(4).ToString();
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

                da = new SqlDataAdapter("Select *from staff where Staff_Name='" + bunifuMaterialTextbox5.Text + "' ", con);
              SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception e5)
            {
                MessageBox.Show("Please enter a valid name");
            }
            
           this.staffTableAdapter.Fill(this.db2DataSet2.staff);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuMaterialTextbox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            bunifuMaterialTextbox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            bunifuMaterialTextbox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
           
        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 m = new Form2();
            m.Show();
            this.Close();
        }
    }
}
