using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceInspecaoCSNet40
{
    public partial class _Default : System.Web.UI.Page
    {
        public _Default()
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);

            DiretorioArmazenamentoCompleto = System.Web.Hosting.HostingEnvironment.MapPath(string.Format(@"~/{0}/", DiretorioArmazenamento));
            // DiretorioArmazenamentoCompleto = @"C:\inetpub\wwwroot\WebServiceInspecao\";
            DiretorioArmazenamentoCompleto = string.Format(@"{0}\{1}\", DiretorioArmazenamentoCompleto, DiretorioArmazenamento).Replace(@"\\", @"\");

            System.IO.Directory.CreateDirectory(DiretorioArmazenamentoCompleto);

            mtdBaseDados_Load();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mtdBaseDados_Load();
            }
            else
            {
            }
        }

        protected void btnConsultarInspecao_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            dt = mtdSelecionarDados
            (
                lstColunasTabelaInspecao,
                strTabelaInspecao,
                ddlCampo1.SelectedValue.ToString() == string.Empty ? lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.HashCode] : ddlCampo1.SelectedValue.ToString(),
                ddlDado1.SelectedValue.ToString() == string.Empty ? "'%'" : string.Format("'{0}'", ddlDado1.SelectedValue.ToString()),
                ddlCampo2.SelectedValue.ToString() == string.Empty ? lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.HashCode] : ddlCampo2.SelectedValue.ToString(),
                ddlDado2.SelectedValue.ToString() == string.Empty ? "'%'" : string.Format("'{0}'", ddlDado2.SelectedValue.ToString()),
                ddlCampo3.SelectedValue.ToString() == string.Empty ? lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.HashCode] : ddlCampo3.SelectedValue.ToString(),
                ddlDado3.SelectedValue.ToString() == string.Empty ? "'%'" : string.Format("'{0}'", ddlDado3.SelectedValue.ToString()),
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Codigo],
                false
            );

            gdvInspecao.DataSource = dt;
            gdvInspecao.DataBind();
        }

        protected void btnCalcularEstatistica_Click(object sender, EventArgs e)
        {
            mtdCalcularEstatistica
            (
                ddlCampo1.SelectedValue.ToString() == string.Empty ? lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Endereco] : ddlCampo1.SelectedValue.ToString(),
                ddlCampo2.SelectedValue.ToString(),
                ddlCampo3.SelectedValue.ToString()
            );
        }

        public void mtdCalcularEstatistica(int opcao)
        {
            List<string> lstColunas = new List<string>
            { 
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Data],
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Endereco],
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Servico]
            };

            List<string> lstColunas_Adicional = new List<string> { };

            lstColunas_Adicional.AddRange(lstColunas);

            lstColunas_Adicional.Add(string.Format("AVG({0}) AS {1}_{0}", lstColunasTabelaInspecao[(int) _Default.enmColunasTabelaInspecao.Nota], "Media"));

            System.Data.DataTable dt = mtdObterDadosEstatisticos
            (
                strTabelaInspecao,
                lstColunas_Adicional,
                lstColunas,
                lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.Endereco],
                true
            );

            switch (opcao)
            {
                case 1:
                    mtdObterTabelaMedia(strTabelaEstatistica_01, ref dt, 2, "Media_Nota", "Media");
                    break;
                case 2:
                    mtdObterTabelaMedia(strTabelaEstatistica_01, ref dt, 2, "Media_Nota", "Media");
                    mtdObterTabelaMedia(strTabelaEstatistica_02, ref dt, 1, "Media_Media_Nota", "Media");
                    break;
            }

            try
            {
                gdvInspecao.DataSource = dt;
                gdvInspecao.DataBind();
            }
            catch (System.Exception ex)
            {
            }
        }

        public void mtdCalcularEstatistica(string Campo1, string Campo2, string Campo3)
        {
            List<string> lstColunas = new List<string> { };

            if (Campo1 != string.Empty)
            {
                lstColunas.Add(Campo1);
            }

            if (Campo2 != string.Empty)
            {
                lstColunas.Add(Campo2);
            }

            if (Campo3 != string.Empty)
            {
                lstColunas.Add(Campo3);
            }

            List<string> lstColunas_Adicional = new List<string> { };

            lstColunas_Adicional.AddRange(lstColunas);

            lstColunas_Adicional.Add(string.Format("AVG({0}) AS {1}_{0}", lstColunasTabelaInspecao[10], "Media"));

            System.Data.DataTable dt = mtdObterDadosEstatisticos
            (
                strTabelaInspecao,
                lstColunas_Adicional,
                lstColunas,
                lstColunas[0],
                true
            );

            int opcao = lstColunas.Count - 1;

            switch (opcao)
            {
                case 1:
                    mtdObterTabelaMedia(strTabelaEstatistica_01, ref dt, 2, "Media_Nota", "Media");
                    break;
                case 2:
                    mtdObterTabelaMedia(strTabelaEstatistica_01, ref dt, 2, "Media_Nota", "Media");
                    mtdObterTabelaMedia(strTabelaEstatistica_02, ref dt, 1, "Media_Media_Nota", "Media");
                    break;
            }

            gdvInspecao.DataSource = dt;
            gdvInspecao.DataBind();
        }

        private List<List<object>> tblDadosEstatisticos = new List<List<object>> { };

        private System.Data.DataTable mtdObterDadosEstatisticos(string Tabela, List<string> ListaColuna, List<string> ListaGrupoColuna, string ColunaOrdenadora, bool Crescente)
        {
            System.Data.DataTable Retorno = new System.Data.DataTable { };

            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexaoMySQL, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            objImplementacaoBancoDados.mtdAbrirConexao();
            objImplementacaoBancoDados.mtdExecutarComando
            (
                string.Format
                (
                    "SELECT DISTINCT {0} FROM {1} GROUP BY {2} ORDER BY {3}{4}",
                    objImplementacaoBancoDados.mtdListaLinhaCampos(ListaColuna),
                    Tabela,
                    objImplementacaoBancoDados.mtdListaLinhaCampos(ListaGrupoColuna),
                    ColunaOrdenadora,
                    Crescente ? string.Empty : " DESC"
                )
            );

            objImplementacaoBancoDados.mtdAdaptadorDados();

            Retorno = objImplementacaoBancoDados.prpAjustadorDados.Tables[0];

            objImplementacaoBancoDados.Dispose();

            return Retorno;
        }

        private void mtdPreehcerDadosTabelaEstatistica(string Tabela, System.Data.DataTable Dt, string ColunaSelecionadora, string DadoSelecionador, List<object> ListaColunas)
        {
            clsImplementacaoBancoDados objImplementacaoBancoDados = new clsImplementacaoBancoDados(strConexaoMySQL, clsInfraestruturaBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.MySQL);

            mtdDeletarDadosTabelaEstatistica(Tabela, ColunaSelecionadora, DadoSelecionador);
            mtdDeletarTabelaEstatistica(Tabela);

            List<List<object>> Dados = new List<List<object>> { };

            Dados.Add(ListaColunas);

            for (int linha = 0; linha <= Dt.Rows.Count - 1; linha++)
            {
                Dados.Add(new List<object> { });

                for (int coluna = 0; coluna <= Dt.Columns.Count - 1; coluna++)
                {
                    Dados[linha + 1].Add(Dt.Rows[linha].ItemArray[coluna]);
                }
            }

            objImplementacaoBancoDados.mtdInserirDadosParametroComandoMySQL(Tabela, Dados, enmModoParametroComando.Valor);
            objImplementacaoBancoDados.Dispose();
        }

        private void mtdPrepararTabelaEstatisticaMedia(string Tabela, List<string> NomesColunas, List<string> TiposColunas, System.Data.DataTable Dt, string ColunaSelecionadora)
        {
            System.Data.DataTable Retorno = new System.Data.DataTable();

            mtdCriarTabelaEstatistica(Tabela, NomesColunas, TiposColunas);

            lstColunasTabelaEstatisticaObject.Clear();
            lstColunasTabelaEstatisticaObject = new List<object>() { };
            lstColunasTabelaEstatisticaObject.AddRange(mtdGerarListaColunasTabelaEstatistica(NomesColunas));

            mtdPreehcerDadosTabelaEstatistica(Tabela, Dt, ColunaSelecionadora, "%", lstColunasTabelaEstatisticaObject);
        }

        private void mtdCalcularMediaTabelaEstatisticaMedia(string Tabela, List<string> NomesColunas, ref System.Data.DataTable Dt, string MediaColuna, string AcrescentarColuna)
        {
            List<string> NomesColunas_Adicional = new List<string> { };
            NomesColunas_Adicional.Clear();
            NomesColunas_Adicional = new List<string> { };

            NomesColunas_Adicional.AddRange(NomesColunas);
            NomesColunas_Adicional.Add(string.Format("AVG({0}) AS {1}_{0}", MediaColuna, AcrescentarColuna));

            Dt = mtdObterDadosEstatisticos
            (
                Tabela,
                NomesColunas_Adicional,
                NomesColunas,
                NomesColunas[0],
                true
            );
        }

        private void mtdObterListaNomesTiposColunas(ref List<string> ListaNomesColunas, ref List<string> ListaTiposColunas, ref System.Data.DataTable Dt)
        {
            ListaNomesColunas.Clear();
            ListaTiposColunas.Clear();

            for (int coluna = 0; coluna <= Dt.Columns.Count - 1; coluna++)
            {
                ListaNomesColunas.Add(Dt.Columns[coluna].ColumnName);

                switch (Dt.Columns[coluna].DataType.FullName)
                {
                    case "System.String":
                        ListaTiposColunas.Add("NVARCHAR");
                        break;
                    case "System.Double":
                        ListaTiposColunas.Add("FLOAT");
                        break;
                }
            }
        }

        private void mtdObterTabelaMedia(string NomeTabela, ref System.Data.DataTable Dt, int NumeroColunas, string MediaColuna, string AcrescentarColuna)
        {
            List<string> lstColunas = new List<string> { };

            List<string> ListaNomesCampos = new List<string> { };
            List<string> ListaTiposCampos = new List<string> { };

            mtdObterListaNomesTiposColunas(ref ListaNomesCampos, ref ListaTiposCampos, ref Dt);

            lstColunas.Clear();
            lstColunas.AddRange(ListaNomesCampos);

            mtdPrepararTabelaEstatisticaMedia(NomeTabela, lstColunas, ListaTiposCampos, Dt, lstColunas[0]);

            lstColunas.Clear();
            for (int contador = 0; contador <= NumeroColunas - 1; contador++)
            {
                lstColunas.Add(ListaNomesCampos[contador]);
            }

            mtdCalcularMediaTabelaEstatisticaMedia(NomeTabela, lstColunas, ref  Dt, MediaColuna, AcrescentarColuna);
        }

        protected void btnCalcularDataIdentificacaoServicoEstatistica_Click(object sender, EventArgs e)
        {
            mtdCalcularEstatistica(0);
        }

        protected void btnCalcularIdentificacaoEstatistica_Click(object sender, EventArgs e)
        {
            mtdCalcularEstatistica(1);
        }

        protected void btnCalcularDataEstatistica_Click(object sender, EventArgs e)
        {
            mtdCalcularEstatistica(2);
        }

        private void mtdPreencherDdlCampos(ref System.Web.UI.WebControls.DropDownList Ddl)
        {
            if (Ddl.Items.Count == 0)
            {
                List<string> lst = lstColunasTabelaInspecao;

                Ddl.Items.Clear();
                Ddl.Items.Add(string.Empty);

                for (int contador = 0; contador <= lst.Count - 1; contador++)
                {
                    Ddl.Items.Add(lst[contador]);
                }

                Ddl.SelectedIndex = 0;
            }
        }

        private void mtdPreencherDdlDados(ref System.Web.UI.WebControls.DropDownList Ddl, string ColunaSelecionada, string ColunaSelecionadora, string DadoSelecionador)
        {
            //if (Ddl.Items.Count == 0)
            {
                List<string> lst = new List<string> { };

                lst = mtdSelecionarDados
                (
                    ColunaSelecionada,
                    strTabelaInspecao,
                    ColunaSelecionadora,
                    "LIKE",
                    DadoSelecionador,
                    ColunaSelecionada,
                    ColunaSelecionada,
                    true
                );

                Ddl.Items.Clear();
                Ddl.Items.Add(string.Empty);

                for (int contador = 0; contador <= lst.Count - 1; contador++)
                {
                    Ddl.Items.Add(lst[contador]);
                }

                Ddl.SelectedIndex = 0;
            }
        }

        protected void ddlCampo1_Load(object sender, EventArgs e)
        {
            mtdPreencherDdlCampos(ref ddlCampo1);
        }

        protected void ddlDado1_PreRender(object sender, EventArgs e)
        {
            mtdPreencherDdlDados
            (
                ref ddlDado1,
                ddlCampo1.SelectedValue.ToString(),
                ddlCampo1.SelectedValue.ToString(),
                "'%'"
            );
        }

        protected void ddlCampo2_Load(object sender, EventArgs e)
        {
            mtdPreencherDdlCampos(ref ddlCampo2);
        }

        protected void ddlDado2_PreRender(object sender, EventArgs e)
        {
            mtdPreencherDdlDados
            (
                ref ddlDado2,
                ddlCampo2.SelectedValue.ToString(),
                ddlCampo2.SelectedValue.ToString(),
                "'%'"
            );
        }

        protected void ddlCampo3_Load(object sender, EventArgs e)
        {
            mtdPreencherDdlCampos(ref ddlCampo3);
        }

        protected void ddlDado3_PreRender(object sender, EventArgs e)
        {
            mtdPreencherDdlDados
            (
                ref ddlDado3,
                ddlCampo3.SelectedValue.ToString(),
                ddlCampo3.SelectedValue.ToString(),
                "'%'"
            );
        }

        protected void ddlCampo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            upp1.Update();
        }

        protected void ddlCampo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            upp1.Update();
        }

        protected void ddlCampo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            upp1.Update();
        }

        protected void btnDeletarInspecao_Click(object sender, EventArgs e)
        {
            if (chkAutorizarDelete.Checked)
            {
                mtdDeletarDadosTabelaInspecao(lstColunasTabelaInspecao[(int)enmColunasTabelaInspecao.HashCode], "%");
            }

            chkAutorizarDelete.Checked = false;

            btnConsultarInspecao_Click(sender, e);
        }
    }
}