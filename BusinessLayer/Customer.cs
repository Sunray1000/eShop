using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using eShop.enums;

namespace eShop.DomainClasses
{
    public class Customer
    {
        Customer()
        {
            Addresses = new List<Address>();
        }
        [Key]
        public int CustomerId;
        public string FirstName;
        public string LastName;
        public string UserName;
       
        private List<ContactDetail> _contactDetails;
       
        public SecureString Password;

        public ICollection<Address> Addresses { get; set; }

        public ICollection<ContactDetail> ContactDetails
        {
            get { return _contactDetails; }
            set { _contactDetails = (List<ContactDetail>) value; }
        }

    }


}
