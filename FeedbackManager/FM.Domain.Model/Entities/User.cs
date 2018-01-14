using FM.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FM.Domain.Model.Entities
{
    [DataContract]
    public class User : BaseEntity
    {
        [DataMember]
        [MaxLength(20)]
        [Required]
        public string UserLogin { get; set; }

        [IgnoreDataMember]
        [MaxLength(20)]
        [Required]
        public string UserPassword { get; set; }

        [DataMember]
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [MaxLength(200)]
        [Required]
        public string Surname { get; set; }

        [DataMember]
        [MaxLength(200)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataMember]
        [Required]
        public int? RoleId { get; set; }
    }
}
