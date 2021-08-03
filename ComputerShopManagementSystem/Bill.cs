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
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
        }
        private void reset_field()
        {
            this.Close();
            Bill bo1 = new Bill();
            bo1.Show();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hi\documents\visual studio 2013\Projects\ComputerShopManagementSystem\ComputerShopManagementSystem\computershop.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from bill";
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

        private void Bill_Load(object sender, EventArgs e)
        {
            display();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from sale where sale_Id=(select MAX(sale_Id) from sale)";
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
                cmd.CommandText = "select MAX(id) from bill";
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
                cmd.CommandText = "select distinct customer_name from bill";
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
                cmd.CommandText = "select distinct product_name from bill";
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
                cmd.CommandText = "select distinct product_model from bill";
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
                cmd.CommandText = "select distinct quantity from bill";
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
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView2.CurrentCell.RowIndex;
            textBox2.Text = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
            textBox3.Text = Convert.ToString(dataGridView2.Rows[i].Cells[3].Value);
            textBox4.Text = Convert.ToString(dataGridView2.Rows[i].Cells[5].Value);
            textBox5.Text = Convert.ToString(dataGridView2.Rows[i].Cells[6].Value);
            textBox6.Text = Convert.ToString(dataGridView2.Rows[i].Cells[8].Value);
            textBox7.Text = Convert.ToString(dataGridView2.Rows[i].Cells[9].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox2.Text=="")
                {
                    textBox2.BackColor = Color.White;
                    MessageBox.Show("Please sale Id");
                    return;
                }

                if (textBox3.Text == "")
                {
                    textBox3.BackColor = Color.White;
                    MessageBox.Show("Please Enter Customer Name");
                    return;
                }

                if (textBox4.Text == "")
                {
                    textBox4.BackColor = Color.White;
                    MessageBox.Show("please Computer company Name");
                    return;
                }

                if (textBox5.Text == "")
                {
                    textBox5.BackColor = Color.White;
                    MessageBox.Show("Please Enter Computer Model no");
                    return;
                }

                if (textBox6.Text == "")
                {
                    textBox6.BackColor = Color.White;
                    MessageBox.Show("Please Enter Selling price");
                    return;
                }

                if (textBox7.Text == "")
                {
                    textBox7.BackColor = Color.White;
                    MessageBox.Show("Please Enter Quantity");
                    return;
                }

                if (comboBox13.Text == "")
                {
                    comboBox13.BackColor = Color.LightPink;
                    MessageBox.Show("Please select GST");
                    return;
                }

                if (textBox11.Text == "")
                {
                    textBox11.BackColor = Color.White;
                    MessageBox.Show("Please Enter Discount");
                    return;
                }
                if (textBox10.Text == "")
                {
                    textBox10.BackColor = Color.White;
                    MessageBox.Show("Please Enter Total Amount");
                    return;
                }

                
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into bill values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + dateTimePicker1.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Bill Added Sucessfully");
                display();
                reset_field();
            }
            catch(Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset_field();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Customer Name")
            {
                comboBox1.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
            }
            if (comboBox2.SelectedItem == "Product Name")
            {
                comboBox1.Visible = false;
                comboBox3.Visible = true;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
            }
            if (comboBox2.SelectedItem == "Model No")
            {
                comboBox1.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = true;
                comboBox5.Visible = false;
            }
            if (comboBox2.SelectedItem == "Quantity")
            {
                comboBox1.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = true;
            }
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double p = Convert.ToDouble(textBox6.Text);
                int q = Convert.ToInt32(textBox7.Text);

                double pri = p * q;
                string gs = Convert.ToString(comboBox13.SelectedItem);
                string gs1 = gs.Trim('%');
                double gs2 = Convert.ToDouble(gs1);
                double amount = pri * gs2 / 100;
                textBox8.Text = Convert.ToString(amount);
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox11.BackColor = Color.White;
            try
            {
                double temp = 0;
                if (textBox11.Text == "")
                {
                    textBox11.Text = Convert.ToString(temp);
                }
                double p = Convert.ToDouble(textBox6.Text);
                int q = Convert.ToInt32(textBox7.Text);
                double np = p * q;
                double g = Convert.ToDouble(textBox8.Text);
                double dis = np + g;
                double dis1 = Convert.ToDouble(textBox11.Text);
                double disc = dis * dis1 / 100;
                textBox9.Text = Convert.ToString(disc);
                double ta = dis - disc;
                textBox10.Text = Convert.ToString(ta);
            }
            catch (Exception e7)
            {
                MessageBox.Show(e7.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from bill where customer_name='" + comboBox1.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception eb)
            {
                con.Close();
                MessageBox.Show(eb.Message);
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from bill where product_name='" + comboBox3.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception eb)
            {
                con.Close();
                MessageBox.Show(eb.Message);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from bill where quantity='" + comboBox5.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception eb)
            {
                con.Close();
                MessageBox.Show(eb.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from bill where product_model='" + comboBox4.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
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
