using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePass.View
{
    public partial class FrmForgottenPwd : Form
    {
        private Model.UserInput userInput;
        private int authentificationAttempts;
        private int attempt;

        public FrmForgottenPwd(int attempts)
        {
            InitializeComponent();
            userInput = new Model.UserInput(cbxQuestion);
            authentificationAttempts = attempts;
            attempt = 0;
        }

        private void cbxQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxQuestion.SelectedIndex > -1)
            {
                tbxReply.Enabled = true;
            }
        }

        private void tbxReply_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxReply.Text))
            {
                btnAdd.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*
             * ------------ VERIFIER LA REPONSE ET BLOQUER L'APPLICATION EN CAS DE 6 TENTATIVES TOTALES ------------
             * 
             * [EXEMPLE DE CODE] -----------------------------------------------------------------------------------
             * 
             * if (secure.Error == null)
             * {
             * CloseThis(tbxPassword.Text);
             * }
             * else
             * {
             * attempt++;
             * userInput.IsNotAttemptingAnymore(attempt, lblMessage, tbxPassword, true);
             * pbxMessage.Visible = true;
             * lblMessage.Visible = true;
             * }
             */
        }
    }
}
