using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CamadaDados
{
    class DApresentacao
    {
        private int _Idapresentacao;
        private string _Nome;
        private string _Descricao;
        private string _TextoBuscar;

        public int Idapresentacao { get => _Idapresentacao; set => _Idapresentacao = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
    }
}
