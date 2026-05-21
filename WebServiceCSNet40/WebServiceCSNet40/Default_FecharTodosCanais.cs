using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WebServiceCSNet40
{
    public partial class Default
    {
        private static System.Threading.Thread ThFecharTodosCanais;

        public static void mtdIniciarThreadFecharTodosCanais()
        {
            try
            {
                mtdAbortarThreadFecharTodosCanais();

                IntervaloThread = 10000;
                ThFecharTodosCanais = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaFecharTodosCanais
                        )
                        );
                ThFecharTodosCanais.IsBackground = true;
                ThFecharTodosCanais.Priority = System.Threading.ThreadPriority.Lowest;
                ThFecharTodosCanais.Start();
            }
            catch (System.Exception ex)
            {
                //mtdAbortarThreadFecharTodosCanais();
            }
        }

        public static void mtdAbortarThreadFecharTodosCanais()
        {
            try
            {
                blnForcarAbortoFecharTodosCanais = true;

                if (ThFecharTodosCanais != null)
                {
                    ThFecharTodosCanais.Abort();
                }
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAbortarThreadFecharTodosCanais: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }

        private static object LockerRotinaFecharTodosCanais = new object();

        private static bool blnForcarAbortoFecharTodosCanais = false;

        private static int IntervaloThread = 10000;

        public static void mtdRotinaFecharTodosCanais()
        {
            lock (LockerRotinaFecharTodosCanais)
            {
                blnForcarAbortoFecharTodosCanais = false;

                WebServicoBancoDados.dblTempoRotinaFecharTodosCanais = System.DateTime.Now.TimeOfDay.TotalMilliseconds;

                IntervaloThread = 10000;

                while (!blnForcarAbortoFecharTodosCanais)
                {
                    WebServicoBancoDados.dblDiferencaTempoRotinaFecharTodosCanais = System.DateTime.Now.TimeOfDay.TotalMilliseconds - WebServicoBancoDados.dblTempoRotinaFecharTodosCanais;

                    WebServicoBancoDados.mtdFecharTodosCanais_();

                    System.GC.Collect(0, System.GCCollectionMode.Optimized);
                    //System.GC.Collect(0, System.GCCollectionMode.Forced);
                }

                System.Threading.Thread.Sleep(IntervaloThread);
            }
        }
    }
}
