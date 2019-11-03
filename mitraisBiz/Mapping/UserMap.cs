using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using mitraisBiz.Entities;

namespace mitraisBiz.Mapping
{
    class UserMap : ClassMap<User>
    {
        //Constructor
        public UserMap() 
        {
            Id(x => x.Id);
            Map(x => x.MobileNumber);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.DateOfBirth);
            Map(x => x.Sex);
            Map(x => x.Email);
            Map(x => x.Password);
            Map(x => x.CreatedDate);
            Map(x => x.CreatedBy);
            Map(x => x.UpdatedDate);
            Map(x => x.UpdatedBy);

            Table("Users");
        }
    }
}
