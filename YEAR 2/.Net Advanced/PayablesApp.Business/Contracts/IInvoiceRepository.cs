using PayablesApp.Domain;
using System.Collections.Generic;

namespace PayablesApp.Business.Contracts
{
    public interface IInvoiceRepository
    {
        IReadOnlyList<Invoice> GetAll();
    }
}
