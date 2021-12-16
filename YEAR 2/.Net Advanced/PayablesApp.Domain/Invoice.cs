using System;

namespace PayablesApp.Domain
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int VendorId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceTotal { get; set; }
        public decimal PaymentTotal { get; set; }
        public decimal CreditTotal { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal BalanceDue => InvoiceTotal - PaymentTotal - CreditTotal;
    }
}
