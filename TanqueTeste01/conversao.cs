using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanqueTeste01
{
    public partial class frmConversao : Form
    {
        private frmPrincipal principal;

        public frmConversao()
        {
            InitializeComponent();
        }

        public frmConversao(frmPrincipal sender)
        {
            InitializeComponent();
            this.principal = sender;
        }        

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.principal.SetParametro(TipoParametro.enPA, Double.Parse(this.textBoxA.Text));
            this.principal.SetParametro(TipoParametro.enPB, Double.Parse(this.textBoxB.Text));
            Close();
        }

        private void frmConversao_Shown(object sender, EventArgs e)
        {
            this.textBoxA.Text = this.principal.GetParametro(TipoParametro.enPA).ToString();
            this.textBoxB.Text = this.principal.GetParametro(TipoParametro.enPB).ToString();
        }
    }
}
