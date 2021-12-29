using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudASPNEW.CORE.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Double BaseSalary { get; set; }
        public Depa Department { get; set; }
        public ICollection<RecordeVendas> Vendas { get; set; } = new List<RecordeVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string name, string email, DateTime birthDate, double baseSalary, Depa department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddVendas(RecordeVendas Rv)
        {
            Vendas.Add(Rv);
        }

        public void RemoveVendas(RecordeVendas Rv)
        {
            Vendas.Remove(Rv);
        }

        public double VendasTotais(DateTime initial, DateTime final)
        {
            return Vendas
                    .Where(sr => sr.Data >= initial && sr.Data <= final)
                    .Sum(sr => sr.Quantia);
        }
    }
} 
