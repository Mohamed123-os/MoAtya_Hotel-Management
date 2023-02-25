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
    public partial class reservation : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        public reservation()
        {
            InitializeComponent();
           
        }
        DateTime today;

        private void reservation_Load(object sender, EventArgs e)
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
            // TODO: This line of code loads data into the 'db2DataSet8.reservation' table. You can move, or remove it, as needed.
            this.reservationTableAdapter.Fill(this.db2DataSet8.reservation);

            today = dateTimePicker1.Value;
            label2.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            fillRoomcombo();
            fillclientcombo();
          
       
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            int res = DateTime.Compare(dateTimePicker1.Value,today);
            if (DialogResult < 0)
            {
                MessageBox.Show("Wrong Date For Reservation");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 m = new Form2();
            m.Show();
            this.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            int res = DateTime.Compare(dateTimePicker2.Value, dateTimePicker1.Value);
            if (DialogResult < 0)
            {
                MessageBox.Show("Wrong Date Out Check Once More");
            }
        }
        //####################################
        public void updateroomstate()
        {
            string newstate1 = "Busy";
            try
            {
                SqlCommand com4 = new SqlCommand("UPDATE room  Set RoomFree= '" + newstate1+"'where RoomNumber='" + Convert.ToInt32( comboBox3.SelectedItem.ToString())+ "'", con);
                com4.ExecuteNonQuery();
              //  fillRoomcombo();
                this.reservationTableAdapter.Fill(this.db2DataSet8.reservation);     

            }
            catch (Exception e4)
            {
                MessageBox.Show(e4.Message);
            }
        }
        //####################################
        public void updateroomstatedelete()
        {
            string newstate2 = "Free";
           int roomnumber = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            try
            {
                SqlCommand com4 = new SqlCommand("UPDATE room  Set RoomFree= '" + newstate2 + "'where RoomNumber='" + roomnumber + "'", con);
                com4.ExecuteNonQuery();
             
            }
            catch (Exception e4)
            {
                MessageBox.Show(e4.Message);
            }
       
        }
        //#################################

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand c = new SqlCommand("insert into reservation(ResID,Client,RoomNumber,DateIN,DateOut)values('" +Convert.ToInt32( bunifuMaterialTextbox1.Text) + "','" + comboBox2.SelectedItem.ToString()+ "','" +Convert.ToInt32( comboBox3.SelectedItem.ToString()) + "','" + dateTimePicker1.Value + "','"+dateTimePicker2.Value+"')", con);
                c.ExecuteNonQuery();

                this.reservationTableAdapter.Fill(this.db2DataSet8.reservation);
             
                MessageBox.Show("Added successfully");
                updateroomstate();
              //  fillRoomcombo();
            }
            catch (Exception e2)
            {
                MessageBox.Show("Please enter valid values");
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {

                da = new SqlDataAdapter("Select *from reservation where ResID='" + bunifuMaterialTextbox5.Text + "'", con);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception e5)
            {
                MessageBox.Show("Please enter a valid ID");
            }

            this.reservationTableAdapter.Fill(this.db2DataSet8.reservation);
        }
        public void fillRoomcombo()
        {
            string roomstate= "Free";
            try
            {
                SqlCommand cmd = new SqlCommand("select *from room where RoomFree='"+ roomstate +"'", con);
                SqlDataReader rdr= cmd.ExecuteReader();

                while (rdr.Read())
                {
                    comboBox3.Items.Add(rdr["RoomNumber"]);
                }
                rdr.Close();
            }
            catch (Exception e5)
            {
                MessageBox.Show(e5.Message);
            }
           
        }
        //public void fillRoomcombo2()
        //{
        //    string roomstate = "Free";
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("select *from room where RoomFree='" + roomstate + "'", con);
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            comboBox3.Items.Add(rdr["RoomNumber"]);
        //        }
        //        rdr.Close();
        //    }
        //    catch (Exception e5)
        //    {
        //        MessageBox.Show(e5.Message);
        //    }

        //}
        public void fillclientcombo()
        {
            try
            {
                SqlCommand cm = new SqlCommand("select *from client", con);
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    comboBox2.Items.Add(rd["ClientName"]);
                }
                rd.Close();
            }
            catch (Exception e5)
            {
                MessageBox.Show(e5.Message);

            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                da = new SqlDataAdapter("Select *from reservation where ResID='" + bunifuMaterialTextbox5.Text + "' ", con);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception e5)
            {
                MessageBox.Show("Please enter a v alid name");
            }

            try
            {

                SqlCommand dd = new SqlCommand("Select *from reservation where ResID='" + bunifuMaterialTextbox5.Text + "' ", con);
                SqlDataReader rr = dd.ExecuteReader();
                if (rr.Read())
                {
                    bunifuMaterialTextbox1.Text = rr.GetValue(0).ToString();
                    comboBox2.Text = rr.GetValue(1).ToString();
                    comboBox3.Text = rr.GetValue(2).ToString();
                    dateTimePicker1.Text= rr.GetValue(3).ToString();
                    dateTimePicker2.Text = rr.GetValue(4).ToString();
                }
                rr.Close();
            }
            catch (Exception e6)
            {
                MessageBox.Show(e6.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")
            {

                MessageBox.Show(" please enter a reservation id");
            }
            else
            {
                try
                {
                    SqlCommand com4 = new SqlCommand("UPDATE reservation Set Client='"+comboBox2.SelectedItem.ToString()+ "',RoomNumber='"+comboBox3.SelectedItem.ToString()+ "',DateIN='" + dateTimePicker1.Value.ToString()+ "',DateOut='" +dateTimePicker2.Value.ToString()+ "'where ResID='" + bunifuMaterialTextbox1.Text+"'", con);
                    com4.ExecuteNonQuery();
                    this.reservationTableAdapter.Fill(this.db2DataSet8.reservation);
                    MessageBox.Show(" Updated Successfully");
                }
                catch (Exception e4)
                {
                    MessageBox.Show(e4.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuMaterialTextbox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")
            {

                MessageBox.Show(" please enter a reservation id");
            }
            else { 
                try
                {
                    SqlCommand c1 = new SqlCommand(" Delete from reservation where ResID=" + bunifuMaterialTextbox1.Text, con);
                    c1.ExecuteNonQuery();
                    updateroomstatedelete();
                   // fillRoomcombo();
                    this.reservationTableAdapter.Fill(this.db2DataSet8.reservation);
                  
                    MessageBox.Show("Deleted Sucessfully");
                   
                }
                 
                catch (Exception e3)
                {
                    MessageBox.Show("please enter a valid ID");
                }
               // updateroomstatedelete();
            }
        }
    }
}
