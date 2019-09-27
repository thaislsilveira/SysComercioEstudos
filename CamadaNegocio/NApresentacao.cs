using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    public class NApresentacao
    {
        //Método Inserir
        public static string Inserir(string nome, string descricao)
        {
            DApresentacao Obj = new CamadaDados.DApresentacao();
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Inserir(Obj);
        }

        //Método Editar
        public static string Editar(int idpresentacao, string nome, string descricao)
        {
            DApresentacao Obj = new CamadaDados.DApresentacao();
            Obj.Idapresentacao = idpresentacao;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Editar(Obj);
        }

        //Método Deletar
        public static string Excluir(int idapresentacao)
        {
            DApresentacao Obj = new CamadaDados.DApresentacao();
            Obj.Idapresentacao = idapresentacao;

            return Obj.Excluir(Obj);
        }

        //Método Mostrar 
        public static DataTable Mostrar()
        {
            return new DApresentacao().Mostrar();
        }

        //Método Buscar Nome

        public static DataTable BuscarNome(string textobuscar)
        {
            DApresentacao Obj = new DApresentacao();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }
    }
}
