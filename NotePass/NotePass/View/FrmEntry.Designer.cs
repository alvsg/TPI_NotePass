
namespace NotePass.View
{
    partial class FrmEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntry));
            this.lblDescription = new System.Windows.Forms.Label();
            this.gbxNewEntry = new System.Windows.Forms.GroupBox();
            this.lblFavorites = new System.Windows.Forms.Label();
            this.pbxFavorites = new System.Windows.Forms.PictureBox();
            this.lblDateAdded = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tbxUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.pbxShowPwd = new System.Windows.Forms.PictureBox();
            this.tbxPassowrd = new System.Windows.Forms.TextBox();
            this.tbxWebSiteOrSoftwareName = new System.Windows.Forms.TextBox();
            this.lblWebSiteOrSoftwareName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.gbxNewEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFavorites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(83, 58);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(283, 16);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "* Les champs du formulaire obligatoire à remplir";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxNewEntry
            // 
            this.gbxNewEntry.Controls.Add(this.lblFavorites);
            this.gbxNewEntry.Controls.Add(this.pbxFavorites);
            this.gbxNewEntry.Controls.Add(this.lblDateAdded);
            this.gbxNewEntry.Controls.Add(this.lblDate);
            this.gbxNewEntry.Controls.Add(this.tbxUsername);
            this.gbxNewEntry.Controls.Add(this.lblUsername);
            this.gbxNewEntry.Controls.Add(this.tbxUrl);
            this.gbxNewEntry.Controls.Add(this.lblUrl);
            this.gbxNewEntry.Controls.Add(this.lblPassword);
            this.gbxNewEntry.Controls.Add(this.pbxShowPwd);
            this.gbxNewEntry.Controls.Add(this.tbxPassowrd);
            this.gbxNewEntry.Controls.Add(this.tbxWebSiteOrSoftwareName);
            this.gbxNewEntry.Controls.Add(this.lblWebSiteOrSoftwareName);
            this.gbxNewEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxNewEntry.Location = new System.Drawing.Point(12, 87);
            this.gbxNewEntry.Name = "gbxNewEntry";
            this.gbxNewEntry.Size = new System.Drawing.Size(513, 204);
            this.gbxNewEntry.TabIndex = 9;
            this.gbxNewEntry.TabStop = false;
            // 
            // lblFavorites
            // 
            this.lblFavorites.AutoSize = true;
            this.lblFavorites.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFavorites.Location = new System.Drawing.Point(45, 164);
            this.lblFavorites.Name = "lblFavorites";
            this.lblFavorites.Size = new System.Drawing.Size(57, 16);
            this.lblFavorites.TabIndex = 12;
            this.lblFavorites.Text = "Favoris :";
            // 
            // pbxFavorites
            // 
            this.pbxFavorites.Image = global::NotePass.Properties.Resources.retire_favoris;
            this.pbxFavorites.Location = new System.Drawing.Point(226, 164);
            this.pbxFavorites.Name = "pbxFavorites";
            this.pbxFavorites.Size = new System.Drawing.Size(20, 20);
            this.pbxFavorites.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxFavorites.TabIndex = 5;
            this.pbxFavorites.TabStop = false;
            // 
            // lblDateAdded
            // 
            this.lblDateAdded.AutoSize = true;
            this.lblDateAdded.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateAdded.Location = new System.Drawing.Point(223, 136);
            this.lblDateAdded.Name = "lblDateAdded";
            this.lblDateAdded.Size = new System.Drawing.Size(126, 16);
            this.lblDateAdded.TabIndex = 11;
            this.lblDateAdded.Text = "00.00.0000 00:00:00";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(43, 136);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 16);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "Date :";
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(226, 104);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(232, 20);
            this.tbxUsername.TabIndex = 9;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(45, 105);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(117, 16);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Nom d\'utilisateur* :";
            // 
            // tbxUrl
            // 
            this.tbxUrl.Location = new System.Drawing.Point(226, 52);
            this.tbxUrl.Name = "tbxUrl";
            this.tbxUrl.Size = new System.Drawing.Size(232, 20);
            this.tbxUrl.TabIndex = 7;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrl.Location = new System.Drawing.Point(45, 53);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(41, 16);
            this.lblUrl.TabIndex = 6;
            this.lblUrl.Text = "URL :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(45, 79);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 16);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Mot de passe* :";
            // 
            // pbxShowPwd
            // 
            this.pbxShowPwd.Image = global::NotePass.Properties.Resources.visibe;
            this.pbxShowPwd.Location = new System.Drawing.Point(226, 79);
            this.pbxShowPwd.Name = "pbxShowPwd";
            this.pbxShowPwd.Size = new System.Drawing.Size(20, 20);
            this.pbxShowPwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxShowPwd.TabIndex = 4;
            this.pbxShowPwd.TabStop = false;
            // 
            // tbxPassowrd
            // 
            this.tbxPassowrd.Location = new System.Drawing.Point(252, 78);
            this.tbxPassowrd.Name = "tbxPassowrd";
            this.tbxPassowrd.Size = new System.Drawing.Size(206, 20);
            this.tbxPassowrd.TabIndex = 1;
            // 
            // tbxWebSiteOrSoftwareName
            // 
            this.tbxWebSiteOrSoftwareName.Location = new System.Drawing.Point(226, 26);
            this.tbxWebSiteOrSoftwareName.Name = "tbxWebSiteOrSoftwareName";
            this.tbxWebSiteOrSoftwareName.Size = new System.Drawing.Size(232, 20);
            this.tbxWebSiteOrSoftwareName.TabIndex = 3;
            // 
            // lblWebSiteOrSoftwareName
            // 
            this.lblWebSiteOrSoftwareName.AutoSize = true;
            this.lblWebSiteOrSoftwareName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebSiteOrSoftwareName.Location = new System.Drawing.Point(45, 27);
            this.lblWebSiteOrSoftwareName.Name = "lblWebSiteOrSoftwareName";
            this.lblWebSiteOrSoftwareName.Size = new System.Drawing.Size(171, 16);
            this.lblWebSiteOrSoftwareName.TabIndex = 0;
            this.lblWebSiteOrSoftwareName.Text = "Nom du site ou du logiciel* :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(78, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(269, 46);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Ajouter un entrée";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(412, 297);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(113, 24);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 24);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::NotePass.Properties.Resources.ajouter_entree;
            this.pbxLogo.Location = new System.Drawing.Point(12, 12);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(60, 60);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 7;
            this.pbxLogo.TabStop = false;
            // 
            // FrmEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 337);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.gbxNewEntry);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbxLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmEntry";
            this.Text = "Formulaire d\'ajout";
            this.gbxNewEntry.ResumeLayout(false);
            this.gbxNewEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFavorites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox gbxNewEntry;
        private System.Windows.Forms.PictureBox pbxFavorites;
        private System.Windows.Forms.PictureBox pbxShowPwd;
        private System.Windows.Forms.TextBox tbxWebSiteOrSoftwareName;
        private System.Windows.Forms.TextBox tbxPassowrd;
        private System.Windows.Forms.Label lblWebSiteOrSoftwareName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblFavorites;
        private System.Windows.Forms.Label lblDateAdded;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbxUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}