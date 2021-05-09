using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CrudXMLServiceReference.CrudXMLServiceClient srv = new CrudXMLServiceReference.CrudXMLServiceClient();
                srv.InsertUserDetails();
                MessageBox.Show("Xml inserted succesfully!!!!!");
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {              
                CrudXMLServiceReference.CrudXMLServiceClient srv = new CrudXMLServiceReference.CrudXMLServiceClient();
                dataGridView1.DataSource = srv.GetUserDetails().CustomersTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                int customerId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string name = dataGridView1.CurrentRow.Cells[1].Value.ToString(); 
                string country = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string country = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (customerId != 0)
            {
                       CrudXMLServiceReference.CrudXMLServiceClient client = new CrudXMLServiceReference.CrudXMLServiceClient();
                       client.UpdateCustomer(customerId, name, country);
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this customer?", "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                int customerId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (customerId != 0)
                {
                    CrudXMLServiceReference.CrudXMLServiceClient client = new CrudXMLServiceReference.CrudXMLServiceClient();
                    client.DeleteCustomer(customerId);
                }


            }
        }
    }
}
