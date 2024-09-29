using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BancoPC2_CAMPOS.Data;
using BancoPC2_CAMPOS.Models;
using BancoPC2_CAMPOS.ViewModel;

namespace BancoPC2_CAMPOS.Controllers
{
    public class BancoController : Controller
    {
        private readonly ILogger<BancoController> _logger;
        private readonly ApplicationDbContext _context;

        public BancoController(ILogger<BancoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var miscuentas = from o in _context.DataCuenta select o;
            _logger.LogDebug("cuenta {miscuentas}", miscuentas);
            var viewModel = new CuentaViewModel
            {
                FormCuenta = new Cuenta(),
                ListCuenta = miscuentas
            };
            _logger.LogDebug("viewModel {viewModel}", viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Enviar(CuentaViewModel viewModel)
        {
            _logger.LogDebug("Ingreso a Crear Cuenta");

            var cuenta = new Cuenta
            {
                NombreT = viewModel.FormCuenta.NombreT,
                TipoC = viewModel.FormCuenta.TipoC,
                SaldoI = viewModel.FormCuenta.SaldoI,
                Email = viewModel.FormCuenta.Email,
            };

            _context.Add(cuenta);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }

    [Serializable]
    internal class CuentaViewModel : Exception
    {
        public CuentaViewModel()
        {
        }

        public CuentaViewModel(string? message) : base(message)
        {
        }

        public CuentaViewModel(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public Cuenta FormCuenta { get; set; }
        public IQueryable<Cuenta> ListCuenta { get; set; }
    }
}