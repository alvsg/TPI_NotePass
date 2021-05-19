/*
 * PROJET : NotePass - Gestionnaire de mot de passe
 * AUTEUR : ALVES GUASTTI Letitia (I.FA-P3A)
 * DESC.: Cette classe permet à l'utilisateur de définir les 3 questions secrètes et/ou le mot de passe de l'application
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
    /// <summary>
    /// Une vue qui permet de définir les 3 questions secrètes et/ou le mot de passe de l'application
    /// </summary>
    public partial class FrmRegistry : Form
    {
        #region Déclaration de variables

        private Model.XmlFile xmlFile;
        private Model.Security secure;
        private UserInput userInput;
        /// <summary>
        /// Booléen qui permet de définir si le mot de passe est visible
        /// </summary>
        private bool visiblePwd, visiblePwdConf;
        /// <summary>
        /// Booléen qui permet de définir si l'appelle du constructeur a été effectué dans FrmForgottenPwd
        /// </summary>
        private bool forgottenPwd;
        /// <summary>
        /// Chaine de caractère du mot de passe de l'application
        /// </summary>
        private string password;

        #endregion

        /// <summary>
        /// Constructeur qui récupère s'il a été appelé depuis la classe FrmForgottenPwd et le mot de passe de l'application
        /// </summary>
        /// <param name="isCallledFromForgottenPwd">Un booléen qui définit si le constructeur est appelé depuis la classe FrmForgottenPwd</param>
        /// <param name="passwordOf">Le mot de passe de l'utilisateur</param>
        public FrmRegistry(bool isCallledFromForgottenPwd, string passwordOf)
        {
            InitializeComponent();

            // Boucle qui vérifie que le mot de passe récupéré ne soit pas un champ nul
            if (passwordOf != null)
            {
                password = passwordOf;
                xmlFile = new Model.XmlFile(password, false);
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
            forgottenPwd = isCallledFromForgottenPwd;
        }

        /// <summary>
        /// Méthode qui permet de générer les questions pour les listes déroulantes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRegistry_Load(object sender, EventArgs e)
        {
            // Boucle qui vérifie si la classe FrmRegistry est appelée depuis la classe FrmForgottenPwd
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
        /// Méthode qui permet de remplis les champs du mot de passe avec un mot de passe généré aléatoirement lorsque la case à cocher est cochée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRandomPwd_CheckedChanged(object sender, EventArgs e)
        {
            secure.GenerateRandomPwdInTextBox(cbxRandomPwd, gbxPassword);
        }

        /// <summary>
        /// Méthode qui permet de vérifier si une question de la liste déroulante a déjà été sélectionnée par l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllCbxQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            // Boucle qui vérifie si la question est déjà sélectionnée dans une autre liste déroulante
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
        /// Méthode qui détermine si le champ de réponse lié à la question est actif
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
        /// Méthode qui permet de définir le nombre de caractères maximum des champs de textes
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
        /// Méthode qui permet de définir si le mot de passe est visible en clair
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
        /// Méthode qui définit le statut du bouton à chaque fois que le texte dans un champ change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerifyIfNotEmpty(object sender, EventArgs e)
        {
            IsMyBtnSaveEnabled();
        }

        /// <summary>
        /// Méthode qui permet d'enregistrer ce que l'utilisateur a entrée et de rediriger sur la page principale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Boucle qui vérifie que le champ de mot de passe et celui de confirmation sont semblable
            if (tbxPassowrd.Text == tbxPasswordConf.Text)
            {
                // Boucle qui vérifie si la classe FrmRegistry est appelée depuis la classe FrmForgottenPwd
                if (forgottenPwd)
                {
                    xmlFile.UpdatePassword(tbxPasswordConf.Text, xmlFile.LstAnswer);
                    xmlFile.UpdateDataInXml(0, "NotePass", tbxPasswordConf.Text, "", "", false);
                }
                else
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
        /// Méthode qui permet à la fenêtre de création de se fermer et d'afficher la fenêtre principale
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
            // Boucle qui vérifie si la classe FrmRegistry est appelée depuis la classe FrmForgottenPwd
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
                // Boucle qui vérifie que les champs liés au conteneur du mot de passe ne sont pas vide
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
        /// Méthode qui permet de vérifier si les champs textes sont vie et si un élément a été sélectionné dans chaque liste déroulante
        /// </summary>
        /// <param name="groupBox">Le conteneur des contrôleurs</param>
        /// <returns>L'état de tous les contrôleurs</returns>
        private bool IsMyTextBoxOrMyComboBoxEmptyOrImproper(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                // Boucle qui vérifie que le contrôleur est un champ texte et actif
                if (control is TextBox && control.Enabled)
                {
                    TextBox textBox = control as TextBox;
                    // Boucle qui vérifie que le contenu du champ texte soit correcte ou non-vide
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return false;
                    }
                    else
                    {
                        // Boucle 
                        if (textBox.Tag != null)
                        {
                            // Boucle qui vérifie que le champ est un champ de mot de passe
                            if (textBox.Tag.ToString() == "Password")
                            {
                                // Boucle qui vérifie si le mot de passe n'est pas valide
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
                }
                // Boucle qui vérifie que le contrôleur est une liste déroulante
                else if (control is ComboBox)
                {
                    ComboBox comboBox = control as ComboBox;
                    // Boucle qui vérifie si une question n'a pas été sélectionné dans la liste déroulante
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
