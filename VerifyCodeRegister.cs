// VerifyCodeRegister.cs
using APP_RachST20.componnet;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace APP_RachST20
{
    public partial class VerifyCodeRegister : Form
    {
        private int ID = 0;
        private int count = 180;
        private Timer timer;

        public VerifyCodeRegister(int id)
        {
            InitializeComponent();
            ID = id;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void VerifyCodeRegister_Load(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (count > 0)
            {
                if (count <= 10)
                {
                    countLabel.ForeColor = Color.Red;
                }
            }
            countLabel.Text = count.ToString("D2");
            count--;
            if (count < 0)
            {
                ((Timer)sender).Stop();
                this.Close();
                new Register().Show();
                MessageBox.Show("Time out. We will send you later!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtytoken = token_txt.Text;
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

            try
            {
                using (SqlConnection dbconn = new SqlConnection(connectionString))
                {
                    dbconn.Open();

                    using (SqlCommand query = new SqlCommand("SELECT token FROM [User] WHERE ID = @ID", dbconn))
                    {
                        query.Parameters.AddWithValue("@ID", ID);
                        using (SqlDataReader reader = query.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string token = reader.GetString(0);
                                if (token == txtytoken)
                                {
                                    MessageBox.Show("Register successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                    new congrate().Show();
                                }
                                else
                                {
                                    MessageBox.Show("Your Register was not successful!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
