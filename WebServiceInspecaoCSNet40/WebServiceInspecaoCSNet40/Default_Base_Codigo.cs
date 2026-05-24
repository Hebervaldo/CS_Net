using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace WebServiceInspecaoCSNet40
{
    public partial class _Default
    {
        private string mtdConverterDataString(System.DateTime Data)
        {
            return mtdConverterDataString(Data, true);
        }

        private string mtdConverterDataString(System.DateTime Data, bool Hora)
        {
            string Retorno = string.Empty;

            if (Hora)
            {
                Retorno = string.Format
                    (
                        "{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}",
                        Data.Year,
                        Data.Month,
                        Data.Day,
                        Data.Hour,
                        Data.Minute,
                        Data.Second
                    );
            }
            else
            {
                Retorno = string.Format
                    (
                        "{0:0000}{1:00}{2:00}",
                        Data.Year,
                        Data.Month,
                        Data.Day
                    );
            }

            return Retorno;
        }

        private System.DateTime mtdConverterDataString(string Data)
        {
            return mtdConverterStringData(Data, true);
        }

        private System.DateTime mtdConverterStringData(string Data, bool Hora)
        {
            System.DateTime Retorno;

            if (Hora)
            {
                Retorno = new System.DateTime
                (
                    System.Convert.ToInt32(Data.Substring(0, 4)),
                    System.Convert.ToInt32(Data.Substring(4, 2)),
                    System.Convert.ToInt32(Data.Substring(6, 2)),
                    System.Convert.ToInt32(Data.Substring(8, 2)),
                    System.Convert.ToInt32(Data.Substring(10, 2)),
                    System.Convert.ToInt32(Data.Substring(12, 2))
                );
            }
            else
            {
                Retorno = new System.DateTime
                (
                    System.Convert.ToInt32(Data.Substring(0, 4)),
                    System.Convert.ToInt32(Data.Substring(4, 2)),
                    System.Convert.ToInt32(Data.Substring(6, 2))
                );
            }

            return Retorno;
        }

        public ulong mtdGerarProximoNumeroCodigo(string Tabela, string Campo)
        {
            int intNumeroControle = 0;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexaoMySQL, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            System.DateTime dtAtual = System.DateTime.Today;
            objImplementacaoBancoDados.mtdSelecionarDados
            (
                Campo,
                Tabela,
                Campo,
                false
            );

            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            ulong ulngNumeroCodigo = 0;
            ulong ulngMaximoNumeroCodigo = 0;
            if ((objImplementacaoBancoDados.mtdProximoRegistro()))
            {
                string strValorRegistro = objImplementacaoBancoDados.mtdObterValorRegistroDescricaoVetor(Campo).ToString();
                if (strValorRegistro != string.Empty)
                {
                    ulngMaximoNumeroCodigo = Convert.ToUInt64(strValorRegistro);
                    strValorRegistro = objImplementacaoBancoDados.mtdObterValorRegistroDescricaoVetor(Campo).ToString();
                    ulngMaximoNumeroCodigo = Convert.ToUInt64(strValorRegistro);

                    ulngNumeroCodigo = Convert.ToUInt64(ulngMaximoNumeroCodigo + 1);
                }
                else
                {
                    ulngNumeroCodigo = Convert.ToUInt64((intNumeroControle) + 1);
                }
            }
            else
            {
                ulngNumeroCodigo = Convert.ToUInt64((intNumeroControle) + 1);
            }

            objImplementacaoBancoDados.Dispose();

            return ulngNumeroCodigo;
        }

        public ulong mtdGerarProximoNumeroIdentificacao(string Tabela, string Campo)
        {
            int intNumeroControle = 1000000;

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexaoMySQL, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            System.DateTime dtAtual = System.DateTime.Today;
            objImplementacaoBancoDados.mtdSelecionarDados
            (
                Campo,
                Tabela,
                Campo,
                false
            );

            objImplementacaoBancoDados.mtdDefinirLeitorDados();
            ulong ulngNumeroIdentificacao = 0;
            ulong ulngMaximoNumeroIdentificacao = 0;
            if ((objImplementacaoBancoDados.mtdProximoRegistro()))
            {
                string strValorRegistro = objImplementacaoBancoDados.mtdObterValorRegistroDescricaoVetor(Campo).ToString();
                if (strValorRegistro != string.Empty)
                {
                    ulngMaximoNumeroIdentificacao = Convert.ToUInt64(strValorRegistro);
                    if
                    (
                        !(ulngMaximoNumeroIdentificacao > Convert.ToUInt64(dtAtual.Year * intNumeroControle)
                        &&
                        ulngMaximoNumeroIdentificacao < Convert.ToUInt64(dtAtual.AddYears(1).Year * intNumeroControle))
                    )
                    {
                        objImplementacaoBancoDados.mtdExecutarComando
                        (
                            string.Format
                            (
                                "SELECT {0} FROM {1} WHERE {0} > {2} AND {0} < {3} ORDER BY {0} DESC;",
                                Campo,
                                Tabela,
                                dtAtual.Year * intNumeroControle,
                                (dtAtual.Year + 1) * intNumeroControle
                            )
                        );
                        objImplementacaoBancoDados.mtdDefinirLeitorDados();
                        if
                        (
                            objImplementacaoBancoDados.mtdProximoRegistro()
                        )
                        {
                            strValorRegistro = objImplementacaoBancoDados.mtdObterValorRegistroDescricaoVetor(Campo).ToString();
                            ulngMaximoNumeroIdentificacao = Convert.ToUInt64(strValorRegistro);
                        }
                        else
                        {
                            ulngMaximoNumeroIdentificacao = Convert.ToUInt64(dtAtual.Year * intNumeroControle);
                        }
                    }
                    ulngNumeroIdentificacao = Convert.ToUInt64(ulngMaximoNumeroIdentificacao + 1);
                }
                else
                {
                    ulngNumeroIdentificacao = Convert.ToUInt64((dtAtual.Year * intNumeroControle) + 1);
                }
            }
            else
            {
                ulngNumeroIdentificacao = Convert.ToUInt64((dtAtual.Year * intNumeroControle) + 1);
            }

            objImplementacaoBancoDados.Dispose();

            return ulngNumeroIdentificacao;
        }

        private long mtdObterCodigoEspalhamento(string Dado)
        {
            long saida = 0;

            System.Security.Cryptography.HashAlgorithm algorithm = System.Security.Cryptography.SHA1.Create();
            Byte[] vetData = System.Text.Encoding.Unicode.GetBytes(Dado);
            Byte[] vetDataHash = algorithm.ComputeHash(vetData);
            saida = BitConverter.ToInt64(vetDataHash, 0);

            return saida;
        }

        public long mtdCalcularCodigoEspalhamento(List<object> Dados)
        {
            long saida = 0;

            for (int contador = 0; contador <= Dados.Count - 1; contador++)
            {
                saida = saida ^ mtdObterCodigoEspalhamento(Dados[contador].ToString());
            }

            return saida;
        }
    }
}