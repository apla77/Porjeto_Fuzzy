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
            btnEnviar.Enabled = false;
            btnBomba.Enabled = false;
            btnSalvar.Enabled = false; 
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
                    btConectar.Text = "Desconectar";
                    cboPortaSerial.Enabled = false;
                    btnEnviar.Enabled = true;
                }
            }
            else
            {
                try
                {
                    serialPort1.Close();
                    cboPortaSerial.Enabled = true;
                    btConectar.Text = "Conectar";
                    btnEnviar.Enabled = false;
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

        private void btEnviar_Click(object sender, EventArgs e) {
            if(serialPort1.IsOpen){
                if (btnEnviar.Text == "Iniciar"){
                    serialPort1.DiscardOutBuffer();
                    serialPort1.DiscardInBuffer();
                    serialPort1.Write(iniciarComunicacao);
                    chartNivel.Series[0].Points.Clear();
                    chartBomba.Series[0].Points.Clear();
                    btnEnviar.Text = "Parar";
                    ajustarParametrosToolStripMenuItem.Enabled = false;
                    btConectar.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnBomba.Enabled = true;
                    requested = true;
                    radioButtonManual.Checked = true;
                    sample = 0;

                }else {
                    serialPort1.DiscardOutBuffer();
                    serialPort1.Write(finalizarComunicacao);
                    btnEnviar.Text = "Iniciar";
                    btConectar.Enabled = true;
                    btnSalvar.Enabled = true;
                    ajustarParametrosToolStripMenuItem.Enabled = true;
                    btnBomba.Enabled = false;
                    requested = false;
                }
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e){
            if (requested){
                leituraBombaSensor = (string)serialPort1.ReadExisting();    //ler o dado disponível na serial   
                this.Invoke(new EventHandler(TrataDadoRecebido));           //chama outra thread para escrever 
            }
        }
 
        private void ChaveNivelAlto (double nivel, double valorBomba)
        {
            if ((nivel >= NIVEL_MAX) && (valorBomba > ACIONAMENTO_SEGURANCA))
            {
                if (serialPort1.IsOpen)
                {
                    string acionamentoString = ACIONAMENTO_SEGURANCA.ToString();
                    serialPort1.Write(acionamentoString);
                    pnlChaveSeguranca.Visible = true;
                    hScrollBarBomba.Value = ACIONAMENTO_SEGURANCA;
                    lblTeste.Text = acionamentoString;
                }
            }
            else
            {
                pnlChaveSeguranca.Visible = false;
            }
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

        private void TrataDadoRecebido(object sender, EventArgs e)
        {
            tratarLeitura += leituraBombaSensor;

            int firstOpen = tratarLeitura.IndexOf("[");
            int firstClose = tratarLeitura.IndexOf("]");

            if (firstClose > firstOpen)
            {
                string[] dados = tratarLeitura.Substring(firstOpen + 1, (firstClose - firstOpen - 1)).Split('/');

                nivelCm = Double.Parse(dados[0]) * this.GetParametro(TipoParametro.enPA) - this.GetParametro(TipoParametro.enPB);             
                valorBomba = this.ConversaoBomba(Double.Parse(dados[1].Replace(".", ",")));

                this.ChaveNivelAlto(nivelCm, valorBomba);

                lblBomba.Text = valorBomba.ToString() + " %";
                labelSen.Text = nivelCm.ToString("F2") + " cm";
                lblSetPoint.Text = setPoint + " cm";
                mostrarTanque = nivelCm; //dados[0]
                tratarLeitura = tratarLeitura.Remove(firstOpen, firstClose + 1);

                chartNivel.Series[0].Points.AddXY(sample, nivelCm);
                chartNivel.Series[1].Points.AddXY(sample, setPoint);
                chartBomba.Series[0].Points.AddXY(1 + sample++, valorBomba);

                Tanque(); // função que mostra a imagem do tanque

                if (serialPort1.IsOpen && this.radioButtonPid.Checked)
                {
                    int recebePid = ControladorPid();
                    Console.WriteLine("VALOR PID = " + recebePid);
                    serialPort1.Write(recebePid.ToString()); 
                }
            }
        }

        private void Tanque()
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
                Double perc = 1 - (mostrarTanque - 20) / 10;
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
            lblTeste.Text = hScrollBarBomba.Value.ToString() + " %";
        }

        private void btnBomba_Click(object sender, EventArgs e){
            if (serialPort1.IsOpen){
                serialPort1.Write(hScrollBarBomba.Value.ToString());
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
            setPoint = Convert.ToInt32(textBoxSetPoint.Text);
        }

        private void radioButtonManual_CheckedChanged(object sender, EventArgs e)
        {
            this.chartNivel.Series[1].Enabled = !this.radioButtonManual.Checked;
        }

        private void radioButtonPid_CheckedChanged(object sender, EventArgs e)
        {
            this.btnBomba.Enabled = !this.radioButtonPid.Checked;
            this.hScrollBarBomba.Enabled = !this.radioButtonPid.Checked;
        }

        private void radioButtonFuzzy_CheckedChanged(object sender, EventArgs e)
        {
            this.btnBomba.Enabled = !this.radioButtonFuzzy.Checked;
            this.hScrollBarBomba.Enabled = !this.radioButtonFuzzy.Checked;
        }

        private int ControladorPid()
        {
 
               this.erro = this.setPoint - this.nivelCm;
               this.diferencaErro = this.erro - this.erroAnterior;
               this.erroAnterior = this.erro;
               this.somatoriaPid += erro;

                this.resultadoPid = (kp * erro) + (ki * somatoriaPid) + (kd * diferencaErro);

                if(this.resultadoPid > 100)
                {
                    resultadoPid = 100;
                }
                else if(this.resultadoPid < 0)
                {
                    resultadoPid = 0;
                }

                Console.WriteLine("Erro = " + erro + " somatória erros = " + somatoriaPid + " resultado PID = " + resultadoPid);

            return Convert.ToInt32(resultadoPid);   
        }

        private void btnParametrosPid_Click(object sender, EventArgs e)
        {

            this.kp = Double.Parse(textBoxKp.Text);
            this.ki = Double.Parse(textBoxKi.Text);
            this.kd = Double.Parse(textBoxKd.Text);
        }

    }
}