using FM.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FM.Domain.Model.Entities
{
    [DataContract]
    public class Feedback : BaseEntity
    {
        [DataMember]
        [Required]
        public int Rating { get; set; }

        [DataMember]
        [MaxLength(500)]
        public string Comment { get; set; }

        [DataMember]
        public int? UserId { get; set; }

        [DataMember]
        public int? GameSessionId { get; set; }

        #region Non persistent properties
        public string UserLogin { get; set; }
        public Guid SessionIdentifier { get; set; }
        #endregion

    }
}
