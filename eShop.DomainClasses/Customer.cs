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
        public Customer()
        {
            Addresses = new List<Address>();
            ContactDetails = new List<ContactDetail>();
            _customerReviews = new List<Review>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }

        private List<Review> _customerReviews;
        public ICollection<Review> CustomerReviews
        {
            get { return _customerReviews.Where(c => c.CustomerId == this.CustomerId).ToList(); }
            set { _customerReviews = (List<Review>) value; }
        }

        public byte[] RowVersion { get; set; }

    }


}
