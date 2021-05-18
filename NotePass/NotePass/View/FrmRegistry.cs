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
        private UserInput userInput;
        private bool visiblePwd, visiblePwdConf;
        private bool forgottenPwd;
        private string newPassword;

        /// <summary>
        /// Constructeur principal de la classe FrmRegistry
        /// </summary>
        /// <param name="isForgottenPwd">La booléen qui définit si le constructeur est appelé parce que l'tulisateur a oublié son mot de passe ou non</param>
        public FrmRegistry(bool isForgottenPwd, string password)
        {
            InitializeComponent();

            if (password != null)
            {
                newPassword = password;
                xmlFile = new Model.XmlFile(newPassword, false);
            }
            else
            {
                xmlFile = new Model.XmlFile();
            }
            secure = new Model.Security(xmlFile);
            userInput = new UserInput(cbxQuestion1, cbxQuestion2, cbxQuestion3);
            btnSave.Enabled = false;
            visiblePwd = false;
            visiblePwdConf = false;
            tbxPassowrd.PasswordChar = '*';
            tbxPasswordConf.PasswordChar = '*';
            forgottenPwd = isForgottenPwd;        }

        /// <summary>
        /// Méthode qui permet de générer les questions pour les comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRegistry_Load(object sender, EventArgs e)
        {
            // Boucle qui vérifie si la classe FrmRegistry est appelé depuis la classe FrmForgottenPwd ou pas
            if (forgottenPwd)
            {
                gbxQuestions.Enabled = false;
            }
            else
            {
                SetNoCharInTextBox(gbxQuestions);
            }
        }

        /// <summary>
        /// Méthode qui permet de remplis les champs dû mot de passe avec un mot de passe généré aléatoirement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRandomPwd_CheckedChanged(object sender, EventArgs e)
        {
            secure.GenerateRandomPwdInTextBox(cbxRandomPwd, gbxPassword);
        }

        /// <summary>
        /// Méthode qui permet de vérifier si une question a déjà été séléctionné par l'utilisateur
        ///     Si oui, le champ de la réponse lié à la question devient inactif
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllCbxQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            // Boucle qui vérifie si la question est déjà séléctionnée dans une autre liste déroulante
            if (userInput.IsAlreadySelected(comboBox.SelectedIndex))
            {
                IsWritable(false, comboBox);
            }
            else
            {
                IsWritable(true, comboBox);
            }
            IsMyBtnSaveEnabled();
        }

        /// <summary>
        /// Méthode qui détermine si le champ de réponse lié à la question est actif ou non
        /// </summary>
        /// <param name="state">L'état du champ</param>
        /// <param name="comboBox">La liste déroulante</param>
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

        /// <summary>
        /// Méthode qui permet de définir la taille maximum des champs de textes
        /// </summary>
        /// <param name="groupBox">Le conteneur des contrôleurs</param>
        private void SetNoCharInTextBox(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                // Boucle qui vérifie si le contrôleur est un champ texte
                if (control is TextBox)
                {
                    TextBox textBox = control as TextBox;
                    textBox.MaxLength = 60;
                }
            }
        }

        /// <summary>
        /// Méthode qui permet de définir si le mot de passe est visible en clair ou non
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsPasswordVisible(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            switch (pictureBox.Name)
            {
                case "pbxShowPwd":
                    visiblePwd = !visiblePwd;
                    userInput.MakeVisibleOrNot(visiblePwd, tbxPassowrd, pictureBox);
                    break;
                case "pbxShowPwdConf":
                    visiblePwdConf = !visiblePwdConf;
                    userInput.MakeVisibleOrNot(visiblePwdConf, tbxPasswordConf, pictureBox);
                    break;
            }
        }

        /// <summary>
        /// Méthode qui définit le statut du boutons à chaque fois que le texte dans un champs change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerifyIfNotEmpty(object sender, EventArgs e)
        {
            IsMyBtnSaveEnabled();
        }

        /// <summary>
        /// Méthode qui permet d'enregistrer ce que l'utilisateur a entrée et de le rediriger sur la page principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Boucle qui vérifie que les deux champs du mot de passe sont identique
            if (tbxPassowrd.Text == tbxPasswordConf.Text)
            {
                if (forgottenPwd)
                {
                    xmlFile.UpdatePassword(tbxPasswordConf.Text, xmlFile.LstAnswer);
                    xmlFile.UpdateDataInXml(0, "NotePass", tbxPasswordConf.Text, "", "", false);
                }
                else if(!forgottenPwd)
                {
                    xmlFile.CreateDataXmlFile(0, "NotePass", tbxPasswordConf.Text, "", "", false);
                    xmlFile.LstAnswer.Add(tbxQuestion1Answer.Text);
                    xmlFile.LstAnswer.Add(tbxQuestion2Answer.Text);
                    xmlFile.LstAnswer.Add(tbxQuestion3Answer.Text);
                    xmlFile.CreateForgottenPwdXmlFile(cbxQuestion1.SelectedIndex, cbxQuestion2.SelectedIndex, cbxQuestion3.SelectedIndex, tbxPasswordConf.Text);
                }
                CloseThis();
            }
            else
            {
                lblMessage.Text = "Les deux mots de passes ne sont pas identique !";
                pbxMessage.Visible = true;
                lblMessage.Visible = true;
            }
        }

        /// <summary>
        /// Méthode qui permet a la fenêtre de création de se fermet et d'afficher la fenêtre principal
        /// </summary>
        private void CloseThis()
        {
            this.Hide();
            View.FrmMain frmMain = new FrmMain(tbxPasswordConf.Text);
            frmMain.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Méthode qui permet de vérifier l'état du bouton selon l'état des contrôleurs
        /// </summary>
        private void IsMyBtnSaveEnabled()
        {
            // Boucle qui vérifie si la classe FrmRegistry est appelé depuis la classe FrmForgottenPwd ou pas
            if (!forgottenPwd)
            {
                // Boucle qui vérifie que les champs dans chaque conteneur ne sont pas vide
                if (IsMyTextBoxOrMyComboBoxEmptyOrImproper(gbxPassword) && IsMyTextBoxOrMyComboBoxEmptyOrImproper(gbxQuestions))
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
            else
            {
                // Boucle qui vérifie que les champs dans un conteneur ne sont pas vide
                if (IsMyTextBoxOrMyComboBoxEmptyOrImproper(gbxPassword))
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Méthode qui permet de vérifier l'état des contrôleurs
        /// </summary>
        /// <param name="groupBox">Le conteneur des contrôleurs</param>
        /// <returns></returns>
        private bool IsMyTextBoxOrMyComboBoxEmptyOrImproper(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                // Boucle qui vérifie que le contrôleur soit un champs texte et actif
                if (control is TextBox && control.Enabled)
                {
                    TextBox textBox = control as TextBox;
                    // Boucle qui vérifie que le contenu du champs texte soit correct ou non vide
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return false;
                    }
                    else
                    {
                        if (textBox.Name.Contains("tbxPassowrd"))
                        {
                            if (!userInput.IsThePasswordOk(textBox.Text))
                            {
                                lblMessage.Text = "Votre mot de passe n'est pas conforme !";
                                lblMessage.Visible = true;
                                pbxMessage.Visible = true;

                                return false;
                            }
                            else
                            {
                                lblMessage.Visible = false;
                                pbxMessage.Visible = false;
                            }
                        }
                    }
                }
                // Boucle qui vérifie que le contrôleur soit une liste déroulante
                else if (control is ComboBox)
                {
                    ComboBox comboBox = control as ComboBox;
                    // Boucle qui vérifie si une question a été séléctionné dans la liste déroulante
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
