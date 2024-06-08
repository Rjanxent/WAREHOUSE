using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace warehouseManagement
{
    public partial class Register : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        

        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.Icon = null;
            this.BackgroundImageLayout = ImageLayout.Stretch; //stretches background image
            
            //makes background colors transparent on labels, images, and etc.
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            checkBox2.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent; 
            linkLabel1.BackColor = Color.Transparent;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=register";
            string insertQuery = "INSERT INTO record (FIRSTNAME, LASTNAME, DOB, USERNAME, PASSWORD) VALUES (@FIRSTNAME, @LASTNAME, @DOB, @USERNAME, @PASSWORD)";
            string selectQuery = "SELECT * FROM record";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {




                using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@FIRSTNAME", this.textBox5.Text);
                    cmd.Parameters.AddWithValue("@LASTNAME", this.textBox6.Text);
                    cmd.Parameters.AddWithValue("@DOB", this.dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@USERNAME", this.textBox3.Text);
                    cmd.Parameters.AddWithValue("@PASSWORD", this.textBox4.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item added successfully");
                }
                this.Close();
                Login log = new Login();
                log.Show();
            }
        }
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on the CheckBox state
            if (checkBox2.Checked)
            {
                textBox4.PasswordChar = '\0'; // show password
            }
            else
            {
                textBox4.PasswordChar = '*'; // hide
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
