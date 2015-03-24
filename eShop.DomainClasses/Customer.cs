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
            _contactDetails = new List<ContactDetail>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public ICollection<Address> Addresses { get; set; }

        private List<ContactDetail> _contactDetails;
        public ICollection<ContactDetail> ContactDetails
        {
            get { return _contactDetails; }
            set { _contactDetails = (List<ContactDetail>) value; }
        }

        private List<Review> _customerReviews;

        public ICollection<Review> CustomerReviews
        {
            get { return _customerReviews.Where(c => c.CustomerId == this.CustomerId).ToList(); }
            set { _customerReviews = (List<Review>) value; }
        }

    }


}
