using PayablesApp.Business;
using PayablesApp.Domain;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PayablesApp.UI
{
    public partial class MainWindow : Window
    {
        private readonly IInvoiceService _invoiceService;


        public MainWindow(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
            InitializeComponent();
        }

        private void ShowBigInvoicesButton_OnClick(object sender, RoutedEventArgs e)
        {
            IList<Invoice> bigInvoices = _invoiceService.GetBigInvoices();

            var resultBuilder = new StringBuilder("Invoice No.\tBalance due\tBalance done");
            resultBuilder.AppendLine();
            foreach (var item in bigInvoices) 
            {
                resultBuilder.AppendLine($"{item.InvoiceNumber}\t{item.BalanceDue}\t\t" +
                    $"{item.InvoiceTotal:C}");
            }
            MessageBox.Show(resultBuilder.ToString(), "Invoices > 20000");
        }

        private void ShowInvoicesSumButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_invoiceService.GetInvoicesTotal().ToString("C"),"Sum of invoices");
        }

        private void ShowInvoicesDueButton_OnClick(object sender, RoutedEventArgs e)
        {
            IList<InvoiceBalanceDto> invoicesDue = _invoiceService.GetInvoicesDue();

            var resultBuilder = new StringBuilder("Invoice No.\tBalance due\tBalance done");
            resultBuilder.AppendLine();
            foreach (var item in invoicesDue)
            {
                resultBuilder.AppendLine($"{item.InvoiceNumber.PadRight(15)}\t{item.BalanceDue:C}\t{item.BalanceDone:C}");
            }
            MessageBox.Show(resultBuilder.ToString(), "Invoices Due");
        }

        private void ShowGroupedInvoicesButton_OnClick(object sender, RoutedEventArgs e)
        {
            IList<VendorInvoiceGroupDto> groupedInvoices = _invoiceService.GetGroupedInvoices();

            var resultBuilder = new StringBuilder("Vendor Id (#invoices)\t\tInvoice No.\tInvoice Total");
            resultBuilder.AppendLine();
            foreach (var vendorInfo in groupedInvoices) 
            {
                resultBuilder.AppendLine($"{vendorInfo.VendorId} ({vendorInfo.Count})");
                foreach (var invoice in vendorInfo.Invoices)
                {
                    resultBuilder.AppendLine($"\t\t\t{invoice.InvoiceNumber.PadRight(15)}\t{invoice.InvoiceTotal:C}");
                }
            }
            MessageBox.Show(resultBuilder.ToString(), "Invoices grouped by Vendor");
        }

        private void ShowBigInvoicesWithVendorButton_OnClick(object sender, RoutedEventArgs e)
        {
            IList<InvoiceDto> bigInvoices = _invoiceService.GetBigInvoices2();

            var resultBuilder = new StringBuilder("Vendor Name\tInvoice Number\t\tInvoice Total");
            resultBuilder.AppendLine();
            foreach (var item in bigInvoices)
            {
                resultBuilder.AppendLine($"{item.VendorName}\t{item.InvoiceNumber}\t\t{item.InvoiceTotal:C}");
            }
            MessageBox.Show(resultBuilder.ToString(), "Invoices with Vendor > 20000");

        }
    }
}
