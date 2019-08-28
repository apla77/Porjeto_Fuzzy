namespace TanqueTeste01
{
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
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
            this.textBoxSetPoint = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnParametrosPid = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxKd = new System.Windows.Forms.TextBox();
            this.textBoxKi = new System.Windows.Forms.TextBox();
            this.textBoxKp = new System.Windows.Forms.TextBox();
            this.lblSetPoint = new System.Windows.Forms.Label();
            this.radioButtonPid = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonManual = new System.Windows.Forms.RadioButton();
            this.radioButtonFuzzy = new System.Windows.Forms.RadioButton();
            this.btnSetPoint = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlChaveSeguranca = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chartNivel)).BeginInit();
            this.chartNivelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBomba)).BeginInit();
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
            // btConectar
            // 
            this.btConectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConectar.Location = new System.Drawing.Point(106, 38);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(112, 23);
            this.btConectar.TabIndex = 0;
            this.btConectar.Text = "Conectar";
            this.btConectar.UseVisualStyleBackColor = true;
            this.btConectar.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(14, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(85, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseClick);
            // 
            // btEnviar
            // 
            this.btEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnviar.Location = new System.Drawing.Point(232, 37);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(66, 25);
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
            this.hScrollBarBomba.Location = new System.Drawing.Point(9, 92);
            this.hScrollBarBomba.Maximum = 109;
            this.hScrollBarBomba.Name = "hScrollBarBomba";
            this.hScrollBarBomba.Size = new System.Drawing.Size(203, 23);
            this.hScrollBarBomba.TabIndex = 5;
            this.hScrollBarBomba.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarBomba_Scroll);
            // 
            // btnBomba
            // 
            this.btnBomba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBomba.Location = new System.Drawing.Point(232, 92);
            this.btnBomba.Name = "btnBomba";
            this.btnBomba.Size = new System.Drawing.Size(66, 23);
            this.btnBomba.TabIndex = 6;
            this.btnBomba.Text = "Bomba";
            this.btnBomba.UseVisualStyleBackColor = true;
            this.btnBomba.Click += new System.EventHandler(this.btnBomba_Click);
            // 
            // labelSen
            // 
            this.labelSen.AutoSize = true;
            this.labelSen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSen.Location = new System.Drawing.Point(59, 146);
            this.labelSen.Name = "labelSen";
            this.labelSen.Size = new System.Drawing.Size(40, 16);
            this.labelSen.TabIndex = 7;
            this.labelSen.Text = "0 cm";
            // 
            // chartNivel
            // 
            chartArea5.AxisX.Minimum = 0D;
            chartArea5.AxisX.Title = "amostras";
            chartArea5.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisY.Interval = 5D;
            chartArea5.AxisY.Maximum = 35D;
            chartArea5.AxisY.Title = "nível (cm)";
            chartArea5.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.Name = "ChartArea1";
            this.chartNivel.ChartAreas.Add(chartArea5);
            this.chartNivel.ContextMenuStrip = this.chartNivelMenu;
            this.chartNivel.Location = new System.Drawing.Point(334, 37);
            this.chartNivel.Name = "chartNivel";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Nível";
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.Red;
            series7.Enabled = false;
            series7.Name = "Set-Pint";
            this.chartNivel.Series.Add(series5);
            this.chartNivel.Series.Add(series7);
            this.chartNivel.Size = new System.Drawing.Size(513, 265);
            this.chartNivel.TabIndex = 8;
            this.chartNivel.Text = "Nível do Tanque";
            title5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title5.Name = "Title1";
            title5.Text = "Nível do Tanque";
            this.chartNivel.Titles.Add(title5);
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
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisX.Title = "amostras";
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY.Interval = 20D;
            chartArea4.AxisY.Maximum = 100D;
            chartArea4.AxisY.Title = "acionamento (%)";
            chartArea4.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.Name = "ChartArea1";
            this.chartBomba.ChartAreas.Add(chartArea4);
            this.chartBomba.Location = new System.Drawing.Point(334, 313);
            this.chartBomba.Name = "chartBomba";
            series2.BorderColor = System.Drawing.Color.White;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Green;
            series2.LabelBorderWidth = 2;
            series2.MarkerColor = System.Drawing.Color.Transparent;
            series2.Name = "Bomba";
            this.chartBomba.Series.Add(series2);
            this.chartBomba.Size = new System.Drawing.Size(513, 263);
            this.chartBomba.TabIndex = 10;
            this.chartBomba.Text = "chart1";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.Name = "Title1";
            title4.Text = "Acionamento da Bomba";
            this.chartBomba.Titles.Add(title4);
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
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(499, 596);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(112, 23);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "Salvar Dados";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvarArquivo);
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
            this.btnOpenArquivo.Location = new System.Drawing.Point(650, 596);
            this.btnOpenArquivo.Name = "btnOpenArquivo";
            this.btnOpenArquivo.Size = new System.Drawing.Size(112, 23);
            this.btnOpenArquivo.TabIndex = 20;
            this.btnOpenArquivo.Text = "Abrir Dados";
            this.btnOpenArquivo.UseVisualStyleBackColor = true;
            this.btnOpenArquivo.Click += new System.EventHandler(this.btnOpenArquivo_Click);
            // 
            // lblBomba
            // 
            this.lblBomba.AutoSize = true;
            this.lblBomba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBomba.Location = new System.Drawing.Point(246, 146);
            this.lblBomba.Name = "lblBomba";
            this.lblBomba.Size = new System.Drawing.Size(33, 16);
            this.lblBomba.TabIndex = 28;
            this.lblBomba.Text = "0 %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 146);
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
            this.groupBox1.Controls.Add(this.btEnviar);
            this.groupBox1.Controls.Add(this.btConectar);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.lblSelecionaPorta);
            this.groupBox1.Controls.Add(this.btnBomba);
            this.groupBox1.Controls.Add(this.hScrollBarBomba);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblBomba);
            this.groupBox1.Controls.Add(this.labelSen);
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
            this.menuPrincipal.Size = new System.Drawing.Size(1022, 24);
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
            // textBoxSetPoint
            // 
            this.textBoxSetPoint.Location = new System.Drawing.Point(14, 35);
            this.textBoxSetPoint.Name = "textBoxSetPoint";
            this.textBoxSetPoint.Size = new System.Drawing.Size(107, 20);
            this.textBoxSetPoint.TabIndex = 38;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnParametrosPid);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxKd);
            this.groupBox2.Controls.Add(this.textBoxKi);
            this.groupBox2.Controls.Add(this.textBoxKp);
            this.groupBox2.Controls.Add(this.lblSetPoint);
            this.groupBox2.Controls.Add(this.radioButtonPid);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.radioButtonManual);
            this.groupBox2.Controls.Add(this.radioButtonFuzzy);
            this.groupBox2.Controls.Add(this.btnSetPoint);
            this.groupBox2.Controls.Add(this.textBoxSetPoint);
            this.groupBox2.Location = new System.Drawing.Point(12, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 185);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            // 
            // btnParametrosPid
            // 
            this.btnParametrosPid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParametrosPid.Location = new System.Drawing.Point(120, 156);
            this.btnParametrosPid.Name = "btnParametrosPid";
            this.btnParametrosPid.Size = new System.Drawing.Size(75, 23);
            this.btnParametrosPid.TabIndex = 49;
            this.btnParametrosPid.Text = "OK";
            this.btnParametrosPid.UseVisualStyleBackColor = true;
            this.btnParametrosPid.Click += new System.EventHandler(this.btnParametrosPid_Click);
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
            // textBoxKd
            // 
            this.textBoxKd.Location = new System.Drawing.Point(232, 118);
            this.textBoxKd.Name = "textBoxKd";
            this.textBoxKd.Size = new System.Drawing.Size(47, 20);
            this.textBoxKd.TabIndex = 45;
            this.textBoxKd.Text = "0";
            // 
            // textBoxKi
            // 
            this.textBoxKi.Location = new System.Drawing.Point(133, 117);
            this.textBoxKi.Name = "textBoxKi";
            this.textBoxKi.Size = new System.Drawing.Size(47, 20);
            this.textBoxKi.TabIndex = 44;
            this.textBoxKi.Text = "0";
            // 
            // textBoxKp
            // 
            this.textBoxKp.Location = new System.Drawing.Point(40, 118);
            this.textBoxKp.Name = "textBoxKp";
            this.textBoxKp.Size = new System.Drawing.Size(45, 20);
            this.textBoxKp.TabIndex = 43;
            this.textBoxKp.Text = "0";
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
            // radioButtonPid
            // 
            this.radioButtonPid.AutoSize = true;
            this.radioButtonPid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPid.Location = new System.Drawing.Point(120, 77);
            this.radioButtonPid.Name = "radioButtonPid";
            this.radioButtonPid.Size = new System.Drawing.Size(46, 17);
            this.radioButtonPid.TabIndex = 42;
            this.radioButtonPid.Text = "PID";
            this.radioButtonPid.UseVisualStyleBackColor = true;
            this.radioButtonPid.CheckedChanged += new System.EventHandler(this.radioButtonPid_CheckedChanged);
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
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Set - Point";
            // 
            // radioButtonManual
            // 
            this.radioButtonManual.AutoSize = true;
            this.radioButtonManual.Checked = true;
            this.radioButtonManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonManual.Location = new System.Drawing.Point(213, 77);
            this.radioButtonManual.Name = "radioButtonManual";
            this.radioButtonManual.Size = new System.Drawing.Size(66, 17);
            this.radioButtonManual.TabIndex = 41;
            this.radioButtonManual.TabStop = true;
            this.radioButtonManual.Text = "Manual";
            this.radioButtonManual.UseVisualStyleBackColor = true;
            this.radioButtonManual.CheckedChanged += new System.EventHandler(this.radioButtonManual_CheckedChanged);
            // 
            // radioButtonFuzzy
            // 
            this.radioButtonFuzzy.AutoSize = true;
            this.radioButtonFuzzy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFuzzy.Location = new System.Drawing.Point(14, 77);
            this.radioButtonFuzzy.Name = "radioButtonFuzzy";
            this.radioButtonFuzzy.Size = new System.Drawing.Size(57, 17);
            this.radioButtonFuzzy.TabIndex = 40;
            this.radioButtonFuzzy.Text = "Fuzzy";
            this.radioButtonFuzzy.UseVisualStyleBackColor = true;
            this.radioButtonFuzzy.CheckedChanged += new System.EventHandler(this.radioButtonFuzzy_CheckedChanged);
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
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1022, 631);
            this.Controls.Add(this.pnlChaveSeguranca);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnOpenArquivo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.chartBomba);
            this.Controls.Add(this.chartNivel);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Sistema Supervisório - Sistema de Nível";
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

        private int sample = 0;
      //  private int valorMaximoNivel = 29;
        private int setPoint = 15;

        private double mostrarTanque = 0; // Recebe o valor sensor 
        private double nivelCm = 0;
        private double valorBomba = 0;
        private double erro = 0;
        private double erroAnterior = 0;
        private double diferencaErro = 0;
        private double somatoriaPid = 0;

        private double kp = 0;
        private double ki = 0;
        private double kd = 0;
        private double resultadoPid = 0;

        private string leituraBombaSersor;
        private string iniciarComunicacao = "300";
        private string finalizarComunicacao = "200";
        private string aux = "";

        private const double NIVEL_MAX = 30;
        private const int ACIONAMENTO_SEGURANCA = 30;
        private const int NIVEL_SERIE = 0;
        private const int SP_SERIE = 1;
        private const int BOMBA_SERIE = 0;

        private bool requested = false;

        private double parametroA = 0.1283;
        private double parametroB = 2.9587;

        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnOpenArquivo;
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
        private System.Windows.Forms.TextBox textBoxSetPoint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonManual;
        private System.Windows.Forms.RadioButton radioButtonFuzzy;
        private System.Windows.Forms.Button btnSetPoint;
        private System.Windows.Forms.RadioButton radioButtonPid;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblSetPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlChaveSeguranca;
        private System.Windows.Forms.Button btnParametrosPid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxKd;
        private System.Windows.Forms.TextBox textBoxKi;
        private System.Windows.Forms.TextBox textBoxKp;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

