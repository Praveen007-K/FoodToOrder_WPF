using FoodToOrderAppWPF.Controls;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FoodToOrderAppWPF
{
    /// <summary>
    /// Interaction logic for Restaurant.xaml
    /// </summary>
    /// 
    public partial class DishWindow : Window
    {

        public DishWindow()
        {
            InitializeComponent();
        }



        public void Dish_Display(int x)
        {
            SqlConnection con = new SqlConnection("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Praveen;User=sa;Password=sa@1234;TrustServerCertificate=true;MultipleActiveResultSets=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[Dish] where Availability='true' and RestaurantId=" + x, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    AddDish(dataSet.Tables[0].Rows[i]["DishName"].ToString(), dataSet.Tables[0].Rows[i]["Price"].ToString(), dataSet.Tables[0].Rows[i]["Id"].ToString());
                }

            }
            con.Close();
        }

        decimal total;
        decimal sum;
        public void AddDish(string name, string price, string imgid)
        {
            // Create ListBoxItem
            ListBoxItem newItem = new ListBoxItem();
            ListBoxItem newItem2 = new ListBoxItem();

            // Create Grid to hold elements
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200, GridUnitType.Pixel) }); // For restaurant name
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100, GridUnitType.Pixel) }); // For button
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(75, GridUnitType.Pixel) }); // For image column
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });

            // Create TextBlock to display restaurant name
            TextBlock textBlock = new TextBlock();
            textBlock.Text = name;
            textBlock.Margin = new Thickness(5);
            textBlock.FontSize = 20;
            textBlock.Foreground = Brushes.Black; // Set text color

            TextBlock textBlock2 = new TextBlock();
            textBlock2.Text = price;
            textBlock2.Margin = new Thickness(5);
            textBlock2.FontSize = 20;
            textBlock2.Foreground = Brushes.Black;

            CountIncrementer countIncrementer = new CountIncrementer();
            countIncrementer.IncrementClicked += (sender, e) =>
            {
                // Access the count value of the CountIncrementer attached to this dish
                int count = countIncrementer.Count;
                // Do whatever you want with the incremented count value
                Console.WriteLine($"Incremented count for {name}: {count}");
            };
            countIncrementer.DecrementClicked += (sender, e) =>
            {
                // Access the count value of the CountIncrementer attached to this dish
                int count = countIncrementer.Count;
                // Do whatever you want with the decremented count value
                Console.WriteLine($"Decremented count for {name}: {count}");
            };

            // Create Button in the existing column
            Button button = new Button();
            button.Content = countIncrementer;
            button.Margin = new Thickness(10);
            button.FontSize = 16;
            button.Background = Brushes.RoyalBlue; // Set button background color
            button.Foreground = Brushes.White; // Set button text color
            button.BorderBrush = Brushes.Transparent; // Remove button border
            button.Padding = new Thickness(5);
            // button.Template = (ControlTemplate)Application.Current.Resources["RoundButtonTemplate"]; // You may need to uncomment this line if you are using a custom button template.

            // Create Image in the additional column
            string imagePath = "Images/" + imgid.Trim() + ".jfif";
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            image.Stretch = Stretch.Uniform; // Adjust as needed
            image.Height = 50;
            image.Width = 50;

            Grid.SetColumn(textBlock, 0);
            Grid.SetColumn(textBlock2, 1);
            Grid.SetColumn(button, 2);
            Grid.SetColumn(image, 3);

            // Add elements to the Grid
            grid.Children.Add(textBlock);
            grid.Children.Add(textBlock2);
            grid.Children.Add(button);
            grid.Children.Add(image);

            // Set Grid as the content of the ListBoxItem
            newItem.Content = grid;

            // Add ListBoxItem to the ListBox
            lstdish.Items.Add(newItem);
        }
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            List<BillWindow.BillItem> selectedItems = new List<BillWindow.BillItem>();

            // Iterate through each ListBoxItem to gather selected dishes and their counts
            foreach (ListBoxItem item in lstdish.Items)
            {
                Grid grid = item.Content as Grid;
                if (grid != null)
                {
                    // Extract dish name from the first TextBlock
                    TextBlock dishNameTextBlock = grid.Children[0] as TextBlock;
                    TextBlock dishPriceTextBlock = grid.Children[1] as TextBlock;
                    if (dishNameTextBlock != null)
                    {
                        string dishName = dishNameTextBlock.Text;
                        string Price = dishPriceTextBlock.Text;

                        // Extract CountIncrementer from the Button control
                        Button button = grid.Children[2] as Button;
                        if (button != null && button.Content is CountIncrementer)
                        {
                            CountIncrementer countIncrementer = button.Content as CountIncrementer;
                            int count = countIncrementer.Count;

                            // Add the selected dish and its count to the list
                            if (count > 0)
                            {
                                total = Convert.ToDecimal(Price) * count;
                                sum += total;
                                selectedItems.Add(new BillWindow.BillItem() { Dish = dishName,Price = Price, Quantity = count, Total=total, Sum=sum });
                            }
                        }
                    }
                }
            }


        // Show the bill window with selected items
        BillWindow billWindow = new BillWindow(selectedItems);
            billWindow.billtotal.Text = sum.ToString();
            billWindow.Show();
        }

        private void RestOptions(object sender, RoutedEventArgs e)
        {
            Close();
            RestaurantWindow r = new RestaurantWindow();
            r.Restaurant_Display();
            r.Show();
        }
    }

}
