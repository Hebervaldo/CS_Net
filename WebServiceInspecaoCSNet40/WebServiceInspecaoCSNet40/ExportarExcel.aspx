<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ExportarExcel.aspx.cs" Inherits="WebServiceInspecaoCSNet40.ExportarExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #TextArea1
        {
            height: 100px;
            width: 562px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListBox ID="lstDownloadArquivos" runat="server" Height="120px" Width="337px">
    </asp:ListBox>
    &nbsp;<br />
    <br />
    <asp:Button ID="btnExportarExcel" runat="server" BackColor="White" EnableTheming="True"
        ForeColor="#333333" Height="25px" OnClick="btnExportarExcel_Click" Style="margin-left: 0px"
        Text="Exportar Excel" Width="110px" />
    &nbsp;<asp:Button ID="btnDownloadArquivoInspecao" runat="server" BackColor="White"
        EnableTheming="True" ForeColor="#333333" Height="25px" OnClick="btnDownloadArquivoInspecao_Click"
        Style="margin-left: 0px" Text="Download - Inspecao" Width="175px" />
    &nbsp;<asp:Button ID="btnDownloadArquivoEstatistica_01" runat="server" BackColor="White"
        EnableTheming="True" ForeColor="#333333" Height="25px" OnClick="btnDownloadArquivoEstatistica_01_Click"
        Style="margin-left: 0px" Text="Download - Estatistica_01" Width="175px" />
    &nbsp;<asp:Button ID="btnDownloadArquivoEstatistica_02" runat="server" BackColor="White"
        EnableTheming="True" ForeColor="#333333" Height="25px" OnClick="btnDownloadArquivoEstatistica_02_Click"
        Style="margin-left: 0px" Text="Download - Estatistica_02" Width="175px" />
</asp:Content>
