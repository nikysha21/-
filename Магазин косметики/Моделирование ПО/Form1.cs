using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;

namespace Моделирование_ПО
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string login = richTextBox1.Text;
            string password = richTextBox2.Text;

            if (login == "" || password == "")
            {
                MessageBox.Show("Введите логин и пароль!", "Внимание!");
                return;
            }

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\окончательный вариант системы\\password.mdb";

            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            try
            {
                dbConnection.Open();

                string query = "SELECT COUNT(*) FROM [password] WHERE [Логин] = '" + login + "' AND [Пароль] = '" + password + "'";

                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                int count = Convert.ToInt32(dbCommand.ExecuteScalar());

                if (count > 0)
                {
                    Form2 newForm = new Form2();
                    newForm.Show();
                    this.Hide();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Неправильно введен логин или пароль! Хотите зарегистрироваться?", "Внимание!",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Данная функция пока недоступна", "Внимание!");
                    }
                    else
                    {
                        MessageBox.Show("Проверьте корректность введенных данных", "Внимание!");
                    }
                }

                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message, "Ошибка!");
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
            }
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        //добавление 4-ой формы
        {
            Form4 newForm = new Form4();
            newForm.Show();

        }

    }
}

