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
    public partial class Quotation : Form
    {
        public Quotation()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hi\documents\visual studio 2013\Projects\ComputerShopManagementSystem\ComputerShopManagementSystem\computershop.mdf;Integrated Security=True;Connect Timeout=30");
        private void reset_field()
        {
            this.Close();
            Quotation qo = new Quotation();
            qo.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Quotation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'computershopDataSet23.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter1.Fill(this.computershopDataSet23.customer);
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
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select MAX(id) from quotation";
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string i = sdr[0].ToString();
                    if (i == "")
                    {
                        textBox3.Text = "1";
                    }
                    else
                    {
                        textBox3.Text = (Convert.ToInt64(sdr[0].ToString()) + 1).ToString();
                    }
                }
                sdr.Dispose();
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
                cmd.CommandText = "select * from customer";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
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
                cmd.CommandText = "select * from computerstock where quantity>0";
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
                cmd.CommandText = "select * from quotation";
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
            try{
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct name from customer";
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
                MessageBox.Show(e4.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct company  from computerstock where quantity>0";
                SqlDataReader sdr2 = cmd.ExecuteReader();
                string i = "";
                while (sdr2.Read())
                {
                    i = Convert.ToString(sdr2[0]);
                    comboBox3.Items.Add(i);

                }
                sdr2.Dispose();
                con.Close();
            }
            catch (Exception e5)
            {
                MessageBox.Show(e5.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct generation  from computerstock where quantity>0";
                SqlDataReader sdr3 = cmd.ExecuteReader();
                string i = "";
                while (sdr3.Read())
                {
                    i = Convert.ToString(sdr3[0]);
                    comboBox4.Items.Add(i);

                }
                sdr3.Dispose();
                con.Close();
            }
            catch (Exception e5)
            {
                MessageBox.Show(e5.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct os from computerstock where quantity>0";
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
            catch (Exception e6)
            {
                MessageBox.Show(e6.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct ram from computerstock where quantity>0";
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
            catch (Exception e7)
            {
                MessageBox.Show(e7.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct hard_disk from computerstock where quantity>0";
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
            catch (Exception e7)
            {
                MessageBox.Show(e7.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct screen_size from computerstock where quantity>0";
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
            catch (Exception e7)
            {
                MessageBox.Show(e7.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct color from computerstock where quantity>0";
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
            catch (Exception e8)
            {
                MessageBox.Show(e8.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct weight from computerstock where quantity>0";
                SqlDataReader sdr9 = cmd.ExecuteReader();
                string i = "";
                while (sdr9.Read())
                {
                    i = Convert.ToString(sdr9[0]);
                    comboBox10.Items.Add(i);

                }
                sdr9.Dispose();
                con.Close();
            }
            catch (Exception e8)
            {
                MessageBox.Show(e8.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct processor_type from computerstock where quantity>0";
                SqlDataReader sdr10 = cmd.ExecuteReader();
                string i = "";
                while (sdr10.Read())
                {
                    i = Convert.ToString(sdr10[0]);
                    comboBox11.Items.Add(i);

                }
                sdr10.Dispose();
                con.Close();
            }
            catch (Exception e8)
            {
                MessageBox.Show(e8.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct quantity from computerstock where quantity>0";
                SqlDataReader sdr11 = cmd.ExecuteReader();
                string i = "";
                while (sdr11.Read())
                {
                    i = Convert.ToString(sdr11[0]);
                    comboBox17.Items.Add(i);

                }
                sdr11.Dispose();
                con.Close();
            }
            catch (Exception e9)
            {
                MessageBox.Show(e9.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct customer_name  from quotation";
                SqlDataReader sdr12 = cmd.ExecuteReader();
                string i = "";
                while (sdr12.Read())
                {
                    i = Convert.ToString(sdr12[0]);
                    comboBox16.Items.Add(i);

                }
                sdr12.Dispose();
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
                cmd.CommandText = "select distinct product_name  from quotation";
                SqlDataReader sdr13 = cmd.ExecuteReader();
                string i = "";
                while (sdr13.Read())
                {
                    i = Convert.ToString(sdr13[0]);
                    comboBox18.Items.Add(i);

                }
                sdr13.Dispose();
                con.Close();
            }
            catch (Exception e5)
            {
                MessageBox.Show(e5.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct model_no from quotation";
                SqlDataReader sdr14 = cmd.ExecuteReader();
                string i = "";
                while (sdr14.Read())
                {
                    i = Convert.ToString(sdr14[0]);
                    comboBox19.Items.Add(i);

                }
                sdr14.Dispose();
                con.Close();
            }
            catch (Exception e5)
            {
                MessageBox.Show(e5.Message);
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset_field();
        }

       
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            textBox4.Text = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
            textBox5.Text = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView2.CurrentCell.RowIndex;
            textBox6.Text = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
            textBox7.Text = Convert.ToString(dataGridView2.Rows[i].Cells[1].Value);
            textBox8.Text = Convert.ToString(dataGridView2.Rows[i].Cells[9].Value);
            textBox9.Text = Convert.ToString(dataGridView2.Rows[i].Cells[12].Value);       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "")
                {
                    textBox4.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Customer Id");
                    return;
                }
                else
                {
                    int id1;
                    if (!int.TryParse(textBox4.Text, out id1))
                    {
                        textBox4.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter valid Customer Id");
                        return;
                    }
                }
                if (textBox5.Text == "")
                {
                    textBox5.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Customer Name");
                    return;
                }
                if (textBox6.Text == "")
                {
                    textBox6.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Product Id");
                    return;
                }
                else
                {
                    int id2;
                    if (!int.TryParse(textBox6.Text, out id2))
                    {
                        textBox6.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Valid product Id");
                        return;
                    }
                }
                if (textBox7.Text == "")
                {
                    textBox7.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter product Name");
                    return;
                }
                if (textBox8.Text == "")
                {
                    textBox8.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Model No");
                    return;
                }
                if (textBox9.Text == "")
                {
                    textBox9.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter price");
                    return;
                }
                else
                {
                    double money;
                    if (!double.TryParse(textBox9.Text, out money))
                    {
                        textBox9.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter valid Price eg[25000]");
                        return;
                    }
                }
                if (textBox10.Text == "")
                {
                    textBox10.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Quantity");
                    return;
                }
                else
                {
                    int q;
                    if (!int.TryParse(textBox10.Text, out q))
                    {
                        textBox10.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter valid Quantity eg[5]");
                        return;
                    }
                }
                if (comboBox14.Text == "")
                {
                    comboBox14.BackColor = Color.LightPink;
                    MessageBox.Show("Please select GST");
                    return;
                }
                if (textBox1.Text == "")
                {
                    textBox1.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Discount ");
                    return;
                }
                if (textBox13.Text == "")
                {
                    textBox13.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Total Amount");
                    return;
                }
                else
                {
                    double money1;
                    if (!double.TryParse(textBox13.Text, out money1))
                    {
                        textBox13.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter valid Total amount eg.[50000]");
                        return;
                    }
                }
                //insert data into database
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into quotation values('" + dateTimePicker1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Quotation Added succesfully");
                reset_field();
            }
            catch(Exception ei)
            {
                MessageBox.Show(ei.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customer where name='"+comboBox1.Text+"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where company='" + comboBox3.Text + "'";
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
        }*/

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
                comboBox17.Visible = false;
            }
            if (comboBox2.SelectedItem == "Generation")
            {
                comboBox4.Visible = true;
                comboBox3.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox17.Visible = false;
            }
            if (comboBox2.SelectedItem == "OS")
            {
                comboBox5.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox17.Visible = false;
            }
            if (comboBox2.SelectedItem == "RAM")
            {
                comboBox6.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox17.Visible = false;
            }
            if (comboBox2.SelectedItem == "Hard Disk")
            {
                comboBox7.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox17.Visible = false;
            }
            if (comboBox2.SelectedItem == "Screen Size")
            {
                comboBox8.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox17.Visible = false;
            }
            if (comboBox2.SelectedItem == "Color")
            {
                comboBox9.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox17.Visible = false;
            }
            if (comboBox2.SelectedItem == "Weight")
            {
                comboBox10.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox17.Visible = false;
            }
            if (comboBox2.SelectedItem == "Processor type")
            {
                comboBox11.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox12.Visible = false;
                comboBox17.Visible = false;
            }
            if (comboBox2.SelectedItem == "Quantity")
            {
                comboBox17.Visible = true;
                comboBox11.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox12.Visible = false;
            }
            if (comboBox2.SelectedItem == "price")
            {
                comboBox12.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox17.Visible = false;
            }
                  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customer where name='" + comboBox1.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox14.BackColor = Color.White;
            try
            {
                double p = Convert.ToDouble(textBox9.Text);
                int q = Convert.ToInt32(textBox10.Text);

                double pri = p * q;
                string gs = Convert.ToString(comboBox14.SelectedItem);
                string gs1 = gs.Trim('%');
                double gs2 = Convert.ToDouble(gs1);
                double amount = pri * gs2 / 100;
                textBox11.Text = Convert.ToString(amount);
            }
            catch(Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where company='" + comboBox3.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch(Exception es1)
            {
                MessageBox.Show(es1.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int gen = Convert.ToInt32(comboBox4.Text);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where generation='" + gen+ "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception es2)
            {
                MessageBox.Show(es2.Message);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where os='" + comboBox5.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception es3)
            {
                MessageBox.Show(es3.Message);
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where ram='" + comboBox6.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception es4)
            {
                MessageBox.Show(es4.Message);
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where hard_disk='" + comboBox7.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception es5)
            {
                MessageBox.Show(es5.Message);
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where screen_size='" + comboBox8.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception es5)
            {
                MessageBox.Show(es5.Message);
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where color='" + comboBox9.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception es6)
            {
                MessageBox.Show(es6.Message);
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where weight='" + comboBox10.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception es7)
            {
                MessageBox.Show(es7.Message);
            }
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where processor_type='" + comboBox11.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception es7)
            {
                MessageBox.Show(es7.Message);
            }
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from computerstock where quantity='" + comboBox17.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception es8)
            {
                MessageBox.Show(es8.Message);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from quotation where date='" + dateTimePicker2.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();
            }
            catch (Exception es8)
            {
                MessageBox.Show(es8.Message);
            }
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from quotation where customer_name='" + comboBox16.Text + "'";
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

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from quotation where product_name='" + comboBox18.Text + "'";
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

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from quotation where model_no='" + comboBox19.Text + "'";
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox9.BackColor = Color.White;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double temp1 = 0;
                if (textBox10.Text == "")
                {
                    textBox10.Text = Convert.ToString(temp1);
                }
                textBox10.BackColor = Color.White;
                double baa = Convert.ToDouble(textBox9.Text);
                double q1 = Convert.ToDouble(textBox10.Text);
                double p1 = baa * q1;
                textBox2.Text = Convert.ToString(p1);
            }
            catch(Exception ed)
            {
                MessageBox.Show(ed.Message);
            }
         }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            textBox13.BackColor = Color.White;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            try
            {
                double temp = 0;
                if (textBox1.Text == "")
                {
                    textBox1.Text = Convert.ToString(temp);
                }
                double p = Convert.ToDouble(textBox9.Text);
                int q = Convert.ToInt32(textBox10.Text);
                double np = p * q;
                double g = Convert.ToDouble(textBox11.Text);
                double dis = np + g;
                double dis1 = Convert.ToDouble(textBox1.Text);
                double disc = dis * dis1 / 100;
                textBox12.Text = Convert.ToString(disc);
                double ta = dis - disc;
                textBox13.Text = Convert.ToString(ta);
            }
            catch(Exception e7)
            {
                MessageBox.Show(e7.Message);
            }
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                                
                if(comboBox12.SelectedItem=="<20000")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from computerstock where saling_price<='20000' and quantity>0";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                    sqa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                if (comboBox12.SelectedItem == "20000-25000")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from computerstock where saling_price>='20000' and saling_price<='25000' and quantity>0";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                    sqa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                if (comboBox12.SelectedItem == "25000-30000")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from computerstock where saling_price>='25000' and saling_price<='30000' and quantity>0";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                    sqa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                if (comboBox12.SelectedItem == "30000-35000")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from computerstock where saling_price>='30000' and saling_price<='35000' and quantity>0";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                    sqa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                if (comboBox12.SelectedItem == "35000-40000")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from computerstock where saling_price>='35000' and saling_price<='40000' and quantity>0";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                    sqa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                if (comboBox12.SelectedItem == "40000-45000")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from computerstock where saling_price>='40000' and saling_price<='45000' and quantity>0";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                    sqa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                if (comboBox12.SelectedItem == "45000-50000")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from computerstock where saling_price>='45000' and saling_price<='50000' and quantity>0";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                    sqa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                if (comboBox12.SelectedItem == ">50000")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from computerstock where saling_price>='50000' and quantity>0";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                    sqa.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.SelectedItem == "Customer Name")
            {
                comboBox16.Visible = true;
                comboBox18.Visible = false;
                comboBox19.Visible = false;
                dateTimePicker2.Visible = false;
            }
            if (comboBox13.SelectedItem == "Company Name")
            {
                comboBox16.Visible = false;
                comboBox18.Visible = true;
                comboBox19.Visible = false;
                dateTimePicker2.Visible = false;
            }
            if (comboBox13.SelectedItem == "Model No")
            {
                comboBox16.Visible = false;
                comboBox18.Visible = false;
                comboBox19.Visible = true;
                dateTimePicker2.Visible = false;
            }
            if (comboBox13.SelectedItem == "Date")
            {
                dateTimePicker2.Visible = true;
                comboBox16.Visible = false;
                comboBox18.Visible = false;
                comboBox19.Visible = false;

            }
        }
    }
}
