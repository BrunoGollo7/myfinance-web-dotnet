using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;
using System.Diagnostics;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly IPlanoContaService _planoContaService;
        public PlanoContaController(IPlanoContaService PlanoContaService)
        {
            _planoContaService = PlanoContaService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Lista = _planoContaService.ListarRegistros();
            return View();
        }
        
        [HttpGet]
        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(PlanoContaModel? model, int? id)
        {
           if(id != null && !ModelState.IsValid) //Carregar registro em tela
           {
                var registo = _planoContaService.RetornarRegistro((int)id);
                
                var planoContaModel = new PlanoContaModel()
                {
                    Id = registo.Id,
                    Nome = registo.Nome,
                    Tipo =  registo.Tipo
                };
                return View(planoContaModel);
           }
           else if(model != null && ModelState.IsValid)
           {
                var planoConta = new PlanoConta
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Tipo = model.Tipo
                };
                _planoContaService.Salvar(planoConta);
                // Adiciona a mensagem de sucesso
                TempData["MensagemSucesso"] = "Item salvo com sucesso!";

                return View();
           }
           else
           {
                return View();
           }
        }

        
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _planoContaService.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
