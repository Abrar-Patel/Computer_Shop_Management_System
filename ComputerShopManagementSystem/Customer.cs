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
using System.Text.RegularExpressions;

namespace ComputerShopManagementSystem
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hi\Documents\Visual Studio 2013\Projects\ComputerShopManagementSystem\ComputerShopManagementSystem\computershop.mdf;Integrated Security=True;Connect Timeout=30");
        private void display()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customer";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception ed)
            {
                MessageBox.Show(ed.Message);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void reset_field()
        {
            this.Close();
            Customer co = new Customer();
            co.Show();
        }
        private void Customer_Load(object sender, EventArgs e)
        {
            display();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select MAX(customer_Id) from customer";
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string i = sdr[0].ToString();
                    if (i == "")
                    {
                        textBox1.Text = "1";
                    }
                    else
                    {
                        textBox1.Text = (Convert.ToInt64(sdr[0].ToString()) + 1).ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                con.Close();
            }
            
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select name  from customer";
                SqlDataReader sdr1 = cmd.ExecuteReader();
                string i = "";
                while (sdr1.Read())
                {
                    i = Convert.ToString(sdr1[0]);
                    comboBox4.Items.Add(i);

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
                cmd.CommandText = "select distinct gender from customer";
                SqlDataReader sdr2 = cmd.ExecuteReader();
                string i = "";
                while (sdr2.Read())
                {
                    i = Convert.ToString(sdr2[0]);
                    comboBox6.Items.Add(i);

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
                cmd.CommandText = "select distinct state from customer";
                SqlDataReader sdr3 = cmd.ExecuteReader();
                string i = "";
                while (sdr3.Read())
                {
                    i = Convert.ToString(sdr3[0]);
                    comboBox7.Items.Add(i);

                }
                sdr3.Dispose();
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
                cmd.CommandText = "select distinct city from customer";
                SqlDataReader sdr4 = cmd.ExecuteReader();
                string i = "";
                while (sdr4.Read())
                {
                    i = Convert.ToString(sdr4[0]);
                    comboBox8.Items.Add(i);

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
                cmd.CommandText = "select distinct pincode from customer";
                SqlDataReader sdr5 = cmd.ExecuteReader();
                string i = "";
                while (sdr5.Read())
                {
                    i = Convert.ToString(sdr5[0]);
                    comboBox9.Items.Add(i);

                }
                sdr5.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                con.Close();
                MessageBox.Show(e4.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset_field();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for customer Firstname
                if (textBox2.Text == "")
                {
                    textBox2.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer First Name");
                    return;
                }

                //validation for customer L_name
                if (textBox6.Text == "")
                {
                    textBox6.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer Last Name");
                    return;
                }

                //validation for customer mob no
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer Mobile no");
                    return;
                }
                else
                {
                    long mo;
                    if(!long.TryParse(textBox3.Text, out mo))
                    {
                        textBox3.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Customer Mobile no in Digits[eg.9876543210]");
                        return;
                    }
                    else
                    {
                        long ml;
                        if((!long.TryParse(textBox3.Text,out ml)) || (textBox3.Text.Length>10 || textBox3.Text.Length<10))
                        {
                            textBox3.BackColor = Color.LightPink;
                            MessageBox.Show("Please Enter Customer Mobile no in 10 Digits[eg.9876543210]");
                            return;
                        }

                    }
                }
                

               //validation for customer email
                if (textBox4.Text == "")
                {
                    textBox4.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer Email");
                    return;
                }
                else
                {
                    bool chem = Regex.IsMatch(textBox4.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    if (chem == false)
                    {
                        textBox4.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Valid Email eg[sam@gmail.com]");
                        return;
                    }
                }

                if(radioButton1.Checked==false && radioButton2.Checked==false)
                {
                    radioButton1.BackColor = Color.LightPink;
                    radioButton2.BackColor = Color.LightPink;
                    MessageBox.Show("Please Select Gender");
                    return;
                }

                //validation for company state
                if (comboBox1.Text == "")
                {
                    comboBox1.BackColor = Color.LightPink;
                    MessageBox.Show("Please select Customer state");
                    return;
                }

                //validation for city
                string city = "";
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "")
                    {
                        comboBox2.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {
                        city = comboBox2.Text;
                    }
                }
                if (comboBox3.Visible == true)
                {
                    if (comboBox3.Text == "")
                    {
                        comboBox3.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox3.Text;
                    }
                }

                if (comboBox10.Visible == true)
                {
                    if (comboBox10.Text == "")
                    {
                        comboBox10.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox10.Text;
                    }
                }

                if (comboBox11.Visible == true)
                {
                    if (comboBox11.Text == "")
                    {
                        comboBox11.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox11.Text;
                    }
                }

                if (comboBox12.Visible == true)
                {
                    if (comboBox12.Text == "")
                    {
                        comboBox12.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox12.Text;
                    }
                }

                if (comboBox13.Visible == true)
                {
                    if (comboBox13.Text == "")
                    {
                        comboBox13.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox13.Text;
                    }
                }

                if (comboBox14.Visible == true)
                {
                    if (comboBox14.Text == "")
                    {
                        comboBox14.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox14.Text;
                    }
                }

                if (comboBox15.Visible == true)
                {
                    if (comboBox15.Text == "")
                    {
                        comboBox15.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox15.Text;
                    }
                }

                if (comboBox16.Visible == true)
                {
                    if (comboBox16.Text == "")
                    {
                        comboBox16.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox16.Text;
                    }
                }

                if (comboBox17.Visible == true)
                {
                    if (comboBox17.Text == "")
                    {
                        comboBox17.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox17.Text;
                    }
                }

                if (comboBox18.Visible == true)
                {
                    if (comboBox18.Text == "")
                    {
                        comboBox18.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox18.Text;
                    }
                }
               
                //validation for customer area
                if (textBox8.Text == "")
                {
                    textBox8.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer Village/Area/Town Name");
                    return;
                }

                //validation for customer house ni
                if (textBox9.Text == "")
                {
                    textBox9.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Customer House no/street name/apartment name Name");
                    return;
                }

                //validation for company pincode
                if (textBox10.Text == "")
                {
                    textBox10.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer pincode");
                    return;
                }
                else
                {
                    long pin;
                    if (!long.TryParse(textBox10.Text, out pin))
                    {
                        textBox10.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Customer pincode in Digits[eg.413002]");
                        return;
                    }
                }

                string gen = "";
                if (radioButton1.Checked)
                    gen = "Male";
                if (radioButton2.Checked)
                    gen = "Female";

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string name = textBox2.Text + "  " + textBox6.Text;
                cmd.CommandText = "insert into customer values('" + name + "','" + textBox3.Text + "','" + textBox4.Text + "','" + gen + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + city + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Customer Added succesfully");
                reset_field();
            }
            catch(Exception ei)
            {
                con.Close();
                MessageBox.Show(ei.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.BackColor = Color.White;
            
            if (comboBox1.SelectedItem == "Andhra Pradesh")
            {
                comboBox2.Visible = true;
                comboBox3.Visible = false;
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
            if (comboBox1.SelectedItem == "Chhattisgarh")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = true;
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
            if (comboBox1.SelectedItem == "Delhi")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
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
            if (comboBox1.SelectedItem == "Goa")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
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
            if (comboBox1.SelectedItem == "Gujarat")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
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
            if (comboBox1.SelectedItem == "Karnataka")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
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
            if (comboBox1.SelectedItem == "Madhya Paradesh")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
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
            if (comboBox1.SelectedItem == "Maharashtra")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
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
            if (comboBox1.SelectedItem == "Rajasthan")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
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
            if (comboBox1.SelectedItem == "Tamil Nadu")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
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
            if (comboBox1.SelectedItem == "Telangana")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.BackColor = Color.White;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string bt1 = "";
            string cit = "", sta = "";
            int i = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
            textBox3.Text = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
            textBox4.Text = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
            bt1 = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
           if (bt1 == "Male")
                radioButton1.Checked = true;
            if (bt1 == "Female")
                radioButton2.Checked = true;
            textBox5.Text = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);
            comboBox1.Text = Convert.ToString(dataGridView1.Rows[i].Cells[6].Value);
            sta = Convert.ToString(dataGridView1.Rows[i].Cells[6].Value);
            cit = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
            if (sta == "Andhra Pradesh")
            {
                comboBox2.Visible = true;
                comboBox2.Text = cit;
            }
            if (sta == "Chhattisgarh")
            {
                comboBox3.Visible = true;
                comboBox3.Text = cit;
            }
            if (sta == "Delhi")
            {
                comboBox10.Visible = true;
                comboBox10.Text = cit;
            }
            if (sta == "Goa")
            {
                comboBox11.Visible = true;
                comboBox11.Text = cit;
            }
            if (sta == "Gujarat")
            {
                comboBox12.Visible = true;
                comboBox12.Text = cit;
            }
            if (sta == "Karnataka")
            {
                comboBox13.Visible = true;
                comboBox13.Text = cit;
            }
            if (sta == "Madhya Paradesh")
            {
                comboBox14.Visible = true;
                comboBox14.Text = cit;
            }
            if (sta == "Maharashtra")
            {
                comboBox15.Visible = true;
                comboBox15.Text = cit;
            }
            if (sta == "Rajasthan")
            {
                comboBox16.Visible = true;
                comboBox16.Text = cit;
            }
            if (sta == "Tamil Nadu")
            {
                comboBox17.Visible = true;
                comboBox17.Text = cit;
            }
            if (sta == "Telangana")
            {
                comboBox18.Visible = true;
                comboBox18.Text = cit;
            }
            textBox8.Text = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);
            textBox9.Text = Convert.ToString(dataGridView1.Rows[i].Cells[9].Value);
            textBox10.Text = Convert.ToString(dataGridView1.Rows[i].Cells[10].Value);
            
           
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for customer Firstname
                if (textBox2.Text == "")
                {
                    textBox2.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer First Name");
                    return;
                }

                //validation for customer L_name
                if (textBox6.Text == "")
                {
                    textBox6.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer Last Name");
                    return;
                }

                //validation for customer mob no
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer Mobile no");
                    return;
                }
                else
                {
                    long mo;
                    if (!long.TryParse(textBox3.Text, out mo))
                    {
                        textBox3.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Customer Mobile no in Digits[eg.9876543210]");
                        return;
                    }
                    else
                    {
                        long ml;
                        if ((!long.TryParse(textBox3.Text, out ml)) || (textBox3.Text.Length > 10 || textBox3.Text.Length < 10))
                        {
                            textBox3.BackColor = Color.LightPink;
                            MessageBox.Show("Please Enter Customer Mobile no in 10 Digits[eg.9876543210]");
                            return;
                        }

                    }
                }


                //validation for customer email
                if (textBox4.Text == "")
                {
                    textBox4.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer Email");
                    return;
                }
                else
                {
                    bool chem = Regex.IsMatch(textBox4.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    if (chem == false)
                    {
                        textBox4.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Valid Email eg[sam@gmail.com]");
                        return;
                    }
                }

                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    radioButton1.BackColor = Color.LightPink;
                    radioButton2.BackColor = Color.LightPink;
                    MessageBox.Show("Please Select Gender");
                    return;
                }

                //validation for company state
                if (comboBox1.Text == "")
                {
                    comboBox1.BackColor = Color.LightPink;
                    MessageBox.Show("Please select Customer state");
                    return;
                }

                //validation for city
                string city = "";
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "")
                    {
                        comboBox2.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {
                        city = comboBox2.Text;
                    }
                }
                if (comboBox3.Visible == true)
                {
                    if (comboBox3.Text == "")
                    {
                        comboBox3.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox3.Text;
                    }
                }

                if (comboBox10.Visible == true)
                {
                    if (comboBox10.Text == "")
                    {
                        comboBox10.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox10.Text;
                    }
                }

                if (comboBox11.Visible == true)
                {
                    if (comboBox11.Text == "")
                    {
                        comboBox11.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox11.Text;
                    }
                }

                if (comboBox12.Visible == true)
                {
                    if (comboBox12.Text == "")
                    {
                        comboBox12.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox12.Text;
                    }
                }

                if (comboBox13.Visible == true)
                {
                    if (comboBox13.Text == "")
                    {
                        comboBox13.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox13.Text;
                    }
                }

                if (comboBox14.Visible == true)
                {
                    if (comboBox14.Text == "")
                    {
                        comboBox14.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox14.Text;
                    }
                }

                if (comboBox15.Visible == true)
                {
                    if (comboBox15.Text == "")
                    {
                        comboBox15.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox15.Text;
                    }
                }

                if (comboBox16.Visible == true)
                {
                    if (comboBox16.Text == "")
                    {
                        comboBox16.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox16.Text;
                    }
                }

                if (comboBox17.Visible == true)
                {
                    if (comboBox17.Text == "")
                    {
                        comboBox17.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox17.Text;
                    }
                }

                if (comboBox18.Visible == true)
                {
                    if (comboBox18.Text == "")
                    {
                        comboBox18.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Customer city");
                        return;
                    }
                    else
                    {

                        city = comboBox18.Text;
                    }
                }

                //validation for customer area
                if (textBox8.Text == "")
                {
                    textBox8.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer Village/Area/Town Name");
                    return;
                }

                //validation for customer house ni
                if (textBox9.Text == "")
                {
                    textBox9.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Customer House no/street name/apartment name Name");
                    return;
                }

                //validation for company pincode
                if (textBox10.Text == "")
                {
                    textBox10.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter customer pincode");
                    return;
                }
                else
                {
                    int pin;
                    if (!int.TryParse(textBox10.Text, out pin))
                    {
                        textBox10.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Customer pincode in Digits[eg.413002]");
                        return;
                    }
                }
               
                string gen2 = "";
                if (radioButton1.Checked)
                    gen2 = "Male";
                if (radioButton2.Checked)
                    gen2 = "Female";
                string name1 = textBox2.Text + "  " + textBox6.Text;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update customer set name='" + name1 + "',mobile_no='" + textBox3.Text + "',email='" + textBox4.Text + "',gender='" + gen2 + "',state='"+comboBox1.Text+"',city='"+city+"',Area='" + textBox8.Text + "',house_no='" + textBox9.Text + "',pincode='" + textBox10.Text + "' where customer_Id='"+textBox1.Text+"'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Customer updated succesfully");
                reset_field();
            }
            catch (Exception eu)
            {
                MessageBox.Show(eu.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customer where name='"+comboBox4.Text+"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ed)
            {
                con.Close();
                MessageBox.Show(ed.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.White;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8.BackColor = Color.White;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox9.BackColor = Color.White;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox10.BackColor = Color.White;
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox3.BackColor = Color.White;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.BackColor = Color.White;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox10.BackColor = Color.White;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox11.BackColor = Color.White;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox12.BackColor = Color.White;
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox13.BackColor = Color.White;
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox14.BackColor = Color.White;
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox15.BackColor = Color.White;
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox16.BackColor = Color.White;
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox17.BackColor = Color.White;
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox18.BackColor = Color.White;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem == "Customer Name")
            {
                comboBox4.Visible = true;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
            }
            if (comboBox5.SelectedItem == "Customer Gender")
            {
                comboBox4.Visible = false;
                comboBox6.Visible = true;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
            }
            if (comboBox5.SelectedItem == "State")
            {
                comboBox4.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = true;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
            }
            if (comboBox5.SelectedItem == "City")
            {
                comboBox4.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = true;
                comboBox9.Visible = false;
            }
            if (comboBox5.SelectedItem == "Pincode")
            {
                comboBox4.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = true;
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customer where gender='" + comboBox6.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ed)
            {
                con.Close();
                MessageBox.Show(ed.Message);
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customer where state='" + comboBox7.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ed)
            {
                con.Close();
                MessageBox.Show(ed.Message);
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customer where city='" + comboBox8.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ed)
            {
                con.Close();
                MessageBox.Show(ed.Message);
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customer where pincode='" + comboBox9.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ed)
            {
                con.Close();
                MessageBox.Show(ed.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.BackColor = Color.White;
            radioButton2.BackColor = Color.White;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.BackColor = Color.White;
            radioButton1.BackColor = Color.White;
        }
    }
}
