using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace warehouseManagement
{
    public partial class Admin : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=inventorymain");
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=inventorymain";
            string query = "DELETE FROM inventoryrecord1";
            string selectQuery = "SELECT * FROM inventoryrecord1";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))

                {

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item deleted successfully");

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }



                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=inventorymain";
            string query = "UPDATE inventoryrecord1 SET ProductName=@ProductName, Quantity=@Quantity";
            string selectQuery = "SELECT * FROM inventoryrecord1";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        con.Open();

                        using (MySqlCommand updateCmd = new MySqlCommand(query, con))
                        {
                            updateCmd.Parameters.AddWithValue("@ProductName", this.textBox1.Text);
                            updateCmd.Parameters.AddWithValue("@Quantity", this.textBox2.Text);
                            updateCmd.Parameters.AddWithValue("@Price", this.textBox3.Text);


                            updateCmd.ExecuteNonQuery();
                            MessageBox.Show("Item updated successfully");
                        }

                        using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, con))
                        {
                            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectCmd))
                            {
                                DataTable dataTable = new DataTable();
                                dataAdapter.Fill(dataTable);
                                dataGridView1.DataSource = dataTable;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=inventorymain";
            string insertQuery = "INSERT INTO inventoryrecord1 (ProductName, Quantity, Price) VALUES (@ProductName, @Quantity, @Price)";
            string selectQuery = "SELECT * FROM inventoryrecord1";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {




                using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ProductName", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@Quantity", this.textBox2.Text);
                    cmd.Parameters.AddWithValue("@Price", this.textBox3.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item added successfully");
                }

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, con))
                {
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }


            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage mag = new Manage();
            mag.Show();
        }
    }
}
