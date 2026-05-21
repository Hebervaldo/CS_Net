<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebServiceCSNet40.login" %>

<%@ Register assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

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
        }
        .style3
        {
            color: #0000CC;
            font-family: "Times New Roman" , Times, serif;
            font-size: small;
            text-align: right;
        }
        .style4
        {
            font-family: "Times New Roman" , Times, serif;
            font-size: x-large;
            color: #400000;
        }
        .style5
        {
            color: #CCCCFF;
            font-family: "Times New Roman" , Times, serif;
            font-size: medium;
        }
        #txp1
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
        .style21
        {
            color: #000000;
        }
        .style26
        {
            text-align: left;
            width: 793px;
            color: #666666;
        }
        .style25
        {
            text-align: left;
            color: #0000CC;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="frmLogin" runat="server">
    <p class="style3" style="width: 100%">
        <strong>
            <asp:Label ID="lblSaudacao" runat="server" CssClass="style26"></asp:Label>
        </strong><span class="style21"><strong>&nbsp;- </strong></span><strong>
            <asp:HyperLink ID="hlkSobre" runat="server" NavigateUrl="~/Todos/sobre.aspx" CssClass="style25">Sobre</asp:HyperLink>
        </strong>
    </p>
    <hr style="height: 0px; margin-top: 0px; margin-bottom: 0px; width: 100%;" />
    <p class="style11" style="width: 100%;">
        <strong>ELETROBRAS ELETRONORTE</strong></p>
    <p class="style4" style="width: 100%;">
        <strong>WEB SERVICE</strong></p>
    &nbsp;<p class="style5">
        <strong>Tela de Login<asp:Timer ID="tmr1" runat="server" Interval="120000" 
            ontick="tmr1_Tick" />
            <asp:ScriptManager ID="scmg1" runat="server">
            </asp:ScriptManager>
        </strong>
    </p>
    &nbsp;<p class="style2">
        <asp:Label ID="lblUsuario" runat="server" Text="Nome de Usuário: " Style="margin-left: 0px"
            Width="100px" ToolTip="Digite o nome do usuário no campo abaixo."></asp:Label>
        <p class="style2">
            <asp:TextBox ID="txtUsuario" runat="server" Style="margin-left: 0px; text-align: center;"
                Width="323px"></asp:TextBox>
        </p>
        <p class="style2">
            <asp:Label ID="lblSenha" runat="server" Text="Senha: " Style="margin-left: 0px" Width="100px"
                ToolTip="Digite a senha no campo abaixo."></asp:Label>
            <p class="style2">
                <asp:TextBox ID="txtSenha" runat="server" Style="margin-left: 0px; text-align: center;"
                    Width="323px" TextMode="Password"></asp:TextBox>
                <p class="style2">
                    <asp:Button ID="btnEntrar" runat="server" Height="25px" Style="margin-left: 0px"
                        Text="Entrar" ToolTip="Clique aqui para logar" Width="100px" BackColor="White"
                        ForeColor="#0000CC" OnClick="btnEntrar_Click" />
                    <p class="style2">
                        <asp:Button ID="btnTornarSistemaFuncional" runat="server" Height="25px" Style="margin-left: 0px"
                            Text="Tornar Sistema Funcional" ToolTip="Clique aqui para tornar sistema funcional"
                            Width="250px" BackColor="White" ForeColor="#0000CC" OnClick="btnTornarSistemaFuncional_Click" />
                        <p class="style2">
                            <asp:Button ID="btnPrincipal" runat="server" Height="25px" Style="margin-left: 0px"
                                Text="Web Service" ToolTip="Clique aqui para acessar o Web Service." Width="250px"
                                BackColor="White" ForeColor="#0000CC" OnClick="btnPrincipal_Click" />
                            <p class="style2">
                                <asp:Label ID="lblTestarConexaoAbertaBancoDados" runat="server"></asp:Label>
                                <p class="style2">
                                    <asp:Label ID="lblTestarExecucaoComandoBancoDados" runat="server"></asp:Label>
                                    <p class="style2">
                                        <asp:Label ID="lblInformacao" runat="server"></asp:Label>
                                        <p class="style2">
                                            <asp:Label ID="lblIpLocal" runat="server"></asp:Label>
                                        </p>
                                        <p class="style2">
                                            <asp:Label ID="lblIpInternet" runat="server"></asp:Label>
                                        </p>
                                        <p class="style2">
                                            <asp:Label ID="lblCanalAberto" runat="server"></asp:Label>
                                        </p>
    </form>
</body>
</html>
