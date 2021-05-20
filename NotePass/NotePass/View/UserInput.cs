/*
 * PROJET : NotePass - Gestionnaire de mot de passe
 * AUTEUR : ALVES GUASTTI Letitia (I.FA-P3A)
 * DESC.: Permet de gérer toute la partie sécurité de l'application
 * VERSION : 04.05.2021 v.1
 */

using System;
using System.Collections.Generic;
using System.IO; //Directive ajouté manuellement
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; //Directive ajouté manuellement
using System.Threading.Tasks;
using System.Windows.Forms; //Directive ajouté manuellement
using System.Xml.Linq;

namespace NotePass.View
{
    class UserInput
    {
        #region Declaration des variables

        /// <summary>
        /// Liste des questions
        /// </summary>
        private List<string> lstQuestions;
        private Model.Security secure;
        /// <summary>
        /// Liste des ComboBox
        /// </summary>
        private List<ComboBox> lstComboBox;
        /// <summary>
        /// Liste des questions déjà sélectionnée
        /// </summary>
        private List<int> lstSelectedQuestions;
        /// <summary>
        /// Nombre des tentatives maximum
        /// </summary>
        private const int MAX_ATTEMPTS = 2;
        /// <summary>
        /// Nombre de tentatives restantes
        /// </summary>
        private int noAttemptsLeft = 2;
        private Model.XmlFile xmlFile;

        #endregion

        /// <summary>
        /// Constructeur qui récupère les ComboBox pour les remplir avec les 10 questions secrètes
        /// </summary>
        /// <param name="cbxQuestions1">Première ComboBox</param>
        /// <param name="cbxQuestions2">Seconde ComboBox</param>
        /// <param name="cbxQuestions3">Troisième ComboBox</param>
        public UserInput(ComboBox cbxQuestions1, ComboBox cbxQuestions2, ComboBox cbxQuestions3) : this()
        {
            lstComboBox = new List<ComboBox>();
            lstComboBox.Add(cbxQuestions1);
            lstComboBox.Add(cbxQuestions2);
            lstComboBox.Add(cbxQuestions3);

            lstSelectedQuestions = new List<int>();
            GenerateTheChoiceOfQuestionsForLstComboBox();
        }

        /// <summary>
        /// Constructeur qui récupère un ComboBox pour afficher les questions déjà sélectionnées
        /// </summary>
        /// <param name="cbxQuestions4"></param>
        public UserInput(ComboBox cbxQuestions4) : this()
        {
            xmlFile = new Model.XmlFile();
            lstSelectedQuestions = GetIndexQuestions(null);
            cbxQuestions4.Tag = lstSelectedQuestions;
            GenerateQuestionFromIndex(cbxQuestions4);
        }

        /// <summary>
        /// Constructeur qui permet de récupérer les 10 questions secrètes et de les mettre dans une liste
        /// </summary>
        public UserInput()
        {
            secure = new Model.Security();
            lstQuestions = new List<string>();
            lstQuestions = File.ReadLines(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\doc\Questions.txt").ToList();
        }

        /// <summary>
        /// Méthode qui permet de remplir les ComboBox avec les 10 questions
        /// </summary>
        private void GenerateTheChoiceOfQuestionsForLstComboBox()
        {
            foreach (ComboBox comboBox in lstComboBox)
            {
                for (int noQuestion = 0; noQuestion < lstQuestions.Count; noQuestion++)
                {
                    comboBox.Items.Add(lstQuestions[noQuestion]);
                }
            }
        }

        /// <summary>
        /// Méthode qui permet de retrouver les questions sélectionnées selon l'identifiant et de les ajouter dans le ComboBox
        /// </summary>
        /// <param name="comboBox">ComboBox des questions déjà choisit</param>
        private void GenerateQuestionFromIndex(ComboBox comboBox)
        {
            foreach (int index in lstSelectedQuestions)
            {
                comboBox.Items.Add(lstQuestions[index]);
            }
        }

        /// <summary>
        /// Méthode qui permet de vérifier si la question sélectionnée est déjà dans la liste des questions sélectionnée
        /// </summary>
        /// <param name="question">L'identifiant de la question sélectionnée</param>
        /// <returns>Le booléen qui indique si la question a déjà été sélectionnée</returns>
        public bool IsAlreadySelected(int question)
        {
            bool selected = false;
            // Boucle qui vérifie qu'une question a été sélectionnée
            if (lstSelectedQuestions.Count != 0)
            {
                foreach (int selectedQuestion in lstSelectedQuestions)
                {
                    // Boucle qui vérifie que la question n'est pas dans la liste des questions sélectionnée 
                    if (question != selectedQuestion)
                    {
                        int index = lstSelectedQuestions.IndexOf(selectedQuestion);
                        lstSelectedQuestions[index] = question;
                        selected = false;
                        break;
                    }
                    else
                    {
                        selected = true;
                    }
                }
            }
            else
            {
                lstSelectedQuestions.Add(question);
            }
            return selected;
        }

        /// <summary>
        /// Méthode qui permet d'afficher à la vue qu'il n'y a plus de tentative
        /// </summary>
        /// <param name="attempt">Le nombre de tentative</param>
        /// <param name="lblMessage">Le message d'erreur</param>
        /// <param name="tbxPassword">Le champ du mot de passe</param>
        /// <param name="isAuthentification">Le booléen qui indique si l'utilisateur est authentifié</param>
        /// <param name="form">La vue depuis lequel la méthode est appelée</param>
        public void IsNotAttemptingAnymore(int attempt, Label lblMessage, TextBox tbxPassword, bool isAuthentification, Form form)
        {
            // Boucle qui vérifie si il reste des tentatives
            if (!IsStillAttempting(attempt, lblMessage, form))
            {
                tbxPassword.Enabled = false;
                tbxPassword.Text = string.Empty;
                // Boucle qui vérifie si authentifié
                if (isAuthentification)
                {
                    lblMessage.Text = "Vous n'avez plus de tentatives, veuillez séléctionner un autre moyen de connexion !";
                }
                else
                {
                    lblMessage.Text = "Vous n'avez plus de tentatives !";
                }
            }
        }

        /// <summary>
        /// Méthode qui permet de renvoyer si il reste des tentatives
        /// </summary>
        /// <param name="attempt">Le nombre de tentative</param>
        /// <param name="lblMessage">Le message d'erreur</param>
        /// <param name="form">La vue depuis lequel la méthode est appelée</param>
        /// <returns>Un booléen qui indique si il y a encre des tentatives</returns>
        private bool IsStillAttempting(int attempt, Label lblMessage, Form form)
        {
            // Boucle qui vérifie si le nombre de tentatives est supérieur au maximum
            if (attempt > MAX_ATTEMPTS)
            {
                return false;
            }

            // Boucle qui vérifie le nom de la vue
            if (form.Name == "FrmAuthentification")
            {
                lblMessage.Text = "Le mot de passe est incorrect ! Il vous reste " + (noAttemptsLeft--).ToString() + " tentatives.";
            }
            else
            {
                lblMessage.Text = "La réponse est incorrect ! Il vous reste " + (noAttemptsLeft--).ToString() + " tentatives.";
            }
            return true;
        }

        /// <summary>
        /// Méthode qui va afficher ou masqueer le mot de passe
        /// </summary>
        /// <param name="clicked">Définit l'état de l'icon</param>
        /// <param name="textBox">Le champ du mot de passe</param>
        /// <param name="pictureBox">L'icon qui illustre l'état d'affichage du mot de passe</param>
        public void MakeVisibleOrNot(bool clicked, TextBox textBox, PictureBox pictureBox)
        {
            // Boucle qui vérifie si l'icon a déjà été cliqué
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

        /// <summary>
        /// Méthode qui permet de vérifier si le mot de passe est correct
        /// </summary>
        /// <param name="password">Le mot de passe entrée par l'utilisateur</param>
        /// <returns>Un booléen qui indique si le mot de passe est correct</returns>
        public bool IsThePasswordOk(string password)
        {
            // Boucle qui vérifie la longueur du mot de passe
            if (password.Length > 9)
            {
                string isThereCapitalLetters = string.Concat(Regex.Matches(password, "[A-Z]").OfType<Match>().Select(match => match.Value));
                string isThereNumbers = string.Concat(Regex.Matches(password, "[0-9]").OfType<Match>().Select(match => match.Value));
                string isThereSpecialChars = string.Concat(Regex.Matches(password, "[^A-Za-z0-9]").OfType<Match>().Select(match => match.Value));
                // Boucle qui vérifie que le mot de passe contient au moins une majuscule, un chiffre et un caractère spécial
                if (isThereCapitalLetters.Length > 0 && isThereNumbers.Length > 0 && isThereSpecialChars.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Méthode qui permet de définir la méthode de tri des entrées
        /// </summary>
        /// <param name="lstEntry">La liste des entrées</param>
        /// <param name="criterion">Le critères de tri</param>
        /// <returns>La liste des entrées triée</returns>
        public List<Model.Entry> SortTheList(List<Model.Entry> lstEntry, string criterion)
        {
            List<Model.Entry> theList = new List<Model.Entry>();
            switch (criterion)
            {
                case "tsmiAlphabeticalOrder":
                    theList = SortInAplhabeticalOrder(lstEntry);
                    break;
                case "tsmiDateAsc":
                    theList = SortInOrderOfDateAdded(lstEntry, "ASC");
                    break;
                case "tsmiDateDesc":
                    theList = SortInOrderOfDateAdded(lstEntry, "DESC");
                    break;
            }
            return theList;
        }

        /// <summary>
        /// Méthode qui permet de trier la liste des entrées dans l'ordre alphabétique
        /// </summary>
        /// <param name="lstEntry">La liste des entrées</param>
        /// <returns>La liste triée dans l'ordre alphabétique</returns>
        private List<Model.Entry> SortInAplhabeticalOrder(List<Model.Entry> lstEntry)
        {
            List<Model.Entry> theList = lstEntry.OrderBy(x => x.Name).ToList();
            return theList;
        }

        /// <summary>
        /// Méthode qui permet de trier la liste des entrées selon la date d'ajout
        /// </summary>
        /// <param name="lstEntry">La liste des entrées</param>
        /// <param name="order">Le sense dans lequel trier</param>
        /// <returns>La liste trée par date d'ajout dans l'ordre voulu</returns>
        private List<Model.Entry> SortInOrderOfDateAdded(List<Model.Entry> lstEntry, string order)
        {
            List<Model.Entry> theList = new List<Model.Entry>();
            lstEntry = lstEntry.OrderBy(x => x.Date).ToList();
            // Boucle qui vérifie l'ordre dans lequel trier
            if (order == "DESC")
            {
                int oldPosition = lstEntry.Count - 1;
                for (int newPosition = 0; newPosition < lstEntry.Count; newPosition++)
                {
                    theList.Add(lstEntry[oldPosition]);
                    oldPosition--;
                }
                return theList;
            }
            return lstEntry;
        }

        /// <summary>
        /// Méthode qui permet d'afficher que l'application est définitivement bloquée suite aux nombreuses tentatives erronée
        /// </summary>
        /// <param name="attempt">Le nombre de tentative</param>
        /// <param name="authentificationAttempt">Le nombre de tentative de l'authentification par mot de passe</param>
        /// <param name="lblMessage">Le message d'erreur</param>
        /// <param name="tbxReply">Le champ texte de la réponse</param>
        /// <param name="form">La vue depuis lequel la méthode est appelée</param>
        public void IsTheApplicationBlocked(int attempt, int authentificationAttempt, Label lblMessage, TextBox tbxReply, Form form)
        {
            // Boucle qui vérifie si il reste des tentatives
            if (!IsStillAttempting(attempt, lblMessage, form) && attempt > MAX_ATTEMPTS)
            {
                // Boucée qui vérifie si le nombre de tentative de l'authentification par mot de passe est au maximum
                if (authentificationAttempt > MAX_ATTEMPTS)
                {
                    lblMessage.Text = "Vous n'avez plus de tentatives !";
                }
                else
                {
                    lblMessage.Text = "Vous n'avez plus de tentatives ! Veuillez choisir un autre moyen de connexion.";
                }
                tbxReply.Text = string.Empty;
                tbxReply.Enabled = false;
            }
        }

        /// <summary>
        /// Méthode qui permet de récupérer les identifiants des questions secrètes
        /// </summary>
        /// <param name="answers">La liste des réponses</param>
        /// <returns></returns>
        private List<int> GetIndexQuestions(List<string> answers)
        {
            XDocument xDocument;
            List<int> question = new List<int>();

            secure.ActionOnFile(false, secure.StringEncryptPwd, "writing", xmlFile.ForgottenpwdFilePath);
            xDocument = XDocument.Load(xmlFile.ForgottenpwdFilePath);
            foreach (XElement element in xDocument.Descendants("questions").Nodes().ToList())
            {
                // Boucle qui vérifie que le nom de la balise
                if (element.Name == "question")
                {
                    question.Add(Convert.ToInt32(element.Attribute("id").Value));
                }
            }
            secure.ActionOnFile(true, secure.StringEncryptPwd, "writing", xmlFile.ForgottenpwdFilePath);

            return question;
        }
    }
}
