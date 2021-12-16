using PayablesApp.Business.Contracts;
using PayablesApp.Domain;
using System;
using System.Collections.Generic;

namespace PayablesApp.Data
{
    internal class InMemoryInvoiceRepository: IInvoiceRepository
    {
        private readonly List<Invoice> _dummyInvoices;

        public InMemoryInvoiceRepository()
        {
            _dummyInvoices = new List<Invoice>();
            for (int i = 1; i <= 5; i++)
            {
                _dummyInvoices.Add(CreateDummyInvoiceWithoutBalanceDue(i));
            }
            for (int i = 6; i <= 10; i++)
            {
                _dummyInvoices.Add(CreateDummyInvoiceWithBalanceDue(i));
            }
        }

        public IReadOnlyList<Invoice> GetAll()
        {
            return _dummyInvoices;
        }

        private Invoice CreateDummyInvoiceWithoutBalanceDue(int identifier)
        {
            return new Invoice
            {
                InvoiceId = identifier,
                InvoiceDate = DateTime.Today.AddDays(-20),
                InvoiceNumber = "989319-457",
                VendorId = 1,
                DueDate = DateTime.Today.AddDays(30),
                InvoiceTotal = 25000,
                CreditTotal = 2000,
                PaymentTotal = 8000,
                PaymentDate = DateTime.Today.AddDays(-1)               
            };
        }

        private Invoice CreateDummyInvoiceWithBalanceDue(int identifier)
        {
            return new Invoice
            {
                InvoiceId = identifier,
                InvoiceDate = DateTime.Today.AddDays(-40),
                InvoiceNumber = "263253241",
                VendorId = 2,
                DueDate = DateTime.Today.AddDays(-10),
                InvoiceTotal = 20000,
                CreditTotal = 1000,
                PaymentTotal = 5000,
                PaymentDate = DateTime.Today.AddDays(-5)
            };
        }
    }
}
