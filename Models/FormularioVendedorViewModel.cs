using CrudASPNEW.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudASPNET.CORE.Models
{
    public class FormularioVendedorViewModel
    {
        public Vendedor vendedor { get; set; }
        public ICollection<Depa> departamentos { get; set; }
    }
}
