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
    /// Interaction logic for EditDishWindow.xaml
    /// </summary>
    public partial class EditDishWindow : Window
    {
        public EditDishWindow()
        {
            InitializeComponent();
        }
        private void EditDish(object sender, RoutedEventArgs e)
        {
            try
            {
                int did = Convert.ToInt32(EditDishIdTextbox.Text);
                int restid = Convert.ToInt32(EditRidTextbox.Text);
                string dishName = EditDishNameTextbox.Text;
                int price = Convert.ToInt32(EditpriceTextbox.Text);
                bool isAvail = (bool)checkboxdish.IsChecked;
                SqlConnection con = new SqlConnection("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Praveen;User=sa;Password=sa@1234;TrustServerCertificate=true;MultipleActiveResultSets=true;");

                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Dish] SET  DishName='" + dishName+ "', RestaurantId='" + restid + "', Availability='" + isAvail + "', Price='" + price + "'  WHERE Id=" + did, con);
                cmd.Parameters.AddWithValue("@Id", did);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Restaurant " + dishName + " edited!");
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
