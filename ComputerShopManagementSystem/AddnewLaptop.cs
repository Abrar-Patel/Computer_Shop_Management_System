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
    public partial class AddnewLaptop : Form
    {
        public AddnewLaptop()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hi\documents\visual studio 2013\Projects\ComputerShopManagementSystem\ComputerShopManagementSystem\computershop.mdf;Integrated Security=True;Connect Timeout=300000");
        private void display()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from laptopstock";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                sqa.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception e1)
            {
                con.Close();
                MessageBox.Show("Unable to connect with Database");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label19_Click(object sender, EventArgs e)
        {
         }

        private void AddnewLaptop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'computershopDataSet1.laptopstock' table. You can move, or remove it, as needed.
            this.laptopstockTableAdapter.Fill(this.computershopDataSet1.laptopstock);
            // TODO: This line of code loads data into the 'computershopDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.computershopDataSet.Supplier);
            //display();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select MAX(id) from laptopstock";
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
                        textBox16.Text = (Convert.ToInt64(sdr[0].ToString()) + 1).ToString();
                    }
                }
               con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                con.Close();
            }
            display();
        }

        private void reset_field()
        {
            this.Close();
            AddnewLaptop adnl = new AddnewLaptop();
            adnl.Show();
           // display();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            reset_field();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
