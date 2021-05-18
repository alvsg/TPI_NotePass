
namespace NotePass.View
{
    partial class FrmForgottenPwd
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblReply = new System.Windows.Forms.Label();
            this.tbxReply = new System.Windows.Forms.TextBox();
            this.gbxForgottenPwd = new System.Windows.Forms.GroupBox();
            this.cbxQuestion = new System.Windows.Forms.ComboBox();
            this.pbxMessage = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.gbxForgottenPwd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(412, 186);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(113, 24);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(13, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(83, 58);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(388, 16);
            this.lblDescription.TabIndex = 16;
            this.lblDescription.Text = "Choisissez une de vous questions secrètes pour vous authentifiez";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(78, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(309, 46);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Mot de passe oublié";
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::NotePass.Properties.Resources.question;
            this.pbxLogo.Location = new System.Drawing.Point(12, 12);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(60, 60);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 13;
            this.pbxLogo.TabStop = false;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(45, 27);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(68, 16);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Question :";
            // 
            // lblReply
            // 
            this.lblReply.AutoSize = true;
            this.lblReply.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReply.Location = new System.Drawing.Point(45, 53);
            this.lblReply.Name = "lblReply";
            this.lblReply.Size = new System.Drawing.Size(67, 16);
            this.lblReply.TabIndex = 6;
            this.lblReply.Text = "Réponse :";
            // 
            // tbxReply
            // 
            this.tbxReply.Enabled = false;
            this.tbxReply.Location = new System.Drawing.Point(119, 52);
            this.tbxReply.Name = "tbxReply";
            this.tbxReply.Size = new System.Drawing.Size(340, 20);
            this.tbxReply.TabIndex = 7;
            this.tbxReply.TextChanged += new System.EventHandler(this.tbxReply_TextChanged);
            // 
            // gbxForgottenPwd
            // 
            this.gbxForgottenPwd.Controls.Add(this.cbxQuestion);
            this.gbxForgottenPwd.Controls.Add(this.tbxReply);
            this.gbxForgottenPwd.Controls.Add(this.lblReply);
            this.gbxForgottenPwd.Controls.Add(this.lblQuestion);
            this.gbxForgottenPwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxForgottenPwd.Location = new System.Drawing.Point(12, 87);
            this.gbxForgottenPwd.Name = "gbxForgottenPwd";
            this.gbxForgottenPwd.Size = new System.Drawing.Size(513, 93);
            this.gbxForgottenPwd.TabIndex = 15;
            this.gbxForgottenPwd.TabStop = false;
            // 
            // cbxQuestion
            // 
            this.cbxQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuestion.FormattingEnabled = true;
            this.cbxQuestion.Location = new System.Drawing.Point(119, 26);
            this.cbxQuestion.Name = "cbxQuestion";
            this.cbxQuestion.Size = new System.Drawing.Size(339, 21);
            this.cbxQuestion.TabIndex = 8;
            this.cbxQuestion.SelectedIndexChanged += new System.EventHandler(this.cbxQuestion_SelectedIndexChanged);
            // 
            // pbxMessage
            // 
            this.pbxMessage.Image = global::NotePass.Properties.Resources.danger1;
            this.pbxMessage.Location = new System.Drawing.Point(13, 216);
            this.pbxMessage.Name = "pbxMessage";
            this.pbxMessage.Size = new System.Drawing.Size(30, 30);
            this.pbxMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxMessage.TabIndex = 20;
            this.pbxMessage.TabStop = false;
            this.pbxMessage.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(49, 216);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(476, 30);
            this.lblMessage.TabIndex = 19;
            this.lblMessage.Text = "Message d\'erreur";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.Visible = false;
            // 
            // FrmForgottenPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 256);
            this.Controls.Add(this.pbxMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.gbxForgottenPwd);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbxLogo);
            this.Name = "FrmForgottenPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmForgottenPwd";
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.gbxForgottenPwd.ResumeLayout(false);
            this.gbxForgottenPwd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblReply;
        private System.Windows.Forms.TextBox tbxReply;
        private System.Windows.Forms.GroupBox gbxForgottenPwd;
        private System.Windows.Forms.ComboBox cbxQuestion;
        private System.Windows.Forms.PictureBox pbxMessage;
        private System.Windows.Forms.Label lblMessage;
    }
}