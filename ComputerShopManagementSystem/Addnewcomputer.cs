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
    public partial class Addnewcomputer : Form
    {
        public Addnewcomputer()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hi\documents\visual studio 2013\Projects\ComputerShopManagementSystem\ComputerShopManagementSystem\computershop.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reset_field()
        {
            this.Close();
            Addnewcomputer adn = new Addnewcomputer();
            adn.Show();
        }

        public void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from computerstock";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sqa = new SqlDataAdapter(cmd);
            sqa.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
       
        private void Addnewcomputer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'computershopDataSet12.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter1.Fill(this.computershopDataSet12.Supplier);
            display();
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
                dataGridView1.DataSource = dt;
                con.Close();
             }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select MAX(product_Id) from computerstock";
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string i = sdr[0].ToString();
                    if (i == "")
                    {
                        textBox16.Text = "1";
                    }
                    else
                    {
                        textBox16.Text = (Convert.ToInt64(sdr[0].ToString()) + 1).ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);

            }
            
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct company_name  from Supplier";
                SqlDataReader sdrs = cmd.ExecuteReader();
                string i = "";
                while (sdrs.Read())
                {
                    i = Convert.ToString(sdrs[0]);
                    comboBox1.Items.Add(i);

                }
                sdrs.Dispose();
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
                cmd.CommandText = "select distinct company from computerstock";
                SqlDataReader sdr1 = cmd.ExecuteReader();
                string i = "";
                while (sdr1.Read())
                {
                    i = Convert.ToString(sdr1[0]);
                    comboBox3.Items.Add(i);

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
                SqlDataReader sdr8= cmd.ExecuteReader();
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

        private void button5_Click(object sender, EventArgs e)
        {
            reset_field();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for Company name
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Enter  product Company name");
                    textBox1.BackColor = Color.LightPink;
                    return;
                }

                //validation for generation
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Please Enter  product Generation");
                    textBox2.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    int gi;
                    if (!int.TryParse(textBox2.Text, out gi))
                    {
                        textBox2.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Generation in Digits[eg.6]");
                        return;
                    }
                }
                //validation for OS
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Please Enter  product Operating System");
                    textBox3.BackColor = Color.LightPink;
                    return;
                }

                //validation for RAM
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Please Enter  product RAM");
                    textBox4.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    int ram;
                    if (!int.TryParse(textBox4.Text, out ram))
                    {
                        textBox4.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product RAM in Digits[eg.6]");
                        return;
                    }
                }

                //validation for CPU_manufacturer
                if (textBox6.Text == "")
                {
                    MessageBox.Show("Please Enter product CPU_Manufacturer");
                    textBox6.BackColor = Color.LightPink;
                    return;
                }

                //validation for Hard disk
                if (textBox5.Text == "")
                {
                    MessageBox.Show("Please Enter  product Hard Disk size");
                    textBox5.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    int hd;
                    if (!int.TryParse(textBox5.Text, out hd))
                    {
                        textBox5.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Hard Disk Size in Digits[eg.2]");
                        return;
                    }
                }

                //validation for screen size
                if (textBox7.Text == "")
                {
                    MessageBox.Show("Please Enter  product screen size");
                    textBox7.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    float sc;
                    if (!float.TryParse(textBox7.Text, out sc))
                    {
                        textBox7.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Screen Size in Digits[eg.15.5]");
                        return;
                    }
                }

                //validation for color
                if (textBox8.Text == "")
                {
                    MessageBox.Show("Please Enter  product Color");
                    textBox8.BackColor = Color.LightPink;
                    return;
                }

                //validation for item weight
                if (textBox9.Text == "")
                {
                    MessageBox.Show("Please Enter  product Weight");
                    textBox9.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    float we;
                    if (!float.TryParse(textBox9.Text, out we))
                    {
                        textBox9.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Weight in Digits[eg.3.2]");
                        return;
                    }
                }

                //validation for supplier name
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please Select Supplier Name");
                    comboBox1.BackColor = Color.LightPink;
                    return;
                }

                //validation for cpu speed
                if (textBox17.Text == "")
                {
                    MessageBox.Show("Please Enter cpu speed");
                    textBox17.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    float cp;
                    if (!float.TryParse(textBox17.Text, out cp))
                    {
                        textBox17.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product cpu speed in Digits[eg.3.2]");
                        return;
                    }
                }

                //validation for model no
                if (textBox10.Text == "")
                {
                    MessageBox.Show("Please Enter  product Model no");
                    textBox10.BackColor = Color.LightPink;
                    return;
                }

                //validation for processor type
                if (textBox11.Text == "")
                {
                    MessageBox.Show("Please Enter  product processor type");
                    textBox11.BackColor = Color.LightPink;
                    return;
                }

                //validation for purchase price
                if (textBox12.Text == "")
                {
                    MessageBox.Show("Please Enter  product purchase price");
                    textBox12.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    double pp;
                    if (!double.TryParse(textBox12.Text, out pp))
                    {
                        textBox12.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Purchase price in Digits[eg.30000]");
                        return;
                    }
                }

                //validation for selling price
                if (textBox13.Text == "")
                {
                    MessageBox.Show("Please Enter  product salling price");
                    textBox13.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    double sp;
                    if (!double.TryParse(textBox13.Text, out sp))
                    {
                        textBox13.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product salling price in Digits[eg.30000]");
                        return;
                    }
                }

                //validation for quantity
                if (textBox18.Text == "")
                {
                    MessageBox.Show("Please Enter  product quantity");
                    textBox18.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    int pq;
                    if (!int.TryParse(textBox18.Text, out pq))
                    {
                        textBox18.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Quantity in Digits[eg.30]");
                        return;
                    }
                }

                //insert data into database
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into computerstock values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox6.Text + "','" + textBox17.Text + "','" + comboBox1.Text + "','" + textBox18.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Computer Added in Stock Sucessfully");
                reset_field();
            }
            catch(Exception ei)
            {
                MessageBox.Show(ei.Message);
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                int i = dataGridView1.CurrentCell.RowIndex;
                textBox16.Text = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                textBox1.Text = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                textBox2.Text = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                textBox3.Text = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                textBox4.Text = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                textBox5.Text = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);
                textBox7.Text = Convert.ToString(dataGridView1.Rows[i].Cells[6].Value);
                textBox8.Text = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                textBox9.Text = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);
                textBox10.Text = Convert.ToString(dataGridView1.Rows[i].Cells[9].Value);
                textBox11.Text = Convert.ToString(dataGridView1.Rows[i].Cells[10].Value);
                textBox12.Text = Convert.ToString(dataGridView1.Rows[i].Cells[11].Value);
                textBox13.Text = Convert.ToString(dataGridView1.Rows[i].Cells[12].Value);
                textBox6.Text = Convert.ToString(dataGridView1.Rows[i].Cells[13].Value);
                textBox17.Text = Convert.ToString(dataGridView1.Rows[i].Cells[14].Value);
                comboBox1.Text = Convert.ToString(dataGridView1.Rows[i].Cells[15].Value);
                textBox18.Text = Convert.ToString(dataGridView1.Rows[i].Cells[16].Value);
            }
            catch(Exception e4)
            {
                MessageBox.Show(e4.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            try
            {
                //validation for Company name
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Enter  product Company name");
                    textBox1.BackColor = Color.LightPink;
                    return;
                }

                //validation for generation
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Please Enter  product Generation");
                    textBox2.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    int gi;
                    if (!int.TryParse(textBox2.Text, out gi))
                    {
                        textBox2.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Generation in Digits[eg.6]");
                        return;
                    }
                }
                //validation for OS
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Please Enter  product Operating System");
                    textBox3.BackColor = Color.LightPink;
                    return;
                }

                //validation for RAM
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Please Enter  product RAM");
                    textBox4.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    int ram;
                    if (!int.TryParse(textBox4.Text, out ram))
                    {
                        textBox4.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product RAM in Digits[eg.6]");
                        return;
                    }
                }

                //validation for CPU_manufacturer
                if (textBox6.Text == "")
                {
                    MessageBox.Show("Please Enter product CPU_Manufacturer");
                    textBox6.BackColor = Color.LightPink;
                    return;
                }

                //validation for Hard disk
                if (textBox5.Text == "")
                {
                    MessageBox.Show("Please Enter  product Hard Disk size");
                    textBox5.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    int hd;
                    if (!int.TryParse(textBox5.Text, out hd))
                    {
                        textBox5.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Hard Disk Size in Digits[eg.2]");
                        return;
                    }
                }

                //validation for screen size
                if (textBox7.Text == "")
                {
                    MessageBox.Show("Please Enter  product screen size");
                    textBox7.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    float sc;
                    if (!float.TryParse(textBox7.Text, out sc))
                    {
                        textBox7.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Screen Size in Digits[eg.15.5]");
                        return;
                    }
                }

                //validation for color
                if (textBox8.Text == "")
                {
                    MessageBox.Show("Please Enter  product Color");
                    textBox8.BackColor = Color.LightPink;
                    return;
                }

                //validation for item weight
                if (textBox9.Text == "")
                {
                    MessageBox.Show("Please Enter  product Weight");
                    textBox9.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    float we;
                    if (!float.TryParse(textBox9.Text, out we))
                    {
                        textBox9.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Weight in Digits[eg.3.2]");
                        return;
                    }
                }

                //validation for supplier name
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please Select Supplier Name");
                    comboBox1.BackColor = Color.LightPink;
                    return;
                }

                //validation for cpu speed
                if (textBox17.Text == "")
                {
                    MessageBox.Show("Please Enter cpu speed");
                    textBox17.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    float cp;
                    if (!float.TryParse(textBox17.Text, out cp))
                    {
                        textBox17.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product cpu speed in Digits[eg.3.2]");
                        return;
                    }
                }

                //validation for model no
                if (textBox10.Text == "")
                {
                    MessageBox.Show("Please Enter  product Model no");
                    textBox10.BackColor = Color.LightPink;
                    return;
                }

                //validation for processor type
                if (textBox11.Text == "")
                {
                    MessageBox.Show("Please Enter  product processor type");
                    textBox11.BackColor = Color.LightPink;
                    return;
                }

                //validation for purchase price
                if (textBox12.Text == "")
                {
                    MessageBox.Show("Please Enter  product purchase price");
                    textBox12.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    double pp;
                    if (!double.TryParse(textBox12.Text, out pp))
                    {
                        textBox12.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Purchase price in Digits[eg.30000]");
                        return;
                    }
                }

                //validation for selling price
                if (textBox13.Text == "")
                {
                    MessageBox.Show("Please Enter  product salling price");
                    textBox13.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    double sp;
                    if (!double.TryParse(textBox13.Text, out sp))
                    {
                        textBox13.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product salling price in Digits[eg.30000]");
                        return;
                    }
                }

                //validation for quantity
                if (textBox18.Text == "")
                {
                    MessageBox.Show("Please Enter  product quantity");
                    textBox18.BackColor = Color.LightPink;
                    return;
                }
                else
                {
                    int pq;
                    if (!int.TryParse(textBox18.Text, out pq))
                    {
                        textBox18.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter product Quantity in Digits[eg.30]");
                        return;
                    }
                }

                //update data
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update computerstock set company='" + textBox1.Text + "',generation='" + textBox2.Text + "',os='" + textBox3.Text + "',ram='" + textBox4.Text + "',hard_disk='" + textBox5.Text + "',screen_size='" + textBox7.Text + "',color='" + textBox8.Text + "',weight='" + textBox9.Text + "',model_no='" + textBox10.Text + "',processor_type='"+textBox11.Text+"',purchase_price='"+textBox12.Text+"',saling_price='"+textBox13.Text+"',cpu_manufac='"+textBox6.Text+"',cpu_speed='"+textBox17.Text+"',supplier_name='"+comboBox1.Text+"',quantity='"+textBox18.Text+"' where product_Id='"+textBox16.Text+"'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Computer updated succesfully");
                reset_field();
            }
            catch (Exception eu)
            {
                MessageBox.Show(eu.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Company")
            {
                comboBox3.Visible = true;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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
                comboBox3.Visible = false;
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText="select * from computerstock where company='"+comboBox3.SelectedItem+"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
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
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void comboBox8_SelectedIndexChanged_1(object sender, EventArgs e)
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
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
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception s3)
            {
                con.Close();
                MessageBox.Show(s3.Message);
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.BackColor = Color.White;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.BackColor = Color.White;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.BackColor = Color.White;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8.BackColor = Color.White;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox9.BackColor = Color.White;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.BackColor = Color.White;
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            textBox17.BackColor = Color.White;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox10.BackColor = Color.White;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox11.BackColor = Color.White;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            textBox12.BackColor = Color.White;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            textBox13.BackColor = Color.White;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            textBox18.BackColor = Color.White;
        }

    }
}
