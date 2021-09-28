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
                create table tbl_doces
                (
                id_Doce int primary key not null,
                tipo_Doce varchar(30) not null,
                fabricante_Doce varchar(50) not null,
                peso_Doce int not null,
                estoque_Doce int not null
                );
             */

            MySqlCommand cmd = new MySqlCommand("insert into tbl_doces values(@id_Doce, @tipo_Doce, @fabricante_Doce, @peso_Doce, @estoque_Doce", con.ConectarBd());
            cmd.Parameters.Add("@id_Doce", MySqlDbType.VarChar).Value = doces.codDoce;
            cmd.Parameters.Add("@tipo_Doce", MySqlDbType.VarChar).Value = doces.tipoDoce;
            cmd.Parameters.Add("@fabricante_Doce", MySqlDbType.VarChar).Value = doces.fornecedorDoce;
            cmd.Parameters.Add("@peso_Doce", MySqlDbType.VarChar).Value = doces.pesoDoce;
            cmd.Parameters.Add("@estoque_Doce", MySqlDbType.VarChar).Value = doces.estoqDoce;
            cmd.ExecuteNonQuery();
            con.DesconectarBd();

        }

        public Doces ListarCodDoces(int cod)
        {
            var comando = String.Format("select * from tbl_doces where id_Doce = {0}", cod);
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
                    codDoce = int.Parse(dt["id_Doce"].ToString()),
                    tipoDoce = dt["tipo_Doce"].ToString(),
                    fornecedorDoce = dt["fabricante_Doce"].ToString(),
                    pesoDoce = int.Parse(dt["peso_Doce"].ToString()),
                    estoqDoce = int.Parse(dt["estoque_Doce"].ToString()),
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
                    codDoce = int.Parse(dt["id_Doce"].ToString()),
                    tipoDoce = dt["tipo_Doce"].ToString(),
                    fornecedorDoce = dt["fabricante_Doce"].ToString(),
                    pesoDoce = int.Parse(dt["peso_Doce"].ToString()),
                    estoqDoce = int.Parse(dt["estoque_Doce"].ToString()),
                };
                TodosDoces.Add(DocesTemp);
            }
            dt.Close();
            return TodosDoces;
        }

        //FORNECEDOR 

        /*
            id_fornecedor int primary key not null,
            nome_Fornecedor varchar(50) not null,
            endereco_Fornecedor varchar(50) not null,
            telefone_Fornecedor varchar(14) not null,
            email_Fornecedor varchar(60) not null
         */

        public void CadastrarFornecedor(Fornecedor fornecedor)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_fornecedor values(@id_fornecedor, @nome_Fornecedor, @endereco_Fornecedor, @telefone_Fornecedor, @email_Fornecedor,", con.ConectarBd());
            cmd.Parameters.Add("@id_fornecedor", MySqlDbType.VarChar).Value = fornecedor.codForn;
            cmd.Parameters.Add("@nome_Fornecedor", MySqlDbType.VarChar).Value = fornecedor.nomeForn;
            cmd.Parameters.Add("@endereco_Fornecedor", MySqlDbType.VarChar).Value = fornecedor.enderecoForn;
            cmd.Parameters.Add("@telefone_Fornecedor", MySqlDbType.VarChar).Value = fornecedor.telefoneForn;
            cmd.Parameters.Add("@email_Fornecedor", MySqlDbType.VarChar).Value = fornecedor.emailForn;
            cmd.ExecuteNonQuery();
            con.DesconectarBd();
        }

        public Fornecedor ListarCodJogo(int cod)
        {
            var comando = String.Format("select * from tbl_fornecedor where codForn = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBd());
            var DadosFornecedor = cmd.ExecuteReader();
            return ListCodJogo(DadosFornecedor).FirstOrDefault();
        }

        public List<Fornecedor> ListCodJogo(MySqlDataReader dt)
        {
            var AltAl = new List<Fornecedor>();
            while (dt.Read())
            {
                var FornecedorTemp = new Fornecedor()
                {
                    codForn = int.Parse(dt["id_fornecedor"].ToString()),
                    nomeForn = dt["nome_Fornecedor"].ToString(),
                    enderecoForn = dt["endereco_Fornecedor"].ToString(),
                    telefoneForn = dt["telefone_Fornecedor"].ToString(),
                    emailForn = dt["email_Fornecedor"].ToString(),
                };
                AltAl.Add(FornecedorTemp);
            }

            dt.Close();
            return AltAl;
        }

        public List<Fornecedor> ListarJogo()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_fornecedor ", con.ConectarBd());
            var DadosFornecedor = cmd.ExecuteReader();
            return ListarTodosFornecedor(DadosFornecedor);
        }

        public List<Fornecedor> ListarTodosFornecedor(MySqlDataReader dt)
        {
            var TodosFornecedor = new List<Fornecedor>();
            while (dt.Read())
            {
                var FornecedorTemp = new Fornecedor()
                {
                    codForn = int.Parse(dt["id_fornecedor"].ToString()),
                    nomeForn = dt["nome_Fornecedor"].ToString(),
                    enderecoForn = dt["endereco_Fornecedor"].ToString(),
                    telefoneForn = dt["telefone_Fornecedor"].ToString(),
                    emailForn = dt["email_Fornecedor"].ToString(),
                };
                TodosFornecedor.Add(FornecedorTemp);
            }
            dt.Close();
            return TodosFornecedor;
        }
    }
}