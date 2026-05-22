using System;
using System.Collections.Generic;
using System.Text;

namespace prjConsolePDFOCRCSNet480
{
    public partial class clsConexaoBancoDados
    {
    }

    public partial class clsInfraestruturaBancoDados
    {
        // Variaveis do Odbc
        protected System.Data.Odbc.OdbcConnection objConexaoOdbc = new System.Data.Odbc.OdbcConnection();
        protected System.Data.Odbc.OdbcCommand objComandoOdbc = new System.Data.Odbc.OdbcCommand();
        protected System.Data.Odbc.OdbcDataAdapter objAdaptadorDadosOdbc = new System.Data.Odbc.OdbcDataAdapter();
        protected System.Data.Odbc.OdbcDataReader objLeitorDadosOdbc;

        // Propriedades do Odbc

        public System.Data.Odbc.OdbcConnection prpConexaoOdbc
        {
            get
            {
                return objConexaoOdbc;
            }
            set
            {
                objConexaoOdbc = value;
            }
        }

        public System.Data.Odbc.OdbcCommand prpComandoOdbc
        {
            get
            {
                return objComandoOdbc;
            }
            set
            {
                objComandoOdbc = value;
            }
        }

        public System.Data.Odbc.OdbcDataAdapter prpAdaptadorDadosOdbc
        {
            get
            {
                return objAdaptadorDadosOdbc;
            }
            set
            {
                objAdaptadorDadosOdbc = value;
            }
        }

        public System.Data.Odbc.OdbcDataReader prpLeitorDadosOdbc
        {
            get
            {
                return objLeitorDadosOdbc;
            }
            set
            {
                objLeitorDadosOdbc = value;
            }
        }

        public void mtdExecutarParametroComandoOdbc
            (
            string NomeParametro,
            object Valor
            )
        {
            System.Data.Odbc.OdbcParameter objParametroOdbc =
                new System.Data.Odbc.OdbcParameter
                    (
                    NomeParametro,
                    Valor
                    );
            prpComandoOdbc.Parameters.Add(objParametroOdbc);
        }

        public void mtdExecutarParametroComandoOdbc
           (
           string NomeParametro,
           System.Data.Odbc.OdbcType TipoSqlDb,
           object Valor
           )
        {
            System.Data.Odbc.OdbcParameter objParametroOdbc =
              new System.Data.Odbc.OdbcParameter
                  (
                  NomeParametro,
                  TipoSqlDb
                  );
            objParametroOdbc.Value = Valor;
            prpComandoOdbc.Parameters.Add(objParametroOdbc);
        }

        public void mtdExecutarParametroComandoOdbc
           (
           string NomeParametro,
           System.Data.Odbc.OdbcType TipoSqlDb,
           object Valor,
           int Tamanho
           )
        {
            System.Data.Odbc.OdbcParameter objParametroOdbc =
              new System.Data.Odbc.OdbcParameter
                  (
                  NomeParametro,
                  TipoSqlDb,
                  Tamanho
                  );
            objParametroOdbc.Value = Valor;
            prpComandoOdbc.Parameters.Add(objParametroOdbc);
        }

        public void mtdExecutarParametroComandoOdbc
            (
            string NomeParametro,
            System.Data.Odbc.OdbcType TipoSqlDb,
            object Valor,
            int Tamanho,
            string ColunaOrigem
            )
        {
            System.Data.Odbc.OdbcParameter objParametroOdbc =
                new System.Data.Odbc.OdbcParameter
                    (
                    NomeParametro,
                    TipoSqlDb,
                    Tamanho,
                    ColunaOrigem
                    );
            objParametroOdbc.Value = Valor;
            prpComandoOdbc.Parameters.Add(objParametroOdbc);
        }

        public void mtdExecutarParametroComandoOdbc
            (
            System.Data.DataRowVersion OrigemVersao,
            string NomeParametro,
            System.Data.Odbc.OdbcType TipoSqlDb,
            System.Data.ParameterDirection DirecaoParametro,
            string OrigemColuna,
            object Valor,
            int Tamanho
            )
        {
            System.Data.Odbc.OdbcParameter objParametroOdbc =
                new System.Data.Odbc.OdbcParameter
                    (
                    NomeParametro,
                    TipoSqlDb,
                    Tamanho,
                    OrigemColuna
                    );
            objParametroOdbc.SourceVersion = OrigemVersao;
            objParametroOdbc.Direction = DirecaoParametro;
            objParametroOdbc.Value = Valor;
            prpComandoOdbc.Parameters.Add(objParametroOdbc);
        }
    }

    public partial class clsImplementacaoBancoDados
    {
        // Odbc

        private string strParametroOdbc = @"@";

        private bool mtdAtualizarDadosParametroComandoOdbcValor(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    strCampoBase = CampoBase;
                    strOperacao = Operacao;
                    objDadoBase = CampoBase;

                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = string.Empty;
                        prpComandoOdbc.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1);
                            coluna <=
                            (
                            Campos_Dados.GetUpperBound(1)
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    mtdExecutarParametroComandoOdbc
                                        (
                                        vetNomeColunas[coluna],
                                        vetRegistrosColunas[coluna]
                                        );

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados.GetUpperBound(1)) ?
                                        @"{0} = {2}{1}" :
                                        @"{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroOdbc
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoOdbc
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                @"UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroOdbc
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipo(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    strCampoBase = CampoBase;
                    strOperacao = Operacao;
                    objDadoBase = DadoBase;

                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            case (1):
                                vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = string.Empty;
                        prpComandoOdbc.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1);
                            coluna <=
                            (
                            Campos_Dados.GetUpperBound(1)
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    break;
                                case (1):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    if (Campos_Dados[1, coluna] != null)
                                    {
                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados.GetUpperBound(1)) ?
                                        @"{0} = {2}{1}" :
                                        @"{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroOdbc
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoOdbc
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                @"UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroOdbc
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            int[] vetTamanhoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    strCampoBase = CampoBase;
                    strOperacao = Operacao;
                    objDadoBase = DadoBase;

                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            case (1):
                                vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            case (2):
                                vetTamanhoColunas = new int[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = string.Empty;
                        prpComandoOdbc.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1);
                            coluna <=
                            (
                            Campos_Dados.GetUpperBound(1)
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    break;
                                case (1):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                    }
                                    break;
                                case (2):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTamanhoColunas[coluna] = (int)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTamanhoColunas[coluna] = (int)0;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    if (Campos_Dados[1, coluna] != null)
                                    {
                                        if (Campos_Dados[2, coluna] != null)
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna],
                                                vetTamanhoColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados.GetUpperBound(1)) ?
                                        @"{0} = {2}{1}" :
                                        "{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroOdbc
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoOdbc
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                @"UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroOdbc
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoOdbc(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoOdbcValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValor(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        strCampoBase = CampoBase;
                        strOperacao = Operacao;
                        objDadoBase = DadoBase;

                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0);
                                coluna <=
                                (
                                Campos_Dados[linha].GetUpperBound(0)
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].GetUpperBound(0)) ?
                                            @"{0} = {2}{1}" :
                                            "{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    @"UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroOdbc
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipo(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    strCampoBase = CampoBase;
                    strOperacao = Operacao;
                    objDadoBase = DadoBase;

                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                case (1):
                                    vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0);
                                coluna <=
                                (
                                Campos_Dados[linha].GetUpperBound(0)
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].GetUpperBound(0)) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroOdbc
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            int[] vetTamanhoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                case (1):
                                    vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                case (2):
                                    vetTamanhoColunas = new int[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados[linha][Campos_Dados[linha].GetUpperBound(0) - 2];
                                    strOperacao = (string)Campos_Dados[linha][Campos_Dados.GetUpperBound(0) - 1];
                                    objDadoBase = Campos_Dados[linha][Campos_Dados[linha].GetUpperBound(0)];
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0);
                                coluna <=
                                (
                                Campos_Dados[linha].GetUpperBound(0)
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTamanhoColunas[coluna] = (int)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTamanhoColunas[coluna] = (int)0;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            if (Campos_Dados[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna],
                                                    vetTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].GetUpperBound(0) - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                    (
                                    string.Format("Alterar_{0}", strCampoBase),
                                    objDadoBase
                                    );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroOdbc
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoOdbc(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoOdbcValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValor(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        strCampoBase = CampoBase;
                        strOperacao = Operacao;
                        objDadoBase = DadoBase;

                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                Campos_Dados[linha].Count - 1
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        mtdExecutarParametroComandoOdbc
                                            (
                                            lstNomeColunas[coluna],
                                            lstRegistrosColunas[coluna]
                                            );

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].Count - 1) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroOdbc
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipo(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<System.Data.Odbc.OdbcType> lstTipoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    strCampoBase = CampoBase;
                    strOperacao = Operacao;
                    objDadoBase = DadoBase;

                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.Odbc.OdbcType> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                Campos_Dados[linha].Count - 1
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                            lstTipoColunas.Add(System.Data.Odbc.OdbcType.Binary);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                lstNomeColunas[coluna],
                                                lstTipoColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].Count - 1) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroOdbc
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<System.Data.Odbc.OdbcType> lstTipoColunas = null;
            List<int> lstTamanhoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.Odbc.OdbcType> { };
                                    break;
                                case (2):
                                    lstTamanhoColunas = new List<int> { };
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados[linha][Campos_Dados[linha].Count - 1 - 2];
                                    strOperacao = (string)Campos_Dados[linha][Campos_Dados.Count - 1 - 1];
                                    objDadoBase = Campos_Dados[linha][Campos_Dados[linha].Count - 1];
                                    lstRegistrosColunas = new List<object>(Campos_Dados[linha].Count - 1 + 1);
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                Campos_Dados[linha].Count - 1
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                            lstTipoColunas.Add(System.Data.Odbc.OdbcType.Binary);
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTamanhoColunas[coluna] = (int)Campos_Dados[linha][coluna];
                                            lstTamanhoColunas.Add((int)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTamanhoColunas[coluna] = (int)0;
                                            lstTamanhoColunas.Add((int)0);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            if (Campos_Dados[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna],
                                                    lstTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados[linha].Count - 1 - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.Count - 1 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                    (
                                    string.Format("Alterar_{0}", strCampoBase),
                                    objDadoBase
                                    );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroOdbc
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoOdbc(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoOdbcValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValor(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            default:
                                strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2];
                                strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1];
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)];
                                vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = string.Empty;
                        prpComandoOdbc.Parameters.Clear();

                        for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1);
                            coluna <=
                            (
                            (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
                            ?
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)
                            :
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];

                                    mtdExecutarParametroComandoOdbc
                                        (
                                        vetNomeColunas[coluna],
                                        vetRegistrosColunas[coluna]
                                        );

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3) ?
                                        @"{0} = {2}{1}" :
                                        @"{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroOdbc
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoOdbc
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroOdbc
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipo(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            case (1):
                                vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            default:
                                strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2];
                                strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1];
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)];
                                vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = string.Empty;
                        prpComandoOdbc.Parameters.Clear();

                        for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1);
                            coluna <=
                            (
                            (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
                            ?
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)
                            :
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    break;
                                case (1):
                                    if (Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];

                                    if (Campos_Dados_CampoBase_Operacao_DadoBase[1, coluna] != null)
                                    {
                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3) ?
                                        @"{0} = {2}{1}" :
                                        @"{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroOdbc
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoOdbc
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroOdbc
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            int[] vetTamanhoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            case (1):
                                vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            case (2):
                                vetTamanhoColunas = new int[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                            default:
                                strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2];
                                strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1];
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)];
                                vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                                break;
                        }

                        strTexto = string.Empty;
                        prpComandoOdbc.Parameters.Clear();

                        for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1);
                            coluna <=
                            (
                            (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
                            ?
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)
                            :
                            Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3
                            );
                            coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    break;
                                case (1):
                                    if (Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                    }
                                    break;
                                case (2):
                                    if (Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna] != null)
                                    {
                                        vetTamanhoColunas[coluna] = (int)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTamanhoColunas[coluna] = (int)0;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];

                                    if (Campos_Dados_CampoBase_Operacao_DadoBase[1, coluna] != null)
                                    {
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[2, coluna] != null)
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna],
                                                vetTamanhoColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    strTexto +=
                                        string.Format
                                        (
                                        (coluna == Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3) ?
                                        @"{0} = {2}{1}" :
                                        @"{0} = {2}{1}, ",
                                        vetNomeColunas[coluna],
                                        vetNomeColunas[coluna],
                                        strParametroOdbc
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            mtdExecutarParametroComandoOdbc
                               (
                               string.Format("Alterar_{0}", strCampoBase),
                               objDadoBase
                               );

                            saida &= mtdExecutarComando
                                (
                                string.Format
                                (
                                "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                NomeTabela,
                                strTexto,
                                strCampoBase,
                                strOperacao,
                                strParametroOdbc
                                )
                                );
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoOdbc(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoOdbcValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValor(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)];
                                    vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetLowerBound(0);
                                coluna <=
                                (
                                (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];

                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna]
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipo(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                case (1):
                                    vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)];
                                    vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetLowerBound(0);
                                coluna <=
                                (
                                (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        break;
                                    case (1):
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];

                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );


                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroOdbc
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            int[] vetTamanhoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                case (1):
                                    vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                case (2):
                                    vetTamanhoColunas = new int[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0) - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)];
                                    vetRegistrosColunas = new object[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetLowerBound(0);
                                coluna <=
                                (
                                (linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1)
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        break;
                                    case (1):
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            vetTamanhoColunas[coluna] = (int)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTamanhoColunas[coluna] = (int)0;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];

                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[1][coluna] != null)
                                        {
                                            if (Campos_Dados_CampoBase_Operacao_DadoBase[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna],
                                                    vetTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            vetNomeColunas[coluna],
                                            vetNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                    (
                                    string.Format("Alterar_{0}", strCampoBase),
                                    objDadoBase
                                    );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroOdbc
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoOdbc(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoOdbcValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
            }
            return saida;
        }
        
        private bool mtdAtualizarDadosParametroComandoOdbcValor(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados_CampoBase_Operacao_DadoBase.Count - 1; linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1];
                                    lstRegistrosColunas = new List<object>(Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 + 1);
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                (linha <= 0 + intLinhasAdicionais - 1)
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);

                                        mtdExecutarParametroComandoOdbc
                                            (
                                            lstNomeColunas[coluna],
                                            lstRegistrosColunas[coluna]
                                            );

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroOdbc
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipo(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<System.Data.Odbc.OdbcType> lstTipoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados_CampoBase_Operacao_DadoBase.Count - 1; linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.Odbc.OdbcType> { };
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1];
                                    lstRegistrosColunas = new List<object>(Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 + 1);
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                (linha <= 0 + intLinhasAdicionais - 1)
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        break;
                                    case (1):
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                            lstTipoColunas.Add((System.Data.Odbc.OdbcType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                            lstTipoColunas.Add(System.Data.Odbc.OdbcType.Binary);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);

                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                lstNomeColunas[coluna],
                                                lstTipoColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                   (
                                   string.Format("Alterar_{0}", strCampoBase),
                                   objDadoBase
                                   );


                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroOdbc
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> lstNomeColunas = null;
            List<System.Data.Odbc.OdbcType> lstTipoColunas = null;
            List<int> lstTamanhoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                if (Campos_Dados_CampoBase_Operacao_DadoBase.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados_CampoBase_Operacao_DadoBase.Count - 1; linha++)
                    {
                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.Odbc.OdbcType> { };
                                    break;
                                case (2):
                                    lstTamanhoColunas = new List<int> { };
                                    break;
                                default:
                                    strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 2];
                                    strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase.Count - 1 - 1];
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1];
                                    lstRegistrosColunas = new List<object>(Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 + 1);
                                    break;
                            }

                            strTexto = string.Empty;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = 0;
                                coluna <=
                                (
                                (linha <= 0 + intLinhasAdicionais - 1)
                                ?
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1
                                :
                                Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3
                                );
                                coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        break;
                                    case (1):
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                            lstTipoColunas.Add((System.Data.Odbc.OdbcType)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                            lstTipoColunas.Add(System.Data.Odbc.OdbcType.Binary);
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna] != null)
                                        {
                                            //lstTamanhoColunas[coluna] = (int)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                            lstTamanhoColunas.Add((int)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTamanhoColunas[coluna] = (int)0;
                                            lstTamanhoColunas.Add((int)0);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna]);

                                        if (Campos_Dados_CampoBase_Operacao_DadoBase[1][coluna] != null)
                                        {
                                            if (Campos_Dados_CampoBase_Operacao_DadoBase[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna],
                                                    lstTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        strTexto +=
                                            string.Format
                                            (
                                            (coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1 - 3) ?
                                            @"{0} = {2}{1}" :
                                            @"{0} = {2}{1}, ",
                                            lstNomeColunas[coluna],
                                            lstNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                mtdExecutarParametroComandoOdbc
                                    (
                                    string.Format("Alterar_{0}", strCampoBase),
                                    objDadoBase
                                    );

                                saida &= mtdExecutarComando
                                    (
                                    string.Format
                                    (
                                    "UPDATE {0} SET {1} WHERE {2} {3} {4}Alterar_{2};",
                                    NomeTabela,
                                    strTexto,
                                    strCampoBase,
                                    strOperacao,
                                    strParametroOdbc
                                    )
                                    );
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDadosParametroComandoOdbc(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdAtualizarDadosParametroComandoOdbcValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdAtualizarDadosParametroComandoOdbcValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase);
                    break;
            }
            return saida;
        }

        private bool mtdInserirDadosParametroComandoOdbcValor(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        objResgistrosColunas = null;
                        prpComandoOdbc.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1); coluna <= Campos_Dados.GetUpperBound(1); coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    strNomeColunas +=
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        @"{0}, "
                                        :
                                        @"{0}",
                                        vetNomeColunas[coluna]
                                        );
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    mtdExecutarParametroComandoOdbc
                                        (
                                        vetNomeColunas[coluna],
                                        vetRegistrosColunas[coluna]
                                        );

                                    objResgistrosColunas +=
                                       string.Format
                                       (
                                       (coluna != Campos_Dados.GetUpperBound(1))
                                       ?
                                       @"{1}{0}, "
                                       :
                                       @"{1}{0}",
                                       vetNomeColunas[coluna],
                                       strParametroOdbc
                                       );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdInserirDadosParametroComandoOdbcValorTipo(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            case (1):
                                vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        objResgistrosColunas = null;
                        prpComandoOdbc.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1); coluna <= Campos_Dados.GetUpperBound(1); coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    strNomeColunas +=
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        @"{0}, "
                                        :
                                        @"{0}",
                                        vetNomeColunas[coluna]
                                        );
                                    break;
                                case (1):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    if (Campos_Dados[1, coluna] != null)
                                    {
                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetTipoColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    objResgistrosColunas +=
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        @"{1}{0}, "
                                        :
                                        @"{1}{0}",
                                        vetNomeColunas[coluna],
                                        strParametroOdbc
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdInserirDadosParametroComandoOdbcValorTipoTamanho(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            int[] vetTamanhoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        switch (linha)
                        {
                            case (0):
                                vetNomeColunas = new string[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            case (1):
                                vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            case (2):
                                vetTamanhoColunas = new int[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                            default:
                                vetRegistrosColunas = new object[Campos_Dados.GetUpperBound(1) + 1];
                                break;
                        }

                        objResgistrosColunas = null;
                        prpComandoOdbc.Parameters.Clear();

                        for (int coluna = Campos_Dados.GetLowerBound(1); coluna <= Campos_Dados.GetUpperBound(1); coluna++)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas[coluna] = (string)Campos_Dados[linha, coluna];
                                    strNomeColunas +=
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        @"{0}, "
                                        :
                                        @"{0}",
                                        vetNomeColunas[coluna]
                                        );
                                    break;
                                case (1):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                    }
                                    break;
                                case (2):
                                    if (Campos_Dados[linha, coluna] != null)
                                    {
                                        vetTamanhoColunas[coluna] = (int)Campos_Dados[linha, coluna];
                                    }
                                    else
                                    {
                                        vetTamanhoColunas[coluna] = (int)0;
                                    }
                                    break;
                                default:
                                    vetRegistrosColunas[coluna] = (object)Campos_Dados[linha, coluna];

                                    if (Campos_Dados[1, coluna] != null)
                                    {
                                        if (Campos_Dados[2, coluna] != null)
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna],
                                                vetTamanhoColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                    }
                                    else
                                    {
                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );
                                    }

                                    objResgistrosColunas +=
                                        string.Format
                                        (
                                        (coluna != Campos_Dados.GetUpperBound(1))
                                        ?
                                        @"{1}{0}, "
                                        :
                                        @"{1}{0}",
                                        vetNomeColunas[coluna]
                                        );
                                    break;
                            }
                        }
                        if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                        {
                            saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdInserirDadosParametroComandoOdbc(string NomeTabela, object[,] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdInserirDadosParametroComandoOdbcValor(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdInserirDadosParametroComandoOdbcValorTipo(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdInserirDadosParametroComandoOdbcValorTipoTamanho(NomeTabela, Campos_Dados);
                    break;
            }
            return saida;
        }

        private bool mtdInserirDadosParametroComandoOdbcValor(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0); coluna <= Campos_Dados[linha].GetUpperBound(0); coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            vetNomeColunas[coluna]
                                            );
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        mtdExecutarParametroComandoOdbc
                                            (
                                            vetNomeColunas[coluna],
                                            vetRegistrosColunas[coluna]
                                            );

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            vetNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdInserirDadosParametroComandoOdbcValorTipo(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                case (1):
                                    vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0); coluna <= Campos_Dados[linha].GetUpperBound(0); coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            vetNomeColunas[coluna]
                                            );
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetTipoColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            vetNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdInserirDadosParametroComandoOdbcValorTipoTamanho(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            string[] vetNomeColunas = null;
            System.Data.Odbc.OdbcType[] vetTipoColunas = null;
            int[] vetTamanhoColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1)
                {
                    for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    vetNomeColunas = new string[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                case (1):
                                    vetTipoColunas = new System.Data.Odbc.OdbcType[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                case (2):
                                    vetTamanhoColunas = new int[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                                default:
                                    vetRegistrosColunas = new object[Campos_Dados[linha].GetUpperBound(0) + 1];
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = Campos_Dados[linha].GetLowerBound(0); coluna <= Campos_Dados[linha].GetUpperBound(0); coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        vetNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            vetNomeColunas[coluna]
                                            );
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            vetTamanhoColunas[coluna] = (int)Campos_Dados[linha][coluna];
                                        }
                                        else
                                        {
                                            vetTamanhoColunas[coluna] = (int)0;
                                        }
                                        break;
                                    default:
                                        vetRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            if (Campos_Dados[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna],
                                                    vetTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    vetNomeColunas[coluna],
                                                    vetTipoColunas[coluna],
                                                    vetRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                vetNomeColunas[coluna],
                                                vetRegistrosColunas[coluna]
                                                );
                                        }

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].GetUpperBound(0))
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            vetNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdInserirDadosParametroComandoOdbc(string NomeTabela, object[][] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdInserirDadosParametroComandoOdbcValor(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdInserirDadosParametroComandoOdbcValorTipo(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdInserirDadosParametroComandoOdbcValorTipoTamanho(NomeTabela, Campos_Dados);
                    break;
            }
            return saida;
        }

        private bool mtdInserirDadosParametroComandoOdbcValor(string NomeTabela, List<List<object>> Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 1;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            List<string> lstNomeColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = 0; coluna <= Campos_Dados[linha].Count - 1; coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            lstNomeColunas[coluna]
                                            );
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        mtdExecutarParametroComandoOdbc
                                            (
                                            lstNomeColunas[coluna],
                                            lstRegistrosColunas[coluna]
                                            );

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            lstNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdInserirDadosParametroComandoOdbcValorTipo(string NomeTabela, List<List<object>> Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 2;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            List<string> lstNomeColunas = null;
            List<System.Data.Odbc.OdbcType> lstTipoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.Odbc.OdbcType> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = 0; coluna <= Campos_Dados[linha].Count - 1; coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            lstNomeColunas[coluna]
                                            );
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                            lstTipoColunas.Add(System.Data.Odbc.OdbcType.Binary);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                lstNomeColunas[coluna],
                                                lstTipoColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            lstNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        private bool mtdInserirDadosParametroComandoOdbcValorTipoTamanho(string NomeTabela, List<List<object>> Campos_Dados)
        {
            bool saida = true;

            int intLinhasAdicionais = 3;
            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;
            List<string> lstNomeColunas = null;
            List<System.Data.Odbc.OdbcType> lstTipoColunas = null;
            List<int> lstTamanhoColunas = null;
            List<object> lstRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados != null)
            {
                if (Campos_Dados.Count >= intLinhasAdicionais + 1)
                {
                    for (int linha = 0; linha <= Campos_Dados.Count - 1; linha++)
                    {
                        if (Campos_Dados[linha] != null)
                        {
                            switch (linha)
                            {
                                case (0):
                                    lstNomeColunas = new List<string> { };
                                    break;
                                case (1):
                                    lstTipoColunas = new List<System.Data.Odbc.OdbcType> { };
                                    break;
                                case (2):
                                    lstTamanhoColunas = new List<int> { };
                                    break;
                                default:
                                    lstRegistrosColunas = new List<object> { };
                                    break;
                            }

                            objResgistrosColunas = null;
                            prpComandoOdbc.Parameters.Clear();

                            for (int coluna = 0; coluna <= Campos_Dados[linha].Count - 1; coluna++)
                            {
                                switch (linha)
                                {
                                    case (0):
                                        //lstNomeColunas[coluna] = (string)Campos_Dados[linha][coluna];
                                        lstNomeColunas.Add((string)Campos_Dados[linha][coluna]);
                                        strNomeColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{0}, "
                                            :
                                            @"{0}",
                                            lstNomeColunas[coluna]
                                            );
                                        break;
                                    case (1):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTipoColunas[coluna] = (System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna];
                                            lstTipoColunas.Add((System.Data.Odbc.OdbcType)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTipoColunas[coluna] = System.Data.Odbc.OdbcType.Binary;
                                            lstTipoColunas.Add(System.Data.Odbc.OdbcType.Binary);
                                        }
                                        break;
                                    case (2):
                                        if (Campos_Dados[linha][coluna] != null)
                                        {
                                            //lstTamanhoColunas[coluna] = (int)Campos_Dados[linha][coluna];
                                            lstTamanhoColunas.Add((int)Campos_Dados[linha][coluna]);
                                        }
                                        else
                                        {
                                            //lstTamanhoColunas[coluna] = (int)0;
                                            lstTamanhoColunas.Add((int)0);
                                        }
                                        break;
                                    default:
                                        //lstRegistrosColunas[coluna] = (object)Campos_Dados[linha][coluna];
                                        lstRegistrosColunas.Add((object)Campos_Dados[linha][coluna]);

                                        if (Campos_Dados[1][coluna] != null)
                                        {
                                            if (Campos_Dados[2][coluna] != null)
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna],
                                                    lstTamanhoColunas[coluna]
                                                    );
                                            }
                                            else
                                            {
                                                mtdExecutarParametroComandoOdbc
                                                    (
                                                    lstNomeColunas[coluna],
                                                    lstTipoColunas[coluna],
                                                    lstRegistrosColunas[coluna]
                                                    );
                                            }
                                        }
                                        else
                                        {
                                            mtdExecutarParametroComandoOdbc
                                                (
                                                lstNomeColunas[coluna],
                                                lstRegistrosColunas[coluna]
                                                );
                                        }

                                        objResgistrosColunas +=
                                            string.Format
                                            (
                                            (coluna != Campos_Dados[linha].Count - 1)
                                            ?
                                            @"{1}{0}, "
                                            :
                                            @"{1}{0}",
                                            lstNomeColunas[coluna],
                                            strParametroOdbc
                                            );
                                        break;
                                }
                            }
                            if (linha >= 0 + intLinhasAdicionais)
                            {
                                saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                            }
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdInserirDadosParametroComandoOdbc(string NomeTabela, List<List<object>> Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            bool saida = false;
            switch (ModoParametroComando)
            {
                case enmModoParametroComando.Valor:
                    saida = mtdInserirDadosParametroComandoOdbcValor(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipo:
                    saida = mtdInserirDadosParametroComandoOdbcValorTipo(NomeTabela, Campos_Dados);
                    break;
                case enmModoParametroComando.ValorTipoTamanho:
                    saida = mtdInserirDadosParametroComandoOdbcValorTipoTamanho(NomeTabela, Campos_Dados);
                    break;
            }
            return saida;
        }

        public bool mtdDeletarDadosParametroComandoOdbc(string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            mtdExecutarParametroComandoOdbc
                (
                CampoSelecionador,
                Dado
                );

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando(string.Format("DELETE FROM {0} WHERE {1} {2} {3}{1};", NomeTabela, CampoSelecionador, Operacao, strParametroOdbc));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoOdbc(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            mtdExecutarParametroComandoOdbc
                (
                CampoSelecionador,
                Dado
                );

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0}{1} FROM {2} WHERE {3} {4} {5}{3};",
                NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                Campos,
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                strParametroOdbc
                )
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoOdbc(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoOdbc
                (
                NumeroLinhas,
                mtdVetorLinhaCampos(Campos),
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoOdbc(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoOdbc
                (
                NumeroLinhas,
                mtdListaLinhaCampos(Campos),
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoOdbc(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            mtdExecutarParametroComandoOdbc
                (
                CampoSelecionador,
                Dado
                );

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0}{1} FROM {2} WHERE {3} {4} {7}{3} ORDER BY {5}{6};",
                NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                Campos,
                NomeTabela,
                CampoSelecionador,
                Operacao,
                CampoOrdenador,
                Crescente ? string.Empty : " DESC",
                strParametroOdbc
                )
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoOdbc(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoOdbc
                (
                NumeroLinhas,
                mtdVetorLinhaCampos(Campos),
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoOrdenador,
                Crescente
                );

            return saida;
        }

        public bool mtdSelecionarDadosParametroComandoOdbc(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDadosParametroComandoOdbc
                (
                NumeroLinhas,
                mtdListaLinhaCampos(Campos),
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoOrdenador,
                Crescente
                );

            return saida;
        }
    }

    public class clsBDOdbc : clsImplementacaoBancoDados, itfImplementacaoBancoDados
    {
        private static object LockBDOdbc = new object();

        public override bool mtdAbrirConexao(string Conexao, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            lock (LockBDOdbc)
            {
                bool saida = false;
                strExcecao = "mtdAbrirConexao: Nao houve excecao.";
                prpConexao = Conexao;
                //prpTipoSistemaGerenciadorBancoDadosRelacional = base.enuTipoSistemaGerenciadorBancoDadosRelacional;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                            objConexaoOdbc.ConnectionString = prpConexao;
                            objConexaoOdbc.Open();
                            if (objConexaoOdbc.State == System.Data.ConnectionState.Open)
                            {
                                saida = true;
                            }
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    saida = false;
                    strExcecao = "mtdAbrirConexao: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return saida;
            }
        }

        public override bool mtdFecharConexao()
        {
            lock (LockBDOdbc)
            {
                bool saida = false;
                strExcecao = "mtdFecharConexao: Nao houve excecao.";
                setNumeroLinhas = 0;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                            objConexaoOdbc.Close();
                            break;
                    }
                    saida = true;
                }
                catch (System.Exception ex)
                {
                    saida = false;
                    strExcecao = "mtdFecharConexao: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return saida;
            }
        }

        public override bool mtdExecutarComando(string Comando)
        {
            lock (LockBDOdbc)
            {
                bool saida = false;
                strExcecao = "mtdExecutarComando: Nao houve excecao.";
                try
                {
                    prpComando = Comando;
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                            objComandoOdbc.CommandType = System.Data.CommandType.Text;
                            objComandoOdbc.CommandText = prpComando;
                            objComandoOdbc.Connection = objConexaoOdbc;
                            mtdFecharLeitorDados();
                            objComandoOdbc.ExecuteNonQuery();
                            break;
                    }
                    saida = true;
                }
                catch (System.Exception ex)
                {
                    saida = false;
                    strExcecao = "mtdExecutarComando: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return saida;
            }
        }

        public override string[] mtdObterCabecalhoColunasVetor(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDOdbc)
            {
                strExcecao = "mtdObterCabecalhoColunas: Nao houve excecao.";

                int intNumeroColunas = 0;
                string[] vetCabecalhos = new string[intNumeroColunas];
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        vetCabecalhos = new string[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                                    vetCabecalhos[contador] = objLeitorDadosOdbc.GetName(contador);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        vetCabecalhos = new string[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            vetCabecalhos[contador] = objAjustadorDados.Tables[strTabela].Columns[contador].ColumnName.ToString();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterCabecalhoColunas: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return vetCabecalhos;
            }
        }

        public override List<object> mtdObterCabecalhoColunasLista(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDOdbc)
            {
                strExcecao = "mtdObterCabecalhoColunas: Nao houve excecao.";

                int intNumeroColunas = 0;
                List<object> lstCabecalhos = new List<object>(intNumeroColunas);
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        lstCabecalhos = new List<object>() { };
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            lstCabecalhos.Add(null);
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                                    lstCabecalhos[contador] = objLeitorDadosOdbc.GetName(contador);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        lstCabecalhos = new List<object>();
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            lstCabecalhos.Add(null);
                            lstCabecalhos[contador] = objAjustadorDados.Tables[strTabela].Columns[contador].ColumnName.ToString();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterCabecalhoColunas: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return lstCabecalhos;
            }
        }

        public override bool mtdDefinirLeitorDados(System.Data.CommandBehavior ComandoComportamento)
        {
            lock (LockBDOdbc)
            {
                bool saida = false;
                strExcecao = "mtdDefinirLeitorDados: Nao houve excecao.";
                prpComandoComportamento = ComandoComportamento;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                            objLeitorDadosOdbc = objComandoOdbc.ExecuteReader(prpComandoComportamento);
                            break;
                    }
                    saida = true;
                }
                catch (System.Exception ex)
                {
                    saida = false;
                    strExcecao = "mtdDefinirLeitorDados: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                intLinha = 0;
                return saida;
            }
        }

        public override object[] mtdObterValorRegistroVetor(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDOdbc)
            {
                strExcecao = "mtdObterValorRegistro: Nao houve excecao.";
                int intNumeroColunas = 0;
                object[] vetValores = null;
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        vetValores = new object[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                                    vetValores[contador] = objLeitorDadosOdbc[contador];
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        vetValores = new string[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            vetValores[contador] = objAjustadorDados.Tables[strTabela].Rows[0][contador];
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterValorRegistro: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return vetValores;
            }
        }

        public override List<object> mtdObterValorRegistroLista(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDOdbc)
            {
                strExcecao = "mtdObterValorRegistro: Nao houve excecao.";
                int intNumeroColunas = 0;
                List<object> lstValores = null;
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        lstValores = new List<object>(intNumeroColunas);
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                                    lstValores[contador] = objLeitorDadosOdbc[contador];
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        lstValores = new List<object>(intNumeroColunas);
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            lstValores[contador] = objAjustadorDados.Tables[strTabela].Rows[0][contador];
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterValorRegistro: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return lstValores;
            }
        }

        public override System.Type[] mtdObterTipoRegistroVetor(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDOdbc)
            {
                strExcecao = "mtdObterTipoRegistro: Nao houve excecao.";
                int intNumeroColunas = 0;
                System.Type[] vetTipos = null;
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        vetTipos = new System.Type[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                                    vetTipos[contador] = objLeitorDadosOdbc.GetValue(contador).GetType();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        vetTipos = new System.Type[intNumeroColunas];
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            vetTipos[contador] = objAjustadorDados.Tables[strTabela].Columns[contador].Caption.GetType();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterTipoRegistro: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return vetTipos;
            }
        }

        public override List<System.Type> mtdObterTipoRegistroLista(string Tabela, string Comando, bool Otimizacao)
        {
            lock (LockBDOdbc)
            {
                strExcecao = "mtdObterTipoRegistro: Nao houve excecao.";
                int intNumeroColunas = 0;
                List<System.Type> lstTipos = null;
                try
                {
                    if (Otimizacao)
                    {
                        prpTabela = Tabela;
                        prpComando = Comando;
                        intNumeroColunas = mtdNumeroColunas();
                        lstTipos = new List<System.Type>(intNumeroColunas);
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador++)
                        {
                            switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                            {
                                case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                                    lstTipos[contador] = objLeitorDadosOdbc.GetValue(contador).GetType();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = mtdNumeroColunas(false);
                        lstTipos = new List<System.Type>(intNumeroColunas);
                        for (int contador = 0; contador <= intNumeroColunas - 1; contador += 1)
                        {
                            lstTipos[contador] = objAjustadorDados.Tables[strTabela].Columns[contador].Caption.GetType();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdObterTipoRegistro: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return lstTipos;
            }
        }

        public override bool mtdFecharLeitorDados()
        {
            lock (LockBDOdbc)
            {
                bool saida = false;
                strExcecao = "mtdFecharLeitorDados: Nao houve excecao.";
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                            if (objLeitorDadosOdbc != null)
                            {
                                if (!objLeitorDadosOdbc.IsClosed)
                                {
                                    objLeitorDadosOdbc.Close();
                                }
                            }
                            break;
                    }
                    saida = true;
                }
                catch (System.Exception ex)
                {
                    saida = false;
                    strExcecao = "mtdFecharLeitorDados: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                intLinha = 0;
                return saida;
            }
        }

        public override bool mtdAdaptadorDados(string Conexao, string Comando, string Tabela, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
        {
            lock (LockBDOdbc)
            {
                bool saida = false;
                strExcecao = "mtdAdaptadorDados: Nao houve excecao.";
                prpConexao = Conexao;
                prpComando = Comando;
                prpTabela = Tabela;
                prpAjustadorDados = new System.Data.DataSet();
                prpTabelaDados = new System.Data.DataTable();
                prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                            objAdaptadorDadosOdbc = new System.Data.Odbc.OdbcDataAdapter(prpComando, prpConexao);
                            objAdaptadorDadosOdbc.Fill(prpAjustadorDados, Tabela);
                            objAdaptadorDadosOdbc.Fill(prpTabelaDados);
                            saida = true;
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    saida = false;
                    strExcecao = "mtdAdaptadorDados: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return saida;
            }
        }

        public override bool mtdProximoRegistro()
        {
            lock (LockBDOdbc)
            {
                strExcecao = "mtdProximoRegistro: Nao houve excecao.";
                bool saida = false;
                try
                {
                    switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                    {
                        case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                            saida = objLeitorDadosOdbc.Read();
                            break;
                    }
                    if (saida)
                    {
                        intLinha += 1;
                    }
                    else
                    {
                        intLinha = 0;
                    }
                }
                catch (System.Exception ex)
                {
                    intLinha = -1;
                    strExcecao = "mtdProximoRegistro: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return saida;
            }
        }

        public override int mtdNumeroColunas(bool Otimizacao)
        {
            lock (LockBDOdbc)
            {
                strExcecao = "mtdNumeroColunas: Nao houve excecao.";
                int intNumeroColunas = 0;
                try
                {
                    if (Otimizacao)
                    {
                        switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                        {
                            case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                                intNumeroColunas = objLeitorDadosOdbc.FieldCount;
                                break;
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroColunas = objAjustadorDados.Tables[strTabela].Columns.Count;
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdNumeroColunas: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return intNumeroColunas;
            }
        }

        public override int mtdNumeroLinhas(bool Otimizacao)
        {
            lock (LockBDOdbc)
            {
                strExcecao = "mtdNumeroLinhas: Nao houve excecao.";
                int intNumeroLinhas = 0;
                try
                {
                    if (Otimizacao)
                    {
                        switch (enuTipoSistemaGerenciadorBancoDadosRelacional)
                        {
                            case TipoSistemaGerenciadorBancoDadosRelacional.Odbc:
                                intNumeroLinhas = mtdContarNumeroLinhas();
                                break;
                        }
                    }
                    else
                    {
                        mtdAdaptadorDados();
                        intNumeroLinhas = objAjustadorDados.Tables[strTabela].Rows.Count;
                    }
                }
                catch (System.Exception ex)
                {
                    strExcecao = "mtdNumeroLinhas: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine(strExcecao);
                }
                return intNumeroLinhas;
            }
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoOdbc(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoOdbc(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoOdbc(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoOdbc(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoOdbc(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase, ModoParametroComando);
        }

        public bool mtdAtualizarDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando)
        {
            return mtdAtualizarDadosParametroComandoOdbc(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase, ModoParametroComando);
        }

        public bool mtdInserirDadosParametroComando(string NomeTabela, object[,] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            return mtdInserirDadosParametroComandoOdbc(NomeTabela, Campos_Dados, ModoParametroComando);
        }

        public bool mtdInserirDadosParametroComando(string NomeTabela, object[][] Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            return mtdInserirDadosParametroComandoOdbc(NomeTabela, Campos_Dados, ModoParametroComando);
        }

        public bool mtdInserirDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados, enmModoParametroComando ModoParametroComando)
        {
            return mtdInserirDadosParametroComandoOdbc(NomeTabela, Campos_Dados, ModoParametroComando);
        }

        public bool mtdDeletarDadosParametroComando(string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdDeletarDadosParametroComandoOdbc(NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdSelecionarDadosParametroComandoOdbc(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdSelecionarDadosParametroComandoOdbc(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            return mtdSelecionarDadosParametroComandoOdbc(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosParametroComandoOdbc(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosParametroComandoOdbc(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
        }

        public bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            return mtdSelecionarDadosParametroComandoOdbc(NumeroLinhas, Campos, NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Code to cleanup managed resources held by the class.
            }
            // Code to cleanup unmanaged resources held by the class.
            base.Dispose(disposing);
        }
        // Note that the derived class does not // re-implement IDisposable
    }
}
