using System;
using System.Collections.Generic;

namespace Cafe.Domain
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public int? Age { get; set; }

        public string? Education { get; set; }

        public int ProfessionId { get; set; }

        public virtual Profession Profession { get; set; } = null!;
    }
}
