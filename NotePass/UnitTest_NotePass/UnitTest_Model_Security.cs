using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotePass.Model;
using System.Windows.Forms;

namespace UnitTest_NotePass
{
    [TestClass]
    public class UnitTest_Model_Security
    {
        string textToDecrypt;

        [TestMethod]
        public void CallSecurityWithParameters()
        {
            // arrange
            Security secure;
            XmlFile xmlFile;

            // act
            xmlFile = new XmlFile();
            secure = new Security(xmlFile);

            // assert
            Assert.AreEqual(xmlFile, secure.xmlFile, "Le parametre de la claase XmlFile est incorrect");
        }

        [TestMethod]
        public void CallSecurityWithoutParameters()
        {
            // arrange
            Security secure;
            string password;

            // act
            password = "xv9$tv&Ak9hpX6wMwTnZPKn?NFzhBr";
            secure = new Security();

            // assert
            Assert.AreEqual(password, secure.StringEncryptPwd, "Le mot de passe n'est pas semblable");
        }
        
        [TestMethod]
        public void EncryptAText()
        {
            // arrange
            Security secure;

            // act
            secure = new Security();
            textToDecrypt = secure.ActionOnString(true, "Text", "Mot-de-passe-2021");
            string error = null;

            // assert
            Assert.AreEqual(error, secure.Error, "Le déchiffrement à échoué");
        }

        [TestMethod]
        public void DecryptAText()
        {
            // arrange
            Security secure;

            // act
            secure = new Security();
            textToDecrypt = secure.ActionOnString(true, "Text", "Mot-de-passe-2021");
            textToDecrypt = secure.ActionOnString(false, textToDecrypt, "Mot-de-passe-2021");
            string error = null;

            // assert
            Assert.AreEqual(error, secure.Error, "Le déchiffrement à échoué");
        }
    }
}
