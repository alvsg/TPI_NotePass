/*
 * PROJET : NotePass - Gestionnaire de mot de passe
 * AUTEUR : ALVES GUASTTI Letitia (I.FA-P3A)
 * DESC.: Permet a l'utilisateur de s'authentifié pour accéder à l'application
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

namespace NotePass
{
    public partial class FrmAuthentification : Form
    {
        private Model.XmlFile xmlFile;
        private Model.Security secure;
        private Model.UserInput userInput;
        private int attempt;

        public FrmAuthentification()
        {
            InitializeComponent();
            xmlFile = new Model.XmlFile();
            secure = new Model.Security(xmlFile);
            userInput = new Model.UserInput();
            attempt = 0;
        }

        /// <summary>
        /// Méthode qui permet lors de l'initialisation de la fenêtre d'authentification de vérifier si l'utlisateur ouvre l'application pour la première fois
        ///     Si oui, ouvre la fenêtre de création
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAuthentification_Load(object sender, EventArgs e)
        {
            xmlFile.VerifyIfFirstOpen(this);
        }

        /// <summary>
        /// Méthode qui permet de fermer l'application lorsque l'utilisateur clique sur la croix rouge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Voulez-vous vraiment fermet l'application ?", "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // Boucle qui vérifie que l'utilisateur a cliqué sur Oui
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Méthode qui permet de vérifier si le mot de passe de l'utilisateur l'authentifie et gère les tentatives de l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {
            secure.Error = null;
            // Boucle qui vérifie que le contenu du champs texte soit correct ou non vide
            if (!string.IsNullOrWhiteSpace(tbxPassword.Text))
            {
                secure.ActionOnFile(false, tbxPassword.Text, "data", xmlFile.DataFilePath);
                // Boucle qui vérifie qu'il n'y a pas d'erreur lors du déchiffrage avec le mot de passe entrée par l'utilisateur
                if (secure.Error == null)
                {
                    CloseThis(tbxPassword.Text);
                }
                else
                {
                    attempt++;
                    userInput.IsNotAttemptingAnymore(attempt, lblMessage, tbxPassword, true);
                    pbxMessage.Visible = true;
                    lblMessage.Visible = true;
                }
            }
        }

        /// <summary>
        /// Méthode qui permet de fermer la fenêtre d'authentification et d'afficher le formulaire principal
        /// </summary>
        /// <param name="password">Le mot de passe de l'utilisateur</param>
        private void CloseThis(string password)
        {
            this.Hide();
            View.FrmMain frmMain = new View.FrmMain(password);
            frmMain.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Méthode qui permet de rentre le bouton de connexion actif lorsque le champs n'est plus vide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            // Boucle qui vérifie que le contenu du champs texte soit correct ou non vide
            if (!string.IsNullOrWhiteSpace(tbxPassword.Text))
            {
                btnEnter.Enabled = true;
            }
            else
            {
                btnEnter.Enabled = false;
            }
        }

        /// <summary>
        /// Méthode qui permet de redirigé l'utilisateur sur la fenêtre du mot de passe oublié
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblForgottenPwd_Click(object sender, EventArgs e)
        {
            View.FrmForgottenPwd frmForgottenPwd = new View.FrmForgottenPwd(attempt);
            frmForgottenPwd.ShowDialog();
        }
    }
}
