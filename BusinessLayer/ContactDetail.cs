using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using eShop.DomainClasses.enums;

namespace eShop.DomainClasses
{
    public class ContactDetail
    {
        [Key]
        public int ContactDetailId;
        public int CustomerId;
        public string ContactDescription;
        public string PhoneNumber;
        public string Email;
        public ContactDetailTypes ContactDetailType;
    }
}
