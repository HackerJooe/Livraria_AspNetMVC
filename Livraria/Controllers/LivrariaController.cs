using Livraria.Dados;
using Livraria.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Livraria.Controllers
{
    public class LivrariaController : Controller
    {
        // Metodo para carregar os autores dos livros da Livraria
        public ActionResult carregaAutores()
        {
            List<SelectListItem> autores = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Database=bdLivraria; User=root; password= 1234546789"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbAutor where sta= 1", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    autores.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }
            ViewBag.autores = new SelectList(autores, "Value", "Text");
            return View();
        }

        public ActionResult cadLivro()
        {
            carregaAutores();
            return View();
        }

        acLivro ac = new acLivro(); // instancia as classes
        modelLivro mod = new modelLivro(); // instancia as classes

        public ActionResult confCadLivro(FormCollection frm)
        {
            mod.nomeLivro = frm["txtNmLivro"];
            mod.codAutor = Request["autores"];
            ac.inserirLivro(mod);
            return View();
        }

        public ActionResult consLivro()
        {
            GridView gvAtendimento = new GridView();
            gvAtendimento.DataSource = ac.selecionaLivro();
            gvAtendimento.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvAtendimento.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }

        public ActionResult listarLivros ()
        {
            return View(ac.buscarLivro());
        }
    }
}