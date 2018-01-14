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
    public class GameSession : BaseEntity
    {
        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]
        public int? GameId { get; set; }

        [DataMember]
        public Guid SessionIdentifier { get; set; }
    }
}
