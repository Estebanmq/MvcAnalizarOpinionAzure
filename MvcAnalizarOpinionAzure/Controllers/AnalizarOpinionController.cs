using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcAnalizarOpinionAzure.Services;

namespace MvcAnalizarOpinionAzure.Controllers
{
    public class AnalizarOpinionController : Controller
    {

        private ServicePowerAutomate service;

        public AnalizarOpinionController(ServicePowerAutomate service)
        {
            this.service = service;
        }

        public IActionResult AnalizarOpinion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AnalizarOpinion(string opinion)
        {
            string resultado = await this.service.AnalizarOpinionAsync(opinion);
            ViewBag.Resultado = resultado;
            return View();
        }
    }
}
