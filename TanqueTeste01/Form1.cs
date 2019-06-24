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
    public partial class Form1 : Form
    {
        int motor;

        public Form1(){     
            InitializeComponent();
            btEnviar.Enabled = false;
            btnBomba.Enabled = false;
            btnSalvar.Enabled = false; 
        }

        private void atualizaListaCOMs(){
            int i;
            bool quantDiferente; //flag para sinalizar que a quantidade de portas mudou

            i = 0;
            quantDiferente = false;

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
            if (serialPort1.IsOpen == true)  // se porta aberta
                serialPort1.Close();         //fecha a porta
        }

        private void btEnviar_Click(object sender, EventArgs e) {
            if(serialPort1.IsOpen){
                if (btEnviar.Text == "Iniciar"){
                    serialPort1.DiscardOutBuffer();
                    serialPort1.DiscardInBuffer();
                    iniciarParar = "300";
                    serialPort1.Write(iniciarParar);
                    chartNivel.Series[0].Points.Clear();
                    chartBomba.Series[0].Points.Clear();
                    btEnviar.Text = "Parar";
                    btConectar.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnBomba.Enabled = true;
                    requested = true;
                    sample = 0;

                }else {
                    serialPort1.DiscardOutBuffer();
                    iniciarParar = "200";
                    serialPort1.Write(iniciarParar);
                    btEnviar.Text = "Iniciar";
                    btConectar.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnBomba.Enabled = false;
                    requested = true;   
                }
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e){
            if (requested){
                leituraBombaSersor = (string)serialPort1.ReadExisting();              //ler o dado disponível na serial   
                this.Invoke(new EventHandler(TrataDadoRecebido));           //chama outra thread para escrever 
            }
        }

        Double mostrarTanque = 0; // Recebe o valor sensor 
        string aux = "";
        private void TrataDadoRecebido(object sender, EventArgs e){
            textBoxReceber.AppendText(leituraBombaSersor);
            aux += leituraBombaSersor;
            
            int firstOpen = aux.IndexOf("[");
            int firstClose = aux.IndexOf("]");

            if (firstClose > firstOpen) {
                string[] dados = aux.Substring(firstOpen + 1, (firstClose - firstOpen - 1)).Split('/');

                Double relacaoNivel = Double.Parse(dados[0]) * valorA - valorB;         // 0.1205 - 3.2624;

                labelSen.Text = relacaoNivel.ToString("F2");
                //labelSen.Text = dados[0];
                mostrarTanque = relacaoNivel; //dados[0]
                labelBom.Text = dados[1];
                aux = aux.Remove(firstOpen, firstClose + 1);

                chartNivel.Series[0].Points.AddXY(sample, relacaoNivel);
                chartBomba.Series[0].Points.AddXY(sample++, Double.Parse(dados[1].Replace(".",",")));

                Tanque(); // função que mostra a imagem do tanque
            }
        }

        private void Tanque()
        {
            if (mostrarTanque > 0 && mostrarTanque <= 35)
            {
                if (mostrarTanque > 10)
                {
                    picSecaoInferior.Height = 0;
                }
                else
                {
                    Double perc = 1 - mostrarTanque / 10;
                    picSecaoInferior.Height = Convert.ToInt32(83 * perc);
                }
            }
            else
            {
                picSecaoInferior.Height = 83;
            }

            if (mostrarTanque > 10 && mostrarTanque <= 35)
            {
                if (mostrarTanque > 20)
                {
                    picSecaoIntermediaria.Height = 0;
                }
                else
                {
                    Double perc = 1 - (mostrarTanque - 10) / 10;
                    picSecaoIntermediaria.Height = Convert.ToInt32(84 * perc);
                }
            }
            else
            {
                picSecaoIntermediaria.Height = 84;
            }

            if (mostrarTanque > 20 && mostrarTanque <= 35)
            {
                Double perc = 1 - (mostrarTanque - 20) / 10;
                picSecaoSuperior.Height = Convert.ToInt32(100 * perc);
            }
            else
            {
                picSecaoSuperior.Height = 100;
            } 

            Console.WriteLine("valor p2 = " + picSecaoInferior.Height);
            Console.WriteLine("valor p3 = " + picSecaoIntermediaria.Height);
            Console.WriteLine("valor p4 = " + picSecaoSuperior.Height);
            Console.WriteLine("mostrar  = " + mostrarTanque);
        }

        private void Form1_Load(object sender, EventArgs e){
            atualizaListaCOMs();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e){
            atualizaListaCOMs();
        }

        private void hScrollBarBomba_Scroll(object sender, ScrollEventArgs e){
            lblTeste.Text = hScrollBarBomba.Value.ToString() + " %";
        }

        private void btnBomba_Click(object sender, EventArgs e){
            if (serialPort1.IsOpen){
                serialPort1.Write(hScrollBarBomba.Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e){
            if (saveFile.ShowDialog() == DialogResult.OK){
                int npNivel = chartNivel.Series[0].Points.Count;

                textBoxReceber.Text = saveFile.FileName.ToUpper() + "\n";

                FileStream fs = new FileStream(saveFile.FileName, FileMode.Create); //Cria um stream usando o nome do arquivo
                StreamWriter writer = new StreamWriter(fs); //Cria um escrito que irá escrever no stream
              //  writer.Write("X" + "\t" + "Y" + "\t" + "Z" + "\n"); //escreve o conteúdo da caixa de texto no stream

                for (int i = 0; i < npNivel; i++){
                    double x = chartNivel.Series[0].Points[i].XValue;
                    double[] y = chartNivel.Series[0].Points[i].YValues;
                    double[] z = chartBomba.Series[0].Points[i].YValues; 

                    textBoxReceber.AppendText(x.ToString() + "\t" + y[0].ToString() + "\t" + z[0].ToString() + "\n"); // enviar para arquivo

                    //escreve o conteúdo da caixa de texto no stream
                    writer.Write(y[0].ToString() + '-' + z[0].ToString() + "\n");
                }
                writer.Close(); //fecha o escrito e o stream 
            }
        }

        private void button1_Click_1(object sender, EventArgs e){
            
            if (picSecaoInferior.Height > 0){
                picSecaoInferior.Height = picSecaoInferior.Height - 5;
            }
            else if (picSecaoIntermediaria.Height >= 4 && picSecaoInferior.Height == 0){
                picSecaoIntermediaria.Height = picSecaoIntermediaria.Height - 5;
            }
            else if (picSecaoSuperior.Height >= 7 && picSecaoIntermediaria.Height < 4)
            {
                picSecaoSuperior.Height = picSecaoSuperior.Height - 5;
            }
            else{
                picSecaoInferior.Height = 81;
                picSecaoIntermediaria.Height = 84;
                picSecaoSuperior.Height = 100;
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
                    string[] dados = linha.Split('-');
                    chartNivel.Series[0].Points.AddY(dados[0]);
                    chartBomba.Series[0].Points.AddY(dados[1]);
                }
            }

        }

        private void btnEnviarAB_Click(object sender, EventArgs e)
        {
            valorA = Double.Parse(textBoxA.Text);
            valorB = Double.Parse(textBoxB.Text);
        }
    }
}