using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudASPNEW.CORE.Models
{
    public class Depa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();


        public Depa()
        {
        }
      
        public Depa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void addVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public double VendasTotais(DateTime inicial,DateTime final)
        {
            return Vendedores
                .Sum(vendedor => vendedor
                    .VendasTotais(inicial,final));
        }
    }
}
