//using System.Collections.Generic;
//using System.IO;
//using System.Windows;
//using iText.Kernel.Exceptions;
//using iText.Kernel.Pdf;
//using iText.Layout;
//using iText.Layout.Element;
//using Microsoft.Win32;

//namespace FoodToOrderAppWPF
//{
//    public partial class BillWindow : Window
//    {
//        public class BillItem
//        {
//            public string Dish { get; set; }
//            public string Price { get; set; }
//            public decimal Quantity { get; set; }

//            public decimal Total { get; set; }
//            public decimal Sum { get; set; }
//        }

//        public List<BillItem> SelectedItems { get; set; }

//        public BillWindow(List<BillItem> selectedItems)
//        {
//            InitializeComponent();
//            SelectedItems = selectedItems;
//            lstBill.ItemsSource = SelectedItems;
//            DataContext = this;
//        }

//        //Untaugh feature - PDF BILL
//        private void Order_Click(object sender, RoutedEventArgs e)
//        {
//            MessageBox.Show("Order Placed Successfully");
//        }


//    private void MenuOptions(object sender, RoutedEventArgs e)
//        {
//            Close();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.Win32;

namespace FoodToOrderAppWPF
{
    public partial class BillWindow : Window
    {
        public class BillItem
        {
            public string Dish { get; set; }
            public string Price { get; set; }
            public decimal Quantity { get; set; }
            public decimal Total { get; set; }
            public decimal Sum { get; set; }
        }

        public List<BillItem> SelectedItems { get; set; }

        public BillWindow(List<BillItem> selectedItems)
        {
            InitializeComponent();
            SelectedItems = selectedItems;
            lstBill.ItemsSource = SelectedItems;
            DataContext = this;
        }

        // Generate PDF Bill
        private void GeneratePDFBill(string filePath)
        {
            try
            {
                using (var writer = new PdfWriter(filePath))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);
                        document.Add(new Paragraph("Bill"));

                        // Add items to the PDF
                        foreach (var item in SelectedItems)
                        {
                            document.Add(new Paragraph($"Dish: {item.Dish}, Price: {item.Price}, Quantity: {item.Quantity}, Total: {item.Total}"));
                        }

                        document.Close();
                    }
                }

                MessageBox.Show("PDF bill generated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF bill: {ex.ToString()}");
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            // Generate PDF bill
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                GeneratePDFBill(saveFileDialog.FileName);
            }

            MessageBox.Show("Order Placed Successfully");
        }

        private void MenuOptions(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
