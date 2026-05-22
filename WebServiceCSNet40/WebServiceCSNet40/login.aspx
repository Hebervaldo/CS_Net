<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebServiceCSNet40.login" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Eletrobras Eletronorte - Login</title>

    <style type="text/css">

        body
        {
            margin: 0;
            padding: 0;
            background-color: #f3f6fb;
            font-family: Segoe UI, Arial, Helvetica, sans-serif;
        }

        .topo
        {
            width: 100%;
            background-color: #0b3d91;
            color: white;
            padding: 15px 25px;
            box-sizing: border-box;
            text-align: right;
            font-size: 13px;
        }

        .topo a
        {
            color: #ffffff;
            text-decoration: none;
            font-weight: bold;
        }

        .topo a:hover
        {
            text-decoration: underline;
        }

        .header
        {
            text-align: center;
            padding-top: 35px;
            padding-bottom: 15px;
        }

        .titulo
        {
            font-size: 38px;
            font-weight: bold;
            color: #0b3d91;
            margin-bottom: 5px;
        }

        .subtitulo
        {
            font-size: 22px;
            color: #555555;
            font-weight: bold;
        }

        .login-container
        {
            width: 430px;
            margin: 30px auto;
            background-color: #ffffff;
            border-radius: 10px;
            border: 1px solid #d9e2ef;
            padding: 35px;
            box-shadow: 0px 3px 10px rgba(0,0,0,0.10);
        }

        .card-title
        {
            text-align: center;
            font-size: 24px;
            color: #0b3d91;
            font-weight: bold;
            margin-bottom: 30px;
        }

        .campo
        {
            margin-bottom: 22px;
        }

        .campo label
        {
            display: block;
            margin-bottom: 8px;
            font-size: 14px;
            font-weight: bold;
            color: #444444;
        }

        .textbox
        {
            width: 100%;
            padding: 11px;
            font-size: 14px;
            border: 1px solid #c8d3e1;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .textbox:focus
        {
            border-color: #0b3d91;
            outline: none;
        }

        .btn
        {
            width: 100%;
            background-color: #0b3d91;
            color: white;
            border: none;
            border-radius: 5px;
            padding: 11px;
            font-size: 14px;
            font-weight: bold;
            cursor: pointer;
            margin-bottom: 12px;
        }

        .btn:hover
        {
            background-color: #1455c0;
        }

        .btn-secundario
        {
            width: 100%;
            background-color: #f5f7fb;
            color: #0b3d91;
            border: 1px solid #cfd9ea;
            border-radius: 5px;
            padding: 11px;
            font-size: 14px;
            font-weight: bold;
            cursor: pointer;
            margin-bottom: 12px;
        }

        .btn-secundario:hover
        {
            background-color: #e9eef7;
        }

        .info
        {
            text-align: center;
            color: #0b3d91;
            font-size: 13px;
            margin-top: 10px;
        }

        .rodape-info
        {
            margin-top: 25px;
            padding-top: 20px;
            border-top: 1px solid #eeeeee;
        }

        .label-info
        {
            display: block;
            margin-bottom: 10px;
            color: #666666;
            font-size: 13px;
            text-align: center;
        }

    </style>

</head>

<body>

    <form id="frmLogin" runat="server">

        <div class="topo">

            <strong>

                <asp:Label ID="lblSaudacao"
                    runat="server">
                </asp:Label>

            </strong>

            &nbsp;&nbsp;|&nbsp;&nbsp;

            <asp:HyperLink ID="hlkSobre"
                runat="server"
                NavigateUrl="~/Todos/sobre.aspx">
                Sobre
            </asp:HyperLink>

        </div>

        <div class="header">

            <div class="titulo">
                ELETROBRAS ELETRONORTE
            </div>

            <div class="subtitulo">
                WEB SERVICE
            </div>

        </div>

        <div class="login-container">

            <div class="card-title">

                Tela de Login

                <asp:Timer ID="tmr1"
                    runat="server"
                    Interval="120000"
                    OnTick="tmr1_Tick" />

                <asp:ScriptManager ID="scmg1"
                    runat="server">
                </asp:ScriptManager>

            </div>

            <div class="campo">

                <label>
                    Nome de Usuário
                </label>

                <asp:TextBox ID="txtUsuario"
                    runat="server"
                    CssClass="textbox"
                    ToolTip="Digite o nome do usuário no campo abaixo.">
                </asp:TextBox>

            </div>

            <div class="campo">

                <label>
                    Senha
                </label>

                <asp:TextBox ID="txtSenha"
                    runat="server"
                    CssClass="textbox"
                    TextMode="Password"
                    ToolTip="Digite a senha no campo abaixo.">
                </asp:TextBox>

            </div>

            <asp:Button ID="btnEntrar"
                runat="server"
                CssClass="btn"
                Text="Entrar"
                ToolTip="Clique aqui para logar"
                OnClick="btnEntrar_Click" />

            <asp:Button ID="btnTornarSistemaFuncional"
                runat="server"
                CssClass="btn-secundario"
                Text="Tornar Sistema Funcional"
                ToolTip="Clique aqui para tornar sistema funcional"
                OnClick="btnTornarSistemaFuncional_Click" />

            <asp:Button ID="btnPrincipal"
                runat="server"
                CssClass="btn-secundario"
                Text="Web Service"
                ToolTip="Clique aqui para acessar o Web Service."
                OnClick="btnPrincipal_Click" />

            <div class="rodape-info">

                <span class="label-info">
                    <asp:Label ID="lblTestarConexaoAbertaBancoDados"
                        runat="server">
                    </asp:Label>
                </span>

                <span class="label-info">
                    <asp:Label ID="lblTestarExecucaoComandoBancoDados"
                        runat="server">
                    </asp:Label>
                </span>

                <span class="label-info">
                    <asp:Label ID="lblInformacao"
                        runat="server">
                    </asp:Label>
                </span>

                <span class="label-info">
                    <asp:Label ID="lblIpLocal"
                        runat="server">
                    </asp:Label>
                </span>

                <span class="label-info">
                    <asp:Label ID="lblIpInternet"
                        runat="server">
                    </asp:Label>
                </span>

                <span class="label-info">
                    <asp:Label ID="lblCanalAberto"
                        runat="server">
                    </asp:Label>
                </span>

            </div>

        </div>

    </form>

</body>
</html>