using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WebServiceCSNet40
{
    public partial class WebServicoBancoDados
    {
        private System.Threading.Thread ThsetTabelaInventarioBens;

        private void mtdIniciarThreadsetTabelaInventarioBens()
        {
            try
            {
                ThsetTabelaInventarioBens = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        this.mtdRotinasetTabelaInventarioBens
                        )
                    );
                ThsetTabelaInventarioBens.IsBackground = true;
                ThsetTabelaInventarioBens.Priority = System.Threading.ThreadPriority.Normal;
                ThsetTabelaInventarioBens.Start();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdIniciarThreadsetTabelaInventarioBens: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private void mtdAbortarThreadsetTabelaInventarioBens()
        {
            try
            {
                ThsetTabelaInventarioBens.Abort();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadsetTabelaInventarioBens: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private static object LockerRotinasetTabelaInventarioBens = new object();

        private void mtdRotinasetTabelaInventarioBens()
        {
            lock (LockerRotinasetTabelaInventarioBens)
            {
                setTabelaInventarioBens_(BancoDados_setTabelaInventarioBens, AjustadorDados_setTabelaInventarioBens, NumeroIdentificacao_setTabelaInventarioBens);
                //mtdAbortarThreadsetTabelaInventarioBens();
            }
        }
    }
}
