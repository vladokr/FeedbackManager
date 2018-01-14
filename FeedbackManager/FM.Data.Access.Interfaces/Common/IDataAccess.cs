using FM.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Access.Interfaces.Common
{
    public interface IDataAccess<T> where T : BaseEntity
    {
        T SelectById(int id);
        IList<T> SelectAll();
        IList<T> Select(Func<T, bool> criteria);
        T Insert(T item);
    }
}
