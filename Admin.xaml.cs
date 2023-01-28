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
        public Admin()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=DESKTOP-1AHTENP;Initial Catalog=FarmersMarket;Integrated Security=True;Pooling=False");
            con.Open();
        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Insert_Button_Click(object sender, RoutedEventArgs e)
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

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "Delete from ProductTable where ProductId = @Id";
                string readerQuery = "Select ProductName, Amount from ProductTable where ProductId = @Id";
                SqlCommand command = new SqlCommand(query, con);
                SqlCommand readerCmd = new SqlCommand(readerQuery, con);
                command.Parameters.AddWithValue("@Id", int.Parse(p_id.Text));
                readerCmd.Parameters.AddWithValue("@Id", int.Parse(p_id.Text));
                

                SqlDataReader reader = readerCmd.ExecuteReader();

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

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string query = "update ProductTable set Productname = @name, Amount = @amount, Price = @price where ProductId = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(p_id.Text));
                cmd.Parameters.AddWithValue("@name", p_name.Text);
                cmd.Parameters.AddWithValue("@amount", int.Parse(p_amount.Text));
                cmd.Parameters.AddWithValue("@price", float.Parse(p_price.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data updated into database successfully!");

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string qury = "select ProductName, Amount, Price from ProductTable where ProductId = @Id";
                SqlCommand cmd = new SqlCommand(qury, con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(p_id.Text));
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    p_name.Text = reader.GetValue(0).ToString();
                    p_amount.Text = reader.GetValue(1).ToString();
                    p_price.Text = reader.GetValue(2).ToString();
                }

                reader.Close();
                MessageBox.Show("With ID " + p_id.Text.ToString() + ", we found " + p_amount.Text + "kg " + p_name.Text + " with price " + p_price.Text + " CAD/kg in database");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void List_All_Button_Click(object sender, RoutedEventArgs e)
        {
            ListAll ls = new ListAll();
            ls.Show();
            this.Close();
        }
    }
}
