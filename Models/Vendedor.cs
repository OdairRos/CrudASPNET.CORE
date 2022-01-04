using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CrudASPNEW.CORE.Models
{
    public class Vendedor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       
        [StringLength(60,MinimumLength =3, ErrorMessage ="O nome({0}) deve ser entre {2}-{1}.")]
        [Display(Name="Nome")]
        [Required(ErrorMessage = "Campo {0} Obrigatorio")]
        public string Name { get; set; }

        
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage ="Digite um e-mail valido")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Campo {0} Obrigatorio")]
        public string Email { get; set; }


        [Display(Name = "Data de aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo {0} Obrigatorio")]
        public DateTime BirthDate { get; set; }


        [Range(100.0,10000000.00, ErrorMessage ="{0} Deve ser maior que {1}")]
        [Display(Name="Salário base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "Campo {0} Obrigatorio")]
        public Double BaseSalary { get; set; }
        

        [Display(Name="Departamento")]
        public Depa Department { get; set; }

        public int DepartmentId { get; set; }
        public ICollection<HistoricoVendas> Vendas { get; set; } = new List<HistoricoVendas>();

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

        #region Methods
        public void AddVendas(HistoricoVendas Rv)
        {
            Vendas.Add(Rv);
        }

        public void RemoveVendas(HistoricoVendas Rv)
        {
            Vendas.Remove(Rv);
        }

        public double VendasTotais(DateTime initial, DateTime final)
        {
            return Vendas
                    .Where(sr => sr.Data >= initial && sr.Data <= final)
                    .Sum(sr => sr.Quantia);
        }
        #endregion
    }
}
