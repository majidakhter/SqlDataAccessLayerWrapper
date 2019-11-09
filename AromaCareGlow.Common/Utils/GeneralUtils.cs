using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

using AromaCareGlow.Common.Constants;
using System.Reflection;
using System.ComponentModel;


namespace AromaCareGlow.Common.Utils
{
    public static class GeneralUtils
    {
        /// <summary>
        /// Function to generate binary equivalent array of given integer value
        /// </summary>
        /// <param name="integerValue">input integer value</param>
        /// <returns>Returns array object which contains binary value in each item</returns>
        public static char[] ConvertToBinary(int integerValue)
        {
            string binEqv = Convert.ToString(integerValue, 2);
            binEqv = binEqv.PadLeft(6, FMSConstant.VALUE_ZERO);
            char[] value = binEqv.ToCharArray();
            Array.Reverse(value);

            return value.Where((v, index) => index > 0).ToArray();
        }

        public static String GetDisplayText(this Enum enumValue)
        {
            var type = enumValue.GetType();
            MemberInfo[] memberInfo = type.GetMember(enumValue.ToString());

            if (memberInfo == null || memberInfo.Length == 0)
                return enumValue.ToString();

            object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes == null || attributes.Length == 0)
                return enumValue.ToString();

            return ((DescriptionAttribute)attributes[0]).Description;
        }

        public static string ReadClientUrlFromXML(string filepath, string xpath)
        {
            FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            XmlDocument doc = new XmlDocument();

            //load the stream into an XML Document

            doc.Load(stream);

            stream.Close();

            //variable to hold the value

            string returnValue = string.Empty;

            //get all the elements for the specified tag

            XmlNodeList nodeList = doc.SelectNodes(xpath);
            //loop through the document
            for (int i = nodeList.Count - 1; i >= 0; i--)
            {
                returnValue = nodeList[i].Attributes["Text"].Value;
            }

            return returnValue;
        }

        /// <summary>
        /// Validates the date format
        /// </summary>
        /// <param name="date"></param>
        /// <param name="sdate"></param>
        /// <returns></returns>
        public static bool IsValidDate(this DateTime date, string sdate)
        {
            try
            {
                DateTime.Parse(sdate);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}