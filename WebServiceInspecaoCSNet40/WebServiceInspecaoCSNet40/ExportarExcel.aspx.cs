using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceInspecaoCSNet40
{
    public partial class ExportarExcel : System.Web.UI.Page
    {
        public ExportarExcel()
        {
            new _Default();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            mtdCarregarLstDownloadArquivos();
        }

        private void mtdCarregarLstDownloadArquivos()
        {
            try
            {
                string[] arquivos = new string[] { };
                int index = 0;

                // Obtem a lista de arquivos no diretório imagens
                //arquivos = System.IO.Directory.GetFiles(Server.MapPath("Armazenamento"));
                arquivos = System.IO.Directory.GetFiles(_Default.DiretorioArmazenamentoCompleto);

                // removemos o caminho dos arquivos a serem exibidos
                for (index = 0; index <= arquivos.Length - 1; index++)
                {
                    arquivos[index] = new System.IO.FileInfo(arquivos[index]).Name;
                }

                // vincula a lista dos arquivos ao controle no formulário
                lstDownloadArquivos.DataSource = arquivos;
                lstDownloadArquivos.DataBind();

                // seleciona a primeira entrada da lista
                if (lstDownloadArquivos.Items.Count > 0)
                {
                    lstDownloadArquivos.SelectedIndex = 0;
                }
            }
            catch (System.Exception ex)
            {
            }
        }

        private void mtdExportarExcel(string BaseDados, string Tabela, List<List<object>> Dados)
        {
            if (System.IO.File.Exists(BaseDados))
            {
                System.IO.File.Delete(BaseDados);
            }

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados();

            objImplementacaoBancoDados.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, BaseDados);
            objImplementacaoBancoDados.mtdAbrirInserirPlanilhaExcel_Otimizado(Tabela);
            objImplementacaoBancoDados.mtdCabecalhoInserirPlanilhaExcel_Otimizado(Dados);
            objImplementacaoBancoDados.mtdDadosInserirPlanilhaExcel_Otimizado(Dados, true);
            objImplementacaoBancoDados.mtdFecharInserirPlanilhaExcel_Otimizado(BaseDados);
            objImplementacaoBancoDados.Dispose();
        }

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            WebServiceInspecao objWebServiceInspecao = new WebServiceInspecao();
            _Default objDefault = new _Default();

            mtdExportarExcel
            (
                string.Format(@"{0}\{1}", _Default.DiretorioArmazenamentoCompleto, "dbInspecao.xls").Replace(@"\\", @"\"),
                "Inspecao",
                objWebServiceInspecao.mtdConverterTabelaDadosListaDados(objWebServiceInspecao.mtdObterDadosTabelaInspecao_().Tables[0])
            );

            objDefault.mtdCalcularEstatistica(2);

            mtdExportarExcel
            (
                string.Format(@"{0}\{1}", _Default.DiretorioArmazenamentoCompleto, "dbEstatistica_01.xls").Replace(@"\\", @"\"),
                "Estatistica_01",
                objWebServiceInspecao.mtdConverterTabelaDadosListaDados(objWebServiceInspecao.mtdObterDadosTabelaEstatistica_01_().Tables[0])
            );

            mtdExportarExcel
            (
                string.Format(@"{0}\{1}", _Default.DiretorioArmazenamentoCompleto, "dbEstatistica_02.xls").Replace(@"\\", @"\"),
                "Estatistica_02",
                objWebServiceInspecao.mtdConverterTabelaDadosListaDados(objWebServiceInspecao.mtdObterDadosTabelaEstatistica_02_().Tables[0])
            );

            mtdCarregarLstDownloadArquivos();
        }

        protected void btnDownloadArquivoInspecao_Click(object sender, EventArgs e)
        {
            try
            {
                //string nomeArquivo = Server.MapPath("Armazenamento") + @"\" + lstDownloadArquivos.SelectedItem.Text;
                string nomeArquivo = _Default.DiretorioArmazenamentoCompleto + @"\" + lstDownloadArquivos.Items[2].Text;

                System.IO.FileInfo arquivo = new System.IO.FileInfo(nomeArquivo);

                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lstDownloadArquivos.Items[2].Text);
                Response.AddHeader("Content-Length", arquivo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(nomeArquivo);
                Response.End();
            }
            catch (System.Exception ex)
            {
            }
        }

        protected void btnDownloadArquivoEstatistica_01_Click(object sender, EventArgs e)
        {
            try
            {
                //string nomeArquivo = Server.MapPath("Armazenamento") + @"\" + lstDownloadArquivos.SelectedItem.Text;
                string nomeArquivo = _Default.DiretorioArmazenamentoCompleto + @"\" + lstDownloadArquivos.Items[0].Text;

                System.IO.FileInfo arquivo = new System.IO.FileInfo(nomeArquivo);

                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lstDownloadArquivos.Items[0].Text);
                Response.AddHeader("Content-Length", arquivo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(nomeArquivo);
                Response.End();
            }
            catch (System.Exception ex)
            {
            }

        }

        protected void btnDownloadArquivoEstatistica_02_Click(object sender, EventArgs e)
        {
            try
            {
                //string nomeArquivo = Server.MapPath("Armazenamento") + @"\" + lstDownloadArquivos.SelectedItem.Text;
                string nomeArquivo = _Default.DiretorioArmazenamentoCompleto + @"\" + lstDownloadArquivos.Items[1].Text;

                System.IO.FileInfo arquivo = new System.IO.FileInfo(nomeArquivo);

                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lstDownloadArquivos.Items[1].Text);
                Response.AddHeader("Content-Length", arquivo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(nomeArquivo);
                Response.End();
            }
            catch (System.Exception ex)
            {
            }

        }
    }
}