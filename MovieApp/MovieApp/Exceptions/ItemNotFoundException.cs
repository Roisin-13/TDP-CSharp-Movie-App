﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Exceptions
{
    class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() : base()
        {
        }

        public ItemNotFoundException(string message) : base(message)
        {
        }



    }


}