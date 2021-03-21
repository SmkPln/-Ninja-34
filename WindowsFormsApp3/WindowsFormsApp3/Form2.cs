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
        }

        //Закриття форми
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Додати
        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == " .  . ")
            {
                MessageBox.Show("Введіть ПІП");
                return;
            }

            if (maskedTextBox2.Text == "  .  .2021")
            {
                MessageBox.Show("Введіть дату народження");
                return;
            }

            OleDbCommand command = myConnection.CreateCommand();
            command.CommandText = "INSERT INTO Workers (name, data) VALUES (@a, @b)";

            command.Parameters.AddWithValue("@a", (maskedTextBox1.Text));
            command.Parameters.AddWithValue("@b", (maskedTextBox2.Text));
            command.ExecuteNonQuery();

            MessageBox.Show("Працівника додано до списку");
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