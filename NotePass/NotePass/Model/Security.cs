/*
 * PROJET : NotePass - Gestionnaire de mot de passe
 * AUTEUR : ALVES GUASTTI Letitia (I.FA-P3A)
 * DESC.: Permet de gérer toute la partie sécurité de l'application
 * VERSION : 04.05.2021 v.1
 */

using System;
using System.Collections.Generic;
using System.IO; //Directive ajouté manuellement
using System.Runtime.InteropServices; //Directive ajouté manuellement
using System.Security.Cryptography; //Directive ajouté manuellement
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //Directive ajouté manuellement
using System.Xml.Linq;

namespace NotePass.Model
{
    /// <summary>
    /// Modèle qui permet de gérer toute la partie sécurité de l'application
    /// </summary>
    public class Security
    {
        #region Déclaration des valeurs 

        //Permet de supprimer la clé de la mémoire après utilisation
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);


        private static byte[] salt;
        private string _error;
        public XmlFile xmlFile;
        private string _stringEncryptPwd;

        #endregion
        
        /// <summary>
        /// Texte de l'erreur
        /// </summary>
        public string Error { get => _error; }
        /// <summary>
        /// Texte qui est un mot de passe
        /// </summary>
        public string StringEncryptPwd { get => _stringEncryptPwd; }

        /// <summary>
        /// Consteucteur qui récupère le modèle XmlFile en paramètre
        /// </summary>
        /// <param name="file">Le modèle XmlFile</param>
        public Security(XmlFile file) : this()
        {
            xmlFile = file;
        }

        /// <summary>
        /// Constructeur qui permet de générer un sel et un mot de passe en dur
        /// </summary>
        public Security()
        {
            salt = GenerateRandomSalt();
            _stringEncryptPwd = "xv9$tv&Ak9hpX6wMwTnZPKn?NFzhBr";
        }

        /// <summary>
        /// Methode qui permet de créer un sel aléatoire qui va être utiliser pour chiffrer le fichier
        /// </summary>
        /// <returns> Le sel </returns>
        private static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);
                }
            }

            return data;
        }

        /// <summary>
        /// Méthode qui permet de définir si le fichier xml doit être chiffré ou de déchiffré
        /// </summary>
        /// <param name="encrypt">Booléen qui indique si le fichier est chiffré</param>
        /// <param name="password">Mot de passe de l'application</param>
        /// <param name="inProgress">L'action en cours sur le fichier</param>
        /// <param name="filePath">L'emplacement du fichier</param>
        public void ActionOnFile(bool encrypt, string password, string inProgress, string filePath)
        {
            _error = null;

            // Epingle le mot de passe
            GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

            // Boucle qui vérifie si le fichier doit être chiffré ou déchiffré
            if (encrypt)
            {
                FileEncrypt(filePath, password);
                IfCopyExist(filePath);
            }
            else
            {
                string filePathAES = filePath + ".aes";
                FileDecrypt(filePathAES, filePath, password);
                // Boucle qui vérifie si il y a un erreur
                if (_error == null)
                {
                    IfCopyExist(filePathAES);
                }
                else
                {
                    IfCopyExist(filePath);
                }
            }

            // Supprime le mot de passe épingler si pas en ecriture dans le fichier
            if (inProgress != "writing")
            {
                ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
                gch.Free();
            }
        }

        /// <summary>
        /// Méthode qu permet de chiffrer un fichier (https://ourcodeworld.com/articles/read/471/how-to-encrypt-and-decrypt-files-using-the-aes-encryption-algorithm-in-c-sharp)
        /// </summary>
        /// <param name="inputFile"> Le chemin du fichier à chiffrer </param>
        /// <param name="password"> Le mot de passe de l'utilisateur </param>
        private void FileEncrypt(string inputFile, string password)
        {
            // (http://stackoverflow.com/questions/27645527/aes-encryption-on-large-files)

            using (FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create))
            {

                // Générer un sel aléatoire
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Définir l'algorithme de chiffrement symétrique Rijndael
                RijndaelManaged AES = new RijndaelManaged();
                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Padding = PaddingMode.PKCS7;

                // Hash à plusieurs reprises le mot de passe de l'utilisateur avec le sel. Nombre d'itérations élevé (http://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly)
                var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                // Cipher modes (http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption)
                AES.Mode = CipherMode.CFB;

                // Ecrit le sel au début du fichier
                fsCrypt.Write(salt, 0, salt.Length);

                using (CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {

                    using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                    {

                        // Créationd'un tampon (1mb) pour que seule cette quantité soit allouée dans la mémoire et non le fichier entier
                        byte[] buffer = new byte[1048576];
                        int read;

                        try
                        {
                            while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                cs.Write(buffer, 0, read);
                            }
                        }
                        catch (Exception ex)
                        {
                            _error = "Error: " + ex.Message;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Méthode qui permet de déchiffrer un fichier
        /// </summary>
        /// <param name="inputFile"> Le fichier chiffré </param>
        /// <param name="outputFile"> Le fichier déchiffré </param>
        /// <param name="password"> Le mot de passe de l'utilisateur </param>
        private void FileDecrypt(string inputFile, string outputFile, string password)
        {
            // Générer un sel aléatoire
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
            {
                fsCrypt.Read(salt, 0, salt.Length);

                // Définir l'algorithme de chiffrement symétrique Rijndael
                RijndaelManaged AES = new RijndaelManaged();
                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Padding = PaddingMode.PKCS7;

                // Hash à plusieurs reprises le mot de passe de l'utilisateur avec le sel. Nombre d'itérations élevé (http://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly)
                var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                // Cipher modes (http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption)
                AES.Mode = CipherMode.CFB;

                CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

                using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                {

                    // Créationd'un tampon (1mb) pour que seule cette quantité soit allouée dans la mémoire et non le fichier entier
                    byte[] buffer = new byte[1048576];
                    int read;

                    try
                    {
                        while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fsOut.Write(buffer, 0, read);
                        }
                    }
                    catch (CryptographicException ex_CryptographicException)
                    {
                        _error = "CryptographicException error: " + ex_CryptographicException.Message;
                    }
                    catch (Exception ex)
                    {
                        _error = "Error: " + ex.Message;
                    }
                }
            }
        }

        /// <summary>
        /// Méthode qui permet de générer un mot de passe aléatoirement
        /// </summary>
        /// <returns>Le mot de passe généré</returns>
        private string GenerateRandomPwd()
        {
            string characters = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
            string numbers = "0123456789";
            string specialChar = "~`!@#$%^&*()_-+={[}]|\\:;\"'<,>.?/";
            Random rnd = new Random();
            string GeneratePwd = "";
            for (int i = 0; i < 11; i++)
            {
                if (i % 2 == 0)
                {
                    GeneratePwd += characters[rnd.Next(0, characters.Length)];
                }
                else if (i % 3 == 0)
                {
                    GeneratePwd += specialChar[rnd.Next(0, specialChar.Length)];
                }
                else if (i % i == 0)
                {
                    GeneratePwd += numbers[rnd.Next(0, numbers.Length)];
                }
            }
            return Shuffle(GeneratePwd);
        }

        /// <summary>
        /// Méthode qui permet de mélanger l'emplacement des caractères dans un texte (https://stackoverflow.com/questions/4739903/shuffle-string-c-sharp)
        /// </summary>
        /// <param name="password"> </param>
        /// <returns>Le mot de passe généré aléatoirement mélangé</returns>
        private string Shuffle(string password)
        {
            char[] arrayChar = password.ToCharArray();
            Random position = new Random();
            int stringLenght = arrayChar.Length;
            while (stringLenght > 1)
            {
                stringLenght--;
                int newPosition = position.Next(stringLenght + 1);
                var value = arrayChar[newPosition];
                arrayChar[newPosition] = arrayChar[stringLenght];
                arrayChar[stringLenght] = value;
            }
            return new string(arrayChar);
        }

        /// <summary>
        /// Méthode qui permet de définir l'action de chiffrer ou de déchiffrer sur un texte 
        /// </summary>
        /// <param name="encrypt">Booléen qui indique si le texte doit être chiffré</param>
        /// <param name="text">Le texte</param>
        /// <param name="key">La clé de chiffrement/déchiffrement</param>
        /// <returns>Le texte chiffré ou déchiffré</returns>
        public string ActionOnString(bool encrypt, string text, string key)
        {
            // Boucle qui vérifie si le texte doit être chiffré ou déchiffré
            if (encrypt)
            {
                return EncryptString(text, key);
            }
            else
            {
                return DecryptString(text, key);
            }
        }

        /// <summary>
        /// Méthode qui permet de chiffrer un texte
        /// http://curlybrackets.com/posts/43017/how-to-encrypt-and-decrypt-a-string-in-c-sharp
        /// </summary>
        /// <param name="text">Le texte</param>
        /// <param name="key">La clé de chiffrement</param>
        /// <returns>Le texte chiffré</returns>
        private string EncryptString(string text, string key)
        {
            try
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    using (var tdes = new TripleDESCryptoServiceProvider())
                    {
                        tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                        tdes.Mode = CipherMode.ECB;
                        tdes.Padding = PaddingMode.PKCS7;

                        using (var transform = tdes.CreateEncryptor())
                        {
                            byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                            byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                            return Convert.ToBase64String(bytes, 0, bytes.Length);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _error = "Error : " + ex.ToString();
                return null;
            }
        }

        /// <summary>
        /// Méthode qui permet de déchiffrer un texte
        /// http://curlybrackets.com/posts/43017/how-to-encrypt-and-decrypt-a-string-in-c-sharp
        /// </summary>
        /// <param name="cipher">Le texte chiffré</param>
        /// <param name="key">La clé de déchiffrement</param>
        /// <returns>Le texte déchiffré</returns>
        private string DecryptString(string cipher, string key)
        {
            try
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    using (var tdes = new TripleDESCryptoServiceProvider())
                    {
                        tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                        tdes.Mode = CipherMode.ECB;
                        tdes.Padding = PaddingMode.PKCS7;

                        using (var transform = tdes.CreateDecryptor())
                        {
                            byte[] cipherBytes = Convert.FromBase64String(cipher);
                            byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                            return UTF8Encoding.UTF8.GetString(bytes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _error = "Error : " + ex.ToString();
                return null;
            }
        }

        /// <summary>
        /// Méthode qui permet de générer un mot de passe aléatoirement dans des TextBox
        /// </summary>
        /// <param name="cbxRandomPwd">La case à coché</param>
        /// <param name="gbxPassword">Le groupe de TextBox</param>
        public void GenerateRandomPwdInTextBox(CheckBox cbxRandomPwd, GroupBox gbxPassword)
        {
            // Boucle qui vérifie si la case de la génération aléaoire du mot de passe est cochée
            if (cbxRandomPwd.Checked)
            {
                string pwd = GenerateRandomPwd();
                foreach (Control control in gbxPassword.Controls)
                {
                    // Boucle qui vérifie si le contrôleur est un champ texte
                    if (control is TextBox)
                    {
                        TextBox textBox = control as TextBox;
                        if (textBox.Tag != null && textBox.Tag.ToString() == "Password")
                        {
                            textBox.Text = pwd;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Méthode qui permet de définir l'action a effectué sur le fichier XML
        /// </summary>
        /// <param name="key">Le mot de passe</param>
        /// <param name="safe">Le coffre</param>
        public void ActionOnFileContent(string key, Safe safe)
        {
            xmlFile = new XmlFile(key, true);
            ActionOnFile(false, key, "writing", xmlFile.DataFilePath);
            // Boucle qui vérifie si il y a une erreur lors du déchiffrement
            if (_error == null)
            {
                foreach (Entry entry in safe.LstEntry)
                {
                    int noIndex = safe.LstEntry.IndexOf(entry);
                    // Boucle qui vérifie si l'identifiant de l'entrée se trouve dans la liste et que la liste n'est pas vide
                    if (safe.AddedInXmlFile != null && safe.AddedInXmlFile.Contains(noIndex))
                    {
                        xmlFile.InsertDataInFile(noIndex, entry.Name, entry.Password, entry.Username, entry.Url, entry.Date, Convert.ToBoolean(entry.Favorites));
                        safe.AddedInXmlFile.Clear();
                        break;
                    }
                    else if (safe.ModifiedInXmlFile != null && safe.ModifiedInXmlFile.Contains(noIndex))
                    {
                        xmlFile.UpdateDataInXml(noIndex, entry.Name, entry.Password, entry.Username, entry.Url, Convert.ToBoolean(entry.Favorites));
                        // Boucle qui vérifie que le mot de passe de l'application n'a pas été modifié
                        if (key != entry.Password)
                        {
                            key = entry.Password;
                            // Boucle qui vérifie que l'entrée n'est pas celle qui a été crée par défaut
                            if (noIndex == 0)
                            {
                                ActionOnFile(false, _stringEncryptPwd, "writing", xmlFile.ForgottenpwdFilePath);
                                xmlFile.UpdatePassword(key, xmlFile.LstAnswer);
                            }
                        }
                        safe.ModifiedInXmlFile.Clear();
                        break;
                    }
                    else if (safe.DeletedInXmlFile != null && safe.DeletedInXmlFile.Contains(noIndex))
                    {
                        DeleteDataInXmlFile(noIndex);
                        safe.LstEntry.RemoveAt(noIndex);
                        safe.DeletedInXmlFile.Clear();
                        break;
                    }
                }
                ActionOnFile(true, key, "writing", xmlFile.DataFilePath);
            }
        }

        /// <summary>
        /// Méthode qui permet de supprimer un fichier
        /// </summary>
        /// <param name="file">Le fichier rechercher</param>
        private void IfCopyExist(string file)
        {
            // Boucle qui vérifie que le fichier existe
            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        /// <summary>
        /// Méthode qui permet de supprimer les données dans le fichier XML
        /// </summary>
        /// <param name="index">L'idetifiant de l'entrée</param>
        public void DeleteDataInXmlFile(int index)
        {
            XDocument xDocument;
            xDocument = XDocument.Load(xmlFile.DataFilePath);
            foreach (XElement parent in xDocument.Root.Elements("id"))
            {
                // Boucle qui cherche l'entrée selon l'identifiant
                if ((int)parent.Attribute("no") == index)
                {
                    parent.Remove();
                }
            }
            xDocument.Save(xmlFile.DataFilePath);
        }
    }
}