/*
 * PROJET : NotePass - Gestionnaire de mot de passe
 * AUTEUR : ALVES GUASTTI Letitia (I.FA-P3A)
 * DESC.: Cette classe permet de créer ou de récupérer les entrées selon les données que l'utilisateur a rentrées
 * VERSION : 04.05.2021 v.1
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePass.Model
{
    /// <summary>
    /// Modèle qui permet de créer ou de récupérer les entrées selon les données rentrées
    /// </summary>
    public class Entry
    {
        #region Déclaration des variables

        private string _name, _url, _password, _username, _favorites;
        private DateTime _date;

        #endregion

        /// <summary>
        /// Propriété du nom du site ou du logiciel de l'entrée
        /// </summary>
        public string Name { get => _name; set => _name = value; }
        /// <summary>
        /// Propriété de l'adresse web (url) du site de l'entrée
        /// </summary>
        public string Url { get => _url; set => _url = value; }
        /// <summary>
        /// Propriété du mot de passe de l'entrée
        /// </summary>
        public string Password { get => _password; set => _password = value; }
        /// <summary>
        /// Propriété du nom d'utilisateur de l'entrée
        /// </summary>
        public string Username { get => _username; set => _username = value; }
        /// <summary>
        /// Propriété qui définit ou retourne si l'entrée est en favoris
        /// </summary>
        public string Favorites { get => _favorites; set => _favorites = value; }
        /// <summary>
        /// Propriété de la date d'ajout
        /// </summary>
        public DateTime Date { get => _date; set => _date = value; }

        /// <summary>
        /// Constructeur qui permet de créer une entrée avec toutes les données que l'utilisateur a saisies
        /// </summary>
        /// <param name="nameOf">Le nom du site ou du logiciel</param>
        /// <param name="urlOf">L'addresse web (url)</param>
        /// <param name="passwordOf">Le mot de passe</param>
        /// <param name="usernameOf">Le nom d'utilisateur</param>
        /// <param name="favoritesOf">Un booléen qui détermine si l'entrée est en favoris</param>
        public Entry(string nameOf, string urlOf, string passwordOf, string usernameOf, string favoritesOf)
        {
            _name = nameOf;
            _url = urlOf;
            _password = passwordOf;
            _username = usernameOf;
            _favorites = favoritesOf;
        }

        /// <summary>
        /// Constructeur qui permet de modifier une entrée avec toutes les données que l'utilisateur a saisies
        /// </summary>
        /// <param name="nameOf">Le nom du site ou du logiciel</param>
        /// <param name="urlOf">L'addresse web (url)</param>
        /// <param name="passwordOf">Le mot de passe</param>
        /// <param name="usernameOf">Le nom d'utilisateur</param>
        /// <param name="date">La date d'ajout</param>
        /// <param name="favoritesOf">Un booléen qui détermine si l'entrée est en favoris</param>
        public Entry(string nameOf, string urlOf, string passwordOf, string usernameOf, DateTime date, string favoritesOf) : this(nameOf, urlOf, passwordOf, usernameOf, favoritesOf)
        {
            _date = date;
        }
    }
}
