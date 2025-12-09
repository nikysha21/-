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
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace Моделирование_ПО
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = richTextBox4.Text;
            string password = richTextBox1.Text;
            string fio = richTextBox3.Text;
            string email = richTextBox5.Text;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Колледж\\окончательный вариант системы\\reg.mdb";

            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            try
            {
                dbConnection.Open();

                string query = "INSERT INTO Clients (Login, [Password], FIO, Email) " +
                               "VALUES ('" + login + "', '" + password + "', '" + fio + "', '" + email + "')";


                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);


                if (dbCommand.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Ошибка выполнения запроса!", "Внимание!");
                }
                else
                {
                    MessageBox.Show("Данные успешно добавлены!", "Успех!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {

                dbConnection.Close();
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
