using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWork.UpdateModels
{
    public class EnrollmentUpdate
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int? Grade { get; set; }
    }
}
