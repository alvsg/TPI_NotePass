/*
 * PROJET : NotePass - Gestionnaire de mot de passe
 * AUTEUR : ALVES GUASTTI Letitia (I.FA-P3A)
 * DESC.: Cette classe permet à l'utilisateur de choisir une de ses 3 questions secrètes et d'y répondre afin de s'authentifier
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
using System.Xml.Linq;

namespace NotePass.View
{
    /// <summary>
    /// Vue qui permet de choisir une de ses 3 questions secrètes et d'y répondre afin de s'authentifier
    /// </summary>
    public partial class FrmForgottenPwd : Form
    {
        #region Déclaration des variables

        /// <summary>
        /// Liste des identifiants des questions déjà sélectionnées
        /// </summary>
        private List<int> lstAlreadySelected;
        private UserInput userInput;
        private Model.XmlFile xmlFile;
        /// <summary>
        /// Nombre de tentatives de connexion de FrmAuthentification
        /// </summary>
        private int authentificationAttempts;
        /// <summary>
        /// Le nombre de tentatives
        /// </summary>
        private int attempt;

        #endregion

        /// <summary>
        /// Constructeur qui récupère le nombre de tentatives d'authentification effectué sur la fenêtre d'authentification
        /// </summary>
        /// <param name="attempts">Nombre de tentatives de FrmAuthentification</param>
        public FrmForgottenPwd(int attempts)
        {
            InitializeComponent();
            lstAlreadySelected = new List<int>();
            userInput = new UserInput(cbxQuestion);
            xmlFile = new Model.XmlFile();
            authentificationAttempts = attempts;
            attempt = 0;
        }

        /// <summary>
        /// Méthode qui permet de vérifier lorsque l'utilisateur choisit une question dans la liste déroulante si elle a déjà été sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Boucle qui vérifie qu'une question a été sélectionnée dans la liste déroulante
            if (cbxQuestion.SelectedIndex > -1)
            {
                tbxReply.Enabled = true;
            }

            // Boucle qui vérifie que l'identifiant de la question sélectionnée ne se trouve pas dans la liste des questions déjà sélectionnée
            if (lstAlreadySelected.Contains(cbxQuestion.SelectedIndex))
            {
                // Boucle qui vérifie que le nombre d'éléments dans la liste des questions déjà sélectionnée ne soit pas égale à 3
                if (lstAlreadySelected.Count != 3)
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

        /// <summary>
        /// Méthode qui vérifie que le champ texte de la réponse ne soit pas invalide ou vide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxReply_TextChanged(object sender, EventArgs e)
        {
            // Boucle qui vérifie que le contenu du champ texte soit correcte ou non-vide
            if (!string.IsNullOrWhiteSpace(tbxReply.Text))
            {
                btnAdd.Enabled = true;
            }
        }

        /// <summary>
        /// Méthode qui permet d'ouvrir la fenêtre de création pour que l'utilisateur puisse définir un nouveau mot de passe
        /// </summary>
        /// <param name="password">Le mot de passe de l'application</param>
        private void ChangePassword(string password)
        {
            this.Hide();
            FrmRegistry frmRegistry = new FrmRegistry(true, password);
            frmRegistry.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Méthode qui permet de vérifier si la réponse à la question est correcte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string itIsRight = VerifyIfResponseIfRight(cbxQuestion.SelectedIndex, tbxReply.Text, cbxQuestion);
            // Boucle qui vérifie si le mot de passe a été déchiffré correctement
            if (itIsRight != null)
            {
                ChangePassword(itIsRight);
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

        private string VerifyIfResponseIfRight(int selectedQuestion, string response, ComboBox comboBox)
        {
            string password;
            Model.Security secure = new Model.Security(xmlFile);
            XDocument xDocument;
            secure.ActionOnFile(false, secure.StringEncryptPwd, "writing", xmlFile.ForgottenpwdFilePath);
            List<int> lstSelectedQuestion = (List<int>)comboBox.Tag;
            xDocument = XDocument.Load(xmlFile.ForgottenpwdFilePath);

            foreach (XElement element in xDocument.Descendants("questions").Nodes().ToList())
            {
                if (element.Name == "question")
                {
                    if (Convert.ToInt32(element.Attribute("id").Value) == lstSelectedQuestion[selectedQuestion])
                    {
                        password = secure.ActionOnString(false, element.Value, response);
                        if (password != null)
                        {
                            secure.ActionOnFile(false, password, "writing", xmlFile.DataFilePath);
                            if (secure.Error == null)
                            {
                                return password;
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
