﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.enums;

namespace eShop.DomainClasses
{
    public class Address
    {
        public string Name;
        public string AddressLine1;
        public string AddressLine2;
        public string AddressLine3;
        public string PostalZipCode;
        public List<string> Country;
        public AddressType AddressType;
    }
}
