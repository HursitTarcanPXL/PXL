using PayablesApp.Business.Contracts;
using PayablesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayablesApp.Business
{
    internal class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IVendorRepository _vendorRepository;

        private IReadOnlyList<Invoice> _allInvoices;
        private IReadOnlyList<Vendor> _allVendors;

        private IReadOnlyList<Invoice> AllInvoices
        {
            get
            {
                if (_allInvoices == null)
                {
                    _allInvoices = _invoiceRepository.GetAll();
                }
                return _allInvoices;
            }
        }
        private IReadOnlyList<Vendor> AllVendors
        {
            get
            {
                if (_allVendors == null)
                {
                    _allVendors = _vendorRepository.GetAll();
                }
                return _allVendors;
            }
        }

        public InvoiceService(IInvoiceRepository invoiceRepository, IVendorRepository vendorRepository)
        {
            _invoiceRepository = invoiceRepository;
            _vendorRepository = vendorRepository;
        }

        public IList<Invoice> GetBigInvoices()
        {
            //Define the query expression
            var invoicesQuery = from invoice in AllInvoices
                where invoice.InvoiceTotal > 20000
                orderby invoice.InvoiceTotal descending
                select invoice;

            ////Method syntax alternative:
            //var invoicesQuery = AllInvoices.Where(invoice => invoice.InvoiceTotal > 2000)
            //    .OrderByDescending(invoice => invoice.InvoiceTotal);

            //Execute the query
            IList<Invoice> invoices = new List<Invoice>();
            foreach (var item in invoicesQuery) //triggers query execution
            {
                invoices.Add(item);
            }
            return invoices;
            // Shorter (better) alternative:
            // return invoicesQuery.ToList();
        }

        public decimal GetInvoicesTotal()
        {
            var invoiceQuery = from invoice in AllInvoices
                select invoice;

            decimal sum = 0;

            //Execute the query
            foreach (var invoice in invoiceQuery) //triggers query execution
            {
                sum += invoice.InvoiceTotal;
            }
            return sum;

            ////Alternative using Linq aggregate method (Sum):
            //decimal sum = AllInvoices.Select(invoice => invoice.InvoiceTotal).Sum();
            ////Or:
            //decimal sum = AllInvoices.Sum(invoice => invoice.InvoiceTotal);
        }

        public IList<InvoiceBalanceDto> GetInvoicesDue()
        {
            //Define the query expression
            var invoiceDueQuery = from invoice in AllInvoices
                                  where invoice.BalanceDue > 0 &&
                                        invoice.DueDate < DateTime.Today.AddDays(15)
                                  orderby invoice.BalanceDue, invoice.InvoiceNumber
                                  select new
                                  {
                                      Number = invoice.InvoiceNumber,
                                      invoice.BalanceDue,
                                      BalanceDone = invoice.CreditTotal + invoice.PaymentTotal //balanceDone
                                  };

            ////Method syntax alternative:
            //var invoiceDueQuery = AllInvoices
            //    .Where(invoice => invoice.BalanceDue > 0 && invoice.DueDate < DateTime.Today.AddDays(15))
            //    .OrderBy(invoice => invoice.BalanceDue).ThenBy(invoice => invoice.InvoiceNumber)
            //    .Select(invoice => new
            //    {
            //        Number = invoice.InvoiceNumber,
            //        invoice.BalanceDue,
            //        BalanceDone = invoice.CreditTotal + invoice.PaymentTotal //balanceDone
            //    });

            //Execute the query
            IList<InvoiceBalanceDto> invoicesDue = new List<InvoiceBalanceDto>();
            foreach (var item in invoiceDueQuery) //triggers query execution
            {
                InvoiceBalanceDto invoiceDue = new InvoiceBalanceDto
                {
                    InvoiceNumber = item.Number,
                    BalanceDue = item.BalanceDue,
                    BalanceDone = item.BalanceDone
                };
                invoicesDue.Add(invoiceDue);
            }
            return invoicesDue;

            ////Shorter alternative:
            //var invoiceDueQuery = from invoice in AllInvoices
            //    where invoice.BalanceDue > 0 &&
            //          invoice.DueDate < DateTime.Today.AddDays(15)
            //    orderby invoice.BalanceDue, invoice.InvoiceNumber
            //    select new InvoiceBalanceDto
            //    {
            //        InvoiceNumber = invoice.InvoiceNumber,
            //        BalanceDue = invoice.BalanceDue,
            //        BalanceDone = invoice.CreditTotal + invoice.PaymentTotal 
            //    };
            //return invoiceDueQuery.ToList();
        }

        public IList<InvoiceDto> GetBigInvoices2()
        {
            //Define the query expression
            var bigInvoicesQuery = from invoice in AllInvoices
                                   join vendor in AllVendors on invoice.VendorId equals vendor.VendorId
                                   where invoice.InvoiceTotal > 20000
                                   orderby invoice.InvoiceTotal descending
                                   select new InvoiceDto
                                   {
                                       VendorName = vendor.Name,
                                       InvoiceNumber = invoice.InvoiceNumber,
                                       InvoiceTotal = invoice.InvoiceTotal
                                   };

            //Execute the query
            IList<InvoiceDto> bigInvoices = bigInvoicesQuery.ToList(); //triggers query execution
            return bigInvoices;
        }

        public IList<VendorInvoiceGroupDto> GetGroupedInvoices()
        {
            //Define the query expression
            var groupedInvoicesQuery = from invoice in AllInvoices
                                       where invoice.InvoiceTotal > 9000
                                       group invoice by invoice.VendorId into vendorGroup
                                       select new VendorInvoiceGroupDto
                                       {
                                           VendorId = vendorGroup.Key,
                                           Count = vendorGroup.Count(),
                                           Invoices = vendorGroup
                                       };

            //Execute the query
            IList<VendorInvoiceGroupDto> groupedInvoices = groupedInvoicesQuery.ToList(); //triggers query execution
            return groupedInvoices;
        }

    }
}
