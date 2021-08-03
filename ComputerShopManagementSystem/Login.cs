using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerShopManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //validation for uusername
            if (Luname.Text == "")
            {
                Luname.BackColor = Color.LightPink;
                MessageBox.Show("UserName required");
                return;
            }
            if (Lpass.Text == "")
            {
                Lpass.BackColor = Color.LightPink;
                MessageBox.Show("Password required");
                return;

            }

            if ((Luname.Text == "Admin") && (Lpass.Text == "Admin"))
            {

                Menu f = new Menu();
                f.Show();
                this.Hide();
            }
            //else
            //{
            //    MessageBox.Show("Invalid UserName or Password");
            //    Luname.Clear();
            //    Lpass.Clear();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Luname.Clear();
            Lpass.Clear();
        }

        private void Luname_TextChanged(object sender, EventArgs e)
        {
            Luname.BackColor = Color.White;
        }

        private void Lpass_TextChanged(object sender, EventArgs e)
        {
            Lpass.BackColor = Color.White;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Lpass.UseSystemPasswordChar = false;
            if (checkBox1.Checked ==false)
                Lpass.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

        }
    }
}
