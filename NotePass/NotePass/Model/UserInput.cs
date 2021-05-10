using System;
using System.Collections.Generic;
using System.IO; //Directive ajouté manuellement
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //Directive ajouté manuellement

namespace NotePass.Model
{
    class UserInput
    {
        private List<string> lstQuestions;
        private List<ComboBox> lstComboBox;
        private List<string> lstSelectedQuestions;
        private const int MAX_ATTEMPTS = 2;
        private int noAttemptsLeft = 2;

        public UserInput(ComboBox cbxQuestions1, ComboBox cbxQuestions2, ComboBox cbxQuestions3) : this()
        {
            lstComboBox = new List<ComboBox>();
            lstComboBox.Add(cbxQuestions1);
            lstComboBox.Add(cbxQuestions2);
            lstComboBox.Add(cbxQuestions3);

            lstSelectedQuestions = new List<string>();
            GenerateTheChoiceOfQuestionsForLstComboBox();
        }

        public UserInput(ComboBox cbxQuestions4) : this()
        {
            GenerateTheChoiceOfQuestionsForOneComboBox(cbxQuestions4);
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

        private void GenerateTheChoiceOfQuestionsForOneComboBox(ComboBox comboBox)
        {
            for (int noQuestion = 0; noQuestion < lstQuestions.Count; noQuestion++)
            {
                comboBox.Items.Add(lstQuestions[noQuestion]);
            }
        }

        public bool IsAlreadySelected(string question)
        {
            bool selected = false;
            if (lstSelectedQuestions.Count != 0)
            {
                foreach (string selectedQuestion in lstSelectedQuestions)
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

        public void IsNotAttemptingAnymore(int attempt, Label lblMessage, TextBox tbxPassword, bool isAuthentification)
        {
            if (!IsStillAttempting(attempt, lblMessage))
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

        private bool IsStillAttempting(int attempt, Label lblMessage)
        {
            if (attempt > MAX_ATTEMPTS)
            {
                return false;
            }
            lblMessage.Text = "Le mot de passe est incorrect ! Il vous reste " + (noAttemptsLeft--).ToString() + " tentatives.";
            return true;
        }
    }
}
