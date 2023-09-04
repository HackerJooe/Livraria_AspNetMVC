using Livraria.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Livraria.Dados
{
    public class acStatus
    {
        Conexao con = new Conexao();
        public void inserirStatus(modelStatus mdlStatus)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbStatus (desc_status) values (@sta)",
            con.MyConectarBD()); // comando para inserir no banco de dados, com as referencias das informacoes e @parametros pelo mvc

            cmd.Parameters.Add("@sta", MySqlDbType.VarChar).Value = mdlStatus.sta;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelStatus> ListarStatus()
        {
            List<modelStatus> modList = new List<modelStatus>();

            MySqlCommand cmd = new MySqlCommand("select * from tbStatus", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                modList.Add(
                    new modelStatus
                    {
                        codStatus = Convert.ToString(dr["codLivro"]),
                        sta = Convert.ToString(dr["nomeLivro"])
                    });
            }
            return modList;
        }

        public void atualizarStatus(modelStatus cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbStatus set desc_status=@sta where codStatus=@codStatus", con.MyConectarBD());

            cmd.Parameters.Add("@codStatus", MySqlDbType.VarChar).Value = cm.codStatus;
            cmd.Parameters.Add("@desc_status", MySqlDbType.VarChar).Value = cm.sta;

            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();
        }
    }
}