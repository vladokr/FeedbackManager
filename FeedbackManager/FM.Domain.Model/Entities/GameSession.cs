using FM.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Domain.Model.Entities
{
    public class GameSession : BaseEntity
    {
        public DateTime? EndDate { get; set; }
        public int? GameId { get; set; }
        public Guid SessionIdentifier { get; set; }
    }
}
