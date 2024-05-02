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
    /// Interaction logic for DeleteRestWindow.xaml
    /// </summary>
    public partial class DeleteRestWindow : Window
    {
        public DeleteRestWindow()
        {
            InitializeComponent();
        }

        private void DeleteRest(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(deleteTextbox.Text);
            SqlConnection con = new SqlConnection("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Praveen;User=sa;Password=sa@1234;TrustServerCertificate=true;MultipleActiveResultSets=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from [dbo].[Restaurant] where id=@Id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Restaurant Deleted.");
            con.Close();
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
        private void AdminOptions(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
