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
            btEnviar.Enabled = false;
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
            if (comboBox1.Items.Count == SerialPort.GetPortNames().Length) {
                foreach (string s in SerialPort.GetPortNames()) {
                    if (comboBox1.Items[i++].Equals(s) == false) {
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
            comboBox1.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames()) {
                comboBox1.Items.Add(s);
            }
            //seleciona a primeira posição da lista
            comboBox1.SelectedIndex = 0;
        }

        private void btConectar_Click(object sender, EventArgs e){
            if (serialPort1.IsOpen == false){
                try {
                    serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    serialPort1.Open();
                }
                catch{
                    return;
                }
                if (serialPort1.IsOpen) {
                    btConectar.Text = "Desconectar";
                    comboBox1.Enabled = false;
                    btEnviar.Enabled = true;   
                }
            }
            else{
                try {
                    serialPort1.Close();
                    comboBox1.Enabled = true;
                    btConectar.Text = "Conectar";
                    btEnviar.Enabled = false;
                }
                catch {
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
                if (btEnviar.Text == "Iniciar"){
                    serialPort1.DiscardOutBuffer();
                    serialPort1.DiscardInBuffer();
                    serialPort1.Write(iniciarComunicacao);
                    chartNivel.Series[0].Points.Clear();
                    chartBomba.Series[0].Points.Clear();
                    btEnviar.Text = "Parar";
                    ajustarParâmetrosToolStripMenuItem.Enabled = false;
                    btConectar.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnBomba.Enabled = true;
                    requested = true;
                    sample = 0;

                }else {
                    serialPort1.DiscardOutBuffer();
                    serialPort1.Write(finalizarComunicacao);
                    btEnviar.Text = "Iniciar";
                    btConectar.Enabled = true;
                    btnSalvar.Enabled = true;
                    ajustarParâmetrosToolStripMenuItem.Enabled = true;
                    btnBomba.Enabled = false;
                    requested = false;   
                }
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e){
            if (requested){
                leituraBombaSersor = (string)serialPort1.ReadExisting();    //ler o dado disponível na serial   
                this.Invoke(new EventHandler(TrataDadoRecebido));           //chama outra thread para escrever 
            }
        }

        private void ChaveNivelAlto (double nivel, double valorBomba)
        {
            if ((nivel >= NIVEL_MAX) && (valorBomba > ACIONAMENTO_SEGURANCA))
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(ACIONAMENTO_SEGURANCA.ToString());
                }
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
            aux += leituraBombaSersor;

            int firstOpen = aux.IndexOf("[");
            int firstClose = aux.IndexOf("]");

            if (firstClose > firstOpen)
            {
                string[] dados = aux.Substring(firstOpen + 1, (firstClose - firstOpen - 1)).Split('/');

                relacaoNivel = Double.Parse(dados[0]) * this.GetParametro(TipoParametro.enPA) - this.GetParametro(TipoParametro.enPB);          // 0.1205 - 3.2624;                

                valorBomba = this.ConversaoBomba(Double.Parse(dados[1].Replace(".", ",")));

                this.ChaveNivelAlto(relacaoNivel, valorBomba);

                lblBomba.Text = valorBomba.ToString() + " %";
                labelSen.Text = relacaoNivel.ToString("F2") + " cm";
                mostrarTanque = relacaoNivel; //dados[0]
                aux = aux.Remove(firstOpen, firstClose + 1);

                chartNivel.Series[0].Points.AddXY(sample, relacaoNivel);
                chartBomba.Series[0].Points.AddXY(1 + sample++, valorBomba);

                Console.WriteLine(Double.Parse(dados[0]));

                Tanque(); // função que mostra a imagem do tanque
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

            //chartNivel.Series[0].Points.AddXY(10, 30);
            //chartBomba.Series[0].Points.AddXY(10,100);

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

                //textBoxReceber.Text = saveFile.FileName.ToUpper() + "\n";

                FileStream fs = new FileStream(saveFile.FileName, FileMode.Create); //Cria um stream usando o nome do arquivo
                StreamWriter writer = new StreamWriter(fs); //Cria um escrito que irá escrever no stream
                                                            //  writer.Write("X" + "\t" + "Y" + "\t" + "Z" + "\n"); //escreve o conteúdo da caixa de texto no stream

                for (int i = 0; i < npNivel; i++)
                {
                    double x = chartNivel.Series[0].Points[i].XValue;
                    double[] y = chartNivel.Series[0].Points[i].YValues;
                    double[] z = chartBomba.Series[0].Points[i].YValues;

                    //textBoxReceber.AppendText(x.ToString() + "\t" + y[0].ToString() + "\t" + z[0].ToString() + "\n"); // enviar para arquivo

                    //escreve o conteúdo da caixa de texto no stream
                    writer.Write(y[0].ToString().Replace(',','.') + ' ' + z[0].ToString() + "\n");
                }
                writer.Close(); //fecha o escrito e o stream 
            }
        }


        private void btnOpenArquivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string linha;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "TXT files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string arquivo = openFileDialog1.FileName;
                StreamReader texto = new StreamReader(arquivo);
                
                while ((linha = texto.ReadLine()) != null)
                {
                    string[] dados = linha.Split(' ');
                    chartNivel.Series[0].Points.AddY(dados[0]);
                    chartBomba.Series[0].Points.AddY(dados[1]);
                }
            }
        }

        private void ajustarParâmetrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConversao conversao = new frmConversao(this);
            conversao.Show();
        }

    }
}