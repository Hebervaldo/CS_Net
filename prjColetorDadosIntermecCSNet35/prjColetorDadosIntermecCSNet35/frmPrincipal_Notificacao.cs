using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosIntermecCSNet35
{
    public partial class frmPrincipal
    {
        private System.Threading.Thread ThNotificacao;

        private void mtdIniciarThreadNotificacao()
        {
            ThNotificacao = new System.Threading.Thread(new System.Threading.ThreadStart(this.mtdRotinaNotificacao));
            ThNotificacao.IsBackground = true;
            ThNotificacao.Priority = System.Threading.ThreadPriority.Lowest;
            ThNotificacao.Start();
        }

        private void mtdAbortarThreadNotificacao()
        {
            try
            {
                ThNotificacao.Abort();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadNotificacao: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdRotinaNotificacao()
        {
            string NewText = "A tabela de dados com os bens foi carregada.";
            if (this.InvokeRequired)
            {
                SetTextCallback f = new SetTextCallback(this.SetText);
                this.Invoke(f, new object[] { NewText });
            }
            else
            {
                SetText(NewText);
            }

            mtdAbortarThreadNotificacao();
        }
    }
}
