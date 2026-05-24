<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Enderecos.aspx.cs" Inherits="WebServiceInspecaoCSNet40.Enderecos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="lblEndereco" runat="server" Text="Endereco:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtEndereco" runat="server" BorderStyle="Inset"></asp:TextBox>
        &nbsp;<asp:Button ID="btnAlterar" runat="server" BackColor="White" EnableTheming="True"
            ForeColor="#333333" Height="25px" OnClick="btnAtualizar_Click" Style="margin-left: 0px"
            Text="Alterar" Width="110px" />
        &nbsp;<asp:Button ID="btnInserir" runat="server" BackColor="White" EnableTheming="True"
            ForeColor="#333333" Height="25px" OnClick="btnInserir_Click" Style="margin-left: 0px"
            Text="Inserir" Width="110px" />
        &nbsp;<asp:Button ID="btnDeletar" runat="server" BackColor="White" EnableTheming="True"
            ForeColor="#333333" Height="25px" OnClick="btnDeletar_Click" Style="margin-left: 0px"
            Text="Deletar" Width="110px" />
        &nbsp;<asp:Button ID="btnDeletarTodos" runat="server" BackColor="White" EnableTheming="True"
            ForeColor="#333333" Height="25px" OnClick="btnDeletarTodos_Click" Style="margin-left: 0px"
            Text="Deletar - Todos" Width="110px" />
        &nbsp;<asp:Button ID="btnSelecionar" runat="server" BackColor="White" EnableTheming="True"
            ForeColor="#333333" Height="25px" OnClick="btnSelecionar_Click" Style="margin-left: 0px"
            Text="Selecionar" Width="110px" />
        &nbsp;<asp:Label ID="lblInformacao" runat="server"></asp:Label>
    </p>
    <asp:GridView ID="gvwEndereco" runat="server" AutoGenerateSelectButton="True" CellPadding="4"
        ForeColor="#333333" GridLines="None" Style="text-align: center" Width="100%"
        OnSelectedIndexChanged="gvwEndereco_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
