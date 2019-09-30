using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaNegocio;

namespace CamadaApresentacao
{
    public partial class frmFornecedor : Form
    {
        private bool eNovo = false;
        private bool eEditar = false;
        public frmFornecedor()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtEmpresa, "Insira o nome da Empresa");
        }

        //Mostrar mensagem de confirmação
        private void MensagemOK(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema Comércio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar mensagem de erro
        private void MensagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema Comércio", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //Limpar Campos
        private void Limpar()
        {
            this.txtEmpresa.Text = string.Empty;
            this.txtSetorComercial.Text = string.Empty;
            this.txtTipoDocumento.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;
            this.txtEndereco.Text = string.Empty;
            this.txtTelefone.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtUrl.Text = string.Empty;

        }

        //Habilitar os text box
        private void Habilitar(bool valor)
        {
            this.txtEmpresa.ReadOnly = !valor;
            this.txtSetorComercial.ReadOnly = !valor;
            this.txtTipoDocumento.ReadOnly = !valor;
            this.txtNumDocumento.ReadOnly = !valor;
            this.txtEndereco.ReadOnly = !valor;
            this.txtTelefone.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtUrl.ReadOnly = !valor;
        }

        //Habilitar os botões
        private void botoes()
        {
            if (this.eNovo || this.eEditar)
            {
                this.Habilitar(true);
                this.btnNovo.Enabled = false;
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }


        //Ocultar as Colunas do Grid
        private void ocultarColunas()
        {
            this.dataLista.Columns[0].Visible = false;
            this.dataLista.Columns[1].Visible = false;
        }

        //Mostrar no Data Grid
        private void Mostrar()
        {
            this.dataLista.DataSource = NFornecedor.Mostrar();
            this.ocultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataLista.Rows.Count);

        }

        //Buscar pelo Nome
        private void BuscarNome()
        {
            this.dataLista.DataSource = NFornecedor.BuscarNomeEmpresa(this.txtBuscar.Text);
            this.ocultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataLista.Rows.Count);

        }

        private void FrmApresentacao_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.botoes();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {

        }

        private void ChkDeletar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnDeletar_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void TxtUrl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
