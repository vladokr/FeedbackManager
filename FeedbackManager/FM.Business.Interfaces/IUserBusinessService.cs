using FM.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Business.Interfaces
{
    public interface IUserBusinessService
    {
        IList<User> SelectAll();
    }
}
