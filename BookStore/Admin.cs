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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            tbPassword.UseSystemPasswordChar = true;
        }

        private void Shut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (tbPassword.Text.Equals("Password"))
            {
                MessageBox.Show("欢迎管理员登录本系统", "消息提示");
                flag = true;
                book obj = new book();
                obj.Show();
                this.Hide();
            }
            if (tbPassword.Text.Equals(""))
            {
                MessageBox.Show("密码不能为空！", "登录提示");
                tbPassword.Clear();
                return;
            }
            if (!flag)
            {
                MessageBox.Show("登录失败！", "错误提示");
                tbPassword.Clear();
                return;
            }
        }

        private void Backlb_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
