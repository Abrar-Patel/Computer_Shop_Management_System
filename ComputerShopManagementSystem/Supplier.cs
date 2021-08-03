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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hi\Documents\Visual Studio 2013\Projects\ComputerShopManagementSystem\ComputerShopManagementSystem\computershop.mdf;Integrated Security=True;Connect Timeout=30");
        private void clear_field()
        {
            this.Close();
            Supplier sn = new Supplier();
            sn.Show();
        }
        
        private void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Supplier";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sqa = new SqlDataAdapter(cmd);
            sqa.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clear_field();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for company name
                if (textBox2.Text == "")
                {
                    textBox2.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company Name");
                    return;
                }

                if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked==false)
                {
                    radioButton1.BackColor = Color.LightPink;
                    radioButton2.BackColor = Color.LightPink;
                    radioButton3.BackColor = Color.LightPink;
                    MessageBox.Show("Please Select Supplier Business type");
                    return;
                }

               
                
                //validation for company website
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company Website");
                    return;
                }

                //validation for company fax
                if (textBox4.Text == "")
                {
                    textBox4.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company fax");
                    return;
                }

                //validation for company contact email
                if (textBox5.Text == "")
                {
                    textBox5.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company contact Email");
                    return;
                }
                else
                {
                    bool chem = Regex.IsMatch(textBox5.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    if (chem == false)
                    {
                        textBox5.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Valid Email eg[sam@gmail.com]");
                        return;
                    }
                }

                //validation for company contact number
                if (textBox6.Text == "")
                {
                    textBox6.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Company Contact Number");
                    return;
                }
                else
                {
                    long mob;
                    if (!long.TryParse(textBox6.Text, out mob))
                    {
                        textBox6.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Company Contact Number in Digits[eg.1234567890]");
                        return;
                    }
                    else
                    {
                        long ml;
                        if ((!long.TryParse(textBox6.Text, out ml)) || (textBox6.Text.Length > 10 || textBox6.Text.Length < 10))
                        {
                            textBox6.BackColor = Color.LightPink;
                            MessageBox.Show("Please Enter Customer Mobile no in 10 Digits[eg.9876543210]");
                            return;
                        }

                    }
                }

                //validation for company representing person
                if (textBox7.Text == "")
                {
                    textBox7.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company representing person Name");
                    return;
                }

                //validation for company state
                if (comboBox1.Text == "")
                {
                    comboBox1.BackColor = Color.LightPink;
                    MessageBox.Show("Please select company state");
                    return;
                }

               //validation for city
                string city = "";
                if (comboBox2.Visible == true)
                {
                   if (comboBox2.Text == "")
                    {
                        comboBox2.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
                        return;
                    }
                    else
                    {

                        city = comboBox18.Text;
                    }
                }
                //validation for company street name
                if (textBox8.Text == "")
                {
                    textBox8.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company Street Name");
                    return;
                }


                //validation for company pincode
                if (textBox12.Text == "")
                {
                    textBox12.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company pincode");
                    return;
                }
                else
                {
                    int pin;
                    if (!int.TryParse(textBox12.Text, out pin))
                    {
                        textBox12.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Company pincode in Digits[eg.413002]");
                        return;
                    }
                }

                string bt = "";
                if (radioButton1.Checked)
                    bt = "Manufacturer";
                if (radioButton2.Checked)
                    bt = "Distributor";
                if (radioButton3.Checked)
                    bt = "Service provider";
                
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Supplier values('" + textBox2.Text + "','" + bt + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + city + "','" + comboBox1.Text + "','" + textBox11.Text + "','" + textBox12.Text + "' )";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Supplier Added succesfully");
                clear_field();
            }
            catch(Exception ei)
            {
                con.Close();
                MessageBox.Show(ei.Message);
            }

        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            display();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select MAX(id) from Supplier";
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
                cmd.CommandText = "select distinct company_name from Supplier";
                SqlDataReader sdr1 = cmd.ExecuteReader();
                string i = "";
                while (sdr1.Read())
                {
                    i = Convert.ToString(sdr1[0]);
                    comboBox5.Items.Add(i);

                }
                sdr1.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                MessageBox.Show(e4.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct business_type from Supplier";
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
                MessageBox.Show(e4.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct company_repre_name from Supplier";
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
                MessageBox.Show(e4.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct company_State from Supplier";
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
                MessageBox.Show(e4.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct comapny_city from Supplier";
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
                MessageBox.Show(e4.Message);
                con.Close();
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string bt1 = "";
            int i = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
            bt1 = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
            if (bt1 == "Manufacturer")
                radioButton1.Checked=true;
            if (bt1 == "Distributor")
                radioButton2.Checked = true;
            if (bt1 == "Service provider")
                radioButton3.Checked = true;
            textBox3.Text = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
            textBox4.Text = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
            textBox5.Text = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);
            textBox6.Text = Convert.ToString(dataGridView1.Rows[i].Cells[6].Value);
            textBox7.Text = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
            textBox8.Text = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);
            comboBox1.Text = Convert.ToString(dataGridView1.Rows[i].Cells[10].Value);
            textBox12.Text = Convert.ToString(dataGridView1.Rows[i].Cells[12].Value);
            string cit = "",sta="";
            sta=Convert.ToString(dataGridView1.Rows[i].Cells[10].Value);
            cit = Convert.ToString(dataGridView1.Rows[i].Cells[9].Value);
            if(sta=="Andhra Pradesh")
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for company name
                if (textBox2.Text == "")
                {
                    textBox2.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company Name");
                    return;
                }

                if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
                {
                    radioButton1.BackColor = Color.LightPink;
                    radioButton2.BackColor = Color.LightPink;
                    radioButton3.BackColor = Color.LightPink;
                    MessageBox.Show("Please Select Supplier Business type");
                    return;
                }

                //validation for company website
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company Website");
                    return;
                }

                //validation for company fax
                if (textBox4.Text == "")
                {
                    textBox4.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company fax");
                    return;
                }

                //validation for company contact email
                if (textBox5.Text == "")
                {
                    textBox5.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company contact Email");
                    return;
                }
                else
                {
                    bool chem = Regex.IsMatch(textBox5.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    if (chem == false)
                    {
                        textBox5.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Valid Email eg[sam@gmail.com]");
                        return;
                    }
                }

                //validation for company contact number
                if (textBox6.Text == "")
                {
                    textBox6.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Company Contact Number");
                    return;
                }
                else
                {
                    long mob;
                    if (!long.TryParse(textBox6.Text, out mob))
                    {
                        textBox6.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Company Contact Number in Digits[eg.1234567890]");
                        return;
                    }
                    else
                    {
                        long ml;
                        if ((!long.TryParse(textBox6.Text, out ml)) || (textBox6.Text.Length > 10 || textBox6.Text.Length < 10))
                        {
                            textBox6.BackColor = Color.LightPink;
                            MessageBox.Show("Please Enter Customer Mobile no in 10 Digits[eg.9876543210]");
                            return;
                        }

                    }
                }

                //validation for company representing person
                if (textBox7.Text == "")
                {
                    textBox7.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company representing person Name");
                    return;
                }

                //validation for company state
                if (comboBox1.Text == "")
                {
                    comboBox1.BackColor = Color.LightPink;
                    MessageBox.Show("Please select company state");
                    return;
                }

                //validation for city
                string city = "";
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "")
                    {
                        comboBox2.BackColor = Color.LightPink;
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
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
                        MessageBox.Show("Please select Company city");
                        return;
                    }
                    else
                    {

                        city = comboBox18.Text;
                    }
                }
                //validation for company street name
                if (textBox8.Text == "")
                {
                    textBox8.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company Street Name");
                    return;
                }


                //validation for company pincode
                if (textBox12.Text == "")
                {
                    textBox12.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company pincode");
                    return;
                }
                else
                {
                    int pin;
                    if (!int.TryParse(textBox12.Text, out pin))
                    {
                        textBox12.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Company pincode in Digits[eg.413002]");
                        return;
                    }
                }
                string bt2 = "";
                if (radioButton1.Checked)
                    bt2 = "Manufacturer";
                if (radioButton2.Checked)
                    bt2 = "Distributor";
                if (radioButton3.Checked)
                    bt2 = "Service provider";

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Supplier set company_name='" + textBox2.Text + "',business_type='" + bt2 + "',company_website='" + textBox3.Text + "',company_fax='" + textBox4.Text + "',company_email='" + textBox5.Text + "',company_phone='" + textBox6.Text + "',company_repre_name='" + textBox7.Text + "',company_street='" + textBox8.Text + "',comapny_city='" + city + "',company_State='" + comboBox1.SelectedItem + "',company_pincode='" + textBox12.Text + "' where Id='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Supplier updated succesfully");
                clear_field();
            }
            catch (Exception eu)
            {
                con.Close();
                MessageBox.Show(eu.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from supplier where Id='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Supplier removed succesfully");
                clear_field();
            }
            catch (Exception eu)
            {
                MessageBox.Show(eu.Message);
            }
        }

       private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == "Company Name")
            {
                comboBox5.Visible = true;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
            }
            if (comboBox4.SelectedItem == "Business type")
            {
                comboBox5.Visible = false;
                comboBox6.Visible = true;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
            }
            if (comboBox4.SelectedItem == "Company representing Name")
            {
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = true;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
            }
            if (comboBox4.SelectedItem == "State")
            {
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = true;
                comboBox9.Visible = false;
            } 
            if (comboBox4.SelectedItem == "City")
            {
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = true;
            }

        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Supplier where company_name='" + comboBox5.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception es8)
            {
                MessageBox.Show(es8.Message);
            }
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Supplier where business_type='" + comboBox6.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception es8)
            {
                MessageBox.Show(es8.Message);
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Supplier where company_repre_name='" + comboBox7.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception es8)
            {
                MessageBox.Show(es8.Message);
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Supplier where company_State='" + comboBox8.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception es8)
            {
                MessageBox.Show(es8.Message);
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Supplier where comapny_city='" + comboBox9.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception es8)
            {
                MessageBox.Show(es8.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.White;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.BackColor = Color.White;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.BackColor = Color.White;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.BackColor = Color.White;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8.BackColor = Color.White;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            textBox12.BackColor = Color.White;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox2.BackColor = Color.White;
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox18.BackColor = Color.White;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.BackColor = Color.White;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.BackColor = Color.White;
            radioButton2.BackColor = Color.White;
            radioButton3.BackColor = Color.White;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.BackColor = Color.White;
            radioButton2.BackColor = Color.White;
            radioButton3.BackColor = Color.White;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.BackColor = Color.White;
            radioButton2.BackColor = Color.White;
            radioButton3.BackColor = Color.White;
        }
    }
}
