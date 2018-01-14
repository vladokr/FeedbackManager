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
    public class Game : BaseEntity
    {
        [DataMember]
        public string Name { get; set; }
    }
}
