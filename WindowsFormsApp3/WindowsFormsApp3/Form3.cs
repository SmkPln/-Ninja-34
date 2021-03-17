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
    public partial class Form3 : Form
    {
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 8.mdb;";

        private OleDbConnection myConnection;

        public Form3()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();

            textBox1.Text = "Іванов С. Р.";
            textBox1.ForeColor = Color.Gray;
        }

        //Закриття форми
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Видалити
        private void button1_Click_1(object sender, EventArgs e)
        {
            OleDbCommand command = myConnection.CreateCommand();
            command.CommandText = "DELETE * FROM Workers WHERE name = @c";

            command.Parameters.AddWithValue("@c", (textBox1.Text));
            command.ExecuteNonQuery();
        }

        //Вийти в меню
        private void button2_Click_1(object sender, EventArgs e)
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
    }
}
