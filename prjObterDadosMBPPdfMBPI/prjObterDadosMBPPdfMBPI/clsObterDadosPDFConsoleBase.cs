using System.Text;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace prjObterDadosMBPPdfMBPI
{
    public class clsConverterPDF
    {
        public string mtdPDFExtrairTexto(string Endereco)
        {
            StringBuilder Retorno = new StringBuilder();

            PdfReader LeitorPDF = new PdfReader(Endereco);

            for (int i = 1; i <= LeitorPDF.NumberOfPages; i++)
            {
                Retorno.Append(PdfTextExtractor.GetTextFromPage(LeitorPDF, i));
            }

            return Retorno.ToString();
        }
    }
}