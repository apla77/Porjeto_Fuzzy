namespace TanqueTeste01
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btConectar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.hScrollBarBomba = new System.Windows.Forms.HScrollBar();
            this.btnBomba = new System.Windows.Forms.Button();
            this.labelSen = new System.Windows.Forms.Label();
            this.chartNivel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartNivelMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chartBomba = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTeste = new System.Windows.Forms.Label();
            this.lblSelecionaPorta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenArquivo = new System.Windows.Forms.Button();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.lblA = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.btnEnviarAB = new System.Windows.Forms.Button();
            this.lblBomba = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartNivel)).BeginInit();
            this.chartNivelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBomba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btConectar
            // 
            this.btConectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConectar.Location = new System.Drawing.Point(27, 101);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(114, 23);
            this.btConectar.TabIndex = 0;
            this.btConectar.Text = "Conectar";
            this.btConectar.UseVisualStyleBackColor = true;
            this.btConectar.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(27, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseClick);
            // 
            // btEnviar
            // 
            this.btEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnviar.Location = new System.Drawing.Point(155, 101);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(75, 23);
            this.btEnviar.TabIndex = 2;
            this.btEnviar.Text = "Iniciar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // hScrollBarBomba
            // 
            this.hScrollBarBomba.Location = new System.Drawing.Point(27, 147);
            this.hScrollBarBomba.Maximum = 109;
            this.hScrollBarBomba.Name = "hScrollBarBomba";
            this.hScrollBarBomba.Size = new System.Drawing.Size(185, 23);
            this.hScrollBarBomba.TabIndex = 5;
            this.hScrollBarBomba.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarBomba_Scroll);
            // 
            // btnBomba
            // 
            this.btnBomba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBomba.Location = new System.Drawing.Point(108, 186);
            this.btnBomba.Name = "btnBomba";
            this.btnBomba.Size = new System.Drawing.Size(75, 23);
            this.btnBomba.TabIndex = 6;
            this.btnBomba.Text = "Bomba";
            this.btnBomba.UseVisualStyleBackColor = true;
            this.btnBomba.Click += new System.EventHandler(this.btnBomba_Click);
            // 
            // labelSen
            // 
            this.labelSen.AutoSize = true;
            this.labelSen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSen.Location = new System.Drawing.Point(87, 323);
            this.labelSen.Name = "labelSen";
            this.labelSen.Size = new System.Drawing.Size(40, 16);
            this.labelSen.TabIndex = 7;
            this.labelSen.Text = "0 cm";
            // 
            // chartNivel
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "amostras";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Title = "nível (cm)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chartNivel.ChartAreas.Add(chartArea1);
            this.chartNivel.ContextMenuStrip = this.chartNivelMenu;
            this.chartNivel.Location = new System.Drawing.Point(287, 10);
            this.chartNivel.Name = "chartNivel";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Nível";
            this.chartNivel.Series.Add(series1);
            this.chartNivel.Size = new System.Drawing.Size(513, 252);
            this.chartNivel.TabIndex = 8;
            this.chartNivel.Text = "Nível do Tanque";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Nível do Tanque";
            this.chartNivel.Titles.Add(title1);
            // 
            // chartNivelMenu
            // 
            this.chartNivelMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.chartNivelMenu.Name = "chartNivelMenu";
            this.chartNivelMenu.Size = new System.Drawing.Size(106, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.toolStripMenuItem1.Text = "Salvar";
            // 
            // chartBomba
            // 
            chartArea2.AxisX.Title = "amostras";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.Title = "acionamento (%)";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.Name = "ChartArea1";
            this.chartBomba.ChartAreas.Add(chartArea2);
            this.chartBomba.Location = new System.Drawing.Point(287, 268);
            this.chartBomba.Name = "chartBomba";
            series2.BorderColor = System.Drawing.Color.White;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Green;
            series2.LabelBorderWidth = 2;
            series2.MarkerColor = System.Drawing.Color.Transparent;
            series2.Name = "Nível";
            this.chartBomba.Series.Add(series2);
            this.chartBomba.Size = new System.Drawing.Size(513, 252);
            this.chartBomba.TabIndex = 10;
            this.chartBomba.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Acionamento da Bomba";
            this.chartBomba.Titles.Add(title2);
            // 
            // lblTeste
            // 
            this.lblTeste.AutoSize = true;
            this.lblTeste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeste.Location = new System.Drawing.Point(228, 154);
            this.lblTeste.Name = "lblTeste";
            this.lblTeste.Size = new System.Drawing.Size(29, 16);
            this.lblTeste.TabIndex = 11;
            this.lblTeste.Text = "0%";
            // 
            // lblSelecionaPorta
            // 
            this.lblSelecionaPorta.AutoSize = true;
            this.lblSelecionaPorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelecionaPorta.Location = new System.Drawing.Point(24, 27);
            this.lblSelecionaPorta.Name = "lblSelecionaPorta";
            this.lblSelecionaPorta.Size = new System.Drawing.Size(88, 16);
            this.lblSelecionaPorta.TabIndex = 12;
            this.lblSelecionaPorta.Text = "Porta serial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sensor:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(405, 537);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(112, 23);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "Salvar Dados";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFile
            // 
            this.saveFile.DefaultExt = "\".txt\"";
            this.saveFile.Filter = "Dados Experimentais (.txt)|*.txt";
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // btnOpenArquivo
            // 
            this.btnOpenArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenArquivo.Location = new System.Drawing.Point(550, 537);
            this.btnOpenArquivo.Name = "btnOpenArquivo";
            this.btnOpenArquivo.Size = new System.Drawing.Size(112, 23);
            this.btnOpenArquivo.TabIndex = 20;
            this.btnOpenArquivo.Text = "Abrir Dados";
            this.btnOpenArquivo.UseVisualStyleBackColor = true;
            this.btnOpenArquivo.Click += new System.EventHandler(this.btnOpenArquivo_Click);
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(93, 228);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(41, 20);
            this.textBoxA.TabIndex = 21;
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblA.Location = new System.Drawing.Point(28, 229);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(59, 16);
            this.lblA.TabIndex = 22;
            this.lblA.Text = "Valor A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(151, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Valor B";
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(216, 229);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(41, 20);
            this.textBoxB.TabIndex = 23;
            // 
            // btnEnviarAB
            // 
            this.btnEnviarAB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarAB.Location = new System.Drawing.Point(108, 268);
            this.btnEnviarAB.Name = "btnEnviarAB";
            this.btnEnviarAB.Size = new System.Drawing.Size(75, 24);
            this.btnEnviarAB.TabIndex = 25;
            this.btnEnviarAB.Text = "Enviar";
            this.btnEnviarAB.UseVisualStyleBackColor = true;
            this.btnEnviarAB.Click += new System.EventHandler(this.btnEnviarAB_Click);
            // 
            // lblBomba
            // 
            this.lblBomba.AutoSize = true;
            this.lblBomba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBomba.Location = new System.Drawing.Point(229, 323);
            this.lblBomba.Name = "lblBomba";
            this.lblBomba.Size = new System.Drawing.Size(33, 16);
            this.lblBomba.TabIndex = 28;
            this.lblBomba.Text = "0 %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Bomba:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TanqueTeste01.Properties.Resources.Capturar11;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, 358);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 202);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.InitialImage")));
            this.pictureBox5.Location = new System.Drawing.Point(867, 376);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(83, 166);
            this.pictureBox5.TabIndex = 33;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.InitialImage")));
            this.pictureBox4.Location = new System.Drawing.Point(860, 209);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(98, 167);
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.InitialImage")));
            this.pictureBox3.Location = new System.Drawing.Point(851, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(116, 199);
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Image = global::TanqueTeste01.Properties.Resources.tanque05;
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(817, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(154, 541);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(985, 574);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBomba);
            this.Controls.Add(this.btnEnviarAB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.btnOpenArquivo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSelecionaPorta);
            this.Controls.Add(this.lblTeste);
            this.Controls.Add(this.chartBomba);
            this.Controls.Add(this.chartNivel);
            this.Controls.Add(this.labelSen);
            this.Controls.Add(this.btnBomba);
            this.Controls.Add(this.hScrollBarBomba);
            this.Controls.Add(this.btEnviar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btConectar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartNivel)).EndInit();
            this.chartNivelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBomba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConectar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btEnviar;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.HScrollBar hScrollBarBomba;
        private System.Windows.Forms.Button btnBomba;
        private System.Windows.Forms.Label labelSen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNivel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBomba;
        private System.Windows.Forms.Label lblTeste;
        private System.Windows.Forms.Label lblSelecionaPorta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.ContextMenuStrip chartNivelMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

        string leituraBombaSersor;
        string iniciarParar = "300";
        bool requested = false;
        double valorA = 0.1283;
        double valorB = 2.9587;
        int sample = 0;

        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnOpenArquivo;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.Button btnEnviarAB;
        private System.Windows.Forms.Label lblBomba;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

