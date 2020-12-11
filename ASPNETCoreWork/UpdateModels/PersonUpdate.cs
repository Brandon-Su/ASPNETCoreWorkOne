using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWork.UpdateModels
{
    public class PersonUpdate
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Discriminator { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
