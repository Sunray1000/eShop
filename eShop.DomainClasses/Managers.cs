using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainClasses
{
    public class Managers : ItemState
    {
        public int ManagerID { get; set; }
        public string UserName { get; set; }
        public SecureString Password { get; set; }
    }
}
