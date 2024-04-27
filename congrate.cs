using APP_RachST20.componnet;
using APP_RachST20.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_RachST20
{
    public partial class congrate : Form
    {
        
        public congrate()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new login().Show();
        }
    }
}
