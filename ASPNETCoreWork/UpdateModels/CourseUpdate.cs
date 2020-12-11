using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWork.UpdateModels
{
    public class CourseUpdate
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
