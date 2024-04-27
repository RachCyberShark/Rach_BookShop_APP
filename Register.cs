// Register.cs
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace APP_RachST20
{
    public partial class Register : Form
    {
        private byte[] selectedImageBytes;
        public Register()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string phone = txtphone.Text;
            string address = txtadrees.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and Password fields are empty", "Sign Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string token = GenerateToken();
            DateTime tokenExpireAt = DateTime.Now.AddMinutes(2);

            try
            {
                using (SqlConnection dbconn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    dbconn.Open();
                    using (SqlCommand mysqlCmd = new SqlCommand(
                        "INSERT INTO [User] (name, Email, Password, token, token_expire_at,Phone,Address,profile_image) VALUES (@name, @email, @password, @token, @token_expire_at,@Phone,@Address,@profile_image)",
                        dbconn))
                    {
                        mysqlCmd.Parameters.AddWithValue("@name", username);
                        mysqlCmd.Parameters.AddWithValue("@email", email);
                        mysqlCmd.Parameters.AddWithValue("@token", token);
                        mysqlCmd.Parameters.AddWithValue("@token_expire_at", tokenExpireAt);
                        mysqlCmd.Parameters.AddWithValue("@password", password);
                        mysqlCmd.Parameters.AddWithValue("@Address", address);
                        mysqlCmd.Parameters.AddWithValue("@Phone", phone);
                        if (selectedImageBytes != null)
                        {
                            mysqlCmd.Parameters.AddWithValue("@profile_image", selectedImageBytes);
                        }
                        else
                        {
                            mysqlCmd.Parameters.AddWithValue("@profile_image", DBNull.Value);
                        }

                        // Execute the command
                        mysqlCmd.ExecuteNonQuery();
                    }

                    // Get the ID of the newly inserted customer
                    int ID;
                    using (SqlCommand cmd = new SqlCommand("SELECT @@IDENTITY", dbconn))
                    {
                        ID = Convert.ToInt32(cmd.ExecuteScalar());
                    }


                    // Send email with token
                    var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
                    {
                        Credentials = new NetworkCredential("c24c64f87f4e0d", "b7ba7febf1b0f6"),
                        EnableSsl = true
                    };

                    MailMessage mail = new MailMessage(
                        "your_email@example.com",
                        email,
                        "This is your verify Token",
                        $"This is your verify Token: {token}");

                    client.Send(mail);

                    // Hide the current form and show the next form
                    this.Hide();
                    VerifyCodeRegister verifyCodeForm = new VerifyCodeRegister(ID);
                    verifyCodeForm.Show();
                    verifyCodeForm.FormClosed += (s, args) => this.Close(); // Close current form when VerifyCodeRegister form is closed
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateToken()
        {
            // Generating a random token of 6 digits
            Random random = new Random();
            int token = random.Next(100000, 999999);
            return token.ToString();
        }
        private void user_profile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image to PictureBox
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

                // Convert the image to a byte array
                selectedImageBytes = ImageToByteArray(pictureBox1.Image);
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }


        private static bool IsValidEmail(string email)
        {
            // Regex for email validation
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }


        private void Register_Load(object sender, EventArgs e)
        {
            // Initialization logic if needed
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new login().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image to PictureBox
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

                // Convert the image to a byte array
                selectedImageBytes = ImageToByteArray(pictureBox1.Image);
            }
        }
    }
}
