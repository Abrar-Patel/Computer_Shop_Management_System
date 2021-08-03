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
    public partial class Saleproducts : Form
    {
        public Saleproducts()
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
            Saleproducts so = new Saleproducts();
            so.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            reset_field();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    textBox2.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Customer Id");
                    return;
                }
                else
                {
                    int id1;
                    if (!int.TryParse(textBox2.Text, out id1))
                    {
                        textBox2.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter valid Customer Id");
                        return;
                    }
                }
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Customer Name");
                    return;
                }
                if (textBox4.Text == "")
                {
                    textBox4.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Product Id");
                    return;
                }
                else
                {
                    int id2;
                    if (!int.TryParse(textBox4.Text, out id2))
                    {
                        textBox4.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Valid product Id");
                        return;
                    }
                }
                if (textBox5.Text == "")
                {
                    textBox7.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter product Name");
                    return;
                }
                if (textBox6.Text == "")
                {
                    textBox6.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Model No");
                    return;
                }
                if (textBox9.Text == "")
                {
                    textBox9.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter quantity");
                    return;
                }
                else
                {
                    double p1;
                    if (!double.TryParse(textBox9.Text, out p1))
                    {
                        textBox9.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter valid Purchase price eg[30000]");
                        return;
                    }
                }
                if (textBox7.Text == "")
                {
                    textBox7.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter quantity");
                    return;
                }
                else
                {
                    double p2;
                    if (!double.TryParse(textBox7.Text, out p2))
                    {
                        textBox7.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter valid saling price eg[30000]");
                        return;
                    }
                }
                if(textBox8.Text=="")
               {
                  textBox8.BackColor = Color.LightPink;
                  MessageBox.Show("Please enter quantity");
                  return;
               }
                else
                {
                    int qu;
                    if (!int.TryParse(textBox8.Text, out qu))
                    {
                        textBox8.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter valid quantity eg[3]");
                        return;
                    }
                }
                int qu1,upq=0,i=0;
                qu1 = Convert.ToInt32(textBox8.Text);
                
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into sale values('" + dateTimePicker1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','"+textBox9.Text+"','" + textBox7.Text + "','" + textBox8.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                                
                try
                {
                    con.Open();
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "select quantity from computerstock where product_id='"+textBox4.Text+"'";
                    SqlDataReader sdr1 = cmd1.ExecuteReader();
                   
                    while (sdr1.Read())
                    {
                        i =  i + Convert.ToInt32(sdr1[0]);

                    }
                    sdr1.Dispose();
                    con.Close();
                }
                catch (Exception e4)
                {
                    MessageBox.Show(e4.Message);
                    con.Close();
                }
                upq = i - qu1;
                try
                {
                    con.Open();
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "update computerstock set quantity='" + upq + "' where product_id='" + textBox4.Text + "'";
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception eu)
                {
                    MessageBox.Show(eu.Message);
                }
                MessageBox.Show(" Product sales Sucessfully");
                this.Close();
                Bill bo = new Bill();
                bo.Show();
                
            }
            catch(Exception e2)
            {
                con.Close();
                MessageBox.Show(e2.Message);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void Saleproducts_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select MAX(sale_Id) from sale";
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
                cmd.CommandText = "select * from sale";
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
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct name  from customer";
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
                cmd.CommandText = "select distinct customer_name  from sale";
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
                cmd.CommandText = "select distinct product_name  from sale";
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
                cmd.CommandText = "select distinct model_no from sale";
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

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.computerstockTableAdapter.FillBy(this.computershopDataSet19.computerstock);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.BackColor = Color.White;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            textBox2.Text = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
            textBox3.Text = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView2.CurrentCell.RowIndex;
            textBox4.Text = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
            textBox5.Text = Convert.ToString(dataGridView2.Rows[i].Cells[1].Value);
            textBox6.Text = Convert.ToString(dataGridView2.Rows[i].Cells[9].Value);
            textBox9.Text = Convert.ToString(dataGridView2.Rows[i].Cells[11].Value);
            textBox7.Text = Convert.ToString(dataGridView2.Rows[i].Cells[12].Value);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8.BackColor = Color.White;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
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
                cmd.CommandText = "select * from computerstock where generation='" + gen + "'";
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
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (comboBox12.SelectedItem == "<20000")
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

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from sale where customer_name='" + comboBox16.Text + "'";
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
                cmd.CommandText = "select * from sale where product_name='" + comboBox18.Text + "'";
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
                cmd.CommandText = "select * from sale where model_no='" + comboBox19.Text + "'";
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from sale where date='" + dateTimePicker2.Text + "'";
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox9.BackColor = Color.White;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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
            catch (Exception es8)
            {
                MessageBox.Show(es8.Message);
            }
        }
    }
}
