using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form5 : Form
    {
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 8.mdb;";

        private OleDbConnection myConnection;

        public Form5()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }

        //Закриття форми
        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Переглянути
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Workers";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            OleDbDataReader reader = command.ExecuteReader();

            listBox1.Items.Clear();

            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString() + "  " + reader[1].ToString() + "  " + reader[2].ToString() + "  ");
            }

            reader.Close();
        }

        //Вийти в меню
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
