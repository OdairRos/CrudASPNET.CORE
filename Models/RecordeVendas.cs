using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudASPNEW.CORE.Models.Enums;
namespace CrudASPNEW.CORE.Models
{
    public class RecordeVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quantia { get; set; }
        public StatusVenda Status{ get; set; }
        public Vendedor vendedor { get; set; }

        public RecordeVendas()
        {
        }

        public RecordeVendas(int id, DateTime data, double quantia, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Status = status;
            this.vendedor = vendedor;
        }
    }
}
