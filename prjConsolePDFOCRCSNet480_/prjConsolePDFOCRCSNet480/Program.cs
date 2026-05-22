using System;
using System.Text;

namespace prjConsolePDFOCRCSNet480
{
    internal class Program
    {
        private static clsManipularBancoDadosAccess objManipularBancoDadosAccess = new clsManipularBancoDadosAccess();
        // private static clsManipularBancoDadosExcel objManipularBancoDadosExcel = new clsManipularBancoDadosExcel();
        private static clsUtilitarios objUtilitarios = new clsUtilitarios();

        private static string strCaminhoCompletoArquivo = string.Empty;

        private static ulong ulgId = 0;
        private static string strDescricao = string.Empty;
        private static ulong ulgPagina = 0;
        private static string strDocumento = string.Empty;
        private static string strTexto_ocr = string.Empty;
        private static string strIndice = string.Empty;

        static void Main(string[] args)
        {
            clsProcessadorArquivosRecursivos objProcessadorArquivosRecursivos = new clsProcessadorArquivosRecursivos();

            objManipularBancoDadosAccess.mtdCriarBancoDadosTabela("bdArquivosDigitalizados", "tblArquivosDigitalizados");
            // objManipularBancoDadosExcel.mtdCriarBancoDadosTabela("bdArquivosDigitalizados", "tblArquivosDigitalizados");

            string strEnderecoArquivo = @"C:\Users\Usuario\Desktop\DVD 01\";
            string strNumerosCDObtido = string.Empty;

            uint uintContadorLstArquivo = 1;
            uint uintTotalLstArquivo = 0;

            System.Collections.Generic.List<string> lstArquivo = objProcessadorArquivosRecursivos.mtdObterListaArquivosNoDiretorioInformado(strEnderecoArquivo);
            uintTotalLstArquivo = (uint) lstArquivo.Count;

            foreach (string strArquivo in lstArquivo)
            {
                if (strArquivo.Contains(".pdf"))
                {
                    strNumerosCDObtido = mtdConverterPDFOCRTexto(strArquivo);
                    System.Console.WriteLine(string.Format(@"Arquivo processado ({0}/{1}): {2}{3} - {4}", uintContadorLstArquivo, uintTotalLstArquivo, strEnderecoArquivo, strArquivo, strNumerosCDObtido));
                }

                uintContadorLstArquivo++;
            }

            objManipularBancoDadosAccess.mtdFecharConexaoBancoDados();
        }

        public static string mtdConverterPDFOCRTexto(string Arquivo)
        {
            string Retorno = string.Empty;

            try
            {
                // Console.Clear();

                objManipularBancoDadosAccess.mtdAbrirConexaoBancoDados();

                strCaminhoCompletoArquivo = Arquivo;
                ulgPagina = 0;

                // Load PDF

                Spire.Pdf.PdfDocument doc = new Spire.Pdf.PdfDocument(Arquivo);
                doc.LoadFromFile(strCaminhoCompletoArquivo);
                //Extract text from every page
                StringBuilder buffer = new StringBuilder();
                foreach (Spire.Pdf.PdfPageBase page in doc.Pages)
                {
                    // buffer.Append(page.ExtractText());

                    ulgId = ulgId + 1;
                    strDescricao = string.Format("'{0}'", (new System.IO.FileInfo(Arquivo)).Name);
                    ulgPagina = ulgPagina + 1;
                    strDocumento = string.Format("'{0}'", strCaminhoCompletoArquivo);
                    strTexto_ocr = string.Format("'{0}'", objUtilitarios.mtdExecutarTudo(objUtilitarios.mtdRetirarEspacoExtra(page.ExtractText()).Replace("Evaluation Warning : The document was created with Spire.PDF for .NET.", string.Empty)));
                    strIndice = string.Format("'{0}'", mtdObterNumeroDocumentoCD(strTexto_ocr));

                    objManipularBancoDadosAccess.mtdPopularDados(ulgId, strDescricao, ulgPagina, strDocumento, strTexto_ocr, strIndice);
                    // objManipularBancoDadosExcel.mtdPopularDados(ulgId, strDescricao, ulgPagina, strDocumento, strTexto_ocr, strIndice);

                    //Write to a txt file
                    // String fileName = EnderecoArquivo + NomeArquivo_OCR;
                    // System.IO.File.WriteAllText(fileName, buffer.ToString());
                }

                objManipularBancoDadosAccess.mtdInserirDados();
                // objManipularBancoDadosExcel.mtdInserirDados();
                objManipularBancoDadosAccess.mtdResetarDados();

                Retorno = strIndice;
            }
            catch (System.Exception ex)
            {

            }

            return Retorno;
        }

        private static string mtdObterNumeroDocumentoCD(string ConteudoDocumento)
        {
            string Retorno = string.Empty;

            string[] vetConteudoDocumento = ConteudoDocumento.Split(' ');
            string strConConteudoDocumentoAbsoluto = ConteudoDocumento.Replace(@" ", string.Empty);
            char[] vetChrConteudoDocumentoAbsoluto = strConConteudoDocumentoAbsoluto.ToCharArray();

            string strAcumulador = string.Empty;
            System.Collections.Generic.List<char> lstChrAcumulador = new System.Collections.Generic.List<char> { };
            int intTermosNumero = 0;
            int intIndiceComprovantedeDiario = strConConteudoDocumentoAbsoluto.IndexOf("COMPROVANTEDEDIARIO");
            int intIndiceNumeroDocumento = strConConteudoDocumentoAbsoluto.IndexOf("NUMERODOCUMENTO");
            int intIndiceExcercicio = strConConteudoDocumentoAbsoluto.IndexOf("EXERCICIO:");

            if (intIndiceComprovantedeDiario > -1)
            {
                if (intIndiceExcercicio > -1)
                {
                    strAcumulador = string.Empty;

                    lstChrAcumulador.Clear();

                    for (int k = intIndiceNumeroDocumento + 12; k <= intIndiceNumeroDocumento + 27; k = k + 1)
                    {
                        lstChrAcumulador.Add(vetChrConteudoDocumentoAbsoluto[k]);
                    }

                    intTermosNumero = 0;

                    for (int l = 0; l <= lstChrAcumulador.Count - 1; l = l + 1)
                    {
                        if (System.Convert.ToInt16(lstChrAcumulador[l]) >= 48 && (System.Convert.ToInt16(lstChrAcumulador[l]) <= 57))
                        {
                            intTermosNumero = intTermosNumero + 1;
                            strAcumulador += lstChrAcumulador[l];
                        }

                        if (intTermosNumero >= 10)
                        {
                            break;
                        }
                    }

                    Retorno += string.Format("CD: {0} - ", strAcumulador);
                }

                if (intIndiceExcercicio > -1)
                {
                    strAcumulador = string.Empty;

                    lstChrAcumulador.Clear();

                    for (int k = intIndiceExcercicio + 10; k <= intIndiceExcercicio + 20; k = k + 1)
                    {
                        lstChrAcumulador.Add(vetChrConteudoDocumentoAbsoluto[k]);
                    }

                    intTermosNumero = 0;

                    for (int l = 0; l <= lstChrAcumulador.Count - 1; l = l + 1)
                    {
                        if (System.Convert.ToInt16(lstChrAcumulador[l]) >= 48 && (System.Convert.ToInt16(lstChrAcumulador[l]) <= 57))
                        {
                            intTermosNumero = intTermosNumero + 1;
                            strAcumulador += lstChrAcumulador[l];
                        }

                        if (intTermosNumero >= 4)
                        {
                            break;
                        }
                    }

                    Retorno += string.Format("{0}.", strAcumulador);
                }
            }

            return Retorno;
        }
    }
}