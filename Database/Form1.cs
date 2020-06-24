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
        public void searchName()
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
                        cmd.CommandText = "select last_name, first_name, salary from my_employee where" +
                            " UPPER(last_name) LIKE UPPER(:lastName)";
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader dr = cmd.ExecuteReader();

                        if (dr == null || !dr.HasRows)
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
                                listBox1.Items.Add("Pensja: " + dr.GetInt32(2));
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

        public Form1()
        {
            InitializeComponent();
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchName();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            var newForm = new Form2();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var newForm = new Form3();
            newForm.Show();
        }
    }
}
