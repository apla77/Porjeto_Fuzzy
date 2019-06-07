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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btConectar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.textBoxReceber = new System.Windows.Forms.TextBox();
            this.timerReq = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.hScrollBarBomba = new System.Windows.Forms.HScrollBar();
            this.btnBomba = new System.Windows.Forms.Button();
            this.labelSen = new System.Windows.Forms.Label();
            this.chartNivel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartNivelMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelBom = new System.Windows.Forms.Label();
            this.chartBomba = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTeste = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartNivel)).BeginInit();
            this.chartNivelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBomba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btConectar
            // 
            this.btConectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConectar.Location = new System.Drawing.Point(293, 55);
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
            this.comboBox1.Location = new System.Drawing.Point(69, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseClick);
            // 
            // btEnviar
            // 
            this.btEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnviar.Location = new System.Drawing.Point(69, 129);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(75, 23);
            this.btEnviar.TabIndex = 2;
            this.btEnviar.Text = "Iniciar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // textBoxReceber
            // 
            this.textBoxReceber.Location = new System.Drawing.Point(12, 381);
            this.textBoxReceber.Multiline = true;
            this.textBoxReceber.Name = "textBoxReceber";
            this.textBoxReceber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReceber.Size = new System.Drawing.Size(208, 324);
            this.textBoxReceber.TabIndex = 4;
            // 
            // timerReq
            // 
            this.timerReq.Interval = 1000;
            this.timerReq.Tick += new System.EventHandler(this.timerReq_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // hScrollBarBomba
            // 
            this.hScrollBarBomba.Location = new System.Drawing.Point(175, 197);
            this.hScrollBarBomba.Maximum = 109;
            this.hScrollBarBomba.Minimum = 1;
            this.hScrollBarBomba.Name = "hScrollBarBomba";
            this.hScrollBarBomba.Size = new System.Drawing.Size(185, 23);
            this.hScrollBarBomba.TabIndex = 5;
            this.hScrollBarBomba.Value = 1;
            this.hScrollBarBomba.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarBomba_Scroll);
            // 
            // btnBomba
            // 
            this.btnBomba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBomba.Location = new System.Drawing.Point(69, 197);
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
            this.labelSen.Location = new System.Drawing.Point(243, 132);
            this.labelSen.Name = "labelSen";
            this.labelSen.Size = new System.Drawing.Size(29, 16);
            this.labelSen.TabIndex = 7;
            this.labelSen.Text = "0%";
            // 
            // chartNivel
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chartNivel.ChartAreas.Add(chartArea1);
            this.chartNivel.ContextMenuStrip = this.chartNivelMenu;
            this.chartNivel.Location = new System.Drawing.Point(558, 12);
            this.chartNivel.Name = "chartNivel";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Nível";
            this.chartNivel.Series.Add(series1);
            this.chartNivel.Size = new System.Drawing.Size(613, 310);
            this.chartNivel.TabIndex = 8;
            this.chartNivel.Text = "chart1";
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
            // labelBom
            // 
            this.labelBom.AutoSize = true;
            this.labelBom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBom.Location = new System.Drawing.Point(378, 132);
            this.labelBom.Name = "labelBom";
            this.labelBom.Size = new System.Drawing.Size(29, 16);
            this.labelBom.TabIndex = 9;
            this.labelBom.Text = "0%";
            // 
            // chartBomba
            // 
            chartArea2.Name = "ChartArea1";
            this.chartBomba.ChartAreas.Add(chartArea2);
            this.chartBomba.Location = new System.Drawing.Point(558, 328);
            this.chartBomba.Name = "chartBomba";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Nível";
            this.chartBomba.Series.Add(series2);
            this.chartBomba.Size = new System.Drawing.Size(613, 324);
            this.chartBomba.TabIndex = 10;
            this.chartBomba.Text = "chart1";
            // 
            // lblTeste
            // 
            this.lblTeste.AutoSize = true;
            this.lblTeste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeste.Location = new System.Drawing.Point(378, 200);
            this.lblTeste.Name = "lblTeste";
            this.lblTeste.Size = new System.Drawing.Size(29, 16);
            this.lblTeste.TabIndex = 11;
            this.lblTeste.Text = "0%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Selecione uma porta abaixo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sensor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(299, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Bomba:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(447, 289);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFile
            // 
            this.saveFile.DefaultExt = "\".txt\"";
            this.saveFile.Filter = "Dados Experimentais (.txt)|*.txt";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 532);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(381, 353);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 200);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(390, 353);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 200);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 717);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTeste);
            this.Controls.Add(this.chartBomba);
            this.Controls.Add(this.labelBom);
            this.Controls.Add(this.chartNivel);
            this.Controls.Add(this.labelSen);
            this.Controls.Add(this.btnBomba);
            this.Controls.Add(this.hScrollBarBomba);
            this.Controls.Add(this.textBoxReceber);
            this.Controls.Add(this.btEnviar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btConectar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartNivel)).EndInit();
            this.chartNivelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBomba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConectar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.TextBox textBoxReceber;
        private System.Windows.Forms.Timer timerReq;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.HScrollBar hScrollBarBomba;
        private System.Windows.Forms.Button btnBomba;
        private System.Windows.Forms.Label labelSen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNivel;


        bool requested = false;
        private System.Windows.Forms.Label labelBom;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBomba;
        private System.Windows.Forms.Label lblTeste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.ContextMenuStrip chartNivelMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

