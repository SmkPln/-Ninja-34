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
    public partial class Form1 : Form
    {
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 8.mdb;";

        private OleDbConnection myConnection;

        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Згенерувати привітання
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        //Додати працівника
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        //Видалити працівника
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        //Переглянути список
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
            form5.Show();
        }

        //Вихід з програми
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Програма 'ППК Вітання'\n\n" +
                            "Керування програмою: Бреславець М. О.\n" +
                            "Розробка: Чередниченко С. Ю.\n" +
                            "Тестування: Козленко Д. Р.\n" +
                            "Керування випуском: Тур Д. О.\n" +
                            "Задоволення споживача: Куян О. В.\n" +
                            "Керування продуктом: Куян О. В.\n\n" +
                            "Програма створена для автоматизації привітання 'З Днем Народження' викладачів коледжу.\n\n" +
                            "'Згенерувати привітання' - кнопка генерації привітання.\n" +
                            "'Додати працівника' - додавання працівника коледжу.\n" +
                            "'Переглянути список' - список працівників коледжу.\n" +
                            "'Видалення працівника' - видалення працівника коледжу.\n" +
                            "'Вихід з програми' - вихід.\n");
        }
    }
}
