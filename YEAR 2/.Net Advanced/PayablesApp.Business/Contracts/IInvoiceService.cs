using PayablesApp.Domain;
using System.Collections.Generic;

namespace PayablesApp.Business
{
    public interface IInvoiceService
    {
        IList<Invoice> GetBigInvoices();
        decimal GetInvoicesTotal();
        IList<InvoiceBalanceDto> GetInvoicesDue();
        IList<InvoiceDto> GetBigInvoices2();
        IList<VendorInvoiceGroupDto> GetGroupedInvoices();
    }
}
