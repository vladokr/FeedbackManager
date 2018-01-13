using FM.Data.Access.Interfaces.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Access.Impl.LinqSql.Exceptions
{
    public class LinqToSqlDataAccessException : Exception, IDataAccessException
    {
        public LinqToSqlDataAccessException() : base() { }
        public LinqToSqlDataAccessException(string message) : base(message) { }
        public LinqToSqlDataAccessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
