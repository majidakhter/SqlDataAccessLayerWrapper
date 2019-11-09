//------------------------------------------------------------------------------ 
// <copyright file="SecureString.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace AromaCareGlow.Common.Utils
{
    /// <summary>
    ///     A class for encrypting and decrypting password. 
    ///     
    ///     Created By : Majid Akhter       Created Date : 12/30/2019	
    ///     Modified By :                  Modified Date : 
    ///     ----------------------------------------------------------
    ///     Change Comment
    ///     ----------------------------------------------------------
    /// </summary>
    public class SecureString
    {
        /// <summary>
        ///     Secure key for encryption.
        /// </summary>
        private static string securityKey = "AC";

        /// <summary>
        ///     This method used for encrypting password 
        /// </summary>
        /// <param name="stringToEncrypt">password string</param>
        /// <returns>encrypted password string</returns>
        public static string Encrypt(string stringToEncrypt)
        {
            byte[] keyArray;
            byte[] encryptArray = UTF8Encoding.UTF8.GetBytes(stringToEncrypt);

            // This class used for encrypt secure key
            MD5CryptoServiceProvider cryptoServiceProvideMD5 = new MD5CryptoServiceProvider();
            keyArray = cryptoServiceProvideMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(securityKey));
            cryptoServiceProvideMD5.Clear();

            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = keyArray;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryToTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cryToTransform.TransformFinalBlock(encryptArray, 0, encryptArray.Length);
            tripleDES.Clear();

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        ///     This method used for decrypting password     
        /// </summary>
        /// <param name="stringToDecrypt">encrypted password string</param>
        /// <returns>decrypted password string</returns>
        public static string Decrypt(string stringToDecrypt)
        {
            byte[] keyArray;
            byte[] decryptArray = Convert.FromBase64String(stringToDecrypt);

            // This class used for encrypt secure key
            MD5CryptoServiceProvider cryptoServiceProvideMD5 = new MD5CryptoServiceProvider();
            keyArray = cryptoServiceProvideMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(securityKey));
            cryptoServiceProvideMD5.Clear();

            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = keyArray;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryToTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cryToTransform.TransformFinalBlock(decryptArray, 0, decryptArray.Length);
            tripleDES.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}