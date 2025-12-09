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

namespace Моделирование_ПО
{
    public partial class Form2 : Form
    {
        private string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\cosmetic.mdb;";
        public Form2()
        {
            InitializeComponent();
            LoadProducts();
        }
        private void LoadProducts()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT Id, Name, Price FROM Products";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    comboBox1.DataSource = table;
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "Id";

                    comboBox1.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки товаров: " + ex.Message);
            }
        }
        private decimal GetPrice(int productId)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT Price FROM Products WHERE Id = @Id";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", productId);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    return Convert.ToDecimal(result);
                }
            }
            catch
            {
                return 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                int productId = (int)comboBox1.SelectedValue;
                decimal price = GetPrice(productId);
                label2.Text = price.ToString("C");
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Товар добавлен в корзину", "Успешно!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
         Form3 newForm = new Form3();
                newForm.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
