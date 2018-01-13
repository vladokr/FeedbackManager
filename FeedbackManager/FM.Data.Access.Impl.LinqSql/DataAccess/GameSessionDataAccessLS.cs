using FM.Data.Access.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Domain.Model.Entities;

namespace FM.Data.Access.Impl.LinqSql.DataAccess
{
    public class GameSessionDataAccessLS : IGameSessionDataAccess
    {
        public void Insert(GameSession item)
        {
            throw new NotImplementedException();
        }

        public IList<GameSession> SelectAll()
        {
            throw new NotImplementedException();
        }

        public GameSession SelectById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
