using projSchoolService.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projSchoolService.Models.Concretes
{
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool HasLicence { get; set; }

        public string Adress { get; set; } = null!;

        public virtual Car? Car { get; set; }
        
        public int? CarId { get; set; }

        public virtual Ride? Ride { get; set; }

        public int? RideId { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
