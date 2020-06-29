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
    public partial class Form2 : Form
    {

        public void addData()
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
                        cmd.Parameters.Add("id", textBox1.Text);
                        cmd.Parameters.Add("lastName", textBox2.Text);
                        cmd.Parameters.Add("firstName", textBox3.Text);
                        cmd.Parameters.Add("userId", textBox4.Text);
                        cmd.Parameters.Add("salary", textBox5.Text);
                        cmd.CommandText = "INSERT INTO my_employee VALUES(:id, :lastName, :firstName, :userId, :salary)";
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader dr = cmd.ExecuteReader();

                        MessageBox.Show("Dodano!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addData();
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }   
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
