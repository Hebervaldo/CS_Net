using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceCSNet40
{

    public partial class clsConexaoBancoDados
    {

        public const string cntStringConexaoExcelOdbc = "Driver={Microsoft Excel Driver (*.xls)}; DriverId={0}; Dbq={1}; DefaultDir={2}; ReadOnly={3};";
        public const string cntStringConexaoExcel2003OleDb = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties={1}";
        public const string cntStringConexaoExcel2007OleDb = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties={1};";

        public const string cntExemploStringConexaoExcelOdbc = @"Driver={Microsoft Excel Driver (*.xls)}; DriverId=790; Dbq=C:\MyExcel.xls; DefaultDir=c:\mypath; ReadOnly=0;";
        public const string cntExemploStringConexaoExcel2003OleDb = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\MyExcel.xls; Extended Properties='Excel 8.0; HDR=Yes; IMEX=1';";
        public const string cntExemploStringConexaoExcel2007OleDb = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=c:\myFolder\myOldExcelFile.xls; Extended Properties='Excel 12.0; HDR=YES';";

        // Variaveis somente leitura de instancia do Excel

        private readonly string[] cntProviderExcel = { "Provider", "Microsoft.Jet.OLEDB.4.0", "Microsoft.ACE.OLEDB.12.0" };
        private readonly string[] cntDriverExcel = { "Driver", "{Microsoft Excel Driver (*.xls)}" };
        private readonly string[] cntDriverIdExcel = { "DriverId", "790" };
        private readonly string[] cntDataSourceExcel = { "DataSource", string.Empty };
        private readonly string[] cntExtendedPropertiesExcel = { "ExtendedProperties", "Excel 8.0; HDR=Yes; IMEX=1", "Excel 12.0; HDR=YES" };
        private readonly string[] cntDefaultDirExcel = { "DefaultDir", string.Empty };
        private readonly string[] cntReadOnlyExcel = { "ReadOnly", "0" };

        // Variaveis de instancia do Excel

        private string[] strProviderExcel;
        private string[] strDriverExcel;
        private string[] strDriverIdExcel;
        private string[] strDataSourceExcel;
        private string[] strExtendedPropertiesExcel;
        private string[] strDefaultDirExcel;
        private string[] strReadOnlyExcel;

        private string[] vetProviderExcel = { "Provider" };
        private string[] vetDriverExcel = { "Driver" };
        private string[] vetDriverIdExcel = { "DriverId", "Driver Id" };
        private string[] vetDataSourceExcel = { "DataSource", "Data Source", "Dbq", "Server" };
        private string[] vetExtendedPropertiesExcel = { "ExtendedProperties", "Extended Properties" };
        private string[] vetDefaultDirExcel = { "DefaultDir", "Default Dir" };
        private string[] vetReadOnlyExcel = { "ReadOnly", "Read Only" };

        // Variaveis que determinam se a conexao incorporara o workbook. Isso facilita na criacao, alteracao ou delecao do workbook.

        private bool blnPermitirBancoDadosExcel = true;

        // Propriedades de instancia do Excel

        public string prpProviderExcel
        {
            get
            {
                if (strProviderExcel == null)
                {
                    strProviderExcel = new string[2] { cntProviderExcel[0], cntProviderExcel[1] };
                }
                return strProviderExcel[1];
            }
            set
            {
                if (strProviderExcel == null)
                {
                    strProviderExcel = new string[2] { cntProviderExcel[0], cntProviderExcel[1] };
                }
                strProviderExcel[1] = value;
                mtdReDefinirConexaoString(strProviderExcel);
            }
        }

        public string prpDriverExcel
        {
            get
            {
                if (strDriverExcel == null)
                {
                    strDriverExcel = new string[2] { cntDriverExcel[0], cntDriverExcel[1] };
                }
                return strDriverExcel[1];
            }
            set
            {
                if (strDriverExcel == null)
                {
                    strDriverExcel = new string[2] { cntDriverExcel[0], cntDriverExcel[1] };
                }
                strDriverExcel[1] = value;
                mtdReDefinirConexaoString(strDriverExcel);
            }
        }

        public string prpDriverIdExcel
        {
            get
            {
                if (strDriverIdExcel == null)
                {
                    strDriverIdExcel = new string[2] { cntDriverIdExcel[0], cntDriverIdExcel[1] };
                }
                return strDriverIdExcel[1];
            }
            set
            {
                if (strDriverIdExcel == null)
                {
                    strDriverIdExcel = new string[2] { cntDriverIdExcel[0], cntDriverIdExcel[1] };
                }
                strDriverIdExcel[1] = value;
                mtdReDefinirConexaoString(strDriverIdExcel);
            }
        }

        public string prpDataSourceExcel
        {
            get
            {
                if (strDataSourceExcel == null)
                {
                    strDataSourceExcel = new string[2] { cntDataSourceExcel[0], cntDataSourceExcel[1] };
                }
                return strDataSourceExcel[1];
            }
            set
            {
                if (strDataSourceExcel == null)
                {
                    strDataSourceExcel = new string[2] { cntDataSourceExcel[0], cntDataSourceExcel[1] };
                }
                strDataSourceExcel[1] = value;
                mtdReDefinirConexaoString(strDataSourceExcel);
            }
        }

        public string prpExtendedPropertiesExcel
        {
            get
            {
                if (strExtendedPropertiesExcel == null)
                {
                    strExtendedPropertiesExcel = new string[2] { cntExtendedPropertiesExcel[0], cntExtendedPropertiesExcel[1] };
                }
                return strExtendedPropertiesExcel[1];
            }
            set
            {
                if (strExtendedPropertiesExcel == null)
                {
                    strExtendedPropertiesExcel = new string[2] { cntExtendedPropertiesExcel[0], cntExtendedPropertiesExcel[1] };
                }
                strExtendedPropertiesExcel[1] = value;
                mtdReDefinirConexaoString(strExtendedPropertiesExcel);
            }
        }

        public string prpDefaultDirExcel
        {
            get
            {
                if (strDefaultDirExcel == null)
                {
                    strDefaultDirExcel = new string[2] { cntDefaultDirExcel[0], cntDefaultDirExcel[1] };
                }
                return strDefaultDirExcel[1];
            }
            set
            {
                if (strDefaultDirExcel == null)
                {
                    strDefaultDirExcel = new string[2] { cntDefaultDirExcel[0], cntDefaultDirExcel[1] };
                }
                strDefaultDirExcel[1] = value;
                mtdReDefinirConexaoString(strDefaultDirExcel);
            }
        }

        public string prpReadOnlyExcel
        {
            get
            {
                if (strReadOnlyExcel == null)
                {
                    strReadOnlyExcel = new string[2] { cntReadOnlyExcel[0], cntReadOnlyExcel[1] };
                }
                return strReadOnlyExcel[1];
            }
            set
            {
                if (strReadOnlyExcel == null)
                {
                    strReadOnlyExcel = new string[2] { cntReadOnlyExcel[0], cntReadOnlyExcel[1] };
                }
                strReadOnlyExcel[1] = value;
                mtdReDefinirConexaoString(strReadOnlyExcel);
            }
        }

        // Metodos de instancia do Excel

        public string[] mtdValidarConexaoDispositivoExcel(string Conexao)
        {
            strDriverExcel = mtdValidarConexao(Conexao, vetDriverExcel);
            return strDriverExcel;
        }

        public string[] mtdValidarConexaoDispositivoIdExcel(string Conexao)
        {
            strDriverIdExcel = mtdValidarConexao(Conexao, vetDriverIdExcel);
            return strDriverIdExcel;
        }

        public string[] mtdValidarConexaoProvedorExcel(string Conexao)
        {
            strProviderExcel = mtdValidarConexao(Conexao, vetProviderExcel);
            return strProviderExcel;
        }

        public string[] mtdValidarConexaoOrigemDadosExcel(string Conexao)
        {
            strDataSourceExcel = mtdValidarConexao(Conexao, vetDataSourceExcel);
            return strDataSourceExcel;
        }

        public string[] mtdValidarPropriedadesExtendidasExcel(string Conexao)
        {
            strExtendedPropertiesExcel = mtdValidarConexao(Conexao, vetExtendedPropertiesExcel);
            return strExtendedPropertiesExcel;
        }

        public string[] mtdValidarDiretorioPadraoExcel(string Conexao)
        {
            strDefaultDirExcel = mtdValidarConexao(Conexao, vetDefaultDirExcel);
            return strDefaultDirExcel;
        }

        public string[] mtdValidarSomenteLeituraExcel(string Conexao)
        {
            strReadOnlyExcel = mtdValidarConexao(Conexao, vetReadOnlyExcel);
            return strReadOnlyExcel;
        }

        public string mtdValidarConexaoExcel(string Conexao)
        {
            string saida = string.Empty;

            prpTipoConexao = TipoConexao.Indisponivel;
            //if (strDriverExcel == null || strDriverExcel[1] == cntDriverExcel[1])
            //{
            mtdValidarConexaoDispositivoExcel(Conexao);
            //}
            if (strDriverExcel != null)
            {
                prpTipoConexao = TipoConexao.ConexaoExcelOdbc;
            }
            //if (strProviderExcel == null || strProviderExcel[1] == cntProviderExcel[1])
            //{
            mtdValidarConexaoProvedorExcel(Conexao);
            //}
            if (strProviderExcel != null)
            {
                if (strProviderExcel[strProviderExcel.GetUpperBound(0)] == cntProviderExcel[cntProviderExcel.GetUpperBound(0)])
                {
                    prpTipoConexao = TipoConexao.ConexaoExcel2007OleDb;
                }
                else
                {
                    prpTipoConexao = TipoConexao.ConexaoExcel2003OleDb;
                }
            }
            //if (strDataSourceExcel == null || strDataSourceExcel[1] == cntDataSourceExcel[1])
            //{
            mtdValidarConexaoOrigemDadosExcel(Conexao);
            //}
            //if (strDriverIdExcel == null || strDriverIdExcel[1] == cntDriverIdExcel[1])
            //{
            mtdValidarConexaoDispositivoIdExcel(Conexao);
            //}
            //if (strExtendedPropertiesExcel == null || strExtendedPropertiesExcel[1] == cntExtendedPropertiesExcel[1])
            //{
            mtdValidarPropriedadesExtendidasExcel(Conexao);
            //}
            //if (strDefaultDirExcel == null || strDefaultDirExcel[1] == cntDefaultDirExcel[1])
            //{
            mtdValidarDiretorioPadraoExcel(Conexao);
            //}
            //if (strReadOnlyExcel == null || strReadOnlyExcel[1] == cntReadOnlyExcel[1])
            //{
            mtdValidarSomenteLeituraExcel(Conexao);
            //}

            if (strDriverExcel != null)
            {
                saida += string.Format("{0}={1}; ", strDriverExcel[0], strDriverExcel[1]);
            }
            if (strProviderExcel != null)
            {
                saida += string.Format("{0}={1}; ", strProviderExcel[0], strProviderExcel[1]);
            }
            if (strDataSourceExcel != null)
            {
                saida += string.Format("{0}={1}; ", strDataSourceExcel[0], strDataSourceExcel[1]);
            }
            if (strDriverIdExcel != null)
            {
                saida += string.Format("{0}={1}; ", strDriverIdExcel[0], strDriverIdExcel[1]);
            }
            if (strExtendedPropertiesExcel != null)
            {
                saida += string.Format("{0}={1};", strExtendedPropertiesExcel[0], strExtendedPropertiesExcel[1]);
            }
            if (strDefaultDirExcel != null)
            {
                saida += string.Format("{0}={1};", strDefaultDirExcel[0], strDefaultDirExcel[1]);
            }
            if (strReadOnlyExcel != null)
            {
                saida += string.Format("{0}={1};", strReadOnlyExcel[0], strReadOnlyExcel[1]);
            }
            return saida;
        }

        public string mtdDefinirStringConexaoExcel()
        {
            return mtdDefinirStringConexaoExcel(prpConexao, true);
        }

        public string mtdDefinirStringConexaoExcel(string Conexao, bool PermitirBancoDados)
        {
            blnPermitirBancoDadosExcel = PermitirBancoDados;
            mtdValidarConexaoExcel(Conexao);
            return mtdDefinirStringConexaoExcel(prpTipoConexao, prpDataSourceExcel);
        }

        public string mtdDefinirStringConexaoExcel(TipoConexao TipoConexao, string DataSource)
        {
            return mtdDefinirStringConexaoExcel(TipoConexao, DataSource, cntDriverIdExcel[1], cntExtendedPropertiesExcel[1], cntDefaultDirExcel[1], cntReadOnlyExcel[1]);
        }

        public string mtdDefinirStringConexaoExcel(TipoConexao TipoConexao, string DataSource, string DriverId, string ExtendedProperties, string DefaultDir, string ReadOnly)
        {
            string saida = string.Empty;
            switch (TipoConexao)
            {
                case TipoConexao.ConexaoExcelOdbc:
                    saida = string.Format(cntStringConexaoExcelOdbc.Replace(string.Format("Driver={0}; ", cntDriverExcel[1]), string.Empty), DriverId, DataSource, DefaultDir, ReadOnly);
                    strDriverExcel = cntDriverExcel;
                    saida = string.Format("{0}={1}; ", strDriverExcel[0], strDriverExcel[1]) + saida;
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Odbc;
                    break;
                case TipoConexao.ConexaoExcel2003OleDb:
                    saida = string.Format(cntStringConexaoExcel2003OleDb.Replace(string.Format("Provider={0}; ", cntProviderExcel[1]), string.Empty), DataSource, ExtendedProperties);
                    strProviderExcel = cntProviderExcel;
                    saida = string.Format("{0}={1}; ", strProviderExcel[0], strProviderExcel[1]) + saida;
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb;
                    break;
                case TipoConexao.ConexaoExcel2007OleDb:
                    saida = string.Format(cntStringConexaoExcel2007OleDb.Replace(string.Format("Provider={0}; ", cntProviderExcel[1]), string.Empty), DataSource, ExtendedProperties);
                    strProviderExcel = cntProviderExcel;
                    saida = string.Format("{0}={1}; ", strProviderExcel[0], strProviderExcel[1]) + saida;
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida);
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb;
                    break;
                case TipoConexao.Indisponivel:
                    saida = TipoConexao.Indisponivel.ToString();
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel;
                    break;
            }
            prpConexao = mtdValidarConexaoExcel(saida);
            return prpConexao.Trim();
        }
    }

    public partial class clsImplementacaoBancoDados
    {
        // Excel

        public bool mtdAlterarBancoDadosExcel(string NovoBancoDados)
        {
            return mtdAlterarBancoDadosExcel(prpDataSourceExcel, NovoBancoDados);
        }

        public bool mtdAlterarBancoDadosExcel(string BancoDados, string NovoBancoDados)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("Não há workbook (arquivo) a ser alterado.");

            try
            {
                prpDataSourceExcel = BancoDados;
                mtdDefinirStringConexaoExcel();
                mtdFecharConexao();
                prpDataSourceExcel = NovoBancoDados;
                mtdDefinirStringConexaoExcel();
                mtdFecharConexao();
                if (System.IO.File.Exists(BancoDados))
                {
                    if (!System.IO.File.Exists(NovoBancoDados))
                    {
                        System.IO.File.Move(BancoDados, NovoBancoDados);
                        saida = true;
                    }
                    else
                    {
                        ex = new System.Exception("Já existe um workbook (arquivo) com esse nome.");
                        saida = false;
                    }
                }
                else
                {
                    setExcecao = ex.Message;
                    saida = false;
                }
            }
            catch (Exception exception)
            {
                setExcecao = exception.Message;
                saida = false;
            }

            return saida;
        }

        public bool mtdCriarBancoDadosExcel()
        {
            return mtdCriarBancoDadosExcel(prpDataSourceExcel);
        }

        public bool mtdCriarBancoDadosExcel(string BancoDados)
        {
            bool saida = false;

            System.Exception ex = new System.Exception("Já existe um workbook (arquivo) com esse nome.");

            try
            {
                prpDataSourceExcel = BancoDados;
                mtdDefinirStringConexaoExcel();
                mtdFecharConexao();
                if (!System.IO.File.Exists(BancoDados))
                {
                    Microsoft.Office.Interop.Excel.Application xlApp;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Microsoft.Office.Interop.Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(System.Reflection.Missing.Value);

                    xlWorkBook.SaveAs
                        (
                        BancoDados,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value
                        );
                    xlWorkBook.Close
                        (
                        true,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value
                        );
                    xlApp.Quit();

                    mtdLiberarObjeto(xlWorkBook);
                    mtdLiberarObjeto(xlApp);

                    saida = true;
                }
                else
                {
                    setExcecao = ex.Message;
                    saida = false;
                }
            }
            catch (Exception exception)
            {
                setExcecao = exception.Message;
                saida = false;
            }

            return saida;
        }

        public bool mtdDeletarBancoDadosExcel()
        {
            return mtdDeletarBancoDadosExcel(prpDataSourceExcel);
        }

        public bool mtdDeletarBancoDadosExcel(string BancoDados)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("Não há workbook (arquivo) a ser deletado.");

            try
            {
                prpDataSourceExcel = BancoDados;
                mtdDefinirStringConexaoExcel();
                mtdFecharConexao();
                if (System.IO.File.Exists(BancoDados))
                {
                    System.IO.File.Delete(BancoDados);
                    saida = true;
                }
                else
                {
                    setExcecao = ex.Message;
                    saida = false;
                }
            }
            catch (Exception exception)
            {
                setExcecao = exception.Message;
                saida = false;
            }

            return saida;
        }

        private Microsoft.Office.Interop.Excel.Application xlApp;
        private Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        private Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;

        private object misValue = System.Reflection.Missing.Value;

        public bool mtdAbrirInserirPlanilhaExcel_Otimizado()
        {
            return mtdAbrirInserirPlanilhaExcel_Otimizado(prpTabela);
        }

        public bool mtdAbrirInserirPlanilhaExcel_Otimizado(string NomeTabela)
        {
            return mtdAbrirInserirPlanilhaExcel_Otimizado(prpDataSourceExcel, NomeTabela);
        }

        public bool mtdAbrirInserirPlanilhaExcel_Otimizado(string EnderecoArquivo, string NomeTabela)
        {
            bool blnRetorno = false;

            try
            {
                intLinhaPlanilha = 1;

                xlApp = new Microsoft.Office.Interop.Excel.Application();

                if (System.IO.File.Exists(EnderecoArquivo))
                {
                    xlWorkBook = xlApp.Workbooks.Open(EnderecoArquivo, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                }
                else
                {
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                }

                try
                {
                    while (xlWorkBook.Sheets.Count > 1)
                    {
                        ((Microsoft.Office.Interop.Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[2]).Delete();
                    }
                }
                catch (System.Exception ex)
                {
                }

                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets[1];
                xlWorkSheet.Name = NomeTabela; //Rename the sheet
                //xlWorkSheet.Select(Type.Missing);

                blnRetorno = true;
            }
            catch (System.Exception ex)
            {
                blnRetorno = false;
            }

            return blnRetorno;
        }

        public bool mtdCabecalhoInserirPlanilhaExcel_Otimizado(object[,] dados)
        {
            bool blnRetorno = false;

            try
            {
                int linha = 0;

                if (dados != null)
                {
                    for (int coluna = dados.GetLowerBound(1); coluna <= dados.GetUpperBound(1); coluna++)
                    {
                        xlWorkSheet.Cells[linha + 1, coluna + 1] = dados[linha, coluna];
                        System.Threading.Thread.Sleep(1);
                    }
                }

                blnRetorno = true;
            }
            catch (Exception ex)
            {
                blnRetorno = false;
            }

            return blnRetorno;
        }

        public bool mtdCabecalhoInserirPlanilhaExcel_Otimizado(object[][] dados)
        {
            bool blnRetorno = false;

            try
            {
                int linha = 0;

                if (dados[linha] != null)
                {
                    for (int coluna = dados[linha].GetLowerBound(0); coluna <= dados[linha].GetUpperBound(0); coluna++)
                    {
                        xlWorkSheet.Cells[linha + 1, coluna + 1] = dados[linha][coluna];
                        System.Threading.Thread.Sleep(1);
                    }

                    blnRetorno = true;
                }
            }
            catch (Exception ex)
            {
                blnRetorno = false;
            }

            return blnRetorno;
        }

        public bool mtdCabecalhoInserirPlanilhaExcel_Otimizado(List<List<object>> dados)
        {
            bool blnRetorno = false;

            try
            {
                int linha = 0;

                if (dados[linha] != null)
                {
                    for (int coluna = 0; coluna <= dados[linha].Count - 1; coluna++)
                    {
                        xlWorkSheet.Cells[linha + 1, coluna + 1] = dados[linha][coluna];
                        System.Threading.Thread.Sleep(1);
                    }
                }

                blnRetorno = true;
            }
            catch (Exception ex)
            {
                blnRetorno = false;
            }

            return blnRetorno;
        }

        int intLinhaPlanilha = 1;

        public bool mtdDadosInserirPlanilhaExcel_Otimizado(object[,] dados)
        {
            return mtdDadosInserirPlanilhaExcel_Otimizado(dados, true);
        }

        public bool mtdDadosInserirPlanilhaExcel_Otimizado(object[,] dados, bool InsercaoLiteral)
        {
            bool blnRetorno = false;

            try
            {
                if (InsercaoLiteral)
                {
                    if (dados != null)
                    {
                        for (int linha = dados.GetLowerBound(0) + 1; linha <= dados.GetUpperBound(0); linha++)
                        {
                            for (int coluna = dados.GetLowerBound(1); coluna <= dados.GetUpperBound(0); coluna++)
                            {
                                xlWorkSheet.Cells[linha + 1, coluna + 1] = dados[linha, coluna];
                                System.Threading.Thread.Sleep(1);
                            }
                        }
                    }
                }
                else
                {
                    int linha = 1;

                    if (dados != null)
                    {
                        for (int coluna = dados.GetLowerBound(1); coluna <= dados.GetUpperBound(0); coluna++)
                        {
                            xlWorkSheet.Cells[intLinhaPlanilha + 1, coluna + 1] = dados[linha, coluna];
                            System.Threading.Thread.Sleep(1);
                        }

                        intLinhaPlanilha++;
                    }
                }

                blnRetorno = true;
            }
            catch (Exception ex)
            {
                blnRetorno = false;
            }

            return blnRetorno;
        }

        public bool mtdDadosInserirPlanilhaExcel_Otimizado(object[][] dados)
        {
            return mtdDadosInserirPlanilhaExcel_Otimizado(dados, true);
        }

        public bool mtdDadosInserirPlanilhaExcel_Otimizado(object[][] dados, bool InsercaoLiteral)
        {
            bool blnRetorno = false;

            try
            {
                if (InsercaoLiteral)
                {
                    for (int linha = dados.GetLowerBound(0) + 1; linha <= dados.GetUpperBound(0); linha++)
                    {
                        if (dados[linha] != null)
                        {
                            for (int coluna = dados[linha].GetLowerBound(0); coluna <= dados[linha].GetUpperBound(0); coluna++)
                            {
                                xlWorkSheet.Cells[linha + 1, coluna + 1] = dados[linha][coluna];
                                System.Threading.Thread.Sleep(1);
                            }
                        }
                    }
                }
                else
                {
                    int linha = 1;

                    if (dados[linha] != null)
                    {
                        for (int coluna = dados[linha].GetLowerBound(0); coluna <= dados[linha].GetUpperBound(0); coluna++)
                        {
                            xlWorkSheet.Cells[intLinhaPlanilha + 1, coluna + 1] = dados[linha][coluna];
                            System.Threading.Thread.Sleep(1);
                        }

                        intLinhaPlanilha++;
                    }
                }

                blnRetorno = true;
            }
            catch (Exception ex)
            {
                blnRetorno = false;
            }

            return blnRetorno;
        }

        public bool mtdDadosInserirPlanilhaExcel_Otimizado(List<List<object>> dados)
        {
            return mtdDadosInserirPlanilhaExcel_Otimizado(dados, true);
        }

        public bool mtdDadosInserirPlanilhaExcel_Otimizado(List<List<object>> dados, bool InsercaoLiteral)
        {
            bool blnRetorno = false;

            try
            {
                if (InsercaoLiteral)
                {
                    for (int linha = 0 + 1; linha <= dados.Count - 1; linha++)
                    {
                        if (dados[linha] != null)
                        {
                            for (int coluna = 0; coluna <= dados[linha].Count - 1; coluna++)
                            {
                                xlWorkSheet.Cells[linha + 1, coluna + 1] = dados[linha][coluna];
                                System.Threading.Thread.Sleep(1);
                            }
                        }
                    }
                }
                else
                {
                    int linha = 1;

                    if (dados[linha] != null)
                    {
                        for (int coluna = 0; coluna <= dados[linha].Count - 1; coluna++)
                        {
                            xlWorkSheet.Cells[intLinhaPlanilha + 1, coluna + 1] = dados[linha][coluna];
                            System.Threading.Thread.Sleep(1);
                        }

                        intLinhaPlanilha++;
                    }
                }

                blnRetorno = true;
            }
            catch (Exception ex)
            {
                blnRetorno = false;
            }

            return blnRetorno;
        }

        public bool mtdDadosInserirPlanilhaExcel_Otimizado(object[,] dados, int linhaPlanilha, int linhaDados)
        {
            bool blnRetorno = false;

            try
            {
                if (linhaPlanilha < 1)
                {
                    linhaPlanilha = 1;
                }

                if (dados != null)
                {
                    for (int coluna = dados.GetLowerBound(1); coluna <= dados.GetUpperBound(1); coluna++)
                    {
                        xlWorkSheet.Cells[linhaPlanilha + 1, coluna + 1] = dados[linhaDados, coluna];
                        System.Threading.Thread.Sleep(1);
                    }
                }

                blnRetorno = true;
            }
            catch (Exception ex)
            {
                blnRetorno = false;
            }

            return blnRetorno;
        }

        public bool mtdDadosInserirPlanilhaExcel_Otimizado(object[][] dados, int linhaPlanilha, int linhaDados)
        {
            bool blnRetorno = false;

            try
            {
                if (linhaPlanilha < 1)
                {
                    linhaPlanilha = 1;
                }

                if (dados[linhaDados] != null)
                {
                    for (int coluna = dados[1].GetLowerBound(0); coluna <= dados[1].GetUpperBound(0); coluna++)
                    {
                        xlWorkSheet.Cells[linhaPlanilha + 1, coluna + 1] = dados[linhaDados][coluna];
                        System.Threading.Thread.Sleep(1);
                    }
                }

                blnRetorno = true;
            }
            catch (Exception ex)
            {
                blnRetorno = false;
            }

            return blnRetorno;
        }

        public bool mtdDadosInserirPlanilhaExcel_Otimizado(List<List<object>> dados, int linhaPlanilha, int linhaDados)
        {
            bool blnRetorno = false;

            try
            {
                if (linhaPlanilha < 1)
                {
                    linhaPlanilha = 1;
                }

                if (dados[linhaDados] != null)
                {
                    for (int coluna = 0; coluna <= dados[1].Count - 1; coluna++)
                    {
                        xlWorkSheet.Cells[linhaPlanilha + 1, coluna + 1] = dados[linhaDados][coluna];
                        System.Threading.Thread.Sleep(1);
                    }
                }

                blnRetorno = true;
            }
            catch (Exception ex)
            {
                blnRetorno = false;
            }

            return blnRetorno;
        }

        public bool mtdFecharInserirPlanilhaExcel_Otimizado()
        {
            return mtdFecharInserirPlanilhaExcel_Otimizado(prpDataSourceExcel);
        }

        public bool mtdFecharInserirPlanilhaExcel_Otimizado(string EnderecoArquivo)
        {
            bool blnRetorno = false;

            try
            {
                xlWorkBook.SaveAs(EnderecoArquivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                mtdLiberarObjeto(xlWorkSheet);
                mtdLiberarObjeto(xlWorkBook);
                mtdLiberarObjeto(xlApp);

                blnRetorno = true;
            }
            catch (Exception ex)
            {
                blnRetorno = false;
            }

            return blnRetorno;
        }

        public bool mtdInserirDadosPlanilhaExcel(object[,] Campos_Dados)
        {
            return mtdInserirDadosPlanilhaExcel(prpTabela, Campos_Dados, true);
        }

        public bool mtdInserirDadosPlanilhaExcel(string NomeTabela, object[,] Campos_Dados)
        {
            return mtdInserirDadosPlanilhaExcel(NomeTabela, Campos_Dados, true);
        }

        public bool mtdInserirDadosPlanilhaExcel(string NomeTabela, object[,] Campos_Dados, bool InsercaoLiteral)
        {
            bool saida = true;

            saida &= mtdAbrirInserirPlanilhaExcel_Otimizado(NomeTabela);
            saida &= mtdCabecalhoInserirPlanilhaExcel_Otimizado(Campos_Dados);
            saida &= mtdDadosInserirPlanilhaExcel_Otimizado(Campos_Dados, InsercaoLiteral);
            saida &= mtdFecharInserirPlanilhaExcel_Otimizado(prpDataSourceExcel);

            return saida;
        }

        public bool mtdInserirDadosPlanilhaExcel(object[][] Campos_Dados)
        {
            return mtdInserirDadosPlanilhaExcel(prpTabela, Campos_Dados, true);
        }


        public bool mtdInserirDadosPlanilhaExcel(string NomeTabela, object[][] Campos_Dados)
        {
            return mtdInserirDadosPlanilhaExcel(NomeTabela, Campos_Dados, true);
        }

        public bool mtdInserirDadosPlanilhaExcel(string NomeTabela, object[][] Campos_Dados, bool InsercaoLiteral)
        {
            bool saida = true;

            saida &= mtdAbrirInserirPlanilhaExcel_Otimizado(NomeTabela);
            saida &= mtdCabecalhoInserirPlanilhaExcel_Otimizado(Campos_Dados);
            saida &= mtdDadosInserirPlanilhaExcel_Otimizado(Campos_Dados, InsercaoLiteral);
            saida &= mtdFecharInserirPlanilhaExcel_Otimizado(prpDataSourceExcel);

            return saida;
        }

        public bool mtdInserirDadosPlanilhaExcel(List<List<object>> Campos_Dados)
        {
            return mtdInserirDadosPlanilhaExcel(prpTabela, Campos_Dados, true);
        }

        public bool mtdInserirDadosPlanilhaExcel(string NomeTabela, List<List<object>> Campos_Dados)
        {
            return mtdInserirDadosPlanilhaExcel(NomeTabela, Campos_Dados, true);
        }

        public bool mtdInserirDadosPlanilhaExcel(string NomeTabela, List<List<object>> Campos_Dados, bool InsercaoLiteral)
        {
            bool saida = true;

            saida &= mtdAbrirInserirPlanilhaExcel_Otimizado(NomeTabela);
            saida &= mtdCabecalhoInserirPlanilhaExcel_Otimizado(Campos_Dados);
            saida &= mtdDadosInserirPlanilhaExcel_Otimizado(Campos_Dados, InsercaoLiteral);
            saida &= mtdFecharInserirPlanilhaExcel_Otimizado(prpDataSourceExcel);

            return saida;
        }

        private bool mtdLiberarObjeto(object objeto)
        {
            bool saida = false;
            setExcecao = "mtdExecutarComando: Nao houve excecao.";
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objeto);
                objeto = null;
                saida = true;
            }
            catch (Exception ex)
            {
                objeto = null;
                setExcecao = "mtdLiberarObjeto: " + ex.Message;
                saida = true;
            }
            finally
            {
                GC.Collect();
            }
            return saida;
        }
    }
}