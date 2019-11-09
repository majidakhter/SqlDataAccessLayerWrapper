//------------------------------------------------------------------------------ 
// <copyright file="PDFConverter.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

using AromaCareGlow.Common.Constants.Application;

namespace AromaCareGlow.Common.Utils
{
    /// <summary>
    ///     A customized class to get Pdf file 
    ///     
    ///     Created By : Majid Akhter   Created Date : 08/15/2019	
    ///     Modified By : Name            Modified Date : mm/dd/yyyy
    ///     ----------------------------------------------------------
    ///     Change Comment
    ///     ----------------------------------------------------------
    /// </summary>
    public class PDFGenerator
    {
        #region Public Methods

        /// <summary>
        /// Delete file from current folder
        /// </summary>
        /// <param name="strPath">Path of the file</param>
        public void DeleteFile(string strPath)
        {
            if (File.Exists(strPath))
            {
                File.Delete(strPath);

            }
        }

        /// <summary>
        /// Convert Html file to Pdf file
        /// </summary>
        /// <param name="strFilePath">Path of the file</param>
        /// <param name="buffer">Buffer stream</param>
        /// <returns>Pdf file as a stream</returns>
        public Stream ConvertToPdf(string filePath, byte[] buffer)
        {
            // write temp file 
            this.WriteToFile(filePath, buffer);
            Process pdfConvert = new Process();
            pdfConvert.StartInfo.FileName = ConfigurationSettings.AppSettings[ApplicationConstants.PDF_CONVERTER_EXE_FILE_PATH];
            //pdfConvert.StartInfo.Arguments = " --webpage -f \"" +
            pdfConvert.StartInfo.Arguments = "--size A4 --left .50cm --right .50cm --top 0.2in --bottom 0.2in  --webpage -f \"" +
            filePath.Replace(".htm", ".pdf") + "\" \"" + filePath + "\"";
            pdfConvert.Start();

            pdfConvert.WaitForExit();
            if (pdfConvert.ExitCode == ApplicationConstants.COUNT_ZERO)
            {
                Stream streamMail = new MemoryStream(File.ReadAllBytes(filePath.Replace(".htm", ".pdf")));

                // Delete temp html file and pdf file from disk 
                this.DeleteFile(filePath);
                this.DeleteFile(filePath.Replace(ApplicationConstants.HTML_FILE_NAME_EXTENSION, ApplicationConstants.PDF_FILE_NAME_EXTENSION));

                return streamMail;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Convert Html file to Pdf file
        /// </summary>
        /// <param name="strFilePath">Path of the file</param>
        /// <returns>Pdf file as a stream</returns>
        public Stream ConvertToPdf(string filePath)
        {
            Process pdfConvert = new Process();
            pdfConvert.StartInfo.FileName = ConfigurationSettings.AppSettings[ApplicationConstants.PDF_CONVERTER_EXE_FILE_PATH];
            pdfConvert.StartInfo.Arguments = "--size A4 --left .25cm --top 0.2in --bottom 0.2in  --webpage -f \"" +
            filePath.Replace(".htm", ".pdf") + "\" \"" + filePath + "\"";
            pdfConvert.Start();
            pdfConvert.WaitForExit();
            if (pdfConvert.ExitCode == ApplicationConstants.COUNT_ZERO)
            {
                Stream streamMail = new MemoryStream(File.ReadAllBytes(filePath.Replace(".htm", ".pdf")));

                // Delete temp html file and pdf file from disk 
                this.DeleteFile(filePath);
                //this.DeleteFile(filePath.Replace(ApplicationConstants.HTML_FILE_NAME_EXTENSION, ApplicationConstants.PDF_FILE_NAME_EXTENSION));

                return streamMail;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Convert Html file to Pdf file
        /// </summary>
        /// <param name="strFilePath">Path of the file</param>
        /// <param name="buffer">Buffer stream</param>
        /// <returns>Returns 'true' if converted successfully, else returns 'false'</returns>
        public bool ConvertFile(string filePath, byte[] buffer)
        {
            // write temp file 
            this.WriteToFile(filePath, buffer);
            Process pdfConvert = new Process();
            pdfConvert.StartInfo.FileName = ConfigurationSettings.AppSettings[ApplicationConstants.PDF_CONVERTER_EXE_FILE_PATH];
            pdfConvert.StartInfo.Arguments = " --webpage -f \"" +
            filePath.Replace(".htm", ".pdf") + "\" \"" + filePath + "\"";
            pdfConvert.Start();
            pdfConvert.WaitForExit();
            if (pdfConvert.ExitCode == ApplicationConstants.COUNT_ZERO)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Writes file to current folder
        /// </summary>
        /// <param name="strPath">Path of the file</param>
        /// <param name="buffer">Buffer stream</param>
        private void WriteToFile(string strPath, byte[] buffer)
        {
            // Create a file
            //strPath = strPath.Replace(".htm", ".pdf");
            FileStream newFile = new FileStream(strPath, FileMode.Create);

            // Write data to the file
            newFile.Write(buffer, 0, buffer.Length);

            // Close file
            newFile.Close();
        }

        #endregion
    }
}