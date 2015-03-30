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
    public class Customer : ItemState
    {
        private ICollection<Address> _addresses;
        private ICollection<Review> _customerReviews;
        private ICollection<ContactDetail> _contactDetails;

        public Customer()
        {
            _addresses = new List<Address>();
            _contactDetails = new List<ContactDetail>();
            _customerReviews = new List<Review>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Address> Addresses 
        { 
            get { return _addresses; } 
            set { _addresses = value; } 
        }
        public virtual ICollection<ContactDetail> ContactDetails 
        { 
            get { return _contactDetails;}
            set { _contactDetails = value; } 
        }

        public ICollection<Review> CustomerReviews
        {
            get { return _customerReviews.Where(c => c.CustomerId == this.CustomerId).ToList(); }
            set { _customerReviews = (List<Review>) value; }
        }

        public byte[] RowVersion { get; set; }

    }


}
