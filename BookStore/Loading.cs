using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        int startPos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPos += 5;
            progressBar.Value = startPos;
            percentLb.Text = startPos + "%";
            if(progressBar.Value == 100)
            {
                progressBar.Value = 0;
                timer1.Stop();
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
