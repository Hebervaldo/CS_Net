using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjObterDadosMBPPdfMBPI
{
    public class clsProcessadorArquivosRecursivos
    {
        public bool mtdVerificarExistenciaArquivo(string EnderecoArquivo)
        {
            bool Retorno = false;

            string[] EntradasAqruivos = System.IO.Directory.GetFiles(EnderecoArquivo);
            foreach (string NomeArquivo in EntradasAqruivos)
            {
                Retorno = System.IO.File.Exists(NomeArquivo);
            }

            return Retorno;
        }

        public bool mtdVerificarExistenciaDiretorio(string EnderecoDiretorio)
        {
            bool Retorno = false;

            string[] EntradasDiretorios = System.IO.Directory.GetDirectories(EnderecoDiretorio);
            foreach (string NomeDiretorio in EntradasDiretorios)
            {
                Retorno = System.IO.Directory.Exists(NomeDiretorio);
            }

            return Retorno;
        }

        public List<string> mtdObterEnderecoNomesArquivos(string EnderecoDiretorio)
        {
            List<string> lstEnderecoNomeArquivo = new List<string>();

            while (mtdVerificarExistenciaDiretorio(EnderecoDiretorio))
            {
                mtdObterEnderecoNomesArquivos(EnderecoDiretorio);
            }

            foreach (var Arquivo in System.IO.Directory.GetFiles(EnderecoDiretorio))
            {
                lstEnderecoNomeArquivo.Add(Arquivo.Trim());
            }

            return lstEnderecoNomeArquivo;
        }
    }
}
