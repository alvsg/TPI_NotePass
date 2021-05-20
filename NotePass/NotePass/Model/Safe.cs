/*
 * PROJET : NotePass - Gestionnaire de mot de passe
 * AUTEUR : ALVES GUASTTI Letitia (I.FA-P3A)
 * DESC.: Permet de gérer le coffre fort de l'application
 * VERSION : 04.05.2021 v.1
 */

using NotePass.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //Directive ajouté manuellement
using System.Xml.Linq;

namespace NotePass.Model
{
    /// <summary>
    /// Modèle qui permet de gérer le coffre fort de l'application
    /// </summary>
    public class Safe
    {
        #region Déclaration des variables

        private List<Entry> _lstEntry, _lstFavorites;
        private Entry _newEntry;
        private XmlFile xmlFile;
        public FrmMain frmMain;
        /// <summary>
        /// Le conteneur des boutons
        /// </summary>
        private FlowLayoutPanel _flpButton;
        private List<int> _addedInXmlFile, _modifiedInXmlFile, _deletedInXmlFile;
        private int _noData;
        private bool _cancel;
        private XDocument xDocument;

        #endregion

        /// <summary>
        /// Liste des entrées à ajouter dans le fichier xml 
        /// </summary>
        public List<int> AddedInXmlFile { get => _addedInXmlFile; set => _addedInXmlFile = value; }
        /// <summary>
        /// Liste des doonées à modifier dans le fichier xml
        /// </summary>
        public List<int> ModifiedInXmlFile { get => _modifiedInXmlFile; set => _modifiedInXmlFile = value; }
        /// <summary>
        /// Liste des entrées à supprimer dans le fichier xml
        /// </summary>
        public List<int> DeletedInXmlFile { get => _deletedInXmlFile; set => _deletedInXmlFile = value; }
        /// <summary>
        /// Liste des entrées
        /// </summary>
        public List<Entry> LstEntry { get => _lstEntry; set => _lstEntry = value; }
        /// <summary>
        /// Nombre d'entrées
        /// </summary>
        public int NoData { get => _noData; set => _noData = value; }
        /// <summary>
        /// Nouvelle entrée
        /// </summary>
        public Entry NewEntry { get => _newEntry; }
        /// <summary>
        /// Booléen qui indique la fermeture d'une vue
        /// </summary>
        public bool Cancel { get => _cancel; }
        /// <summary>
        /// Liste des entrées en favoris
        /// </summary>
        public List<Entry> LstFavorites { get => _lstFavorites; }
        /// <summary>
        /// Conteneur des entrées (boutons)
        /// </summary>
        public FlowLayoutPanel FlpButton { get => _flpButton; }

        /// <summary>
        /// Constructeur qui permet de récupérer la vue principale et le conteneur des entrées
        /// </summary>
        /// <param name="formMain">La vue principale</param>
        /// <param name="flowLayoutPanel">Le conteneur des boutons</param>
        public Safe(FrmMain formMain, FlowLayoutPanel flowLayoutPanel)
        {
            frmMain = formMain;
            _flpButton = flowLayoutPanel;
            xmlFile = new XmlFile();
            _lstEntry = new List<Entry>();
            _lstEntry = GetDataInArray();
            _noData = _lstEntry.Count;
            _addedInXmlFile = new List<int>();
            _deletedInXmlFile = new List<int>();
            _modifiedInXmlFile = new List<int>();
            _lstFavorites = GetAllFavoritesData();
        }

        /// <summary>
        /// Méthode qui permet dafficher les données de l'entrée lors du clique d'un bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnFlp_Click(object sender, EventArgs e)
        {
            // Boucle qui vérifie que le sender est bien un bouton
            if (sender is Button btnEntry)
            {
                ShowAndLetModifyValuesInData((Entry)btnEntry.Tag);
            }
        }

        /// <summary>
        /// Méthode qui permet d'afficher les données d'une entrée dans une vue
        /// </summary>
        /// <param name="entry">L'entrée liée au bouton</param>
        private void ShowAndLetModifyValuesInData(Entry entry)
        {
            int index = _lstEntry.IndexOf(entry);
            Security secure = new Security();
            FrmEntry frmEntry = new FrmEntry(entry, true, _lstEntry);
            frmEntry.ShowDialog();
            // Boucle qui vérifie le résultat de la boite de dialogue
            if (frmEntry.DialogResult == DialogResult.OK)
            {
                UpdateOnButton(index, frmEntry.Enregistrement.Name);
                _lstEntry[index] = new Entry(frmEntry.Enregistrement.Name, frmEntry.Enregistrement.Url, frmEntry.Enregistrement.Password, frmEntry.Enregistrement.Username, frmEntry.Enregistrement.Date, frmEntry.Enregistrement.Favorites);
                _modifiedInXmlFile.Add(index);
            }
            else if (frmEntry.DialogResult == DialogResult.Abort)
            {
                foreach (Button btnEntry in _flpButton.Controls)
                {
                    // Boucle qui vérifie que le bouton liée à l'entrée soit dans le conteneur
                    if (index == _flpButton.Controls.IndexOf(btnEntry))
                    {
                        _flpButton.Controls.RemoveAt(index);
                        _deletedInXmlFile.Add(index);
                        _lstFavorites.Remove(frmEntry.Enregistrement);
                    }
                }
            }
            else if (frmEntry.DialogResult == DialogResult.Cancel)
            {
                _lstEntry[index].Favorites = frmEntry.Enregistrement.Favorites;

                // Boucle qui vérifie la valeur du booléen qui indique si l'entrée est en favoris
                if (Convert.ToBoolean(frmEntry.Enregistrement.Favorites))
                {
                    _lstFavorites.Add(frmEntry.Enregistrement);
                }
                else
                {
                    _lstFavorites.Remove(frmEntry.Enregistrement);
                }

                _modifiedInXmlFile.Add(index);
            }
            secure.ActionOnFileContent(frmMain.Key, this);
        }

        /// <summary>
        /// Méthode qui permet d'ajouter une entrée dans la liste des entrées et dans la liste AddedInXmlFile
        /// </summary>
        public void AddValuesInData()
        {
            FrmEntry frmEntry = new FrmEntry(false);
            frmEntry.ShowDialog();
            // Boucle qui vérifie le resultat de la boite de dialogue
            if (frmEntry.DialogResult == DialogResult.Yes)
            {
                _cancel = false;

                _newEntry = new Entry(frmEntry.Enregistrement.Name, frmEntry.Enregistrement.Url, frmEntry.Enregistrement.Password, frmEntry.Enregistrement.Username, DateTime.Now, frmEntry.Enregistrement.Favorites);
                _lstEntry.Add(_newEntry);
                int index = _lstEntry.IndexOf(_newEntry);
                _addedInXmlFile.Add(index);
            }
            else
            {
                _cancel = true;
            }
        }

        /// <summary>
        /// Méthode qui permet de modifier le texte du bouton
        /// </summary>
        /// <param name="index">L'identifiant du  bouton</param>
        /// <param name="newName">Le nouveau nom</param>
        private void UpdateOnButton(int index, string newName)
        {
            Button button = (Button)_flpButton.Controls[index];
            // Boucle qui vérifie que le nouveau nom n'est pas semblable au nom du bouton
            if (button.Text != newName)
            {
                button.Text = newName;
            }
        }

        /// <summary>
        /// Méthode qui permet de récupérer les données du fichier datafile.xml
        /// </summary>
        /// <returns>La liste des entrées</returns>
        private  List<Entry> GetDataInArray()
        {
            List<Entry> data = new List<Entry>();
            DateTime dateTime;
            xDocument = XDocument.Load(xmlFile.DataFilePath);

            foreach (XElement element in xDocument.Descendants("data").Nodes().ToList())
            {
                dateTime = DateTime.ParseExact(element.Element("date").Value, "MM:dd:yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                data.Add(new Entry(element.Element("name").Value, element.Element("url").Value, element.Element("password").Value, element.Element("username").Value, dateTime, element.Element("favorites").Value));
            }

            return data;
        }

        /// <summary>
        /// Méthode qui permet de récupérer les entrées en favoris
        /// </summary>
        /// <returns>La liste des entrées en favoris</returns>
        private List<Entry> GetAllFavoritesData()
        {
            List<Entry> favorites = new List<Entry>();
            DateTime dateTime;
            xDocument = XDocument.Load(xmlFile.DataFilePath);

            foreach (XElement element in xDocument.Descendants("data").Nodes().ToList())
            {
                // Boucle qui permet de vérifier la valeur du booléen
                if (Convert.ToBoolean(element.Element("favorites").Value))
                {
                    dateTime = DateTime.ParseExact(element.Element("date").Value, "MM:dd:yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); //Yann heleped
                    favorites.Add(new Entry(element.Element("name").Value, element.Element("url").Value, element.Element("password").Value, element.Element("username").Value, dateTime, element.Element("favorites").Value));
                }
            }

            return favorites;
        }
    }
}
