<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCadastroUsuario.aspx.cs"
    Inherits="WebServiceCSNet40.frmCadastroUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

    <title>Eletrobras Eletronorte - Cadastro de Usuários</title>

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

        .menu-area
        {
            background-color: #204D74;
            padding: 10px;
        }

        .conteudo
        {
            width: 96%;
            max-width: 1500px;
            margin: 20px auto;
        }

        .layout
        {
            overflow: hidden;
        }

        .esquerda
        {
            float: left;
            width: 72%;
        }

        .direita
        {
            float: right;
            width: 25%;
        }

        .card
        {
            background-color: #FFFFFF;
            border: 1px solid #DDDDDD;
            padding: 25px;
            margin-bottom: 20px;
        }

        .card-titulo
        {
            color: #16365D;
            font-size: 24px;
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
            max-width: 250px;
            padding: 10px;
            border: 1px solid #CCCCCC;
            font-size: 14px;
        }

        .dropdown
        {
            width: 100%;
            max-width: 250px;
            padding: 10px;
            border: 1px solid #CCCCCC;
            font-size: 14px;
        }

        .botao
        {
            background-color: #16365D;
            color: #FFFFFF;
            border: none;
            padding: 10px 18px;
            cursor: pointer;
            font-size: 14px;
            width: 160px;
            margin-bottom: 10px;
        }

        .botao:hover
        {
            background-color: #204D74;
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

        .informacao
        {
            background-color: #F7F9FC;
            border-left: 4px solid #16365D;
            padding: 12px;
            margin-bottom: 20px;
            font-weight: bold;
            color: #204D74;
        }

        .rodape
        {
            text-align: center;
            color: #888888;
            font-size: 12px;
            padding: 20px;
        }

    </style>

</head>

<body>

<form id="Default" runat="server">

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
            Cadastro de Usuários
        </div>

    </div>

    <!-- MENU -->

    <div class="menu-area">

        <asp:Menu ID="mnu1"
            runat="server"
            Orientation="Horizontal"
            StaticDisplayLevels="1"
            ForeColor="White"
            BackColor="#204D74"
            DynamicHorizontalOffset="2"
            Font-Names="Segoe UI"
            Font-Size="14px"
            OnMenuItemClick="mnu1_MenuItemClick">

            <StaticMenuItemStyle HorizontalPadding="15px"
                VerticalPadding="10px" />

            <StaticHoverStyle BackColor="#16365D"
                ForeColor="White" />

            <Items>

                <asp:MenuItem Text="Voltar"
                    Value="smnVoltar" />

                <asp:MenuItem Text="Importação de dados"
                    Value="smnImportacaoDados" />

                <asp:MenuItem Text="Web Service"
                    Value="smnPrincipal" />

            </Items>

        </asp:Menu>

    </div>

    <!-- CONTEÚDO -->

    <div class="conteudo">

        <div class="layout">

            <!-- GRID -->

            <div class="esquerda">

                <div class="card">

                    <div class="card-titulo">
                        Usuários Cadastrados
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
                        CellPadding="8"
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

            <!-- LATERAL -->

            <div class="direita">

                <!-- CRIPTOGRAFIA -->

                <div class="card">

                    <div class="grupo-titulo">
                        Criptografia
                    </div>

                    <div class="linha">

                        <span class="label">Senha</span>

                        <asp:TextBox ID="txtSenhaCadastro"
                            runat="server"
                            TextMode="Password"
                            CssClass="textbox">
                        </asp:TextBox>

                    </div>

                    <div class="linha">

                        <span class="label">
                            Senha Criptografada
                        </span>

                        <asp:TextBox ID="txtSenhaCriptografadaCadastro"
                            runat="server"
                            Enabled="False"
                            CssClass="textbox">
                        </asp:TextBox>

                    </div>

                    <div class="linha">

                        <span class="label">Chave</span>

                        <asp:TextBox ID="txtChaveCadastro"
                            runat="server"
                            CssClass="textbox">
                        </asp:TextBox>

                    </div>

                </div>

                <!-- USUÁRIO -->

                <div class="card">

                    <div class="grupo-titulo">
                        Usuário - Status
                    </div>

                    <div class="linha">

                        <span class="label">Usuário</span>

                        <asp:TextBox ID="txtUsuarioCadastro"
                            runat="server"
                            CssClass="textbox">
                        </asp:TextBox>

                    </div>

                    <div class="linha">

                        <span class="label">
                            Status do Usuário
                        </span>

                        <asp:DropDownList ID="dplStatusUsuarioCadastro"
                            runat="server"
                            CssClass="dropdown">
                        </asp:DropDownList>

                    </div>

                    <asp:Button ID="btnAlterar"
                        runat="server"
                        Text="Alterar"
                        CssClass="botao"
                        OnClick="btnAtualizar_Click" />

                    <br />

                    <asp:Button ID="btnInserir"
                        runat="server"
                        Text="Inserir"
                        CssClass="botao"
                        OnClick="btnInserir_Click" />

                    <br />

                    <asp:Button ID="btnDeletar"
                        runat="server"
                        Text="Deletar"
                        CssClass="botao"
                        OnClick="btnDeletar_Click" />

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