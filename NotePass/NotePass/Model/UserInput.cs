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

        public UserInput(ComboBox cbxQuestions1, ComboBox cbxQuestions2, ComboBox cbxQuestions3)
        {
            lstQuestions = new List<string>();
            lstQuestions = File.ReadLines(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\doc\Questions.txt").ToList();

            lstComboBox = new List<ComboBox>();
            lstComboBox.Add(cbxQuestions1);
            lstComboBox.Add(cbxQuestions2);
            lstComboBox.Add(cbxQuestions3);

            lstSelectedQuestions = new List<string>();
            GenerateTheChoiceOfQuestions();
        }

        private void GenerateTheChoiceOfQuestions()
        {
            foreach (ComboBox comboBox in lstComboBox)
            {
                for (int noQuestion = 0; noQuestion < lstQuestions.Count; noQuestion++)
                {
                    comboBox.Items.Add(lstQuestions[noQuestion]);
                }
            }
        }

        public bool IsAlreadySelected(string question)
        {
            bool selected = false;
            if(lstSelectedQuestions.Count != 0)
            {
                foreach(string selectedQuestion in lstSelectedQuestions)
                {
                    if(question != selectedQuestion)
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
    }
}
