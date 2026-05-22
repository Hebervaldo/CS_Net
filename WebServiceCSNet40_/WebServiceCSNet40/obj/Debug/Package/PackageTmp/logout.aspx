<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="WebServiceCSNet40.logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eletrobras Eletronorte - Web Service</title>
    <style type="text/css">
        .style1
        {
            color: #0066CC;
            font-family: "Times New Roman" , Times, serif;
            font-size: xx-large;
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
            font-size: large;
        }
        #txp1
        {
            width: 323px;
            margin-left: 0px;
        }
        .style12
        {
            margin-left: 200px;
            width: 213px;
        }
        .style11
        {
            color: #0066CC;
            font-family: "Times New Roman" , Times, serif;
            font-size: xx-large;
            text-align: center;
            width: 1114px;
        }
        .style27
        {
            text-align: left;
            width: 213px;
            color: #0066FF;
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
    <form id="frmLogout" runat="server">
    <p class="style3" style="width: 100%">
        <strong>
            <asp:HyperLink ID="hlkPerfil" runat="server" Style="font-size: small; font-family: 'Times New Roman';"
                CssClass="style27">[hlkPerfil]</asp:HyperLink>
        </strong><span class="style21"><strong>&nbsp;- </strong></span><strong>
            <asp:Label ID="lblUsuario" runat="server" Style="font-family: 'Times New Roman';"
                CssClass="style27"></asp:Label>
        </strong><span class="style21"><strong>&nbsp;- </strong></span><strong>
            <asp:Label ID="lblSaudacao" runat="server" CssClass="style26"></asp:Label>
        </strong><span class="style21"><strong>&nbsp;-&nbsp;</strong></span><strong><asp:HyperLink
            ID="hlkLogin" runat="server" NavigateUrl="~/login.aspx" CssClass="style25">Login</asp:HyperLink>
        </strong><span class="style21"><strong>&nbsp;- </strong></span><strong>
            <asp:HyperLink ID="hlkSobre" runat="server" NavigateUrl="/Todos/sobre.aspx" CssClass="style25">Sobre</asp:HyperLink>
        </strong>
    </p>
    <hr style="height: 0px; margin-top: 0px; margin-bottom: 0px; width: 100%;" />
    <p class="style11" style="width: 100%;">
        <strong>ELETROBRAS ELETRONORTE</strong></p>
    <p class="style4" style="width: 100%;">
        <strong>WEB SERVICE</strong></p>
    &nbsp;<p class="style5">
        <strong>Não há usuários conectados.</strong></p>
    <p class="style5">
        <strong>
            <asp:HyperLink ID="hlk2" runat="server" NavigateUrl="login.aspx" Style="color: #0000CC">Logar novamente.</asp:HyperLink>
        </strong>
    </p>
    </form>
</body>
</html>
