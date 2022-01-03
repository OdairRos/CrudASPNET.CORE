using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudASPNEW.CORE.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CrudASPNEW.CORE.Models
{
    public class RecordeVendas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quantia { get; set; }
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RecordeVendas()
        {
        }

        public RecordeVendas(int id, DateTime data, double quantia, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Status = status;
            this.Vendedor = vendedor;
        }
    }
}
