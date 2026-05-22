<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sobre.aspx.cs" Inherits="WebServiceCSNet40.sobre" %>

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
            background: #EEF2F7;
            font-family: Segoe UI, Arial, Sans-Serif;
            color: #333333;
        }

        .topo
        {
            background-color: #16365D;
            color: #FFFFFF;
            padding: 12px 20px;
            overflow: hidden;
        }

        .topo-esquerda
        {
            float: left;
            font-size: 14px;
        }

        .topo-direita
        {
            float: right;
            font-size: 14px;
        }

        .topo a
        {
            color: #FFFFFF;
            text-decoration: none;
            font-weight: bold;
            margin-right: 10px;
        }

        .topo a:hover
        {
            text-decoration: underline;
        }

        .header
        {
            background-color: #FFFFFF;
            text-align: center;
            padding: 30px 10px;
            border-bottom: 1px solid #DCDCDC;
        }

        .logo
        {
            width: 180px;
            height: auto;
        }

        .titulo-principal
        {
            color: #16365D;
            font-size: 34px;
            font-weight: bold;
            margin-top: 15px;
        }

        .subtitulo
        {
            color: #666666;
            font-size: 22px;
            margin-top: 5px;
        }

        .conteudo
        {
            width: 95%;
            max-width: 1200px;
            margin: 30px auto;
        }

        .card
        {
            background-color: #FFFFFF;
            border: 1px solid #DDDDDD;
            padding: 30px;
        }

        .card-titulo
        {
            font-size: 28px;
            color: #16365D;
            font-weight: bold;
            margin-bottom: 20px;
            border-bottom: 1px solid #EEEEEE;
            padding-bottom: 10px;
        }

        .texto-sobre
        {
            width: 100%;
            height: 350px;
            border: 1px solid #CCCCCC;
            padding: 15px;
            font-size: 14px;
            resize: none;
            background-color: #F9F9F9;
            color: #333333;
            box-sizing: border-box;
        }

        .rodape
        {
            text-align: center;
            color: #888888;
            font-size: 12px;
            padding: 20px;
        }

    </style>

</head>

<body>

<form id="frmLogin" runat="server">

    <!-- TOPO -->

    <div class="topo">

        <div class="topo-esquerda">

            <asp:HyperLink ID="hlkPerfil"
                runat="server">
                Perfil
            </asp:HyperLink>

            |

            <asp:Label ID="lblUsuario"
                runat="server">
            </asp:Label>

            |

            <asp:Label ID="lblSaudacao"
                runat="server">
            </asp:Label>

        </div>

        <div class="topo-direita">

            <asp:HyperLink ID="hlkVoltar"
                runat="server"
                NavigateUrl="~/Default.aspx">
                Voltar
            </asp:HyperLink>

        </div>

        <div style="clear: both;"></div>

    </div>

    <!-- HEADER -->

    <div class="header">

        <img alt=""
             class="logo"
             src="Imagem/imgEletrobrasEletronorte.jpg" />

        <div class="titulo-principal">
            ELETROBRAS ELETRONORTE
        </div>

        <div class="subtitulo">
            WEB SERVICE
        </div>

    </div>

    <!-- CONTEÚDO -->

    <div class="conteudo">

        <div class="card">

            <div class="card-titulo">
                Sobre o Sistema
            </div>

            <asp:TextBox ID="txt1"
                runat="server"
                TextMode="MultiLine"
                ReadOnly="True"
                CssClass="texto-sobre">
            </asp:TextBox>

        </div>

    </div>

    <!-- RODAPÉ -->

    <div class="rodape">

        Sistema Web Service - Eletrobras Eletronorte

    </div>

</form>

</body>

</html>