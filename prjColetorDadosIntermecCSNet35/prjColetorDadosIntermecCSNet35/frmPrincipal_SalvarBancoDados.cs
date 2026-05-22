using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosIntermecCSNet35
{
    public partial class frmPrincipal
    {
        private System.Threading.Thread ThSalvarBancoDados;

        private void mtdIniciarThreadSalvarBancoDados()
        {
            ThSalvarBancoDados = new System.Threading.Thread
                (
                new System.Threading.ThreadStart
                    (
                    this.mtdRotinaSalvarBancoDados
                    )
                    );
            ThSalvarBancoDados.IsBackground = true;
            ThSalvarBancoDados.Priority = System.Threading.ThreadPriority.Lowest;
            ThSalvarBancoDados.Start();
        }

        private void mtdAbortarThreadSalvarBancoDados()
        {
            try
            {
                ThSalvarBancoDados.Abort();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadSalvarBancoDados: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private int intContador = 1;

        private void mtdRotinaSalvarBancoDados()
        {
            mtdSalvarBancoDados();

            mtdAbortarThreadSalvarBancoDados();
        }

        private static object LockerSalvarBancoDados = new object();

        private void mtdSalvarBancoDados()
        {
            lock (LockerSalvarBancoDados)
            {
                if (frmPrincipal.uintNumeroCopiasBackup != 0)
                {
                    if (intContador <= frmPrincipal.uintNumeroCopiasBackup - 1)
                    {
                        mtdRealizarCopiaBancoDados();

                        intContador++;
                    }
                    else
                    {
                        mtdRealizarCopiaBancoDados();

                        intContador = 1;
                    }
                }
            }
        }

        private void mtdRealizarCopiaBancoDados()
        {
            mtdCopiarArquivo
                (
                strEnderecoBancoDadosColetor,
                strNomeBancoDadosColetor,
                strEnderecoBancoDadosColetor,
                string.Format
                (
                "{0}{1}",
                strNomeBancoDadosColetor.Replace
                (
                cntExtensaoBancoDadosColetor,
                string.Format("Bkp_{0}", intContador)),
                cntExtensaoBancoDadosColetor
                ),
                true
                );

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados
                (
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                );

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE
                (
                clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa,
                string.Format
                (
                "{0}{1}",
                strBaseDadosColetor.Replace(cntExtensaoBancoDadosColetor,
                string.Format("Bkp_{0}", intContador)),
                cntExtensaoBancoDadosColetor
                ),
                strSenhaColetor
                );

            if (objImplementacaoBancoDados.mtdAbrirConexao())
            {
                objImplementacaoBancoDados.mtdFecharConexao();
                blnReparado = mtdRepararBancoDadosColetor();
                blnCompactado = mtdCompactarBancoDadosColetor();
            }

            objImplementacaoBancoDados.Dispose();
        }

        // Método que realiza a cópia do diretório de origem para o diretório de destino especificado.
        public void mtdCopiarArquivo
            (
            string DiretorioOrigem,
            string ArquivoOrigem,
            string DiretorioDestino,
            string ArquivoDestino,
            bool Sobreescrever
            )
        {
            System.IO.DirectoryInfo origemDiretorio = new System.IO.DirectoryInfo(DiretorioOrigem);
            System.IO.FileInfo origemArquivo = new System.IO.FileInfo(ArquivoOrigem);
            System.IO.DirectoryInfo destinoDiretorio = new System.IO.DirectoryInfo(DiretorioDestino);
            System.IO.FileInfo destinoArquivo = new System.IO.FileInfo(ArquivoDestino);

            string origemDiretorioArquivo = System.IO.Path.Combine(origemDiretorio.FullName, origemArquivo.Name);
            string destinoDiretorioArquivo = System.IO.Path.Combine(destinoDiretorio.FullName, destinoArquivo.Name);

            try
            {
                (new System.IO.FileInfo(origemDiretorioArquivo)).CopyTo(destinoDiretorioArquivo, Sobreescrever);
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdCopiarDiretorio: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }
    }
}