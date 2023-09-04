﻿using Livraria.Dados;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Livraria.Controllers
{
    public class HomeController : Controller
    {
        modelLivro modelo = new modelLivro(); // instancia as classes
        acLivro acoes = new acLivro(); // instancia as classes
        clAutores acAutor = new clAutores();

        // CADASTRAR AUTOR
        public ActionResult cadAutor()
        {
            return View();
        }

        // CADASTRAR AUTOR
        public ActionResult confCadAutor (FormCollection frm)
        {
            modelo.nomeAutor = frm["txtNmAutor"];
            modelo.status = frm["txtStatus"];

            acoes.inserirLivro(modelo);

            return View();
        }

        public ActionResult atAutor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult atAutor(FormCollection frm, string btn)
        {
            modelo.codAutor = frm["txtCodAutor"];

            if (btn == "Buscar")
            {
                acAutor.buscarAutor(modelo);

                ViewBag.codAutor = modelo.codAutor;
                ViewBag.nomeAutor = modelo.nomeAutor;
                ViewBag.sta = modelo.status;

                return View();
            } 
            else if (btn == "Atualizar")
            {
                modelo.nomeAutor = frm["txtNomeAutor"];
                modelo.status = frm["txtStatus"];

                acAutor.atualizarAutor(modelo);

                ViewBag.msg = "Autor atualizado com Sucesso!!!";

                return View();
            }
            else if (btn == "Excluir")
            {
                acAutor.excluirAutor(modelo);

                ViewBag.msg = "Autor excluído com Sucesso!!!";

                return View();
            } else
            {
                return View();
            }
        }

        
    }
}