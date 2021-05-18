
namespace NotePass.View
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nsFrmMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOrganize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlphabeticalOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDateAdded = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDateAsc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDateDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFavorites = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVersion = new System.Windows.Forms.Button();
            this.flpEntry = new System.Windows.Forms.FlowLayoutPanel();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nsFrmMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nsFrmMain
            // 
            this.nsFrmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiOrganize,
            this.aideToolStripMenuItem});
            this.nsFrmMain.Location = new System.Drawing.Point(0, 0);
            this.nsFrmMain.Name = "nsFrmMain";
            this.nsFrmMain.Size = new System.Drawing.Size(1062, 24);
            this.nsFrmMain.TabIndex = 3;
            this.nsFrmMain.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.toolStripSeparator1,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(54, 20);
            this.tsmiFile.Text = "&Fichier";
            // 
            // tsmiNew
            // 
            this.tsmiNew.Image = global::NotePass.Properties.Resources.ajouter_entree;
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiNew.Size = new System.Drawing.Size(180, 22);
            this.tsmiNew.Text = "&Nouveau";
            this.tsmiNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = global::NotePass.Properties.Resources.fermer;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsmiExit.Size = new System.Drawing.Size(180, 22);
            this.tsmiExit.Text = "&Quitter";
            // 
            // tsmiOrganize
            // 
            this.tsmiOrganize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAlphabeticalOrder,
            this.tsmiDateAdded});
            this.tsmiOrganize.Name = "tsmiOrganize";
            this.tsmiOrganize.Size = new System.Drawing.Size(70, 20);
            this.tsmiOrganize.Text = "&Oragniser";
            // 
            // tsmiAlphabeticalOrder
            // 
            this.tsmiAlphabeticalOrder.Image = global::NotePass.Properties.Resources.ordre_aphabetique;
            this.tsmiAlphabeticalOrder.Name = "tsmiAlphabeticalOrder";
            this.tsmiAlphabeticalOrder.Size = new System.Drawing.Size(180, 22);
            this.tsmiAlphabeticalOrder.Text = "Ordre a&lphabétique";
            this.tsmiAlphabeticalOrder.Click += new System.EventHandler(this.tsmiAlphabeticalOrder_Click);
            // 
            // tsmiDateAdded
            // 
            this.tsmiDateAdded.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDateAsc,
            this.tsmiDateDesc});
            this.tsmiDateAdded.Image = global::NotePass.Properties.Resources.date;
            this.tsmiDateAdded.Name = "tsmiDateAdded";
            this.tsmiDateAdded.Size = new System.Drawing.Size(180, 22);
            this.tsmiDateAdded.Text = "&Date d\'ajout";
            // 
            // tsmiDateAsc
            // 
            this.tsmiDateAsc.Image = global::NotePass.Properties.Resources.date_croissant;
            this.tsmiDateAsc.Name = "tsmiDateAsc";
            this.tsmiDateAsc.Size = new System.Drawing.Size(167, 22);
            this.tsmiDateAsc.Text = "Ordre &croissant";
            this.tsmiDateAsc.Click += new System.EventHandler(this.tsmiDateAsc_Click);
            // 
            // tsmiDateDesc
            // 
            this.tsmiDateDesc.Image = global::NotePass.Properties.Resources.date_decroissant;
            this.tsmiDateDesc.Name = "tsmiDateDesc";
            this.tsmiDateDesc.Size = new System.Drawing.Size(167, 22);
            this.tsmiDateDesc.Text = "Ordre décroi&ssant";
            this.tsmiDateDesc.Click += new System.EventHandler(this.tsmiDateDesc_Click);
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::NotePass.Properties.Resources.NotePass_Logo;
            this.pbxLogo.Location = new System.Drawing.Point(6, 12);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(1);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(60, 60);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 4;
            this.pbxLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(68, 12);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(137, 60);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "NotePass";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(6, 73);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(226, 54);
            this.btnHome.TabIndex = 6;
            this.btnHome.Text = "Accueil";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(232, 74);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(53, 53);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFavorites
            // 
            this.btnFavorites.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFavorites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavorites.Location = new System.Drawing.Point(7, 127);
            this.btnFavorites.Margin = new System.Windows.Forms.Padding(0);
            this.btnFavorites.Name = "btnFavorites";
            this.btnFavorites.Size = new System.Drawing.Size(279, 53);
            this.btnFavorites.TabIndex = 8;
            this.btnFavorites.Text = "Favoris";
            this.btnFavorites.UseVisualStyleBackColor = true;
            this.btnFavorites.Click += new System.EventHandler(this.btnFavorites_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(6, 894);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(280, 83);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Quitter";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnVersion);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnFavorites);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pbxLogo);
            this.panel1.Location = new System.Drawing.Point(-7, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 984);
            this.panel1.TabIndex = 1;
            // 
            // btnVersion
            // 
            this.btnVersion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVersion.Location = new System.Drawing.Point(7, 858);
            this.btnVersion.Margin = new System.Windows.Forms.Padding(0);
            this.btnVersion.Name = "btnVersion";
            this.btnVersion.Size = new System.Drawing.Size(279, 36);
            this.btnVersion.TabIndex = 10;
            this.btnVersion.Text = "03.05.2020 v.0.0.0";
            this.btnVersion.UseVisualStyleBackColor = true;
            // 
            // flpEntry
            // 
            this.flpEntry.Location = new System.Drawing.Point(284, 25);
            this.flpEntry.Margin = new System.Windows.Forms.Padding(5);
            this.flpEntry.Name = "flpEntry";
            this.flpEntry.Size = new System.Drawing.Size(778, 965);
            this.flpEntry.TabIndex = 2;
            this.flpEntry.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flpEntry_ControlAdded);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.aideToolStripMenuItem.Text = "&Aide";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 991);
            this.Controls.Add(this.flpEntry);
            this.Controls.Add(this.nsFrmMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.nsFrmMain.ResumeLayout(false);
            this.nsFrmMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip nsFrmMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrganize;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlphabeticalOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiDateAdded;
        private System.Windows.Forms.ToolStripMenuItem tsmiDateAsc;
        private System.Windows.Forms.ToolStripMenuItem tsmiDateDesc;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFavorites;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpEntry;
        private System.Windows.Forms.Button btnVersion;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
    }
}