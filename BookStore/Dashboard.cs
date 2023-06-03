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

namespace BookStore
{
    public partial class Dashboard : Form
    {
        private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        private MySqlConnection connection;
        public Dashboard()
        {
            InitializeComponent();
            builder.Server = "localhost";
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "314358";
            builder.Database = "bookstore";
            connection = new MySqlConnection(builder.ConnectionString);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎再次使用系统！");
            Login obj = new Login();
            obj.Show();
            this.Close();
        }

        private void lbBook_Click(object sender, EventArgs e)
        {
            book obj = new book();
            obj.Show();
            this.Close();
        }

        private void lbUser_Click(object sender, EventArgs e)
        {
            Users obj = new Users();
            obj.Show();
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            connection.Open();
            string sql = "select sum(BNum) from books;";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            lbBNum.Text = dt.Rows[0][0].ToString();

            string sql1 = "select sum(Amount) from dbo;";
            MySqlDataAdapter mda1 = new MySqlDataAdapter(sql1, connection);
            DataTable dt1 = new DataTable();
            mda1.Fill(dt1);
            lbPtotal.Text = dt1.Rows[0][0].ToString();

            string sql2 = "select count(*) from users;";
            MySqlDataAdapter mda2 = new MySqlDataAdapter(sql2, connection);
            DataTable dt2 = new DataTable();
            mda2.Fill(dt2);
            lbPeople.Text = dt2.Rows[0][0].ToString();

            connection.Close();
        }
    }
}
