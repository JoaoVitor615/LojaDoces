using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaDoces.Models;
using LojaDoces.Repositorio;

namespace LojaDoces.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        Acoes ac = new Acoes();

        public ActionResult Doces()
        {
            var doces = new Doces();
            return View(doces);
        }


        [HttpPost]
        public ActionResult CadDoces(Doces doces)
        {
            ac.CadastrarDoce(doces);
            return View(doces);
        }

        public ActionResult ListarDoces()
        {
            var ExibeDoces = new Acoes();
            var TodosDoces = ExibeDoces.ListarDoces();
            return View(TodosDoces);
        }
    }
}