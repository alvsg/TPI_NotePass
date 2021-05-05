/*
 * PROJET : NotePass - Gestionnaire de mot de passe
 * AUTEUR : ALVES GUASTTI Letitia (I.FA-P3A)
 * DESC.: 
 * VERSION : 04.05.2021 v.1
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; //Directive ajouté manuellement
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePass.View
{
    public partial class FrmRegistry : Form
    {
        private List<string> _lstQuestions;
        private List<ComboBox> _lstComboBox;
        public List<string> LstQuestions { get => _lstQuestions; }
        public List<ComboBox> LstComboBox { get => _lstComboBox; }

        Model.XmlFile xmlFile;
        Model.Security secure;

        public FrmRegistry()
        {
            InitializeComponent();

            xmlFile = new Model.XmlFile();
            secure = new Model.Security();

            _lstQuestions = new List<string>();
            _lstQuestions = File.ReadLines(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\doc\Questions.txt").ToList();

            _lstComboBox = new List<ComboBox>();
            _lstComboBox.Add(cbxQuestion1);
            _lstComboBox.Add(cbxQuestion2);
            _lstComboBox.Add(cbxQuestion3);
        }

        private void FrmRegistry_Load(object sender, EventArgs e)
        {
            foreach (ComboBox comboBox in _lstComboBox)
            {
                for(int noQuestion = 0; noQuestion < _lstQuestions.Count; noQuestion++)
                {
                    comboBox.Items.Add(_lstQuestions[noQuestion]);
                }
            }
        }
    }
}
