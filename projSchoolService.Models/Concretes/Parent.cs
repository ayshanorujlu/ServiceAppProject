using projSchoolService.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projSchoolService.Models.Concretes
{
    public class Parent:BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public ICollection<Student>  Students { get; set; }
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
