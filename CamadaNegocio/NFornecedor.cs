using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
   public class NFornecedor
    {
        //Método Inserir
        public static string Inserir(string empresa, string setor_comercial, string tipo_documento,
            string num_documento, string endereco, string telefone, string email, string url)
        {
            DFornecedor Obj = new CamadaDados.DFornecedor();
            Obj.Empresa = empresa;
            Obj.SetorComercial = setor_comercial;
            Obj.TipoDocumento = tipo_documento;
            Obj.NumDocumento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Inserir(Obj);
        }

        //Método Editar
        public static string Editar(int idfornecedor, string empresa, string setor_comercial, string tipo_documento, string num_documento,
            string endereco, string telefone, string email, string url)
        {
            DFornecedor Obj = new CamadaDados.DFornecedor();
            Obj.Idfornecedor = idfornecedor;
            Obj.Empresa = empresa;
            Obj.SetorComercial = setor_comercial;
            Obj.TipoDocumento = tipo_documento;
            Obj.NumDocumento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Editar(Obj);
        }

        //Método Deletar
        public static string Excluir(int idfornecedor)
        {
            DFornecedor Obj = new CamadaDados.DFornecedor();
            Obj.Idfornecedor = idfornecedor;

            return Obj.Excluir(Obj);
        }

        //Método Mostrar 
        public static DataTable Mostrar()
        {
            return new DApresentacao().Mostrar();
        }

        //Método Buscar Nome

        public static DataTable BuscarNomeEmpresa(string textobuscar)
        {
            DFornecedor Obj = new DFornecedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNomeEmpresa(Obj);
        }
    }
}
