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
    public partial class Form1 : Form
    {
        static string orad = "User Id=MSBD17;Password=bazy2020;Data Source=155.158.112.45:1521/oltpstud;";
        OracleParameter parm = new OracleParameter();

        public Form1()
        {
            InitializeComponent();
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(OracleConnection con = new OracleConnection(orad))
            {
                using(OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;
                        parm.OracleDbType = OracleDbType.Varchar2;
                        cmd.Parameters.Add("lastName", textBox1.Text);
                        cmd.CommandText = "select last_name, first_name, email from employees where" +
                            " UPPER(last_name) LIKE UPPER(:lastName)";
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader dr = cmd.ExecuteReader();
                        
                        if(dr == null || !dr.HasRows)
                        {
                            MessageBox.Show("Nie znaleziono!");
                            listBox1.Items.Clear();
                        }
                        else
                        {
                            while (dr.Read())
                            {
                                listBox1.Items.Clear();
                                listBox1.Items.Add("Nazwisko: " + dr.GetString(0));
                                listBox1.Items.Add("Imie: " + dr.GetString(1));
                                listBox1.Items.Add("Email: " + dr.GetString(2));
                                MessageBox.Show("Znaleziono!");
                            }
                        }

                        textBox1.SelectionStart = 0;
                        textBox1.SelectionLength = textBox1.Text.Length;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
