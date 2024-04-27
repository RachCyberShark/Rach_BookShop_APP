using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Configuration;
using System.Data.SqlClient;
using APP_RachST20.subform;

namespace APP_RachST20.componnet
{
    public partial class Userdashboard : Form
    {
        // Property to hold the currently logged in user
        public User Login_User { get; set; }
        private int categoryId;
        // Constructor for UserProfile form
        public Userdashboard (User auth, int categoryId)
        {
            InitializeComponent();

            this.Login_User = auth;
            this.categoryId = categoryId;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // This method can be used for any additional actions when the text in the textbox changes
        }

        private void welcome_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            subform.Controls.Clear();
            Home home = new Home();
            home.TopLevel = false;
            home.AutoScroll = true;
            home.FormBorderStyle = FormBorderStyle.None;
            subform.Controls.Add(home);
            home.BringToFront();
            home.Show();

            Chgcolor((Button)sender, Color.Blue);
        }
        private Button lastButton = null;
        private void Chgcolor(Button current, Color colorName)
        {
            if (lastButton != null)
            {
                lastButton.BackColor = SystemColors.Control;
            }
            lastButton = current;
            current.BackColor = colorName;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            subform.Controls.Clear();
            catecory task = new catecory(Login_User, categoryId);
            task.TopLevel = false;
            task.AutoScroll = true;
            task.FormBorderStyle = FormBorderStyle.None;
            subform.Controls.Add(task);
            task.BringToFront();
            task.Show();
            Chgcolor((Button)sender, Color.Blue);

        }

        private void Userdashboard_Load(object sender, EventArgs e)
        {

        }

        private void manage_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
