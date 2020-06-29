using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace Database
{
    public partial class Form3 : Form
    {

        public void deleteData()
        {
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        OracleParameter parm = new OracleParameter();
                        parm.OracleDbType = OracleDbType.Varchar2;
                        cmd.Parameters.Add("lastName", textBox1.Text);                      
                        cmd.CommandText = "DELETE FROM my_employee WHERE UPPER(last_name) = UPPER(:lastName)";
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader dr = cmd.ExecuteReader();

                        MessageBox.Show("Usunieto!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteData();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
