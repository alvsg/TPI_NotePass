
namespace NotePass
{
    partial class FrmAuthentification
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lblForgottenPwd = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.pbxMessage = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(213, 44);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 60);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "NotePass";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(81, 118);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(272, 20);
            this.tbxPassword.TabIndex = 7;
            this.tbxPassword.TextChanged += new System.EventHandler(this.tbxPassword_TextChanged);
            // 
            // btnEnter
            // 
            this.btnEnter.Enabled = false;
            this.btnEnter.Location = new System.Drawing.Point(359, 116);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 8;
            this.btnEnter.Text = "Entrer";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lblForgottenPwd
            // 
            this.lblForgottenPwd.AutoSize = true;
            this.lblForgottenPwd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgottenPwd.Location = new System.Drawing.Point(188, 141);
            this.lblForgottenPwd.Name = "lblForgottenPwd";
            this.lblForgottenPwd.Size = new System.Drawing.Size(125, 16);
            this.lblForgottenPwd.TabIndex = 9;
            this.lblForgottenPwd.Text = "Mot de passe oublié";
            this.lblForgottenPwd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblForgottenPwd.Click += new System.EventHandler(this.lblForgottenPwd_Click);
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::NotePass.Properties.Resources.NotePass_Logo;
            this.pbxLogo.Location = new System.Drawing.Point(148, 45);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(1);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(60, 60);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 2;
            this.pbxLogo.TabStop = false;
            // 
            // pbxClose
            // 
            this.pbxClose.Image = global::NotePass.Properties.Resources.fermer;
            this.pbxClose.Location = new System.Drawing.Point(494, -1);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(25, 25);
            this.pbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxClose.TabIndex = 10;
            this.pbxClose.TabStop = false;
            this.pbxClose.Click += new System.EventHandler(this.pbxClose_Click);
            // 
            // pbxMessage
            // 
            this.pbxMessage.Image = global::NotePass.Properties.Resources.danger1;
            this.pbxMessage.Location = new System.Drawing.Point(12, 158);
            this.pbxMessage.Name = "pbxMessage";
            this.pbxMessage.Size = new System.Drawing.Size(30, 30);
            this.pbxMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxMessage.TabIndex = 12;
            this.pbxMessage.TabStop = false;
            this.pbxMessage.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(48, 157);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(459, 30);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "Message d\'erreur";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.Visible = false;
            // 
            // FrmAuthentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 197);
            this.Controls.Add(this.pbxMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pbxClose);
            this.Controls.Add(this.lblForgottenPwd);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAuthentification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmAuthentification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lblForgottenPwd;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.PictureBox pbxMessage;
        private System.Windows.Forms.Label lblMessage;
    }
}

