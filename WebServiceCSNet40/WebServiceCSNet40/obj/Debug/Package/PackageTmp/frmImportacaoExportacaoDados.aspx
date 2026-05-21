<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmImportacaoExportacaoDados.aspx.cs"
    Inherits="WebServiceCSNet40.frmImportacaoExportacaoDados" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eletrobras Eletronorte - Web Service</title>
    <style type="text/css">
        .style3
        {
            color: #0000CC;
            font-family: "Times New Roman" , Times, serif;
            font-size: small;
            text-align: right;
            width: 815px;
            margin-bottom: 6px;
        }
        .style4
        {
            font-family: "Times New Roman" , Times, serif;
            font-size: x-large;
            color: #400000;
            text-align: center;
            width: 1114px;
        }
        #txp1
        {
            width: 323px;
            margin-left: 0px;
        }
        #txp2
        {
            width: 323px;
            margin-left: 0px;
        }
        .style11
        {
            color: #0066CC;
            font-family: "Times New Roman" , Times, serif;
            font-size: xx-large;
            text-align: center;
            width: 1114px;
        }
        .style14
        {
            color: #3366CC;
            font-family: "Times New Roman" , Times, serif;
            font-size: medium;
            text-align: center;
        }
        .style15
        {
            color: #33CC33;
            font-family: "Times New Roman" , Times, serif;
            font-size: medium;
            text-align: center;
        }
        .style16
        {
            color: #0000CC;
            font-family: "Times New Roman" , Times, serif;
            font-size: small;
            text-align: center;
        }
        .style20
        {
            color: #666666;
        }
        .style21
        {
            color: #000000;
            font-weight: bold;
        }
        .style22
        {
            color: #0000CC;
            font-weight: bold;
        }
        .style23
        {
            color: #0066FF;
            font-weight: bold;
        }
        .style24
        {
            width: 200px;
        }
    </style>
</head>
<body style="text-align: center; height: 1265px; margin-bottom: 4px;">
    <form id="frmImportacaoExportacaoDados" runat="server">
    <p class="style3" style="width: 100%">
        <asp:HyperLink ID="hlkPerfil" runat="server" Style="font-size: small; font-family: 'Times New Roman';"
            CssClass="style23">[hlkPerfil]</asp:HyperLink>
        <span class="style21">&nbsp;- </span>
        <asp:Label ID="lblUsuario" runat="server" Style="font-family: 'Times New Roman';"
            CssClass="style23"></asp:Label>
        <span class="style21">&nbsp;- </span><b>
            <asp:Label ID="lblSaudacao" runat="server" CssClass="style20"></asp:Label>
        </b><span class="style21">&nbsp;-&nbsp;</span><asp:HyperLink ID="hlkLogout" runat="server"
            NavigateUrl="~/logout.aspx" CssClass="style22">Logout</asp:HyperLink>
        <span class="style21">&nbsp;- </span>
        <asp:HyperLink ID="hlkSobre" runat="server" NavigateUrl="~/Todos/sobre.aspx" CssClass="style22">Sobre</asp:HyperLink>
    </p>
    <hr style="height: 0px; margin-top: 0px; margin-bottom: 0px; width: 100%;" />
    <p class="style11" style="width: 100%;">
        <strong>ELETROBRAS ELETRONORTE</strong></p>
    <p class="style4" style="width: 100%;">
        <table width="100%" style="height: 921px">
            <tr>
                <td class="style24">
                    <asp:DropDownList ID="dplSelecionarBancoDados" runat="server" Width="150px">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Menu ID="mnu1" runat="server" BackColor="#E3EAEB" DynamicHorizontalOffset="2"
                        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666" StaticSubMenuIndent="10px"
                        OnMenuItemClick="mnu1_MenuItemClick" Width="100%" Style="text-align: center;
                        font-size: medium; font-weight: 700;">
                        <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicMenuStyle BackColor="#E3EAEB" />
                        <DynamicSelectedStyle BackColor="#1C5E55" />
                        <Items>
                            <asp:MenuItem Text="Voltar" Value="smnVoltar"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticSelectedStyle BackColor="#1C5E55" />
                    </asp:Menu>
                    <asp:Label ID="lblInformacao" runat="server" Style="font-size: medium; color: #0066CC;"></asp:Label>
                    <br />
                </td>
                <td class="style14">
                    <span class="style15">
                        <div id="resultDiv" style="border: dashed 1px black;">
                            &nbsp;
                        </div>
                        <asp:ScriptManager ID="scmg1" runat="server" EnablePageMethods="true" 
                        LoadScriptsBeforeUI="true" ScriptMode="Release">
                            <Scripts>
                                <asp:ScriptReference Path="~/Scripts/Main.js" />
                            </Scripts>
                    </asp:ScriptManager>
                        <br />
                    <asp:Label ID="lblAviso" runat="server" Style="font-family: 'Times New Roman', Times, serif; color: #0000CC;
                        font-size: medium;"></asp:Label>
                    <br />
                    <br />
                    Preparação Principal<br />
                    <br />
                    <asp:Button ID="btnIniciarPreparacaoPrincipal" runat="server" BackColor="White"
                        ForeColor="#333333" Height="25px" Text="Iniciar" Width="150px" OnClick="btnIniciarPreparacaoPrincipal_Click"
                        OnClientClick="mtdExecutarProgressBar('Preparação Banco Dados Principal')" 
                        Font-Bold="True" />
                    <br />
                    <br />
                    <asp:Button ID="btnPararPreparacaoPrincipal" runat="server" BackColor="White"
                        ForeColor="#333333" Height="25px" Text="Parar" Width="150px" OnClick="btnPararPreparacaoPrincipal_Click"
                        OnClientClick="mtdExecutarProgressBar('Preparação Banco Dados Principal')" 
                        Font-Bold="True" />
                    <br />
                        <br />
                        Preparação Coletor de Dados</span>
                    <br />
                    <br />
                    <asp:Button ID="btnIniciarPreparacaoColetorDados" runat="server" BackColor="White"
                        ForeColor="#333333" Height="25px" Text="Iniciar" Width="150px" OnClick="btnIniciarPreparacaoColetorDados_Click"
                        OnClientClick="mtdExecutarProgressBar('Preparação Coletor de Dados')" 
                        Font-Bold="True" />
                    <br />
                    <br />
                    <asp:Button ID="btnPararPreparacaoColetorDados" runat="server" BackColor="White"
                        ForeColor="#333333" Height="25px" Text="Parar" Width="150px" OnClick="btnPararPreparacaoColetorDados_Click"
                        OnClientClick="mtdExecutarProgressBar('Preparação Coletor de Dados')" 
                        Font-Bold="True" />
                    <br />
                    <br />
                    <span class="style16">Exibir Barra de Progresso</span>
                    <br />
                    <br />
                    <asp:Button ID="btnExibirBarraProgresso" runat="server" BackColor="White" ForeColor="#333333"
                        Height="25px" Text="Barra de Progresso" Width="150px" OnClientClick="mtdExecutarProgressBar('Barra de Progresso')"
                        Font-Bold="True" />
                    <br />
                    <br />
                    <span class="style16">Forçar Aborto de Todos os Processos</span>
                    <br />
                    <br />
                    <asp:Button ID="btnForcarAbortoTodosProcessos" runat="server" BackColor="White" ForeColor="#333333"
                        Height="25px" Text="Abortar" Width="150px" OnClientClick="mtdExecutarProgressBar('Barra de Progresso')"
                        Font-Bold="True" OnClick="btnForcarAbortoTodosProcessos_Click" />
                    <br />
                    <br />
                    <span class="style16">Fazer Download dos Arquivos</span>
                    <br />
                    <br />
                    <asp:Button ID="btnFazerDownloadArquivos" runat="server" BackColor="White" ForeColor="#333333"
                        Height="25px" Text="Download" Width="150px" Font-Bold="True" 
                        OnClick="btnFazerDownloadArquivos_Click" />
                    <br />
                    <br />
                    <span class="style15">Importação de dados</span><br />
                    <br />
                    <span class="style16">Bens - Centro Custo</span><br />
                    <br />
                    <asp:Button ID="btnIniciarImportacaoDadosBens" runat="server" BackColor="White" ForeColor="#333333"
                        Height="25px" Text="Iniciar" Width="150px" OnClick="btnIniciarImportacaoDadosBens_Click"
                        OnClientClick="mtdExecutarProgressBar('Importação de dados - Bens - Centro de Custo')"
                        Font-Bold="True" />
                    <br />
                    <br />
                    <asp:Button ID="btnPararImportacaoDadosBens" runat="server" BackColor="White" ForeColor="#333333"
                        Height="25px" Text="Parar" Width="150px" OnClick="btnPararImportacaoDadosBens_Click"
                        OnClientClick="mtdExecutarProgressBar('Importação de dados - Bens - Centro de Custo')"
                        Font-Bold="True" />
                    <br />
                    <br />
                    <span class="style16">Empregados</span><br />
                    <br />
                    <asp:Button ID="btnIniciarImportacaoDadosEmpregados" runat="server" BackColor="White"
                        ForeColor="#333333" Height="25px" Text="Iniciar" Width="150px" OnClick="btnIniciarImportacaoDadosEmpregados_Click"
                        OnClientClick="mtdExecutarProgressBar('Importação de dados - Empregados')" 
                        Font-Bold="True" />
                    <br />
                    <br />
                    <asp:Button ID="btnPararImportacaoDadosEmpregados" runat="server" BackColor="White"
                        ForeColor="#333333" Height="25px" Text="Parar" Width="150px" OnClick="btnPararImportacaoDadosEmpregados_Click"
                        OnClientClick="mtdExecutarProgressBar('Importação de dados - Empregados')" 
                        Font-Bold="True" />
                    <br />
                    <br />
                    <span class="style16">Centro de Custo</span><br />
                    <br />
                    <asp:Button ID="btnIniciarImportacaoDadosCentroCusto" runat="server" BackColor="White"
                        ForeColor="#333333" Height="25px" Text="Iniciar" Width="150px" OnClick="btnIniciarImportacaoDadosCentroCusto_Click"
                        OnClientClick="mtdExecutarProgressBar('Importação de dados - Centro de Custo')"
                        Font-Bold="True" />
                    <br />
                    <br />
                    <asp:Button ID="btnPararImportacaoDadosCentroCusto" runat="server" BackColor="White"
                        ForeColor="#333333" Height="25px" Text="Parar" Width="150px" OnClick="btnPararImportacaoDadosCentroCusto_Click"
                        OnClientClick="mtdExecutarProgressBar('Importação de dados - Centro de Custo')"
                        Font-Bold="True" />
                    <br />
                    <br />
                    <span class="style15">Exportação de dados</span>
                    <br />
                    <br />
                    <span class="style16">Inventário Bens - Excel </span>
                    <br />
                    <br />
                    <asp:Button ID="btnIniciarExportacaoDadosInventarioBensExcel" runat="server" BackColor="White"
                        ForeColor="#333333" Height="25px" Text="Iniciar" Width="150px" OnClick="btnIniciarExportacaoDadosInventarioBensExcel_Click"
                        OnClientClick="mtdExecutarProgressBar('Exportação de Dados - Inventário de Bens - Excel')"
                        Font-Bold="True" />
                    <br />
                    <br />
                    <asp:Button ID="btnPararExportacaoDadosInventarioBensExcel" runat="server" BackColor="White"
                        ForeColor="#333333" Height="25px" Text="Parar" Width="150px" OnClick="btnPararExportacaoDadosInventarioBensExcel_Click"
                        OnClientClick="mtdExecutarProgressBar('Exportação de Dados - Inventário de Bens - Excel')"
                        Font-Bold="True" />
                    <br />
                    <br />
                    <asp:DropDownList ID="dplConsultarCampoExportacaoDadosInventarioBensExcel" runat="server"
                        Width="150px" Height="20px">
                    </asp:DropDownList>
                    <br />
                    <br />
                    Transferência de dados
                    <br />
                    <br />
                    <span class="style16">Inventário Bens </span>
                    <br />
                    <br />
                    <span class="style16">
                        <asp:RadioButton ID="rdbPermitirDeletarTabelaInventarioBens" runat="server" AutoPostBack="False"
                            Style="font-size: small; color: #996633" Text="Deletar Tabela" />
                    </span>
                    <br />
                    <br />
                    <asp:Button ID="btnIniciarTransferenciaDadosInventarioBens" runat="server" BackColor="White"
                        Font-Bold="True" ForeColor="#333333" Height="25px" OnClick="btnIniciarTransferenciaDadosInventarioBens_Click"
                        OnClientClick="mtdExecutarProgressBar('Transferência de dados - Inventário de Bens')"
                        Text="Iniciar" Width="150px" />
                    <br />
                    <br />
                    <asp:Button ID="btnPararTransferenciaDadosInventarioBens" runat="server" BackColor="White"
                        Font-Bold="True" ForeColor="#333333" Height="25px" OnClick="btnPararTransferenciaDadosInventarioBens_Click"
                        Text="Parar" OnClientClick="mtdExecutarProgressBar('Transferência de dados - Inventário de Bens')"
                        Width="150px" />
                    <br />
                </td>
                <td class="style24">
                    &nbsp;
                </td>
            </tr>
        </table>
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
                ; // nothing to process
            };
            mHandlers.GetStatuses = function () {
                // call server method
                // which gets an array
                // of currently executing processes
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
                } else {
                    resultDiv.innerHTML = "&nbsp;";
                }
            };
            mHandlers.BuildProcessList = function (obj) {
                var i = 0;
                if (obj.length == 0)
                    return "&nbsp;";
                var result = "<table " +
                         "cellspacing='0' " +
                         "cellpadding='3' " +
                         "width='99%'>";

                result += "<td " +
                            "align='left' " +
                            "style='width:1%; white-space:nowrap'>" +
                            "<b>Nome do Processo</b>" +
                          "</td>";

                result += "<td " +
                            "align='left' " +
                            "style='width:89%;'>" +
                            "<b>Progresso</b>" +
                          "</td>";

                result += "<td " +
                            "align='left' " +
                            "style='width:10%; white-space:nowrap'>" +
                            "<b>Porcentagem</b>" +
                          "</td>";

                for (i = 0; i < obj.length; i++) {
                    result += "<tr>";

                    result += "<td " +
                            "align='left' " +
                            "style='width:1%; white-space:nowrap'>" +
                            obj[i].Name +
                          "</td>";

                    result += "<td " +
                            "align='left' " +
                            "style='width:89%;'>" +
                                "<div " +
                                    "style='width:100%; " +
                                    "background-color:white' " +
                                    ">" +
                                    "<div " +
                                        "style='width:" +
                                        obj[i].Status +
                                        "%; background-color:" +
                                            (obj[i].Status < 100 ?
                                                "red" : "green") +
                                            ";'>" +
                                        "&nbsp;</div>" +
                                "</div>" +
                          "</td>";

                    result += "<td " +
                            "align='left' " +
                            "style='width:10%; white-space:nowrap'>" +
                            obj[i].Status + " %" +
                          "</td>";

                    result += "</tr>";
                }
                result += "</table>";
                return result;
            };
        </script>
        </form>
</body>
</html>
