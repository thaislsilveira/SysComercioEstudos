using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    class DFornecedor
    {
        private int _Idfornecedor;
        private string _Empresa;
        private string _SetorComercial;
        private string _TipoDocumento;
        private string _NumDocumento;
        private string _Endereco;
        private string _Email;
        private string _Url;
        private string _TextoBuscar;
        public int Idfornecedor { get => _Idfornecedor; set => _Idfornecedor = value; }
        public string Empresa { get => _Empresa; set => _Empresa = value; }
        public string SetorComercial { get => _SetorComercial; set => _SetorComercial = value; }
        public string TipoDocumento { get => _TipoDocumento; set => _TipoDocumento = value; }
        public string NumDocumento { get => _NumDocumento; set => _NumDocumento = value; }
        public string Endereco { get => _Endereco; set => _Endereco = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        // Construtor Vazio 
        public DFornecedor()
        {

        }

        //Construtor com Parametros
        public DFornecedor(int idfornecedor, string empresa, string setorcomercial, string tipodocumento, 
            string numdocumento, string endereco, string email, string url)
        {
            this.Idfornecedor = idfornecedor;
            this.Empresa = empresa;
            this.SetorComercial = setorcomercial;
            this.TipoDocumento = tipodocumento;
            this.NumDocumento = numdocumento;
            this.Endereco = endereco;
            this.Email = email;
            this.Url = url; 

        }

        //Método Inserir
        public string Inserir(DFornecedor Fornecedor)
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
                SqlCmd.CommandText = "spinserir_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcfornecedor = new SqlParameter();
                ParIdcfornecedor.ParameterName = "@idfornecedor";
                ParIdcfornecedor.SqlDbType = SqlDbType.Int;
                ParIdcfornecedor.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcfornecedor);


                SqlParameter ParEmpresa = new SqlParameter();
                ParEmpresa.ParameterName = "@empresa";
                ParEmpresa.SqlDbType = SqlDbType.VarChar;
                ParEmpresa.Size = 50;
                ParEmpresa.Value = Fornecedor.Empresa;
                SqlCmd.Parameters.Add(ParEmpresa);


                SqlParameter ParSetorComercial = new SqlParameter();
                ParSetorComercial.ParameterName = "@setor_comercial";
                ParSetorComercial.SqlDbType = SqlDbType.VarChar;
                ParSetorComercial.Size = 50;
                ParSetorComercial.Value = Fornecedor.SetorComercial;
                SqlCmd.Parameters.Add(ParSetorComercial);


                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 50;
                ParTipoDocumento.Value = Fornecedor.TipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);


                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 50;
                ParNumDocumento.Value = Fornecedor.NumDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);


                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 150;
                ParEndereco.Value = Fornecedor.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);


                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarBinary;
                ParEmail.Size = 50;
                ParEmail.Value = Fornecedor.Email;
                SqlCmd.Parameters.Add(ParEmail);


                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 50;
                ParUrl.Value = Fornecedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Editar(DFornecedor Fornecedor)
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
                SqlCmd.CommandText = "speditar_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdfornecedor = new SqlParameter();
                ParIdfornecedor.ParameterName = "@idfornecedor";
                ParIdfornecedor.SqlDbType = SqlDbType.Int;
                ParIdfornecedor.Value = Fornecedor.Idfornecedor;
                SqlCmd.Parameters.Add(ParIdfornecedor);


                SqlParameter ParEmpresa = new SqlParameter();
                ParEmpresa.ParameterName = "@empresa";
                ParEmpresa.SqlDbType = SqlDbType.VarChar;
                ParEmpresa.Size = 50;
                ParEmpresa.Value = Fornecedor.Empresa;
                SqlCmd.Parameters.Add(ParEmpresa);


                SqlParameter ParSetorComercial = new SqlParameter();
                ParSetorComercial.ParameterName = "@setor_comercial";
                ParSetorComercial.SqlDbType = SqlDbType.VarChar;
                ParSetorComercial.Size = 50;
                ParSetorComercial.Value = Fornecedor.SetorComercial;
                SqlCmd.Parameters.Add(ParSetorComercial);


                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 50;
                ParTipoDocumento.Value = Fornecedor.TipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);


                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 50;
                ParNumDocumento.Value = Fornecedor.NumDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);


                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 150;
                ParEndereco.Value = Fornecedor.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);


                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarBinary;
                ParEmail.Size = 50;
                ParEmail.Value = Fornecedor.Email;
                SqlCmd.Parameters.Add(ParEmail);


                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 50;
                ParUrl.Value = Fornecedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Excluir(DFornecedor Fornecedor)
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
                SqlCmd.CommandText = "spdeletar_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdfornecedor = new SqlParameter();
                ParIdfornecedor.ParameterName = "@idfornecedor";
                ParIdfornecedor.SqlDbType = SqlDbType.Int;
                ParIdfornecedor.Value = Fornecedor.Idfornecedor;
                SqlCmd.Parameters.Add(ParIdfornecedor);

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
            DataTable DtResultado = new DataTable("fornecedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_fornecedor";
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
        public DataTable BuscarNome(DFornecedor Fornecedor)
        {
            DataTable DtResultado = new DataTable("fornecedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_fornecedor_empresa";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Fornecedor.TextoBuscar;
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
