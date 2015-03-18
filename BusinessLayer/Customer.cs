using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using BusinessLayer.enums;

namespace BusinessLayer
{
    public class Customer
    {
        Customer()
        {
            _address = new List<Address>();
        }

        private ICollection<Address> _address;
        public int CustomerID;
        public string FirstName;
        public string LastName;
        public string UserName;
        public SecureString password;
        public string Email;

        public ICollection<Address> Addresses
        {
            get{ return _address; }
            set{ _address = value; }
        }


    }


}
