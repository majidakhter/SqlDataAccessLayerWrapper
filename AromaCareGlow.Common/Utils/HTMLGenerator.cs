//------------------------------------------------------------------------------ 
// <copyright file="HTMLGenerator.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace AromaCareGlow.Common.Utils
{
    /// <summary>
    ///     A customized class to generate html content as a Stream from xslt
    ///     
    ///     Created By : Majid Akhter   Created Date : 08/27/2019	
    ///     Modified By : Name            Modified Date : mm/dd/yyyy
    ///     ----------------------------------------------------------
    ///     Change Comment
    ///     ----------------------------------------------------------
    /// </summary>
    public class HTMLGenerator
    {
        #region Public Members

        /// <summary>
        /// This Method Generate Html File content as a Stream based on Xml Document and Xlst file
        /// </summary>
        /// <param name="xmlDocument">Xml Document</param>
        /// <param name="xlstFilePath">Xlst File Path</param>
        /// <param name="xsltArgumentsDictionary">Xslt Arguments as a Dictionary</param>
        /// <returns>stream object</returns>
        public static Stream GenerateHtmlFile(XmlDocument xmlDocument, string xlstFilePath, Dictionary<string, string> xsltArgumentsDictionary)
        {
            MemoryStream mstream = new MemoryStream();
            StreamWriter swriter = new StreamWriter(mstream);

            XslCompiledTransform xslTransform = new XslCompiledTransform();
            xslTransform.Load(xlstFilePath);
            XsltArgumentList xsltArgumentList = null;

            if (xsltArgumentsDictionary != null)
            {
                xsltArgumentList = new XsltArgumentList();
                foreach (KeyValuePair<string, string> item in xsltArgumentsDictionary)
                {
                    xsltArgumentList.AddParam(item.Key, string.Empty, item.Value);
                }
            }

            xslTransform.Transform(xmlDocument, xsltArgumentList, mstream);
            mstream.Seek(0, SeekOrigin.Begin);
            return mstream;
        }

        /// <summary>
        /// This Method Generate Html File content as a Stream based on Xml Document and Xlst file
        /// </summary>
        /// <param name="xmlData">Data in XML format</param>
        /// <param name="xlstFilePath">Xlst File Path</param>
        /// <param name="xsltArgumentsDictionary">Xslt Arguments as a Dictionary</param>
        /// <returns>stream object</returns>
        public static Stream GenerateHtmlFile(string xmlData, string xlstFilePath, Dictionary<string, string> xsltArgumentsDictionary)
        {
            // Remove any namesapce if it is present
            int startPosition = xmlData.IndexOf("xmlns", 0);
            int endPosition = xmlData.IndexOf(".xsd", 0) + 5;
            string changedXmlFile = xmlData.Remove(startPosition, endPosition - startPosition);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(changedXmlFile);

            MemoryStream mstream = new MemoryStream();
            StreamWriter swriter = new StreamWriter(mstream);

            XslCompiledTransform xslTransform = new XslCompiledTransform();
            xslTransform.Load(xlstFilePath);

            XsltArgumentList xsltArgumentList = null;
            if (xsltArgumentsDictionary != null)
            {
                xsltArgumentList = new XsltArgumentList();
                foreach (KeyValuePair<string, string> item in xsltArgumentsDictionary)
                {
                    xsltArgumentList.AddParam(item.Key, string.Empty, item.Value);
                }
            }

            xslTransform.Transform(xmlDoc, xsltArgumentList, mstream);
            mstream.Seek(0, SeekOrigin.Begin);

            return mstream;
        }

        /// <summary>
        /// This Method Generate Html File content as a Stream based on Xml Document and Xlst file
        /// </summary>
        /// <param name="xmlData">Data in XML format</param>
        /// <param name="xlstFilePath">Xlst File Path</param>
        /// <param name="xsltArgumentsDictionary">Xslt Arguments as a Dictionary</param>
        /// <returns>stream object</returns>
        public static String GenerateStringFile(string xmlData, string xlstFilePath, Dictionary<string, string> xsltArgumentsDictionary)
        {
            // Remove any namesapce if it is present
            // int startPosition = xmlData.IndexOf("xmlns", 0);
            // int endPosition = xmlData.IndexOf(".xsd", 0) + 5;
            // string changedXmlFile = xmlData.Remove(startPosition, endPosition - startPosition);
            string changedXmlFile = xmlData.Replace("xmlns:asp=\"remove\"", "");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(changedXmlFile);

            MemoryStream mstream = new MemoryStream();
            StreamWriter swriter = new StreamWriter(mstream);

            XslCompiledTransform xslTransform = new XslCompiledTransform();
            xslTransform.Load(xlstFilePath);

            XsltArgumentList xsltArgumentList = null;
            if (xsltArgumentsDictionary != null)
            {
                xsltArgumentList = new XsltArgumentList();
                foreach (KeyValuePair<string, string> item in xsltArgumentsDictionary)
                {
                    xsltArgumentList.AddParam(item.Key, string.Empty, item.Value);
                }
            }

            xslTransform.Transform(xmlDoc, xsltArgumentList, mstream);
            mstream.Seek(0, SeekOrigin.Begin);

            StreamReader reader = new StreamReader(mstream);
            return reader.ReadToEnd();
        }

        /// <summary>
        ///     This Method Generate Html File content as a Stream based on Xlst file
        /// </summary>
        /// <param name="xlstFilePath">Xlst File Path</param>
        /// <param name="xsltArgumentsDictionary">Xslt Arguments as a Dictionary</param>
        /// <returns>stream object</returns>
        public static Stream GenerateHtmlFile(string xlstFilePath, Dictionary<string, string> xsltArgumentsDictionary)
        {
            XmlDocument xmlDoc = new XmlDocument();

            MemoryStream mstream = new MemoryStream();
            StreamWriter swriter = new StreamWriter(mstream);

            XslCompiledTransform xslTransform = new XslCompiledTransform();
            xslTransform.Load(xlstFilePath);

            XsltArgumentList xsltArgumentList = null;
            if (xsltArgumentsDictionary != null)
            {
                xsltArgumentList = new XsltArgumentList();
                foreach (KeyValuePair<string, string> item in xsltArgumentsDictionary)
                {
                    xsltArgumentList.AddParam(item.Key, string.Empty, item.Value);
                }
            }

            xslTransform.Transform(xmlDoc, xsltArgumentList, mstream);
            mstream.Seek(0, SeekOrigin.Begin);
            return mstream;
        }
        #endregion
    }
}