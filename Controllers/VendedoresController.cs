using CrudASPNET.CORE.Models;
using CrudASPNET.CORE.Services;
using CrudASPNEW.CORE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudASPNET.CORE.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService __VendedorServico;
        private readonly DepartmentService __DepartamentoServico;

        public VendedoresController(VendedorService vendedorServico, DepartmentService departamentoServico)
        {
            __VendedorServico = vendedorServico;
            __DepartamentoServico = departamentoServico;
        }

        public IActionResult Index()
        {
            var list = __VendedorServico.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = __DepartamentoServico.FindAll();
            var viewModel = new FormularioVendedorViewModel { departamentos = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            __VendedorServico.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

    }
}
