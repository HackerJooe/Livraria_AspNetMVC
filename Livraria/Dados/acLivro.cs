using Livraria.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Livraria.Dados
{
    public class acLivro
    {
        Conexao con = new Conexao();
        acLivro ac = new acLivro();
        public void inserirLivro(modelLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbLivro (nomeLivro, codAutor) values (@nomeLivro, @codAutor)",
            con.MyConectarBD()); // comando para inserir no banco de dados, com as referencias das informacoes e @parametros pelo mvc

            cmd.Parameters.Add("@nomeLivro", MySqlDbType.VarChar).Value = cm.nomeLivro;
            cmd.Parameters.Add("@codAutor", MySqlDbType.VarChar).Value = cm.codAutor;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable selecionaLivro()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbLivro inner join tbAutor on tbLivro.codAutor = tbAutor.codAutor", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable atendimento = new DataTable();
            da.Fill(atendimento);
            con.MyDesconectarBD();
            return atendimento;
        }

        public List<modelLivro> buscarLivro()
        {
            List<modelLivro> modList = new List<modelLivro>();
            MySqlCommand cmd = new MySqlCommand("select * from tbLivro inner join tbAutor on tbLivro.codAutor = tbAutor.codAutor", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                modList.Add(
                    new modelLivro
                    {
                        codLivro = Convert.ToString(dr["codLivro"]),
                        nomeLivro = Convert.ToString(dr["nomeLivro"]),
                        codAutor = Convert.ToString(dr["codAutor"]),
                        nomeAutor = Convert.ToString(dr["nomeAutor"])
                    }
                    );
            }
            return modList;
        }
    }
}