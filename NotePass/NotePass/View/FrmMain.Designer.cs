
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFavorites = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.flpEntry = new System.Windows.Forms.FlowLayoutPanel();
            this.nsFrmMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOrganize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlphabeticalOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDateAdded = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAsc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.nsFrmMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnFavorites);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pbxLogo);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 962);
            this.panel1.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(1, 854);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(1);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(293, 26);
            this.lblInfo.TabIndex = 10;
            this.lblInfo.Text = "03.05.2021 v.1";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(1, 881);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(294, 81);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Quitter";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnFavorites
            // 
            this.btnFavorites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavorites.Location = new System.Drawing.Point(1, 117);
            this.btnFavorites.Margin = new System.Windows.Forms.Padding(0);
            this.btnFavorites.Name = "btnFavorites";
            this.btnFavorites.Size = new System.Drawing.Size(294, 53);
            this.btnFavorites.TabIndex = 8;
            this.btnFavorites.Text = "Favoris";
            this.btnFavorites.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(242, 63);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(53, 53);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(1, 63);
            this.btnHome.Margin = new System.Windows.Forms.Padding(1);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(241, 53);
            this.btnHome.TabIndex = 6;
            this.btnHome.Text = "Accueil";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(63, 1);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(137, 60);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "NotePass";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::NotePass.Properties.Resources.NotePass_Logo;
            this.pbxLogo.Location = new System.Drawing.Point(1, 1);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(1);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(60, 60);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 4;
            this.pbxLogo.TabStop = false;
            // 
            // flpEntry
            // 
            this.flpEntry.Location = new System.Drawing.Point(298, 28);
            this.flpEntry.Margin = new System.Windows.Forms.Padding(5);
            this.flpEntry.Name = "flpEntry";
            this.flpEntry.Size = new System.Drawing.Size(764, 962);
            this.flpEntry.TabIndex = 2;
            // 
            // nsFrmMain
            // 
            this.nsFrmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiModify,
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
            // tsmiModify
            // 
            this.tsmiModify.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopy,
            this.tsmiCut,
            this.tsmiPaste});
            this.tsmiModify.Name = "tsmiModify";
            this.tsmiModify.Size = new System.Drawing.Size(64, 20);
            this.tsmiModify.Text = "&Modifier";
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmiCopy.Size = new System.Drawing.Size(180, 22);
            this.tsmiCopy.Text = "Copier";
            // 
            // tsmiCut
            // 
            this.tsmiCut.Name = "tsmiCut";
            this.tsmiCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmiCut.Size = new System.Drawing.Size(180, 22);
            this.tsmiCut.Text = "Couper";
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmiPaste.Size = new System.Drawing.Size(180, 22);
            this.tsmiPaste.Text = "Coller";
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
            // 
            // tsmiDateAdded
            // 
            this.tsmiDateAdded.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAsc,
            this.tsmiDesc});
            this.tsmiDateAdded.Image = global::NotePass.Properties.Resources.date;
            this.tsmiDateAdded.Name = "tsmiDateAdded";
            this.tsmiDateAdded.Size = new System.Drawing.Size(180, 22);
            this.tsmiDateAdded.Text = "&Date d\'ajout";
            // 
            // tsmiAsc
            // 
            this.tsmiAsc.Image = global::NotePass.Properties.Resources.date_croissant;
            this.tsmiAsc.Name = "tsmiAsc";
            this.tsmiAsc.Size = new System.Drawing.Size(180, 22);
            this.tsmiAsc.Text = "Ordre &croissant";
            // 
            // tsmiDesc
            // 
            this.tsmiDesc.Image = global::NotePass.Properties.Resources.date_decroissant;
            this.tsmiDesc.Name = "tsmiDesc";
            this.tsmiDesc.Size = new System.Drawing.Size(180, 22);
            this.tsmiDesc.Text = "Ordre décroi&ssant";
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
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nsFrmMain);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.nsFrmMain.ResumeLayout(false);
            this.nsFrmMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFavorites;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.FlowLayoutPanel flpEntry;
        private System.Windows.Forms.MenuStrip nsFrmMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiModify;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiCut;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaste;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrganize;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlphabeticalOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiDateAdded;
        private System.Windows.Forms.ToolStripMenuItem tsmiAsc;
        private System.Windows.Forms.ToolStripMenuItem tsmiDesc;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
    }
}