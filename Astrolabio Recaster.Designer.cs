namespace Astrolabio_Recaster
{
    partial class Form1
    {
        /// <summary>
        ///  Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Limpar os recursos sendo usados.
        /// </summary>
        /// <param name="disposing">true se os recursos gerenciados tiverem que ser descartados; caso contrário, false.</param>
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
        ///  Método necessário para suporte ao Designer - não modifique
        ///  o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMain = new Panel();
            nudVisualDelay = new NumericUpDown();
            lblVisualDelay = new Label();
            lblMatchedStatsValue = new Label();
            lblMatchedStatsTitle = new Label();
            lblClickOffsetValue = new Label();
            lblClickOffsetTitle = new Label();
            lblClickCalibrationValue = new Label();
            btnCalibrateClick = new Button();
            lblClickCalibrationTitle = new Label();
            lblElapsedValue = new Label();
            lblElapsedTitle = new Label();
            chkUnlimitedAttempts = new CheckBox();
            nudMaxAttempts = new NumericUpDown();
            lblMaxAttemptsTitle = new Label();
            lblAttemptsValue = new Label();
            lblAttemptsTitle = new Label();
            lblStatusValue = new Label();
            lblStatusTitle = new Label();
            grpDesiredStats = new GroupBox();
            btnTestCapture = new Button();
            btnStopRolling = new Button();
            btnStartRolling = new Button();
            lblSelectedCount = new Label();
            dgvDesiredStats = new DataGridView();
            colSelect = new DataGridViewCheckBoxColumn();
            colStatName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewComboBoxColumn();
            label1 = new Label();
            trackOpacity = new TrackBar();
            lblStatus = new Label();
            lstStats = new ListBox();
            lblDetectedStats = new Label();
            picCapturedRegion = new PictureBox();
            lblCapturedRegion = new Label();
            txtOcrRaw = new TextBox();
            lblOcrRaw = new Label();
            pnlHeader = new Panel();
            btnHelp = new Button();
            btnClose = new Button();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudVisualDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxAttempts).BeginInit();
            grpDesiredStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDesiredStats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackOpacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCapturedRegion).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(20, 20, 20);
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(nudVisualDelay);
            pnlMain.Controls.Add(lblVisualDelay);
            pnlMain.Controls.Add(lblMatchedStatsValue);
            pnlMain.Controls.Add(lblMatchedStatsTitle);
            pnlMain.Controls.Add(lblClickOffsetValue);
            pnlMain.Controls.Add(lblClickOffsetTitle);
            pnlMain.Controls.Add(lblClickCalibrationValue);
            pnlMain.Controls.Add(btnCalibrateClick);
            pnlMain.Controls.Add(lblClickCalibrationTitle);
            pnlMain.Controls.Add(lblElapsedValue);
            pnlMain.Controls.Add(lblElapsedTitle);
            pnlMain.Controls.Add(chkUnlimitedAttempts);
            pnlMain.Controls.Add(nudMaxAttempts);
            pnlMain.Controls.Add(lblMaxAttemptsTitle);
            pnlMain.Controls.Add(lblAttemptsValue);
            pnlMain.Controls.Add(lblAttemptsTitle);
            pnlMain.Controls.Add(lblStatusValue);
            pnlMain.Controls.Add(lblStatusTitle);
            pnlMain.Controls.Add(grpDesiredStats);
            pnlMain.Controls.Add(label1);
            pnlMain.Controls.Add(trackOpacity);
            pnlMain.Controls.Add(lblStatus);
            pnlMain.Controls.Add(lstStats);
            pnlMain.Controls.Add(lblDetectedStats);
            pnlMain.Controls.Add(picCapturedRegion);
            pnlMain.Controls.Add(lblCapturedRegion);
            pnlMain.Controls.Add(txtOcrRaw);
            pnlMain.Controls.Add(lblOcrRaw);
            pnlMain.Controls.Add(pnlHeader);
            pnlMain.Location = new Point(20, 20);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1080, 874);
            pnlMain.TabIndex = 0;
            // 
            // nudVisualDelay
            // 
            nudVisualDelay.Location = new Point(1010, 778);
            nudVisualDelay.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            nudVisualDelay.Name = "nudVisualDelay";
            nudVisualDelay.Size = new Size(38, 23);
            nudVisualDelay.TabIndex = 37;
            nudVisualDelay.TextAlign = HorizontalAlignment.Right;
            nudVisualDelay.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblVisualDelay
            // 
            lblVisualDelay.AutoSize = true;
            lblVisualDelay.ForeColor = Color.White;
            lblVisualDelay.Location = new Point(702, 786);
            lblVisualDelay.Name = "lblVisualDelay";
            lblVisualDelay.Size = new Size(301, 15);
            lblVisualDelay.TabIndex = 36;
            lblVisualDelay.Text = "Delay visual (tempo de tela após o rolete em segundos):";
            // 
            // lblMatchedStatsValue
            // 
            lblMatchedStatsValue.AutoSize = true;
            lblMatchedStatsValue.ForeColor = Color.White;
            lblMatchedStatsValue.Location = new Point(1018, 762);
            lblMatchedStatsValue.Name = "lblMatchedStatsValue";
            lblMatchedStatsValue.Size = new Size(30, 15);
            lblMatchedStatsValue.TabIndex = 35;
            lblMatchedStatsValue.Text = "0 / 0";
            // 
            // lblMatchedStatsTitle
            // 
            lblMatchedStatsTitle.AutoSize = true;
            lblMatchedStatsTitle.ForeColor = Color.White;
            lblMatchedStatsTitle.Location = new Point(749, 762);
            lblMatchedStatsTitle.Name = "lblMatchedStatsTitle";
            lblMatchedStatsTitle.Size = new Size(254, 15);
            lblMatchedStatsTitle.TabIndex = 34;
            lblMatchedStatsTitle.Text = "Atributos desejados encontrados nesta rodada:";
            // 
            // lblClickOffsetValue
            // 
            lblClickOffsetValue.AutoEllipsis = true;
            lblClickOffsetValue.ForeColor = Color.White;
            lblClickOffsetValue.Location = new Point(113, 800);
            lblClickOffsetValue.Name = "lblClickOffsetValue";
            lblClickOffsetValue.Size = new Size(168, 20);
            lblClickOffsetValue.TabIndex = 33;
            lblClickOffsetValue.Text = "(0, 0)";
            // 
            // lblClickOffsetTitle
            // 
            lblClickOffsetTitle.AutoEllipsis = true;
            lblClickOffsetTitle.ForeColor = Color.White;
            lblClickOffsetTitle.Location = new Point(6, 800);
            lblClickOffsetTitle.Name = "lblClickOffsetTitle";
            lblClickOffsetTitle.Size = new Size(90, 20);
            lblClickOffsetTitle.TabIndex = 32;
            lblClickOffsetTitle.Text = "Coordenadas:";
            // 
            // lblClickCalibrationValue
            // 
            lblClickCalibrationValue.AutoEllipsis = true;
            lblClickCalibrationValue.ForeColor = Color.White;
            lblClickCalibrationValue.Location = new Point(113, 780);
            lblClickCalibrationValue.Name = "lblClickCalibrationValue";
            lblClickCalibrationValue.Size = new Size(168, 20);
            lblClickCalibrationValue.TabIndex = 31;
            lblClickCalibrationValue.Text = "Não";
            // 
            // btnCalibrateClick
            // 
            btnCalibrateClick.BackColor = Color.FromArgb(45, 45, 45);
            btnCalibrateClick.FlatStyle = FlatStyle.Flat;
            btnCalibrateClick.ForeColor = Color.White;
            btnCalibrateClick.Location = new Point(6, 743);
            btnCalibrateClick.Name = "btnCalibrateClick";
            btnCalibrateClick.Size = new Size(122, 34);
            btnCalibrateClick.TabIndex = 5;
            btnCalibrateClick.Text = "Calibrar Mouse";
            btnCalibrateClick.UseVisualStyleBackColor = false;
            btnCalibrateClick.Click += btnCalibrateClick_Click;
            // 
            // lblClickCalibrationTitle
            // 
            lblClickCalibrationTitle.AutoEllipsis = true;
            lblClickCalibrationTitle.ForeColor = Color.White;
            lblClickCalibrationTitle.Location = new Point(6, 780);
            lblClickCalibrationTitle.Name = "lblClickCalibrationTitle";
            lblClickCalibrationTitle.Size = new Size(108, 20);
            lblClickCalibrationTitle.TabIndex = 30;
            lblClickCalibrationTitle.Text = "Mouse calibrado:";
            // 
            // lblElapsedValue
            // 
            lblElapsedValue.AutoSize = true;
            lblElapsedValue.ForeColor = Color.White;
            lblElapsedValue.Location = new Point(114, 640);
            lblElapsedValue.Name = "lblElapsedValue";
            lblElapsedValue.Size = new Size(49, 15);
            lblElapsedValue.TabIndex = 29;
            lblElapsedValue.Text = "00:00:00";
            // 
            // lblElapsedTitle
            // 
            lblElapsedTitle.AutoSize = true;
            lblElapsedTitle.ForeColor = Color.White;
            lblElapsedTitle.Location = new Point(14, 640);
            lblElapsedTitle.Name = "lblElapsedTitle";
            lblElapsedTitle.Size = new Size(47, 15);
            lblElapsedTitle.TabIndex = 28;
            lblElapsedTitle.Text = "Tempo:";
            // 
            // chkUnlimitedAttempts
            // 
            chkUnlimitedAttempts.AutoSize = true;
            chkUnlimitedAttempts.ForeColor = Color.White;
            chkUnlimitedAttempts.Location = new Point(199, 609);
            chkUnlimitedAttempts.Name = "chkUnlimitedAttempts";
            chkUnlimitedAttempts.Size = new Size(82, 19);
            chkUnlimitedAttempts.TabIndex = 27;
            chkUnlimitedAttempts.Text = "Sem limite";
            chkUnlimitedAttempts.UseVisualStyleBackColor = true;
            chkUnlimitedAttempts.CheckedChanged += chkUnlimitedAttempts_CheckedChanged;
            // 
            // nudMaxAttempts
            // 
            nudMaxAttempts.Location = new Point(114, 602);
            nudMaxAttempts.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudMaxAttempts.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMaxAttempts.Name = "nudMaxAttempts";
            nudMaxAttempts.Size = new Size(73, 23);
            nudMaxAttempts.TabIndex = 26;
            nudMaxAttempts.TextAlign = HorizontalAlignment.Right;
            nudMaxAttempts.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblMaxAttemptsTitle
            // 
            lblMaxAttemptsTitle.AutoSize = true;
            lblMaxAttemptsTitle.ForeColor = Color.White;
            lblMaxAttemptsTitle.Location = new Point(14, 610);
            lblMaxAttemptsTitle.Name = "lblMaxAttemptsTitle";
            lblMaxAttemptsTitle.Size = new Size(89, 15);
            lblMaxAttemptsTitle.TabIndex = 25;
            lblMaxAttemptsTitle.Text = "Máx. tentativas:";
            // 
            // lblAttemptsValue
            // 
            lblAttemptsValue.AutoSize = true;
            lblAttemptsValue.ForeColor = Color.White;
            lblAttemptsValue.Location = new Point(114, 580);
            lblAttemptsValue.Name = "lblAttemptsValue";
            lblAttemptsValue.Size = new Size(13, 15);
            lblAttemptsValue.TabIndex = 24;
            lblAttemptsValue.Text = "0";
            // 
            // lblAttemptsTitle
            // 
            lblAttemptsTitle.AutoSize = true;
            lblAttemptsTitle.ForeColor = Color.White;
            lblAttemptsTitle.Location = new Point(14, 580);
            lblAttemptsTitle.Name = "lblAttemptsTitle";
            lblAttemptsTitle.Size = new Size(63, 15);
            lblAttemptsTitle.TabIndex = 23;
            lblAttemptsTitle.Text = "Tentativas:";
            // 
            // lblStatusValue
            // 
            lblStatusValue.AutoSize = true;
            lblStatusValue.ForeColor = Color.White;
            lblStatusValue.Location = new Point(114, 550);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(73, 15);
            lblStatusValue.TabIndex = 22;
            lblStatusValue.Text = "Aguardando";
            // 
            // lblStatusTitle
            // 
            lblStatusTitle.AutoSize = true;
            lblStatusTitle.ForeColor = Color.White;
            lblStatusTitle.Location = new Point(15, 550);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new Size(42, 15);
            lblStatusTitle.TabIndex = 21;
            lblStatusTitle.Text = "Status:";
            // 
            // grpDesiredStats
            // 
            grpDesiredStats.BackColor = Color.FromArgb(15, 15, 15);
            grpDesiredStats.Controls.Add(btnTestCapture);
            grpDesiredStats.Controls.Add(btnStopRolling);
            grpDesiredStats.Controls.Add(btnStartRolling);
            grpDesiredStats.Controls.Add(lblSelectedCount);
            grpDesiredStats.Controls.Add(dgvDesiredStats);
            grpDesiredStats.ForeColor = Color.White;
            grpDesiredStats.Location = new Point(287, 46);
            grpDesiredStats.Name = "grpDesiredStats";
            grpDesiredStats.Size = new Size(496, 704);
            grpDesiredStats.TabIndex = 20;
            grpDesiredStats.TabStop = false;
            grpDesiredStats.Text = "Atributos desejados";
            // 
            // btnTestCapture
            // 
            btnTestCapture.BackColor = Color.FromArgb(45, 45, 45);
            btnTestCapture.FlatStyle = FlatStyle.Flat;
            btnTestCapture.ForeColor = Color.White;
            btnTestCapture.Location = new Point(6, 659);
            btnTestCapture.Name = "btnTestCapture";
            btnTestCapture.Size = new Size(122, 34);
            btnTestCapture.TabIndex = 4;
            btnTestCapture.Text = "Teste de Captura";
            btnTestCapture.UseVisualStyleBackColor = false;
            btnTestCapture.Click += btnTestCapture_Click;
            // 
            // btnStopRolling
            // 
            btnStopRolling.BackColor = Color.FromArgb(45, 45, 45);
            btnStopRolling.Enabled = false;
            btnStopRolling.FlatStyle = FlatStyle.Flat;
            btnStopRolling.ForeColor = Color.White;
            btnStopRolling.Location = new Point(368, 659);
            btnStopRolling.Name = "btnStopRolling";
            btnStopRolling.Size = new Size(122, 34);
            btnStopRolling.TabIndex = 3;
            btnStopRolling.Text = "Parar";
            btnStopRolling.UseVisualStyleBackColor = false;
            btnStopRolling.Click += btnStopRolling_Click;
            // 
            // btnStartRolling
            // 
            btnStartRolling.BackColor = Color.FromArgb(45, 45, 45);
            btnStartRolling.FlatStyle = FlatStyle.Flat;
            btnStartRolling.ForeColor = Color.White;
            btnStartRolling.Location = new Point(191, 659);
            btnStartRolling.Name = "btnStartRolling";
            btnStartRolling.Size = new Size(122, 34);
            btnStartRolling.TabIndex = 2;
            btnStartRolling.Text = "Iniciar";
            btnStartRolling.UseVisualStyleBackColor = false;
            btnStartRolling.Click += btnStartRolling_Click;
            // 
            // lblSelectedCount
            // 
            lblSelectedCount.AutoSize = true;
            lblSelectedCount.Location = new Point(348, 618);
            lblSelectedCount.Name = "lblSelectedCount";
            lblSelectedCount.Size = new Size(134, 15);
            lblSelectedCount.TabIndex = 1;
            lblSelectedCount.Text = "Total selecionado: 0 / 10";
            // 
            // dgvDesiredStats
            // 
            dgvDesiredStats.AllowUserToAddRows = false;
            dgvDesiredStats.AllowUserToResizeColumns = false;
            dgvDesiredStats.AllowUserToResizeRows = false;
            dgvDesiredStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDesiredStats.BackgroundColor = SystemColors.ActiveCaptionText;
            dgvDesiredStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDesiredStats.Columns.AddRange(new DataGridViewColumn[] { colSelect, colStatName, colQuantity });
            dgvDesiredStats.Location = new Point(6, 22);
            dgvDesiredStats.MultiSelect = false;
            dgvDesiredStats.Name = "dgvDesiredStats";
            dgvDesiredStats.RowHeadersVisible = false;
            dgvDesiredStats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDesiredStats.Size = new Size(484, 583);
            dgvDesiredStats.TabIndex = 0;
            // 
            // colSelect
            // 
            colSelect.FillWeight = 83.10547F;
            colSelect.HeaderText = "Selecionar";
            colSelect.Name = "colSelect";
            // 
            // colStatName
            // 
            colStatName.FillWeight = 140.7524F;
            colStatName.HeaderText = "Atributo";
            colStatName.Name = "colStatName";
            colStatName.ReadOnly = true;
            // 
            // colQuantity
            // 
            colQuantity.FillWeight = 76.1421356F;
            colQuantity.HeaderText = "Qtd";
            colQuantity.Items.AddRange(new object[] { "1", "2" });
            colQuantity.Name = "colQuantity";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(854, 837);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 19;
            label1.Text = "Opacidade:";
            // 
            // trackOpacity
            // 
            trackOpacity.Location = new Point(923, 822);
            trackOpacity.Maximum = 100;
            trackOpacity.Minimum = 20;
            trackOpacity.Name = "trackOpacity";
            trackOpacity.Size = new Size(151, 45);
            trackOpacity.TabIndex = 18;
            trackOpacity.Value = 85;
            trackOpacity.Scroll += trackOpacity_Scroll;
            // 
            // lblStatus
            // 
            lblStatus.AutoEllipsis = true;
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(-1, 849);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(849, 20);
            lblStatus.TabIndex = 17;
            lblStatus.Text = "Pronto.";
            // 
            // lstStats
            // 
            lstStats.BackColor = Color.FromArgb(32, 32, 32);
            lstStats.BorderStyle = BorderStyle.FixedSingle;
            lstStats.ForeColor = Color.White;
            lstStats.FormattingEnabled = true;
            lstStats.ItemHeight = 15;
            lstStats.Location = new Point(800, 477);
            lstStats.Name = "lstStats";
            lstStats.Size = new Size(257, 272);
            lstStats.TabIndex = 16;
            // 
            // lblDetectedStats
            // 
            lblDetectedStats.AutoSize = true;
            lblDetectedStats.ForeColor = Color.White;
            lblDetectedStats.Location = new Point(800, 459);
            lblDetectedStats.Name = "lblDetectedStats";
            lblDetectedStats.Size = new Size(117, 15);
            lblDetectedStats.TabIndex = 15;
            lblDetectedStats.Text = "Atributos detectados";
            // 
            // picCapturedRegion
            // 
            picCapturedRegion.BackColor = Color.Black;
            picCapturedRegion.BorderStyle = BorderStyle.FixedSingle;
            picCapturedRegion.Location = new Point(15, 56);
            picCapturedRegion.Name = "picCapturedRegion";
            picCapturedRegion.Size = new Size(255, 471);
            picCapturedRegion.SizeMode = PictureBoxSizeMode.Zoom;
            picCapturedRegion.TabIndex = 14;
            picCapturedRegion.TabStop = false;
            // 
            // lblCapturedRegion
            // 
            lblCapturedRegion.AutoSize = true;
            lblCapturedRegion.ForeColor = Color.White;
            lblCapturedRegion.Location = new Point(15, 41);
            lblCapturedRegion.Name = "lblCapturedRegion";
            lblCapturedRegion.Size = new Size(99, 15);
            lblCapturedRegion.TabIndex = 13;
            lblCapturedRegion.Text = "Região capturada";
            // 
            // txtOcrRaw
            // 
            txtOcrRaw.BackColor = Color.FromArgb(32, 32, 32);
            txtOcrRaw.BorderStyle = BorderStyle.FixedSingle;
            txtOcrRaw.ForeColor = Color.White;
            txtOcrRaw.Location = new Point(800, 56);
            txtOcrRaw.Multiline = true;
            txtOcrRaw.Name = "txtOcrRaw";
            txtOcrRaw.ScrollBars = ScrollBars.Vertical;
            txtOcrRaw.Size = new Size(257, 395);
            txtOcrRaw.TabIndex = 12;
            // 
            // lblOcrRaw
            // 
            lblOcrRaw.AutoSize = true;
            lblOcrRaw.ForeColor = Color.White;
            lblOcrRaw.Location = new Point(800, 41);
            lblOcrRaw.Name = "lblOcrRaw";
            lblOcrRaw.Size = new Size(63, 15);
            lblOcrRaw.TabIndex = 11;
            lblOcrRaw.Text = "OCR bruto";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(35, 35, 35);
            pnlHeader.Controls.Add(btnHelp);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1075, 40);
            pnlHeader.TabIndex = 0;
            pnlHeader.MouseDown += pnlHeader_MouseDown;
            pnlHeader.MouseMove += pnlHeader_MouseMove;
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.CadetBlue;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHelp.ForeColor = Color.White;
            btnHelp.Location = new Point(1006, 7);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(28, 24);
            btnHelp.TabIndex = 2;
            btnHelp.Text = "?";
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1042, 7);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(28, 24);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(187, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Astrolabio Recaster - by: iTzCROW";
            lblTitle.MouseDown += pnlHeader_MouseDown;
            lblTitle.MouseMove += pnlHeader_MouseMove;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lime;
            ClientSize = new Size(1118, 912);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Astrolabio Recaster - by: iTzCROW";
            TopMost = true;
            TransparencyKey = Color.Lime;
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudVisualDelay).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxAttempts).EndInit();
            grpDesiredStats.ResumeLayout(false);
            grpDesiredStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDesiredStats).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackOpacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCapturedRegion).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlHeader;
        private Button btnClose;
        private Label lblTitle;
        private TextBox txtOcrRaw;
        private Label lblOcrRaw;
        private PictureBox picCapturedRegion;
        private Label lblCapturedRegion;
        private Label lblDetectedStats;
        private ListBox lstStats;
        private Label lblStatus;
        private TrackBar trackOpacity;
        private Label label1;
        private GroupBox grpDesiredStats;
        private DataGridView dgvDesiredStats;
        private Button btnStopRolling;
        private Button btnStartRolling;
        private Label lblSelectedCount;
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colStatName;
        private DataGridViewComboBoxColumn colQuantity;
        private Button btnTestCapture;
        private CheckBox chkUnlimitedAttempts;
        private NumericUpDown nudMaxAttempts;
        private Label lblMaxAttemptsTitle;
        private Label lblAttemptsValue;
        private Label lblAttemptsTitle;
        private Label lblStatusValue;
        private Label lblStatusTitle;
        private Label lblElapsedValue;
        private Label lblElapsedTitle;
        private Button btnCalibrateClick;
        private Label lblClickOffsetValue;
        private Label lblClickOffsetTitle;
        private Label lblClickCalibrationValue;
        private Label lblClickCalibrationTitle;
        private Label lblMatchedStatsValue;
        private Label lblMatchedStatsTitle;
        private NumericUpDown nudVisualDelay;
        private Label lblVisualDelay;
        private Button btnHelp;
    }
}