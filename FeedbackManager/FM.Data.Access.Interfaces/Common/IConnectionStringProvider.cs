using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Access.Interfaces.Common
{
    public interface IAppConfig
    {
        String ConnectionString { get; }
        String ApplicationKey { get; }
        String AuthenticationScheme { get; }
        String AuthenticationUserLoginHeader { get; }
        String AuthenticationUserPasswordHeader { get; }
    }
}
