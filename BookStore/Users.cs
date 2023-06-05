using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class Users : Form
    {
        private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        private MySqlConnection connection;

        public Users()
        {
            InitializeComponent();
            builder.Server = "localhost";
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "314358";
            builder.Database = "bookstore";
            connection = new MySqlConnection(builder.ConnectionString);
            ShowUsers();
        }

        private void ShowUsers()
        {
            connection.Open();
            string sql = "select * from users";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "users");
            UsersView.DataSource = ds.Tables["users"];
            connection.Close();
        }

        private void clear()
        {
            tbId.Clear();
            tbName.Clear();
            tbPhone.Clear();
            tbAdd.Clear();
            tbPwd.Clear();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "" || tbName.Text == "" || tbPhone.Text == "" ||
                tbAdd.Text == "" || tbPwd.Text == "")
            {
                MessageBox.Show("用户信息不能为空！");
                clear();
                return;
            }
            else
            {
                try
                {
                    string sql = "insert into users(UId, UName, UPhone, UAddress, UPassword) values (" +
                    int.Parse(tbId.Text) + ",'" + tbName.Text + "','" + tbPhone.Text + "','" + tbAdd.Text + "','" +
                    tbPwd.Text + "');";
                    MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    mda.Fill(ds, "users");
                    MessageBox.Show("保存成功！", "提示");
                    ShowUsers();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "错误信息");
                }
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "" || tbName.Text == "" || tbPhone.Text == "" ||
                tbAdd.Text == "" || tbPwd.Text == "")
            {
                MessageBox.Show("用户信息不能为空！");
                clear();
                return;
            }
            else
            {
                string sql = "update users set UName = '" + tbName.Text + "', UPhone = '" + tbPhone.Text +
                "', UAddress = '" + tbAdd.Text + "', UPassword = '" + tbPwd.Text + 
                "' where UId = " + int.Parse(tbId.Text) + ";";
                MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                try
                {
                    string msg = "是否确认编辑？";
                    if (1 == (int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                    {
                        mda.Fill(ds, "users");
                        MessageBox.Show("编辑成功", "提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "错误信息");
                }
                connection.Close();
                ShowUsers();
            }
        }

        private void UsersView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbId.Text = UsersView.SelectedRows[0].Cells[0].Value.ToString();
            tbName.Text = UsersView.SelectedRows[0].Cells[1].Value.ToString();
            tbPhone.Text = UsersView.SelectedRows[0].Cells[2].Value.ToString();
            tbAdd.Text = UsersView.SelectedRows[0].Cells[3].Value.ToString();
            tbPwd.Text = UsersView.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            connection.Open();
            int index = UsersView.CurrentCell.RowIndex;
            int UId = (int)UsersView.Rows[index].Cells[0].Value;
            string sql = "delete from users where UId=" + UId + ";";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            try
            {
                string msg = "是否确认删除？";
                if (1 == (int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                {
                    mda.Fill(ds, "users");
                    MessageBox.Show("删除成功", "提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误信息");
            }
            connection.Close();
            ShowUsers();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            clear();
            ShowUsers();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎再次使用系统！");
            Login obj = new Login();
            obj.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            book obj = new book();
            obj.Show();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Close();
        }

        private void Shut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
