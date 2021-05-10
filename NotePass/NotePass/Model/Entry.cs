using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePass.Model
{
    class Entry
    {
        private string _name, _url, _password, _username, _favorites, _firstAnswer, _secondAnswer, _thirdAwnser;
        private DateTime _date;

        public string Name { get => _name; set => _name = value; }
        public string Url { get => _url; set => _url = value; }
        public string Password { get => _password; set => _password = value; }
        public string Username { get => _username; set => _username = value; }
        public string Favorites { get => _favorites; set => _favorites = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string FirstAnswer { get => _firstAnswer; set => _firstAnswer = value; }
        public string SecondAnswer { get => _secondAnswer; set => _secondAnswer = value; }
        public string ThirdAnswer { get => _thirdAwnser; set => _thirdAwnser = value; }

        public Entry(string nameOf, string urlOf, string passwordOf, string usernameOf, DateTime date, string favoritesOf)
        {
            _name = nameOf;
            _url = urlOf;
            _password = passwordOf;
            _username = usernameOf;
            _date = date;
            _favorites = favoritesOf;
        }

        public Entry(string nameOf, string passwordOf, string usernameOf, string answer1, string answer2, string answer3, DateTime date, string favoritesOf)
        {
            _name = nameOf;
            _password = passwordOf;
            _username = usernameOf;
            _firstAnswer = answer1;
            _secondAnswer = answer2;
            _thirdAwnser = answer3;
            _date = date;
            _favorites = favoritesOf;
        }
    }
}
