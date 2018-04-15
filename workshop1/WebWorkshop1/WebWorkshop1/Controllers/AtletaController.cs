using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebWorkshop1.Controllers
{
    public class AtletaController : Controller
    {
        EquipaContext db = new EquipaContext();
        public ActionResult Index()
        {
            return View();
        }

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        [HttpPost]
        public ActionResult AdicionarAtleta([Bind(Include = "nome,data_nascimento,genero")] Atleta atleta)
        {
            if (ModelState.IsValid)
            {
                db.Atleta.Add(atleta);
                db.SaveChanges();
            }
            return RedirectToAction("sucessOperation");
        }

        public ActionResult sucessOperation()
        {
            ViewBag.title = "Atleta adicionado com sucesso";
            ViewBag.mensagem = "Atleta inserido com sucesso";
            return View();
        }

        public ActionResult verAtletas()
        {
            var atletas = (from m in db.Atleta
                           select m);
            return View(atletas);
        }
    }
}