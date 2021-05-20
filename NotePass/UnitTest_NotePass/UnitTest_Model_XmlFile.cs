using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotePass.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTest_NotePass
{
    [TestClass]
    public class UnitTest_Model_XmlFile
    {
        [TestMethod]
        public void CallXmlFileWithoutParameters()
        {
            // arrange
            XmlFile xmlFile;

            // act
            xmlFile = new XmlFile();
            string dataFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/data/datafile.xml";
            string forgottenpwdFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/data/forgottenpwd.xml";

            // assert
            Assert.AreEqual(dataFilePath, xmlFile.DataFilePath);
            Assert.AreEqual(forgottenpwdFilePath, xmlFile.ForgottenpwdFilePath);
        }
        
        [TestMethod]
        public void CallXmlFileWithParameters()
        {
            // arrange
            XmlFile xmlFile;

            // act
            xmlFile = new XmlFile("Mot-de-passe-2021", false);
            List<string> lstAnswer = new List<string>();
            lstAnswer.Add("Première réponse");
            lstAnswer.Add("Deuxième réponse");
            lstAnswer.Add("Troisième réponse");

            // assert
            for(int index = 0; index < lstAnswer.Count; index++)
            {
                Assert.AreEqual(lstAnswer[index], xmlFile.LstAnswer[index]);
            }
        }

        [TestMethod]
        public void CreationOfDataFileXml()
        {
            // arrange
            XmlFile xmlFile;

            // act
            xmlFile = new XmlFile();
            xmlFile.CreateDataXmlFile(0,"NotePass", "Mot-de-passe-2021", "Nom d'utilisateur", "",false);
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/data/datafile.xml";

            // assert
            Assert.AreEqual(path, xmlFile.DataFilePath);
        }
        
        [TestMethod]
        public void CreationOfForgottenpwdXml()
        {
            // arrange
            XmlFile xmlFile;
            List<string> lstAnswer;

            // act
            xmlFile = new XmlFile();
            lstAnswer = new List<string>();
            lstAnswer.Add("Première réponse");
            lstAnswer.Add("Deuxième réponse");
            lstAnswer.Add("Troisième réponse");
            xmlFile.LstAnswer = lstAnswer;
            xmlFile.CreateForgottenPwdXmlFile(0, 1, 2, "Mot-de-passe-2021");
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/data/forgottenpwd.xml";

            // assert
            Assert.AreEqual(path, xmlFile.ForgottenpwdFilePath);
        }

        [TestMethod]
        public void InsertDataInXmlFileData()
        {
            // arrange
            XmlFile xmlFile;

            // act
            xmlFile = new XmlFile();
            xmlFile.InsertDataInFile(1, "Snapchat", "Ancien-mot-de-passe-2020", "Nom d'utilisateur", "", DateTime.Now, true);

            // assert
            Assert.IsNotNull(xmlFile.DataFilePath);
        }
    }
}
