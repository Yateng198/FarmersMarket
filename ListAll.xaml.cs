using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for ListAll.xaml
    /// </summary>
    public partial class ListAll : Window
    {
        public ListAll()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1AHTENP;Initial Catalog=FarmersMarket;Integrated Security=True;Pooling=False");

            try
            {
                con.Open();
                string query = "Select ProductId, ProductName, Amount, Price from ProductTable";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("ProductTable");
                adapter.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                
                adapter.Update(dt);
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Admin_Page_Button_Click(object sender, RoutedEventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Close();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
