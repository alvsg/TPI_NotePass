using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotePass.Model;
using System;

namespace UnitTest_NotePass
{
    [TestClass]
    public class UnitTest_Model_Entry
    {
        Entry entry;
        string name, url, password, username;
        bool favorites;
        DateTime date;

        [TestMethod]
        public void NewEntryWithDateTime()
        {
            // arrange
            name = "Youtube";
            url = "https://www.youtube.com/";
            password = "Super-2021";
            username = "";
            favorites = false;
            date = DateTime.Now;

            // act
            entry = new Entry(name, url, password, username, date, favorites.ToString());

            // assert
            Assert.AreEqual(name, entry.Name, "Le nom n'est pas semblable au resultat attendu");
            Assert.AreEqual(url, entry.Url, "L'url n'est pas semblable au resultat attendu");
            Assert.AreEqual(password, entry.Password, "Le mot de passe n'est pas semblable au resultat attendu");
            Assert.AreEqual(username, entry.Username, "Le nom d'utilisateur n'est pas semblable au resultat attendu");
            Assert.AreEqual(favorites.ToString(), entry.Favorites, "L'indication qui définit si l'entrée est en favoris n'est pas semblable au resultat attendu");
            Assert.AreEqual(date, entry.Date, "La date d'ajout n'est pas semblable au resultat attendu");
        }

        [TestMethod]
        public void NewEntryWithoutDateTime()
        {
            // arrange
            name = "Youtube";
            url = "https://www.youtube.com/";
            password = "Super-2021";
            username = "";
            favorites = false;

            // act
            entry = new Entry(name, url, password, username, favorites.ToString());

            // assert
            Assert.AreEqual(name, entry.Name, "Le nom n'est pas semblable au resultat attendu");
            Assert.AreEqual(url, entry.Url, "L'url n'est pas semblable au resultat attendu");
            Assert.AreEqual(password, entry.Password, "Le mot de passe n'est pas semblable au resultat attendu");
            Assert.AreEqual(username, entry.Username, "Le nom d'utilisateur n'est pas semblable au resultat attendu");
            Assert.AreEqual(favorites.ToString(), entry.Favorites, "L'indication qui définit si l'entrée est en favoris n'est pas semblable au resultat attendu");
        }
    }
}
