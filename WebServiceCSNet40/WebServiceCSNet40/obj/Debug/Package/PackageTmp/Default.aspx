<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebServiceCSNet40.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eletrobras Eletronorte - Web Service</title>
    <style type="text/css">
        .style2
        {
            color: #0000CC;
            font-family: "Times New Roman" , Times, serif;
            font-size: small;
            text-align: center;
        }
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
        .style5
        {
            color: #C0C0C0;
            font-family: "Times New Roman" , Times, serif;
            font-size: medium;
            text-align: center;
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
        .style9
        {
            color: #3366CC;
        }
        .style10
        {
            width: 750px;
            margin-left: 200px;
        }
        .style11
        {
            color: #0066CC;
            font-family: "Times New Roman" , Times, serif;
            font-size: xx-large;
            text-align: center;
            width: 1114px;
        }
        .style13
        {
            width: 217px;
            height: 154px;
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
        .style17
        {
            width: 213px;
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
            width: 1504px;
            margin-left: 200px;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="Default" runat="server">
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
        <strong>WEB SERVICE</strong></p>
    <table width="100%">
        <tr>
            <td class="style24">
                <asp:Menu ID="mnu1" runat="server" OnMenuItemClick="mnu1_MenuItemClick" StaticSubMenuIndent="10px"
                    Style="font-size: medium; color: #000000; font-weight: 700;" BackColor="#E3EAEB"
                    DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666"
                    Width="100%">
                    <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="#E3EAEB" />
                    <DynamicSelectedStyle BackColor="#1C5E55" />
                    <Items>
                        <asp:MenuItem Text="Cadastro de Usuários" Value="smnCadastroUsuarios"></asp:MenuItem>
                        <asp:MenuItem Text="Consultar Tabela de Dados" Value="smnConsultaTabelaDados"></asp:MenuItem>
                        <asp:MenuItem Text="Importação de Dados" Value="smnImportacaoDados"></asp:MenuItem>
                        <asp:MenuItem Text="Web Service" Value="smnPrincipal"></asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#1C5E55" />
                </asp:Menu>
            </td>
            <td class="style10">
                &nbsp;<img alt="" class="style13" src="Imagem/imgEletrobrasEletronorte.jpg" />
                <br />
                <p class="style5">
                    <asp:Label ID="lblAviso" runat="server" Style="font-family: 'Trebuchet MS'; color: #666666;
                        font-size: larger;"></asp:Label>
                </p>
                                        <p class="style2">
                                            <asp:Label ID="lblIpLocal" runat="server"></asp:Label>
                                        </p>
                                        <p class="style2">
                                            <asp:Label ID="lblIpInternet" runat="server"></asp:Label>
                                        </p>
                <p class="style2">
                                            <asp:Label ID="lblCanalAberto" runat="server"></asp:Label>
                                        </p>
                <p class="style2">
                    <asp:Button ID="btnObterInformacoes" runat="server" BackColor="White" ForeColor="Black"
                        Height="25px" Width="200px" Text="Obter Informações" 
                        OnClick="btnObterInformacoes_Click" />
                                        </p>
                <p class="style5">
                    <strong>Configurações</strong></p>
                <p class="style14">
                    <strong>TEXTO</strong></p>
                <p class="style16">
                    <asp:Label ID="lblEnderecoTexto" runat="server" Text="Endereço:" Style="margin-left: 0px"
                        Width="100px"></asp:Label></p>
                <p class="style2">
                    <asp:TextBox ID="txtEnderecoTexto" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="550px" Height="16px" TextMode="MultiLine"></asp:TextBox></p>
                <p class="style2">
                    <asp:Label ID="lblNomeTexto" runat="server" Text="Nome:" Style="margin-left: 0px"
                        Width="100px"></asp:Label></p>
                <p class="style2">
                    <asp:TextBox ID="txtNomeTexto" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="150px"></asp:TextBox></p>
                <p class="style14">
                    <strong>PRINCIPAL</strong></p>
                <p class="style16">
                    <asp:Label ID="lblEnderecoPrincipal" runat="server" Text="Endereço:" Style="margin-left: 0px"
                        Width="100px"></asp:Label></p>
                <p class="style2">
                    <asp:TextBox ID="txtEnderecoPrincipal" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="550px" Height="16px" TextMode="MultiLine"></asp:TextBox></p>
                <p class="style16">
                    <asp:Label ID="lblNomePrincipal" runat="server" Text="Nome:" Style="margin-left: 0px"
                        Width="100px"></asp:Label></p>
                <p class="style2">
                    <asp:TextBox ID="txtNomePrincipal" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="150px"></asp:TextBox></p>
                <p class="style16">
                    <asp:Label ID="lblSenhaPrincipal" runat="server" Text="Senha: " Style="margin-left: 0px"
                        Width="100px"></asp:Label></p>
                <p class="style2">
                    <asp:TextBox ID="txtSenhaPrincipal" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="150px" TextMode="Password"></asp:TextBox></p>
                <p class="style2">
                    <asp:Button ID="btnTestarConexaoPrincipal" runat="server" BackColor="White" ForeColor="Black"
                        Height="25px" Width="200px" Text="Clique para Testar..." 
                        OnClick="btnTestarConexaoPrincipal_Click" /></p>
                <p class="style14">
                    <strong class="style9">EXCEL</strong></p>
                <p class="style16">
                    <asp:Label ID="lblEnderecoeExcel" runat="server" Text="Endereço:" Style="margin-left: 0px"
                        Width="100px"></asp:Label></p>
                <p class="style2">
                    <asp:TextBox ID="txtEnderecoExcel" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="550px" Height="16px" TextMode="MultiLine"></asp:TextBox></p>
                <p class="style2">
                    <asp:Label ID="lblNomeExcel" runat="server" Text="Nome:" Style="margin-left: 0px"
                        Width="100px"></asp:Label></p>
                <p class="style2">
                    <asp:TextBox ID="txtNomeExcel" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="150px"></asp:TextBox></p>
                <p class="style16">
                    <asp:Label ID="lblSenhaExcel" runat="server" Text="Senha: " Style="margin-left: 0px"
                        Width="100px" Enabled="False"></asp:Label></p>
                <p class="style2">
                    <asp:TextBox ID="txtSenhaExcel" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="150px" Enabled="False" TextMode="Password"></asp:TextBox></p>
                <p class="style2">
                    <asp:Button ID="btnTestarConexaoExcel" runat="server" BackColor="White" ForeColor="Black"
                        Height="25px" Width="200px" Text="Clique para Testar..." 
                        OnClick="btnTestarConexaoExcel_Click" />
                </p>
                <p class="style15">
                    <strong class="style9">CADU</strong></p>
                <p class="style16">
                    <asp:Label ID="lbServidorCADU" runat="server" Text="Servidor:" Style="margin-left: 0px"
                        Width="100px"></asp:Label>
                </p>
                <p class="style2">
                    <asp:TextBox ID="txtServidorCADU" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="150px"></asp:TextBox>
                </p>
                <p class="style16">
                    <asp:Label ID="lbBancoDadosCADU" runat="server" Text="Banco de Dados:" Style="margin-left: 0px"
                        Width="100px"></asp:Label>
                </p>
                <p class="style2">
                    <asp:TextBox ID="txtBancoDadosCADU" runat="server" Style="margin-left: 0px;
                        text-align: center;" Width="150px"></asp:TextBox>
                </p>
                <p class="style16">
                    <asp:Label ID="lbUsuarioCADU" runat="server" Text="Usuário:" Style="margin-left: 0px"
                        Width="100px"></asp:Label>
                </p>
                <p class="style2">
                    <asp:TextBox ID="txtUsuarioCADU" runat="server" Style="margin-left: 0px; text-align: left;"
                        Width="150px"></asp:TextBox>
                </p>
                <p class="style16">
                    <asp:Label ID="lblSenhaCADU" runat="server" Text="Senha: " Style="margin-left: 0px"
                        Width="100px"></asp:Label>
                </p>
                <p class="style2">
                    <asp:TextBox ID="txtSenhaCADU" runat="server" Style="margin-left: 0px;" Width="150px"
                        TextMode="Password"></asp:TextBox>
                </p>
                <p class="style16">
                    <asp:Label ID="lblTabelaCADU" runat="server" Text="Tabela:" Style="margin-left: 0px"
                        Width="100px"></asp:Label>
                </p>
                <p class="style2">
                    <asp:TextBox ID="txtTabelaCADU" runat="server" Style="margin-left: 0px;" 
                        Width="150px"></asp:TextBox>
                </p>
                <p class="style2">
                    <asp:Button ID="btnTestarConexaoCADU" runat="server" BackColor="White" ForeColor="Black"
                        Height="25px" Width="200px" Text="Clique para Testar..." 
                        OnClick="btnTestarConexaoCADU_Click" />
                </p>
                <p class="style15">
                    <strong class="style9">COLETOR</strong></p>
                <p class="style16">
                    <asp:Label ID="lblEnderecoColetor" runat="server" Text="Endereço:" Style="margin-left: 0px"
                        Width="100px"></asp:Label>
                </p>
                <p class="style2">
                    <asp:TextBox ID="txtEnderecoColetor" runat="server" Style="margin-left: 0px;
                        text-align: center;" Width="550px" Height="16px" TextMode="MultiLine"></asp:TextBox>
                </p>
                <p class="style2">
                    <asp:Label ID="lblNomeColetor" runat="server" Text="Nome:" Style="margin-left: 0px"
                        Width="100px"></asp:Label>
                </p>
                <p class="style2">
                    <asp:TextBox ID="txtNomeColetor" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="150px"></asp:TextBox>
                </p>
                <p class="style16">
                    <asp:Label ID="lblSenhaColetor" runat="server" Text="Senha: " Style="margin-left: 0px"
                        Width="100px"></asp:Label>
                </p>
                <p class="style2">
                    <asp:TextBox ID="txtSenhaColetor" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="150px" TextMode="Password"></asp:TextBox>
                </p>
                <p class="style2">
                    <asp:CheckBox ID="chkPermitirControleColetorUpLoad" runat="server" 
                        Checked="True" Text="Permitir controle coletor de upload" />
                </p>
                <p class="style2">
                    <asp:Button ID="btnTestarConexaoColetor" runat="server" BackColor="White" ForeColor="Black"
                        Height="25px" Width="200px" Text="Clique para Testar..." 
                        OnClick="btnTestarConexaoColetor_Click" />
                </p>
                <p class="style2">
                    <asp:Button ID="btnCadastrar" runat="server" BackColor="White" EnableTheming="True"
                        ForeColor="#333333" Height="25px" Text="Cadastrar" OnClick="btnCadastrar_Click"
                        Style="margin-left: 0px" Width="200px" />
                    &nbsp;</p>
            </td>
            <td class="style17" width="100%">
                <p class="style14">
                    <strong>TEXTO</strong></p>
                <p class="style5">
                    <asp:FileUpload ID="fileImg" runat="server" />
                </p>
                <p class="style5">
                    <asp:Button ID="btnUploadArquivo" runat="server" BackColor="White" ForeColor="Black"
                        Height="20px" Width="150px" OnClick="btnUploadArquivo_Click" Text="Upload" /></p>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
