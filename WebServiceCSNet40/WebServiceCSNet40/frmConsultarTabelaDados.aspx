<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmConsultarTabelaDados.aspx.cs"
    Inherits="WebServiceCSNet40.frmConsultarTabelaDados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

    <title>Eletrobras Eletronorte - Consultar Tabela de Dados</title>

    <style type="text/css">

        body
        {
            margin: 0;
            padding: 0;
            background: #EEF2F7;
            font-family: Segoe UI, Arial, Sans-Serif;
            color: #333333;
        }

        .topo
        {
            background-color: #16365D;
            color: #FFFFFF;
            padding: 12px 20px;
            overflow: hidden;
        }

        .topo-esquerda
        {
            float: left;
            font-size: 14px;
        }

        .topo-direita
        {
            float: right;
            font-size: 14px;
        }

        .topo a
        {
            color: #FFFFFF;
            text-decoration: none;
            font-weight: bold;
            margin-right: 10px;
        }

        .topo a:hover
        {
            text-decoration: underline;
        }

        .header
        {
            background-color: #FFFFFF;
            text-align: center;
            padding: 30px 10px;
            border-bottom: 1px solid #DCDCDC;
        }

        .titulo-principal
        {
            color: #16365D;
            font-size: 34px;
            font-weight: bold;
            margin-top: 10px;
        }

        .subtitulo
        {
            color: #666666;
            font-size: 22px;
            margin-top: 5px;
        }

        .conteudo
        {
            width: 96%;
            max-width: 1600px;
            margin: 20px auto;
        }

        .layout
        {
            overflow: hidden;
        }

        .menu-lateral
        {
            float: left;
            width: 20%;
        }

        .conteudo-central
        {
            float: right;
            width: 78%;
        }

        .card
        {
            background-color: #FFFFFF;
            border: 1px solid #DDDDDD;
            border-radius: 6px;
            padding: 25px;
            margin-bottom: 20px;
        }

        .card-titulo
        {
            color: #16365D;
            font-size: 22px;
            font-weight: bold;
            margin-bottom: 20px;
            border-bottom: 1px solid #EEEEEE;
            padding-bottom: 10px;
        }

        .grupo-titulo
        {
            background-color: #F5F7FA;
            color: #204D74;
            font-size: 18px;
            font-weight: bold;
            padding: 10px;
            border-left: 5px solid #204D74;
            margin-bottom: 20px;
        }

        .linha
        {
            margin-bottom: 15px;
        }

        .label
        {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555555;
        }

        .textbox
        {
            width: 100%;
            padding: 10px;
            border: 1px solid #CCCCCC;
            border-radius: 4px;
            box-sizing: border-box;
            font-size: 14px;
        }

        .dropdown
        {
            width: 100%;
            padding: 10px;
            border: 1px solid #CCCCCC;
            border-radius: 4px;
            box-sizing: border-box;
            font-size: 14px;
        }

        .botao
        {
            background-color: #16365D;
            color: #FFFFFF;
            border: none;
            padding: 10px 18px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 14px;
            width: 160px;
            margin-bottom: 10px;
        }

        .botao:hover
        {
            background-color: #204D74;
        }

        .informacao
        {
            background-color: #F7F9FC;
            border-left: 4px solid #16365D;
            padding: 12px;
            margin-bottom: 20px;
            font-weight: bold;
            color: #204D74;
        }

        .grid
        {
            width: 100%;
            border-collapse: collapse;
        }

        .grid td
        {
            padding: 8px;
        }

        .rodape
        {
            text-align: center;
            color: #888888;
            font-size: 12px;
            padding: 20px;
            margin-top: 30px;
        }

    </style>

</head>

<body>

<form id="frmImportacaoExportacaoDados" runat="server">

    <!-- TOPO -->

    <div class="topo">

        <div class="topo-esquerda">

            <asp:HyperLink ID="hlkPerfil"
                runat="server">
                Perfil
            </asp:HyperLink>

            |

            <asp:Label ID="lblUsuario"
                runat="server">
            </asp:Label>

            |

            <asp:Label ID="lblSaudacao"
                runat="server">
            </asp:Label>

        </div>

        <div class="topo-direita">

            <asp:HyperLink ID="hlkSobre"
                runat="server"
                NavigateUrl="~/Todos/sobre.aspx">
                Sobre
            </asp:HyperLink>

            <asp:HyperLink ID="hlkLogout"
                runat="server"
                NavigateUrl="~/logout.aspx">
                Logout
            </asp:HyperLink>

        </div>

        <div style="clear: both;"></div>

    </div>

    <!-- HEADER -->

    <div class="header">

        <div class="titulo-principal">
            ELETROBRAS ELETRONORTE
        </div>

        <div class="subtitulo">
            Consulta de Tabelas de Dados
        </div>

    </div>

    <!-- CONTEÚDO -->

    <div class="conteudo">

        <div class="layout">

            <!-- MENU LATERAL -->

            <div class="menu-lateral">

                <div class="card">

                    <div class="grupo-titulo">
                        Banco de Dados
                    </div>

                    <div class="linha">

                        <asp:DropDownList ID="dplSelecionarBancoDados"
                            runat="server"
                            CssClass="dropdown">
                        </asp:DropDownList>

                    </div>

                </div>

                <div class="card">

                    <div class="grupo-titulo">
                        Navegação
                    </div>

                    <asp:Menu ID="mnu1"
                        runat="server"
                        BackColor="#F5F7FA"
                        DynamicHorizontalOffset="2"
                        Font-Names="Segoe UI"
                        Font-Size="14px"
                        ForeColor="#333333"
                        StaticSubMenuIndent="10px"
                        Width="100%"
                        OnMenuItemClick="mnu1_MenuItemClick">

                        <DynamicHoverStyle BackColor="#204D74"
                            ForeColor="White" />

                        <DynamicMenuItemStyle HorizontalPadding="10px"
                            VerticalPadding="8px" />

                        <DynamicMenuStyle BackColor="#F5F7FA" />

                        <DynamicSelectedStyle BackColor="#16365D" />

                        <StaticHoverStyle BackColor="#204D74"
                            ForeColor="White" />

                        <StaticMenuItemStyle HorizontalPadding="10px"
                            VerticalPadding="8px" />

                        <StaticSelectedStyle BackColor="#16365D" />

                        <Items>

                            <asp:MenuItem Text="Voltar"
                                Value="smnVoltar" />

                            <asp:MenuItem Text="Filtro Importacao Bens"
                                Value="Filtro Importacao Bens" />

                            <asp:MenuItem Text="TRG"
                                Value="Termo de Responsabilidade Geral" />

                            <asp:MenuItem Text="Bens"
                                Value="Bens" />

                            <asp:MenuItem Text="Empregados"
                                Value="Empregados" />

                            <asp:MenuItem Text="Centro de Custo"
                                Value="Centro de Custo" />

                            <asp:MenuItem Text="Inventário de Bens"
                                Value="Inventário de Bens" />

                            <asp:MenuItem Text="Relatório"
                                Value="Relatório" />

                        </Items>

                    </asp:Menu>

                </div>

            </div>

            <!-- CONTEÚDO CENTRAL -->

            <div class="conteudo-central">

                <!-- CONSULTA -->

                <div class="card">

                    <div class="card-titulo">
                        Consulta de Dados
                    </div>

                    <div class="linha">

                        <span class="label">
                            Tabela Auxiliar - TRG Filtro
                        </span>

                        <asp:TextBox ID="txt1"
                            runat="server"
                            CssClass="textbox">
                        </asp:TextBox>

                    </div>

                    <asp:Button ID="btnAlterar"
                        runat="server"
                        Text="Alterar"
                        CssClass="botao"
                        Font-Bold="True" />

                    <asp:Button ID="btnInserir"
                        runat="server"
                        Text="Inserir"
                        CssClass="botao"
                        Font-Bold="True" />

                    <asp:Button ID="btnDeletar"
                        runat="server"
                        Text="Deletar"
                        CssClass="botao"
                        Font-Bold="True" />

                    <hr style="margin-top:20px; margin-bottom:20px;" />

                    <div class="linha">

                        <span class="label">
                            Tabela
                        </span>

                        <asp:DropDownList ID="dplConsultarTabelaRelatorio"
                            runat="server"
                            CssClass="dropdown"
                            AutoPostBack="True"
                            OnTextChanged="dplConsultarTabelaRelatorio_TextChanged">
                        </asp:DropDownList>

                    </div>

                    <div class="linha">

                        <span class="label">
                            Campo
                        </span>

                        <asp:DropDownList ID="dplConsultarCampo"
                            runat="server"
                            CssClass="dropdown">
                        </asp:DropDownList>

                    </div>

                    <div class="linha">

                        <span class="label">
                            Dado
                        </span>

                        <asp:TextBox ID="txtConsultarCampo"
                            runat="server"
                            CssClass="textbox">
                        </asp:TextBox>

                    </div>

                    <div class="linha">

                        <span class="label">
                            Tipo de Consulta
                        </span>

                        <asp:DropDownList ID="dplConsultarTotalParcial"
                            runat="server"
                            CssClass="dropdown">
                        </asp:DropDownList>

                    </div>

                    <asp:Button ID="btnConsultar"
                        runat="server"
                        Text="Consultar"
                        CssClass="botao"
                        Font-Bold="True"
                        OnClick="btnConsultar_Click" />

                </div>

                <!-- RESULTADO -->

                <div class="card">

                    <div class="card-titulo">
                        Resultado da Consulta
                    </div>

                    <div class="informacao">

                        <asp:Label ID="lblInformacao"
                            runat="server">
                        </asp:Label>

                    </div>

                    <asp:GridView ID="gvw1"
                        runat="server"
                        Width="100%"
                        CssClass="grid"
                        AutoGenerateSelectButton="True"
                        CellPadding="6"
                        ForeColor="#333333"
                        GridLines="None"
                        OnSelectedIndexChanged="gvw1_SelectedIndexChanged">

                        <AlternatingRowStyle BackColor="White"
                            ForeColor="#284775" />

                        <EditRowStyle BackColor="#999999" />

                        <FooterStyle BackColor="#5D7B9D"
                            Font-Bold="True"
                            ForeColor="White" />

                        <HeaderStyle BackColor="#16365D"
                            Font-Bold="True"
                            ForeColor="White" />

                        <PagerStyle BackColor="#284775"
                            ForeColor="White"
                            HorizontalAlign="Center" />

                        <RowStyle BackColor="#F7F6F3"
                            ForeColor="#333333" />

                        <SelectedRowStyle BackColor="#DDE8F5"
                            Font-Bold="True"
                            ForeColor="#333333" />

                        <SortedAscendingCellStyle BackColor="#E9E7E2" />

                        <SortedAscendingHeaderStyle BackColor="#506C8C" />

                        <SortedDescendingCellStyle BackColor="#FFFDF8" />

                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                    </asp:GridView>

                </div>

            </div>

            <div style="clear: both;"></div>

        </div>

    </div>

    <!-- RODAPÉ -->

    <div class="rodape">

        Sistema Web Service - Eletrobras Eletronorte

    </div>

</form>

</body>

</html>