using Livraria.Dados;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livraria.Controllers
{
    public class StatusController : Controller
    {
        modelStatus status = new modelStatus();
        acStatus acoes = new acStatus();
        // GET: Status
        public ActionResult cadStatus()
        {
            return View();
        }

        public ActionResult confCadStatus(FormCollection frm)
        {
            status.sta = frm["txtSta"];
            acoes.inserirStatus(status);
            
            return View();
        }
        public ActionResult ListarStatus()
        {
            return View(acoes.ListarStatus());
        }

        public ActionResult buscarStatus()
        {
            return View();
        }

        public ActionResult editarStatus(string id)
        {
            return View(acoes.ListarStatus().Find(modelStatus => modelStatus.codStatus == id));
        }
        [HttpPost]
        public ActionResult editarStatus (modelStatus modelStatus)
        {
            acoes.atualizarStatus(modelStatus);
            return RedirectToAction(nameof(buscarStatus));
        }

        public ActionResult excluirStatus (string id)
        {
            acoes.excluirStatus(id);
            return RedirectToAction(nameof(buscarStatus));
        }
    }
}