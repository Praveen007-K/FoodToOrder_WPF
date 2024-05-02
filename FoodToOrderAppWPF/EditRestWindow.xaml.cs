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
    /// Interaction logic for EditRestWindow.xaml
    /// </summary>
    public partial class EditRestWindow : Window
    {
        public EditRestWindow()
        {
            InitializeComponent();
        }
        private void EditRest(object sender, RoutedEventArgs e)
        {
            try
            {
                int restid = Convert.ToInt32(EditRidTextbox.Text);
                string restaurantName = EditRestTextbox.Text;
                bool isOpen = (bool)checkboxrest.IsChecked;
                SqlConnection con = new SqlConnection("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Praveen;User=sa;Password=sa@1234;TrustServerCertificate=true;MultipleActiveResultSets=true;");

                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Restaurant] SET RName='" + restaurantName + "', ROpen='" + isOpen + "'  WHERE Id=" + restid, con);
                cmd.Parameters.AddWithValue("@Id", restid);
                //cmd.Parameters.AddWithValue("@RName", restaurantName);
                //cmd.Parameters.AddWithValue("@ROpen", isOpen);
                cmd.Parameters.AddWithValue("@UserId", 0);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Restaurant " + restaurantName + " edited!");
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
