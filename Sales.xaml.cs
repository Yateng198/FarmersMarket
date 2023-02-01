using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.Linq;

namespace FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        public Sales()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        public void FocusApple(object sender, RoutedEventArgs e)
        {
            appleAmount.Text = string.Empty;
            appleAmount.GotFocus -= FocusApple;
        }

        public void FocusOrange(object sender, RoutedEventArgs e)
        {
            orangeAmount.Text = string.Empty;
            orangeAmount.GotFocus -= FocusOrange;
        }

        public void FocusRasp(object sender, RoutedEventArgs e)
        {
            raspAmount.Text = string.Empty;
            raspAmount.GotFocus -= FocusRasp;
        }

        public void FocusBlue(object sender, RoutedEventArgs e)
        {
            blueAmount.Text = string.Empty;
            blueAmount.GotFocus -= FocusBlue;
        }

        public void FocusCauli(object sender, RoutedEventArgs e)
        {
            cauliAmount.Text = string.Empty;
            cauliAmount.GotFocus -= FocusCauli;
        }


        private void Add_Apple(object sender, RoutedEventArgs e)
        {
            double applePrice = 2.1;
            int appleInOrder = Convert.ToInt16(appleAmount.Text);
            double orderTPrice = Convert.ToDouble(totalPrice.Text);
            orderTPrice = orderTPrice + (applePrice * appleInOrder);
            //just for better presentation for avg score
            orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100; 

            totalPrice.Text = orderTPrice.ToString();
        }

        private void Add_Orange(object sender, RoutedEventArgs e)
        {
            double orangePrice = 2.49;
            int orangeInOrder = Convert.ToInt16(orangeAmount.Text);
            double orderTPrice = Convert.ToDouble(totalPrice.Text);
            orderTPrice = orderTPrice + (orangePrice * orangeInOrder);
            //just for better presentation for avg score
            orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100;

            totalPrice.Text = orderTPrice.ToString();
        }

        private void Add_Rasp(object sender, RoutedEventArgs e)
        {
            double raspPrice = 2.35;
            int raspInOrder = Convert.ToInt16(raspAmount.Text);
            double orderTPrice = Convert.ToDouble(totalPrice.Text);
            orderTPrice = orderTPrice + (raspPrice * raspInOrder);
            //just for better presentation for avg score
            orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100;

            totalPrice.Text = orderTPrice.ToString();
        }

        private void Add_Blue(object sender, RoutedEventArgs e)
        {
            double bluePrice = 1.45;
            int blueInOrder = Convert.ToInt16(blueAmount.Text);
            double orderTPrice = Convert.ToDouble(totalPrice.Text);
            orderTPrice = orderTPrice + (bluePrice * blueInOrder);
            //just for better presentation for avg score
            orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100;

            totalPrice.Text = orderTPrice.ToString();
        }

        private void Add_Cauli(object sender, RoutedEventArgs e)
        {
            double cauliPrice = 2.22;
            int cauliInOrder = Convert.ToInt16(cauliAmount.Text);
            double orderTPrice = Convert.ToDouble(totalPrice.Text);
            orderTPrice = orderTPrice + (cauliPrice * cauliInOrder);
            //just for better presentation for avg score
            orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100;

            totalPrice.Text = orderTPrice.ToString();
        }

        private void Restart(object sender, RoutedEventArgs e)
        {
            appleAmount.Text = "Please enter the amount you want to buy";
            orangeAmount.Text = "Please enter the amount you want to buy";
            raspAmount.Text = "Please enter the amount you want to buy";
            blueAmount.Text = "Please enter the amount you want to buy";
            cauliAmount.Text = "Please enter the amount you want to buy";

            double orderTPrice = 0;
            totalPrice.Text = orderTPrice.ToString();
            MessageBox.Show("Shopping carts cleaned, now you could choose again!");
        }

        private void Order_Confirm(object sender, RoutedEventArgs e)
        {
            double orderTPrice = Convert.ToDouble(totalPrice.Text);
            int appleInOrder = Convert.ToInt16(appleAmount.Text);
            int orangeInOrder = Convert.ToInt16(orangeAmount.Text);
            int raspInOrder = Convert.ToInt16(raspAmount.Text);
            int blueInOrder = Convert.ToInt16(blueAmount.Text);
            int cauliInOrder = Convert.ToInt16(cauliAmount.Text);

            MessageBox.Show("Order processed.\n\nYou've ordered " + appleInOrder + " Apples, "+ orangeInOrder + " Oranges, " + raspInOrder + " Raspberries, " + blueInOrder + " Blueberries, " + cauliInOrder + " Cauliflowers, and the Total Price is (CA)$" + orderTPrice + ".");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
