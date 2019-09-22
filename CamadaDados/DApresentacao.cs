﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CamadaDados
{
    public class DApresentacao
    {
        private int _Idapresentacao;
        private string _Nome;
        private string _Descricao;
        private string _TextoBuscar;

        public int Idapresentacao { get => _Idapresentacao; set => _Idapresentacao = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        // Construtor Vazio 

        public DApresentacao()
        {

        }

        //Construtor com Parametros

        public DApresentacao(int idapresentacao, string nome, string descricao, string textobuscar)
        {
            this.Idapresentacao = idapresentacao;
            this.Nome = nome;
            this.Descricao = descricao;
            this.TextoBuscar = textobuscar;

        }

        //Método Inserir
        public string Inserir(DApresentacao Apresentacao)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo

                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_apresentacao";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdapresentacao = new SqlParameter();
                ParIdapresentacao.ParameterName = "@idapresentacao";
                ParIdapresentacao.SqlDbType = SqlDbType.Int;
                ParIdapresentacao.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdapresentacao);


                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Apresentacao.Nome;
                SqlCmd.Parameters.Add(ParNome);


                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 100;
                ParDescricao.Value = Apresentacao.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                //Executar o comando

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi Inserido";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;

        }

        //Método Editar
        public string Editar(DApresentacao Apresentacao)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo

                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_apresentacao";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdapresentacao = new SqlParameter();
                ParIdapresentacao.ParameterName = "@idapresentacao";
                ParIdapresentacao.SqlDbType = SqlDbType.Int;
                ParIdapresentacao.Value = Apresentacao.Idapresentacao;
                SqlCmd.Parameters.Add(ParIdapresentacao);


                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Apresentacao.Nome;
                SqlCmd.Parameters.Add(ParNome);


                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 100;
                ParDescricao.Value = Apresentacao.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                //Executar o comando

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A edição não foi feita";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }

        //Método Excluir
        public string Excluir(DApresentacao Apresentacao)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo

                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_apresentacao";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdapresentacao = new SqlParameter();
                ParIdapresentacao.ParameterName = "@idapresentacao";
                ParIdapresentacao.SqlDbType = SqlDbType.Int;
                ParIdapresentacao.Value = Apresentacao.Idapresentacao;
                SqlCmd.Parameters.Add(ParIdapresentacao);

                //Executar o comando

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A exclusão não foi feita";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("apresentacao");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_apresentacao";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Método Buscar Nome
        public DataTable BuscarNome(DApresentacao Apresentacao)
        {
            DataTable DtResultado = new DataTable("apresentacao");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spapresentacao_nome";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Apresentacao.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
