using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjObterDadosMBPPdfMBPI
{
    internal class Program
    {
        private static string strResultado = string.Empty;

        public static void Main(string[] args)
        {
            mtdObterDadosMBPPdfMBPI();
        }

        public static void mtdObterDadosMBPPdfMBPI()
        {
            clsConverterPDF objConverterPDF = new clsConverterPDF();
            clsProcessadorArquivosRecursivos objProcessadorArquivosRecursivos = new clsProcessadorArquivosRecursivos();
            clsManipularBancoDadosExcel objManipularBancoDadosExcel = new clsManipularBancoDadosExcel();

            Console.Clear();

            string strNumeroMPBI = string.Empty;
            string strOrgaoDestino = string.Empty;
            string strLocalDestino = string.Empty;
            string strNomeRecebedor = string.Empty;
            bool blnPermitirMatriculaRecebedor = false;
            string strMatriculaRecebedor = string.Empty;
            DateTime dtDataCriacaoArquivo = new DateTime();
            bool blnPermitirPatrimonio = false;
            List<string> lstPatrimonio = new List<string> { };
            ulong ulgPatrimonio = 0;
            string strNomeDiretorio = @"C:\Users\Usuario\Desktop\MBPs_AD\";
            string[] vetTeste;

            objManipularBancoDadosExcel.mtdCriarBancoDadosTabela("bdMBPI", "tblMBPI");

            List<string> lstNomeArquivo = objProcessadorArquivosRecursivos.mtdObterEnderecoNomesArquivos(strNomeDiretorio);
            foreach (string strNomeArquivo in lstNomeArquivo)
            {
                strResultado = objConverterPDF.mtdPDFExtrairTexto(strNomeArquivo);
                string[] vetStrResultado = strResultado.Split('\n');
                dtDataCriacaoArquivo = System.IO.File.GetCreationTime(strNomeArquivo);

                for (int i = 0; i <= vetStrResultado.Length - 1; i++)
                {
                    if (vetStrResultado[i].Contains(@"Beneficiado"))
                    {
                        vetTeste = vetStrResultado[i].Split(':');
                        strNomeRecebedor = vetStrResultado[i].Split(':')[1].Trim();
                    }

                    if (vetStrResultado[i].Contains(@"Matrícula "))
                    {
                        vetTeste = vetStrResultado[i].Split(':');
                        strMatriculaRecebedor = vetStrResultado[i].Split(' ')[1].Trim();
                    }

                    if (vetStrResultado[i].Contains("GSCTA"))
                    {
                        string strAuxiliar = vetStrResultado[i].Split(' ')[1].Trim();

                        if (strAuxiliar != string.Empty)
                        {
                            strNumeroMPBI = strAuxiliar;
                        }
                    }

                    if (vetStrResultado[i].Contains(@"De uma UD para outra"))
                    {
                        string[] vetVetStrResultado = vetStrResultado[i].Split(' ');
                        strOrgaoDestino = vetVetStrResultado[vetVetStrResultado.Length - 2].Trim();
                        strLocalDestino = vetVetStrResultado[vetVetStrResultado.Length - 3].Trim();
                    }

                    if (vetStrResultado[i].Contains("Cadastro"))
                    {
                        blnPermitirPatrimonio = false;
                    }

                    if (blnPermitirPatrimonio)
                    {
                        try
                        {
                            ulgPatrimonio = System.Convert.ToUInt64(vetStrResultado[i].Split(' ')[1].Trim());
                            objManipularBancoDadosExcel.mtdPopularDados(strNumeroMPBI, ulgPatrimonio.ToString(), strNomeRecebedor, strMatriculaRecebedor, strOrgaoDestino, strLocalDestino);
                        }
                        catch (System.Exception ex)
                        {

                        }
                    }

                    if (vetStrResultado[i].Contains("Patr"))
                    {
                        blnPermitirPatrimonio = true;
                    }
                }
            }

            objManipularBancoDadosExcel.mtdInserirDados();
        }
    }
}
