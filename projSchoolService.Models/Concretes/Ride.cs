using projSchoolService.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projSchoolService.Models.Concretes
{
    public class Ride : BaseEntity
    {
        public string NameRide { get; set; } = null!;
        public int StudentId { get; set; }

        public virtual Driver? Driver { get;set; }

        public virtual ObservableCollection<Student> Students { get; set; } 
    }
}
