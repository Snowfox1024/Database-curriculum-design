using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BookStore
{
    public partial class book : Form
    {
        private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        private MySqlConnection connection;

        public book()
        {
            InitializeComponent();
            builder.Server = "localhost";
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "314358";
            builder.Database = "bookstore";
            connection = new MySqlConnection(builder.ConnectionString);
            ShowBooks();
        }

        private void ShowBooks()
        {
            connection.Open();
            string sql = "select * from books order by BId";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "books");
            BooksView.DataSource = ds.Tables["books"];
            connection.Close();
        }

        private void Filter()
        {
            connection.Open();
            string sql = "select * from books where BCat = '" + cbChoose.SelectedItem.ToString() + "'";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            mda.Fill(ds, "books");
            BooksView.DataSource = ds.Tables["books"];
            connection.Close();
        }
        
        private void clear()
        {
            tbId.Clear();
            tbTitile.Clear();
            tbAuthor.Clear();
            tbNums.Clear();
            tbPrice.Clear();
            cbCat.SelectedIndex = -1;
            cbChoose.SelectedIndex = -1;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "" || tbTitile.Text == "" || tbAuthor.Text == "" || 
                tbNums.Text == "" || tbPrice.Text == "")
            {
                MessageBox.Show("书籍信息不能为空！");
                clear();
                return;
            }
            else
            {
                try
                {
                    string sql = "insert into books(BId, Btitle, BAuthor, BCat, BNum, BPrice) values (" +
                    int.Parse(tbId.Text) + ",'" + tbTitile.Text + "','" + tbAuthor.Text +"','" + cbCat.Text + "'," + 
                    int.Parse(tbNums.Text) + "," + int.Parse(tbPrice.Text) + ");";
                    MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    mda.Fill(ds, "books");
                    MessageBox.Show("保存成功！", "提示");
                    ShowBooks();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "错误信息");
                }
            }
        }

        private void cbChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            ShowBooks();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void BooksView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbId.Text = BooksView.SelectedRows[0].Cells[0].Value.ToString();
            tbTitile.Text = BooksView.SelectedRows[0].Cells[1].Value.ToString();
            tbAuthor.Text = BooksView.SelectedRows[0].Cells[2].Value.ToString();
            cbCat.SelectedItem = BooksView.SelectedRows[0].Cells[3].Value.ToString();
            tbNums.Text = BooksView.SelectedRows[0].Cells[4].Value.ToString();
            tbPrice.Text = BooksView.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            connection.Open();
            int index = BooksView.CurrentCell.RowIndex;
            int BId = (int)BooksView.Rows[index].Cells[0].Value;
            string sql = "delete from books where BId=" + BId + "";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            try
            {
                string msg = "是否确认删除？";
                if (1 == (int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                {
                    mda.Fill(ds, "books");
                    MessageBox.Show("删除成功", "提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误信息");
            }
            connection.Close();
            ShowBooks();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "" || tbTitile.Text == "" || tbAuthor.Text == "" ||
                tbNums.Text == "" || tbPrice.Text == "")
            {
                MessageBox.Show("书籍信息不能为空！");
                clear();
                return;
            }
            else
            {
                string sql = "update books set BTitle = '" + tbTitile.Text + "', BAuthor = '" + tbAuthor.Text +
                "', BCat = '" + cbCat.SelectedItem.ToString() + "', BNum = " + int.Parse(tbNums.Text) + ", BPrice = " + 
                int.Parse(tbPrice.Text) + " where BId =" + int.Parse(tbId.Text) + ";";
                MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                try
                {
                    string msg = "是否确认编辑？";
                    if (1 == (int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                    {
                        mda.Fill(ds, "books");
                        MessageBox.Show("编辑成功", "提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "错误信息");
                }
                connection.Close();
                ShowBooks();
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎再次使用系统！");
            Login obj = new Login();
            obj.Show();
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Users obj = new Users();
            obj.Show();
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
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
