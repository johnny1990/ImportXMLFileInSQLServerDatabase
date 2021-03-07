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


    }
}
