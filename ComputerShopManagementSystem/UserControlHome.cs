using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ComputerShopManagementSystem
{
    public partial class UserControlHome : UserControl
    {
        public UserControlHome()
        {
            InitializeComponent();
            timer1.Start();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hi\documents\visual studio 2013\Projects\ComputerShopManagementSystem\ComputerShopManagementSystem\computershop.mdf;Integrated Security=True;Connect Timeout=30");
        private void UserControlHome_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select quantity from computerstock where quantity > 0";
                SqlDataReader sdr = cmd.ExecuteReader();
                int i = 0;
                while (sdr.Read())
                {
                    i = i + Convert.ToInt32(sdr[0]);

                    label8.Text = Convert.ToString(i);

                }
                sdr.Dispose();
                con.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select quantity from sale where date='"+dateTimePicker1.Text+"' ";
                SqlDataReader sdr1 = cmd.ExecuteReader();
                int j = 0;
                while (sdr1.Read())
                {
                    j = j + Convert.ToInt32(sdr1[0].ToString());

                    label10.Text = Convert.ToString(j);

                }

                con.Close(); 
                sdr1.Dispose();
            }
            catch (Exception e1)
            {
                con.Close();
                MessageBox.Show(e1.Message);
               
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select count(Id) from quotation where date='"+dateTimePicker1.Text+"' ";
                SqlDataReader sdr2 = cmd.ExecuteReader();
                int k = 0;
                while (sdr2.Read())
                {
                    k = k + Convert.ToInt32(sdr2[0].ToString());

                    label12.Text = Convert.ToString(k);

                }

                con.Close();
                sdr2.Dispose();
            }
            catch (Exception e1)
            {
                con.Close();
                MessageBox.Show(e1.Message);

            }

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select purchase_price from sale where date='"+dateTimePicker1.Text+"'";
                SqlDataReader sdr3 = cmd.ExecuteReader();
                int pp = 0;
                while (sdr3.Read())
                {
                    pp = pp + Convert.ToInt32(sdr3[0]);

                }
                sdr3.Dispose();
                //cmd.CommandText = "select saling_price from sale where date='"+dateTimePicker1.Text+"'";
                //SqlDataReader sdr4 = cmd.ExecuteReader();
                //int sp = 0;
                //while (sdr4.Read())
                //{
                //    sp = sp + Convert.ToInt32(sdr4[0]);

                //}
                //sdr4.Dispose();
                cmd.CommandText = "select amount from bill where date='" + dateTimePicker1.Text + "'";
                SqlDataReader sdr5 = cmd.ExecuteReader();
                int am = 0;
                while (sdr5.Read())
                {
                    am = am + Convert.ToInt32(sdr5[0]);

                }
                sdr5.Dispose();
                int prf = am -  pp;
                label3.Text = Convert.ToString(prf);
                con.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                con.Close();
            }
        }
    }
}
