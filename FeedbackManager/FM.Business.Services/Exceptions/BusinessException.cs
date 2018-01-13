using FM.Business.Interfaces.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Business.Services.Exceptions
{
    public class BusinessException : Exception, IBusinessException
    {
        public BusinessException() : base() { }
        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
