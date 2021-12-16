using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayablesApp.Business
{
    public class BigInvoiceDTO
    {
        public string VendorName { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal InvoiceTotal { get; set; }
    }
}
