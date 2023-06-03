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
    public partial class Information : Form
    {
        private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        private MySqlConnection connection;

        public Information()
        {
            InitializeComponent();
            builder.Server = "localhost";
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "314358";
            builder.Database = "bookstore";
            connection = new MySqlConnection(builder.ConnectionString);
        }

        private static string userName;
        private void Information_Load(object sender, EventArgs e)
        {
            userName = Login.UserName;
            labelUser.Text = userName;
            ShowOrders();
            ShowInfo();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎再次光临！");
            Login obj = new Login();
            obj.Show();
            this.Close();
        }

        private void ShowOrders()
        {
            connection.Open();
            string sql = "select BillId,UAddress,Amount from orders where UName ='" + userName + "';";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            mda.Fill(ds, "orders");
            OrdersView.DataSource = ds.Tables["orders"];
            connection.Close();
        }

        private void ShowInfo()
        {
            connection.Open();
            string sql = "select UName,UPhone,UAddress from users where UName ='" + userName + "';";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            tbName.Text = dt.Rows[0][0].ToString();
            tbPhone.Text = dt.Rows[0][1].ToString();
            tbAddress.Text = dt.Rows[0][2].ToString();
            connection.Close();
        }

        private void btGoback_Click(object sender, EventArgs e)
        {
            Bill obj = new Bill();
            obj.Show();
            this.Close();
        }
    }
}
