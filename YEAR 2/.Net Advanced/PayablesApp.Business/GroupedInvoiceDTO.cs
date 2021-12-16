using PayablesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayablesApp.Business
{
    public class GroupedInvoiceDTO
    {
        public int VendorID { get; set; }
        public int Count { get; set; }
        public IGrouping<int, Invoice> Invoices { get; internal set; }
    }
}
