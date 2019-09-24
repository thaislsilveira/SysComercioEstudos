using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int Idfornecedor { get => _Idfornecedor; set => _Idfornecedor = value; }
        public string Empresa { get => _Empresa; set => _Empresa = value; }
        public string SetorComercial { get => _SetorComercial; set => _SetorComercial = value; }
        public string TipoDocumento { get => _TipoDocumento; set => _TipoDocumento = value; }
        public string NumDocumento { get => _NumDocumento; set => _NumDocumento = value; }
        public string Endereco { get => _Endereco; set => _Endereco = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }


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
    }
}
