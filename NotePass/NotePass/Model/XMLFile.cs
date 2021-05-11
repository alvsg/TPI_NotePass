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
        private string usernameWindows, dirPath, fileDataXml, fileForgottenPwd, _dataFilePath, _forgottenpwdFilePath;
        private Security secure;
        private XDocument xDocument;

        public string DataFilePath { get => _dataFilePath; }
        public string ForgottenpwdFilePath { get => _forgottenpwdFilePath; }

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
            fileDataXml = "datafile.xml";
            fileForgottenPwd = "forgottenpwd.xml";
            dirPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/data/";
            _dataFilePath = dirPath + fileDataXml;
            _forgottenpwdFilePath = dirPath + fileForgottenPwd;
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
            if (!exist)
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
            else if (!File.Exists(_dataFilePath + ".aes"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Méthode qui permet de crée le fichier xml (https://stackoverflow.com/questions/4721735/how-to-save-this-string-into-xml-file/4721762)
        /// </summary>
        public void CreateDataXmlFile(int noIndex, string name, string password, string username, string url, bool favorites)
        {
            string textInFile = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + Environment.NewLine + "<data>" + Environment.NewLine + "</data>";
            File.WriteAllText(_dataFilePath, textInFile);
            if (name == "NotePass")
            {
                username = usernameWindows;
            }
            InsertDataInFile(noIndex, name, password, username, url, favorites);
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

        public void InsertDataInFile(int noIndex, string nameOf, string passwordOf, string usernameOf, string urlOf, bool isFavorites)
        {
            xDocument = XDocument.Load(_dataFilePath);

            XElement id = new XElement("id");
            XElement name = new XElement("name", nameOf);
            XElement password = new XElement("password", passwordOf);
            XElement username = new XElement("username", usernameOf);
            XElement url = new XElement("url", urlOf);
            XElement favorites = new XElement("favorites", isFavorites);
            XElement date = new XElement("date", DateTime.Now.ToString("MM:dd:yyyy HH:mm:ss"));

            id.SetAttributeValue("no", noIndex);
            xDocument.Root.Add(id);
            id.Add(name, password, username, url, favorites, date);
            xDocument.Save(_dataFilePath);
        }

        public void CreateForgottenPwdXmlFile(int Question1, int Question2, int Question3, string password, string Answer1, string Answer2, string Answer3)
        {
            string passwordOfQ1 = secure.ActionOnString(true, password, Answer1);
            string passwordOfQ2 = secure.ActionOnString(true, password, Answer2);
            string passwordOfQ3 = secure.ActionOnString(true, password, Answer3);

            string textInFile = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + Environment.NewLine + "<question>" + Environment.NewLine + "</question>";
            File.WriteAllText(_forgottenpwdFilePath, textInFile);
            InsertQuestionsInto(Question1, Question2, Question3, passwordOfQ1, passwordOfQ2, passwordOfQ3);
            secure.ActionOnFile(true, secure.StringEncryptPwd, "", _forgottenpwdFilePath);
        }

        private void InsertQuestionsInto(int Question1, int Question2, int Question3, string passwordOfQ1, string passwordOfQ2, string passwordOfQ3)
        {
            xDocument = XDocument.Load(_forgottenpwdFilePath);

            XElement firstQuestion = new XElement("firstQuestion", passwordOfQ1);
            XElement secondQuestion = new XElement("secondQuestion", passwordOfQ2);
            XElement thirdQuestion = new XElement("thirdQuestion", passwordOfQ3);


            firstQuestion.SetAttributeValue("id", Question1);
            secondQuestion.SetAttributeValue("id", Question2);
            thirdQuestion.SetAttributeValue("id", Question3);

            xDocument.Root.Add(firstQuestion, secondQuestion, thirdQuestion);
            xDocument.Save(_forgottenpwdFilePath);
        }

        public List<int> GetIndexQuestions()
        {
            List<int> question = new List<int>();

            secure.ActionOnFile(false, secure.StringEncryptPwd, "writing", _forgottenpwdFilePath);
            xDocument = XDocument.Load(_forgottenpwdFilePath);
            foreach (XElement element in xDocument.Descendants("question").Nodes().ToList())
            {
                question.Add(Convert.ToInt32(element.Attribute("id").Value));
            }
            secure.ActionOnFile(true, secure.StringEncryptPwd, "", _forgottenpwdFilePath);

            return question;
        }

        public List<Entry> GetDataInArray()
        {
            List<Entry> data = new List<Entry>();
            DateTime dateTime;
            xDocument = XDocument.Load(_dataFilePath);

            // Boucle qui parcour les données dans le fichiers XML
            foreach (XElement element in xDocument.Descendants("data").Nodes().ToList())
            {
                dateTime = DateTime.ParseExact(element.Element("date").Value, "MM:dd:yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); //Yann heleped
                data.Add(new Entry(element.Element("name").Value, element.Element("url").Value, element.Element("password").Value, element.Element("username").Value, dateTime, element.Element("favorites").Value));
            }

            return data;
        }

        public void UpdateDataInXml(int noIndex, string nameOf, string passwordOf, string usernameOf, string urlOf, bool isFavorites)
        {
            xDocument = XDocument.Load(_dataFilePath);
            foreach (XElement parent in xDocument.Root.Elements("id"))
            {
                if ((int)parent.Attribute("num") == noIndex)
                {
                    if ((string)parent.Element("name") != nameOf)
                    {
                        parent.Element("name").Value = nameOf;
                    }
                    else if ((string)parent.Element("password") != passwordOf)
                    {
                        parent.Element("password").Value = passwordOf;
                    }
                    else if ((string)parent.Element("username") != usernameOf)
                    {
                        parent.Element("username").Value = usernameOf;
                    }
                    else if ((string)parent.Element("url") != urlOf)
                    {
                        parent.Element("url").Value = urlOf;
                    }
                    else if ((string)parent.Element("favorites") != isFavorites.ToString())
                    {
                        parent.Element("favorites").Value = isFavorites.ToString();
                    }
                }
            }
            xDocument.Save(_dataFilePath);
        }

        public void DeleteDataInXmlFile(int index)
        {
            xDocument = XDocument.Load(_dataFilePath);
            foreach (XElement parent in xDocument.Root.Elements("id"))
            {
                if ((int)parent.Attribute("num") == index)
                {
                    parent.Remove();
                }
            }
            xDocument.Save(_dataFilePath);
        }
    }
}
