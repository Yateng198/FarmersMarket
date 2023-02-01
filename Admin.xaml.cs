using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        //Global variable
        SqlConnection con;

        //In this page, we are using Task-async-await to contorl Threads Synchronization.
        public Admin()
        {
            InitializeComponent();
            //set up and open connection for this whole page, so that using a single connection with the DB
            //Ensure that data are synchronized
            con = new SqlConnection("Data Source=DESKTOP-1AHTENP;Initial Catalog=FarmersMarket;Integrated Security=True;Pooling=False");
            con.Open();

        }

        //Back to home window and close the connection
        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            con.Close();
            mw.Show();
            this.Close();
        }
        //Insert operation
        private async void Insert_Button_Click(object sender, RoutedEventArgs e)
        {
            //Invoke the insertButton() method
            await Task.Run(insertButton);
        }

        private void insertButton()
        {
            try
            {
                //Dispatch current thread to communicate with the UI thread
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    string query = "insert into ProductTable values(@ProductId, @ProductName, @Amount, @Price)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    //Fill up the place holders with user input

                    //In case of user input errors, pop out message box for error message
                    try
                    {
                        cmd.Parameters.AddWithValue("@ProductId", int.Parse(p_id.Text));
                        cmd.Parameters.AddWithValue("@ProductName", p_name.Text);
                        cmd.Parameters.AddWithValue("@Amount", int.Parse(p_amount.Text));
                        cmd.Parameters.AddWithValue("@Price", float.Parse(p_price.Text));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Input error, try again please!");
                    }
                    //Excute the command
                    cmd.ExecuteNonQuery();
                    string name = p_name.Text.ToString();
                    string amount = p_amount.Text.ToString();
                    string price = p_price.Text.ToString();
                    MessageBox.Show(amount + "kg " + name + " with price " + price + "(CAD)/kg added into databes successfully!");
                }));
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Delete operation
        private async void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            //Run the deleteButton method
            await Task.Run(deleteButton);
            
        }
        
        private void deleteButton()
        {
            try
            {
                //Dispatch current thread to communicate with the UI thread
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    string query = "Delete from ProductTable where ProductId = @Id";
                    string readerQuery = "Select ProductName, Amount from ProductTable where ProductId = @Id";
                    SqlCommand command = new SqlCommand(query, con);
                    SqlCommand readerCmd = new SqlCommand(readerQuery, con);

                    //In case of user input errors, pop out message box for error message
                    int pro_id = 0;
                    try
                    {
                        pro_id = int.Parse(p_id.Text);
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Input error, try again please!");
                    }
                    command.Parameters.AddWithValue("@Id", pro_id);
                    readerCmd.Parameters.AddWithValue("@Id", pro_id);


                    SqlDataReader reader = readerCmd.ExecuteReader();

                    string name = "";
                    string amount = "";
                    if(!reader.HasRows)
                    {
                        MessageBox.Show("There is no item in database matchs this ID, please check you input and try again!");
                    }else if(reader.Read())
                    {
                        name = reader.GetValue(0).ToString();
                        amount = reader.GetValue(1).ToString();

                        reader.Close();
                        command.ExecuteNonQuery();
                        MessageBox.Show(amount + "kg " + name + " have been successfully deleted from database");
                    }
                }));
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Update operation
        private async void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            //Run the updateButton method
            await Task.Run(updateButton);
        }

        
        private void updateButton()
        {
            try{
                //Dispatch current thread to communicate with the UI thread
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    string query = "update ProductTable set Productname = @name, Amount = @amount, Price = @price where ProductId = @Id";
                    string readerQuery = "Select ProductName, Amount from ProductTable where ProductId = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlCommand readerCmd = new SqlCommand(readerQuery, con);
                    int pro_id = 0, pro_amount = 0, pro_price = 0;
                    //In case of user input errors, pop out message box for error message
                    try
                    {
                        pro_id = int.Parse(p_id.Text);
                        pro_amount = int.Parse(p_amount.Text);
                        pro_price = int.Parse(p_price.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Input error, try again please!");
                    }
                    cmd.Parameters.AddWithValue("@Id", pro_id);
                    cmd.Parameters.AddWithValue("@name", p_name.Text);
                    cmd.Parameters.AddWithValue("@amount", pro_amount);
                    cmd.Parameters.AddWithValue("@price", pro_price);
                    
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        MessageBox.Show("There is no item in database matchs this ID, please check you input and try again!");
                        reader.Close();
                    }
                    else if (reader.Read())
                    {
                        reader.Close();
                        //Execute the command
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data updated into database successfully!");
                    }
                }));
                

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(searchButton);
           
        }

        private void searchButton()
        {
            try
            {
                //Dispatch current thread to communicate with the UI thread
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    string qury = "select ProductName, Amount, Price from ProductTable where ProductId = @Id";
                    SqlCommand cmd = new SqlCommand(qury, con);
                    //Fill up the product id with user input
                    int pro_id = 0;
                    try
                    {
                         pro_id = (int.Parse(p_id.Text));
                    }catch(Exception ex) { 
                        MessageBox.Show("Input error, try again please!");
                    }
                    

                    cmd.Parameters.AddWithValue("@Id",pro_id );
                    SqlDataReader reader = cmd.ExecuteReader();
                    //If there's no object matching with this id, will pop this msg box with error msg
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("There is no item in database matchs this ID, please check you input and try again!");
                    }
                    else if(reader.Read())
                        {
                            //Fill up the corresponding textbox with this specific product information
                            p_name.Text = reader.GetValue(0).ToString();
                            p_amount.Text = reader.GetValue(1).ToString();
                            p_price.Text = reader.GetValue(2).ToString();

                        MessageBox.Show("With ID " + p_id.Text.ToString() + ", we found " + p_amount.Text + "kg " + p_name.Text + " with price " + p_price.Text + " CAD/kg in database");
                    }

                    reader.Close();
                    
                }));
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //To check all the data in DB, will display in an independent window
        //And close this window DB connection
        private void List_All_Button_Click(object sender, RoutedEventArgs e)
        {
            ListAll ls = new ListAll();
            con.Close();
            ls.Show();
            this.Close();
        }
    }
}
