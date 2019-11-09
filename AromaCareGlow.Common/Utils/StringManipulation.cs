//------------------------------------------------------------------------------ 
// <copyright file="StringManupulations.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AromaCareGlow.Common.Utils
{

    /// <summary>
    ///     This is used for string manupulations like split, concatinate
    ///     Created By : Majid Akhter    Created Date : 08/18/2019	
    ///     Modified By :                   Modified Date : 
    ///     -------------------------------------------------------------------------------------------
    ///     Change Comment :
    ///     -------------------------------------------------------------------------------------------
    /// </summary>
    public class StringManupulations
    {

        /// <summary>
        /// Method Concatinate 2 strings with the given charector
        /// </summary>
        /// <param name="fristString">fristString</param>
        /// <param name="secondString">secondString</param>
        /// <param name="charector">charector to concatinate between the strings</param>
        /// <returns>Concatinated string</returns>
        public string Concatinate(string fristString, string secondString, char charector)
        {
            return (fristString.Trim() + charector + secondString.Trim());
        }

        /// <summary>
        /// Method to Split the given text with the given charector
        /// </summary>
        /// <param name="text"></param>
        /// <param name="charector"></param>
        /// <returns></returns>
        public string[] SplitStrings(string text, char charector)
        {
            return (text.Trim().Split(charector));
        }

        /// <summary>
        /// Method used to get only digits from the given string.
        /// </summary>
        /// <param name="number">Number as string.</param>
        /// <returns>String contains only digits.</returns>
        public static string GetNumber(string number)
        {
            string phoneNumber = string.Empty;
            if (number != null)
            {
                for (int index = 0; index < number.Length; index++)
                {
                    if (char.IsDigit(number, index))
                    {
                        phoneNumber = phoneNumber + number[index];
                    }
                }
            }
            return phoneNumber;
        }
    }
}