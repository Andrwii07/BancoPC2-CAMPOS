using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BancoPC2_CAMPOS.Data;
using BancoPC2_CAMPOS.Models;

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
            return View();
        }

        [HttpPost]
        public IActionResult Enviar(Cuenta objcuenta)
        {
            _logger.LogDebug("Ingreso a Crear Cuenta");
           
            _context.Add(objcuenta);
            _context.SaveChanges();

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}