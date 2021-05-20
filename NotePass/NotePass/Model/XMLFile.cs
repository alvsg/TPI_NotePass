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
using System.Windows.Forms; //Directive ajouté manuellement
using System.Xml.Linq; //Directive ajouté manuellement

namespace NotePass.Model
{
    public class XmlFile
    {
        #region Déclaration des varaibles

        private string usernameWindows, _dirPath, fileDataXml, fileForgottenPwd, _dataFilePath, _forgottenpwdFilePath;
        private List<string> _lstAnswer;
        private Security secure;
        private XDocument xDocument;

        #endregion

        /// <summary>
        /// Texte qui est le chemin du fichier Xml datafile.xml
        /// </summary>
        public string DataFilePath { get => _dataFilePath; }
        /// <summary>
        /// Texte qui est le chemin du fichier xml forgottenpwd.xml
        /// </summary>
        public string ForgottenpwdFilePath { get => _forgottenpwdFilePath; }
        /// <summary>
        /// Liste des réponses
        /// </summary>
        public List<string> LstAnswer { get => _lstAnswer; set => _lstAnswer = value; }
        /// <summary>
        /// Texte qui est l'emplacement du projet
        /// </summary>
        public string DirPath { get => _dirPath; set => _dirPath = value; }

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
            _dirPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/data/";
            _dataFilePath = _dirPath + fileDataXml;
            _forgottenpwdFilePath = _dirPath + fileForgottenPwd;
            _lstAnswer = new List<string>();
            secure = new Security(this);
        }

        /// <summary>
        /// Constructeur qui récupère le mot de passe et un booléen qui indique si le fichier forgottenpwd.xml est chiffré ou non
        /// </summary>
        /// <param name="passwordOf"></param>
        /// <param name="isEncrypt"></param>
        public XmlFile(string passwordOf, bool isEncrypt) : this()
        {
            // Boucle qui vérifie si le fichier est chiffré
            if (isEncrypt)
            {
                secure.ActionOnFile(false, secure.StringEncryptPwd, "writing", _forgottenpwdFilePath);
            }

            GetAllResponse(passwordOf);

            // Boucle qui vérifie si le fichier est chiffré
            if (isEncrypt)
            {
                secure.ActionOnFile(true, secure.StringEncryptPwd, "writing", _forgottenpwdFilePath);
            }
        }

        /// <summary>
        /// Méthode qui permet de crée le fichier xml (https://stackoverflow.com/questions/4721735/how-to-save-this-string-into-xml-file/4721762)
        /// </summary>
        public void CreateDataXmlFile(int noIndex, string name, string password, string username, string url, bool favorites)
        {
            string textInFile = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + Environment.NewLine + "<data>" + Environment.NewLine + "</data>";
            File.WriteAllText(_dataFilePath, textInFile);
            // Boucle qui vérifie si le nom est celui de l'application
            if (name == "NotePass")
            {
                username = usernameWindows;
            }
            InsertDataInFile(noIndex, name, password, username, url, DateTime.Now, favorites);
        }

        /// <summary>
        /// Méthode qui permet d'insérer une nouvelle entrée dans le fichier datafile.xml
        /// </summary>
        /// <param name="noIndex">L'identifiant</param>
        /// <param name="nameOf">Le nom du site ou du logiciel</param>
        /// <param name="passwordOf">Le mot de passe</param>
        /// <param name="usernameOf">Le nom d'utilisateur</param>
        /// <param name="urlOf">L'adresse web</param>
        /// <param name="added">La date d'ajout</param>
        /// <param name="isFavorites">Le booléen qui indique si l'entrée est en favoris</param>
        public void InsertDataInFile(int noIndex, string nameOf, string passwordOf, string usernameOf, string urlOf, DateTime added, bool isFavorites)
        {
            xDocument = XDocument.Load(_dataFilePath);

            XElement id = new XElement("id");
            XElement name = new XElement("name", nameOf);
            XElement password = new XElement("password", passwordOf);
            XElement username = new XElement("username", usernameOf);
            XElement url = new XElement("url", urlOf);
            XElement favorites = new XElement("favorites", isFavorites);
            XElement date = new XElement("date", added.ToString("MM:dd:yyyy HH:mm:ss"));

            id.SetAttributeValue("no", noIndex);
            xDocument.Root.Add(id);
            id.Add(name, password, username, url, favorites, date);
            xDocument.Save(_dataFilePath);
        }

        /// <summary>
        /// Méthode qui permet de créer le fichier forgottenpwd.xml
        /// </summary>
        /// <param name="Question1">La première question</param>
        /// <param name="Question2">La deuième question</param>
        /// <param name="Question3">La troisième question</param>
        /// <param name="password">Le mot de passe de l'application</param>
        public void CreateForgottenPwdXmlFile(int Question1, int Question2, int Question3, string password)
        {
            string passwordOfQ1 = secure.ActionOnString(true, password, _lstAnswer[0]);
            string passwordOfQ2 = secure.ActionOnString(true, password, _lstAnswer[1]);
            string passwordOfQ3 = secure.ActionOnString(true, password, _lstAnswer[2]);

            string responseOfQ1 = secure.ActionOnString(true, _lstAnswer[0], password);
            string responseOfQ2 = secure.ActionOnString(true, _lstAnswer[1], password);
            string responseOfQ3 = secure.ActionOnString(true, _lstAnswer[2], password);

            string textInFile = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + Environment.NewLine + "<questions>" + Environment.NewLine + "</questions>";
            File.WriteAllText(_forgottenpwdFilePath, textInFile);
            InsertQuestionsInto(Question1, Question2, Question3, passwordOfQ1, passwordOfQ2, passwordOfQ3, responseOfQ1, responseOfQ2, responseOfQ3);
        }

        /// <summary>
        /// Méthode qui permet d'insérer les données dans le fichier forgottenpwd.xml 
        /// </summary>
        /// <param name="Question1">La première question</param>
        /// <param name="Question2">La deuième question</param>
        /// <param name="Question3">La troisième question</param>
        /// <param name="passwordOfQ1">Le mot de passe chiffré à l'aide de la réponse de la question 1</param>
        /// <param name="passwordOfQ2">Le mot de passe chiffré à l'aide de la réponse de la question 2</param>
        /// <param name="passwordOfQ3">Le mot de passe chiffré à l'aide de la réponse de la question 3</param>
        /// <param name="responseOfQ1">La réponse de la question 1 chiffré avec le mot de passe</param>
        /// <param name="responseOfQ2">La réponse de la question 2 chiffré avec le mot de passe</param>
        /// <param name="responseOfQ3">La réponse de la question 3 chiffré avec le mot de passe</param>
        private void InsertQuestionsInto(int Question1, int Question2, int Question3, string passwordOfQ1, string passwordOfQ2, string passwordOfQ3, string responseOfQ1, string responseOfQ2, string responseOfQ3)
        {
            xDocument = XDocument.Load(_forgottenpwdFilePath);

            XElement firstQuestion = new XElement("question", passwordOfQ1);
            XElement secondQuestion = new XElement("question", passwordOfQ2);
            XElement thirdQuestion = new XElement("question", passwordOfQ3);

            XElement firstResponse = new XElement("response", responseOfQ1);
            XElement secondResponse = new XElement("response", responseOfQ2);
            XElement thirdResponse = new XElement("response", responseOfQ3);


            firstQuestion.SetAttributeValue("id", Question1);
            firstResponse.SetAttributeValue("id", Question1);
            xDocument.Root.Add(firstQuestion, firstResponse);

            secondQuestion.SetAttributeValue("id", Question2);
            secondResponse.SetAttributeValue("id", Question1);
            xDocument.Root.Add(secondQuestion, secondResponse);

            thirdQuestion.SetAttributeValue("id", Question3);
            thirdResponse.SetAttributeValue("id", Question1);
            xDocument.Root.Add(thirdQuestion, thirdResponse);

            xDocument.Save(_forgottenpwdFilePath);
        }

        /// <summary>
        /// Méthode qui permet de mettre à jour les données dans le fichier datafile.xml
        /// </summary>
        /// <param name="noIndex">L'identifiant</param>
        /// <param name="nameOf">Le nom du site ou du logiciel</param>
        /// <param name="passwordOf">Le mot de passe</param>
        /// <param name="usernameOf">Le nom d'utilisateur</param>
        /// <param name="urlOf">L'adresse web</param>
        /// <param name="added">La date d'ajout</param>
        /// <param name="isFavorites">Le booléen qui indique si l'entrée est en favoris</param>
        public void UpdateDataInXml(int noIndex, string nameOf, string passwordOf, string usernameOf, string urlOf, bool isFavorites)
        {
            xDocument = XDocument.Load(_dataFilePath);
            foreach (XElement parent in xDocument.Root.Elements("id"))
            {
                // Boucle qui vérifie si l'identifiant correspond
                if ((int)parent.Attribute("no") == noIndex)
                {
                    // Boucle qui vérifie le nom de la balise
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

        /// <summary>
        /// Méthode qui permet de mettre à jour les données dans le fichier forgottenpwd.xml avec le nouveau mot de passe
        /// </summary>
        /// <param name="newPassword"></param>
        /// <param name="answers"></param>
        public void UpdatePassword(string newPassword, List<string> answers)
        {
            // Boucle qui vérifie si la réponse n'est pas null
            if (answers != null)
            {
                _lstAnswer = answers;
            }

            xDocument = XDocument.Load(_forgottenpwdFilePath);
            List<int> idQuestion = GetSelectedQuestion();
            foreach (XElement element in xDocument.Descendants("questions").Nodes().ToList())
            {
                if ((int)element.Attribute("id") == idQuestion[0])
                {
                    UpdateData(element, newPassword, idQuestion.IndexOf((int)element.Attribute("id")));
                }
                else if ((int)element.Attribute("id") == idQuestion[1])
                {
                    UpdateData(element, newPassword, idQuestion.IndexOf((int)element.Attribute("id")));
                }
                else if ((int)element.Attribute("id") == idQuestion[2])
                {
                    UpdateData(element, newPassword, idQuestion.IndexOf((int)element.Attribute("id")));
                }
            }
            xDocument.Save(_forgottenpwdFilePath);
            secure.ActionOnFile(true, secure.StringEncryptPwd, "writing", _forgottenpwdFilePath);
        }

        /// <summary>
        /// Méthode qui permet de récupérer les réponses des questions
        /// </summary>
        /// <param name="password"></param>
        private void GetAllResponse(string password)
        {
            xDocument = XDocument.Load(_forgottenpwdFilePath);
            foreach (XElement element in xDocument.Descendants("questions").Nodes().ToList())
            {
                // Boucle qui vérifie le nom de la balise
                if (element.Name == "response")
                {
                    string response = secure.ActionOnString(false, element.Value, password);
                    _lstAnswer.Add(response);
                }
            }
        }

        /// <summary>
        /// Méthode qui permet de récupérer les questions sélectioné
        /// </summary>
        /// <returns></returns>
        private List<int> GetSelectedQuestion()
        {
            List<int> idQuestion = new List<int>();
            foreach (XElement element in xDocument.Descendants("questions").Nodes().ToList())
            {
                // Boucle qui vérifie le nom de la balise
                if (element.Name == "question")
                {
                    idQuestion.Add(Convert.ToInt32(element.Attribute("id").Value));
                }
            }
            return idQuestion;
        }

        /// <summary>
        /// Néthode qui permet de mettre à jour la valeur des balises dans le fichier forgottenpwd.xml
        /// </summary>
        /// <param name="element">La balise</param>
        /// <param name="newPassword">Le nouveau mot de passe</param>
        /// <param name="index">L'identifiant </param>
        private void UpdateData(XElement element, string newPassword, int index)
        {
            switch (element.Name.ToString())
            {
                case "question":
                    element.Value = secure.ActionOnString(true, newPassword, _lstAnswer[index]);
                    break;
                case "response":
                    element.Value = secure.ActionOnString(true, _lstAnswer[index], newPassword);
                    break;
            }
        }
    }
}
