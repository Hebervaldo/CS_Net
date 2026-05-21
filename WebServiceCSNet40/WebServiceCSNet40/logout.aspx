<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="WebServiceCSNet40.logout" %>

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
            background-color: #f4f7fb;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
        }

        .topo
        {
            width: 100%;
            padding: 12px 20px;
            box-sizing: border-box;
            text-align: right;
            font-size: 13px;
            color: #666666;
            background-color: #ffffff;
        }

        .topo a
        {
            color: #0000CC;
            font-weight: bold;
            text-decoration: none;
        }

        .linha
        {
            border: 0;
            border-top: 1px solid #dcdcdc;
            margin: 0;
        }

        .tituloEmpresa
        {
            margin-top: 30px;
            font-size: 34px;
            font-weight: bold;
            color: #0066CC;
        }

        .tituloSistema
        {
            margin-top: 10px;
            font-size: 28px;
            font-weight: bold;
            color: #400000;
        }

        .painelLogout
        {
            width: 500px;
            margin: 50px auto;
            background-color: #ffffff;
            border: 1px solid #dcdcdc;
            border-radius: 8px;
            padding: 40px;
            box-shadow: 0px 0px 10px #dcdcdc;
        }

        .mensagem
        {
            font-size: 24px;
            color: #0066CC;
            font-weight: bold;
            margin-bottom: 35px;
        }

        .linkLogin
        {
            display: inline-block;
            width: 220px;
            padding: 12px;
            background-color: #337ab7;
            border: 1px solid #2f5fa7;
            border-radius: 4px;
            color: #ffffff !important;
            font-weight: bold;
            text-decoration: none;
        }

        .linkLogin:hover
        {
            background-color: #286090;
        }

    </style>

</head>

<body>

    <form id="frmLogout" runat="server">

        <div class="topo">

            <strong>
                <asp:HyperLink ID="hlkPerfil"
                    runat="server">
                    [hlkPerfil]
                </asp:HyperLink>
            </strong>

            &nbsp;-&nbsp;

            <strong>
                <asp:Label ID="lblUsuario"
                    runat="server">
                </asp:Label>
            </strong>

            &nbsp;-&nbsp;

            <strong>
                <asp:Label ID="lblSaudacao"
                    runat="server">
                </asp:Label>
            </strong>

            &nbsp;-&nbsp;

            <strong>
                <asp:HyperLink ID="hlkLogin"
                    runat="server"
                    NavigateUrl="~/login.aspx">
                    Login
                </asp:HyperLink>
            </strong>

            &nbsp;-&nbsp;

            <strong>
                <asp:HyperLink ID="hlkSobre"
                    runat="server"
                    NavigateUrl="~/Todos/sobre.aspx">
                    Sobre
                </asp:HyperLink>
            </strong>

        </div>

        <hr class="linha" />

        <div class="tituloEmpresa">
            ELETROBRAS ELETRONORTE
        </div>

        <div class="tituloSistema">
            WEB SERVICE
        </div>

        <div class="painelLogout">

            <div class="mensagem">
                Não há usuários conectados.
            </div>

            <strong>
                <asp:HyperLink ID="hlk2"
                    runat="server"
                    NavigateUrl="login.aspx"
                    CssClass="linkLogin">
                    Logar novamente
                </asp:HyperLink>
            </strong>

        </div>

    </form>

</body>
</html>