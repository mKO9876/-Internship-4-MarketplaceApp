﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    public abstract class Person
    {
        public string username;
        public string email;

        public abstract void Print();
    }
}
