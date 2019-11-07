namespace TanqueTeste01
{
    using System.Collections.Generic;

    partial class frmPrincipal
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.btnConnect = new System.Windows.Forms.Button();
            this.cboPortaSerial = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.hsbPump = new System.Windows.Forms.HScrollBar();
            this.btnPump = new System.Windows.Forms.Button();
            this.lblNivelSensor = new System.Windows.Forms.Label();
            this.chtLevel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartNivelMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LimparChartNivel = new System.Windows.Forms.ToolStripMenuItem();
            this.chtPump = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTeste = new System.Windows.Forms.Label();
            this.lblSelecionaPorta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenData = new System.Windows.Forms.Button();
            this.lblBomba = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajustarParametrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSetPoint = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetPidParameters = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKd = new System.Windows.Forms.TextBox();
            this.txtKi = new System.Windows.Forms.TextBox();
            this.txtKp = new System.Windows.Forms.TextBox();
            this.lblSetPoint = new System.Windows.Forms.Label();
            this.radPid = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radManual = new System.Windows.Forms.RadioButton();
            this.radFuzzy = new System.Windows.Forms.RadioButton();
            this.btnSetPoint = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlChaveSeguranca = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnAutomatic = new System.Windows.Forms.Button();
            this.lblAmostras = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClearGraph = new System.Windows.Forms.Button();
            this.erro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chtLevel)).BeginInit();
            this.chartNivelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtPump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(106, 38);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // cboPortaSerial
            // 
            this.cboPortaSerial.FormattingEnabled = true;
            this.cboPortaSerial.Location = new System.Drawing.Point(14, 40);
            this.cboPortaSerial.Name = "cboPortaSerial";
            this.cboPortaSerial.Size = new System.Drawing.Size(85, 21);
            this.cboPortaSerial.TabIndex = 1;
            this.cboPortaSerial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseClick);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(232, 37);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(66, 25);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // hsbPump
            // 
            this.hsbPump.Location = new System.Drawing.Point(9, 92);
            this.hsbPump.Maximum = 109;
            this.hsbPump.Name = "hsbPump";
            this.hsbPump.Size = new System.Drawing.Size(203, 23);
            this.hsbPump.TabIndex = 5;
            this.hsbPump.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarBomba_Scroll);
            // 
            // btnPump
            // 
            this.btnPump.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPump.Location = new System.Drawing.Point(232, 92);
            this.btnPump.Name = "btnPump";
            this.btnPump.Size = new System.Drawing.Size(66, 23);
            this.btnPump.TabIndex = 6;
            this.btnPump.Text = "Bomba";
            this.btnPump.UseVisualStyleBackColor = true;
            this.btnPump.Click += new System.EventHandler(this.btnBomba_Click);
            // 
            // lblNivelSensor
            // 
            this.lblNivelSensor.AutoSize = true;
            this.lblNivelSensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivelSensor.Location = new System.Drawing.Point(59, 146);
            this.lblNivelSensor.Name = "lblNivelSensor";
            this.lblNivelSensor.Size = new System.Drawing.Size(40, 16);
            this.lblNivelSensor.TabIndex = 7;
            this.lblNivelSensor.Text = "0 cm";
            // 
            // chtLevel
            // 
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisX.Title = "amostras";
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.Interval = 5D;
            chartArea3.AxisY.Maximum = 35D;
            chartArea3.AxisY.Title = "nível (cm)";
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.Name = "ChartArea1";
            this.chtLevel.ChartAreas.Add(chartArea3);
            this.chtLevel.ContextMenuStrip = this.chartNivelMenu;
            this.chtLevel.Location = new System.Drawing.Point(334, 37);
            this.chtLevel.Name = "chtLevel";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Nível";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Red;
            series5.Enabled = false;
            series5.Name = "Set-Pint";
            this.chtLevel.Series.Add(series4);
            this.chtLevel.Series.Add(series5);
            this.chtLevel.Size = new System.Drawing.Size(513, 265);
            this.chtLevel.TabIndex = 8;
            this.chtLevel.Text = "Nível do Tanque";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Text = "Nível do Tanque";
            this.chtLevel.Titles.Add(title3);
            // 
            // chartNivelMenu
            // 
            this.chartNivelMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LimparChartNivel});
            this.chartNivelMenu.Name = "chartNivelMenu";
            this.chartNivelMenu.Size = new System.Drawing.Size(112, 26);
            // 
            // LimparChartNivel
            // 
            this.LimparChartNivel.Name = "LimparChartNivel";
            this.LimparChartNivel.Size = new System.Drawing.Size(111, 22);
            this.LimparChartNivel.Text = "Limpar";
            this.LimparChartNivel.Click += new System.EventHandler(this.LimparChartNivel_Click);
            // 
            // chtPump
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "amostras";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Interval = 20D;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Title = "acionamento (%)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chtPump.ChartAreas.Add(chartArea1);
            this.chtPump.Location = new System.Drawing.Point(334, 313);
            this.chtPump.Name = "chtPump";
            series1.BorderColor = System.Drawing.Color.White;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Green;
            series1.LabelBorderWidth = 2;
            series1.MarkerColor = System.Drawing.Color.Transparent;
            series1.Name = "Bomba";
            this.chtPump.Series.Add(series1);
            this.chtPump.Size = new System.Drawing.Size(513, 263);
            this.chtPump.TabIndex = 10;
            this.chtPump.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Acionamento da Bomba";
            this.chtPump.Titles.Add(title1);
            // 
            // lblTeste
            // 
            this.lblTeste.AutoSize = true;
            this.lblTeste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeste.Location = new System.Drawing.Point(103, 95);
            this.lblTeste.Name = "lblTeste";
            this.lblTeste.Size = new System.Drawing.Size(29, 16);
            this.lblTeste.TabIndex = 11;
            this.lblTeste.Text = "0%";
            // 
            // lblSelecionaPorta
            // 
            this.lblSelecionaPorta.AutoSize = true;
            this.lblSelecionaPorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelecionaPorta.Location = new System.Drawing.Point(11, 20);
            this.lblSelecionaPorta.Name = "lblSelecionaPorta";
            this.lblSelecionaPorta.Size = new System.Drawing.Size(88, 16);
            this.lblSelecionaPorta.TabIndex = 12;
            this.lblSelecionaPorta.Text = "Porta serial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nível:";
            // 
            // btnSaveData
            // 
            this.btnSaveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveData.Location = new System.Drawing.Point(473, 617);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(112, 23);
            this.btnSaveData.TabIndex = 15;
            this.btnSaveData.Text = "Salvar Dados";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSalvarArquivo);
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
            // btnOpenData
            // 
            this.btnOpenData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenData.Location = new System.Drawing.Point(747, 617);
            this.btnOpenData.Name = "btnOpenData";
            this.btnOpenData.Size = new System.Drawing.Size(100, 23);
            this.btnOpenData.TabIndex = 20;
            this.btnOpenData.Text = "Abrir Dados";
            this.btnOpenData.UseVisualStyleBackColor = true;
            this.btnOpenData.Click += new System.EventHandler(this.btnOpenArquivo_Click);
            // 
            // lblBomba
            // 
            this.lblBomba.AutoSize = true;
            this.lblBomba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBomba.Location = new System.Drawing.Point(224, 146);
            this.lblBomba.Name = "lblBomba";
            this.lblBomba.Size = new System.Drawing.Size(33, 16);
            this.lblBomba.TabIndex = 28;
            this.lblBomba.Text = "0 %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Bomba:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TanqueTeste01.Properties.Resources.Capturar11;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 437);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 182);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.InitialImage")));
            this.pictureBox5.Location = new System.Drawing.Point(914, 403);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(83, 166);
            this.pictureBox5.TabIndex = 33;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.InitialImage")));
            this.pictureBox4.Location = new System.Drawing.Point(907, 236);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(98, 167);
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.InitialImage")));
            this.pictureBox3.Location = new System.Drawing.Point(898, 37);
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
            this.pictureBox2.Location = new System.Drawing.Point(864, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(154, 541);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTeste);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.cboPortaSerial);
            this.groupBox1.Controls.Add(this.lblSelecionaPorta);
            this.groupBox1.Controls.Add(this.btnPump);
            this.groupBox1.Controls.Add(this.hsbPump);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblBomba);
            this.groupBox1.Controls.Add(this.lblNivelSensor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 187);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrincipalToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1023, 24);
            this.menuPrincipal.TabIndex = 37;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // menuPrincipalToolStripMenuItem
            // 
            this.menuPrincipalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajustarParametrosToolStripMenuItem});
            this.menuPrincipalToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuPrincipalToolStripMenuItem.Name = "menuPrincipalToolStripMenuItem";
            this.menuPrincipalToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.menuPrincipalToolStripMenuItem.Text = "Menu Principal";
            // 
            // ajustarParametrosToolStripMenuItem
            // 
            this.ajustarParametrosToolStripMenuItem.Name = "ajustarParametrosToolStripMenuItem";
            this.ajustarParametrosToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.ajustarParametrosToolStripMenuItem.Text = "Ajustar Parâmetros";
            this.ajustarParametrosToolStripMenuItem.Click += new System.EventHandler(this.ajustarParâmetrosToolStripMenuItem_Click);
            // 
            // txtSetPoint
            // 
            this.txtSetPoint.Location = new System.Drawing.Point(14, 37);
            this.txtSetPoint.Name = "txtSetPoint";
            this.txtSetPoint.Size = new System.Drawing.Size(107, 20);
            this.txtSetPoint.TabIndex = 38;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetPidParameters);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtKd);
            this.groupBox2.Controls.Add(this.txtKi);
            this.groupBox2.Controls.Add(this.txtKp);
            this.groupBox2.Controls.Add(this.lblSetPoint);
            this.groupBox2.Controls.Add(this.radPid);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.radManual);
            this.groupBox2.Controls.Add(this.radFuzzy);
            this.groupBox2.Controls.Add(this.btnSetPoint);
            this.groupBox2.Controls.Add(this.txtSetPoint);
            this.groupBox2.Location = new System.Drawing.Point(12, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 185);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            // 
            // btnSetPidParameters
            // 
            this.btnSetPidParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPidParameters.Location = new System.Drawing.Point(114, 156);
            this.btnSetPidParameters.Name = "btnSetPidParameters";
            this.btnSetPidParameters.Size = new System.Drawing.Size(75, 23);
            this.btnSetPidParameters.TabIndex = 49;
            this.btnSetPidParameters.Text = "OK";
            this.btnSetPidParameters.UseVisualStyleBackColor = true;
            this.btnSetPidParameters.Click += new System.EventHandler(this.btnParametrosPid_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(201, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 16);
            this.label7.TabIndex = 48;
            this.label7.Text = "Kd";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(111, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "Ki";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "Kp";
            // 
            // txtKd
            // 
            this.txtKd.Location = new System.Drawing.Point(232, 118);
            this.txtKd.Name = "txtKd";
            this.txtKd.Size = new System.Drawing.Size(47, 20);
            this.txtKd.TabIndex = 45;
            this.txtKd.Text = "0";
            // 
            // txtKi
            // 
            this.txtKi.Location = new System.Drawing.Point(133, 117);
            this.txtKi.Name = "txtKi";
            this.txtKi.Size = new System.Drawing.Size(47, 20);
            this.txtKi.TabIndex = 44;
            this.txtKi.Text = "0";
            // 
            // txtKp
            // 
            this.txtKp.Location = new System.Drawing.Point(40, 118);
            this.txtKp.Name = "txtKp";
            this.txtKp.Size = new System.Drawing.Size(45, 20);
            this.txtKp.TabIndex = 43;
            this.txtKp.Text = "0";
            // 
            // lblSetPoint
            // 
            this.lblSetPoint.AutoSize = true;
            this.lblSetPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetPoint.Location = new System.Drawing.Point(239, 36);
            this.lblSetPoint.Name = "lblSetPoint";
            this.lblSetPoint.Size = new System.Drawing.Size(40, 16);
            this.lblSetPoint.TabIndex = 30;
            this.lblSetPoint.Text = "0 cm";
            // 
            // radPid
            // 
            this.radPid.AutoSize = true;
            this.radPid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPid.Location = new System.Drawing.Point(120, 77);
            this.radPid.Name = "radPid";
            this.radPid.Size = new System.Drawing.Size(46, 17);
            this.radPid.TabIndex = 42;
            this.radPid.Text = "PID";
            this.radPid.UseVisualStyleBackColor = true;
            this.radPid.CheckedChanged += new System.EventHandler(this.radioButtonPid_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(188, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Valor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Set - Point";
            // 
            // radManual
            // 
            this.radManual.AutoSize = true;
            this.radManual.Checked = true;
            this.radManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radManual.Location = new System.Drawing.Point(213, 77);
            this.radManual.Name = "radManual";
            this.radManual.Size = new System.Drawing.Size(66, 17);
            this.radManual.TabIndex = 41;
            this.radManual.TabStop = true;
            this.radManual.Text = "Manual";
            this.radManual.UseVisualStyleBackColor = true;
            this.radManual.CheckedChanged += new System.EventHandler(this.radioButtonManual_CheckedChanged);
            // 
            // radFuzzy
            // 
            this.radFuzzy.AutoSize = true;
            this.radFuzzy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFuzzy.Location = new System.Drawing.Point(14, 77);
            this.radFuzzy.Name = "radFuzzy";
            this.radFuzzy.Size = new System.Drawing.Size(57, 17);
            this.radFuzzy.TabIndex = 40;
            this.radFuzzy.Text = "Fuzzy";
            this.radFuzzy.UseVisualStyleBackColor = true;
            this.radFuzzy.CheckedChanged += new System.EventHandler(this.radioButtonFuzzy_CheckedChanged);
            // 
            // btnSetPoint
            // 
            this.btnSetPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPoint.Location = new System.Drawing.Point(130, 35);
            this.btnSetPoint.Name = "btnSetPoint";
            this.btnSetPoint.Size = new System.Drawing.Size(36, 23);
            this.btnSetPoint.TabIndex = 39;
            this.btnSetPoint.Text = "OK";
            this.btnSetPoint.UseVisualStyleBackColor = true;
            this.btnSetPoint.Click += new System.EventHandler(this.btnSetPoint_Click);
            // 
            // pnlChaveSeguranca
            // 
            this.pnlChaveSeguranca.BackColor = System.Drawing.Color.Red;
            this.pnlChaveSeguranca.Location = new System.Drawing.Point(898, 67);
            this.pnlChaveSeguranca.Name = "pnlChaveSeguranca";
            this.pnlChaveSeguranca.Size = new System.Drawing.Size(116, 4);
            this.pnlChaveSeguranca.TabIndex = 40;
            this.pnlChaveSeguranca.Visible = false;
            // 
            // btnAutomatic
            // 
            this.btnAutomatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutomatic.Location = new System.Drawing.Point(334, 617);
            this.btnAutomatic.Name = "btnAutomatic";
            this.btnAutomatic.Size = new System.Drawing.Size(95, 23);
            this.btnAutomatic.TabIndex = 41;
            this.btnAutomatic.Text = "Automatico";
            this.btnAutomatic.UseVisualStyleBackColor = true;
            this.btnAutomatic.Click += new System.EventHandler(this.AutomaticTest);
            // 
            // lblAmostras
            // 
            this.lblAmostras.AutoSize = true;
            this.lblAmostras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmostras.Location = new System.Drawing.Point(847, 603);
            this.lblAmostras.Name = "lblAmostras";
            this.lblAmostras.Size = new System.Drawing.Size(0, 16);
            this.lblAmostras.TabIndex = 42;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnClearGraph
            // 
            this.btnClearGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearGraph.Location = new System.Drawing.Point(619, 617);
            this.btnClearGraph.Name = "btnClearGraph";
            this.btnClearGraph.Size = new System.Drawing.Size(95, 23);
            this.btnClearGraph.TabIndex = 43;
            this.btnClearGraph.Text = "Limpar";
            this.btnClearGraph.UseVisualStyleBackColor = true;
            this.btnClearGraph.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // erro
            // 
            this.erro.AutoSize = true;
            this.erro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erro.Location = new System.Drawing.Point(331, 589);
            this.erro.Name = "erro";
            this.erro.Size = new System.Drawing.Size(41, 16);
            this.erro.TabIndex = 44;
            this.erro.Text = "Erro:";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1023, 652);
            this.Controls.Add(this.erro);
            this.Controls.Add(this.btnClearGraph);
            this.Controls.Add(this.lblAmostras);
            this.Controls.Add(this.btnAutomatic);
            this.Controls.Add(this.pnlChaveSeguranca);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnOpenData);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.chtPump);
            this.Controls.Add(this.chtLevel);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Sistema Supervisório - Sistema de Nível";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chtLevel)).EndInit();
            this.chartNivelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtPump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cboPortaSerial;
        private System.Windows.Forms.Button btnStart;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.HScrollBar hsbPump;
        private System.Windows.Forms.Button btnPump;
        private System.Windows.Forms.Label lblNivelSensor;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtLevel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtPump;
        private System.Windows.Forms.Label lblTeste;
        private System.Windows.Forms.Label lblSelecionaPorta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.ContextMenuStrip chartNivelMenu;
        
        private const double NIVEL_MAX = 30;
        private const int ACIONAMENTO_SEGURANCA = 30;
        private const int NIVEL_SERIE = 0;
        private const int SP_SERIE = 1;
        private const int BOMBA_SERIE = 0;

        private int sample = 0;
        private int setPoint = 15;

        private double parametroA = 0.127;
        private double parametroB = 4.1029;
        private double mostrarTanque = 0; // Recebe o valor sensor 
        private double nivelCm = 0;
        private double valorBomba = 0;

        private string leituraBombaSensor;
        private string iniciarComunicacao = "L";
        private string finalizarComunicacao = "D";
        private string tratarLeitura = "";
        
        private bool requested = false;
        private List<string> experimento = new List<string>();
        private int valSetpoint = 0;
        private int contadorPid = 0;
        private bool pidAutomatico = false;
        private int contI = 0;
        private int tamLista = 0;

        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnOpenData;
        private System.Windows.Forms.Label lblBomba;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuPrincipalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajustarParametrosToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSetPoint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radManual;
        private System.Windows.Forms.RadioButton radFuzzy;
        private System.Windows.Forms.Button btnSetPoint;
        private System.Windows.Forms.RadioButton radPid;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblSetPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlChaveSeguranca;
        private System.Windows.Forms.Button btnSetPidParameters;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKd;
        private System.Windows.Forms.TextBox txtKi;
        private System.Windows.Forms.TextBox txtKp;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnAutomatic;
        private System.Windows.Forms.Label lblAmostras;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem LimparChartNivel;
        private System.Windows.Forms.Button btnClearGraph;
        private System.Windows.Forms.Label erro;
    }
}

