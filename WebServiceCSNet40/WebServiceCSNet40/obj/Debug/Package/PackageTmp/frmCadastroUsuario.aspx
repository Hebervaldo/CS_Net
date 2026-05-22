<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCadastroUsuario.aspx.cs"
    Inherits="WebServiceCSNet40.frmCadastroUsuario" %>

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
            <td class="style12">
                <asp:Menu ID="mnu1" runat="server" OnMenuItemClick="mnu1_MenuItemClick" StaticSubMenuIndent="10px"
                    Style="font-size: medium; color: #000000; font-weight: 700;" BackColor="#E3EAEB"
                    DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666"
                    Width="100%">
                    <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="#E3EAEB" />
                    <DynamicSelectedStyle BackColor="#1C5E55" />
                    <Items>
                        <asp:MenuItem Text="Voltar" Value="smnVoltar"></asp:MenuItem>
                        <asp:MenuItem Text="Importação de dados" Value="smnImportacaoDados"></asp:MenuItem>
                        <asp:MenuItem Text="Web Service" Value="smnPrincipal"></asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#1C5E55" />
                </asp:Menu>
            </td>
            <td class="style10">
                <span class="style12"><strong style="width: 100%;">
                    <asp:Label ID="lblInformacao" runat="server" Style="font-size: medium"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:GridView ID="gvw1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        Style="text-align: center" Width="100%" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvw1_SelectedIndexChanged">
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
                </strong></span>
                <br />
            </td>
            <td class="style17" width="15%">
                <p class="style5">
                    <strong class="style24">Criptografia</strong></p>
                <asp:Label ID="lblSenhaCadastro" runat="server" Text="Senha:" Style="margin-left: 0px;
                    font-size: small; color: #0000CC;" Width="100px"></asp:Label>
                <p class="style2">
                    <asp:TextBox ID="txtSenhaCadastro" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="150px" TextMode="Password"></asp:TextBox></p>
                <p class="style2">
                    <asp:Label ID="lblSenhaCriptografadaCadastro" runat="server" Text="Senha Criptografada:"
                        Style="margin-left: 0px" Width="100px"></asp:Label></p>
                <p class="style2">
                    <asp:TextBox ID="txtSenhaCriptografadaCadastro" runat="server" Style="margin-left: 0px;
                        text-align: center;" Width="150px" Enabled="False"></asp:TextBox></p>
                <p class="style16">
                    <asp:Label ID="lblChaveCadastro" runat="server" Text="Chave:" Style="margin-left: 0px"
                        Width="100px" Enabled="False"></asp:Label></p>
                <p class="style2">
                    <asp:TextBox ID="txtChaveCadastro" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="150px"></asp:TextBox></p>
                <p class="style15">
                    <strong class="style9">Usuário - Status</strong></p>
                <p class="style2">
                    <asp:Label ID="lblUsuarioCadastro" runat="server" Text="Usuário:" Style="margin-left: 0px"
                        Width="100px"></asp:Label>
                </p>
                <p class="style2">
                    <asp:TextBox ID="txtUsuarioCadastro" runat="server" Style="margin-left: 0px; text-align: center;"
                        Width="150px"></asp:TextBox>
                </p>
                <p class="style16">
                    <asp:Label ID="lblStatusUsuarioCadastro" runat="server" Text="Status do Usuário: "
                        Style="margin-left: 0px" Width="100px"></asp:Label>
                </p>
                <p class="style2">
                    <asp:DropDownList ID="dplStatusUsuarioCadastro" runat="server" Width="150px">
                    </asp:DropDownList>
                </p>
                <p class="style2">
                    <asp:Button ID="btnAlterar" runat="server" BackColor="White" EnableTheming="True"
                        ForeColor="#333333" Height="25px" Text="Alterar" Style="margin-left: 0px" Width="150px"
                        OnClick="btnAtualizar_Click" />
                </p>
                <p class="style2">
                    <asp:Button ID="btnInserir" runat="server" BackColor="White" EnableTheming="True"
                        ForeColor="#333333" Height="25px" Text="Inserir" Style="margin-left: 0px" Width="150px"
                        OnClick="btnInserir_Click" />
                </p>
                <p class="style2">
                    <asp:Button ID="btnDeletar" runat="server" BackColor="White" EnableTheming="True"
                        ForeColor="#333333" Height="25px" Text="Deletar" Style="margin-left: 0px" Width="150px"
                        OnClick="btnDeletar_Click" />
                </p>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
