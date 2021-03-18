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
        }

        //Закриття форми
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Видалити
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == " ,  , ")
            {
                MessageBox.Show("Введіть ПІП");
                return;
            }

            OleDbCommand command = myConnection.CreateCommand();
            command.CommandText = "DELETE * FROM Workers WHERE name = @c";

            command.Parameters.AddWithValue("@c", (maskedTextBox1.Text));
            command.ExecuteNonQuery();

            MessageBox.Show("Працівника видалено зі списку");
        }

        //Вийти в меню
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
