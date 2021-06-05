using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Client : Person
    {
        public string Company { get; set; }
    }
}
