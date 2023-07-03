using projSchoolService.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projSchoolService.Models.Concretes
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        
        public string Adress { get; set; } = null!;

        public virtual Ride? Ride { get; set; }

        public int? RideId { get; set; }
  

        public virtual Parent? Parent { get; set; }

        public int ParentId { get; set; }

        public virtual Class? Class { get; set; }
        public int? ClassId { get; set; }  
    }
}
