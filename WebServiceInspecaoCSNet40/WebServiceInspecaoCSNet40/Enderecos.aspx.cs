using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceInspecaoCSNet40
{
    public partial class Enderecos : System.Web.UI.Page
    {
        private clsManipuladorTexto objManipuladorTexto = new clsManipuladorTexto();

        public Enderecos()
        {
            new _Default();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            mtdCarregarGvwEndereco();
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            _Default objDefault = new _Default();

            objDefault.mtdAlterarDadosTabelaEndereco(objManipuladorTexto.mtdExecutarTudo(txtEndereco.Text), _Default.lstColunasTabelaEndereco[(int)_Default.enmColunasTabelaEndereco.Endereco], "LIKE", string.Format("{0}", strEndereco));
            mtdCarregarGvwEndereco();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            _Default objDefault = new _Default();

            objDefault.mtdInserirDadosTabelaEndereco(objManipuladorTexto.mtdExecutarTudo(txtEndereco.Text));
            mtdCarregarGvwEndereco();
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            _Default objDefault = new _Default();

            objDefault.mtdDeletarDadosTabelaEndereco(_Default.lstColunasTabelaEndereco[(int)_Default.enmColunasTabelaEndereco.Endereco], strEndereco);
            mtdCarregarGvwEndereco();
        }

        protected void btnDeletarTodos_Click(object sender, EventArgs e)
        {
            _Default objDefault = new _Default();

            objDefault.mtdDeletarDadosTabelaEndereco(_Default.lstColunasTabelaEndereco[(int)_Default.enmColunasTabelaEndereco.Endereco], "%");
            mtdCarregarGvwEndereco();
        }

        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            mtdCarregarGvwEndereco();
        }

        private int intGvw1LinhaSelecionada = 0;
        private static string strEndereco = string.Empty;

        protected void gvwEndereco_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intGvw1LinhaSelecionada = gvwEndereco.SelectedIndex;
                strEndereco = objManipuladorTexto.mtdExecutarTudo(gvwEndereco.SelectedRow.Cells[1].Text);
                txtEndereco.Text = strEndereco;
            }
            catch (System.Exception ex)
            {
                lblInformacao.Text = "Houve erro ao selecionar o item.";
            }
        }

        private void mtdCarregarGvwEndereco()
        {
            try
            {
                _Default objDefault = new _Default();

                System.Data.DataTable dt = objDefault.mtdSelecionarDadosTabelaEndereco();

                gvwEndereco.DataSource = dt;
                gvwEndereco.DataBind();
            }
            catch (System.Exception ex)
            {
            }
        }
    }
}