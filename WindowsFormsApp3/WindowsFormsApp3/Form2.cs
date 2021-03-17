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
    public partial class Form2 : Form
    {
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 8.mdb;";

        private OleDbConnection myConnection;

        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();

            textBox1.Text = "Іванов С. Р.";
            textBox2.Text = "20-02-2002";
            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
        }

        //Закриття форми
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Додати
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand command = myConnection.CreateCommand();
            command.CommandText = "INSERT INTO Workers (name, data) VALUES (@a, @b)";

            command.Parameters.AddWithValue("@a", (textBox1.Text));
            command.Parameters.AddWithValue("@b", (textBox2.Text));
            command.ExecuteNonQuery();
        }

        //Вийти в меню
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Іванов С. Р.")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Іванов С. Р.";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "20-02-2002")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "20-02-2002";
                textBox2.ForeColor = Color.Gray;
            }
        }
    }
}