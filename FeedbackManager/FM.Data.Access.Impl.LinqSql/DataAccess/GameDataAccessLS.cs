using FM.Data.Access.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Domain.Model.Entities;

namespace FM.Data.Access.Impl.LinqSql.DataAccess
{
    public class GameDataAccessLS : IGameDataAccess
    {
        public void Insert(Game item)
        {
            throw new NotImplementedException();
        }

        public IList<Game> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Game SelectById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
