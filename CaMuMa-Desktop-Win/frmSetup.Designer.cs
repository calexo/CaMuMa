namespace Calexo.CaMuMa
{
    partial class frmSetup
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
            this.lblOptions = new System.Windows.Forms.Label();
            this.chkMusicFiles = new System.Windows.Forms.CheckBox();
            this.chkReadOnly = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.chkSpotify = new System.Windows.Forms.CheckBox();
            this.rbReplace = new System.Windows.Forms.RadioButton();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.rbActSpotify = new System.Windows.Forms.RadioButton();
            this.lblAction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.Location = new System.Drawing.Point(12, 170);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(50, 13);
            this.lblOptions.TabIndex = 31;
            this.lblOptions.Text = "Options";
            // 
            // chkMusicFiles
            // 
            this.chkMusicFiles.BackColor = System.Drawing.Color.Transparent;
            this.chkMusicFiles.BackgroundImage = global::Calexo.CaMuMa.Properties.Resources.button_empty_150x25;
            this.chkMusicFiles.Checked = true;
            this.chkMusicFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMusicFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMusicFiles.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.chkMusicFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGreen;
            this.chkMusicFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.chkMusicFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMusicFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMusicFiles.Location = new System.Drawing.Point(86, 189);
            this.chkMusicFiles.Name = "chkMusicFiles";
            this.chkMusicFiles.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.chkMusicFiles.Size = new System.Drawing.Size(150, 25);
            this.chkMusicFiles.TabIndex = 33;
            this.chkMusicFiles.Text = "Only music files";
            this.chkMusicFiles.UseVisualStyleBackColor = false;
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
            this.chkReadOnly.Location = new System.Drawing.Point(86, 218);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.chkReadOnly.Size = new System.Drawing.Size(150, 25);
            this.chkReadOnly.TabIndex = 35;
            this.chkReadOnly.Text = "Read-Only notes";
            this.chkReadOnly.UseVisualStyleBackColor = false;
            // 
            // btnGo
            // 
            this.btnGo.BackgroundImage = global::Calexo.CaMuMa.Properties.Resources.button_empty_100x35;
            this.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGo.FlatAppearance.BorderSize = 0;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(145, 306);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(100, 35);
            this.btnGo.TabIndex = 40;
            this.btnGo.Text = "&OK";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // chkSpotify
            // 
            this.chkSpotify.BackColor = System.Drawing.Color.Transparent;
            this.chkSpotify.BackgroundImage = global::Calexo.CaMuMa.Properties.Resources.button_empty_150x25;
            this.chkSpotify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkSpotify.Checked = true;
            this.chkSpotify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpotify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSpotify.FlatAppearance.BorderSize = 0;
            this.chkSpotify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSpotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpotify.Location = new System.Drawing.Point(86, 160);
            this.chkSpotify.Margin = new System.Windows.Forms.Padding(0);
            this.chkSpotify.Name = "chkSpotify";
            this.chkSpotify.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.chkSpotify.Size = new System.Drawing.Size(150, 25);
            this.chkSpotify.TabIndex = 27;
            this.chkSpotify.Text = "Add Spotify links";
            this.chkSpotify.UseVisualStyleBackColor = false;
            // 
            // rbReplace
            // 
            this.rbReplace.BackColor = System.Drawing.Color.Transparent;
            this.rbReplace.BackgroundImage = global::Calexo.CaMuMa.Properties.Resources.button_empty_150x25;
            this.rbReplace.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.rbReplace.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGreen;
            this.rbReplace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.rbReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReplace.Location = new System.Drawing.Point(86, 46);
            this.rbReplace.Name = "rbReplace";
            this.rbReplace.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.rbReplace.Size = new System.Drawing.Size(150, 25);
            this.rbReplace.TabIndex = 28;
            this.rbReplace.Text = "Add && Modify";
            this.rbReplace.UseVisualStyleBackColor = false;
            // 
            // rbAdd
            // 
            this.rbAdd.BackColor = System.Drawing.Color.Transparent;
            this.rbAdd.BackgroundImage = global::Calexo.CaMuMa.Properties.Resources.button_empty_150x25;
            this.rbAdd.Checked = true;
            this.rbAdd.FlatAppearance.BorderSize = 0;
            this.rbAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAdd.Location = new System.Drawing.Point(86, 77);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.rbAdd.Size = new System.Drawing.Size(150, 25);
            this.rbAdd.TabIndex = 29;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "Add";
            this.rbAdd.UseVisualStyleBackColor = false;
            // 
            // rbActSpotify
            // 
            this.rbActSpotify.BackColor = System.Drawing.Color.Transparent;
            this.rbActSpotify.BackgroundImage = global::Calexo.CaMuMa.Properties.Resources.button_empty_150x25;
            this.rbActSpotify.FlatAppearance.BorderSize = 0;
            this.rbActSpotify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbActSpotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActSpotify.Location = new System.Drawing.Point(86, 108);
            this.rbActSpotify.Name = "rbActSpotify";
            this.rbActSpotify.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.rbActSpotify.Size = new System.Drawing.Size(150, 25);
            this.rbActSpotify.TabIndex = 30;
            this.rbActSpotify.Text = "Just Add Spotify";
            this.rbActSpotify.UseVisualStyleBackColor = false;
            this.rbActSpotify.Visible = false;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(19, 57);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(43, 13);
            this.lblAction.TabIndex = 32;
            this.lblAction.Text = "Action";
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 353);
            this.ControlBox = false;
            this.Controls.Add(this.chkReadOnly);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.chkMusicFiles);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblOptions);
            this.Controls.Add(this.rbActSpotify);
            this.Controls.Add(this.rbAdd);
            this.Controls.Add(this.rbReplace);
            this.Controls.Add(this.chkSpotify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calexo CaMuMa - Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.Button btnGo;
        public System.Windows.Forms.CheckBox chkSpotify;
        public System.Windows.Forms.CheckBox chkMusicFiles;
        public System.Windows.Forms.CheckBox chkReadOnly;
        public System.Windows.Forms.RadioButton rbReplace;
        public System.Windows.Forms.RadioButton rbAdd;
        public System.Windows.Forms.RadioButton rbActSpotify;
        private System.Windows.Forms.Label lblAction;
    }
}