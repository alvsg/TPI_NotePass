/*
 * PROJET : NotePass - Gestionnaire de mot de passe
 * AUTEUR : ALVES GUASTTI Letitia (I.FA-P3A)
 * DESC.: Permet de définir le mot de passe de l'application et les 3 questions secrètes
 * VERSION : 04.05.2021 v.1
 */

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
    public partial class FrmRegistry : Form
    {
        private Model.XmlFile xmlFile;
        private Model.Security secure;
        private Model.UserInput userInput;
        private bool visiblePwd, visiblePwdConf;

        public FrmRegistry()
        {
            InitializeComponent();

            xmlFile = new Model.XmlFile();
            secure = new Model.Security(xmlFile);
            userInput = new Model.UserInput(cbxQuestion1, cbxQuestion2, cbxQuestion3);
            btnSave.Enabled = false;
            visiblePwd = false;
            visiblePwdConf = false;
            tbxPassowrd.PasswordChar = '*';
            tbxPasswordConf.PasswordChar = '*';
        }

        private void FrmRegistry_Load(object sender, EventArgs e)
        {
            SetNoCharInTextBox(gbxQuestions);
        }

        private void cbxRandomPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRandomPwd.Checked)
            {
                string pwd = secure.GenerateRandomPwd();
                foreach(Control control in gbxPassword.Controls)
                {
                    if(control is TextBox)
                    {
                        TextBox textBox = control as TextBox;
                        textBox.Text = pwd;
                    }
                }
            }
        }

        private void AllCbxQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (userInput.IsAlreadySelected(comboBox.SelectedItem.ToString()))
            {
                IsWritable(false, comboBox);
            }
            else
            {
                IsWritable(true, comboBox);
            }
            IsMyBtnSaveEnabled();
        }

        private void IsWritable(bool state, ComboBox comboBox)
        {
            switch (comboBox.Name)
            {
                case "cbxQuestion1":
                    tbxQuestion1Answer.Enabled = state;
                    break;
                case "cbxQuestion2":
                    tbxQuestion2Answer.Enabled = state;
                    break;
                case "cbxQuestion3":
                    tbxQuestion3Answer.Enabled = state;
                    break;
            }
        }

        private void SetNoCharInTextBox(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = control as TextBox;
                    textBox.MaxLength = 55;
                }
            }
        }

        private void IsPasswordVisible(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            switch (pictureBox.Name)
            {
                case "pbxShowPwd":
                    visiblePwd = !visiblePwd;
                    MakeVisibleOrNot(visiblePwd, tbxPassowrd, pictureBox);
                    break;
                case "pbxShowPwdConf":
                    visiblePwdConf = !visiblePwdConf;
                    MakeVisibleOrNot(visiblePwdConf, tbxPasswordConf, pictureBox);
                    break;
            }
        }

        private void MakeVisibleOrNot(bool clicked, TextBox textBox, PictureBox pictureBox)
        {
            if (clicked)
            {
                pictureBox.Image = Properties.Resources.visibe;
                textBox.PasswordChar = '\0';
            }
            else
            {
                pictureBox.Image = Properties.Resources.invisible;
                textBox.PasswordChar = '*';
            }
        }

        private void VerifyIfNotEmpty(object sender, EventArgs e)
        {
            IsMyBtnSaveEnabled();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(tbxPassowrd.Text == tbxPasswordConf.Text)
            {
                xmlFile.CreateXmlFile(tbxPassowrd.Text);
                CloseThis();
            }
            else
            {
                
            }
        }

        private void CloseThis()
        {
            this.Hide();
            View.FrmMain frmMain = new FrmMain(tbxPassowrd.Text);
            frmMain.ShowDialog();
            this.Close();
        }

        private void IsMyBtnSaveEnabled()
        {
            if(IsMyTextBoxOrMyComboBoxEmpty(gbxPassword) && IsMyTextBoxOrMyComboBoxEmpty(gbxQuestions))
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private bool IsMyTextBoxOrMyComboBoxEmpty(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is TextBox && control.Enabled)
                {
                    TextBox textBox = control as TextBox;
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return false;
                    }
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = control as ComboBox;
                    if (comboBox.SelectedIndex < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
