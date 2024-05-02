
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

//namespace FoodToOrderAppWPF.Controls
//{
//    public partial class CountIncrementer : UserControl
//    {
//        public int Count
//        {
//            get { return (int)GetValue(CountProperty); }
//            set { SetValue(CountProperty, value); }
//        }

//        public static readonly DependencyProperty CountProperty =
//            DependencyProperty.Register("Count", typeof(int), typeof(CountIncrementer), new PropertyMetadata(0));

//        public CountIncrementer()
//        {
//            InitializeComponent();
//            DataContext = this;
//        }

//        private void Increment_Click(object sender, RoutedEventArgs e)
//        {
//            Count++;
//        }

//        private void Decrement_Click(object sender, RoutedEventArgs e)
//        {
//            if (Count > 0)
//                Count--;
//        }
//    }
//}


namespace FoodToOrderAppWPF.Controls
{
    public partial class CountIncrementer : UserControl
    {
        public event EventHandler IncrementClicked;
        public event EventHandler DecrementClicked;

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register("Count", typeof(int), typeof(CountIncrementer), new PropertyMetadata(0));

        public CountIncrementer()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            Count++;
            IncrementClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Decrement_Click(object sender, RoutedEventArgs e)
        {
            if (Count > 0)
            {
                Count--;
                DecrementClicked?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
