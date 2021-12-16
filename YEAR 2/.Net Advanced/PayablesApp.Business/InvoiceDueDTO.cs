using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayablesApp.Business
{
    public class InvoiceDueDTO
    {
        public string InvoiceNumber { get; set; }
        public decimal BalanceDue { get; set; }
        public decimal BalanceDone { get; set; }
    }
}
