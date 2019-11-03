using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mitraisBiz.Entities
{
    class User
    {
        public virtual int Id { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual int Sex { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual string UpdatedBy { get; set; }
    }
}
