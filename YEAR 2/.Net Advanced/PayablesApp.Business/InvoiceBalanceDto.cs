namespace PayablesApp.Business
{
    public class InvoiceBalanceDto
    {
        public string InvoiceNumber { get; set; }
        public decimal BalanceDue { get; set; }
        public decimal BalanceDone { get; set; }
    }
}
