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

namespace NotePass.Model
{
    class Security
    {
        //Permet de supprimer la clé de la mémoire après utilisation
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        static byte[] salt;
        private string _error;
        private XmlFile xmlFile;

        public string Error { get => _error; set => _error = value; }

        /// <summary>
        /// Constructeur principal de la classe Securtiy
        /// </summary>
        public Security(XmlFile file)
        {
            xmlFile = file;
            salt = GenerateRandomSalt();
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
        /// <param name="encrypt">Indique que le fichier doit être chiffrer ou non</param>
        /// <param name="password">Le mot de passe utilisateur</param>
        /// <param name="inProgress">L'action en cours</param>
        public void ActionOnFile(bool encrypt, string password, string inProgress)
        {
            // Epingle le mot de passe
            GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

            // Boucle qui vérifie si le fichier doit être chiffré ou déchiffré
            if (encrypt)
            {
                FileEncrypt(xmlFile.FilePath, password);
                xmlFile.IfCopyExist(xmlFile.FilePath);
            }
            else
            {
                string filePathAES = xmlFile.FilePath + ".aes";
                FileDecrypt(filePathAES, xmlFile.FilePath, password);
                if (_error == null)
                {
                    xmlFile.IfCopyExist(filePathAES);
                }
                else
                {
                    xmlFile.IfCopyExist(xmlFile.FilePath);
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
        /// Méthode qu permet de chiffrer un fichier
        /// https://ourcodeworld.com/articles/read/471/how-to-encrypt-and-decrypt-files-using-the-aes-encryption-algorithm-in-c-sharp
        /// </summary>
        /// <param name="inputFile"> Le chemin du fichier à chiffrer </param>
        /// <param name="password"> Le mot de passe de l'utilisateur </param>
        private void FileEncrypt(string inputFile, string password)
        {
            // http://stackoverflow.com/questions/27645527/aes-encryption-on-large-files

            using (FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create))
            {

                // Générer un sel aléatoire
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Définir l'algorithme de chiffrement symétrique Rijndael
                RijndaelManaged AES = new RijndaelManaged();
                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Padding = PaddingMode.PKCS7;

                // http://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly
                // Hash à plusieurs reprises le mot de passe de l'utilisateur avec le sel. Nombre d'itérations élevé.
                var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                // Cipher modes: http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption
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

                // http://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly
                // Hash à plusieurs reprises le mot de passe de l'utilisateur avec le sel. Nombre d'itérations élevé.
                var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                // Cipher modes: http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption
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
        // M.Shcmidan question sur generation de mot de passe
        //https://stackoverflow.com/questions/108819/best-way-to-randomize-an-array-with-net
        public string GenerateRandomPwd()
        {
            string characters = "abcdefghijklmnopqrstuvwxyz";
            string capCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string specialChar = "~`!@#$%^&*()_-+={[}]|\\:;\"'<,>.?/";
            Random rnd = new Random();
            string GeneratePwd = "";
            for (int i = 0; i < 11; i++)
            {
                if(i == 0)
                {
                    GeneratePwd += capCharacters[rnd.Next(0, capCharacters.Length)];
                }
                else if (i % 2 == 0)
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
            return GeneratePwd;
        }
    }
}