using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FM.Domain.Model.Common
{
    [DataContract]
    public abstract class BaseEntity
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public DateTime? CreateDate { get; set; }

        [DataMember]
        public DateTime? UpdateDate { get; set; }
    }
}
