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
    public partial class MoreInformation : Form
    {
        private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        private MySqlConnection connection;
        public MoreInformation()
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

        private void btGoback_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Close();
        }

        private void MoreInformation_Load(object sender, EventArgs e)
        {
            connection.Open();

            Statistic_Cat();
            Statistic_Order();
            Highest_Amount();
            Empty_User();

            connection.Close();
        }

        private void Statistic_Cat()
        {
            string sql = "select BCat, count(*) as BookCount from books group by BCat order by BookCount desc;";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            CatView.DataSource = dt;
        }

        private void Statistic_Order()
        {
            string sql1 = "SELECT u.UId, u.UName, SUM(o.Amount) AS TotalOrderAmount FROM users u " +
                "JOIN orders o ON u.UId = o.UId " +
                "GROUP BY u.UId, u.UName " +
                "ORDER BY TotalOrderAmount DESC;";
            MySqlDataAdapter mda1 = new MySqlDataAdapter(sql1, connection);
            DataTable dt1 = new DataTable();
            mda1.Fill(dt1);
            OrderView.DataSource = dt1;
        }

        private void Highest_Amount()
        {
            string sql2 = "SELECT u.UId, u.UName, o.BillId, o.Amount " +
                "FROM users u " +
                "JOIN orders o ON u.UId = o.UId " +
                "WHERE o.Amount = (SELECT MAX(Amount) FROM orders);";
            MySqlDataAdapter mda2 = new MySqlDataAdapter(sql2, connection);
            DataTable dt2 = new DataTable();
            mda2.Fill(dt2);
            HighestView.DataSource = dt2;
        }

        private void Empty_User()
        {
            string sql3 = "SELECT UId,UName,UPhone FROM users " +
                "WHERE UId NOT IN (SELECT UId FROM orders);";
            MySqlDataAdapter mda3 = new MySqlDataAdapter(sql3, connection);
            DataTable dt3 = new DataTable();
            mda3.Fill(dt3);
            NoOrderView.DataSource = dt3;
        }

        private void Shut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
