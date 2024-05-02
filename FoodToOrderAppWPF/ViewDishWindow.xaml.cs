
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
    /// Interaction logic for ViewDishes.xaml
    /// </summary>
    public partial class ViewDishWindow : Window
    {
        public ViewDishWindow()
        {
            InitializeComponent();
        }

        public void ViewDishes()
        {
            SqlConnection con = new SqlConnection("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Praveen;User=sa;Password=sa@1234;TrustServerCertificate=true;MultipleActiveResultSets=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[Dish]", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                //&& Convert.ToBoolean(dataSet.Tables[0].Rows[i]["Availability"]
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    AddDish(dataSet.Tables[0].Rows[i]["Id"].ToString(), dataSet.Tables[0].Rows[i]["DishName"].ToString(), " Rs " + dataSet.Tables[0].Rows[i]["Price"].ToString());

                }

            }
            con.Close();
        }

        public void AddDish(string id, string name, string price)
        {
            // Create ListBoxItem
            ListBoxItem newItem = new ListBoxItem();

            // Create Grid to hold elements
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(60, GridUnitType.Pixel) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(170, GridUnitType.Pixel) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(120, GridUnitType.Pixel) });

            // Create TextBlock to display restaurant name
            TextBlock textBlock = new TextBlock();
            textBlock.Text = id;
            textBlock.Margin = new Thickness(5);
            textBlock.FontSize = 20;
            textBlock.Foreground = Brushes.RoyalBlue; // Set text color

            TextBlock textBlock2 = new TextBlock();
            textBlock2.Text = name;
            textBlock2.Margin = new Thickness(5);
            textBlock2.FontSize = 20;
            textBlock2.Foreground = Brushes.RoyalBlue;

            TextBlock textBlock3 = new TextBlock();
            textBlock3.Text = price;
            textBlock3.Margin = new Thickness(5);
            textBlock3.FontSize = 20;
            textBlock3.Foreground = Brushes.RoyalBlue;

            // Set Grid.Column for elements
            Grid.SetColumn(textBlock, 0);
            Grid.SetColumn(textBlock2, 1);
            Grid.SetColumn(textBlock3, 2);

            // Add elements to the Grid
            grid.Children.Add(textBlock);
            grid.Children.Add(textBlock2);
            grid.Children.Add(textBlock3);
            // Set Grid as the content of the ListBoxItem
            newItem.Content = grid;

            // Add ListBoxItem to the ListBox
            lstvdish.Items.Add(newItem);
        }

        //public void AddDish(string id)
        //{
        //    // Create ListBoxItem
        //    ListBoxItem newItem = new ListBoxItem();

        //    // Create Grid to hold elements
        //    Grid grid = new Grid();
        //    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200, GridUnitType.Pixel) });

        //    // Create TextBlock to display restaurant name
        //    TextBlock textBlock = new TextBlock();
        //    textBlock.Text = id;
        //    textBlock.Margin = new Thickness(5);
        //    textBlock.FontSize = 20;
        //    textBlock.Foreground = Brushes.RoyalBlue; 

        //    // Set Grid.Column for elements
        //    Grid.SetColumn(textBlock, 0);

        //    // Add elements to the Grid
        //    grid.Children.Add(textBlock);
        //    // Set Grid as the content of the ListBoxItem
        //    newItem.Content = grid;

        //    // Add ListBoxItem to the ListBox
        //    lstvdish.Items.Add(newItem);
        //}
        private void AdminOptions(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}