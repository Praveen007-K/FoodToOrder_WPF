using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
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
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace FoodToOrderAppWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        //public List<User> users;
        public Login()
        {
            InitializeComponent();
            //    FoodToOrderWpfPraveenContext us = new FoodToOrderWpfPraveenContext();
            //    users = us.Users.ToList<User>();

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
    {
            RestaurantWindow rw = new RestaurantWindow();
            AdminWindow aw = new AdminWindow();
            Restaurant r = new Restaurant();
        if (Username.Text.Length == 0)
        {
            errormessage.Text = "Enter an email.";
            Username.Focus();
        }
        else if (!Regex.IsMatch(Username.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
        {
            errormessage.Text = "Enter a valid email.";
                Username.Select(0, Username.Text.Length);
                Username.Focus();
        }
        else
        {
            string email = Username.Text;
            string password = Userpw.Password;
            SqlConnection con = new SqlConnection("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Praveen;User=sa;Password=sa@1234;TrustServerCertificate=true;MultipleActiveResultSets=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [dbo].[User] where Email='" + email + "'  and password='" + password + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();
                    //rw.TextBlockName.Text = username;//Sending value from one form to another form.  
                    string rr = dataSet.Tables[0].Rows[0]["Role"].ToString();
                if (dataSet.Tables[0].Rows[0]["Role"].ToString()=="User")
                    {
                        rw.Restaurant_Display();
                        rw.welcome.Text = "Greetings " + dataSet.Tables[0].Rows[0]["FirstName"];
                        rw.Show();
                    }
                else
                    {
                        aw.welcome.Text = "Greetings " + dataSet.Tables[0].Rows[0]["FirstName"];
                        aw.Show();
                    }
                Close();
            }
            else
            {
                errormessage.Text = "Sorry! Please enter existing emailid/password.";
            }
            con.Close();
        }
    }
}
}
