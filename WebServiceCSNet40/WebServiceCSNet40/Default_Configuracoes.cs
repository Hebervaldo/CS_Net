using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceCSNet40
{
    public partial class Default
    {
        private const bool blnEscolherRegistro = false;

        private static void _mtdEnderecoTexto()
        {
            try
            {
                _mtdObterEnderecoTexto();
            }
            catch (Exception ex)
            {
                _mtdSalvarEnderecoTexto();
                _mtdObterEnderecoTexto();

                string strExcecao = "mtdEnderecoTexto: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdNomeTexto()
        {
            try
            {
                _mtdObterNomeTexto();
            }
            catch (Exception ex)
            {
                _mtdSalvarNomeTexto();
                _mtdObterNomeTexto();

                string strExcecao = "mtdNomeTexto: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdEnderecoPrincipal()
        {
            try
            {
                _mtdObterEnderecoPrincipal();
            }
            catch (Exception ex)
            {
                _mtdSalvarEnderecoPrincipal();
                _mtdObterEnderecoPrincipal();

                string strExcecao = "mtdEnderecoPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdNomePrincipal()
        {
            try
            {
                _mtdObterNomePrincipal();
            }
            catch (Exception ex)
            {
                _mtdSalvarNomePrincipal();
                _mtdObterNomePrincipal();

                string strExcecao = "mtdNomePrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdSenhaPrincipal()
        {
            try
            {
                _mtdObterSenhaPrincipal();
            }
            catch (Exception ex)
            {
                _mtdSalvarSenhaPrincipal();
                _mtdObterSenhaPrincipal();

                string strExcecao = "mtdSenhaPrincipal: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdEnderecoExcel()
        {
            try
            {
                _mtdObterEnderecoExcel();
            }
            catch (Exception ex)
            {
                _mtdSalvarEnderecoExcel();
                _mtdObterEnderecoExcel();

                string strExcecao = "mtdEnderecoExcel: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdNomeExcel()
        {
            try
            {
                _mtdObterNomeExcel();
            }
            catch (Exception ex)
            {
                _mtdSalvarNomeExcel();
                _mtdObterNomeExcel();

                string strExcecao = "mtdNomeExcel: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        //private static void _mtdSenhaExcel()
        //{
        //    try
        //    {
        //        _mtdObterSenhaExcel();
        //    }
        //    catch (Exception ex)
        //    {
        //        _mtdSalvarSenhaExcel();
        //        _mtdObterSenhaExcel();

        //        string strExcecao = "mtdSenhaExcel: " + ex.Message;
        //        System.Diagnostics.Debug.WriteLine(strExcecao); erro;
        //        // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
        //    }
        //}

        private static void _mtdServidorCADU()
        {
            try
            {
                _mtdObterServidorCADU();
            }
            catch (Exception ex)
            {
                _mtdSalvarServidorCADU();
                _mtdObterServidorCADU();

                string strExcecao = "mtdServidorCADU: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdBancoDadosCADU()
        {
            try
            {
                _mtdObterBancoDadosCADU();
            }
            catch (Exception ex)
            {
                _mtdSalvarBancoDadosCADU();
                _mtdObterBancoDadosCADU();

                string strExcecao = "mtdBancoDadosCADU: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdUsuarioCADU()
        {
            try
            {
                _mtdObterUsuarioCADU();
            }
            catch (Exception ex)
            {
                _mtdSalvarUsuarioCADU();
                _mtdObterUsuarioCADU();

                string strExcecao = "mtdUsuarioCADU: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdSenhaCADU()
        {
            try
            {
                _mtdObterSenhaCADU();
            }
            catch (Exception ex)
            {
                _mtdSalvarSenhaCADU();
                _mtdObterSenhaCADU();

                string strExcecao = "mtdSenhaCADU: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdTabelaCADU()
        {
            try
            {
                _mtdObterTabelaCADU();
            }
            catch (Exception ex)
            {
                _mtdSalvarTabelaCADU();
                _mtdObterTabelaCADU();

                string strExcecao = "mtdTabelaCADU: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdEnderecoColetor()
        {
            try
            {
                _mtdObterEnderecoColetor();
            }
            catch (Exception ex)
            {
                _mtdSalvarEnderecoColetor();
                _mtdObterEnderecoColetor();

                string strExcecao = "mtdEnderecoColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdNomeColetor()
        {
            try
            {
                _mtdObterNomeColetor();
            }
            catch (Exception ex)
            {
                _mtdSalvarNomeColetor();
                _mtdObterNomeColetor();

                string strExcecao = "mtdNomeColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdSenhaColetor()
        {
            try
            {
                _mtdObterSenhaColetor();
            }
            catch (Exception ex)
            {
                _mtdSalvarSenhaColetor();
                _mtdObterSenhaColetor();

                string strExcecao = "mtdSenhaColetor: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdPermitirControleColetorUpLoad()
        {
            try
            {
                _mtdObterPermitirControleColetorUpLoad();
            }
            catch (Exception ex)
            {
                _mtdSalvarPermitirControleColetorUpLoad();
                _mtdObterPermitirControleColetorUpLoad();

                string strExcecao = "_mtdPermitirControleColetorUpLoad: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                // Default.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", Default.DiretorioArmazenamentoRegistro), strExcecao);
            }
        }

        private static void _mtdSalvarEnderecoTexto()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                        Microsoft.Win32.Registry.CurrentUser,
                        "Software",
                        "Eletronorte",
                        "Principal",
                        "EnderecoArquivoTexto",
                        strEnderecoArquivoTexto,
                        Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "EnderecoArquivoTexto");
                objArquivoTXT.mtdCriadorTexto(strEnderecoArquivoTexto);
            }
        }

        private void mtdSalvarEnderecoTexto()
        {
            strEnderecoArquivoTexto = txtEnderecoTexto.Text;

            _mtdSalvarEnderecoTexto();
        }

        private static void _mtdSalvarNomeTexto()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                      (
                      Microsoft.Win32.Registry.CurrentUser,
                      "Software",
                      "Eletronorte",
                      "Principal",
                      "NomeArquivoTexto",
                      strNomeArquivoTexto,
                      Microsoft.Win32.RegistryValueKind.String
                      );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "NomeArquivoTexto");
                objArquivoTXT.mtdCriadorTexto(strNomeArquivoTexto);
            }
        }

        private void mtdSalvarNomeTexto()
        {
            strNomeArquivoTexto = txtNomeTexto.Text;

            _mtdSalvarNomeTexto();
        }

        private static void _mtdSalvarEnderecoPrincipal()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                      (
                      Microsoft.Win32.Registry.CurrentUser,
                      "Software",
                      "Eletronorte",
                      "Principal",
                      "EnderecoBancoDadosPrincipal",
                      strEnderecoBancoDadosPrincipal,
                      Microsoft.Win32.RegistryValueKind.String
                      );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "EnderecoBancoDadosPrincipal");
                objArquivoTXT.mtdCriadorTexto(strEnderecoBancoDadosPrincipal);
            }
        }

        private void mtdSalvarEnderecoPrincipal()
        {
            strEnderecoBancoDadosPrincipal = txtEnderecoPrincipal.Text;

            _mtdSalvarEnderecoPrincipal();
        }

        private static void _mtdSalvarNomePrincipal()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "NomeBancoDadosPrincipal",
                    strNomeBancoDadosPrincipal,
                    Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "NomeBancoDadosPrincipal");
                objArquivoTXT.mtdCriadorTexto(strNomeBancoDadosPrincipal);
            }
        }

        private void mtdSalvarNomePrincipal()
        {
            strNomeBancoDadosPrincipal = txtNomePrincipal.Text;

            _mtdSalvarNomePrincipal();
        }

        private static void _mtdSalvarSenhaPrincipal()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "SenhaPrincipal",
                    strSenhaPrincipal,
                    Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "SenhaPrincipal");
                objArquivoTXT.mtdCriadorTexto(strSenhaPrincipal);
            }
        }

        private void mtdSalvarSenhaPrincipal()
        {
            strSenhaPrincipal = txtSenhaPrincipal.Text;

            _mtdSalvarSenhaPrincipal();
        }

        private static void _mtdSalvarEnderecoExcel()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                      (
                      Microsoft.Win32.Registry.CurrentUser,
                      "Software",
                      "Eletronorte",
                      "Principal",
                      "EnderecoBancoDadosExcel",
                      strEnderecoBancoDadosExcel,
                      Microsoft.Win32.RegistryValueKind.String
                      );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "EnderecoBancoDadosExcel");
                objArquivoTXT.mtdCriadorTexto(strEnderecoBancoDadosExcel);
            }
        }

        private void mtdSalvarEnderecoExcel()
        {
            strEnderecoBancoDadosExcel = txtEnderecoExcel.Text;

            _mtdSalvarEnderecoExcel();
        }

        private static void _mtdSalvarNomeExcel()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                      (
                      Microsoft.Win32.Registry.CurrentUser,
                      "Software",
                      "Eletronorte",
                      "Principal",
                      "NomeBancoDadosExcel",
                      strNomeBancoDadosExcel,
                      Microsoft.Win32.RegistryValueKind.String
                      );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "NomeBancoDadosExcel");
                objArquivoTXT.mtdCriadorTexto(strNomeBancoDadosExcel);
            }
        }

        private void mtdSalvarNomeExcel()
        {
            strNomeBancoDadosExcel = txtNomeExcel.Text;

            _mtdSalvarNomeExcel();
        }

        //private static void _mtdSalvarSenhaExcel()
        //{            
        //    objArquivoTXT = new clsArquivoTXT();
        //    if (blnEscolherRegistro)
        //    {
        //        objRegistroWindows.mtdSalvarDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "Principal",
        //            "SenhaExcel",
        //            strSenhaExcel,
        //            Microsoft.Win32.RegistryValueKind.String
        //            );
        //    }
        //    else
        //    {
        //        objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "SenhaExcel");
        //        objArquivoTXTmtdCriadorTexto()(strSenhaExcel);
        //    }
        //}

        //private void mtdSalvarSenhaExcel()
        //{
        //    strSenhaExcel = txtSenhaExcel.Text;

        //    _mtdSalvarSenhaExcel();
        //}

        private static void _mtdSalvarServidorCADU()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "ServidorCADU",
                    strServidorCADU,
                    Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "ServidorCADU");
                objArquivoTXT.mtdCriadorTexto(strServidorCADU);
            }
        }

        private void mtdSalvarServidorCADU()
        {
            strServidorCADU = txtServidorCADU.Text;

            _mtdSalvarServidorCADU();
        }

        private static void _mtdSalvarBancoDadosCADU()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "BancoDadosCADU",
                    strBancoDadosCADU,
                    Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "BancoDadosCADU");
                objArquivoTXT.mtdCriadorTexto(strBancoDadosCADU);
            }
        }

        private void mtdSalvarBancoDadosCADU()
        {
            strBancoDadosCADU = txtBancoDadosCADU.Text;

            _mtdSalvarBancoDadosCADU();
        }

        private static void _mtdSalvarUsuarioCADU()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "UsuarioCADU",
                    strUsuarioCADU,
                    Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "UsuarioCADU");
                objArquivoTXT.mtdCriadorTexto(strUsuarioCADU);
            }
        }

        private void mtdSalvarUsuarioCADU()
        {
            strUsuarioCADU = txtUsuarioCADU.Text;

            _mtdSalvarUsuarioCADU();
        }

        private static void _mtdSalvarSenhaCADU()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "SenhaCADU",
                    strSenhaCADU,
                    Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "SenhaCADU");
                objArquivoTXT.mtdCriadorTexto(strSenhaCADU);
            }
        }

        private void mtdSalvarSenhaCADU()
        {
            strSenhaCADU = txtSenhaCADU.Text;

            _mtdSalvarSenhaCADU();
        }

        private static void _mtdSalvarTabelaCADU()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "TabelaCADU",
                    strTabelaCADU,
                    Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "TabelaCADU");
                objArquivoTXT.mtdCriadorTexto(strTabelaCADU);
            }
        }

        private void mtdSalvarTabelaCADU()
        {
            strTabelaCADU = txtTabelaCADU.Text;

            _mtdSalvarTabelaCADU();
        }

        private static void _mtdSalvarEnderecoColetor()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "EnderecoBancoDadosColetor",
                    strEnderecoBancoDadosColetor,
                    Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "EnderecoBancoDadosColetor");
                objArquivoTXT.mtdCriadorTexto(strEnderecoBancoDadosColetor);
            }
        }

        private void mtdSalvarEnderecoColetor()
        {
            strEnderecoBancoDadosColetor = txtEnderecoColetor.Text;

            _mtdSalvarEnderecoColetor();
        }

        private static void _mtdSalvarNomeColetor()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "NomeBancoDadosColetor",
                    strNomeBancoDadosColetor,
                    Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "NomeBancoDadosColetor");
                objArquivoTXT.mtdCriadorTexto(strNomeBancoDadosColetor);
            }
        }

        private void mtdSalvarNomeColetor()
        {
            strNomeBancoDadosColetor = txtNomeColetor.Text;

            _mtdSalvarNomeColetor();
        }

        private static void _mtdSalvarSenhaColetor()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "SenhaColetor",
                    strSenhaColetor,
                    Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "SenhaColetor");
                objArquivoTXT.mtdCriadorTexto(strSenhaColetor);
            }
        }

        private void mtdSalvarSenhaColetor()
        {
            strSenhaColetor = txtSenhaColetor.Text;

            _mtdSalvarSenhaColetor();
        }

        private static void _mtdSalvarPermitirControleColetorUpLoad()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                objRegistroWindows.mtdSalvarDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "PermitirControleColetorUpLoad",
                    blnPermitirControleColetorUpLoad,
                    Microsoft.Win32.RegistryValueKind.String
                    );
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "PermitirControleColetorUpLoad");
                objArquivoTXT.mtdCriadorTexto(System.Convert.ToString(blnPermitirControleColetorUpLoad));
            }
        }

        private void mtdSalvarPermitirControleColetorUpLoad()
        {
            blnPermitirControleColetorUpLoad = chkPermitirControleColetorUpLoad.Checked;

            _mtdSalvarPermitirControleColetorUpLoad();
        }

        private static void _mtdObterEnderecoTexto()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strEnderecoArquivoTexto = objRegistroWindows.mtdObterDadosRegistro
                      (
                      Microsoft.Win32.Registry.CurrentUser,
                      "Software",
                      "Eletronorte",
                      "Principal",
                      "EnderecoArquivoTexto"
                      ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "EnderecoArquivoTexto");
                strEnderecoArquivoTexto = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strEnderecoArquivoTexto == string.Empty || strEnderecoArquivoTexto == "Não há conteúdo.")
            {
                strEnderecoArquivoTexto = cntEnderecoArquivoTexto;

                _mtdSalvarEnderecoTexto();
            }

            strArquivoTexto = strEnderecoArquivoTexto + strNomeArquivoTexto;
        }

        private void mtdObterEnderecoTexto()
        {
            _mtdObterEnderecoTexto();

            txtEnderecoTexto.Text = strEnderecoArquivoTexto;
        }

        private static void _mtdObterNomeTexto()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strNomeArquivoTexto = objRegistroWindows.mtdObterDadosRegistro
                         (
                         Microsoft.Win32.Registry.CurrentUser,
                         "Software",
                         "Eletronorte",
                         "Principal",
                         "NomeArquivoTexto"
                         ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "NomeArquivoTexto");
                strNomeArquivoTexto = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strNomeArquivoTexto == string.Empty || strNomeArquivoTexto == "Não há conteúdo.")
            {
                strNomeArquivoTexto = cntNomeArquivoTexto;

                _mtdSalvarNomeTexto();
            }

            strArquivoTexto = strEnderecoArquivoTexto + strNomeArquivoTexto;
        }

        private void mtdObterNomeTexto()
        {
            _mtdObterNomeTexto();

            txtNomeTexto.Text = strNomeArquivoTexto;
        }

        private static void _mtdObterEnderecoPrincipal()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strEnderecoBancoDadosPrincipal = objRegistroWindows.mtdObterDadosRegistro
                      (
                      Microsoft.Win32.Registry.CurrentUser,
                      "Software",
                      "Eletronorte",
                      "Principal",
                      "EnderecoBancoDadosPrincipal"
                      ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "EnderecoBancoDadosPrincipal");
                strEnderecoBancoDadosPrincipal = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strEnderecoBancoDadosPrincipal == string.Empty || strEnderecoBancoDadosPrincipal == "Não há conteúdo.")
            {
                strEnderecoBancoDadosPrincipal = cntEnderecoBancoDadosPrincipal;

                _mtdSalvarEnderecoPrincipal();
            }

            strBaseDadosPrincipal = strEnderecoBancoDadosPrincipal + strNomeBancoDadosPrincipal;
        }

        private void mtdObterEnderecoPrincipal()
        {
            _mtdObterEnderecoPrincipal();

            txtEnderecoPrincipal.Text = strEnderecoBancoDadosPrincipal;
        }

        private static void _mtdObterNomePrincipal()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strNomeBancoDadosPrincipal = objRegistroWindows.mtdObterDadosRegistro
                      (
                      Microsoft.Win32.Registry.CurrentUser,
                      "Software",
                      "Eletronorte",
                      "Principal",
                      "NomeBancoDadosPrincipal"
                      ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "NomeBancoDadosPrincipal");
                strNomeBancoDadosPrincipal = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strNomeBancoDadosPrincipal == string.Empty || strNomeBancoDadosPrincipal == "Não há conteúdo.")
            {
                strNomeBancoDadosPrincipal = cntNomeBancoDadosPrincipal;

                _mtdSalvarNomePrincipal();
            }

            strBaseDadosPrincipal = strEnderecoBancoDadosPrincipal + strNomeBancoDadosPrincipal;
        }

        private void mtdObterNomePrincipal()
        {
            _mtdObterNomePrincipal();

            txtNomePrincipal.Text = strNomeBancoDadosPrincipal;
        }

        private static void _mtdObterSenhaPrincipal()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strSenhaPrincipal = objRegistroWindows.mtdObterDadosRegistro
                     (
                     Microsoft.Win32.Registry.CurrentUser,
                     "Software",
                     "Eletronorte",
                     "Principal",
                     "SenhaPrincipal"
                     ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "SenhaPrincipal");
                strSenhaPrincipal = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strSenhaPrincipal == string.Empty || strSenhaPrincipal == "Não há conteúdo.")
            {
                strSenhaPrincipal = cntSenhaPrincipal;

                _mtdSalvarSenhaPrincipal();
            }
        }

        private void mtdObterSenhaPrincipal()
        {
            _mtdObterSenhaPrincipal();

            txtSenhaPrincipal.Text = strSenhaPrincipal;
        }

        private static void _mtdObterEnderecoExcel()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strEnderecoBancoDadosExcel = objRegistroWindows.mtdObterDadosRegistro
                      (
                      Microsoft.Win32.Registry.CurrentUser,
                      "Software",
                      "Eletronorte",
                      "Principal",
                      "EnderecoBancoDadosExcel"
                      ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "EnderecoBancoDadosExcel");
                strEnderecoBancoDadosExcel = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strEnderecoBancoDadosExcel == string.Empty || strEnderecoBancoDadosExcel == "Não há conteúdo.")
            {
                strEnderecoBancoDadosExcel = cntEnderecoBancoDadosExcel;

                _mtdSalvarEnderecoExcel();
            }

            strBaseDadosExcel = strEnderecoBancoDadosExcel + strNomeBancoDadosExcel;
        }

        private void mtdObterEnderecoExcel()
        {
            _mtdObterEnderecoExcel();

            txtEnderecoExcel.Text = strEnderecoBancoDadosExcel;
        }

        private static void _mtdObterNomeExcel()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                //strNomeBancoDadosExcel = objRegistroWindows.mtdObterDadosRegistro
                //      (
                //      Microsoft.Win32.Registry.CurrentUser,
                //      "Software",
                //      "Eletronorte",
                //      "Principal",
                //      "NomeBancoDadosExcel"
                //      ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "NomeBancoDadosExcel");
                strNomeBancoDadosExcel = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strNomeBancoDadosExcel == string.Empty || strNomeBancoDadosExcel == "Não há conteúdo.")
            {
                strNomeBancoDadosExcel = cntNomeBancoDadosExcel;

                _mtdSalvarNomeExcel();
            }

            strBaseDadosExcel = strEnderecoBancoDadosExcel + strNomeBancoDadosExcel;
        }

        private void mtdObterNomeExcel()
        {
            _mtdObterNomeExcel();

            txtNomeExcel.Text = strNomeBancoDadosExcel;
        }

        //private static void _mtdObterSenhaExcel()
        //{   
        //    objArquivoTXT = new clsArquivoTXT();

        //    if (blnEscolherRegistro)
        //    {
        //        strSenhaExcel = objRegistroWindows.mtdObterDadosRegistro
        //            (
        //            Microsoft.Win32.Registry.CurrentUser,
        //            "Software",
        //            "Eletronorte",
        //            "Principal",
        //            "SenhaExcel"
        //            ).ToString().Trim();
        //    }
        //    else
        //    {
        //        objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "SenhaExcel");
        //        strSenhaExcel = objArquivoTXT.mtdLeitorTexto().Trim();
        //    }

        //    if (strSenhaExcel == string.Empty || strSenhaExcel == "Não há conteúdo.")
        //    {
        //        strSenhaExcel = cntSenhaExcel;

        //        mtdSalvarSenhaExcel();
        //    }
        //}

        //private void mtdObterSenhaExcel()
        //{
        //    _mtdObterSenhaExcel(true);

        //    txtSenhaExcel.Text = strSenhaExcel;
        //}

        private static void _mtdObterServidorCADU()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strServidorCADU = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "ServidorCADU"
                    ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "ServidorCADU");
                strServidorCADU = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strServidorCADU == string.Empty || strServidorCADU == "Não há conteúdo.")
            {
                strServidorCADU = cntServidorCADU;

                _mtdSalvarServidorCADU();
            }
        }

        private void mtdObterServidorCADU()
        {
            _mtdObterServidorCADU();

            txtServidorCADU.Text = strServidorCADU;
        }

        private static void _mtdObterBancoDadosCADU()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strBancoDadosCADU = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "BancoDadosCADU"
                    ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "BancoDadosCADU");
                strBancoDadosCADU = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strBancoDadosCADU == string.Empty || strBancoDadosCADU == "Não há conteúdo.")
            {
                strBancoDadosCADU = cntBancoDadosCADU;

                _mtdSalvarBancoDadosCADU();
            }
        }

        private void mtdObterBancoDadosCADU()
        {
            _mtdObterBancoDadosCADU();

            txtBancoDadosCADU.Text = strBancoDadosCADU;
        }

        private static void _mtdObterUsuarioCADU()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strUsuarioCADU = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "UsuarioCADU"
                    ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "UsuarioCADU");
                strUsuarioCADU = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strUsuarioCADU == string.Empty || strUsuarioCADU == "Não há conteúdo.")
            {
                strUsuarioCADU = cntUsuarioCADU;

                _mtdSalvarUsuarioCADU();
            }
        }

        private void mtdObterUsuarioCADU()
        {
            _mtdObterUsuarioCADU();

            txtUsuarioCADU.Text = strUsuarioCADU;
        }

        private static void _mtdObterSenhaCADU()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strSenhaCADU = objRegistroWindows.mtdObterDadosRegistro
                     (
                     Microsoft.Win32.Registry.CurrentUser,
                     "Software",
                     "Eletronorte",
                     "Principal",
                     "SenhaCADU"
                     ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "SenhaCADU");
                strSenhaCADU = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strSenhaCADU == string.Empty || strSenhaCADU == "Não há conteúdo.")
            {
                strSenhaCADU = cntSenhaCADU;

                _mtdSalvarSenhaCADU();
            }
        }

        private void mtdObterSenhaCADU()
        {
            _mtdObterSenhaCADU();

            txtSenhaCADU.Text = strSenhaCADU;
        }

        private static void _mtdObterTabelaCADU()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strTabelaCADU = objRegistroWindows.mtdObterDadosRegistro
                     (
                     Microsoft.Win32.Registry.CurrentUser,
                     "Software",
                     "Eletronorte",
                     "Principal",
                     "TabelaCADU"
                     ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "TabelaCADU");
                strTabelaCADU = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strTabelaCADU == string.Empty || strTabelaCADU == "Não há conteúdo.")
            {
                strTabelaCADU = cntTabelaCADU;

                _mtdSalvarTabelaCADU();
            }
        }

        private void mtdObterTabelaCADU()
        {
            _mtdObterTabelaCADU();

            txtTabelaCADU.Text = strTabelaCADU;
        }

        private static void _mtdObterEnderecoColetor()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strEnderecoBancoDadosColetor = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "EnderecoBancoDadosColetor"
                    ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "EnderecoBancoDadosColetor");
                strEnderecoBancoDadosColetor = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strEnderecoBancoDadosColetor == string.Empty || strEnderecoBancoDadosColetor == "Não há conteúdo.")
            {
                strEnderecoBancoDadosColetor = cntEnderecoBancoDadosColetor;

                _mtdSalvarEnderecoColetor();
            }

            strBaseDadosColetor = strEnderecoBancoDadosColetor + strNomeBancoDadosColetor;
        }

        private void mtdObterEnderecoColetor()
        {
            _mtdObterEnderecoColetor();

            txtEnderecoColetor.Text = strEnderecoBancoDadosColetor;
        }

        private static void _mtdObterNomeColetor()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                strNomeBancoDadosColetor = objRegistroWindows.mtdObterDadosRegistro
                    (
                    Microsoft.Win32.Registry.CurrentUser,
                    "Software",
                    "Eletronorte",
                    "Principal",
                    "NomeBancoDadosColetor"
                    ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "NomeBancoDadosColetor");
                strNomeBancoDadosColetor = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strNomeBancoDadosColetor == string.Empty || strNomeBancoDadosColetor == "Não há conteúdo.")
            {
                strNomeBancoDadosColetor = cntNomeBancoDadosColetor;

                _mtdSalvarNomeColetor();
            }

            strBaseDadosColetor = strEnderecoBancoDadosColetor + strNomeBancoDadosColetor;
        }

        private void mtdObterNomeColetor()
        {
            _mtdObterNomeColetor();

            txtNomeColetor.Text = strNomeBancoDadosColetor;
        }

        private static void _mtdObterSenhaColetor()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                //strSenhaColetor = objRegistroWindows.mtdObterDadosRegistro
                //    (
                //    Microsoft.Win32.Registry.CurrentUser,
                //    "Software",
                //    "Eletronorte",
                //    "Principal",
                //    "SenhaColetor"
                //    ).ToString().Trim();
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "SenhaColetor");
                strSenhaColetor = objArquivoTXT.mtdLeitorTexto().Trim();
            }

            if (strSenhaColetor == string.Empty || strSenhaColetor == "Não há conteúdo.")
            {
                strSenhaColetor = cntSenhaColetor;

                _mtdSalvarSenhaColetor();
            }
        }

        private void mtdObterSenhaColetor()
        {
            _mtdObterSenhaColetor();

            txtSenhaColetor.Text = strSenhaColetor;
        }

        private static void _mtdObterPermitirControleColetorUpLoad()
        {
            objArquivoTXT = new clsArquivoTXT();

            if (blnEscolherRegistro)
            {
                //blnPermitirControleColetorUpLoad = System.Convert.ToBoolean(objRegistroWindows.mtdObterDadosRegistro
                //    (
                //    Microsoft.Win32.Registry.CurrentUser,
                //    "Software",
                //    "Eletronorte",
                //    "Principal",
                //    "PermitirControleColetorUpLoad"
                //    ).ToString().Trim());
            }
            else
            {
                objArquivoTXT.setEnderecoArquivo = string.Format(@"{0}{1}_{2}_{3}_{4}.txt", DiretorioArmazenamentoRegistro, "Software", "Eletronorte", "Principal", "PermitirControleColetorUpLoad");
                blnPermitirControleColetorUpLoad = System.Convert.ToBoolean(objArquivoTXT.mtdLeitorTexto().Trim());
            }
        }

        private void mtdObterPermitirControleColetorUpLoad()
        {
            _mtdObterPermitirControleColetorUpLoad();

            chkPermitirControleColetorUpLoad.Checked = blnPermitirControleColetorUpLoad;
        }
    }
}