using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
