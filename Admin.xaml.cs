using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {

        SqlConnection con;
        SqlDataReader reader;
        public Admin()
        {
            InitializeComponent();
            MainWindow mw = new MainWindow();
            con = mw.GetSqlConnection();
            con.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into ProductTable values(@ProductId, @ProductName, @Amount, @Price)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", int.Parse(p_id.Text));
                cmd.Parameters.AddWithValue("@ProductName", p_name.Text);
                cmd.Parameters.AddWithValue("@Amount", int.Parse(p_amount.Text));
                cmd.Parameters.AddWithValue("@Price", float.Parse(p_price.Text));
                cmd.ExecuteNonQuery();

                string name = p_name.Text.ToString();
                string amount = p_amount.Text.ToString();
                string price = p_price.Text.ToString();
                MessageBox.Show(amount + "kg " + name + " with price " + price + "(CAD)/kg added into databes successfully!");
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "Delete from ProductTable where ProductId = @Id";
                string readerQuery = "Select ProductName, Amount from ProductTable where ProductId = @Id";
                SqlCommand command = new SqlCommand(query, con);
                SqlCommand readerCmd = new SqlCommand(readerQuery, con);
                command.Parameters.AddWithValue("@Id", int.Parse(p_id.Text));
                readerCmd.Parameters.AddWithValue("@Id", int.Parse(p_id.Text));
                

                reader = readerCmd.ExecuteReader();

                string name = "";
                string amount = "";
                while (reader.Read())
                {
                    name = reader.GetValue(0).ToString();
                    amount = reader.GetValue(1).ToString();
                }
                reader.Close();
                command.ExecuteNonQuery();
                MessageBox.Show(amount + "kg " + name + " have been successfully deleted from database");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
