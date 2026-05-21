<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmImportacaoExportacaoDados.aspx.cs"
    Inherits="WebServiceCSNet40.frmImportacaoExportacaoDados" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Eletrobras Eletronorte - Importação e Exportação</title>

    <style type="text/css">
        body
        {
            margin: 0;
            padding: 0;
            background-color: #f4f7fb;
            font-family: Segoe UI, Arial, Helvetica, sans-serif;
            color: #333333;
        }

        .topo
        {
            background-color: #0b3d91;
            color: white;
            padding: 15px 30px;
            text-align: right;
            font-size: 13px;
        }

        .topo a
        {
            color: #ffffff;
            text-decoration: none;
            font-weight: bold;
        }

        .topo a:hover
        {
            text-decoration: underline;
        }

        .header
        {
            background-color: white;
            padding: 30px 20px 20px 20px;
            text-align: center;
            border-bottom: 1px solid #dcdcdc;
        }

        .titulo
        {
            font-size: 34px;
            font-weight: bold;
            color: #0b3d91;
            margin-bottom: 5px;
        }

        .subtitulo
        {
            font-size: 20px;
            color: #666666;
            font-weight: bold;
        }

        .container
        {
            width: 95%;
            max-width: 1600px;
            margin: 25px auto;
        }

        .layout
        {
            width: 100%;
            border-collapse: collapse;
        }

        .menuLateral
        {
            width: 240px;
            vertical-align: top;
            padding-right: 20px;
        }

        .conteudo
        {
            vertical-align: top;
        }

        .card
        {
            background-color: white;
            padding: 20px;
            margin-bottom: 20px;
            border: 1px solid #dfe5ec;
        }

        .cardTitulo
        {
            font-size: 18px;
            font-weight: bold;
            color: #0b3d91;
            margin-bottom: 18px;
            border-bottom: 1px solid #eeeeee;
            padding-bottom: 10px;
        }

        .grupo
        {
            margin-bottom: 30px;
            padding-bottom: 20px;
            border-bottom: 1px solid #eeeeee;
        }

        .grupo:last-child
        {
            border-bottom: none;
        }

        .grupoTitulo
        {
            font-size: 17px;
            color: #1f5fa8;
            font-weight: bold;
            margin-bottom: 15px;
        }

        .subGrupo
        {
            font-size: 14px;
            color: #555555;
            font-weight: bold;
            margin-bottom: 12px;
            margin-top: 15px;
        }

        .campo
        {
            margin-bottom: 15px;
        }

        .campo label
        {
            display: block;
            margin-bottom: 5px;
            font-size: 13px;
            font-weight: bold;
            color: #555555;
        }

        .textbox
        {
            width: 250px;
            padding: 8px;
            border: 1px solid #c7d2e2;
            font-size: 13px;
        }

        .dropdown
        {
            width: 260px;
            padding: 8px;
            border: 1px solid #c7d2e2;
            font-size: 13px;
        }

        .btn
        {
            background-color: #0b3d91;
            color: white;
            border: none;
            padding: 9px 20px;
            font-size: 13px;
            font-weight: bold;
            cursor: pointer;
            min-width: 150px;
        }

        .btn:hover
        {
            background-color: #1455c0;
        }

        .menuBox
        {
            background-color: white;
            border: 1px solid #dfe5ec;
            padding: 15px;
        }

        #resultDiv
        {
            border: 1px solid #d6d6d6 !important;
            background-color: #fafafa;
            min-height: 50px;
            padding: 10px;
        }

        .infoLabel
        {
            color: #0b3d91;
            font-weight: bold;
            font-size: 14px;
        }

        .secaoEspaco
        {
            margin-top: 15px;
        }
    </style>
</head>

<body>

    <form id="frmImportacaoExportacaoDados" runat="server">

        <div class="topo">

            <asp:HyperLink ID="hlkPerfil" runat="server">[hlkPerfil]</asp:HyperLink>

            &nbsp;&nbsp;|&nbsp;&nbsp;

            <asp:Label ID="lblUsuario" runat="server"></asp:Label>

            &nbsp;&nbsp;|&nbsp;&nbsp;

            <asp:Label ID="lblSaudacao" runat="server"></asp:Label>

            &nbsp;&nbsp;|&nbsp;&nbsp;

            <asp:HyperLink ID="hlkLogout" runat="server"
                NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>

            &nbsp;&nbsp;|&nbsp;&nbsp;

            <asp:HyperLink ID="hlkSobre" runat="server"
                NavigateUrl="~/Todos/sobre.aspx">Sobre</asp:HyperLink>

        </div>

        <div class="header">

            <div class="titulo">
                ELETROBRAS ELETRONORTE
            </div>

            <div class="subtitulo">
                WEB SERVICE - IMPORTAÇÃO E EXPORTAÇÃO
            </div>

        </div>

        <div class="container">

            <table class="layout">

                <tr>

                    <td class="menuLateral">

                        <div class="menuBox">

                            <div class="cardTitulo">
                                Navegação
                            </div>

                            <div class="campo">

                                <label>Banco de Dados</label>

                                <asp:DropDownList ID="dplSelecionarBancoDados"
                                    runat="server"
                                    CssClass="dropdown">
                                </asp:DropDownList>

                            </div>

                            <br />

                            <asp:Menu ID="mnu1"
                                runat="server"
                                BackColor="Transparent"
                                DynamicHorizontalOffset="2"
                                Font-Names="Segoe UI"
                                Font-Size="14px"
                                ForeColor="#444444"
                                StaticSubMenuIndent="10px"
                                OnMenuItemClick="mnu1_MenuItemClick"
                                Width="100%">

                                <DynamicHoverStyle BackColor="#1455c0" ForeColor="White" />
                                <DynamicMenuItemStyle HorizontalPadding="8px" VerticalPadding="8px" />
                                <DynamicMenuStyle BackColor="White" />
                                <DynamicSelectedStyle BackColor="#0b3d91" />

                                <Items>
                                    <asp:MenuItem Text="Voltar" Value="smnVoltar"></asp:MenuItem>
                                </Items>

                                <StaticHoverStyle BackColor="#1455c0" ForeColor="White" />
                                <StaticMenuItemStyle HorizontalPadding="8px" VerticalPadding="8px" />
                                <StaticSelectedStyle BackColor="#0b3d91" />

                            </asp:Menu>

                            <br />

                            <asp:Label ID="lblInformacao"
                                runat="server"
                                CssClass="infoLabel">
                            </asp:Label>

                        </div>

                    </td>

                    <td class="conteudo">

                        <div class="card">

                            <div class="cardTitulo">
                                Monitor de Processos
                            </div>

                            <div id="resultDiv">
                                &nbsp;
                            </div>

                            <asp:ScriptManager ID="scmg1"
                                runat="server"
                                EnablePageMethods="true"
                                LoadScriptsBeforeUI="true"
                                ScriptMode="Release">

                                <Scripts>
                                    <asp:ScriptReference Path="~/Scripts/Main.js" />
                                </Scripts>

                            </asp:ScriptManager>

                            <div class="secaoEspaco">

                                <asp:Label ID="lblAviso"
                                    runat="server"
                                    CssClass="infoLabel">
                                </asp:Label>

                            </div>

                        </div>

                        <div class="card">

                            <div class="grupo">

                                <div class="grupoTitulo">
                                    Preparação de Ambiente
                                </div>

                                <div class="subGrupo">
                                    Preparação Principal
                                </div>

                                <asp:Button ID="btnIniciarPreparacaoPrincipal"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Iniciar"
                                    OnClick="btnIniciarPreparacaoPrincipal_Click"
                                    OnClientClick="mtdExecutarProgressBar('Preparação Banco Dados Principal')" />

                                &nbsp;

                                <asp:Button ID="btnPararPreparacaoPrincipal"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Parar"
                                    OnClick="btnPararPreparacaoPrincipal_Click"
                                    OnClientClick="mtdExecutarProgressBar('Preparação Banco Dados Principal')" />

                                <div class="subGrupo">
                                    Preparação Coletor de Dados
                                </div>

                                <asp:Button ID="btnIniciarPreparacaoColetorDados"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Iniciar"
                                    OnClick="btnIniciarPreparacaoColetorDados_Click"
                                    OnClientClick="mtdExecutarProgressBar('Preparação Coletor de Dados')" />

                                &nbsp;

                                <asp:Button ID="btnPararPreparacaoColetorDados"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Parar"
                                    OnClick="btnPararPreparacaoColetorDados_Click"
                                    OnClientClick="mtdExecutarProgressBar('Preparação Coletor de Dados')" />

                            </div>

                            <div class="grupo">

                                <div class="grupoTitulo">
                                    Controle de Processos
                                </div>

                                <asp:Button ID="btnExibirBarraProgresso"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Barra de Progresso"
                                    OnClientClick="mtdExecutarProgressBar('Barra de Progresso')" />

                                &nbsp;

                                <asp:Button ID="btnForcarAbortoTodosProcessos"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Abortar Tudo"
                                    OnClientClick="mtdExecutarProgressBar('Barra de Progresso')"
                                    OnClick="btnForcarAbortoTodosProcessos_Click" />

                                <br /><br />

                                <asp:Button ID="btnFazerDownloadArquivos"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Download Arquivos"
                                    OnClick="btnFazerDownloadArquivos_Click" />

                            </div>

                            <div class="grupo">

                                <div class="grupoTitulo">
                                    Importação de Dados
                                </div>

                                <div class="subGrupo">
                                    Bens - Centro de Custo
                                </div>

                                <asp:Button ID="btnIniciarImportacaoDadosBens"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Iniciar"
                                    OnClick="btnIniciarImportacaoDadosBens_Click"
                                    OnClientClick="mtdExecutarProgressBar('Importação de dados - Bens - Centro de Custo')" />

                                &nbsp;

                                <asp:Button ID="btnPararImportacaoDadosBens"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Parar"
                                    OnClick="btnPararImportacaoDadosBens_Click"
                                    OnClientClick="mtdExecutarProgressBar('Importação de dados - Bens - Centro de Custo')" />

                                <div class="subGrupo">
                                    Empregados
                                </div>

                                <asp:Button ID="btnIniciarImportacaoDadosEmpregados"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Iniciar"
                                    OnClick="btnIniciarImportacaoDadosEmpregados_Click"
                                    OnClientClick="mtdExecutarProgressBar('Importação de dados - Empregados')" />

                                &nbsp;

                                <asp:Button ID="btnPararImportacaoDadosEmpregados"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Parar"
                                    OnClick="btnPararImportacaoDadosEmpregados_Click"
                                    OnClientClick="mtdExecutarProgressBar('Importação de dados - Empregados')" />

                                <div class="subGrupo">
                                    Centro de Custo
                                </div>

                                <asp:Button ID="btnIniciarImportacaoDadosCentroCusto"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Iniciar"
                                    OnClick="btnIniciarImportacaoDadosCentroCusto_Click"
                                    OnClientClick="mtdExecutarProgressBar('Importação de dados - Centro de Custo')" />

                                &nbsp;

                                <asp:Button ID="btnPararImportacaoDadosCentroCusto"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Parar"
                                    OnClick="btnPararImportacaoDadosCentroCusto_Click"
                                    OnClientClick="mtdExecutarProgressBar('Importação de dados - Centro de Custo')" />

                            </div>

                            <div class="grupo">

                                <div class="grupoTitulo">
                                    Exportação de Dados
                                </div>

                                <div class="subGrupo">
                                    Inventário de Bens - Excel
                                </div>

                                <asp:Button ID="btnIniciarExportacaoDadosInventarioBensExcel"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Iniciar"
                                    OnClick="btnIniciarExportacaoDadosInventarioBensExcel_Click"
                                    OnClientClick="mtdExecutarProgressBar('Exportação de Dados - Inventário de Bens - Excel')" />

                                &nbsp;

                                <asp:Button ID="btnPararExportacaoDadosInventarioBensExcel"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Parar"
                                    OnClick="btnPararExportacaoDadosInventarioBensExcel_Click"
                                    OnClientClick="mtdExecutarProgressBar('Exportação de Dados - Inventário de Bens - Excel')" />

                                <br /><br />

                                <asp:DropDownList ID="dplConsultarCampoExportacaoDadosInventarioBensExcel"
                                    runat="server"
                                    CssClass="dropdown">
                                </asp:DropDownList>

                            </div>

                            <div class="grupo">

                                <div class="grupoTitulo">
                                    Transferência de Dados
                                </div>

                                <div class="subGrupo">
                                    Inventário de Bens
                                </div>

                                <asp:RadioButton ID="rdbPermitirDeletarTabelaInventarioBens"
                                    runat="server"
                                    Text="Deletar Tabela" />

                                <br /><br />

                                <asp:Button ID="btnIniciarTransferenciaDadosInventarioBens"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Iniciar"
                                    OnClick="btnIniciarTransferenciaDadosInventarioBens_Click"
                                    OnClientClick="mtdExecutarProgressBar('Transferência de dados - Inventário de Bens')" />

                                &nbsp;

                                <asp:Button ID="btnPararTransferenciaDadosInventarioBens"
                                    runat="server"
                                    CssClass="btn"
                                    Text="Parar"
                                    OnClick="btnPararTransferenciaDadosInventarioBens_Click"
                                    OnClientClick="mtdExecutarProgressBar('Transferência de dados - Inventário de Bens')" />

                            </div>

                        </div>

                    </td>

                </tr>

            </table>

        </div>

        <script type="text/javascript">

            function mtdExecutarProgressBar(NomeProcesso) {
                mainScreen.ExecuteCommand(
                    'LaunchNewProcess',
                    'mHandlers.Void',
                    NomeProcesso);
            }

        </script>

        <script type="text/javascript">

            Sys.Application.add_load(
            applicationLoadHandler
            );

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(
            endRequestHandler
            );

            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(
            beginRequestHandler
            );

            var mHandlers = {};

            mHandlers.Void = function (obj) {
                ;
            };

            mHandlers.GetStatuses = function () {

                mainScreen.ExecuteCommand(
                'GetProcessStatuses',
                'mHandlers.ProcessStatuses',
                null);

                setTimeout(
                "mHandlers.GetStatuses();",
                parseInt(500)
                );
            };

            mHandlers.ProcessStatuses = function (obj) {

                var resultDiv = $get("resultDiv");

                if (obj) {
                    resultDiv.innerHTML =
                    mHandlers.BuildProcessList(obj);
                }
                else {
                    resultDiv.innerHTML = "&nbsp;";
                }
            };

            mHandlers.BuildProcessList = function (obj) {

                var i = 0;

                if (obj.length == 0)
                    return "&nbsp;";

                var result = "<table cellspacing='0' cellpadding='5' width='100%'>";

                result += "<tr>";

                result += "<td><b>Nome do Processo</b></td>";
                result += "<td width='70%'><b>Progresso</b></td>";
                result += "<td><b>Porcentagem</b></td>";

                result += "</tr>";

                for (i = 0; i < obj.length; i++) {

                    result += "<tr>";

                    result += "<td>" + obj[i].Name + "</td>";

                    result += "<td>" +
                        "<div style='width:100%; background-color:#e6e6e6; border-radius:4px;'>" +
                        "<div style='width:" + obj[i].Status + "%;" +
                        "background-color:" +
                        (obj[i].Status < 100 ? "#1455c0" : "#28a745") +
                        "; height:18px; border-radius:4px;'></div></div></td>";

                    result += "<td>" + obj[i].Status + " %</td>";

                    result += "</tr>";
                }

                result += "</table>";

                return result;
            };

        </script>

    </form>

</body>
</html>