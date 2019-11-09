using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Xml;

namespace AromaCareGlow.Common.Utils
{
    /// <summary>
    /// 
    ///     This is class is for encryption and decryption of a string.
    ///     
    ///     Created By : Majid Akhter.          Create Date : 03/Aug/2019     
    ///     Modified By:                       Modified Date : 
    ///     ----------------------------------------------------------
    ///     
    /// </summary>
    public class EncryptAndDecrypt
    {
        /// <summary>
        ///     This method is to encrypt a string
        ///     It uses Rijindael symmetric encryption Algorithm
        /// </summary>
        /// <param name="textToBeEncrypted">string to be encrypted</param>
        /// <returns>encryptedData</returns>
        public string Encrypt(string textToBeEncrypted)
        {
            RijndaelManaged rijindael = new RijndaelManaged();
            string password = "CSC";

            // get the byte array of the string to be encrypted
            byte[] plainText = System.Text.Encoding.Unicode.GetBytes(textToBeEncrypted);
            // get the byte array of the length string to be encrypted
            byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());

            // to derive a key from the password using PBKDF1 algorithm
            PasswordDeriveBytes secretKey = new PasswordDeriveBytes(password, salt);

            // get the encryption for the string
            ICryptoTransform encryptor = rijindael.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            // store the encryption in memory stream object
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainText, 0, plainText.Length);
            // update and clear the buffer      
            cryptoStream.FlushFinalBlock();
            // get byte array from memorystream
            byte[] cipherBytes = memoryStream.ToArray();
            // close the memorystream
            memoryStream.Close();
            // close the crypto stream
            cryptoStream.Close();
            // get the string representetation of encrypted string and return the same
            string encryptedData = Convert.ToBase64String(cipherBytes);
            return encryptedData;
        }

        /// <summary>
        ///     This method is to decrypt the encrypted data.
        ///     It uses Rijindael symmetric decryption Algorithm
        /// </summary>
        /// <param name="toBeDecrypted">encrypted string</param>
        /// <returns>decryptedData (string)</returns>
        public string Decrypt(string toBeDecrypted)
        {
            RijndaelManaged rijandeal = new RijndaelManaged();
            string password = "CSC";
            string decryptedData;
            try
            {
                // get the byte array for the encrypted string
                byte[] encryptedData = Convert.FromBase64String(toBeDecrypted);
                byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());

                // to derive a key from the password using PBKDF1 algorithm
                PasswordDeriveBytes secretKeys = new PasswordDeriveBytes(password, salt);
                // get the decryption for the string
                ICryptoTransform decryptor = rijandeal.CreateDecryptor(secretKeys.GetBytes(32), secretKeys.GetBytes(16));
                // load string encrypted data into memory stream
                MemoryStream memoryStream = new MemoryStream(encryptedData);
                // read the encryption in memory stream object
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainText = new byte[encryptedData.Length];
                int decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
                // close the memory stream
                memoryStream.Close();
                // close the crypto stream
                cryptoStream.Close();
                // get the decrypted string
                decryptedData = Encoding.Unicode.GetString(plainText, 0, decryptedCount);
            }
            catch
            {
                // if any exception store encrypted format only
                decryptedData = toBeDecrypted;
            }
            // return the string decrypted
            return decryptedData;
        }
    }
}