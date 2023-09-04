using Livraria.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.Dados
{
    public class clAutores
    {
        Conexao con = new Conexao();
        public void inserirAutor (modelLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbAutor (nomeAutor, sta) values (@nomeAutor, @sta)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeAutor", MySqlDbType.VarChar).Value = cm.nomeAutor;
            cmd.Parameters.Add("@sta", MySqlDbType.VarChar).Value = cm.status;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        MySqlDataReader dr;

        public void buscarAutor (modelLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbAutor where codAutor=@codAutor", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@codAutor", cm.codAutor);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cm.nomeAutor = dr[1].ToString();
                cm.status = dr[2].ToString();
            }

            con.MyDesconectarBD();
        }

        public void atualizarAutor(modelLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbAutor set nomeAutor=@nomeAutor, sta=@status where codAutor=@codAutor", con.MyConectarBD());

            cmd.Parameters.Add("@codAutor", MySqlDbType.VarChar).Value = cm.codAutor;
            cmd.Parameters.Add("@nomeAutor", MySqlDbType.VarChar).Value = cm.nomeAutor;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = cm.status;

            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();
        }

        public void excluirAutor(modelLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbAutor where @codAutor=@codAutor", con.MyConectarBD());

            cmd.Parameters.Add("@codAutor", MySqlDbType.VarChar).Value = cm.codAutor;

            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();
        }

    }
}