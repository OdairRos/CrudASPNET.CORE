using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudASPNET.CORE.Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message__) : base(message__){}

    }
}
