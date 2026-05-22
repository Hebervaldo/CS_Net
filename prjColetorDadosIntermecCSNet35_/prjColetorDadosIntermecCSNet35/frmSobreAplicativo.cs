using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace prjColetorDadosIntermecCSNet35
{
    public partial class frmSobreAplicativo : Form
    {
        public frmSobreAplicativo()
        {
            InitializeComponent();
        }

        private void frmSobreAplicativo_Load(System.Object sender, System.EventArgs e)
        {
            this.Text = "Sobre o Aplicativo";
            this.txtDescription.Text =
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

        private void mni1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}