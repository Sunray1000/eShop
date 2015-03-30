using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using eShop.DomainClasses.enums;

namespace eShop.DomainClasses
{
    public class ContactDetail : ItemState
    {
        public int ContactDetailId { get; set; }
        public int CustomerId { get; set; }
        public string ContactDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ContactDetailTypes ContactDetailType { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
