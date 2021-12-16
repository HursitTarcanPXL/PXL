using PayablesApp.Business.Contracts;
using PayablesApp.Domain;
using System.Collections.Generic;

namespace PayablesApp.Data
{
    internal class InMemoryVendorRepository : IVendorRepository
    {
        private readonly List<Vendor> _dummyVendors;

        public InMemoryVendorRepository()
        {
            _dummyVendors = new List<Vendor>();
            for (int i = 1; i <= 10; i++)
            {
                _dummyVendors.Add(CreateDummyVendor(i));
            }
        }

        public IReadOnlyList<Vendor> GetAll()
        {
            return _dummyVendors;
        }

        private Vendor CreateDummyVendor(int identifier)
        {
            return new Vendor
            {
                VendorId = identifier,
                Name = $"Small Press{identifier}",
                Address1 = $"Dorpstraat {identifier}",
                City = "Hasselt",
                ZipCode = "3500",
                ContactFirstName = "Jan",
                ContactLastName = "Janssens"                 
            };
        }
    }
}
