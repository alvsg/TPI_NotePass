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
using System.Xml.Linq; //Directive ajouté manuellement

namespace NotePass.Model
{
    class XmlFile
    {
        private string usernameWindows, dirPath, fileXml, _filePath;
        private Security secure;
        private XDocument xDocument;

        public string FilePath { get => _filePath; }

        /// <summary>
        /// Constructeur principal de la classe XmlFile
        ///     _usernameWindows = le nom d'utilisateur windows (https://docs.microsoft.com/en-us/dotnet/api/system.environment.username?view=net-5.0)
        ///     _fileXml = le nom du fichier
        ///     _dirPath = l'emplacement du projet + le nom d'un dossier (https://stackoverflow.com/questions/816566/how-do-you-get-the-current-project-directory-from-c-sharp-code-when-creating-a-c)
        ///     _filePath = l'emplacement du fichier xml
        /// </summary>
        public XmlFile()
        {
            usernameWindows = Environment.UserName;
            fileXml = "datafile.xml";
            dirPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/data/";
            _filePath = dirPath + fileXml;
            secure = new Security(this);
        }

        /// <summary>
        /// Méthode qui permet de vérifier si l'utilisateur ouvre la première fois l'application
        ///     Si oui, le fichier xml est crée et le formulaire de création s'affiche 
        /// </summary>
        /// <param name="frmAuthentification">Le formulaire d'authentification</param>
        public void VerifyIfFirstOpen(FrmAuthentification frmAuthentification)
        {
            bool exist = VerifyIfExist();
            // Boucle qui vérifie que le résultat correct
            if (exist == false)
            {
                View.FrmRegistry frmRegistry = new View.FrmRegistry(false);
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
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                return false;
            }
            // Boucle qui vérifie si le fichier XML n'existe pas
            else if (!File.Exists(_filePath + ".aes"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Méthode qui permet de crée le fichier xml (https://stackoverflow.com/questions/4721735/how-to-save-this-string-into-xml-file/4721762)
        /// </summary>
        public void CreateXmlFile( string password, int Question1, int Question2, int Question3, string Answer1, string Answer2, string Answer3)
        {
            string textInFile = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + Environment.NewLine + "<data>" + Environment.NewLine + "</data>";
            File.WriteAllText(_filePath, textInFile);
            InsertFirstDataInFile(0, "NotePass", password, usernameWindows, Question1, Question2, Question3, Answer1, Answer2, Answer3, false);
        }

        /// <summary>
        /// Méthode qui permet de supprimer un fichier
        /// </summary>
        /// <param name="file">Le fichier rechercher</param>
        public void IfCopyExist(string file)
        {
            // Boucle qui vérifie que le fichier existe
            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        public void InsertDataInFile(int noIndex ,string nameOf, string passwordOf, string usernameOf, string urlOf, bool isFavorites)
        {
            xDocument = XDocument.Load(_filePath);

            XElement id = new XElement("id");
            XElement name = new XElement("name", nameOf);
            XElement password = new XElement("password", passwordOf);
            XElement username = new XElement("username", usernameOf);
            XElement url = new XElement("url", urlOf);
            XElement favorites = new XElement("favorites", isFavorites);
            XElement date = new XElement("date", DateTime.Now.ToString("MM:dd:yyyy HH:mm"));

            id.SetAttributeValue("no", noIndex);
            xDocument.Root.Add(id);
            id.Add(name, password, username, url, favorites, date);
            xDocument.Save(_filePath);
        }

        private void InsertFirstDataInFile(int noIndex, string nameOf, string passwordOf, string usernameOf, int Question1, int Question2, int Question3, string Answer1, string Answer2, string Answer3, bool isFavorites)
        {
            xDocument = XDocument.Load(_filePath);

            XElement id = new XElement("id");
            XElement name = new XElement("name", nameOf);
            XElement password = new XElement("password", passwordOf);
            XElement username = new XElement("username", usernameOf);
            XElement firstQuestion = new XElement("firstQuestion", Answer1);
            XElement secondQuestion = new XElement("secondQuestion", Answer2);
            XElement thirdQuestion = new XElement("thirdQuestion", Answer3);
            XElement favorites = new XElement("favorites", isFavorites);
            XElement date = new XElement("date", DateTime.Now.ToString("MM:dd:yyyy HH:mm:ss"));

            id.SetAttributeValue("no", noIndex);
            firstQuestion.SetAttributeValue("id", Question1);
            secondQuestion.SetAttributeValue("id", Question2);
            thirdQuestion.SetAttributeValue("id", Question3);

            xDocument.Root.Add(id);
            id.Add(name, password, username, firstQuestion, secondQuestion, thirdQuestion, favorites, date);
            xDocument.Save(_filePath);
        }

        /// <summary>
        /// Méthode qui permet de récupérer les données du fichier xml et de les mettre dans une liste
        /// </summary>
        /// <returns> La liste de donnée </returns>
        public List<Entry> GetDataInArray()
        {
            List<Entry> data = new List<Entry>();
            xDocument = XDocument.Load(_filePath);

            // Boucle qui parcour les données dans le fichiers XML
            foreach (XElement element in xDocument.Descendants("data").Nodes().ToList())
            {
                if((int)element.Element("id").Attribute("no") == 0)
                {

                }
                data.Add(new Entry(element.Element("name").Value, element.Element("url").Value, element.Element("password").Value, element.Element("username").Value, Convert.ToDateTime(element.Element("date").Value), element.Element("favorites").Value));
            }

            return data;
        }
    }
}
