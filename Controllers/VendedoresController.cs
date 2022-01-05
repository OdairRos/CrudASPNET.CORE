using CrudASPNET.CORE.Models;
using CrudASPNET.CORE.Services;
using CrudASPNET.CORE.Services.Exceptions;
using CrudASPNEW.CORE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics;
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

        #region Actions
        public async Task<IActionResult> Index()
        {
            var list = await __VendedorServico.FindAllAsync();
            return View(list);
        }
       
        public async Task<IActionResult> Create()
        {
            var departments = await __DepartamentoServico.FindAllAsync();
            var viewModel = new FormularioVendedorViewModel { Departamentos = departments };
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await __VendedorServico.FindByIdAsync(id.Value) == null)
                return RedirectToAction(nameof(Error), Error("Id not valid"));

            return View(await __VendedorServico.FindByIdAsync(id.Value));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var vendedor = await __VendedorServico.FindByIdAsync(id.Value);
            if (id == null || vendedor  == null)
                return RedirectToAction(nameof(Error), Error("Id not valid"));

            return View(vendedor);

        }
        public async  Task<IActionResult> Edit(int? id)
        {
            var vendedor = await __VendedorServico.FindByIdAsync(id.Value);
            List<Depa> departamento = await __DepartamentoServico.FindAllAsync();
            if (id == null || vendedor == null)
                return RedirectToAction(nameof(Error),  Error("Id not valid"));


            FormularioVendedorViewModel viewModel = new FormularioVendedorViewModel
            {
                Vendedor = vendedor,
                Departamentos = departamento
            };
            return View(viewModel);
        }
       
       

        public IActionResult Error(string Message__)
        {
            var viewModel = new ErrorViewModel
            {
                Message = Message__,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
        #endregion

        #region Actions HttpPost

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid) {
                var viewModel = new FormularioVendedorViewModel
                {
                    Vendedor = vendedor,
                    Departamentos = await __DepartamentoServico.FindAllAsync()
                };
                return View(viewModel);
            }

             await __VendedorServico.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await __VendedorServico.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new FormularioVendedorViewModel { 
                        Vendedor = vendedor, 
                        Departamentos = await __DepartamentoServico.FindAllAsync() };

                    return View(viewModel);
                }

                if (id != vendedor.Id)
                    return RedirectToAction(nameof(Error), Error("Id mismatch"));
                await __VendedorServico.UpdateAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), Error(e.Message));
            }
        }
        #endregion
    }
}
