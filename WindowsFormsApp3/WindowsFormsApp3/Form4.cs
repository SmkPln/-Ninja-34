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
    public partial class Form4 : Form
    {
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 8.mdb;";

        private OleDbConnection myConnection;

        public Form4()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();

            textBox1.Text = "Ч або Ж";
            textBox1.ForeColor = Color.Black;

            OleDbCommand command = myConnection.CreateCommand();

            command.CommandText = "SELECT name FROM Workers";
            command.ExecuteNonQuery();

            OleDbDataReader reader3 = command.ExecuteReader();

            while (reader3.Read())
            {
                comboBox1.Items.Add(reader3["name"].ToString());
            }

            reader3.Close();
        }

        //Закриття форми
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Надіслати
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Ч або Ж")
            {
                MessageBox.Show("Введіть стать");
                return;
            }

            MessageBox.Show("Привітання відправлено");
        }

        //Вийти в меню
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        //Згенерувати
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Ч або Ж")
            {
                MessageBox.Show("Введіть стать");
                return;
            }
            
            OleDbCommand command = myConnection.CreateCommand();

            if (textBox1.Text == "Ч")
            {
                command.CommandText = "SELECT compliment1 FROM Congratulations WHERE sex = @c";

                command.Parameters.AddWithValue("@c", (textBox1.Text));
                command.ExecuteNonQuery();

                OleDbDataReader reader1 = command.ExecuteReader();

                listBox1.Items.Clear();

                while (reader1.Read())
                {
                    listBox1.Items.Add(reader1[0].ToString());
                }

                reader1.Close();
            }
            
            else if (textBox1.Text == "Ж")
            {
                command.CommandText = "SELECT compliment1 FROM Congratulations WHERE sex = @c";

                command.Parameters.AddWithValue("@c", (textBox1.Text));
                command.ExecuteNonQuery();

                OleDbDataReader reader1 = command.ExecuteReader();

                listBox1.Items.Clear();

                while (reader1.Read())
                {
                    listBox1.Items.Add(reader1[0].ToString());
                }

                reader1.Close();
            }

            command.CommandText = "SELECT compliment2 FROM Congratulations WHERE id_c = 1";
            command.ExecuteNonQuery();

            OleDbDataReader reader2 = command.ExecuteReader();

            while (reader2.Read())
            {
                textBox2.Text = reader2["compliment2"].ToString();
            }

            reader2.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Ч обо Ж")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ч або Ж";
                textBox1.ForeColor = Color.Black;
            }
        }
    }
}