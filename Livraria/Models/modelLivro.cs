using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class modelLivro
    {
        public string codLivro { get; set; }

        public string nomeLivro { get; set; }

        public string codAutor { get; set; }

        public string nomeAutor { get; set; }

        public string status { get; set; }
    }
}