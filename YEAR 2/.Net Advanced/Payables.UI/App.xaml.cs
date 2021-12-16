using System.Windows;
using PayablesApp.Business;
using PayablesApp.Data;

namespace PayablesApp.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var vendorRepository = new InMemoryVendorRepository();
            var invoiceRepository = new InMemoryInvoiceRepository();

            var service = new InvoiceService(invoiceRepository, vendorRepository);

            MainWindow mainWindow = new MainWindow(service);
            mainWindow.Show();
        }
    }
}
