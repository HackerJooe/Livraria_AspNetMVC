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
    }
}