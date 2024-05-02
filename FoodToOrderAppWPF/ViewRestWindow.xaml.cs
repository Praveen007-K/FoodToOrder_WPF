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
    /// Interaction logic for ViewRestWindow.xaml
    /// </summary>
    public partial class ViewRestWindow : Window
    {
        public ViewRestWindow()
        {
            InitializeComponent();
        }

        public void ViewRestaurant()
        {
            SqlConnection con = new SqlConnection("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Praveen;User=sa;Password=sa@1234;TrustServerCertificate=true;MultipleActiveResultSets=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[Restaurant]", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    AddRestaurant(dataSet.Tables[0].Rows[i]["Id"].ToString() + " " + dataSet.Tables[0].Rows[i]["RName"].ToString(), dataSet.Tables[0].Rows[i]["Id"].ToString());
                }

            }
            con.Close();
        }

        public void AddRestaurant(string name, string dishid)
        {
            // Create ListBoxItem
            ListBoxItem newItem = new ListBoxItem();

            // Create Grid to hold elements
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200, GridUnitType.Pixel) }); // For restaurant name
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100, GridUnitType.Pixel) }); // For button

            // Create TextBlock to display restaurant name
            TextBlock textBlock = new TextBlock();
            textBlock.Text = name;
            textBlock.Margin = new Thickness(5);
            textBlock.FontSize = 20;
            textBlock.Foreground = Brushes.Black; // Set text color

            // Set Grid.Column for elements
            Grid.SetColumn(textBlock, 0);

            // Add elements to the Grid
            grid.Children.Add(textBlock);
            // Set Grid as the content of the ListBoxItem
            newItem.Content = grid;

            // Add ListBoxItem to the ListBox
            lstvrest.Items.Add(newItem);
        }

        private void AdminOptions(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
