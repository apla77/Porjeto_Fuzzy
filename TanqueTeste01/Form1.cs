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
using System.Threading;

namespace TanqueTeste01 {
    public enum TipoParametro
    {
        PA,
        PB
    };

    public partial class frmPrincipal : Form
    {
        public frmPrincipal(){     
            InitializeComponent();
            btnStart.Enabled = false;
            btnPump.Enabled = false;
            btnSaveData.Enabled = false;
            this.groupBox2.Enabled = false;
            btnSetPidParameters.Enabled = true;
            txtKp.Enabled = true;
            txtKi.Enabled = true;
            txtKd.Enabled = true;
        }

        public void SetParametro(TipoParametro tp, double valor)
        {
            if (tp == TipoParametro.PA)
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
            if (tp == TipoParametro.PA)
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
                    btnConnect.Text = "Desconectar";
                    cboPortaSerial.Enabled = false;
                    btnStart.Enabled = true;
                    this.groupBox2.Enabled = true;
                    //this.btnSetPidParameters.Enabled = false;
                }
            }
            else
            {
                try
                {
                    serialPort1.Close();
                    cboPortaSerial.Enabled = true;
                    btnConnect.Text = "Conectar";
                    btnStart.Enabled = false;
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
                serialPort1.Close();                        //fecha a porta
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (btnStart.Text == "Iniciar")
                {
                    this.ligarSistema();
                }
                else
                {
                    this.desligarSistema();
                    btnClearGraph.Enabled = true;
                }
            }
        }

        private void ligarSistema()
        {
            ClearChartSeries();
            serialPort1.DiscardOutBuffer();
            serialPort1.DiscardInBuffer();
            serialPort1.Write(iniciarComunicacao);
            chtLevel.Series[0].Points.Clear();
            chtPump.Series[0].Points.Clear();
            btnStart.Text = "Parar";
            ajustarParametrosToolStripMenuItem.Enabled = false;
            btnConnect.Enabled = false;
            btnSaveData.Enabled = false;
            btnPump.Enabled = true;
            btnOpenData.Enabled = false;
            requested = true;
            btnClearGraph.Enabled = false;
            sample = 0;
        }

        private void desligarSistema()
        {
            serialPort1.DiscardOutBuffer();
            serialPort1.Write(finalizarComunicacao);
            btnStart.Text = "Iniciar";
            btnConnect.Enabled = true;
            btnSaveData.Enabled = true;
            btnClearGraph.Enabled = true;
            ajustarParametrosToolStripMenuItem.Enabled = true;
            btnPump.Enabled = false;
            requested = false;
            pidAutomatico = false;
            btnOpenData.Enabled = true;
            //*****************************AJEITAR
            //this.groupBox2.Enabled = false;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e){
            if (requested){
                leituraBombaSensor = (string)serialPort1.ReadExisting();    //ler o dado disponível na serial   
                this.Invoke(new EventHandler(DadoSerialRecebido));           //chama outra thread para escrever 
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
                valorBomba = this.ConversaoBomba(Double.Parse(dados[1]));

                lblBomba.Text = valorBomba.ToString("N2") + " %";
                lblNivelSensor.Text = nivelCm.ToString("N2") + " cm";
                lblSetPoint.Text = setPoint + " cm";
                mostrarTanque = nivelCm; //dados[0]
                tratarLeitura = tratarLeitura.Remove(firstOpen, firstClose + 1);

                chtLevel.Series[0].Points.AddXY(this.sample, nivelCm);
                chtLevel.Series[1].Points.AddXY(this.sample, setPoint);
                chtPump.Series[0].Points.AddXY(this.sample++, valorBomba);  
                  
                if (this.pidAutomatico)    
                {
                    this.contadorPid = 0;  
                    if (this.contI < this.tamLista) 
                    {
                        string[] dado = experimento[this.contI].Split(' ');
                        valSetpoint = Int32.Parse(dado[1]);
                        this.pidAutomatico = false;
                        this.contI++;
                        SetSetPoint(dado[0]);  
                        this.setPoint = Convert.ToInt32(dado[0]);
                        this.chtLevel.Series[1].Enabled = this.radManual.Checked;
                    }
                    else
                    {
                        this.contI = 0;
                        this.pidAutomatico = false;
                        this.desligarSistema();
                        contadorPid = 0; 
                    }
                }
                if(this.valSetpoint == this.contadorPid && this.contadorPid > 0)
                {
                    this.pidAutomatico = true;
                    this.contadorPid = 0;  
                }
                this.contadorPid++; 
            }
            lblAmostras.Text = "Total de amostras " + contadorPid;
            this.erro.Text = "Erro: " + (setPoint - nivelCm).ToString("N2");
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

            chtLevel.Series[0].Points.AddXY(10, 30);
            chtPump.Series[0].Points.AddXY(10,100);

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e){
            AtualizaListaCOMs();
        }

        private void hScrollBarBomba_Scroll(object sender, ScrollEventArgs e){
            lblTeste.Text = hsbPump.Value.ToString() + " %";
        }

        private void btnBomba_Click(object sender, EventArgs e){
            if (serialPort1.IsOpen){
                serialPort1.Write("B"+hsbPump.Value.ToString());
            }
        }

        private void btnSalvarArquivo(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                int npNivel = chtLevel.Series[0].Points.Count;

                FileStream fs = new FileStream(saveFile.FileName, FileMode.Create); //Cria um stream usando o nome do arquivo
                StreamWriter writer = new StreamWriter(fs); //Cria um escrito que irá escrever no stream

                for (int i = 0; i < npNivel; i++)
                {
                    double x = chtLevel.Series[0].Points[i].XValue;
                    double[] w = chtLevel.Series[1].Points[i].YValues;
                    double[] y = chtLevel.Series[0].Points[i].YValues;
                    double[] z = chtPump.Series[0].Points[i].YValues;

                    //escreve o conteúdo da caixa de texto no stream
                    writer.Write(w[0].ToString() + ' ' + y[0].ToString().Replace(',','.') + ' ' + z[0].ToString().Replace(',', '.') + "\n");
                }
                writer.Close(); //fecha o escrito e o stream 
            }
        }

        private void ClearChartSeries()
        {
            this.chtLevel.Series[NIVEL_SERIE].Points.Clear();
            this.chtLevel.Series[SP_SERIE].Points.Clear();
            this.chtPump.Series[BOMBA_SERIE].Points.Clear();
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
                    chtLevel.Series[1].Points.AddY(dados[0]);
                    chtLevel.Series[0].Points.AddY(dados[1]);
                    chtPump.Series[0].Points.AddY(dados[2]);
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
            this.SetSetPoint(txtSetPoint.Text);
        }

        private void SetSetPoint(string sp)
        {
            if (serialPort1.IsOpen) 
            {
                serialPort1.Write("S" + sp);
            }
            this.setPoint = Convert.ToInt32(sp);
        }

        private void radioButtonManual_CheckedChanged(object sender, EventArgs e)
        {
            this.chtLevel.Series[1].Enabled = !this.radManual.Checked;
            //*****************************AJEITAR
            desabilitaGroupBox2();
            btnSetPidParameters.Enabled = !this.radManual.Checked;
        }

        private void radioButtonPid_CheckedChanged(object sender, EventArgs e)
        {
            this.btnPump.Enabled = !this.radPid.Checked;
            this.hsbPump.Enabled = !this.radPid.Checked;
        }

        private void radioButtonFuzzy_CheckedChanged(object sender, EventArgs e)
        {
            this.btnPump.Enabled = !this.radFuzzy.Checked;
            this.hsbPump.Enabled = !this.radFuzzy.Checked;

            //*****************************AJEITAR
            desabilitaGroupBox2();
        }

        private void desabilitaGroupBox2()
        {
            this.txtKp.Enabled = !this.radManual.Checked;
            this.txtKi.Enabled = !this.radManual.Checked;
            this.txtKd.Enabled = !this.radManual.Checked;
            this.btnSetPidParameters.Enabled = !this.radManual.Checked;

            this.txtKp.Enabled = !this.radFuzzy.Checked;
            this.txtKi.Enabled = !this.radFuzzy.Checked;
            this.txtKd.Enabled = !this.radFuzzy.Checked;
            this.btnSetPidParameters.Enabled = !this.radFuzzy.Checked;        
        }
      
        private void btnParametrosPid_Click(object sender, EventArgs e)
        {
            this.SetPidParameters(this.txtKp.Text, this.txtKi.Text, this.txtKd.Text);
        }

        private void SetPidParameters(string Kp, string Ki, string Kd)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("P" + Kp + ";" + Ki + ";" + Kd);
            }
        }
        private void AutomaticTest(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string linha;
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "TXT files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string arquivo = openFileDialog1.FileName;
                StreamReader texto = new StreamReader(arquivo);
                
                experimento.Clear();
                while ((linha = texto.ReadLine()) != null)
                {
                    this.experimento.Add(linha);
                    this.tamLista++;
                }
                this.ClearChartSeries();
                this.sample = 0;

                this.pidAutomatico = true;
                this.btnSetPidParameters.PerformClick();
                Thread.Sleep(500);
                
                this.btnStart.PerformClick();
                
               
            }
        }

        private void LimparChartNivel_Click(object sender, EventArgs e)
        {
            if(!this.requested)
            { 
                this.ClearChartSeries();
                this.chtLevel.Series[0].Points.AddXY(10, 30);
                this.chtPump.Series[0].Points.AddXY(10, 100);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja limpar os gráficos e descartar os dados?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.ClearChartSeries();
                this.chtLevel.Series[0].Points.AddXY(10, 30);
                this.chtPump.Series[0].Points.AddXY(10, 100);
                this.desligarSistema();
            }
        }
    }
}