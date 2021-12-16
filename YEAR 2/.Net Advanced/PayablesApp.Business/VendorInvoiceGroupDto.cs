using PayablesApp.Domain;
using System.Linq;

namespace PayablesApp.Business
{
    public class VendorInvoiceGroupDto
    {
        public int VendorId { get; set; }
        public int Count { get; set; }
        public IGrouping<int, Invoice> Invoices { get; internal set; }
    }
}
