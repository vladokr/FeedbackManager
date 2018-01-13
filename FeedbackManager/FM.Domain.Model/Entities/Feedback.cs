using FM.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Domain.Model.Entities
{
    public class Feedback : BaseEntity
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int? UserId { get; set; }
        public int? GameSessionId { get; set; }
    }
}
