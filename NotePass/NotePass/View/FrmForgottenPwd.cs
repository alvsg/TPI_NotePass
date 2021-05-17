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
        private List<int> lstAlreadySelected;
        private UserInput userInput;
        private Model.Security secure;
        private Model.XmlFile xmlFile;
        private int authentificationAttempts;
        private int attempt;

        public FrmForgottenPwd(int attempts)
        {
            InitializeComponent();
            lstAlreadySelected = new List<int>();
            userInput = new UserInput(cbxQuestion);
            xmlFile = new Model.XmlFile();
            secure = new Model.Security(xmlFile);
            authentificationAttempts = attempts;
            attempt = 0;
        }

        private void cbxQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxQuestion.SelectedIndex > -1)
            {
                tbxReply.Enabled = true;
            }

            if (lstAlreadySelected.Contains(cbxQuestion.SelectedIndex))
            {
                if(lstAlreadySelected.Count != 3)
                {
                    pbxMessage.Visible = true;
                    lblMessage.Text = "Veuillez choisir une autre question !";
                    lblMessage.Visible = true;
                }
                tbxReply.Enabled = false;
            }
            else
            {
                pbxMessage.Visible = false;
                lblMessage.Visible = false;
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

        private void ChangePassword()
        {
            this.Hide();
            FrmRegistry frmRegistry = new FrmRegistry(true);
            frmRegistry.ShowDialog();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool itIsRight = xmlFile.VerifyIfResponseIfRight(cbxQuestion.SelectedIndex, tbxReply.Text, cbxQuestion);
            if (itIsRight)
            {
                ChangePassword();
            }
            else
            {
                attempt++;
                userInput.IsTheApplicationBlocked(attempt, authentificationAttempts, lblMessage, tbxReply, this);
                lstAlreadySelected.Add(cbxQuestion.SelectedIndex);
                cbxQuestion.SelectedIndex = -1;
                tbxReply.Text = null;
                pbxMessage.Visible = true;
                lblMessage.Visible = true;
            }
        }
    }
}
