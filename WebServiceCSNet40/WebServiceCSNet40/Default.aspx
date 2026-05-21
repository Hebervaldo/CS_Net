<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebServiceCSNet40.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

    <title>Eletrobras Eletronorte - Web Service</title>

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

        .logo
        {
            width: 180px;
            height: auto;
        }

        .titulo-principal
        {
            color: #16365D;
            font-size: 34px;
            font-weight: bold;
            margin-top: 15px;
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
            width: 95%;
            max-width: 1400px;
            margin: 20px auto;
        }

        .card
        {
            background-color: #FFFFFF;
            border: 1px solid #DDDDDD;
            padding: 25px;
            margin-bottom: 25px;
        }

        .card-titulo
        {
            font-size: 24px;
            color: #16365D;
            font-weight: bold;
            margin-bottom: 20px;
            border-bottom: 1px solid #EEEEEE;
            padding-bottom: 10px;
        }

        .grupo
        {
            margin-bottom: 40px;
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
            max-width: 650px;
            padding: 10px;
            border: 1px solid #CCCCCC;
            font-size: 14px;
        }

        .textbox-small
        {
            width: 250px;
        }

        .multiline
        {
            height: 70px;
        }

        .botao
        {
            background-color: #16365D;
            color: #FFFFFF;
            border: none;
            padding: 10px 18px;
            cursor: pointer;
            font-size: 14px;
        }

        .botao:hover
        {
            background-color: #204D74;
        }

        .info
        {
            background-color: #F7F9FC;
            border-left: 4px solid #16365D;
            padding: 12px;
            margin-bottom: 10px;
        }

        .upload-area
        {
            background-color: #FFFFFF;
            border: 1px solid #DDDDDD;
            padding: 25px;
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

        <img alt=""
             class="logo"
             src="Imagem/imgEletrobrasEletronorte.jpg" />

        <div class="titulo-principal">
            ELETROBRAS ELETRONORTE
        </div>

        <div class="subtitulo">
            WEB SERVICE
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

                <asp:MenuItem Text="Cadastro de Usuários"
                    Value="smnCadastroUsuarios" />

                <asp:MenuItem Text="Consultar Tabela de Dados"
                    Value="smnConsultaTabelaDados" />

                <asp:MenuItem Text="Importação de Dados"
                    Value="smnImportacaoDados" />

                <asp:MenuItem Text="Web Service"
                    Value="smnPrincipal" />

            </Items>

        </asp:Menu>

    </div>

    <!-- CONTEUDO -->

    <div class="conteudo">

        <!-- INFORMAÇÕES -->

        <div class="card">

            <div class="card-titulo">
                Informações do Sistema
            </div>

            <div class="info">
                <asp:Label ID="lblAviso" runat="server"></asp:Label>
            </div>

            <div class="info">
                <asp:Label ID="lblIpLocal" runat="server"></asp:Label>
            </div>

            <div class="info">
                <asp:Label ID="lblIpInternet" runat="server"></asp:Label>
            </div>

            <div class="info">
                <asp:Label ID="lblCanalAberto" runat="server"></asp:Label>
            </div>

            <asp:Button ID="btnObterInformacoes"
                runat="server"
                Text="Obter Informações"
                CssClass="botao"
                OnClick="btnObterInformacoes_Click" />

        </div>

        <!-- CONFIGURAÇÕES -->

        <div class="card">

            <div class="card-titulo">
                Configurações
            </div>

            <!-- TEXTO -->

            <div class="grupo">

                <div class="grupo-titulo">
                    TEXTO
                </div>

                <div class="linha">

                    <span class="label">Endereço</span>

                    <asp:TextBox ID="txtEnderecoTexto"
                        runat="server"
                        TextMode="MultiLine"
                        CssClass="textbox multiline">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <span class="label">Nome</span>

                    <asp:TextBox ID="txtNomeTexto"
                        runat="server"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

            </div>

            <!-- PRINCIPAL -->

            <div class="grupo">

                <div class="grupo-titulo">
                    PRINCIPAL
                </div>

                <div class="linha">

                    <span class="label">Endereço</span>

                    <asp:TextBox ID="txtEnderecoPrincipal"
                        runat="server"
                        TextMode="MultiLine"
                        CssClass="textbox multiline">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <span class="label">Nome</span>

                    <asp:TextBox ID="txtNomePrincipal"
                        runat="server"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <span class="label">Senha</span>

                    <asp:TextBox ID="txtSenhaPrincipal"
                        runat="server"
                        TextMode="Password"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

                <asp:Button ID="btnTestarConexaoPrincipal"
                    runat="server"
                    Text="Testar Conexão"
                    CssClass="botao"
                    OnClick="btnTestarConexaoPrincipal_Click" />

            </div>

            <!-- EXCEL -->

            <div class="grupo">

                <div class="grupo-titulo">
                    EXCEL
                </div>

                <div class="linha">

                    <span class="label">Endereço</span>

                    <asp:TextBox ID="txtEnderecoExcel"
                        runat="server"
                        TextMode="MultiLine"
                        CssClass="textbox multiline">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <span class="label">Nome</span>

                    <asp:TextBox ID="txtNomeExcel"
                        runat="server"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <span class="label">Senha</span>

                    <asp:TextBox ID="txtSenhaExcel"
                        runat="server"
                        Enabled="False"
                        TextMode="Password"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

                <asp:Button ID="btnTestarConexaoExcel"
                    runat="server"
                    Text="Testar Conexão"
                    CssClass="botao"
                    OnClick="btnTestarConexaoExcel_Click" />

            </div>

            <!-- CADU -->

            <div class="grupo">

                <div class="grupo-titulo">
                    CADU
                </div>

                <div class="linha">

                    <span class="label">Servidor</span>

                    <asp:TextBox ID="txtServidorCADU"
                        runat="server"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <span class="label">Banco de Dados</span>

                    <asp:TextBox ID="txtBancoDadosCADU"
                        runat="server"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <span class="label">Usuário</span>

                    <asp:TextBox ID="txtUsuarioCADU"
                        runat="server"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <span class="label">Senha</span>

                    <asp:TextBox ID="txtSenhaCADU"
                        runat="server"
                        TextMode="Password"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <span class="label">Tabela</span>

                    <asp:TextBox ID="txtTabelaCADU"
                        runat="server"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

                <asp:Button ID="btnTestarConexaoCADU"
                    runat="server"
                    Text="Testar Conexão"
                    CssClass="botao"
                    OnClick="btnTestarConexaoCADU_Click" />

            </div>

            <!-- COLETOR -->

            <div class="grupo">

                <div class="grupo-titulo">
                    COLETOR
                </div>

                <div class="linha">

                    <span class="label">Endereço</span>

                    <asp:TextBox ID="txtEnderecoColetor"
                        runat="server"
                        TextMode="MultiLine"
                        CssClass="textbox multiline">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <span class="label">Nome</span>

                    <asp:TextBox ID="txtNomeColetor"
                        runat="server"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <span class="label">Senha</span>

                    <asp:TextBox ID="txtSenhaColetor"
                        runat="server"
                        TextMode="Password"
                        CssClass="textbox textbox-small">
                    </asp:TextBox>

                </div>

                <div class="linha">

                    <asp:CheckBox ID="chkPermitirControleColetorUpLoad"
                        runat="server"
                        Checked="True"
                        Text="Permitir controle coletor de upload" />

                </div>

                <asp:Button ID="btnTestarConexaoColetor"
                    runat="server"
                    Text="Testar Conexão"
                    CssClass="botao"
                    OnClick="btnTestarConexaoColetor_Click" />

            </div>

            <asp:Button ID="btnCadastrar"
                runat="server"
                Text="Cadastrar"
                CssClass="botao"
                OnClick="btnCadastrar_Click" />

        </div>

        <!-- UPLOAD -->

        <div class="upload-area">

            <div class="card-titulo">
                Upload de Arquivo
            </div>

            <asp:FileUpload ID="fileImg"
                runat="server" />

            <br />
            <br />

            <asp:Button ID="btnUploadArquivo"
                runat="server"
                Text="Upload"
                CssClass="botao"
                OnClick="btnUploadArquivo_Click" />

        </div>

    </div>

    <!-- RODAPÉ -->

    <div class="rodape">

        Sistema Web Service - Eletrobras Eletronorte

    </div>

</form>

</body>

</html>