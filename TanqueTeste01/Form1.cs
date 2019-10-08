using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; // necessário para ter acesso as portas 
using System.IO;

namespace TanqueTeste01 {
    public enum TipoParametro
    {
        enPA,
        enPB
    };

    public partial class frmPrincipal : Form
    {
        public frmPrincipal(){     
            InitializeComponent();
            btnIniciar.Enabled = false;
            btnBomba.Enabled = false;
            btnSalvar.Enabled = false;
            this.groupBox2.Enabled = false;
        }

        public void SetParametro(TipoParametro tp, double valor)
        {
            if (tp == TipoParametro.enPA)
            {
                this.parametroA = valor;
            }
            else
            {
                this.parametroB = valor;
            }
        }

        public double GetParametro(TipoParametro tp)
        {
            if (tp == TipoParametro.enPA)
            {
                return this.parametroA;       
            }
            else
            {
                return this.parametroB;
            }
        }

        private void AtualizaListaCOMs(){

            int i = 0;
            bool quantDiferente = false; //flag para sinalizar que a quantidade de portas mudou

            //se a quantidade de portas mudou
            if (cboPortaSerial.Items.Count == SerialPort.GetPortNames().Length) {
                foreach (string s in SerialPort.GetPortNames()) {
                    if (cboPortaSerial.Items[i++].Equals(s) == false) {
                        quantDiferente = true;
                    }
                }
            }
            else{
                quantDiferente = true;
            }
            //Se não foi detectado diferença
            if (quantDiferente == false){
                return;                     //retorna
            }
            //limpa comboBox
            cboPortaSerial.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames()) {
                cboPortaSerial.Items.Add(s);
            }
            //seleciona a primeira posição da lista
            cboPortaSerial.SelectedIndex = 0;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.PortName = cboPortaSerial.Items[cboPortaSerial.SelectedIndex].ToString();
                    serialPort1.Open();
                }
                catch
                {
                    return;
                }
                if (serialPort1.IsOpen)
                {
                    btnConectar.Text = "Desconectar";
                    cboPortaSerial.Enabled = false;
                    btnIniciar.Enabled = true;

                }
            }
            else
            {
                try
                {
                    serialPort1.Close();
                    cboPortaSerial.Enabled = true;
                    btnConectar.Text = "Conectar";
                    btnIniciar.Enabled = false;
                }
                catch
                {
                    return;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e){
            if (serialPort1.IsOpen)  // se porta aberta
            {
                serialPort1.Write(finalizarComunicacao);
                serialPort1.Close();         //fecha a porta
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            if (serialPort1.IsOpen)
            {
                if (btnIniciar.Text == "Iniciar")
                {
                    serialPort1.DiscardOutBuffer();
                    serialPort1.DiscardInBuffer();
                    serialPort1.Write(iniciarComunicacao);
                    chartNivel.Series[0].Points.Clear();
                    chartBomba.Series[0].Points.Clear();
                    btnIniciar.Text = "Parar";
                    ajustarParametrosToolStripMenuItem.Enabled = false;
                    btnConectar.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnBomba.Enabled = true;
                    requested = true;
                  //  radManual.Checked = true;
                    sample = 0;
                    //*****************************AJEITAR
                    this.groupBox2.Enabled = true;

                }
                else
                {
                    serialPort1.DiscardOutBuffer();
                    serialPort1.Write(finalizarComunicacao);
                    btnIniciar.Text = "Iniciar";
                    btnConectar.Enabled = true;
                    btnSalvar.Enabled = true;
                    ajustarParametrosToolStripMenuItem.Enabled = true;
                    btnBomba.Enabled = false;
                    requested = false;
                    //*****************************AJEITAR
                    this.groupBox2.Enabled = false;
                }
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e){
            if (requested){
                leituraBombaSensor = (string)serialPort1.ReadExisting();    //ler o dado disponível na serial   
                this.Invoke(new EventHandler(DadoSerialRecebido));           //chama outra thread para escrever 
            }
        }
 
        private bool ChaveNivelAlto (double nivel, double valorBomba)
        {
            if ((nivel >= NIVEL_MAX) && (valorBomba > ACIONAMENTO_SEGURANCA))
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(ACIONAMENTO_SEGURANCA.ToString());
                    pnlChaveSeguranca.Visible = true;
                    hsbBomba.Value = ACIONAMENTO_SEGURANCA;
                    lblTeste.Text = ACIONAMENTO_SEGURANCA.ToString();
                    return true;
                }
            }
            else
            {
                pnlChaveSeguranca.Visible = false;
            }

            return false;
        }

        private double ConversaoBomba(double valorBomba)
        {
            valorBomba = (valorBomba - 80) / 1.75;

            if (valorBomba < 0)
            {
                return 0;
            }
            else if (valorBomba > 100)
            {
                return 100;
            }
            return valorBomba;
        }

        private void DadoSerialRecebido(object sender, EventArgs e)
        {
            tratarLeitura += leituraBombaSensor;

            TratarLeituraSerial(tratarLeitura);
            PrintTanque(); // função que mostra a imagem do tanque
        }

        private void TratarLeituraSerial(string leituraSerial)
        {
            int firstOpen = tratarLeitura.IndexOf("[");
            int firstClose = tratarLeitura.IndexOf("]");

            if (firstClose > firstOpen)
            {
                string[] dados = tratarLeitura.Substring(firstOpen + 1, (firstClose - firstOpen - 1)).Split('/');

                nivelCm = Double.Parse(dados[0]);
                nivelCm = nivelCm / 100;
                valorBomba = this.ConversaoBomba(Double.Parse(dados[1].Replace(".", ",")));

                Console.WriteLine("nivelCm = " + nivelCm);
                Console.WriteLine("valorBomba = " + valorBomba);

                this.ChaveNivelAlto(nivelCm, valorBomba);

                lblBomba.Text = valorBomba.ToString("N2") + " %";
                lblNivelSensor.Text = nivelCm.ToString("N2") + " cm";
                lblSetPoint.Text = setPoint + " cm";
                mostrarTanque = nivelCm; //dados[0]
                tratarLeitura = tratarLeitura.Remove(firstOpen, firstClose + 1);

                chartNivel.Series[0].Points.AddXY(sample, nivelCm);
                chartNivel.Series[1].Points.AddXY(sample, setPoint);
                chartBomba.Series[0].Points.AddXY(1 + sample++, valorBomba);
            }
        }

        private void PrintTanque()
        {
            if (mostrarTanque > 0 && mostrarTanque <= 100)
            {
                if (mostrarTanque > 10)
                {
                    pictureBox5.Height = 0;
                }
                else
                {
                    Double perc = 1 - mostrarTanque / 10;
                    pictureBox5.Height = Convert.ToInt32(166 * perc);
                }
            }
            else
            {
                pictureBox5.Height = 166;
            }

            if (mostrarTanque > 10 && mostrarTanque <= 70)
            {
                if (mostrarTanque > 20)
                {
                    pictureBox4.Height = 0;
                }
                else
                {
                    Double perc = 1 - (mostrarTanque - 10) / 10;
                    pictureBox4.Height = Convert.ToInt32(167 * perc);
                }
            }
            else
            {
                pictureBox4.Height = 167;
            }

            if (mostrarTanque > 20 && mostrarTanque <= 70)
            {
                Double perc = 1 - (mostrarTanque - 20) / 12;
                pictureBox3.Height = Convert.ToInt32(199 * perc);
            }
            
            else
            {
                pictureBox3.Height = 199;
            }
        }

        private void Form1_Load(object sender, EventArgs e){
            AtualizaListaCOMs();

            chartNivel.Series[0].Points.AddXY(10, 30);
            chartBomba.Series[0].Points.AddXY(10,100);

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e){
            AtualizaListaCOMs();
        }

        private void hScrollBarBomba_Scroll(object sender, ScrollEventArgs e){
            lblTeste.Text = hsbBomba.Value.ToString() + " %";
        }

        private void btnBomba_Click(object sender, EventArgs e){
            if (serialPort1.IsOpen){
                serialPort1.Write("B"+hsbBomba.Value.ToString());
            }
        }

        private void btnSalvarArquivo(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                int npNivel = chartNivel.Series[0].Points.Count;

                FileStream fs = new FileStream(saveFile.FileName, FileMode.Create); //Cria um stream usando o nome do arquivo
                StreamWriter writer = new StreamWriter(fs); //Cria um escrito que irá escrever no stream

                for (int i = 0; i < npNivel; i++)
                {
                    double x = chartNivel.Series[0].Points[i].XValue;
                    double[] w = chartNivel.Series[1].Points[i].YValues;
                    double[] y = chartNivel.Series[0].Points[i].YValues;
                    double[] z = chartBomba.Series[0].Points[i].YValues;

                    //escreve o conteúdo da caixa de texto no stream
                    writer.Write(w[0].ToString() + ' ' + y[0].ToString().Replace(',','.') + ' ' + z[0].ToString() + "\n");
                }
                writer.Close(); //fecha o escrito e o stream 
            }
        }

        private void ClearChartSeries()
        {
            this.chartNivel.Series[NIVEL_SERIE].Points.Clear();
            this.chartNivel.Series[SP_SERIE].Points.Clear();
            this.chartBomba.Series[BOMBA_SERIE].Points.Clear();
        }                

        private void btnOpenArquivo_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string linha;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "TXT files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ClearChartSeries();

                string arquivo = openFileDialog1.FileName;
                StreamReader texto = new StreamReader(arquivo);
                
                while ((linha = texto.ReadLine()) != null)
                {
                    string[] dados = linha.Split(' ');
                    chartNivel.Series[1].Points.AddY(dados[0]);
                    chartNivel.Series[0].Points.AddY(dados[1]);
                    chartBomba.Series[0].Points.AddY(dados[2]);
                }
            }
        }

        private void ajustarParâmetrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConversao conversao = new frmConversao(this);
            conversao.Show();
        }

        private void btnSetPoint_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("S" + txtSetPoint.Text);
            }
            setPoint = Convert.ToInt32(txtSetPoint.Text);
        }

        private void radioButtonManual_CheckedChanged(object sender, EventArgs e)
        {
            this.chartNivel.Series[1].Enabled = !this.radManual.Checked;

            //*****************************AJEITAR
            desabilitaGroupBox2();
        }

        private void radioButtonPid_CheckedChanged(object sender, EventArgs e)
        {
            this.btnBomba.Enabled = !this.radPid.Checked;
            this.hsbBomba.Enabled = !this.radPid.Checked;
        }

        private void radioButtonFuzzy_CheckedChanged(object sender, EventArgs e)
        {
            this.btnBomba.Enabled = !this.radFuzzy.Checked;
            this.hsbBomba.Enabled = !this.radFuzzy.Checked;

            //*****************************AJEITAR
            desabilitaGroupBox2();
        }

        private void desabilitaGroupBox2()
        {
            this.txtKp.Enabled = !this.radManual.Checked;
            this.txtKi.Enabled = !this.radManual.Checked;
            this.txtKd.Enabled = !this.radManual.Checked;
            this.btnParametrosPid.Enabled = !this.radManual.Checked;

            this.txtKp.Enabled = !this.radFuzzy.Checked;
            this.txtKi.Enabled = !this.radFuzzy.Checked;
            this.txtKd.Enabled = !this.radFuzzy.Checked;
            this.btnParametrosPid.Enabled = !this.radFuzzy.Checked;
        
        }
      
        private void btnParametrosPid_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("P" + txtKp.Text + ";" + txtKi.Text + ";" + txtKd.Text);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}