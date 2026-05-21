using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class frmImportacaoExportacaoDados
    {
        private System.Threading.Thread ThExportarPlanilhaExcelRelatorio;

        private System.Threading.Thread ThExportarPlanilhaExcelSapR3;

        private string strExcelRelatorio = "Relatorio";

        private string strExcelSapR3 = "SapR3";

        private string strNomeProcessoExportarPlanilhaExcelRelatorio = "Exportação de Dados - Inventário de Bens - Excel";

        private string strNomeProcessoExportarPlanilhaExcelSapR3 = "Exportação de Dados - Inventário de Bens - Excel";

        private void mtdIniciarThreadExportarPlanilhaExcelRelatorio()
        {
            mtdIniciarThreadExportarPlanilhaExcelRelatorio(true);
        }

        private void mtdIniciarThreadExportarPlanilhaExcelSapR3()
        {
            mtdIniciarThreadExportarPlanilhaExcelSapR3(true);
        }

        private void mtdIniciarThreadExportarPlanilhaExcelRelatorio(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio;
                blnAbortarThreadExportarPlanilhaExcelRelatorio = !Iniciar;
                blnForcarAbortarThreadExportarPlanilhaExcelRelatorio = false;
                blnThreadAtivadaExportarPlanilhaExcelRelatorio = true;
                blnSucessoExportarPlanilhaExcelRelatorio = false;
                ThExportarPlanilhaExcelRelatorio = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadExportarPlanilhaExcelRelatorio
                        )
                    );
                ThExportarPlanilhaExcelRelatorio.IsBackground = true;
                ThExportarPlanilhaExcelRelatorio.Priority = System.Threading.ThreadPriority.Normal;
                ThExportarPlanilhaExcelRelatorio.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadExportarPlanilhaExcelRelatorio: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdIniciarThreadExportarPlanilhaExcelSapR3(bool Iniciar)
        {
            try
            {
                intProgresso = 0;
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSapR3;
                blnAbortarThreadExportarPlanilhaExcelSapR3 = !Iniciar;
                blnForcarAbortarThreadExportarPlanilhaExcelSapR3 = false;
                blnThreadAtivadaExportarPlanilhaExcelSapR3 = true;
                blnSucessoExportarPlanilhaExcelSapR3 = false;
                ThExportarPlanilhaExcelSapR3 = new System.Threading.Thread
                    (
                    new System.Threading.ThreadStart
                        (
                        mtdRotinaThreadExportarPlanilhaExcelSapR3
                        )
                    );
                ThExportarPlanilhaExcelSapR3.IsBackground = true;
                ThExportarPlanilhaExcelSapR3.Priority = System.Threading.ThreadPriority.Normal;
                ThExportarPlanilhaExcelSapR3.Start();
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdIniciarThreadExportarPlanilhaExcelSapR3: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdReIniciarThreadExportarPlanilhaExcelRelatorio()
        {
            intProgresso = 0;
            strNomeProcessoRelatorio = strNomeProcessoExportarPlanilhaExcelRelatorio;
            blnAbortarThreadExportarPlanilhaExcelRelatorio = false;
            blnForcarAbortarThreadExportarPlanilhaExcelRelatorio = false;

            blnThreadAtivadaExportarPlanilhaExcelRelatorio = true;
            blnSucessoExportarPlanilhaExcelRelatorio = false;
        }

        private void mtdReIniciarThreadExportarPlanilhaExcelSapR3()
        {
            intProgresso = 0;
            strNomeProcessoSapR3 = strNomeProcessoExportarPlanilhaExcelSapR3;
            blnAbortarThreadExportarPlanilhaExcelSapR3 = false;
            blnForcarAbortarThreadExportarPlanilhaExcelSapR3 = false;

            blnThreadAtivadaExportarPlanilhaExcelSapR3 = true;
            blnSucessoExportarPlanilhaExcelSapR3 = false;
        }

        private static bool blnForcarAbortarThreadExportarPlanilhaExcelRelatorio = false;
        private static bool blnAbortarThreadExportarPlanilhaExcelRelatorio = false;
        private static int intTempoSaidaAbortarThreadExportarPlanilhaExcelRelatorio = 1000;

        private static bool blnForcarAbortarThreadExportarPlanilhaExcelSapR3 = false;
        private static bool blnAbortarThreadExportarPlanilhaExcelSapR3 = false;
        private static int intTempoSaidaAbortarThreadExportarPlanilhaExcelSapR3 = 1000;

        private void mtdAbortarThreadExportarPlanilhaExcelRelatorio()
        {
            mtdAbortarThreadExportarPlanilhaExcelRelatorio(false);
        }

        private void mtdAbortarThreadExportarPlanilhaExcelSapR3()
        {
            mtdAbortarThreadExportarPlanilhaExcelSapR3(false);
        }

        private void mtdAbortarThreadExportarPlanilhaExcelRelatorio(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcessoRelatorio = strNomeProcessoExportarPlanilhaExcelRelatorio;
            blnAbortarThreadExportarPlanilhaExcelRelatorio = true;
            blnForcarAbortarThreadExportarPlanilhaExcelRelatorio = Forcar;

            blnThreadAtivadaExportarPlanilhaExcelRelatorio = false;
            blnSucessoExportarPlanilhaExcelRelatorio = false;

            try
            {
                ThExportarPlanilhaExcelRelatorio.Join(intTempoSaidaAbortarThreadExportarPlanilhaExcelRelatorio);
                ThExportarPlanilhaExcelRelatorio.Abort();
                ThExportarPlanilhaExcelRelatorio = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadExportarPlanilhaExcelRelatorio: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdAbortarThreadExportarPlanilhaExcelSapR3(bool Forcar)
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSapR3;
            blnAbortarThreadExportarPlanilhaExcelSapR3 = true;
            blnForcarAbortarThreadExportarPlanilhaExcelSapR3 = Forcar;

            blnThreadAtivadaExportarPlanilhaExcelSapR3 = false;
            blnSucessoExportarPlanilhaExcelSapR3 = false;

            try
            {
                ThExportarPlanilhaExcelSapR3.Join(intTempoSaidaAbortarThreadExportarPlanilhaExcelSapR3);
                ThExportarPlanilhaExcelSapR3.Abort();
                ThExportarPlanilhaExcelSapR3 = null;
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdAbortarThreadExportarPlanilhaExcelSapR3: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdPararThreadExportarPlanilhaExcelRelatorio()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio;
            blnAbortarThreadExportarPlanilhaExcelRelatorio = true;
            blnForcarAbortarThreadExportarPlanilhaExcelRelatorio = true;

            blnThreadAtivadaExportarPlanilhaExcelRelatorio = false;
            blnSucessoExportarPlanilhaExcelRelatorio = false;
        }

        private void mtdPararThreadExportarPlanilhaExcel()
        {
            intProgresso = 100;
            System.Threading.Thread.Sleep(1000);
            intProgresso = 0;
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSapR3;
            blnAbortarThreadExportarPlanilhaExcelSapR3 = true;
            blnForcarAbortarThreadExportarPlanilhaExcelSapR3 = true;

            blnThreadAtivadaExportarPlanilhaExcelSapR3 = false;
            blnSucessoExportarPlanilhaExcelSapR3 = false;
        }

        private static object LockerExportarPlanilhaExcelRelatorio = new object();

        private static object LockerExportarPlanilhaExcelSapR3 = new object();

        private void mtdRotinaThreadExportarPlanilhaExcelRelatorio()
        {
            while (true)
            {
                if (!blnAbortarThreadExportarPlanilhaExcelRelatorio)
                {
                    //System.Threading.Monitor.Enter(LockerExportarPlanilhaExcelRelatorio);
                    lock (LockerExportarPlanilhaExcelRelatorio)
                    {
                        try
                        {
                            mtdExportarPlanilhaExcelRelatorio(Default.vetCamposTabelaInventarioBens[0], "%");
                            mtdAbortarThreadExportarPlanilhaExcelRelatorio(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockerExportarPlanilhaExcelRelatorio);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private void mtdRotinaThreadExportarPlanilhaExcelSapR3()
        {
            while (true)
            {
                if (!blnAbortarThreadExportarPlanilhaExcelSapR3)
                {
                    //System.Threading.Monitor.Enter(LockerExportarPlanilhaExcelSapR3);
                    lock (LockerExportarPlanilhaExcelSapR3)
                    {
                        try
                        {
                            mtdExportarPlanilhaExcelSapR3(Default.vetCamposTabelaInventarioBens[0], "%");
                            mtdAbortarThreadExportarPlanilhaExcelSapR3(true);
                        }
                        finally
                        {
                            //System.Threading.Monitor.Exit(LockerExportarPlanilhaExcelSapR3);
                        }
                    }
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        private bool blnThreadAtivadaExportarPlanilhaExcelRelatorio = false;
        private bool blnSucessoExportarPlanilhaExcelRelatorio = false;

        private bool blnThreadAtivadaExportarPlanilhaExcelSapR3 = false;
        private bool blnSucessoExportarPlanilhaExcelSapR3 = false;

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void mtdRenomearDeletarPlanilhasExcelRelatorio(string Endereco_Arquivo)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = default(Microsoft.Office.Interop.Excel.Application);
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook = default(Microsoft.Office.Interop.Excel.Workbook);
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = new Microsoft.Office.Interop.Excel.Worksheet();
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Range chartRange = default(Microsoft.Office.Interop.Excel.Range);

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                try
                {
                    if (xlWorkBook.Sheets.Count > 0)
                    {
                        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Sheets[3];
                        xlWorkSheet.Name = strExcelRelatorio;
                        //Rename the sheet
                    }

                    for (int contador = 1; contador <= 2; contador += 1)
                    {
                        if (xlWorkBook.Sheets.Count > 0)
                        {
                            ((Microsoft.Office.Interop.Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Delete();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    if (xlWorkBook.Sheets.Count > 0)
                    {
                        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Sheets[1];
                        xlWorkSheet.Name = strExcelRelatorio;
                        //Rename the sheet
                    }
                }

                xlWorkSheet.Range["b2", "j2"].Merge(false);

                chartRange = xlWorkSheet.Range["b2", "j2"];
                chartRange.FormulaR1C1 = "A planilha ao lado contém o relatório.";
                chartRange.HorizontalAlignment = 2;
                chartRange.VerticalAlignment = 2;
                chartRange.Font.Bold = true;
                chartRange.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);

                xlWorkBook.SaveAs(Endereco_Arquivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue,
                misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdRenomearDeletarPlanilhasExcelRelatorio: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private void mtdRenomearDeletarPlanilhasExcelSapR3(string Endereco_Arquivo)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = default(Microsoft.Office.Interop.Excel.Application);
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook = default(Microsoft.Office.Interop.Excel.Workbook);
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = new Microsoft.Office.Interop.Excel.Worksheet();
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Range chartRange = default(Microsoft.Office.Interop.Excel.Range);

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                try
                {
                    if (xlWorkBook.Sheets.Count > 0)
                    {
                        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Sheets[3];
                        xlWorkSheet.Name = strExcelSapR3;
                        //Rename the sheet
                    }

                    for (int contador = 1; contador <= 2; contador += 1)
                    {
                        if (xlWorkBook.Sheets.Count > 0)
                        {
                            ((Microsoft.Office.Interop.Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[1]).Delete();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    if (xlWorkBook.Sheets.Count > 0)
                    {
                        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Sheets[1];
                        xlWorkSheet.Name = strExcelSapR3;
                        //Rename the sheet
                    }
                }

                xlWorkSheet.Range["b2", "j2"].Merge(false);

                chartRange = xlWorkSheet.Range["b2", "j2"];
                chartRange.FormulaR1C1 = "A planilha ao lado contém os dados do inventário para serem exportados para o SAP/R3.";
                chartRange.HorizontalAlignment = 2;
                chartRange.VerticalAlignment = 2;
                chartRange.Font.Bold = true;
                chartRange.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);

                xlWorkBook.SaveAs(Endereco_Arquivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue,
                misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception ex)
            {
                string strExcecao = "mtdRenomearDeletarPlanilhasExcel: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private string strQtd = "1";
        private string strUn = "UN";

        private int intNumeroCaracteresPorCampoSAPR3 = 50;

        private void mtdExportarPlanilhaExcelRelatorio(string Campo, string Dado)
        {
            Default.strPlanilhaExcel = strExcelRelatorio;

            //string Extensao = "xls";
            //string Filtro = "Arquivo do Excel 2003 (*.xls)|*.xls|Arquivo do Excel 2007 (*.xlsx)|*.xlsx|Todos Arquivos (*.*)|*.*";
            //string NomeArquivo = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", "Inventario", Campo, Dado, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            //Microsoft.VisualBasic.FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments;
            //Microsoft.VisualBasic.FileIO.FileSystem.CreateDirectory(strPlanilhaExcel);
            //Microsoft.VisualBasic.FileIO.FileSystem.CurrentDirectory = string.Format("{0}\\{1}", Microsoft.VisualBasic.FileIO.FileSystem.CurrentDirectory, strPlanilhaExcel);
            //sfd1.InitialDirectory = Microsoft.VisualBasic.FileIO.FileSystem.CurrentDirectory + "\\";
            //sfd1.FileName = NomeArquivo + "." + Extensao;
            //sfd1.OverwritePrompt = true;
            //sfd1.Filter = Filtro;
            //sfd1.FilterIndex = 1;

            //if (sfd1.ShowDialog() == DialogResult.OK) {

            //mtdRenomearDeletarPlanilhasExcelRelatorio(Default.strBaseDadosExcel);

            string[][] campos = new string[Default.vetCamposTabelaInventarioBens.GetLength(0)][];

            for (int contador = 0; contador <= Default.vetCamposTabelaInventarioBens.GetLength(0) - 1; contador += 1)
            {
                campos[contador] = new string[] 
                {
                    Default.vetCamposTabelaInventarioBens[contador],
			        "CHAR",
			        "255",
			        string.Empty
                };
            }

            string BancoDadosPrincipal = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
            clsImplementacaoBancoDados objBDPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

            objBDPrincipal.mtdSelecionarDados(Default.vetCamposTabelaInventarioBens, "tblInventarioBens", Campo, "LIKE", string.Format("'{0}'", Dado), Campo, true);
            int intNumeroLinhasPrincipal = objBDPrincipal.mtdNumeroLinhas();
            objBDPrincipal.mtdDefinirLeitorDados();
            int intNumeroColunasPrincipal = objBDPrincipal.mtdNumeroColunas();

            string BancoDadosExcel = "Excel";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalExcel = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoExcel = Default.mtdDefinirStringConexao(BancoDadosExcel, ref TipoSistemaGerenciadorBancoDadosRelacionalExcel);
            clsImplementacaoBancoDados objBDExcel = new clsImplementacaoBancoDados(strConexaoExcel, TipoSistemaGerenciadorBancoDadosRelacionalExcel);

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, Default.strBaseDadosExcel);
            //objBDExcel.mtdCriarBancoDadosExcel();
            //objBDExcel.mtdCriarTabela(Default.strPlanilhaExcel, campos);
            //objBDExcel.mtdSelecionarDados(Default.vetCamposTabelaInventarioBens, Default.strPlanilhaExcel);
            //objBDExcel.mtdDefinirLeitorDados();

            string[][] dados = new string[2][];
            //dados[0] = objBDExcel.mtdObterCabecalhoColunas();
            dados[0] = new String[Default.vetCamposTabelaInventarioBens.Length - 1];
            dados[1] = new string[Default.vetCamposTabelaInventarioBens.GetUpperBound(0) + 1];

            for (int contador = 0; contador <= dados[0].Length - 1; contador += 1)
            {
                if (blnAbortarThreadExportarPlanilhaExcelRelatorio & blnForcarAbortarThreadExportarPlanilhaExcelRelatorio) return;

                //dados[0][contador] = string.Format("{0}", dados[0][contador]);
                dados[0][contador] = String.Format("{0}", campos[contador][0]);
            }

            int intLinha = 0;

            intProgresso = 0;
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio;

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(Default.strPlanilhaExcel);
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados);
            intLinha += 1;

            while ((objBDPrincipal.mtdProximoRegistro()))
            {
                if (blnAbortarThreadExportarPlanilhaExcelRelatorio & blnForcarAbortarThreadExportarPlanilhaExcelRelatorio) return;

                DateTime dtDataInventario = (System.DateTime)objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensData_Inventario);
                string strDenominacao = objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensDenominacao).ToString();
                string strDenominacaoExtra = string.Empty;
                if (strDenominacao.Length > 50)
                {
                    strDenominacaoExtra = strDenominacao.Substring(intNumeroCaracteresPorCampoSAPR3);
                    strDenominacao = strDenominacao.Substring(0, intNumeroCaracteresPorCampoSAPR3);
                }

                dados[1][Default.intColunaTabelaInventarioBensNumero_Inventario] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensNumero_Inventario).ToString());
                dados[1][Default.intColunaTabelaInventarioBensData_Inventario] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensData_Inventario).ToString());
                dados[1][Default.intColunaTabelaInventarioBensTRG] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensTRG).ToString());
                dados[1][Default.intColunaTabelaInventarioBensCentroCusto] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensCentroCusto).ToString());
                dados[1][Default.intColunaTabelaInventarioBensOrgao] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensOrgao).ToString());
                dados[1][Default.intColunaTabelaInventarioBensSala] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensSala).ToString());
                dados[1][Default.intColunaTabelaInventarioBensNome] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensNome).ToString());
                dados[1][Default.intColunaTabelaInventarioBensMatricula] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensMatricula).ToString());
                dados[1][Default.intColunaTabelaInventarioBensPatrimonio] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensPatrimonio).ToString());
                dados[1][Default.intColunaTabelaInventarioBensQuantidade] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensQuantidade).ToString());
                dados[1][Default.intColunaTabelaInventarioBensDenominacao] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensDenominacao).ToString());
                dados[1][Default.intColunaTabelaInventarioBensN_Serie] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensN_Serie).ToString());
                dados[1][Default.intColunaTabelaInventarioBensPlaca_Veiculo] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensPlaca_Veiculo).ToString());
                dados[1][Default.intColunaTabelaInventarioBensIdentificacao_Inventario] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensIdentificacao_Inventario).ToString());
                dados[1][Default.intColunaTabelaInventarioBensOutrosDados_Inventario] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensOutrosDados_Inventario).ToString());
                dados[1][Default.intColunaTabelaInventarioBensObservacao] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensObservacao).ToString());
                dados[1][Default.intColunaTabelaInventarioBensColetor] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensColetor).ToString());
                dados[1][Default.intColunaTabelaInventarioBensUsuario_Inventariante] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensUsuario_Inventariante).ToString());
                dados[1][Default.intColunaTabelaInventarioBensMatricula_Inventariante] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensMatricula_Inventariante).ToString());
                dados[1][Default.intColunaTabelaInventarioBensInventario] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensInventario).ToString());
                dados[1][Default.intColunaTabelaInventarioBensFotografia] = String.Format("{0}", String.Empty); //String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensFotografia).ToString());
                dados[1][Default.intColunaTabelaInventarioBensGPS_Latitute] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensGPS_Latitute).ToString());
                dados[1][Default.intColunaTabelaInventarioBensGPS_Longitude] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensGPS_Longitude).ToString());
                dados[1][Default.intColunaTabelaInventarioBensGPS_EllipsoidAltitude] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensGPS_EllipsoidAltitude).ToString());
                dados[1][Default.intColunaTabelaInventarioBensGPS_PositionDilutionOfPrecision] = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensGPS_PositionDilutionOfPrecision).ToString());

                //objBDExcel.mtdInserirDados(Default.strPlanilhaExcel, dados);
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, false);
                
                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal);
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio;
                intLinha++;
            }

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(Default.strBaseDadosExcel);

            intProgresso = 99;
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio;

            objBDPrincipal.Dispose();
            objBDExcel.Dispose();

            //System.Windows.Forms.MessageBox.Show("Os dados da tabela de inventário foram exportadas para uma planilha padrão para upload no SAP/R3.", "Aviso!", MessageBoxButtons.OK);
            //}
        }

        private void mtdExportarPlanilhaExcelSapR3(string Campo, string Dado)
        {
            Default.strPlanilhaExcel = strExcelSapR3;

            //string Extensao = "xls";
            //string Filtro = "Arquivo do Excel 2003 (*.xls)|*.xls|Arquivo do Excel 2007 (*.xlsx)|*.xlsx|Todos Arquivos (*.*)|*.*";
            //string NomeArquivo = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", "Inventario", Campo, Dado, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            //Microsoft.VisualBasic.FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments;
            //Microsoft.VisualBasic.FileIO.FileSystem.CreateDirectory(strPlanilhaExcel);
            //Microsoft.VisualBasic.FileIO.FileSystem.CurrentDirectory = string.Format("{0}\\{1}", Microsoft.VisualBasic.FileIO.FileSystem.CurrentDirectory, strPlanilhaExcel);
            //sfd1.InitialDirectory = Microsoft.VisualBasic.FileIO.FileSystem.CurrentDirectory + "\\";
            //sfd1.FileName = NomeArquivo + "." + Extensao;
            //sfd1.OverwritePrompt = true;
            //sfd1.Filter = Filtro;
            //sfd1.FilterIndex = 1;

            //if (sfd1.ShowDialog() == DialogResult.OK) {
            //mtdRenomearDeletarPlanilhasExcelSapR3(Default.strBaseDadosExcel);

            string[][] campos = new string[Default.vetCamposTabelaExportacaoMassaExcel.GetLength(0)][];

            for (int contador = 0; contador <= Default.vetCamposTabelaExportacaoMassaExcel.GetLength(0) - 1; contador += 1)
            {
                campos[contador] = new string[] 
                {
                    Default.vetCamposTabelaExportacaoMassaExcel[contador],
			        "CHAR",
			        "255",
			        string.Empty
                };
            }

            string BancoDadosPrincipal = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalPrincipal = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoPrincipal = Default.mtdDefinirStringConexao(BancoDadosPrincipal, ref TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);
            clsImplementacaoBancoDados objBDPrincipal = new clsImplementacaoBancoDados(strConexaoPrincipal, TipoSistemaGerenciadorBancoDadosRelacionalPrincipal);

            objBDPrincipal.mtdSelecionarDados(Default.vetCamposTabelaInventarioBens, "tblInventarioBens", Campo, "LIKE", string.Format("'{0}'", Dado), Campo, true);
            int intNumeroLinhasPrincipal = objBDPrincipal.mtdNumeroLinhas();
            objBDPrincipal.mtdDefinirLeitorDados();
            int intNumeroColunasPrincipal = objBDPrincipal.mtdNumeroColunas();

            string BancoDadosExcel = "Excel";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacionalExcel = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexaoExcel = Default.mtdDefinirStringConexao(BancoDadosExcel, ref TipoSistemaGerenciadorBancoDadosRelacionalExcel);
            clsImplementacaoBancoDados objBDExcel = new clsImplementacaoBancoDados(strConexaoExcel, TipoSistemaGerenciadorBancoDadosRelacionalExcel);

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, Default.strBaseDadosExcel);
            //objBDExcel.mtdCriarBancoDadosExcel();
            //objBDExcel.mtdCriarTabela(Default.strPlanilhaExcel, campos);
            //objBDExcel.mtdSelecionarDados(Default.vetCamposTabelaExportacaoMassaExcel, Default.strPlanilhaExcel);
            //objBDExcel.mtdDefinirLeitorDados();

            string[][] dados = new string[2][];
            //dados[0] = objBDExcel.mtdObterCabecalhoColunas();
            dados[0] = new String[Default.vetCamposTabelaExportacaoMassaExcel.Length - 1];
            dados[1] = new string[Default.vetCamposTabelaExportacaoMassaExcel.GetUpperBound(0) + 1];

            for (int contador = 0; contador <= dados[0].Length - 1; contador += 1)
            {

                if (blnAbortarThreadExportarPlanilhaExcelSapR3 & blnForcarAbortarThreadExportarPlanilhaExcelSapR3) return;

                //dados[0][contador] = string.Format("{0}", dados[0][contador]);
                dados[0][contador] = String.Format("{0}", campos[contador][0]);
            }

            int intLinha = 0;

            intProgresso = 0;
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSapR3;

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(Default.strPlanilhaExcel);
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados);
            intLinha += 1;

            while ((objBDPrincipal.mtdProximoRegistro()))
            {
                if (blnAbortarThreadExportarPlanilhaExcelSapR3 & blnForcarAbortarThreadExportarPlanilhaExcelSapR3) return;

                DateTime dtDataInventario = (System.DateTime)objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensData_Inventario);
                string strDenominacao = objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensDenominacao).ToString();
                string strDenominacaoExtra = string.Empty;
                if (strDenominacao.Length > 50)
                {
                    strDenominacaoExtra = strDenominacao.Substring(intNumeroCaracteresPorCampoSAPR3);
                    strDenominacao = strDenominacao.Substring(0, intNumeroCaracteresPorCampoSAPR3);
                }

                dados[1][Default.intColunaTabelaExportacaoMassaExcelImobilizado] = string.Format("{0}", mtdObterImobilizadoBens(objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensPatrimonio).ToString()));
                dados[1][Default.intColunaTabelaExportacaoMassaExcelDenomin] = string.Format("{0}", strDenominacao);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelDenomin_Extra] = string.Format("{0}", strDenominacaoExtra);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelSerie] = string.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensN_Serie).ToString());
                dados[1][Default.intColunaTabelaExportacaoMassaExcelPatrimonio] = string.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensPatrimonio).ToString());
                dados[1][Default.intColunaTabelaExportacaoMassaExcelQtd] = string.Format("{0}", strQtd);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelUn] = string.Format("{0}", strUn);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelUlt_invent] = string.Format("{0}", string.Format("{0:00}{1:00}{2:0000}", dtDataInventario.Day, dtDataInventario.Month, dtDataInventario.Year));
                dados[1][Default.intColunaTabelaExportacaoMassaExcelNt_Invent] = string.Format("{0}", string.Format("IN{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensNumero_Inventario)));
                dados[1][Default.intColunaTabelaExportacaoMassaExcelAtiv] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelCc] = string.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensCentroCusto).ToString());
                dados[1][Default.intColunaTabelaExportacaoMassaExcelCcR] = string.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensCentroCusto).ToString());
                dados[1][Default.intColunaTabelaExportacaoMassaExcelCen_Dep] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelEnder] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelSala] = string.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensSala).ToString());
                dados[1][Default.intColunaTabelaExportacaoMassaExcelMatr] = string.Format("{0}", objBDPrincipal.mtdObterValorRegistro(Default.intColunaTabelaInventarioBensMatricula).ToString());
                dados[1][Default.intColunaTabelaExportacaoMassaExcelUc] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelUar] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelOdi] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelTp] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelLocal] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelGener] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelFornec] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelDoc_Aquis] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelCD] = string.Format("{0}", string.Empty);
                dados[1][Default.intColunaTabelaExportacaoMassaExcelOrigem] = string.Format("{0}", string.Empty);

                //objBDExcel.mtdInserirDados(Default.strPlanilhaExcel, dados);
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, false);

                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal);
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSapR3;
                intLinha++;
            }

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(strConexaoExcel);

            intProgresso = 99;
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSapR3;

            objBDPrincipal.Dispose();
            objBDExcel.Dispose();

            //System.Windows.Forms.MessageBox.Show("Os dados da tabela de inventário foram exportadas para uma planilha padrão para upload no SAP/R3.", "Aviso!", MessageBoxButtons.OK);
            //}
        }

        public string mtdObterImobilizadoBens(string Patrimonio)
        {
            string saida = string.Empty;
            string strTabela = Default.strTabelaBensEletronorte;
            string strCampo = Default.vetCamposTabelaBensEletronortePrincipal[0];

            string BancoDados = "Principal";

            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional = new clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional();
            string strConexao = Default.mtdDefinirStringConexao(BancoDados, ref TipoSistemaGerenciadorBancoDadosRelacional);
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexao, TipoSistemaGerenciadorBancoDadosRelacional);

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess();
            objImplementacaoBancoDados.mtdSelecionarDados(string.Format("{0}, {1}", strCampo, "Patrimonio"), strTabela, "Patrimonio", "LIKE", string.Format("'{0}'", Patrimonio), strCampo, false);
            objImplementacaoBancoDados.mtdDefinirLeitorDados();

            if (objImplementacaoBancoDados.mtdProximoRegistro())
            {
                int intColuna = objImplementacaoBancoDados.mtdObterNumeroColuna(strCampo);
                saida = objImplementacaoBancoDados.mtdObterValorRegistro(intColuna).ToString();
            }

            objImplementacaoBancoDados.Dispose();

            return saida;
        }
    }
}