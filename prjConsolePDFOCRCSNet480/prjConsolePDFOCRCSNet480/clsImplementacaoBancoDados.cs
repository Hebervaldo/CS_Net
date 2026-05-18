using System;
using System.Collections.Generic;
using System.Text;

namespace prjConsolePDFOCRCSNet480
{
    public enum enmModoParametroComando
    {
        Valor,
        ValorTipo,
        ValorTipoTamanho
    }

    public partial class clsImplementacaoBancoDados : clsConexaoBancoDados
    {
        private TipoConexao enuTipoConexao = TipoConexao.Indisponivel;

        public clsImplementacaoBancoDados()
            : base(string.Empty, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel)
        {
        }

        public clsImplementacaoBancoDados(string Conexao)
            : base(Conexao, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel)
        {
        }

        public clsImplementacaoBancoDados(TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
            : base(string.Empty, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional)
        {
        }

        public clsImplementacaoBancoDados(string Conexao, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
            : base(Conexao, string.Empty, TipoSistemaGerenciadorBancoDadosRelacional)
        {
        }

        public clsImplementacaoBancoDados(string Conexao, string Comando, TipoSistemaGerenciadorBancoDadosRelacional TipoSistemaGerenciadorBancoDadosRelacional)
            : base(Conexao, Comando, TipoSistemaGerenciadorBancoDadosRelacional)
        {
        }

        //public enum enmModoParametroComando
        //{
        //    Valor,
        //    ValorTipo,
        //    ValorTipoTamanho
        //}

        public bool mtdAlterarTabela(string Nome, string Operacao_Campo_Tipo_Comprimento_Restricao)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional) &&
                        mtdExecutarComando(string.Format("ALTER TABLE {0} {1});", Nome, Operacao_Campo_Tipo_Comprimento_Restricao));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAlterarTabela(string Nome, string[,] Operacao_Campo_Tipo_Comprimento_Restricao)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("O numero de colunas está incorreto, informe uma matriz com cinco colunas.");

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Operacao_Campo_Tipo_Comprimento_Restricao.GetUpperBound(1) + 1 == 5)
            {
                string strTexto = string.Empty;
                for
                    (
                    int linha = Operacao_Campo_Tipo_Comprimento_Restricao.GetLowerBound(0);
                    linha <= Operacao_Campo_Tipo_Comprimento_Restricao.GetUpperBound(0);
                    linha++
                    )
                {
                    for (
                        int coluna = Operacao_Campo_Tipo_Comprimento_Restricao.GetLowerBound(1);
                        coluna <= Operacao_Campo_Tipo_Comprimento_Restricao.GetUpperBound(1);
                        coluna++
                        )
                    {
                        switch (coluna)
                        {
                            case 0:
                                strTexto = string.Format
                                    (
                                    "{0} ",
                                    Operacao_Campo_Tipo_Comprimento_Restricao[linha, coluna]
                                    );
                                break;
                            case 1:
                                strTexto += string.Format
                                    (
                                    "{0} ",
                                    Operacao_Campo_Tipo_Comprimento_Restricao[linha, coluna]
                                    );
                                break;
                            case 2:
                                if (Operacao_Campo_Tipo_Comprimento_Restricao[linha, coluna + 1].Equals(string.Empty))
                                {
                                    strTexto += string.Format
                                        (
                                        "{0} ",
                                        Operacao_Campo_Tipo_Comprimento_Restricao[linha, coluna]
                                        );
                                }
                                else
                                {
                                    strTexto += string.Format
                                        (
                                        "{0}",
                                        Operacao_Campo_Tipo_Comprimento_Restricao[linha, coluna]
                                        );
                                }
                                break;
                            case 3:
                                if (Operacao_Campo_Tipo_Comprimento_Restricao[linha, coluna].Equals(string.Empty))
                                {
                                    strTexto += string.Empty;
                                }
                                else
                                {
                                    strTexto += string.Format
                                        (
                                        "({0})",
                                        Operacao_Campo_Tipo_Comprimento_Restricao[linha, coluna]
                                        );
                                }
                                break;
                            case 4:
                                strTexto += string.Format
                                    (
                                    "{0}",
                                    Operacao_Campo_Tipo_Comprimento_Restricao[linha, coluna]
                                    );
                                break;
                        }
                    }
                    saida &= mtdExecutarComando(string.Format
                                            (
                                            "ALTER TABLE {0} {1};",
                                            Nome,
                                            strTexto
                                            ));
                }
            }
            else
            {
                setExcecao = ex.Message;
                saida = false;
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAlterarTabela(string Nome, string[][] Operacao_Campo_Tipo_Comprimento_Restricao)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("O numero de colunas está incorreto, informe uma matriz com cinco colunas.");

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            string strTexto = string.Empty;
            for
                (
                int linha = Operacao_Campo_Tipo_Comprimento_Restricao.GetLowerBound(0);
                linha <= Operacao_Campo_Tipo_Comprimento_Restricao.GetUpperBound(0);
                linha++
                )
            {
                if (Operacao_Campo_Tipo_Comprimento_Restricao[linha].GetUpperBound(0) + 1 == 5)
                {
                    for
                        (
                        int coluna = Operacao_Campo_Tipo_Comprimento_Restricao[linha].GetLowerBound(0);
                        coluna <= Operacao_Campo_Tipo_Comprimento_Restricao[linha].GetUpperBound(0);
                        coluna++
                        )
                    {
                        switch (coluna)
                        {
                            case 0:
                                strTexto = string.Format
                                    (
                                    "{0} ",
                                    Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                    );
                                break;
                            case 1:
                                strTexto += string.Format
                                    (
                                    "{0} ",
                                    Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                    );
                                break;
                            case 2:
                                if (Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna + 1].Equals(string.Empty))
                                {
                                    strTexto += string.Format
                                        (
                                        "{0} ",
                                        Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                        );
                                }
                                else
                                {
                                    strTexto += string.Format
                                        (
                                        "{0}",
                                        Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                        );
                                }
                                break;
                            case 3:
                                if (Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna].Equals(string.Empty))
                                {
                                    strTexto += string.Empty;
                                }
                                else
                                {
                                    strTexto += string.Format
                                        (
                                        "({0})",
                                        Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                        );
                                }
                                break;
                            case 4:
                                strTexto += string.Format
                                    (
                                    "{0}",
                                    Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                    );
                                break;
                        }
                    }
                }
                else
                {
                    setExcecao = ex.Message;
                    saida = false;
                }
                saida &= mtdExecutarComando(string.Format
                    (
                    "ALTER TABLE {0} {1};",
                    Nome,
                    strTexto
                    ));
            }
            mtdFecharConexao();

            return saida;
        }


        public bool mtdAlterarTabela(string Nome, List<List<string>> Operacao_Campo_Tipo_Comprimento_Restricao)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("O numero de colunas está incorreto, informe uma matriz com cinco colunas.");

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            string strTexto = string.Empty;
            for
                (
                int linha = 0;
                linha <= (Operacao_Campo_Tipo_Comprimento_Restricao.Count - 1);
                linha++
                )
            {
                if ((Operacao_Campo_Tipo_Comprimento_Restricao[linha].Count - 1) + 1 == 5)
                {
                    for
                        (
                        int coluna = 0;
                        coluna <= (Operacao_Campo_Tipo_Comprimento_Restricao[linha].Count - 1);
                        coluna++
                        )
                    {
                        switch (coluna)
                        {
                            case 0:
                                strTexto = string.Format
                                    (
                                    "{0} ",
                                    Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                    );
                                break;
                            case 1:
                                strTexto += string.Format
                                    (
                                    "{0} ",
                                    Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                    );
                                break;
                            case 2:
                                if (Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna + 1].Equals(string.Empty))
                                {
                                    strTexto += string.Format
                                        (
                                        "{0} ",
                                        Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                        );
                                }
                                else
                                {
                                    strTexto += string.Format
                                        (
                                        "{0}",
                                        Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                        );
                                }
                                break;
                            case 3:
                                if (Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna].Equals(string.Empty))
                                {
                                    strTexto += string.Empty;
                                }
                                else
                                {
                                    strTexto += string.Format
                                        (
                                        "({0})",
                                        Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                        );
                                }
                                break;
                            case 4:
                                strTexto += string.Format
                                    (
                                    "{0}",
                                    Operacao_Campo_Tipo_Comprimento_Restricao[linha][coluna]
                                    );
                                break;
                        }
                    }
                }
                else
                {
                    setExcecao = ex.Message;
                    saida = false;
                }
                saida &= mtdExecutarComando(string.Format
                    (
                    "ALTER TABLE {0} {1};",
                    Nome,
                    strTexto
                    ));
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdCriarTabela(string Nome, string Registro_Tipo_Comprimento_Restricao)
        {
            bool saida = true;

            saida = mtdExecutarComando(string.Format("CREATE TABLE {0}({1});", Nome, Registro_Tipo_Comprimento_Restricao));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdCriarTabela(string Nome, string[,] Registro_Tipo_Comprimento_Restricao)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("O numero de colunas está incorreto, informe uma matriz com quatro colunas.");

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Registro_Tipo_Comprimento_Restricao.GetUpperBound(1) + 1 == 4)
            {
                string strTexto = string.Empty;
                for
                    (
                    int linha = Registro_Tipo_Comprimento_Restricao.GetLowerBound(0);
                    linha <= Registro_Tipo_Comprimento_Restricao.GetUpperBound(0);
                    linha++
                    )
                {
                    for
                        (
                        int coluna = Registro_Tipo_Comprimento_Restricao.GetLowerBound(1);
                        coluna <= Registro_Tipo_Comprimento_Restricao.GetUpperBound(1);
                        coluna++
                        )
                    {
                        switch (coluna)
                        {
                            case 0:
                                strTexto += string.Format("{0} ", Registro_Tipo_Comprimento_Restricao[linha, coluna]);
                                break;
                            case 1:
                                if (Registro_Tipo_Comprimento_Restricao[linha, coluna + 1].Equals(string.Empty))
                                {
                                    strTexto += string.Format("{0} ", Registro_Tipo_Comprimento_Restricao[linha, coluna]);
                                }
                                else
                                {
                                    strTexto += string.Format("{0}", Registro_Tipo_Comprimento_Restricao[linha, coluna]);
                                }
                                break;
                            case 2:
                                if (Registro_Tipo_Comprimento_Restricao[linha, coluna].Equals(string.Empty))
                                {
                                    strTexto += string.Empty;
                                }
                                else
                                {
                                    strTexto += string.Format("({0})", Registro_Tipo_Comprimento_Restricao[linha, coluna]);
                                }
                                break;
                            case 3:
                                strTexto += string.Format("{0}", Registro_Tipo_Comprimento_Restricao[linha, coluna]);
                                break;
                        }
                    }
                    if (linha != Registro_Tipo_Comprimento_Restricao.GetUpperBound(0))
                    {
                        strTexto += ", ";
                    }
                }
                saida &= mtdExecutarComando(string.Format("CREATE TABLE {0}({1});", Nome, strTexto));
            }
            else
            {
                setExcecao = ex.Message;
                saida = false;
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdCriarTabela(string Nome, string[][] Registro_Tipo_Comprimento_Restricao)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("O numero de colunas está incorreto, informe uma matriz com quatro colunas.");

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            string strTexto = string.Empty;
            for (int linha = Registro_Tipo_Comprimento_Restricao.GetLowerBound(0); linha <= Registro_Tipo_Comprimento_Restricao.GetUpperBound(0); linha++)
            {
                if (Registro_Tipo_Comprimento_Restricao[linha].GetUpperBound(0) + 1 == 4)
                {
                    for (int coluna = Registro_Tipo_Comprimento_Restricao[linha].GetLowerBound(0); coluna <= Registro_Tipo_Comprimento_Restricao[linha].GetUpperBound(0); coluna++)
                    {
                        switch (coluna)
                        {
                            case 0:
                                strTexto += string.Format("{0} ", Registro_Tipo_Comprimento_Restricao[linha][coluna]);
                                break;
                            case 1:
                                if (Registro_Tipo_Comprimento_Restricao[linha][coluna + 1].Equals(string.Empty))
                                {
                                    strTexto += string.Format("{0} ", Registro_Tipo_Comprimento_Restricao[linha][coluna]);
                                }
                                else
                                {
                                    strTexto += string.Format("{0}", Registro_Tipo_Comprimento_Restricao[linha][coluna]);
                                }
                                break;
                            case 2:
                                if (Registro_Tipo_Comprimento_Restricao[linha][coluna].Equals(string.Empty))
                                {
                                    strTexto += string.Empty;
                                }
                                else
                                {
                                    strTexto += string.Format("({0})", Registro_Tipo_Comprimento_Restricao[linha][coluna]);
                                }
                                break;
                            case 3:
                                strTexto += string.Format("{0}", Registro_Tipo_Comprimento_Restricao[linha][coluna]);
                                break;
                        }
                    }
                    if (linha != Registro_Tipo_Comprimento_Restricao.GetUpperBound(0) && Registro_Tipo_Comprimento_Restricao[linha + 1] != null)
                    {
                        strTexto += ", ";
                    }
                }
                else
                {
                    setExcecao = ex.Message;
                    saida = false;
                }
            }
            saida &= mtdExecutarComando(string.Format("CREATE TABLE {0}({1});", Nome, strTexto));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdCriarTabela(string Nome, List<List<string>> Registro_Tipo_Comprimento_Restricao)
        {
            bool saida = true;

            System.Exception ex = new System.Exception("O numero de colunas está incorreto, informe uma matriz com quatro colunas.");

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            string strTexto = string.Empty;
            for (int linha = 0; linha <= (Registro_Tipo_Comprimento_Restricao.Count - 1); linha++)
            {
                if ((Registro_Tipo_Comprimento_Restricao[linha].Count - 1) + 1 == 4)
                {
                    for (int coluna = 0; coluna <= (Registro_Tipo_Comprimento_Restricao[linha].Count - 1); coluna++)
                    {
                        switch (coluna)
                        {
                            case 0:
                                strTexto += string.Format("{0} ", Registro_Tipo_Comprimento_Restricao[linha][coluna]);
                                break;
                            case 1:
                                if (Registro_Tipo_Comprimento_Restricao[linha][coluna + 1].Equals(string.Empty))
                                {
                                    strTexto += string.Format("{0} ", Registro_Tipo_Comprimento_Restricao[linha][coluna]);
                                }
                                else
                                {
                                    strTexto += string.Format("{0}", Registro_Tipo_Comprimento_Restricao[linha][coluna]);
                                }
                                break;
                            case 2:
                                if (Registro_Tipo_Comprimento_Restricao[linha][coluna].Equals(string.Empty))
                                {
                                    strTexto += string.Empty;
                                }
                                else
                                {
                                    strTexto += string.Format("({0})", Registro_Tipo_Comprimento_Restricao[linha][coluna]);
                                }
                                break;
                            case 3:
                                strTexto += string.Format("{0}", Registro_Tipo_Comprimento_Restricao[linha][coluna]);
                                break;
                        }
                    }
                    if (linha != (Registro_Tipo_Comprimento_Restricao.Count - 1) && Registro_Tipo_Comprimento_Restricao[linha + 1] != null)
                    {
                        strTexto += ", ";
                    }
                }
                else
                {
                    setExcecao = ex.Message;
                    saida = false;
                }
            }
            saida &= mtdExecutarComando(string.Format("CREATE TABLE {0}({1});", Nome, strTexto));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdDeletarTabela(string Nome)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando(string.Format("DROP TABLE {0};", Nome));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDados(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                {
                    strTexto = string.Empty;
                    if (linha != Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                    {
                        strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2];
                        strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1];
                        objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)];
                        vetRegistrosColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                    }
                    else
                    {
                        vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) + 1];
                    }

                    for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1); coluna <= ((linha == Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0)) ? Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) : Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3); coluna++)
                    {
                        if (linha != Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                        {
                            vetRegistrosColunas[coluna] = Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];

                            strTexto +=
                                string.Format((coluna == Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3) ?
                                "{0} = {1}" :
                                "{0} = {1}, ",
                                vetNomeColunas[coluna],
                                (object)vetRegistrosColunas[coluna]);
                        }
                        else
                        {
                            vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha, coluna];
                        }
                    }
                    if (linha != Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                    {
                        saida &= mtdExecutarComando(
                            string.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, strTexto, strCampoBase, strOperacao, (object)objDadoBase));
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDados(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            string[] vetNomeColunas = null;
            object[] vetRegistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                for (int linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0); linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0); linha++)
                {
                    if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                    {
                        strTexto = string.Empty;
                        if (linha != Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                        {
                            strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 2];
                            strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 1];
                            objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0)];
                            vetRegistrosColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                        }
                        else
                        {
                            vetNomeColunas = new string[Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) + 1];
                        }

                        for (int coluna = Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetLowerBound(0); coluna <= ((linha == Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0)) ? Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) : Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3); coluna++)
                        {
                            if (linha != Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                            {
                                vetRegistrosColunas[coluna] = Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];

                                strTexto +=
                                    string.Format((coluna == Campos_Dados_CampoBase_Operacao_DadoBase[linha].GetUpperBound(0) - 3) ?
                                    "{0} = {1}" :
                                    "{0} = {1}, ",
                                    vetNomeColunas[coluna],
                                    (object)vetRegistrosColunas[coluna]);
                            }
                            else
                            {
                                vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                            }
                        }
                        if (linha != Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0))
                        {
                            saida &= mtdExecutarComando
                                (string.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, strTexto, strCampoBase, strOperacao, (object)objDadoBase));
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDados(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase)
        {
            bool saida = true;

            string strCampoBase = string.Empty;
            string strOperacao = string.Empty;
            object objDadoBase = string.Empty;
            string strTexto = string.Empty;
            List<string> vetNomeColunas = new List<string> { };
            List<object> vetRegistrosColunas = new List<object> { };

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Campos_Dados_CampoBase_Operacao_DadoBase != null)
            {
                for (int linha = 0; linha <= (Campos_Dados_CampoBase_Operacao_DadoBase.Count - 1); linha++)
                {
                    if (Campos_Dados_CampoBase_Operacao_DadoBase[linha] != null)
                    {
                        strTexto = string.Empty;
                        if (linha != 0)
                        {
                            strCampoBase = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][(Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1) - 2];
                            strOperacao = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][(Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1) - 1];
                            objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase[linha][(Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1)];
                            for (int contador = 0; contador <= (Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1); contador += 1)
                            {
                                vetRegistrosColunas.Add(null);
                            }
                        }
                        else
                        {
                            for (int contador = 0; contador <= (Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1); contador += 1)
                            {
                                vetNomeColunas.Add(null);
                            }
                        }

                        for (int coluna = 0; coluna <= ((linha == 0) ? (Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1) : (Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1) - 3); coluna++)
                        {
                            if (linha != 0)
                            {
                                vetRegistrosColunas[coluna] = Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];

                                strTexto +=
                                    string.Format((coluna == (Campos_Dados_CampoBase_Operacao_DadoBase[linha].Count - 1) - 3) ?
                                    "{0} = {1}" :
                                    "{0} = {1}, ",
                                    vetNomeColunas[coluna],
                                    (object)vetRegistrosColunas[coluna]);
                            }
                            else
                            {
                                vetNomeColunas[coluna] = (string)Campos_Dados_CampoBase_Operacao_DadoBase[linha][coluna];
                            }
                        }
                        if (linha != 0)
                        {
                            saida &= mtdExecutarComando
                                (string.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, strTexto, strCampoBase, strOperacao, (object)objDadoBase));
                        }
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdAtualizarDados(string NomeTabela, object CampoDado, string CampoBase, string Operacao, object DadoBase)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando(string.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, CampoDado, CampoBase, Operacao, DadoBase));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdInserirDados(string NomeTabela, object[,] Campos_Dados)
        {
            bool saida = true;

            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
            {
                if (Campos_Dados != null)
                {
                    objResgistrosColunas = string.Empty;
                    for (int coluna = Campos_Dados.GetLowerBound(1); coluna <= Campos_Dados.GetUpperBound(1); coluna++)
                    {
                        if (linha == Campos_Dados.GetLowerBound(0))
                        {
                            strNomeColunas +=
                                string.Format((coluna != Campos_Dados.GetUpperBound(1)) ? "{0}, " : "{0}", Campos_Dados[linha, coluna]);
                        }
                        else
                        {
                            objResgistrosColunas +=
                                string.Format((coluna != Campos_Dados.GetUpperBound(1)) ? "{0}, " : "{0}", Campos_Dados[linha, coluna]);
                        }
                    }
                    if (linha != Campos_Dados.GetLowerBound(0))
                    {
                        saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdInserirDados(string NomeTabela, object[][] Campos_Dados)
        {
            bool saida = true;

            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            for (int linha = Campos_Dados.GetLowerBound(0); linha <= Campos_Dados.GetUpperBound(0); linha++)
            {
                if (Campos_Dados[linha] != null)
                {
                    objResgistrosColunas = string.Empty;
                    for (int coluna = Campos_Dados[linha].GetLowerBound(0); coluna <= Campos_Dados[linha].GetUpperBound(0); coluna++)
                    {
                        if (linha == Campos_Dados.GetLowerBound(0))
                        {
                            strNomeColunas +=
                                string.Format((coluna != Campos_Dados[linha].GetUpperBound(0)) ? "{0}, " : "{0}", Campos_Dados[linha][coluna]);
                        }
                        else
                        {
                            objResgistrosColunas +=
                                string.Format((coluna != Campos_Dados[linha].GetUpperBound(0)) ? "{0}, " : "{0}", Campos_Dados[linha][coluna]);
                        }
                    }
                    if (linha != Campos_Dados.GetLowerBound(0))
                    {
                        saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdInserirDados(string NomeTabela, List<List<object>> Campos_Dados)
        {
            bool saida = true;

            string strNomeColunas = string.Empty;
            object objResgistrosColunas = null;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            for (int linha = 0; linha <= (Campos_Dados.Count - 1); linha++)
            {
                if (Campos_Dados[linha] != null)
                {
                    objResgistrosColunas = string.Empty;
                    for (int coluna = 0; coluna <= (Campos_Dados[linha].Count - 1); coluna++)
                    {
                        if (linha == 0)
                        {
                            strNomeColunas +=
                                string.Format((coluna != (Campos_Dados[linha].Count - 1)) ? "{0}, " : "{0}", Campos_Dados[linha][coluna]);
                        }
                        else
                        {
                            objResgistrosColunas +=
                                string.Format((coluna != (Campos_Dados[linha].Count - 1)) ? "{0}, " : "{0}", Campos_Dados[linha][coluna]);
                        }
                    }
                    if (linha != Campos_Dados.Count)
                    {
                        saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas));
                    }
                }
            }
            mtdFecharConexao();

            return saida;
        }

        public bool mtdInserirDados(string NomeTabela, string Campos, object Dado)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando(string.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, Campos, Dado));
            mtdFecharConexao();

            return saida;
        }

        public bool mtdDeletarDados(string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando(string.Format("DELETE FROM {0} WHERE {1} {2} {3};", NomeTabela, CampoSelecionador, Operacao, Dado));
            mtdFecharConexao();

            return saida;
        }

        public string mtdVetorLinhaCampos(string[] Campos)
        {
            string strCampos = string.Empty;
            for (int contador = Campos.GetLowerBound(0); contador <= Campos.GetUpperBound(0); contador++)
            {
                strCampos += string.Format((!(contador == Campos.GetUpperBound(0))) ? "{0}, " : "{0}", Campos[contador]);
            }
            return strCampos;
        }

        public string mtdListaLinhaCampos(List<string> Campos)
        {
            string strCampos = string.Empty;
            for (int contador = 0; contador <= Campos.Count - 1; contador++)
            {
                strCampos += string.Format((!(contador == Campos.Count - 1)) ? "{0}, " : "{0}", Campos[contador]);
            }
            return strCampos;
        }

        public bool mtdSelecionarDados(string Campos, string NomeTabela)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando(string.Format("SELECT {0} FROM {1};", Campos, NomeTabela));

            return saida;
        }

        public bool mtdSelecionarDados(string[] Campos, string NomeTabela)
        {
            bool saida = true;

            saida &= mtdSelecionarDados(mtdVetorLinhaCampos(Campos), NomeTabela);

            return saida;
        }

        public bool mtdSelecionarDados(List<string> Campos, string NomeTabela)
        {
            bool saida = true;

            saida &= mtdSelecionarDados(mtdListaLinhaCampos(Campos), NomeTabela);

            return saida;
        }

        public bool mtdSelecionarDados(string Campos, string NomeTabela, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            if (Crescente)
            {
                saida &= mtdExecutarComando(string.Format("SELECT {0} FROM {1} ORDER BY {2};", Campos, NomeTabela, CampoOrdenador));
            }
            else
            {
                saida &= mtdExecutarComando(string.Format("SELECT {0} FROM {1} ORDER BY {2} DESC;", Campos, NomeTabela, CampoOrdenador));
            }

            return saida;
        }

        public bool mtdSelecionarDados(string[] Campos, string NomeTabela, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDados(mtdVetorLinhaCampos(Campos), NomeTabela, CampoOrdenador, Crescente);

            return saida;
        }

        public bool mtdSelecionarDados(List<string> Campos, string NomeTabela, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDados(mtdListaLinhaCampos(Campos), NomeTabela, CampoOrdenador, Crescente);

            return saida;
        }

        public bool mtdSelecionarDados(string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando(string.Format("SELECT {0} FROM {1} WHERE {2} {3} {4};", Campos, NomeTabela, CampoSelecionador, Operacao, Dado));

            return saida;
        }

        public bool mtdSelecionarDados(string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdSelecionarDados(mtdVetorLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, Dado);

            return saida;
        }

        public bool mtdSelecionarDados(List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdSelecionarDados(mtdListaLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, Dado);

            return saida;
        }

        public bool mtdSelecionarDados(string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0} FROM {1} WHERE {2} {3} {4} ORDER BY {5};",
                Campos,
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoOrdenador
                )
                );

            return saida;
        }

        public bool mtdSelecionarDados(string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDados(mtdVetorLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);

            return saida;
        }

        public bool mtdSelecionarDados(List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDados(mtdListaLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, Crescente);

            return saida;
        }

        public bool mtdSelecionarDados(bool Distinguir, bool DistinguirLinha, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoAgrupador)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0} {1} FROM {2} WHERE {3} {4} {5} GROUP BY {6};",
                Distinguir ? DistinguirLinha ? "DISTINCTROW" : "DISTINCT" : string.Empty,
                Campos,
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoAgrupador
                )
                );

            return saida;
        }

        public bool mtdSelecionarDados(bool Distinguir, bool DistinguirLinha, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoAgrupador)
        {
            bool saida = true;

            saida &= mtdSelecionarDados
                (
                Distinguir,
                DistinguirLinha,
                mtdVetorLinhaCampos(Campos),
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoAgrupador
                );

            return saida;
        }

        public bool mtdSelecionarDados(bool Distinguir, bool DistinguirLinha, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoAgrupador, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0} {1} FROM {2} WHERE {3} {4} {5} GROUP BY {6} ORDER BY {7}{8};",
                Distinguir ? DistinguirLinha ? "DISTINCTROW" : "DISTINCT" : string.Empty,
                Campos,
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoAgrupador,
                CampoOrdenador,
                Crescente ? string.Empty : " DESC"
                )
                );

            return saida;
        }

        public bool mtdSelecionarDados(bool Distinguir, bool DistinguirLinha, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoAgrupador, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDados
                (
                Distinguir,
                DistinguirLinha,
                mtdVetorLinhaCampos(Campos),
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoAgrupador,
                CampoOrdenador,
                Crescente
                );

            return saida;
        }

        public bool mtdSelecionarDados(bool Distinguir, bool DistinguirLinha, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoAgrupador, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDados
                (
                Distinguir,
                DistinguirLinha,
                mtdListaLinhaCampos(Campos),
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoAgrupador,
                CampoOrdenador,
                Crescente
                );

            return saida;
        }

        public bool mtdSelecionarDados(uint NumeroLinhas, string Campos, string NomeTabela)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0}{1} FROM {2};",
                NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                Campos,
                NomeTabela
                )
                );

            return saida;
        }

        public bool mtdSelecionarDados(uint NumeroLinhas, string[] Campos, string NomeTabela)
        {
            bool saida = true;

            saida &= mtdSelecionarDados
                (
                NumeroLinhas,
                mtdVetorLinhaCampos(Campos),
                NomeTabela
                );

            return saida;
        }

        public bool mtdSelecionarDados(uint NumeroLinhas, List<string> Campos, string NomeTabela)
        {
            bool saida = true;

            saida &= mtdSelecionarDados
                (
                NumeroLinhas,
                mtdListaLinhaCampos(Campos),
                NomeTabela
                );

            return saida;
        }

        public bool mtdSelecionarDados(uint NumeroLinhas, string Campos, string NomeTabela, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0}{1} FROM {2} ORDER BY {3}{4};",
                NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                Campos,
                NomeTabela,
                CampoOrdenador,
                Crescente ? string.Empty : " DESC"
                )
                );

            return saida;
        }

        public bool mtdSelecionarDados(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDados
                (
                NumeroLinhas,
                mtdVetorLinhaCampos(Campos),
                NomeTabela,
                CampoOrdenador,
                Crescente
                );

            return saida;
        }

        public bool mtdSelecionarDados(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDados
                (
                NumeroLinhas,
                mtdListaLinhaCampos(Campos),
                NomeTabela,
                CampoOrdenador,
                Crescente
                );

            return saida;
        }

        public bool mtdSelecionarDados(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0}{1} FROM {2} WHERE {3} {4} {5};",
                NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                Campos,
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado
                )
                );

            return saida;
        }

        public bool mtdSelecionarDados(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdSelecionarDados
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

        public bool mtdSelecionarDados(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado)
        {
            bool saida = true;

            saida &= mtdSelecionarDados
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

        public bool mtdSelecionarDados(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional);
            saida &= mtdExecutarComando
                (
                string.Format
                (
                "SELECT {0}{1} FROM {2} WHERE {3} {4} {5} ORDER BY {6}{7};",
                NumeroLinhas != 0 ? string.Format("TOP ({0}) ", NumeroLinhas) : string.Empty,
                Campos,
                NomeTabela,
                CampoSelecionador,
                Operacao,
                Dado,
                CampoOrdenador,
                Crescente ? string.Empty : " DESC"
                )
                );

            return saida;
        }

        public bool mtdSelecionarDados(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDados
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

        public bool mtdSelecionarDados(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente)
        {
            bool saida = true;

            saida &= mtdSelecionarDados
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

    public interface itfImplementacaoBancoDados
    {
        bool mtdAtualizarDadosParametroComando(string NomeTabela, object[,] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando);

        bool mtdAtualizarDadosParametroComando(string NomeTabela, object[][] Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando);

        bool mtdAtualizarDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados, string CampoBase, string Operacao, object DadoBase, enmModoParametroComando ModoParametroComando);

        bool mtdAtualizarDadosParametroComando(string NomeTabela, object[,] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando);

        bool mtdAtualizarDadosParametroComando(string NomeTabela, object[][] Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando);

        bool mtdAtualizarDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados_CampoBase_Operacao_DadoBase, enmModoParametroComando ModoParametroComando);

        bool mtdInserirDadosParametroComando(string NomeTabela, object[,] Campos_Dados, enmModoParametroComando ModoParametroComando);

        bool mtdInserirDadosParametroComando(string NomeTabela, object[][] Campos_Dados, enmModoParametroComando ModoParametroComando);

        bool mtdInserirDadosParametroComando(string NomeTabela, List<List<object>> Campos_Dados, enmModoParametroComando ModoParametroComando);

        bool mtdDeletarDadosParametroComando(string NomeTabela, string CampoSelecionador, string Operacao, object Dado);

        bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado);

        bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado);

        bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado);

        bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente);

        bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, string[] Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente);

        bool mtdSelecionarDadosParametroComando(uint NumeroLinhas, List<string> Campos, string NomeTabela, string CampoSelecionador, string Operacao, object Dado, string CampoOrdenador, bool Crescente);
    }
}