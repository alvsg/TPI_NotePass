using NotePass.Model;
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
    public partial class FrmEntry : Form
    {
        private Entry _enregistrement;
        private bool showData;
        private List<Entry> lstEntry;
        private bool clicked = false, favorites = false;
        private Security secure;
        private UserInput userInput;

        public Entry Enregistrement { get => _enregistrement; }

        public FrmEntry(Entry entry, bool show, List<Entry> list)
        {
            InitializeComponent();

            secure = new Security();
            userInput = new UserInput();
            _enregistrement = entry;
            showData = show;
            lstEntry = list;
        }

        public FrmEntry(bool show)
        {
            InitializeComponent();

            secure = new Security();
            userInput = new UserInput();
            showData = show;
        }

        private void FrmEntry_Load(object sender, EventArgs e)
        {
            if (showData)
            {
                IsTextBoxReadOnly(true);
                pbxShowPwd.Enabled = false;
                btnModifier.Enabled = true;
                btnAction.Text = "Supprimer";
                tbxWebSiteOrSoftwareName.Text = _enregistrement.Name;
                tbxUrl.Text = _enregistrement.Url;
                tbxPassowrd.PasswordChar = '*';
                tbxPassowrd.Text = _enregistrement.Password;
                tbxUsername.Text = _enregistrement.Username;
                lblDateAdded.Text = _enregistrement.Date.ToString();
            }
            else
            {
                btnModifier.Enabled = false;
                btnAction.Text = "Ajouter";
            }
        }

        private void IsTextBoxReadOnly(bool readOnly)
        {
            foreach (Control control in gbxNewEntry.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = control as TextBox;
                    if (textBox.Text == "NotePass" || textBox.Text == Environment.UserName)
                    {
                        textBox.ReadOnly = true;
                    }
                    else
                    {
                        textBox.ReadOnly = readOnly;
                    }
                }
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            btnModifier.Enabled = false;
            pbxShowPwd.Enabled = true;
            IsTextBoxReadOnly(false);
            btnAction.Text = "Sauvegarder";
            btnAction.Enabled = true;
        }

        private void pbxShowPwd_Click(object sender, EventArgs e)
        {
            clicked = !clicked;
            userInput.MakeVisibleOrNot(clicked, tbxPassowrd, pbxShowPwd);
        }

        private void pbxFavorites_Click(object sender, EventArgs e)
        {
            favorites = !favorites;
            if (favorites)
            {
                pbxFavorites.Image = Properties.Resources.ajouter_favoris;
            }
            else
            {
                pbxFavorites.Image = Properties.Resources.retire_favoris;
            }
            _enregistrement.Favorites = favorites.ToString();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            switch (btnAction.Text)
            {
                case "Supprimer":
                    this.DialogResult = DialogResult.Abort;
                    break;
                case "Sauvegarder":
                    SaveChanges(tbxWebSiteOrSoftwareName.Text, tbxUrl.Text, tbxPassowrd.Text, tbxUsername.Text, favorites);
                    this.DialogResult = DialogResult.OK;
                    break;
                case "Ajouter":
                    AddEntry(tbxWebSiteOrSoftwareName.Text, tbxUrl.Text, tbxPassowrd.Text, tbxUsername.Text, favorites);
                    this.DialogResult = DialogResult.Yes;
                    break;
            }
        }

        private void SaveChanges(string tbxWebSiteOrSoftwareName, string tbxUrl, string tbxPassowrd, string tbxUsername, bool pbxFavorites)
        {
            btnModifier.Enabled = true;
            btnAction.Text = "Supprimer";
            if (tbxWebSiteOrSoftwareName != "NotePass" && tbxUsername != Environment.UserName)
            {
                _enregistrement.Name = IsItDifferent(_enregistrement.Name, tbxWebSiteOrSoftwareName);
                _enregistrement.Username = IsItDifferent(_enregistrement.Username, tbxUsername);
            }
            else if (_enregistrement.Url != tbxUrl)
            {
                _enregistrement.Url = tbxUrl;
            }
            _enregistrement.Password = IsItDifferent(_enregistrement.Password, tbxPassowrd);
            _enregistrement.Favorites = IsItDifferent(_enregistrement.Favorites.ToString(), favorites.ToString());
        }

        private string IsItDifferent(string oldEntry, string newEntry)
        {
            if (string.IsNullOrWhiteSpace(newEntry) && newEntry != oldEntry)
            {
                return newEntry;
            }

            return oldEntry;
        }

        private void cbxRandomPwd_CheckedChanged(object sender, EventArgs e)
        {
            secure.GenerateRandomPwdInTextBox(cbxRandomPwd, gbxNewEntry);
        }

        private void VerifyIfNotEmpty(object sender, EventArgs e)
        {
            IsMyBtnEnabled();
        }

        private void IsMyBtnEnabled()
        {
            // Boucle qui vérifie que les champs dans chaque conteneur ne sont pas vide
            if (VerifyTextOfAllTextBox())
            {
                btnAction.Enabled = true;
            }
            else
            {
                btnAction.Enabled = false;
            }
        }

        private bool VerifyTextOfAllTextBox()
        {
            foreach (Control control in gbxNewEntry.Controls)
            {
                // Boucle qui vérifie que le contrôleur soit un champs texte et actif
                if (control is TextBox)
                {
                    TextBox textBox = control as TextBox;
                    // Boucle qui vérifie que le contenu du champs texte soit correct ou non vide
                    if (string.IsNullOrWhiteSpace(textBox.Text) && !textBox.Name.Contains("tbxUrl"))
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
            }
            return true;
        }

        private void AddEntry(string tbxWebSiteOrSoftwareName, string tbxUrl, string tbxPassowrd, string tbxUsername, bool pbxFavorites)
        {
            _enregistrement.Name = tbxWebSiteOrSoftwareName;
            _enregistrement.Url = tbxUrl;
            _enregistrement.Password = tbxPassowrd;
            _enregistrement.Username = tbxUsername;
            _enregistrement.Favorites = pbxFavorites.ToString();
        }

    }
}
