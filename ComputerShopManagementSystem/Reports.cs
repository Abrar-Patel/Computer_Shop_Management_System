using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ComputerShopManagementSystem
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hi\documents\visual studio 2013\Projects\ComputerShopManagementSystem\ComputerShopManagementSystem\computershop.mdf;Integrated Security=True;Connect Timeout=30");
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel9.Visible = false;
            panel12.Visible = false;
            panel4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel9.Visible = false;
            panel12.Visible = false;
            panel5.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel12.Visible = false;
            panel4.Visible = false;
            panel9.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
            panel5.Visible = false;
            panel4.Visible = false;
            panel12.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
           try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string fr = dateTimePicker5.Text;
                string to = dateTimePicker6.Text;
                cmd.CommandText = "select * from sale where date >='"+dateTimePicker5.Text+"' and date <= '"+dateTimePicker6.Text+"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string fr = dateTimePicker5.Text;
                string to = dateTimePicker6.Text;
                cmd.CommandText = "select * from computerstock ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct company from computerstock";
                SqlDataReader sdr1 = cmd.ExecuteReader();
                string i = "";
                while (sdr1.Read())
                {
                    i = Convert.ToString(sdr1[0]);
                    comboBox1.Items.Add(i);

                }
                sdr1.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct generation from computerstock";
                SqlDataReader sdr2 = cmd.ExecuteReader();
                string i = "";
                while (sdr2.Read())
                {
                    i = Convert.ToString(sdr2[0]);
                    comboBox4.Items.Add(i);

                }
                sdr2.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct os from computerstock";
                SqlDataReader sdr4 = cmd.ExecuteReader();
                string i = "";
                while (sdr4.Read())
                {
                    i = Convert.ToString(sdr4[0]);
                    comboBox5.Items.Add(i);

                }
                sdr4.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct ram from computerstock";
                SqlDataReader sdr5 = cmd.ExecuteReader();
                string i = "";
                while (sdr5.Read())
                {
                    i = Convert.ToString(sdr5[0]);
                    comboBox6.Items.Add(i);

                }
                sdr5.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct cpu_manufac from computerstock";
                SqlDataReader sdr6 = cmd.ExecuteReader();
                string i = "";
                while (sdr6.Read())
                {
                    i = Convert.ToString(sdr6[0]);
                    comboBox7.Items.Add(i);

                }
                sdr6.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct hard_disk from computerstock";
                SqlDataReader sdr7 = cmd.ExecuteReader();
                string i = "";
                while (sdr7.Read())
                {
                    i = Convert.ToString(sdr7[0]);
                    comboBox8.Items.Add(i);

                }
                sdr7.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct screen_size from computerstock";
                SqlDataReader sdr8 = cmd.ExecuteReader();
                string i = "";
                while (sdr8.Read())
                {
                    i = Convert.ToString(sdr8[0]);
                    comboBox9.Items.Add(i);

                }
                sdr8.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct color from computerstock";
                SqlDataReader sdr10 = cmd.ExecuteReader();
                string i = "";
                while (sdr10.Read())
                {
                    i = Convert.ToString(sdr10[0]);
                    comboBox10.Items.Add(i);

                }
                sdr10.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct weight from computerstock";
                SqlDataReader sdr11 = cmd.ExecuteReader();
                string i = "";
                while (sdr11.Read())
                {
                    i = Convert.ToString(sdr11[0]);
                    comboBox11.Items.Add(i);

                }
                sdr11.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct supplier_name from computerstock";
                SqlDataReader sdr12 = cmd.ExecuteReader();
                string i = "";
                while (sdr12.Read())
                {
                    i = Convert.ToString(sdr12[0]);
                    comboBox12.Items.Add(i);

                }
                sdr12.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct cpu_speed from computerstock";
                SqlDataReader sdr13 = cmd.ExecuteReader();
                string i = "";
                while (sdr13.Read())
                {
                    i = Convert.ToString(sdr13[0]);
                    comboBox13.Items.Add(i);

                }
                sdr13.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct model_no from computerstock";
                SqlDataReader sdr14 = cmd.ExecuteReader();
                string i = "";
                while (sdr14.Read())
                {
                    i = Convert.ToString(sdr14[0]);
                    comboBox14.Items.Add(i);

                }
                sdr14.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct processor_type from computerstock";
                SqlDataReader sdr15 = cmd.ExecuteReader();
                string i = "";
                while (sdr15.Read())
                {
                    i = Convert.ToString(sdr15[0]);
                    comboBox15.Items.Add(i);

                }
                sdr15.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct purchase_price from computerstock";
                SqlDataReader sdr16 = cmd.ExecuteReader();
                string i = "";
                while (sdr16.Read())
                {
                    i = Convert.ToString(sdr16[0]);
                    comboBox16.Items.Add(i);

                }
                sdr16.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct saling_price from computerstock";
                SqlDataReader sdr17 = cmd.ExecuteReader();
                string i = "";
                while (sdr17.Read())
                {
                    i = Convert.ToString(sdr17[0]);
                    comboBox17.Items.Add(i);

                }
                sdr17.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct quantity from computerstock";
                SqlDataReader sdr18 = cmd.ExecuteReader();
                string i = "";
                while (sdr18.Read())
                {
                    i = Convert.ToString(sdr18[0]);
                    comboBox18.Items.Add(i);

                }
                sdr18.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string fr = dateTimePicker5.Text;
                string to = dateTimePicker6.Text;
                cmd.CommandText = "select * from quotation where date >='" + dateTimePicker7.Text + "' and date <= '" + dateTimePicker8.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView4.DataSource = dt;
                con.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select purchase_price from sale where date >='" + dateTimePicker1.Text + "' and date <= '" + dateTimePicker2.Text + "'";
                SqlDataReader sdr3 = cmd.ExecuteReader();
                int pp = 0;
                while (sdr3.Read())
                {
                    pp = pp + Convert.ToInt32(sdr3[0]);

                }
                sdr3.Dispose();
                //cmd.CommandText = "select saling_price from sale where date >='" + dateTimePicker1.Text + "' and date <= '" + dateTimePicker2.Text + "'";
                //SqlDataReader sdr4 = cmd.ExecuteReader();
                //int sp = 0;
                //while (sdr4.Read())
                //{
                //    sp = sp + Convert.ToInt32(sdr4[0]);

                //}
                //sdr4.Dispose();
                cmd.CommandText = "select amount from bill where date >='" + dateTimePicker1.Text + "' and date <= '" + dateTimePicker2.Text + "'";
                SqlDataReader sdr5 = cmd.ExecuteReader();
                int am = 0;
                while (sdr5.Read())
                {
                    am = am + Convert.ToInt32(sdr5[0]);

                }
                sdr5.Dispose();
                int prf = am - pp;
                label7.Text = Convert.ToString(prf);
                con.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                con.Close();
            }
        
          }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where cpu_manufac='" + comboBox7.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Company")
            {
                comboBox1.Visible = true;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Generation")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = true;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Operating System")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = true;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "RAM")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = true;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "CPU Manufacturer")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = true;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Hard Disk Size")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = true;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Screen Size")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = true;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Color")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = true;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Weight")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = true;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Supplier Name")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = true;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "CPU Speed")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = true;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Model No")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = true;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Processor Type")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = true;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Purchase Price")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = true;
                comboBox17.Visible = false;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Selling Price")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = true;
                comboBox18.Visible = false;
            }
            if (comboBox2.SelectedItem == "Quantity")
            {
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                comboBox16.Visible = false;
                comboBox17.Visible = false;
                comboBox18.Visible = true;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where company='" + comboBox1.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s1)
            {
                con.Close();
                MessageBox.Show(s1.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where generation='" + comboBox4.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s2)
            {
                con.Close();
                MessageBox.Show(s2.Message);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where os='" + comboBox5.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where ram='" + comboBox6.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where hard_disk='" + comboBox8.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where screen_size='" + comboBox9.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where color='" + comboBox10.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where weight='" + comboBox11.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where supplier_name='" + comboBox12.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where cpu_speed='" + comboBox13.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where model_no='" + comboBox14.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where processor_type='" + comboBox15.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where purchase_price='" + comboBox16.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where saling_price='" + comboBox17.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where quantity='" + comboBox18.SelectedItem + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception eb)
            {
                con.Close();
                MessageBox.Show(eb.Message);
            }
        }
    }
}
