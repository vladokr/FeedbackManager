using FM.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FM.Domain.Model.Entities
{
    [DataContract]
    public class User : BaseEntity
    {
        [DataMember]
        public string UserLogin { get; set; }

        [IgnoreDataMember]
        public string UserPassword { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int? RoleId { get; set; }
    }
}
