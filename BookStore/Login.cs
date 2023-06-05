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
using System.Xml.Linq;

namespace BookStore
{
    public partial class Login : Form
    {
        private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        private MySqlConnection connection;

        public Login()
        {
            InitializeComponent();
            builder.Server = "localhost";
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "314358";
            builder.Database = "bookstore";
            connection = new MySqlConnection(builder.ConnectionString);
            tbPassword.UseSystemPasswordChar = true;
        }

        private void Shut_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void clear()
        {
            tbUName.Clear();
            tbPassword.Clear();
            tbUName.Focus();
        }

        public static string UserName = "";

        private void btCheck_Click(object sender, EventArgs e)
        {
            string sqlLogin = "select count(*) from userview where UName = '" + tbUName.Text +
                "' and UPassword = '" + tbPassword.Text + "';";
            try
            {
                connection.Open();
                MySqlDataAdapter mda = new MySqlDataAdapter(sqlLogin, connection);
                DataTable dt = new DataTable();
                mda.Fill(dt);
                bool flag = false;

                if (dt.Rows[0][0].ToString() == "1") 
                {
                    MessageBox.Show("欢迎您登录本系统", "消息提示");
                    flag = true;
                    UserName = tbUName.Text;
                    Bill obj = new Bill();
                    obj.Show();
                    this.Hide();
                }
                if (tbUName.Text.Equals("") || tbPassword.Text.Equals(""))
                {
                    MessageBox.Show("用户名或密码不能为空！", "登录提示");
                    clear();
                    return;
                }

                if (!flag)
                {
                    MessageBox.Show("登录失败！", "错误提示");
                    clear();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("登录失败！", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Adminlb_Click(object sender, EventArgs e)
        {
            Admin obj = new Admin();
            obj.Show();
            this.Close();
        }
    }
}
