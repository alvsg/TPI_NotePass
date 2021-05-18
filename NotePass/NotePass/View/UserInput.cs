using System;
using System.Collections.Generic;
using System.IO; //Directive ajouté manuellement
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; //Directive ajouté manuellement
using System.Threading.Tasks;
using System.Windows.Forms; //Directive ajouté manuellement

namespace NotePass.View
{
    class UserInput
    {
        private List<string> lstQuestions;
        private List<ComboBox> lstComboBox;
        private List<int> lstSelectedQuestions;
        private const int MAX_ATTEMPTS = 2;
        private int noAttemptsLeft = 2;
        private Model.XmlFile xmlFile;

        public UserInput(ComboBox cbxQuestions1, ComboBox cbxQuestions2, ComboBox cbxQuestions3) : this()
        {
            lstComboBox = new List<ComboBox>();
            lstComboBox.Add(cbxQuestions1);
            lstComboBox.Add(cbxQuestions2);
            lstComboBox.Add(cbxQuestions3);

            lstSelectedQuestions = new List<int>();
            GenerateTheChoiceOfQuestionsForLstComboBox();
        }

        public UserInput(ComboBox cbxQuestions4) : this()
        {
            xmlFile = new Model.XmlFile();
            lstSelectedQuestions = xmlFile.GetIndexQuestions(null);
            cbxQuestions4.Tag = lstSelectedQuestions;
            GenerateQuestionFromIndex(cbxQuestions4);
        }

        public UserInput()
        {
            lstQuestions = new List<string>();
            lstQuestions = File.ReadLines(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\doc\Questions.txt").ToList();
        }

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

        private void GenerateQuestionFromIndex(ComboBox comboBox)
        {
            foreach (int index in lstSelectedQuestions)
            {
                comboBox.Items.Add(lstQuestions[index]);
            }
        }

        public bool IsAlreadySelected(int question)
        {
            bool selected = false;
            if (lstSelectedQuestions.Count != 0)
            {
                foreach (int selectedQuestion in lstSelectedQuestions)
                {
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

        public void IsNotAttemptingAnymore(int attempt, Label lblMessage, TextBox tbxPassword, bool isAuthentification, Form form)
        {
            if (!IsStillAttempting(attempt, lblMessage, form))
            {
                tbxPassword.Enabled = false;
                tbxPassword.Text = string.Empty;
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

        private bool IsStillAttempting(int attempt, Label lblMessage, Form form)
        {
            if (attempt > MAX_ATTEMPTS)
            {
                return false;
            }

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

        public bool IsThePasswordOk(string password)
        {
            if (password.Length > 9)
            {
                string isThereCapitalLetters = string.Concat(Regex.Matches(password, "[A-Z]").OfType<Match>().Select(match => match.Value));
                string isThereNumbers = string.Concat(Regex.Matches(password, "[0-9]").OfType<Match>().Select(match => match.Value));
                string isThereSpecialChars = string.Concat(Regex.Matches(password, "[^A-Za-z0-9]").OfType<Match>().Select(match => match.Value));
                if (isThereCapitalLetters.Length > 0 && isThereNumbers.Length > 0 && isThereSpecialChars.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

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

        private List<Model.Entry> SortInAplhabeticalOrder(List<Model.Entry> lstEntry)
        {
            List<Model.Entry> theList = lstEntry.OrderBy(x => x.Name).ToList();
            return theList;
        }

        private List<Model.Entry> SortInOrderOfDateAdded(List<Model.Entry> lstEntry, string order)
        {
            List<Model.Entry> theList = new List<Model.Entry>();
            lstEntry = lstEntry.OrderBy(x => x.Date).ToList();
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

        public void IsTheApplicationBlocked(int attempt, int authentificationAttempt, Label lblMessage, TextBox tnxReply, Form form)
        {
            if (!IsStillAttempting(attempt, lblMessage, form) && attempt > MAX_ATTEMPTS)
            {
                if (authentificationAttempt > MAX_ATTEMPTS)
                {
                    lblMessage.Text = "Vous n'avez plus de tentatives !";
                }
                else
                {
                    lblMessage.Text = "Vous n'avez plus de tentatives ! Veuillez choisir un autre moyen de connexion.";
                }
                tnxReply.Text = string.Empty;
                tnxReply.Enabled = false;
            }
        }
    }
}
