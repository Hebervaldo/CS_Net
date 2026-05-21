using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCSNet40
{
    public partial class frmDownloadArquivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblUsuario.Text = login.NomeUsuario;

                    hlkPerfil.Text = Default.strStatusUsuario;

                    lblSaudacao.Text = Default.mtdSaudacao();


                    string[] arquivos = new string[] { };
                    int index = 0;

                    // Obtem a lista de arquivos no diretório imagens
                    //arquivos = System.IO.Directory.GetFiles(Server.MapPath("Armazenamento"));
                    arquivos = System.IO.Directory.GetFiles(Default.DiretorioArmazenamentoCompleto);

                    // removemos o caminho dos arquivos a serem exibidos
                    for (index = 0; index <= arquivos.Length - 1; index++)
                    {
                        arquivos[index] = new System.IO.FileInfo(arquivos[index]).Name;
                    }

                    // vincula a lista dos arquivos ao controle no formulário
                    lstDownloadArquivos.DataSource = arquivos;
                    lstDownloadArquivos.DataBind();

                    // seleciona a primeira entrada da lista
                    lstDownloadArquivos.SelectedIndex = 0;
                }
            }
            catch
            {
            }
        }

        protected void btnDownloadArquivos_Click(object sender, EventArgs e)
        {
            //string nomeArquivo = Server.MapPath("Armazenamento") + @"\" + lstDownloadArquivos.SelectedItem.Text;
            string nomeArquivo = Default.DiretorioArmazenamentoCompleto + @"\" + lstDownloadArquivos.SelectedItem.Text;

            System.IO.FileInfo arquivo = new System.IO.FileInfo(nomeArquivo);

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lstDownloadArquivos.SelectedItem.Text);
            Response.AddHeader("Content-Length", arquivo.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(nomeArquivo);
            Response.End();
        }
    }
}