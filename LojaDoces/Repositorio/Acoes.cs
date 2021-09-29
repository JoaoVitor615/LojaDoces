using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaDoces.Repositorio;
using MySql.Data.MySqlClient;
using LojaDoces.Models;

namespace LojaDoces.Repositorio
{
    public class Acoes
    {
        Conexao con = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public void CadastrarDoce(Doces doces)
        {
            /*
                iddoce int primary key not null,
                tipodoce varchar(30) not null,
                fabricantedoce varchar(50) not null,
                pesodoce int not null,
                estoquedoce int not null	*/



            MySqlCommand cmd = new MySqlCommand("insert into tbl_doces values(@iddoce, @tipodoce," +
                "@fabricantedoce, @pesodoce, @estoquedoce)", con.ConectarBd());
            cmd.Parameters.Add("@iddoce", MySqlDbType.VarChar).Value = doces.codDoce;
            cmd.Parameters.Add("@tipodoce", MySqlDbType.VarChar).Value = doces.tipoDoce;
            cmd.Parameters.Add("@fabricantedoce", MySqlDbType.VarChar).Value = doces.fornecedorDoce;
            cmd.Parameters.Add("@pesodoce", MySqlDbType.VarChar).Value = doces.pesoDoce;
            cmd.Parameters.Add("@estoquedoce", MySqlDbType.VarChar).Value = doces.estoqDoce;
            cmd.ExecuteNonQuery();
            con.DesconectarBd();

        }

        public Doces ListarCodDoces(int cod)
        {
            var comando = String.Format("select * from tbl_doces where codDoce = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBd());
            var DadosDoce = cmd.ExecuteReader();
            return ListCodDoces(DadosDoce).FirstOrDefault();
        }

        public List<Doces> ListCodDoces(MySqlDataReader dt)
        {
            var AltAl = new List<Doces>();
            while (dt.Read())
            {
                var AlTemp = new Doces()
                {
                    codDoce = int.Parse(dt["iddoce"].ToString()),
                    tipoDoce = dt["tipodoce"].ToString(),
                    fornecedorDoce = dt["fabricantedoce"].ToString(),
                    pesoDoce = int.Parse(dt["pesodoce"].ToString()),
                    estoqDoce = int.Parse(dt["estoquedoce"].ToString()),
                };
                AltAl.Add(AlTemp);
            }

            dt.Close();
            return AltAl;
        }

        public List<Doces> ListarDoces()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_doces ", con.ConectarBd());
            var DadosDoces = cmd.ExecuteReader();
            return ListarTodosDoces(DadosDoces);
        }

        public List<Doces> ListarTodosDoces(MySqlDataReader dt)
        {
            var TodosDoces = new List<Doces>();
            while (dt.Read())
            {
                var DocesTemp = new Doces()
                {
                    codDoce = int.Parse(dt["iddoce"].ToString()),
                    tipoDoce = dt["tipodoce"].ToString(),
                    fornecedorDoce = dt["fabricantedoce"].ToString(),
                    pesoDoce = int.Parse(dt["pesodoce"].ToString()),
                    estoqDoce = int.Parse(dt["estoquedoce"].ToString()),
                };
                TodosDoces.Add(DocesTemp);
            }
            dt.Close();
            return TodosDoces;
        }

        //FORNECEDOR 

        /*
            idfornecedor int primary key not null,
nomefornecedor varchar(50) not null,
enderecofornecedor varchar(50) not null,
telefonefornecedor varchar(14) not null,
emailfornecedor varchar(60) not null
         
        */
        public void CadastrarFornecedor(Fornecedor fornecedor)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_fornecedor values(@idfornecedor, @nomefornecedor," +
                "@enderecofornecedor, @telefonefornecedor, @emailfornecedor)", con.ConectarBd());
            cmd.Parameters.Add("@idfornecedor", MySqlDbType.VarChar).Value = fornecedor.codForn;
            cmd.Parameters.Add("@nomefornecedor", MySqlDbType.VarChar).Value = fornecedor.nomeForn;
            cmd.Parameters.Add("@enderecofornecedor", MySqlDbType.VarChar).Value = fornecedor.enderecoForn;
            cmd.Parameters.Add("@telefonefornecedor", MySqlDbType.VarChar).Value = fornecedor.telefoneForn;
            cmd.Parameters.Add("@emailfornecedor", MySqlDbType.VarChar).Value = fornecedor.emailForn;
            cmd.ExecuteNonQuery();
            con.DesconectarBd();
        }

        public Fornecedor ListarCodForn(int cod)
        {
            var comando = String.Format("select * from tbl_fornecedor where codForn = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBd());
            var DadosForn = cmd.ExecuteReader();
            return ListCodForn(DadosForn).FirstOrDefault();
        }

        public List<Fornecedor> ListCodForn(MySqlDataReader dt)
        {
            var AltAl = new List<Fornecedor>();
            while (dt.Read())
            {
                var FornTemp = new Fornecedor()
                {
                    codForn = int.Parse(dt["idfornecedor"].ToString()),
                    nomeForn = dt["nomefornecedor"].ToString(),
                    enderecoForn = dt["enderecofornecedor"].ToString(),
                    telefoneForn = dt["telefonefornecedor"].ToString(),
                    emailForn = dt["emailfornecedor"].ToString(),
                };
                AltAl.Add(FornTemp);
            }

            dt.Close();
            return AltAl;
        }

        public List<Fornecedor> ListarForn()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_fornecedor ", con.ConectarBd());
            var DadosForn = cmd.ExecuteReader();
            return ListarTodosForn(DadosForn);
        }

        public List<Fornecedor> ListarTodosForn(MySqlDataReader dt)
        {
            var TodosForn = new List<Fornecedor>();
            while (dt.Read())
            {
                var FornTemp = new Fornecedor()
                {
                    codForn = int.Parse(dt["idfornecedor"].ToString()),
                    nomeForn = dt["nomefornecedor"].ToString(),
                    enderecoForn = dt["enderecofornecedor"].ToString(),
                    telefoneForn = dt["telefonefornecedor"].ToString(),
                    emailForn = dt["emailfornecedor"].ToString(),
                };
                TodosForn.Add(FornTemp);
            }
            dt.Close();
            return TodosForn;
        }
        
    }
}