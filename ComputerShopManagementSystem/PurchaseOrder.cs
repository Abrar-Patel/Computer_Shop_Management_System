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
    public partial class PurchaseOrder : Form
    {
        public PurchaseOrder()
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
            PurchaseOrder po = new PurchaseOrder();
            po.Show();
        }
        public void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from purchase_order";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sqa = new SqlDataAdapter(cmd);
            sqa.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'computershopDataSet14.purchase_order' table. You can move, or remove it, as needed.
            this.purchase_orderTableAdapter.Fill(this.computershopDataSet14.purchase_order);
            // TODO: This line of code loads data into the 'computershopDataSet13.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter1.Fill(this.computershopDataSet13.Supplier);
            display();

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select MAX(id) from purchase_order ";
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string i = sdr[0].ToString();
                    if (i == "")
                    {
                        POpono.Text = "1";
                    }
                    else
                    {
                        POpono.Text = (Convert.ToInt64(sdr[0].ToString()) + 1).ToString();
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
                cmd.CommandText = "select distinct supplier_name  from purchase_order";
                SqlDataReader sdr1 = cmd.ExecuteReader();
                string i = "";
                while (sdr1.Read())
                {
                    i = Convert.ToString(sdr1[0]);
                    comboBox2.Items.Add(i);

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
                cmd.CommandText = "select distinct company_name  from Supplier";
                SqlDataReader sdrs = cmd.ExecuteReader();
                string i = "";
                while (sdrs.Read())
                {
                    i = Convert.ToString(sdrs[0]);
                    POsname.Items.Add(i);

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
                cmd.CommandText = "select distinct company  from purchase_order";
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
                MessageBox.Show(e4.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct generation from purchase_order";
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
                MessageBox.Show(e4.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct ram from purchase_order";
                SqlDataReader sdr3 = cmd.ExecuteReader();
                string i = "";
                while (sdr3.Read())
                {
                    i = Convert.ToString(sdr3[0]);
                    comboBox6.Items.Add(i);

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
                cmd.CommandText = "select distinct hard_disk from purchase_order";
                SqlDataReader sdr4 = cmd.ExecuteReader();
                string i = "";
                while (sdr4.Read())
                {
                    i = Convert.ToString(sdr4[0]);
                    comboBox7.Items.Add(i);

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
                cmd.CommandText = "select screen_size ram from purchase_order";
                SqlDataReader sdr5 = cmd.ExecuteReader();
                string i = "";
                while (sdr5.Read())
                {
                    i = Convert.ToString(sdr5[0]);
                    comboBox8.Items.Add(i);

                }
                sdr5.Dispose();
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
                cmd.CommandText = "select distinct processor from purchase_order";
                SqlDataReader sdr6 = cmd.ExecuteReader();
                string i = "";
                while (sdr6.Read())
                {
                    i = Convert.ToString(sdr6[0]);
                    comboBox9.Items.Add(i);

                }
                sdr6.Dispose();
                con.Close();
            }
            catch (Exception e4)
            {
                MessageBox.Show(e4.Message);
                con.Close();
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
            if (POsname.Text == "")
            {
                POsname.BackColor = Color.LightPink;
                MessageBox.Show("Please select Supplier name");
                return;
            }
            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.LightPink;
                MessageBox.Show("Please enter Company Name");
                return;
            }
            if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.LightPink;
                MessageBox.Show("Please enter Generation");
                return;
            }
            else
            {
                int g;
                if (!int.TryParse(textBox2.Text, out g))
                {
                    textBox2.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Generation in digits[eg.6]");
                    return;
                }
            }
            if (textBox3.Text == "")
            {
                textBox3.BackColor = Color.LightPink;
                MessageBox.Show("Please Enter RAM");
                return;
            }
            else
            {
                int r;
                if (!int.TryParse(textBox3.Text, out r))
                {
                    textBox3.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter RAM in digits[eg.12]");
                    return;
                }
            }
            if (textBox4.Text == "")
            {
                textBox4.BackColor = Color.LightPink;
                MessageBox.Show("Please enter Hard Disk Size");
                return;
            }
            else
            {
                int h;
                if (!int.TryParse(textBox4.Text, out h))
                {
                    textBox4.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Hard Disk Size in digits[eg.2]");
                    return;
                }
            }
            if (textBox5.Text == "")
            {
                textBox5.BackColor = Color.LightPink;
                MessageBox.Show("Please enter Screen Size");
                return;
            }
            else
            {
                float s;
                if (!float.TryParse(textBox5.Text, out s))
                {
                    textBox5.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter screen size in digits[eg.15.5]");
                    return;
                }
            }
            if (textBox6.Text == "")
            {
                textBox6.BackColor = Color.LightPink;
                MessageBox.Show("Please enter Processor type");
                return;
            }
            if (textBox10.Text == "")
            {
                textBox10.BackColor = Color.LightPink;
                MessageBox.Show("Please enter Quantity");
                return;
            }
            else
            {
                int qu;
                if (!int.TryParse(textBox10.Text, out qu))
                {
                    textBox10.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Quantity in digits[eg.2]");
                    return;
                }
            }
            if (textBox11.Text == "")
            {
                textBox11.BackColor = Color.LightPink;
                MessageBox.Show("Please enter Price");
                return;
            }
            else
            {
                long pr;
                if (!long.TryParse(textBox11.Text, out pr))
                {
                    textBox11.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Price in digits[eg.25000]");
                    return;
                }
            }
            if (comboBox1.Text == "")
            {
                comboBox1.BackColor = Color.LightPink;
                MessageBox.Show("Please select GST");
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
                double tpr;
                if (!double.TryParse(textBox13.Text, out tpr))
                {
                    textBox13.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter Total Price in digits[eg.25000]");
                    return;
                }
            }
            
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into purchase_order values('" + POsname.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + POodate.Text + "','" + POrdate.Text + "' )";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Purchase Order Added succesfully");
                reset_field();
            
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
         
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            POpono.Text = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
            POsname.Text = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
            textBox1.Text = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
            textBox3.Text = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
            textBox4.Text = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);
            textBox5.Text = Convert.ToString(dataGridView1.Rows[i].Cells[6].Value);
            textBox6.Text = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
            textBox10.Text = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);
            textBox11.Text = Convert.ToString(dataGridView1.Rows[i].Cells[9].Value);
            textBox12.Text = Convert.ToString(dataGridView1.Rows[i].Cells[10].Value);
            textBox13.Text = Convert.ToString(dataGridView1.Rows[i].Cells[11].Value);
            POodate.Text = Convert.ToString(dataGridView1.Rows[i].Cells[12].Value);
            POrdate.Text = Convert.ToString(dataGridView1.Rows[i].Cells[13].Value);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (POsname.Text == "")
                {
                    POsname.BackColor = Color.LightPink;
                    MessageBox.Show("Please select Supplier name");
                    return;
                }
                if (textBox1.Text == "")
                {
                    textBox1.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Company Name");
                    return;
                }
                if (textBox2.Text == "")
                {
                    textBox2.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Generation");
                    return;
                }
                else
                {
                    int g;
                    if (!int.TryParse(textBox2.Text, out g))
                    {
                        textBox2.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Generation in digits[eg.6]");
                        return;
                    }
                }
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = Color.LightPink;
                    MessageBox.Show("Please Enter RAM");
                    return;
                }
                else
                {
                    int r;
                    if (!int.TryParse(textBox3.Text, out r))
                    {
                        textBox3.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter RAM in digits[eg.12]");
                        return;
                    }
                }
                if (textBox4.Text == "")
                {
                    textBox4.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Hard Disk Size");
                    return;
                }
                else
                {
                    int h;
                    if (!int.TryParse(textBox4.Text, out h))
                    {
                        textBox4.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Hard Disk Size in digits[eg.2]");
                        return;
                    }
                }
                if (textBox5.Text == "")
                {
                    textBox5.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Screen Size");
                    return;
                }
                else
                {
                    float s;
                    if (!float.TryParse(textBox5.Text, out s))
                    {
                        textBox5.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter screen size in digits[eg.15.5]");
                        return;
                    }
                }
                if (textBox6.Text == "")
                {
                    textBox6.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Processor type");
                    return;
                }
                if (textBox10.Text == "")
                {
                    textBox10.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Quantity");
                    return;
                }
                else
                {
                    int qu;
                    if (!int.TryParse(textBox10.Text, out qu))
                    {
                        textBox10.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Quantity in digits[eg.2]");
                        return;
                    }
                }
                if (textBox11.Text == "")
                {
                    textBox11.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter Price");
                    return;
                }
                else
                {
                    double pr;
                    if (!double.TryParse(textBox11.Text, out pr))
                    {
                        textBox11.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Price in digits[eg.25000]");
                        return;
                    }
                }
                if (comboBox1.Text == "")
                {
                    comboBox1.BackColor = Color.LightPink;
                    MessageBox.Show("Please select GST");
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
                    double tpr;
                    if (!double.TryParse(textBox13.Text, out tpr))
                    {
                        textBox13.BackColor = Color.LightPink;
                        MessageBox.Show("Please Enter Total Price in digits[eg.25000]");
                        return;
                    }
                }

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update purchase_order set supplier_name='" + POsname.Text + "',company='" + textBox1.Text + "',generation='" + textBox2.Text + "',ram='" + textBox3.Text + "',hard_disk='" + textBox4.Text + "',screen_size='" + textBox5.Text + "',processor='" + textBox6.Text + "',quantity='" + textBox10.Text + "',price='" + textBox11.Text + "',GST='" + textBox12.Text + "',total_amount='" + textBox13.Text + "',order_date='" + POodate.Text + "',req_date='" + POrdate.Text + "' where Id='"+POpono.Text+"'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Purchase Order updated succesfully");
                reset_field();
            }
            catch(Exception eu)
            {
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
                cmd.CommandText = "delete  from purchase_order where Id='" + POpono.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Purchase Order removed succesfully");
                reset_field();
            }
            catch (Exception eu)
            {
                MessageBox.Show(eu.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.BackColor = Color.White;
            try
            {
                double p = Convert.ToDouble(textBox11.Text);
                int q = Convert.ToInt32(textBox10.Text);

                double pri = p * q;
                string gs = Convert.ToString(comboBox1.SelectedItem);
                string gs1 = gs.Trim('%');
                double gs2 = Convert.ToDouble(gs1);
                double amount = pri * gs2 / 100;
                textBox12.Text = Convert.ToString(amount);
                double ta;
                ta=pri+amount;
                textBox13.Text = Convert.ToString(ta);
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.SelectedItem == "Supplier Name")
            {
                comboBox2.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
            }

            if (comboBox13.SelectedItem == "Company")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = true;
                comboBox4.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

            }

            if (comboBox13.SelectedItem == "Generation")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = true;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

            }
            if (comboBox13.SelectedItem == "RAM")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox6.Visible = true;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

            }
            if (comboBox13.SelectedItem == "Hard Disk")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = true;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

            }
            if (comboBox13.SelectedItem == "Screen Size")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = true;
                comboBox9.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

            }
            if (comboBox13.SelectedItem == "Processor type")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = true;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

            }
            if (comboBox13.SelectedItem == "Order Date")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = false;
            }
            if (comboBox13.SelectedItem == "Require Date")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = true;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from purchase_order where supplier_name='" + comboBox2.Text + "'";
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from purchase_order where company='" + comboBox3.Text + "'";
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from purchase_order where generation='" + comboBox4.Text + "'";
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
                cmd.CommandText = "select * from purchase_order where ram='" + comboBox6.Text + "'";
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
                cmd.CommandText = "select * from purchase_order where hard_disk='" + comboBox7.Text + "'";
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
                cmd.CommandText = "select * from purchase_order where screen_size='" + comboBox8.Text + "'";
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
                cmd.CommandText = "select * from purchase_order where processor='" + comboBox9.Text + "'";
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from purchase_order where order_date='" + dateTimePicker1.Text + "'";
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from purchase_order where req_date='" + dateTimePicker2.Text + "'";
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

        private void POsname_SelectedIndexChanged(object sender, EventArgs e)
        {
            POsname.BackColor = Color.White;
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.BackColor = Color.White;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.BackColor = Color.White;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox10.BackColor = Color.White;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox11.BackColor = Color.White;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            textBox13.BackColor = Color.White;
        }
    }
}
