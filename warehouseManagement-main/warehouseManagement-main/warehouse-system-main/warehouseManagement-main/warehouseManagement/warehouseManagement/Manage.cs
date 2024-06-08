using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace warehouseManagement
{
    public partial class Manage : Form
    {
        public Manage()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=register";
            string insertQuery = "INSERT INTO record (FIRSTNAME, LASTNAME, DOB, USERNAME, PASSWORD) VALUES (@FIRSTNAME, @LASTNAME, @DOB, @USERNAME, @PASSWORD)";
            string selectQuery = "SELECT * FROM record";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(selectQuery, con))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }


            }

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {


                using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@FIRSTNAME", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@LASTNAME", this.textBox2.Text);
                    cmd.Parameters.AddWithValue("@DOB", this.dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@USERNAME", this.textBox4.Text);
                    cmd.Parameters.AddWithValue("@PASSWORD", this.textBox5.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item added successfully");


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
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=register";
            string query = "DELETE FROM record";
            string selectQuery = "SELECT * FROM record";

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
            string connectionString = "server=localhost;user id=root;password=;database=register";
            string query = "UPDATE INTO record (FIRSTNAME, LASTNAME, DOB, USERNAME, PASSWORD) VALUES (@FIRSTNAME, @LASTNAME, @DOB, @USERNAME, @PASSWORD)";
            string selectQuery = "SELECT * FROM record";


            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        con.Open();

                        using (MySqlCommand updateCmd = new MySqlCommand(query, con))
                        {
                            updateCmd.Parameters.AddWithValue("@FIRSTNAME", this.textBox1.Text);
                            updateCmd.Parameters.AddWithValue("@LASTNAME", this.textBox2.Text);
                            updateCmd.Parameters.AddWithValue("@DOB", this.dateTimePicker1.Text);
                            updateCmd.Parameters.AddWithValue("@USERNAME", this.textBox4.Text);
                            updateCmd.Parameters.AddWithValue("@PASSWORD", this.textBox5.Text);


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
    }
}