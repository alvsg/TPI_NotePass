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

        public FrmAuthentification()
        {
            InitializeComponent();
            xmlFile = new Model.XmlFile();
        }

        /// <summary>
        /// Méthode qui permet lors de l'initialisation de la fenêtre d'authentification de vérifier si l'utlisateur ouvre l'application pour la première fois
        ///     Si oui, ouvre la fenêtre de création
        /// </summary>
        /// <param name="sender">La fenêtre d'authentification</param>
        /// <param name="e"></param>
        private void FrmAuthentification_Load(object sender, EventArgs e)
        {
            xmlFile.VerifyIfFirstOpen(this);
        }
    }
}
