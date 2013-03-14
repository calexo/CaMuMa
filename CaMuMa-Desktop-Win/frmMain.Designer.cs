namespace Calexo.CaMuMa
{
    partial class frmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnVerif = new System.Windows.Forms.Button();
            this.fbdMusicPath = new System.Windows.Forms.FolderBrowserDialog();
            this.lblMusicFolder = new System.Windows.Forms.Label();
            this.txtMusicFolder = new System.Windows.Forms.TextBox();
            this.cmbNotebook = new System.Windows.Forms.ComboBox();
            this.lblNotebook = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMin = new System.Windows.Forms.Button();
            this.lblAddTag = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lnkCalexo = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnAddTags = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblAction = new System.Windows.Forms.Label();
            this.rbActSpotify = new System.Windows.Forms.RadioButton();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.rbReplace = new System.Windows.Forms.RadioButton();
            this.chkReadOnly = new System.Windows.Forms.CheckBox();
            this.chkMusicFiles = new System.Windows.Forms.CheckBox();
            this.chkSpotify = new System.Windows.Forms.CheckBox();
            this.chkAddIdTags = new System.Windows.Forms.CheckBox();
            this.chkEvernote = new System.Windows.Forms.CheckBox();
            this.chkPdf = new System.Windows.Forms.CheckBox();
            this.chkRegenLists = new System.Windows.Forms.CheckBox();
            this.lblDevKey = new System.Windows.Forms.Label();
            this.txtDevKey = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.Black;
            this.txtUser.Enabled = false;
            this.txtUser.ForeColor = System.Drawing.Color.Orange;
            this.txtUser.Location = new System.Drawing.Point(95, 20);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(185, 20);
            this.txtUser.TabIndex = 1;
            this.txtUser.Text = "calexo";
            this.txtUser.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUser.Location = new System.Drawing.Point(16, 23);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(33, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "&User";
            this.lblUser.Visible = false;
            // 
            // btnVerif
            // 
            this.btnVerif.BackColor = System.Drawing.Color.DimGray;
            this.btnVerif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerif.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerif.ForeColor = System.Drawing.Color.Orange;
            this.btnVerif.Location = new System.Drawing.Point(511, 31);
            this.btnVerif.Name = "btnVerif";
            this.btnVerif.Size = new System.Drawing.Size(75, 23);
            this.btnVerif.TabIndex = 6;
            this.btnVerif.Text = "&Verify";
            this.btnVerif.UseVisualStyleBackColor = false;
            this.btnVerif.Visible = false;
            this.btnVerif.Click += new System.EventHandler(this.Vérifier_Click);
            // 
            // fbdMusicPath
            // 
            this.fbdMusicPath.Description = "Select your Music folder";
            this.fbdMusicPath.ShowNewFolderButton = false;
            // 
            // lblMusicFolder
            // 
            this.lblMusicFolder.AutoSize = true;
            this.lblMusicFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusicFolder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMusicFolder.Location = new System.Drawing.Point(16, 107);
            this.lblMusicFolder.Name = "lblMusicFolder";
            this.lblMusicFolder.Size = new System.Drawing.Size(76, 13);
            this.lblMusicFolder.TabIndex = 7;
            this.lblMusicFolder.Text = "&Music folder";
            // 
            // txtMusicFolder
            // 
            this.txtMusicFolder.BackColor = System.Drawing.Color.White;
            this.txtMusicFolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMusicFolder.ForeColor = System.Drawing.Color.Black;
            this.txtMusicFolder.Location = new System.Drawing.Point(95, 102);
            this.txtMusicFolder.Name = "txtMusicFolder";
            this.txtMusicFolder.ReadOnly = true;
            this.txtMusicFolder.Size = new System.Drawing.Size(200, 29);
            this.txtMusicFolder.TabIndex = 8;
            // 
            // cmbNotebook
            // 
            this.cmbNotebook.BackColor = System.Drawing.Color.White;
            this.cmbNotebook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNotebook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNotebook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNotebook.ForeColor = System.Drawing.Color.Black;
            this.cmbNotebook.FormattingEnabled = true;
            this.cmbNotebook.Location = new System.Drawing.Point(95, 71);
            this.cmbNotebook.Name = "cmbNotebook";
            this.cmbNotebook.Size = new System.Drawing.Size(231, 29);
            this.cmbNotebook.Sorted = true;
            this.cmbNotebook.TabIndex = 11;
            this.cmbNotebook.SelectedIndexChanged += new System.EventHandler(this.cmbNotebook_SelectedIndexChanged);
            // 
            // lblNotebook
            // 
            this.lblNotebook.AutoSize = true;
            this.lblNotebook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotebook.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotebook.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNotebook.Location = new System.Drawing.Point(16, 78);
            this.lblNotebook.Name = "lblNotebook";
            this.lblNotebook.Size = new System.Drawing.Size(62, 13);
            this.lblNotebook.TabIndex = 12;
            this.lblNotebook.Text = "&Notebook";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(756, 57);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Orange;
            this.lblTitle.Location = new System.Drawing.Point(490, 61);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(234, 23);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "Calexo - CaMuMa";
            this.lblTitle.Visible = false;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseUp);
            // 
            // btnMin
            // 
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Location = new System.Drawing.Point(727, 57);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(23, 23);
            this.btnMin.TabIndex = 16;
            this.btnMin.Text = "--";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Visible = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // lblAddTag
            // 
            this.lblAddTag.AutoSize = true;
            this.lblAddTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddTag.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAddTag.Location = new System.Drawing.Point(16, 133);
            this.lblAddTag.Name = "lblAddTag";
            this.lblAddTag.Size = new System.Drawing.Size(75, 13);
            this.lblAddTag.TabIndex = 20;
            this.lblAddTag.Text = "&Tags to add";
            this.lblAddTag.Visible = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lnkCalexo
            // 
            this.lnkCalexo.LinkArea = new System.Windows.Forms.LinkArea(3, 6);
            this.lnkCalexo.Location = new System.Drawing.Point(363, 123);
            this.lnkCalexo.Name = "lnkCalexo";
            this.lnkCalexo.Size = new System.Drawing.Size(100, 13);
            this.lnkCalexo.TabIndex = 30;
            this.lnkCalexo.TabStop = true;
            this.lnkCalexo.Text = "by Calexo";
            this.lnkCalexo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkCalexo.UseCompatibleTextRendering = true;
            this.lnkCalexo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCalexo_LinkClicked);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(369, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "CaMuMa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGo
            // 
            this.btnGo.AccessibleDescription = "Go";
            this.btnGo.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGo.FlatAppearance.BorderSize = 2;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGo.Location = new System.Drawing.Point(364, 236);
            this.btnGo.Margin = new System.Windows.Forms.Padding(0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(100, 35);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "&Go";
            this.btnGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // pctLogo
            // 
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctLogo.Image = global::Calexo.CaMuMa.Properties.Resources.CaMuMa;
            this.pctLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pctLogo.InitialImage")));
            this.pctLogo.Location = new System.Drawing.Point(366, 7);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(100, 100);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 29;
            this.pctLogo.TabStop = false;
            // 
            // btnSetup
            // 
            this.btnSetup.AccessibleDescription = "Options";
            this.btnSetup.BackColor = System.Drawing.Color.Transparent;
            this.btnSetup.BackgroundImage = global::Calexo.CaMuMa.Properties.Resources.button_empty_100x25;
            this.btnSetup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSetup.FlatAppearance.BorderSize = 0;
            this.btnSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSetup.Location = new System.Drawing.Point(511, 87);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(100, 25);
            this.btnSetup.TabIndex = 27;
            this.btnSetup.Text = "&Options";
            this.btnSetup.UseVisualStyleBackColor = false;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnAddTags
            // 
            this.btnAddTags.BackColor = System.Drawing.Color.Transparent;
            this.btnAddTags.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddTags.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddTags.FlatAppearance.BorderSize = 2;
            this.btnAddTags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTags.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTags.Location = new System.Drawing.Point(95, 131);
            this.btnAddTags.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddTags.Name = "btnAddTags";
            this.btnAddTags.Size = new System.Drawing.Size(231, 32);
            this.btnAddTags.TabIndex = 22;
            this.btnAddTags.Text = "Tags to Add...";
            this.btnAddTags.UseVisualStyleBackColor = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBrowse.FlatAppearance.BorderSize = 2;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBrowse.Location = new System.Drawing.Point(301, 102);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(47, 29);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStop.FlatAppearance.BorderSize = 2;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStop.Location = new System.Drawing.Point(364, 236);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 35);
            this.btnStop.TabIndex = 28;
            this.btnStop.Text = "&Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInfo.Location = new System.Drawing.Point(6, 311);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(5);
            this.lblInfo.Size = new System.Drawing.Size(457, 57);
            this.lblInfo.TabIndex = 33;
            this.lblInfo.Text = "Info...\r\nInfo...";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(9, 285);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(455, 23);
            this.pbProgress.TabIndex = 32;
            this.pbProgress.Value = 25;
            this.pbProgress.Visible = false;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(16, 166);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(43, 13);
            this.lblAction.TabIndex = 37;
            this.lblAction.Text = "&Action";
            this.lblAction.Visible = false;
            // 
            // rbActSpotify
            // 
            this.rbActSpotify.BackColor = System.Drawing.Color.Transparent;
            this.rbActSpotify.BackgroundImage = global::Calexo.CaMuMa.Properties.Resources.button_empty_150x25;
            this.rbActSpotify.FlatAppearance.BorderSize = 0;
            this.rbActSpotify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbActSpotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActSpotify.Location = new System.Drawing.Point(514, 166);
            this.rbActSpotify.Name = "rbActSpotify";
            this.rbActSpotify.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.rbActSpotify.Size = new System.Drawing.Size(150, 25);
            this.rbActSpotify.TabIndex = 36;
            this.rbActSpotify.Text = "Just Add Spotify";
            this.rbActSpotify.UseVisualStyleBackColor = false;
            this.rbActSpotify.Visible = false;
            // 
            // rbAdd
            // 
            this.rbAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.rbAdd.Checked = true;
            this.rbAdd.FlatAppearance.BorderSize = 0;
            this.rbAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAdd.Location = new System.Drawing.Point(95, 197);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.rbAdd.Size = new System.Drawing.Size(150, 25);
            this.rbAdd.TabIndex = 35;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "Add";
            this.rbAdd.UseVisualStyleBackColor = false;
            // 
            // rbReplace
            // 
            this.rbReplace.BackColor = System.Drawing.SystemColors.Highlight;
            this.rbReplace.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.rbReplace.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGreen;
            this.rbReplace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.rbReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbReplace.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReplace.Location = new System.Drawing.Point(95, 166);
            this.rbReplace.Name = "rbReplace";
            this.rbReplace.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.rbReplace.Size = new System.Drawing.Size(150, 25);
            this.rbReplace.TabIndex = 34;
            this.rbReplace.Text = "Add && Modify";
            this.rbReplace.UseVisualStyleBackColor = false;
            // 
            // chkReadOnly
            // 
            this.chkReadOnly.BackColor = System.Drawing.Color.Transparent;
            this.chkReadOnly.BackgroundImage = global::Calexo.CaMuMa.Properties.Resources.button_empty_150x25;
            this.chkReadOnly.Checked = true;
            this.chkReadOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadOnly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkReadOnly.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.chkReadOnly.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGreen;
            this.chkReadOnly.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.chkReadOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkReadOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReadOnly.Location = new System.Drawing.Point(511, 138);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.chkReadOnly.Size = new System.Drawing.Size(150, 25);
            this.chkReadOnly.TabIndex = 40;
            this.chkReadOnly.Text = "Read-Only notes";
            this.chkReadOnly.UseVisualStyleBackColor = false;
            this.chkReadOnly.Visible = false;
            // 
            // chkMusicFiles
            // 
            this.chkMusicFiles.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkMusicFiles.Checked = true;
            this.chkMusicFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMusicFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMusicFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMusicFiles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMusicFiles.Location = new System.Drawing.Point(263, 166);
            this.chkMusicFiles.Name = "chkMusicFiles";
            this.chkMusicFiles.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.chkMusicFiles.Size = new System.Drawing.Size(150, 25);
            this.chkMusicFiles.TabIndex = 39;
            this.chkMusicFiles.Text = "Only music files";
            this.chkMusicFiles.UseVisualStyleBackColor = false;
            // 
            // chkSpotify
            // 
            this.chkSpotify.BackColor = System.Drawing.Color.Transparent;
            this.chkSpotify.BackgroundImage = global::Calexo.CaMuMa.Properties.Resources.button_empty_150x25;
            this.chkSpotify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkSpotify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSpotify.FlatAppearance.BorderSize = 0;
            this.chkSpotify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSpotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpotify.Location = new System.Drawing.Point(682, 166);
            this.chkSpotify.Margin = new System.Windows.Forms.Padding(0);
            this.chkSpotify.Name = "chkSpotify";
            this.chkSpotify.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.chkSpotify.Size = new System.Drawing.Size(150, 25);
            this.chkSpotify.TabIndex = 38;
            this.chkSpotify.Text = "Add Spotify links";
            this.chkSpotify.UseVisualStyleBackColor = false;
            this.chkSpotify.Visible = false;
            // 
            // chkAddIdTags
            // 
            this.chkAddIdTags.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkAddIdTags.Checked = true;
            this.chkAddIdTags.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddIdTags.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAddIdTags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAddIdTags.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAddIdTags.Location = new System.Drawing.Point(263, 196);
            this.chkAddIdTags.Name = "chkAddIdTags";
            this.chkAddIdTags.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.chkAddIdTags.Size = new System.Drawing.Size(150, 25);
            this.chkAddIdTags.TabIndex = 41;
            this.chkAddIdTags.Text = "Add Id + QR";
            this.chkAddIdTags.UseVisualStyleBackColor = false;
            // 
            // chkEvernote
            // 
            this.chkEvernote.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkEvernote.Checked = true;
            this.chkEvernote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEvernote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkEvernote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEvernote.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEvernote.Location = new System.Drawing.Point(198, 228);
            this.chkEvernote.Name = "chkEvernote";
            this.chkEvernote.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.chkEvernote.Size = new System.Drawing.Size(150, 25);
            this.chkEvernote.TabIndex = 42;
            this.chkEvernote.Text = "Sync Evernote";
            this.chkEvernote.UseVisualStyleBackColor = false;
            // 
            // chkPdf
            // 
            this.chkPdf.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPdf.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPdf.Location = new System.Drawing.Point(42, 228);
            this.chkPdf.Name = "chkPdf";
            this.chkPdf.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.chkPdf.Size = new System.Drawing.Size(150, 25);
            this.chkPdf.TabIndex = 43;
            this.chkPdf.Text = "PDF";
            this.chkPdf.UseVisualStyleBackColor = false;
            this.chkPdf.Visible = false;
            // 
            // chkRegenLists
            // 
            this.chkRegenLists.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkRegenLists.Checked = true;
            this.chkRegenLists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRegenLists.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRegenLists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRegenLists.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRegenLists.Location = new System.Drawing.Point(198, 254);
            this.chkRegenLists.Name = "chkRegenLists";
            this.chkRegenLists.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.chkRegenLists.Size = new System.Drawing.Size(150, 25);
            this.chkRegenLists.TabIndex = 44;
            this.chkRegenLists.Text = "Regen Lists";
            this.chkRegenLists.UseVisualStyleBackColor = false;
            // 
            // lblDevKey
            // 
            this.lblDevKey.AutoSize = true;
            this.lblDevKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDevKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevKey.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDevKey.Location = new System.Drawing.Point(16, 49);
            this.lblDevKey.Name = "lblDevKey";
            this.lblDevKey.Size = new System.Drawing.Size(55, 13);
            this.lblDevKey.TabIndex = 46;
            this.lblDevKey.Text = "Dev &Key";
            // 
            // txtDevKey
            // 
            this.txtDevKey.BackColor = System.Drawing.Color.White;
            this.txtDevKey.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDevKey.ForeColor = System.Drawing.Color.Black;
            this.txtDevKey.Location = new System.Drawing.Point(95, 40);
            this.txtDevKey.Name = "txtDevKey";
            this.txtDevKey.Size = new System.Drawing.Size(231, 29);
            this.txtDevKey.TabIndex = 45;
            this.txtDevKey.TextChanged += new System.EventHandler(this.txtDevKey_TextChanged);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(472, 366);
            this.Controls.Add(this.lblDevKey);
            this.Controls.Add(this.txtDevKey);
            this.Controls.Add(this.chkRegenLists);
            this.Controls.Add(this.chkPdf);
            this.Controls.Add(this.chkEvernote);
            this.Controls.Add(this.chkAddIdTags);
            this.Controls.Add(this.chkReadOnly);
            this.Controls.Add(this.chkMusicFiles);
            this.Controls.Add(this.chkSpotify);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.rbActSpotify);
            this.Controls.Add(this.rbAdd);
            this.Controls.Add(this.rbReplace);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkCalexo);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.btnAddTags);
            this.Controls.Add(this.lblAddTag);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNotebook);
            this.Controls.Add(this.cmbNotebook);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtMusicFolder);
            this.Controls.Add(this.lblMusicFolder);
            this.Controls.Add(this.btnVerif);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnStop);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Calexo - Music Management (CaMuMa)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnVerif;
        private System.Windows.Forms.FolderBrowserDialog fbdMusicPath;
        private System.Windows.Forms.Label lblMusicFolder;
        private System.Windows.Forms.TextBox txtMusicFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cmbNotebook;
        private System.Windows.Forms.Label lblNotebook;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Label lblAddTag;
        private System.Windows.Forms.Button btnAddTags;
        private System.Windows.Forms.Button btnSetup;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.LinkLabel lnkCalexo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblInfo;
        public System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblAction;
        public System.Windows.Forms.RadioButton rbActSpotify;
        public System.Windows.Forms.RadioButton rbAdd;
        public System.Windows.Forms.RadioButton rbReplace;
        public System.Windows.Forms.CheckBox chkReadOnly;
        public System.Windows.Forms.CheckBox chkMusicFiles;
        public System.Windows.Forms.CheckBox chkSpotify;
        public System.Windows.Forms.CheckBox chkAddIdTags;
        public System.Windows.Forms.CheckBox chkEvernote;
        public System.Windows.Forms.CheckBox chkPdf;
        public System.Windows.Forms.CheckBox chkRegenLists;
        private System.Windows.Forms.Label lblDevKey;
        private System.Windows.Forms.TextBox txtDevKey;
    }
}

