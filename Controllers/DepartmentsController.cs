using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudASPNEW.CORE.Models;
namespace CrudASPNEW.CORE.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department { id = 123, nome = "nueva oficina" });
            list.Add(new Department { id = 456, nome = "nuevo negocio en la calle" });
            return View();
        }

    }
}
