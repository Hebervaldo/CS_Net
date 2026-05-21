using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCSNet40
{
    public partial class sobre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblUsuario.Text = Default.strNomeUsuario != string.Empty ? Default.strNomeUsuario : Default.strContaUsuario;

                    hlkPerfil.Text = Default.strStatusUsuario;

                    lblSaudacao.Text = Default.mtdSaudacao();

                    txt1.Text =
                        "Esse aplicativo foi voltado para o setor de patrimônio, sendo um software sem "
                        +
                        "preocupações com direito autoral, caso haja necessidade, qualquer alteração poderá ser realizada. Contudo "
                        +
                        "deve-se considerar que qualquer dano que venha ocorrer em virtude de seu uso, não será de responsabilidade "
                        +
                        "do criador deste."
                        +
                        System.Environment.NewLine
                        +
                        System.Environment.NewLine
                        +
                        "Autor: Hebervaldo de Paula Carvalhêdo"
                        +
                        System.Environment.NewLine
                        +
                        "Matrícula: 10525"
                        +
                        System.Environment.NewLine
                        +
                        "Órgao: GISB"
                        +
                        System.Environment.NewLine
                        +
                        "Empresa: Eletronorte.";
                }
            }
            catch
            {
            }
        }
    }
}