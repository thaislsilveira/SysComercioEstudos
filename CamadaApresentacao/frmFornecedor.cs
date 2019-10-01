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
            this.eNovo = true;
            this.eEditar = false;
            this.botoes();
            this.Limpar();
            this.Habilitar(true);
            this.txtEmpresa.Focus();
            this.txtIdFornecedor.Enabled = false;
        }

        private void ChkDeletar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnDeletar_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";
                if (this.txtEmpresa.Text == string.Empty)
                {
                    MensagemErro("Preencha todos os campos");
                    errorIcone.SetError(txtEmpresa, "Insira o nome da empresa");
                }
                else
                {
                    if (this.eNovo)
                    {
                        resp = NFornecedor.Inserir(this.txtEmpresa.Text.Trim().ToUpper(),
                            this.txtSetorComercial.Text.Trim(),
                            this.txtTipoDocumento.Text.Trim(),
                            this.txtNumDocumento.Text.Trim(),
                            this.txtEndereco.Text.Trim(),
                            this.txtTelefone.Text.Trim(),
                            this.txtEmail.Text.Trim(),
                            this.txtUrl.Text.Trim());
                    }
                    else
                    {
                        resp = NFornecedor.Editar(Convert.ToInt32(this.txtIdFornecedor.Text),
                            this.txtEmpresa.Text.Trim().ToUpper(),
                            this.txtSetorComercial.Text.Trim(),
                            this.txtTipoDocumento.Text.Trim(),
                            this.txtNumDocumento.Text.Trim(),
                            this.txtEndereco.Text.Trim(),
                            this.txtTelefone.Text.Trim(),
                            this.txtEmail.Text.Trim(),
                            this.txtUrl.Text.Trim());
                    }
                    if (resp.Equals("OK"))
                    {
                        if (this.eNovo)
                        {
                            this.MensagemOK("Registro salvo com sucesso");
                        }
                        else
                        {
                            this.MensagemOK("Registro editado com sucesso");
                        }
                    }
                    else
                    {
                        this.MensagemErro(resp);
                    }
                    this.eNovo = false;
                    this.eEditar = false;
                    this.botoes();
                    this.Limpar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TxtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.botoes();
        }
    }
}
