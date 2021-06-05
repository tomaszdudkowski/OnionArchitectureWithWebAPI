using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public abstract class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
