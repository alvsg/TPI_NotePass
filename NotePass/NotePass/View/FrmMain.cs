/*
 * PROJET : NotePass - Gestionnaire de mot de passe
 * AUTEUR : ALVES GUASTTI Letitia (I.FA-P3A)
 * DESC.: Cette vue est la vue principale du projet 
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
    /// Vue principale du projet 
    /// </summary>
    public partial class FrmMain : Form
    {
        #region Déclaration de variables

        private string _key;
        private Model.Security secure;
        private Model.XmlFile xmlFile;
        private Model.Safe safe;
        private UserInput userInput;
        /// <summary>
        /// Booléen qui indique si les entrées affichées sont uniquement les entrées en favoris
        /// </summary>
        private bool isOnlyFavorites;
        /// <summary>
        /// Liste des boutons a supprimé 
        /// </summary>
        private List<Button> lstToDelete;
        private Button btnEntry;

        #endregion

        /// <summary>
        /// Le mot de passe de l'application
        /// </summary>
        public string Key { get => _key; }


        /// <summary>
        /// Constructeur qui récupère le mot de passe de l'utilisateur
        /// </summary>
        /// <param name="password">Mot de passe de l'application</param>
        public FrmMain(string password)
        {
            InitializeComponent();
            _key = password;
            xmlFile = new Model.XmlFile(password, true);
            secure = new Model.Security(xmlFile);
            safe = new Model.Safe(this, flpEntry);
            userInput = new UserInput();
            isOnlyFavorites = false;
            lstToDelete = new List<Button>();
        }

        /// <summary>
        /// Méthode qui permet de chiffrer le fichier datafile.xml et d'afficher les entrées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            secure.ActionOnFile(true, _key, "writing", xmlFile.DataFilePath);
            OnLoad(safe.LstEntry, flpEntry);
        }

        /// <summary>
        /// Méthode qui ajoute une entrée dans le fichier datafile.xml quand le bouton de l'entrée a été ajouté
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flpEntry_ControlAdded(object sender, ControlEventArgs e)
        {
            // Boucle qui vérifie si le nombre de boutons est supérieur au nombre de données
            if (safe.LstEntry.Count > safe.NoData)
            {
                secure.ActionOnFileContent(_key, safe);
                safe.NoData = safe.LstEntry.Count;
            }
        }

        /// <summary>
        /// Méthode qui permet d'ajouter une nouvelle entrée et de créer le bouton suite à un ajout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isOnlyFavorites = false;
            safe.AddValuesInData();
            // Boucle qui vérifie que la forme n'a pas été fermer sans envoyer les données
            if (!safe.Cancel)
            {
                CreateButtons(safe.NewEntry);
            }
        }

        /// <summary>
        /// Méthode qui permet de lancer la méthode de création d'entrée en simulant un clique sur le bouton d'ajout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            btnAdd.PerformClick();
        }

        /// <summary>
        /// Méthode qui permet d'afficher les entrées en favoris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFavorites_Click(object sender, EventArgs e)
        {
            isOnlyFavorites = true;
            foreach (Button button in flpEntry.Controls)
            {
                Model.Entry entry = (Model.Entry)button.Tag;
                // Boucle qui vérifie que l'entrée est dans la liste des favoris
                if (!safe.LstFavorites.Contains(entry))
                {
                    lstToDelete.Add(button);
                }
            }

            foreach (Button button in lstToDelete)
            {
                flpEntry.Controls.Remove(button);
            }
        }

        /// <summary>
        /// Méthode qui permet d'afficher toutes les entrées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            isOnlyFavorites = false;
            OnLoad(safe.LstEntry, flpEntry);
        }

        /// <summary>
        /// Méthode qui permet de trier les entrées dans l'ordre alphabétique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAlphabeticalOrder_Click(object sender, EventArgs e)
        {
            MakeMyListSort(tsmiAlphabeticalOrder);
        }

        /// <summary>
        /// Méthode qui permet de trier les entrées par date d'ajout ascendant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDateAsc_Click(object sender, EventArgs e)
        {
            MakeMyListSort(tsmiDateAsc);
        }

        /// <summary>
        /// Méthode qui permet de trier les entrées par date d'ajout descendant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDateDesc_Click(object sender, EventArgs e)
        {
            MakeMyListSort(tsmiDateDesc);
        }

        /// <summary>
        /// Méthode qui trie les entrées selon le nom de l'option du menu sélectionné
        /// </summary>
        /// <param name="toolStripMenuItem">Le menu</param>
        private void MakeMyListSort(ToolStripMenuItem toolStripMenuItem)
        {
            List<Model.Entry> lstEntry;
            // Boucle qui vérifie si l'affichage affiche uniquement les entrées en favoris
            if (isOnlyFavorites)
            {
                lstEntry = userInput.SortTheList(safe.LstFavorites, toolStripMenuItem.Name);
            }
            else
            {
                lstEntry = userInput.SortTheList(safe.LstEntry, toolStripMenuItem.Name);
            }

            OnLoad(lstEntry, flpEntry);
        }

        /// <summary>
        /// Méthode qui permet de mettre à jour l'affichage des entrées
        /// </summary>
        /// <param name="lstData">La liste des entrées</param>
        /// <param name="flpEntry">Le conteneur des boutons</param>
        private void OnLoad(List<Model.Entry> lstData, FlowLayoutPanel flpEntry)
        {
            // Boucle qui vérifie que le nombre de bouton soit supérieur à 0
            if (flpEntry.Controls.Count > 0)
            {
                flpEntry.Controls.Clear();
            }

            foreach (Model.Entry entry in lstData)
            {
                CreateButtons(entry);
            }
        }

        /// <summary>
        /// Méthode qui permet de créer les boutons qui permet d'afficher les entrées
        /// </summary>
        /// <param name="entry">L'entrée</param>
        private void CreateButtons(Model.Entry entry)
        {
            btnEntry = new Button();
            btnEntry.Name = entry.Name;
            btnEntry.Text = entry.Name;
            btnEntry.FlatStyle = FlatStyle.Flat;
            btnEntry.Width = 188;
            btnEntry.Height = 111;
            btnEntry.Click += safe.btnFlp_Click;
            btnEntry.Tag = entry;
            flpEntry.Controls.Add(btnEntry);
        }
    }
}
