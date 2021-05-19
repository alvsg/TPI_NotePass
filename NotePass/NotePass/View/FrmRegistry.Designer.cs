
namespace NotePass.View
{
    partial class FrmRegistry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistry));
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbxPassword = new System.Windows.Forms.GroupBox();
            this.cbxRandomPwd = new System.Windows.Forms.CheckBox();
            this.pbxShowPwdConf = new System.Windows.Forms.PictureBox();
            this.pbxShowPwd = new System.Windows.Forms.PictureBox();
            this.tbxPasswordConf = new System.Windows.Forms.TextBox();
            this.lblPasswordConf = new System.Windows.Forms.Label();
            this.tbxPassowrd = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.gbxQuestions = new System.Windows.Forms.GroupBox();
            this.cbxQuestion3 = new System.Windows.Forms.ComboBox();
            this.tbxQuestion3Answer = new System.Windows.Forms.TextBox();
            this.lblQuestion3Answer = new System.Windows.Forms.Label();
            this.lblQuestion3 = new System.Windows.Forms.Label();
            this.cbxQuestion2 = new System.Windows.Forms.ComboBox();
            this.tbxQuestion2Answer = new System.Windows.Forms.TextBox();
            this.lblQuestion2Answer = new System.Windows.Forms.Label();
            this.lblQuestion2 = new System.Windows.Forms.Label();
            this.cbxQuestion1 = new System.Windows.Forms.ComboBox();
            this.tbxQuestion1Answer = new System.Windows.Forms.TextBox();
            this.lblQuestion1Answer = new System.Windows.Forms.Label();
            this.lblQuestion1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pbxMessage = new System.Windows.Forms.PictureBox();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.gbxPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowPwdConf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowPwd)).BeginInit();
            this.gbxQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(78, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(287, 46);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Crée votre compte";
            // 
            // gbxPassword
            // 
            this.gbxPassword.Controls.Add(this.cbxRandomPwd);
            this.gbxPassword.Controls.Add(this.pbxShowPwdConf);
            this.gbxPassword.Controls.Add(this.pbxShowPwd);
            this.gbxPassword.Controls.Add(this.tbxPasswordConf);
            this.gbxPassword.Controls.Add(this.lblPasswordConf);
            this.gbxPassword.Controls.Add(this.tbxPassowrd);
            this.gbxPassword.Controls.Add(this.lblPassword);
            this.gbxPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxPassword.Location = new System.Drawing.Point(12, 87);
            this.gbxPassword.Name = "gbxPassword";
            this.gbxPassword.Size = new System.Drawing.Size(450, 119);
            this.gbxPassword.TabIndex = 2;
            this.gbxPassword.TabStop = false;
            // 
            // cbxRandomPwd
            // 
            this.cbxRandomPwd.AutoSize = true;
            this.cbxRandomPwd.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cbxRandomPwd.Location = new System.Drawing.Point(204, 87);
            this.cbxRandomPwd.Name = "cbxRandomPwd";
            this.cbxRandomPwd.Size = new System.Drawing.Size(227, 20);
            this.cbxRandomPwd.TabIndex = 6;
            this.cbxRandomPwd.Text = "Générer un mot de passe aléatoire";
            this.cbxRandomPwd.UseVisualStyleBackColor = true;
            this.cbxRandomPwd.CheckedChanged += new System.EventHandler(this.cbxRandomPwd_CheckedChanged);
            // 
            // pbxShowPwdConf
            // 
            this.pbxShowPwdConf.Image = global::NotePass.Properties.Resources.invisible;
            this.pbxShowPwdConf.Location = new System.Drawing.Point(416, 60);
            this.pbxShowPwdConf.Name = "pbxShowPwdConf";
            this.pbxShowPwdConf.Size = new System.Drawing.Size(20, 20);
            this.pbxShowPwdConf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxShowPwdConf.TabIndex = 5;
            this.pbxShowPwdConf.TabStop = false;
            this.pbxShowPwdConf.Click += new System.EventHandler(this.IsPasswordVisible);
            // 
            // pbxShowPwd
            // 
            this.pbxShowPwd.Image = global::NotePass.Properties.Resources.invisible;
            this.pbxShowPwd.Location = new System.Drawing.Point(416, 28);
            this.pbxShowPwd.Name = "pbxShowPwd";
            this.pbxShowPwd.Size = new System.Drawing.Size(20, 20);
            this.pbxShowPwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxShowPwd.TabIndex = 4;
            this.pbxShowPwd.TabStop = false;
            this.pbxShowPwd.Click += new System.EventHandler(this.IsPasswordVisible);
            // 
            // tbxPasswordConf
            // 
            this.tbxPasswordConf.Location = new System.Drawing.Point(204, 60);
            this.tbxPasswordConf.Name = "tbxPasswordConf";
            this.tbxPasswordConf.Size = new System.Drawing.Size(206, 20);
            this.tbxPasswordConf.TabIndex = 3;
            this.tbxPasswordConf.Tag = "Password";
            this.tbxPasswordConf.TextChanged += new System.EventHandler(this.VerifyIfNotEmpty);
            // 
            // lblPasswordConf
            // 
            this.lblPasswordConf.AutoSize = true;
            this.lblPasswordConf.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordConf.Location = new System.Drawing.Point(9, 61);
            this.lblPasswordConf.Name = "lblPasswordConf";
            this.lblPasswordConf.Size = new System.Drawing.Size(189, 16);
            this.lblPasswordConf.TabIndex = 2;
            this.lblPasswordConf.Text = "Confirmation du mot de passe :";
            // 
            // tbxPassowrd
            // 
            this.tbxPassowrd.Location = new System.Drawing.Point(204, 27);
            this.tbxPassowrd.Name = "tbxPassowrd";
            this.tbxPassowrd.Size = new System.Drawing.Size(206, 20);
            this.tbxPassowrd.TabIndex = 1;
            this.tbxPassowrd.Tag = "Password";
            this.tbxPassowrd.TextChanged += new System.EventHandler(this.VerifyIfNotEmpty);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(103, 28);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(95, 16);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Mot de passe :";
            // 
            // gbxQuestions
            // 
            this.gbxQuestions.Controls.Add(this.cbxQuestion3);
            this.gbxQuestions.Controls.Add(this.tbxQuestion3Answer);
            this.gbxQuestions.Controls.Add(this.lblQuestion3Answer);
            this.gbxQuestions.Controls.Add(this.lblQuestion3);
            this.gbxQuestions.Controls.Add(this.cbxQuestion2);
            this.gbxQuestions.Controls.Add(this.tbxQuestion2Answer);
            this.gbxQuestions.Controls.Add(this.lblQuestion2Answer);
            this.gbxQuestions.Controls.Add(this.lblQuestion2);
            this.gbxQuestions.Controls.Add(this.cbxQuestion1);
            this.gbxQuestions.Controls.Add(this.tbxQuestion1Answer);
            this.gbxQuestions.Controls.Add(this.lblQuestion1Answer);
            this.gbxQuestions.Controls.Add(this.lblQuestion1);
            this.gbxQuestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxQuestions.Location = new System.Drawing.Point(12, 212);
            this.gbxQuestions.Name = "gbxQuestions";
            this.gbxQuestions.Size = new System.Drawing.Size(450, 198);
            this.gbxQuestions.TabIndex = 6;
            this.gbxQuestions.TabStop = false;
            // 
            // cbxQuestion3
            // 
            this.cbxQuestion3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuestion3.FormattingEnabled = true;
            this.cbxQuestion3.Location = new System.Drawing.Point(106, 132);
            this.cbxQuestion3.Name = "cbxQuestion3";
            this.cbxQuestion3.Size = new System.Drawing.Size(330, 22);
            this.cbxQuestion3.TabIndex = 16;
            this.cbxQuestion3.SelectedIndexChanged += new System.EventHandler(this.AllCbxQuestion_SelectedIndexChanged);
            // 
            // tbxQuestion3Answer
            // 
            this.tbxQuestion3Answer.Location = new System.Drawing.Point(106, 160);
            this.tbxQuestion3Answer.Name = "tbxQuestion3Answer";
            this.tbxQuestion3Answer.Size = new System.Drawing.Size(330, 20);
            this.tbxQuestion3Answer.TabIndex = 13;
            this.tbxQuestion3Answer.TextChanged += new System.EventHandler(this.VerifyIfNotEmpty);
            // 
            // lblQuestion3Answer
            // 
            this.lblQuestion3Answer.AutoSize = true;
            this.lblQuestion3Answer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion3Answer.Location = new System.Drawing.Point(9, 161);
            this.lblQuestion3Answer.Name = "lblQuestion3Answer";
            this.lblQuestion3Answer.Size = new System.Drawing.Size(67, 16);
            this.lblQuestion3Answer.TabIndex = 15;
            this.lblQuestion3Answer.Text = "Réponse :";
            // 
            // lblQuestion3
            // 
            this.lblQuestion3.AutoSize = true;
            this.lblQuestion3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion3.Location = new System.Drawing.Point(6, 133);
            this.lblQuestion3.Name = "lblQuestion3";
            this.lblQuestion3.Size = new System.Drawing.Size(95, 16);
            this.lblQuestion3.TabIndex = 14;
            this.lblQuestion3.Text = "Question n° 3 :";
            // 
            // cbxQuestion2
            // 
            this.cbxQuestion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuestion2.FormattingEnabled = true;
            this.cbxQuestion2.Location = new System.Drawing.Point(107, 78);
            this.cbxQuestion2.Name = "cbxQuestion2";
            this.cbxQuestion2.Size = new System.Drawing.Size(329, 22);
            this.cbxQuestion2.TabIndex = 12;
            this.cbxQuestion2.SelectedIndexChanged += new System.EventHandler(this.AllCbxQuestion_SelectedIndexChanged);
            // 
            // tbxQuestion2Answer
            // 
            this.tbxQuestion2Answer.Location = new System.Drawing.Point(107, 106);
            this.tbxQuestion2Answer.Name = "tbxQuestion2Answer";
            this.tbxQuestion2Answer.Size = new System.Drawing.Size(329, 20);
            this.tbxQuestion2Answer.TabIndex = 9;
            this.tbxQuestion2Answer.TextChanged += new System.EventHandler(this.VerifyIfNotEmpty);
            // 
            // lblQuestion2Answer
            // 
            this.lblQuestion2Answer.AutoSize = true;
            this.lblQuestion2Answer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion2Answer.Location = new System.Drawing.Point(9, 107);
            this.lblQuestion2Answer.Name = "lblQuestion2Answer";
            this.lblQuestion2Answer.Size = new System.Drawing.Size(67, 16);
            this.lblQuestion2Answer.TabIndex = 11;
            this.lblQuestion2Answer.Text = "Réponse :";
            // 
            // lblQuestion2
            // 
            this.lblQuestion2.AutoSize = true;
            this.lblQuestion2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion2.Location = new System.Drawing.Point(6, 79);
            this.lblQuestion2.Name = "lblQuestion2";
            this.lblQuestion2.Size = new System.Drawing.Size(95, 16);
            this.lblQuestion2.TabIndex = 10;
            this.lblQuestion2.Text = "Question n° 2 :";
            // 
            // cbxQuestion1
            // 
            this.cbxQuestion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuestion1.Location = new System.Drawing.Point(107, 24);
            this.cbxQuestion1.Name = "cbxQuestion1";
            this.cbxQuestion1.Size = new System.Drawing.Size(329, 22);
            this.cbxQuestion1.TabIndex = 8;
            this.cbxQuestion1.SelectedIndexChanged += new System.EventHandler(this.AllCbxQuestion_SelectedIndexChanged);
            // 
            // tbxQuestion1Answer
            // 
            this.tbxQuestion1Answer.Location = new System.Drawing.Point(107, 52);
            this.tbxQuestion1Answer.Name = "tbxQuestion1Answer";
            this.tbxQuestion1Answer.Size = new System.Drawing.Size(329, 20);
            this.tbxQuestion1Answer.TabIndex = 6;
            this.tbxQuestion1Answer.TextChanged += new System.EventHandler(this.VerifyIfNotEmpty);
            // 
            // lblQuestion1Answer
            // 
            this.lblQuestion1Answer.AutoSize = true;
            this.lblQuestion1Answer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion1Answer.Location = new System.Drawing.Point(9, 53);
            this.lblQuestion1Answer.Name = "lblQuestion1Answer";
            this.lblQuestion1Answer.Size = new System.Drawing.Size(67, 16);
            this.lblQuestion1Answer.TabIndex = 7;
            this.lblQuestion1Answer.Text = "Réponse :";
            // 
            // lblQuestion1
            // 
            this.lblQuestion1.AutoSize = true;
            this.lblQuestion1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion1.Location = new System.Drawing.Point(6, 25);
            this.lblQuestion1.Name = "lblQuestion1";
            this.lblQuestion1.Size = new System.Drawing.Size(95, 16);
            this.lblQuestion1.TabIndex = 6;
            this.lblQuestion1.Text = "Question n° 1 :";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 416);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(349, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 24);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Sauvegarder";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(83, 56);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(338, 16);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Définissez votre mot de passe et vos questions secrêtes ";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(48, 443);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(414, 30);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "Message d\'erreur";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.Visible = false;
            // 
            // pbxMessage
            // 
            this.pbxMessage.Image = global::NotePass.Properties.Resources.danger;
            this.pbxMessage.Location = new System.Drawing.Point(12, 443);
            this.pbxMessage.Name = "pbxMessage";
            this.pbxMessage.Size = new System.Drawing.Size(30, 30);
            this.pbxMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxMessage.TabIndex = 7;
            this.pbxMessage.TabStop = false;
            this.pbxMessage.Visible = false;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::NotePass.Properties.Resources.crayon;
            this.pbxLogo.Location = new System.Drawing.Point(12, 12);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(60, 60);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 0;
            this.pbxLogo.TabStop = false;
            // 
            // FrmRegistry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 483);
            this.Controls.Add(this.pbxMessage);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbxQuestions);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.gbxPassword);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbxLogo);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmRegistry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulaire de création ";
            this.Load += new System.EventHandler(this.FrmRegistry_Load);
            this.gbxPassword.ResumeLayout(false);
            this.gbxPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowPwdConf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowPwd)).EndInit();
            this.gbxQuestions.ResumeLayout(false);
            this.gbxQuestions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbxPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.PictureBox pbxShowPwdConf;
        private System.Windows.Forms.PictureBox pbxShowPwd;
        private System.Windows.Forms.TextBox tbxPasswordConf;
        private System.Windows.Forms.Label lblPasswordConf;
        private System.Windows.Forms.TextBox tbxPassowrd;
        private System.Windows.Forms.GroupBox gbxQuestions;
        private System.Windows.Forms.ComboBox cbxQuestion3;
        private System.Windows.Forms.TextBox tbxQuestion3Answer;
        private System.Windows.Forms.Label lblQuestion3Answer;
        private System.Windows.Forms.Label lblQuestion3;
        private System.Windows.Forms.ComboBox cbxQuestion2;
        private System.Windows.Forms.TextBox tbxQuestion2Answer;
        private System.Windows.Forms.Label lblQuestion2Answer;
        private System.Windows.Forms.Label lblQuestion2;
        private System.Windows.Forms.ComboBox cbxQuestion1;
        private System.Windows.Forms.TextBox tbxQuestion1Answer;
        private System.Windows.Forms.Label lblQuestion1Answer;
        private System.Windows.Forms.Label lblQuestion1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox pbxMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.CheckBox cbxRandomPwd;
    }
}