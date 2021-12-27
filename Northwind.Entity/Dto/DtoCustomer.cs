using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Entity.Dto
{
    public class DtoCustomer : DtoBase
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
