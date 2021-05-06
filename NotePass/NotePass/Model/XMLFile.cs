/*
 * PROJET : NotePass - Gestionnaire de mot de passe
 * AUTEUR : ALVES GUASTTI Letitia (I.FA-P3A)
 * DESC.: Permet de crée et d'effectuer des actions précises sur le fichier XML et son contenu
 * VERSION : 04.05.2021 v.1
 */

using System;
using System.Collections.Generic;
using System.IO; //Directive ajouté manuellement
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePass.Model
{
    class XmlFile
    {
        private string _usernameWindows, _dirPath, _fileXml, _filePath;
        private Security secure;

        public string UsernameWindows { get => _usernameWindows; }
        public string DirPath { get => _dirPath; }
        public string FileXml { get => _fileXml; }
        public string FilePath { get => _filePath; }

        /// <summary>
        /// Constructeur principal de la classe XmlFile
        ///     _usernameWindows = le nom d'utilisateur windows https://docs.microsoft.com/en-us/dotnet/api/system.environment.username?view=net-5.0
        ///     _fileXml = le nom du fichier
        ///     _dirPath = l'emplacement du projet + le nom d'un dossier https://stackoverflow.com/questions/816566/how-do-you-get-the-current-project-directory-from-c-sharp-code-when-creating-a-c
        ///     _filePath = l'emplacement du fichier xml
        /// </summary>
        public XmlFile()
        {
            _usernameWindows = Environment.UserName;
            _fileXml = "datafile.xml";
            _dirPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/data/";
            _filePath = _dirPath + _fileXml;
            secure = new Security(this);
        }

        /// <summary>
        /// Méthode qui permet de vérifier si l'utilisateur ouvre la première fois l'application
        ///     Si oui, le fichier xml est crée et le formulaire de création s'affiche 
        /// </summary>
        /// <param name="frmAuthentification"></param>
        public void VerifyIfFirstOpen(FrmAuthentification frmAuthentification)
        {
            bool exist = VerifyIfExist();
            // Boucle qui vérifie que le résultat correct
            if(exist == false)
            {
                View.FrmRegistry frmRegistry = new View.FrmRegistry();
                frmRegistry.ShowDialog();
                frmAuthentification.Close();
            }
        }

        /// <summary>
        /// Méthode qui permet de vérifier si le fichier xml a déjà été crée
        /// </summary>
        /// <returns> Un booléen qui indiquera si les deux extistent (true) ou si ils n'existent pas (false) </returns>
        private bool VerifyIfExist()
        {
            // Boucle qui vérifie si le dossier data n'existe pas
            if (!Directory.Exists(_dirPath))
            {
                Directory.CreateDirectory(_dirPath);
                return false;
            }
            // Boucle qui vérifie si le fichier XML n'existe pas
            else if (!System.IO.File.Exists(_filePath + ".aes"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Méthode qui permet de crée le fichier xml
        /// https://stackoverflow.com/questions/4721735/how-to-save-this-string-into-xml-file/4721762
        /// </summary>
        public void CreateXmlFile(string password)
        {
            string textInFile = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + Environment.NewLine + "<data>" + Environment.NewLine + "</data>";
            File.WriteAllText(_filePath, textInFile);
            secure.ActionOnFile(true, password, "");
        }

        /// <summary>
        /// Méthode qui permet de supprimer un fichier
        /// </summary>
        /// <param name="file">Le fichier voulu</param>
        public void IfCopyExist(string file)
        {
            // Boucle qui vérifie que le fichier existe
            if (System.IO.File.Exists(file))
            {
                System.IO.File.Delete(file);
            }
        }
    }
}
