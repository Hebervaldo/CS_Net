<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmConsultarTabelaDados.aspx.cs"
    Inherits="WebServiceCSNet40.frmConsultarTabelaDados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eletrobras Eletronorte - Web Service</title>
    <style type="text/css">
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
        .style14
        {
            color: #3366CC;
            font-family: "Times New Roman" , Times, serif;
            font-size: medium;
            text-align: center;
            width: 500px;
            margin-left: 200px;
        }
        .style15
        {
            color: #33CC33;
            font-family: "Times New Roman" , Times, serif;
            font-size: medium;
            text-align: center;
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
        .style25
        {
            color: #0066FF;
            font-weight: bold;
            width: 200px;
            margin-left: 200px;
        }
        .style16
        {
            color: #0000CC;
            font-family: "Times New Roman" , Times, serif;
            font-size: small;
            text-align: center;
        }
    </style>
</head>
<body style="text-align: center; height: 1062px; margin-bottom: 4px;">
    <form id="frmImportacaoExportacaoDados" runat="server">
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
    <span class="style12">
        <table width="100%" style="height: 885px">
            <tr>
                <td class="style25">
                    <span class="style15"><strong>Banco Dados:
                        <br />
                        <br />
                    </strong></span>
                    <asp:DropDownList ID="dplSelecionarBancoDados" runat="server" Width="150px">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <br />
                    <asp:Menu ID="mnu1" runat="server" BackColor="#E3EAEB" DynamicHorizontalOffset="2"
                        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666" StaticSubMenuIndent="10px"
                        OnMenuItemClick="mnu1_MenuItemClick" Width="100%" Style="text-align: center;
                        font-size: medium;">
                        <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicMenuStyle BackColor="#E3EAEB" />
                        <DynamicSelectedStyle BackColor="#1C5E55" />
                        <Items>
                            <asp:MenuItem Text="Voltar" Value="smnVoltar"></asp:MenuItem>
                            <asp:MenuItem Text="Filtro Importacao Bens" Value="Filtro Importacao Bens"></asp:MenuItem>
                            <asp:MenuItem Text="Termo de Responsabilidade Geral" Value="Termo de Responsabilidade Geral">
                            </asp:MenuItem>
                            <asp:MenuItem Text="Bens" Value="Bens"></asp:MenuItem>
                            <asp:MenuItem Text="Empregados" Value="Empregados"></asp:MenuItem>
                            <asp:MenuItem Text="Centro de Custo" Value="Centro de Custo"></asp:MenuItem>
                            <asp:MenuItem Text="Inventário de Bens" Value="Inventário de Bens"></asp:MenuItem>
                            <asp:MenuItem Text="Relatório" Value="Relatório"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticSelectedStyle BackColor="#1C5E55" />
                    </asp:Menu>
                    <td class="style14">
                        <strong style="width: 100%"><span class="style15">Tabela Auxiliar<br />
                            <br />
                        </span><span class="style16">TRG - Filtro<br />
                        </span>
                            <br />
                            <asp:TextBox ID="txt1" runat="server" Style="margin-left: 0px" Width="150px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="btnAlterar" runat="server" BackColor="White" ForeColor="#333333"
                                Height="25px" Text="Alterar" Width="150px" Font-Bold="True" />
                            <br />
                            <br />
                            <asp:Button ID="btnInserir" runat="server" BackColor="White" ForeColor="#333333"
                                Height="25px" Text="Inserir" Width="150px" Font-Bold="True" />
                            <br />
                            <br />
                            <asp:Button ID="btnDeletar" runat="server" BackColor="White" ForeColor="#333333"
                                Height="25px" Text="Deletar" Width="150px" Font-Bold="True" />
                            <br />
                            <br />
                            Tabela<br />
                            <asp:DropDownList ID="dplConsultarTabelaRelatorio" runat="server" Width="200px" AutoPostBack="True"
                                OnTextChanged="dplConsultarTabelaRelatorio_TextChanged">
                            </asp:DropDownList>
                            <br />
                            <br />
                            Campo<br />
                            <br />
                            <asp:DropDownList ID="dplConsultarCampo" runat="server" Width="200px">
                            </asp:DropDownList>
                            <br />
                            <br />
                            Dado<br />
                            <br />
                            <asp:TextBox ID="txtConsultarCampo" runat="server" Width="200px" BorderStyle="Inset"></asp:TextBox>
                            <br />
                            <br />
                            <asp:DropDownList ID="dplConsultarTotalParcial" runat="server" Width="200px">
                            </asp:DropDownList>
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="btnConsultar" runat="server" BackColor="White" ForeColor="#333333"
                                Height="25px" Text="Consultar" Width="150px" 
                            OnClick="btnConsultar_Click" Font-Bold="True" />
                            <br />
                            <br />
                            <asp:Label ID="lblInformacao" runat="server" Style="font-size: medium; color: #0066CC;"></asp:Label>
                            <br />
                            <br />
                        </strong><span class="style12">
                            <asp:GridView ID="gvw1" runat="server" AutoGenerateSelectButton="True" CellPadding="4"
                                ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvw1_SelectedIndexChanged"
                                Style="text-align: center" Width="100%">
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
                        </span>
                    </td>
                    <td class="style25">
                        &nbsp;
                    </td>
            </tr>
        </table>
    </form>
</body>
</html>
