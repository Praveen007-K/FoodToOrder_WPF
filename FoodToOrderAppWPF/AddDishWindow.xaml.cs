using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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

namespace FoodToOrderAppWPF
{
    /// <summary>
    /// Interaction logic for AddDishWindow.xaml
    /// </summary>
    public partial class AddDishWindow : Window
    {
        public AddDishWindow()
        {
            InitializeComponent();
        }

        private void AddDish(object sender, RoutedEventArgs e)
        {
            try
            {
                string dishName = AddDNameTextbox.Text;
                int dishPrice = Convert.ToInt32(AddDpriceTextbox.Text);
                int restId = Convert.ToInt32(AddRidTextbox.Text);
                bool isOpen = (bool)checkboxdish.IsChecked;
                SqlConnection con = new SqlConnection("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Praveen;User=sa;Password=sa@1234;TrustServerCertificate=true;MultipleActiveResultSets=true;");

                con.Open();
                SqlCommand cmd1 = new SqlCommand("Select Max(Id) AS MaxId from [dbo].[Dish]", con);
                cmd1.CommandType = CommandType.Text;
                int cnt = Convert.ToInt32(cmd1.ExecuteScalar()) + 1;
                con.Close();

                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Dish] (Id, DishName, Price, Availability, RestaurantId) VALUES (@Id, @DishName, @Price, @Availability, @RestaurantId)", con);
                cmd.Parameters.AddWithValue("@Id", cnt);
                cmd.Parameters.AddWithValue("@DishName", dishName);
                cmd.Parameters.AddWithValue("@Price", dishPrice);
                cmd.Parameters.AddWithValue("@Availability", isOpen);
                cmd.Parameters.AddWithValue("@RestaurantId", restId);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Dish " + dishName + " added!");
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void AdminOptions(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox box)
            {
                if (string.IsNullOrEmpty(box.Text))
                    box.Background = (ImageBrush)FindResource("watermark");
                else
                    box.Background = null;
            }
        }
    }
}
