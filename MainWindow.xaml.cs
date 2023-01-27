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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

         public SqlConnection con = new SqlConnection("Data Source=DESKTOP-1AHTENP;Initial Catalog=FarmersMarket;Integrated Security=True;Pooling=False");
        //SqlCommand cmd, cmd1;
        //SqlDataReader reader;
        public SqlConnection GetSqlConnection()
        {
            return con;
        }
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Customer cust = new Customer();
            cust.Show();
            this.Close();
        }
    }
}
