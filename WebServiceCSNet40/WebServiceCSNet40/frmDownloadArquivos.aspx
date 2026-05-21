<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDownloadArquivos.aspx.cs"
    Inherits="WebServiceCSNet40.frmDownloadArquivos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

    <title>Eletrobras Eletronorte - Download de Arquivos</title>

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

        .titulo-principal
        {
            color: #16365D;
            font-size: 34px;
            font-weight: bold;
            margin-top: 10px;
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
            max-width: 700px;
            margin: 40px auto;
        }

        .card
        {
            background-color: #FFFFFF;
            border: 1px solid #DDDDDD;
            border-radius: 6px;
            padding: 30px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.05);
        }

        .card-titulo
        {
            color: #16365D;
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 25px;
            border-bottom: 1px solid #EEEEEE;
            padding-bottom: 10px;
            text-align: center;
        }

        .label
        {
            display: block;
            margin-bottom: 10px;
            font-weight: bold;
            color: #555555;
            font-size: 15px;
        }

        .listbox
        {
            width: 100%;
            height: 220px;
            border: 1px solid #CCCCCC;
            border-radius: 4px;
            padding: 10px;
            font-size: 14px;
            box-sizing: border-box;
        }

        .botao
        {
            background-color: #16365D;
            color: #FFFFFF;
            border: none;
            padding: 12px 24px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 15px;
            margin-top: 20px;
            width: 180px;
        }

        .botao:hover
        {
            background-color: #204D74;
        }

        .centralizar
        {
            text-align: center;
        }

        .rodape
        {
            text-align: center;
            color: #888888;
            font-size: 12px;
            padding: 20px;
            margin-top: 30px;
        }

    </style>

</head>

<body>

<form id="frmLogout" runat="server">

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

            <asp:HyperLink ID="hlkSobre"
                runat="server"
                NavigateUrl="~/Todos/sobre.aspx">
                Sobre
            </asp:HyperLink>

            <asp:HyperLink ID="hlkLogout"
                runat="server"
                NavigateUrl="~/logout.aspx">
                Logout
            </asp:HyperLink>

        </div>

        <div style="clear: both;"></div>

    </div>

    <!-- HEADER -->

    <div class="header">

        <div class="titulo-principal">
            ELETROBRAS ELETRONORTE
        </div>

        <div class="subtitulo">
            Download de Arquivos
        </div>

    </div>

    <!-- CONTEÚDO -->

    <div class="conteudo">

        <div class="card">

            <div class="card-titulo">
                Arquivos Disponíveis
            </div>

            <span class="label">
                Selecione um arquivo para download
            </span>

            <asp:ListBox ID="lstDownloadArquivos"
                runat="server"
                CssClass="listbox">
            </asp:ListBox>

            <div class="centralizar">

                <asp:Button ID="btnDownloadArquivos"
                    runat="server"
                    Text="Download"
                    CssClass="botao"
                    ToolTip="Clique aqui para realizar o download"
                    OnClick="btnDownloadArquivos_Click" />

            </div>

        </div>

    </div>

    <!-- RODAPÉ -->

    <div class="rodape">

        Sistema Web Service - Eletrobras Eletronorte

    </div>

</form>

</body>

</html>