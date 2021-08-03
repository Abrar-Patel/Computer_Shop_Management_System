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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            timer1.Start();
         /*   UserControlHome u = new UserControlHome();
            addcontrolstopanel(u);
       */
        }

        private void addcontrolstopanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControles.Controls.Clear();
            panelControles.Controls.Add(c);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string format = "dddddd";
            labelTime.Text = dt.ToLongTimeString();
            label4.Text = dt.ToShortDateString();
            label7.Text = dt.ToString(format);

       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*UserControlHome u = new UserControlHome();
            addcontrolstopanel(u);
       */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Quotation qo = new Quotation();
            qo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Saleproducts spo = new Saleproducts();
            spo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PurchaseOrder po = new PurchaseOrder();
            po.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Supplier so = new Supplier();
            so.Show();
        }

        private void Stock_Click(object sender, EventArgs e)
        {
            Addnewcomputer an = new Addnewcomputer();
            an.Show();
            
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Customer co1 = new Customer();
            co1.Show();
        }

        private void panelControles_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControles_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Reports ro = new Reports();
            ro.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Receipt_detail rd = new Receipt_detail();
            rd.Show();
        }
    }
}
