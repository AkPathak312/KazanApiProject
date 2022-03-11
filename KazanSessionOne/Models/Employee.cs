using System;
using System.Collections.Generic;

namespace KazanSessionOne.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Assets = new HashSet<Asset>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
