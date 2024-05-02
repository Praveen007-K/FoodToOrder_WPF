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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }


        private void AddRest(object sender, RoutedEventArgs e)
        {
            AddRestWindow arw = new AddRestWindow();
            arw.Show();
        }

        private void EditRest(object sender, RoutedEventArgs e)
        {
            EditRestWindow erw = new EditRestWindow();
            erw.Show();
        }

        private void ViewRest(object sender, RoutedEventArgs e)
        {
            ViewRestWindow vw = new ViewRestWindow();
            vw.ViewRestaurant();
            vw.Show();
        }

        private void DeleteRest(object sender, RoutedEventArgs e)
        {
            DeleteRestWindow drw = new DeleteRestWindow();
            drw.Show();
        }

        private void AddDish(object sender, RoutedEventArgs e)
        {
            AddDishWindow adw = new AddDishWindow();
            adw.Show();
        }

        private void EditDish(object sender, RoutedEventArgs e)
        {
            EditDishWindow edw = new EditDishWindow();
            edw.Show();
        }

        private void ViewDish(object sender, RoutedEventArgs e)
        {
            ViewDishWindow vd = new ViewDishWindow();
            vd.ViewDishes();
            vd.Show();
        }

        private void Deldish(object sender, RoutedEventArgs e)
        {
            DeleteDishWindow ddw = new DeleteDishWindow();
            ddw.Show();
        }
    }
}
