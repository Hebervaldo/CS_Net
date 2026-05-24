<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebServiceInspecaoCSNet40._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
        font-size: small;
        font-weight: bold;
    }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="smn1" runat="server">
    </asp:ScriptManager>
    <br />
    <asp:Label ID="lblCampo1" runat="server" CssClass="style1" Text="Campo 1:"></asp:Label>
    <asp:DropDownList ID="ddlCampo1" runat="server" AutoPostBack="True" OnLoad="ddlCampo1_Load"
        OnSelectedIndexChanged="ddlCampo1_SelectedIndexChanged">
    </asp:DropDownList>
    &nbsp;<asp:Label ID="lblCampo2" runat="server" CssClass="style1" Text="Campo 2:"></asp:Label>
    &nbsp;<asp:DropDownList ID="ddlCampo2" runat="server" AutoPostBack="True" OnLoad="ddlCampo2_Load"
        OnSelectedIndexChanged="ddlCampo2_SelectedIndexChanged">
    </asp:DropDownList>
    &nbsp;<asp:Label ID="lblCampo3" runat="server" CssClass="style1" Text="Campo 3:"></asp:Label>
    &nbsp;<asp:DropDownList ID="ddlCampo3" runat="server" AutoPostBack="True" OnLoad="ddlCampo3_Load"
        OnSelectedIndexChanged="ddlCampo3_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <asp:UpdatePanel ID="upp1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
        <ContentTemplate>
            <asp:Label ID="lblDado1" runat="server" CssClass="style1" Text="Dado 1:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlDado1" runat="server" 
                OnPreRender="ddlDado1_PreRender">
            </asp:DropDownList>
            &nbsp;<asp:Label ID="lblDado2" runat="server" CssClass="style1" Text="Dado 2:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlDado2" runat="server" 
                OnPreRender="ddlDado2_PreRender">
            </asp:DropDownList>
            &nbsp;<asp:Label ID="lblDado3" runat="server" CssClass="style1" Text="Dado 3:"></asp:Label>
            &nbsp; &nbsp;<asp:DropDownList ID="ddlDado3" runat="server" AutoPostBack="True" OnPreRender="ddlDado3_PreRender">
            </asp:DropDownList>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlDado1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlDado2" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlDado3" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upp2" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
        <ContentTemplate>
            <br />
            <asp:Button ID="btnConsultarInspecao" runat="server" OnClick="btnConsultarInspecao_Click"
                Text="Consultar" Width="74px" />
            &nbsp;<asp:Button ID="btnDeletarInspecao" runat="server" OnClick="btnDeletarInspecao_Click"
                Text="Deletar - Tudo" Width="102px" />
            &nbsp;<asp:CheckBox ID="chkAutorizarDelete" runat="server" Text="Autorizar" />
            &nbsp;<asp:Button ID="btnCalcularEstatistica" runat="server"
                OnClick="btnCalcularEstatistica_Click" Text="Endereco" Width="80px" />
            &nbsp;<asp:Button ID="btnCalcularDataIdentificacaoServicoEstatistica" 
                runat="server" OnClick="btnCalcularDataIdentificacaoServicoEstatistica_Click" 
                Text="Data - Endereco - Servico" Width="172px" />
            &nbsp;<asp:Button ID="btnCalcularIdentificacaoEstatistica" runat="server" OnClick="btnCalcularIdentificacaoEstatistica_Click"
                Text="Data - Endereco" Width="120px" />
            &nbsp;<asp:Button ID="btnCalcularDataEstatistica" runat="server" OnClick="btnCalcularDataEstatistica_Click"
                Text="Data" Width="61px" />
            <br />
            <br />
            <br />
            <asp:GridView ID="gdvInspecao" runat="server" BackColor="White" BorderColor="#999999"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlDado1" EventName="PreRender" />
            <asp:AsyncPostBackTrigger ControlID="ddlDado2" EventName="PreRender" />
            <asp:AsyncPostBackTrigger ControlID="ddlDado3" EventName="PreRender" />
        </Triggers>
    </asp:UpdatePanel>
    &nbsp;
</asp:Content>
