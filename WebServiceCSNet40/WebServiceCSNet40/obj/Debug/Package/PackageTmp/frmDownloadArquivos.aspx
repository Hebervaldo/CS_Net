<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDownloadArquivos.aspx.cs"
    Inherits="WebServiceCSNet40.frmDownloadArquivos" %>

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
        .style12
        {
            margin-left: 200px;
            width: 500px;
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
    </style>
</head>
<body style="text-align: center">
    <form id="frmLogout" runat="server">
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
        <strong>WEB SERVICE</strong>&nbsp;</p>
    <p class="style28">
        <asp:ListBox ID="lstDownloadArquivos" runat="server" Height="120px" Width="337px">
        </asp:ListBox>
    </p>
    <p class="style5">
        <asp:Button ID="btnDownloadArquivos" runat="server" Height="25px" Style="margin-left: 0px"
            Text="Download" ToolTip="Clique aqui para logar" Width="100px" BackColor="White"
            ForeColor="#0000CC" OnClick="btnDownloadArquivos_Click" />
    </p>
    </form>
</body>
</html>
