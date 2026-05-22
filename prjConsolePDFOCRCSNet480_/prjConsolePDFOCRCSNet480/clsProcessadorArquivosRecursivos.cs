using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjConsolePDFOCRCSNet480
{
    public class clsProcessadorArquivosRecursivos
    {
        private static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        private List<string> lstArquivo = new List<string>();

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

        public System.Collections.Generic.List<string> mtdObterListaArquivosNoDiretorioInformado(string Diretorio)
        {
            mtdWalkDirectoryTree(Diretorio);

            return lstArquivo;
        }

        public void mtdWalkDirectoryTree(string NomeDiretorio)
        {
            System.IO.DirectoryInfo Directory = (new System.IO.DirectoryInfo(NomeDiretorio));
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = Directory.GetFiles("*.*");

                foreach (var Arquivo in files)
                {
                    lstArquivo.Add(Arquivo.FullName.Trim());
                }
            }

            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                log.Add(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    Console.WriteLine(fi.FullName);
                }

                // Now find all the subdirectories under this directory.
                subDirs = Directory.GetDirectories("*.*");

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    mtdWalkDirectoryTree(dirInfo.FullName);
                }
            }
        }
    }
}
