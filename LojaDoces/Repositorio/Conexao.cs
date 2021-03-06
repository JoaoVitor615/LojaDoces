using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace LojaDoces.Repositorio
{
    public class Conexao
    {

        MySqlConnection cn = new MySqlConnection("Server=localhost;DataBase=loja_doces;user=doceiro;pwd=12345678");
        public static string msg;

        public MySqlConnection ConectarBd()
        {
            try
            {
                cn.Open();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao conectar" + erro.Message;
            }
            return cn;
        }

        public MySqlConnection DesconectarBd()
        {
            try
            {
                cn.Close();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao desconectar" + erro.Message;
            }
            return cn;
        }

    }
}