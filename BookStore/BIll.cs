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
    public partial class Bill : Form
    {
        private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        private MySqlConnection connection;

        public Bill()
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
            string sql = "select * from books";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "books");
            BooksView.DataSource = ds.Tables["books"];
            connection.Close();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎再次光临！");
            Login obj = new Login();
            obj.Show();
            this.Close();
        }

        private void BooksView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbTitile.Text = BooksView.SelectedRows[0].Cells[1].Value.ToString();
            tbPrice.Text = BooksView.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void clear()
        {
            tbTitile.Clear();
            tbPrice.Clear();
            tbNums.Clear();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            clear();
        }

        int n = 0;
        public int cartTotal = 0;
        private void btAddcart_Click(object sender, EventArgs e)
        {            
            int total = 0;
            int index = BooksView.CurrentCell.RowIndex;
            int stock = (int)BooksView.Rows[index].Cells[4].Value;
            if (tbNums.Text == "" || Convert.ToInt32(tbNums.Text) > stock)
            {
                MessageBox.Show("库存不足！");
            }
            else
            {
                total = Convert.ToInt32(tbNums.Text) * Convert.ToInt32(tbPrice.Text);
                DataGridViewRow dr = new DataGridViewRow();
                dr.CreateCells(CartView);
                dr.Cells[0].Value = ++n;
                dr.Cells[1].Value = tbTitile.Text;
                dr.Cells[2].Value = tbPrice.Text;
                dr.Cells[3].Value = tbNums.Text;
                dr.Cells[4].Value = total;
                CartView.Rows.Add(dr);
                UpdateBooks();
                cartTotal += total;
                lbTotal.Text = "￥" + cartTotal;
                clear();
            }
        }

        private void btCalculate_Click(object sender, EventArgs e)
        {
            if (CartView.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("还没有挑选书籍！");
                clear();
                return;
            }
            else
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
                try
                {
                    connection.Open();
                    string sql = "insert into dbo(UName,Amount) values('" + labelUser.Text + "'," + cartTotal + ")";
                    MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    mda.Fill(ds, "books");
                    MessageBox.Show("订单信息保存成功！", "提示");
                    connection.Close();
                    ShowBooks();
                    cartTotal = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "错误信息");
                }
            }
        }

        private int id, nums, price, total, pos = 60;
        private string name, userName;

        private void Bill_Load(object sender, EventArgs e)
        {
            userName = Login.UserName;
            labelUser.Text = userName;
        }
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("订单结算", new Font("幼圆", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("编号  产品  价格  数量  总计", new Font("幼圆", 10, FontStyle.Bold),
                Brushes.Red, new Point(26, 40));
            foreach (DataGridViewRow row in CartView.Rows)
            {
                id = Convert.ToInt32(row.Cells[0].Value);
                name = "" + row.Cells[1].Value;
                price = Convert.ToInt32(row.Cells[2].Value);
                nums = Convert.ToInt32(row.Cells[3].Value);
                total = Convert.ToInt32(row.Cells[4].Value);
                e.Graphics.DrawString("" + id, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + name, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + price, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + nums, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + total, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos += 20;
            }
            e.Graphics.DrawString("订单总额：￥" + cartTotal, new Font("幼圆", 12, FontStyle.Bold), Brushes.Crimson,
                new Point(60, pos + 50));
            CartView.Rows.Clear();
            CartView.Refresh();
            pos = 100;
            lbTotal.Text = "";
        }

        private void UpdateBooks()
        {
            int index = BooksView.CurrentCell.RowIndex;
            int BId = (int)BooksView.Rows[index].Cells[0].Value;
            int stock = (int)BooksView.Rows[index].Cells[4].Value;
            int newStock = stock - Convert.ToInt32(tbNums.Text);
            try
            {
                string sql = "update books set BNum =" + newStock + " where BId =" + BId + " ";
                MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                mda.Fill(ds, "books");
                // MessageBox.Show("书籍信息已更新！");                
                ShowBooks();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误信息");
            }        
        }
    }
}
