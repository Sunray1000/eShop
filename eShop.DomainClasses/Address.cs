using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.enums;

namespace eShop.DomainClasses
{
    public class Address
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostalZipCode { get; set; }
        public List<string> Country { get; set; }
        public AddressType AddressType { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
