using FM.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Domain.Model.Entities
{
    public class User : BaseEntity
    {
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
    }
}
