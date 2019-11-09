////------------------------------------------------------------------------------ 
//// <copyright file="ExportCSV.cs" company="AromaCareGlow LLP">
////     Copyright (c) AromaCareGlow LLP.  All rights reserved.
//// </copyright>
////------------------------------------------------------------------------------ 
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Net;
//using System.Net.Mail;
//using System.Text;
//using System.IO;
////using System.Windows.Forms;

//using AromaCareGlow.Common.Constants.Application;

//namespace GlobalTranz.Common.Utils
//{
//    /// <summary>
//    ///     A class for using Export CSV for DataGridView. 
//    ///     
//    ///     Created By : Majid Akhter       Created Date : 11/14/2019	
//    ///     Modified By : Name              Modified Date : mm/dd/yyyy
//    ///     ----------------------------------------------------------
//    ///     Change Comment
//    ///     ----------------------------------------------------------
//    /// </summary>
//    public static class ExportCSV
//    {
//        #region Private Members
//        #endregion

//        #region Constructors
//        #endregion

//        #region Public Members

//        /// <summary>
//        ///     Export the csv file for Data grid view
//        /// </summary>
//        /// <param name="dgvForCSV">Data grid view instance</param>
//        /// <param name="fileName">CSV file Name</param>
//        public static void ExportCSVFile(DataGridView dgvForCSV, string fileName, ArrayList hideColumns)
//        {
//            StringBuilder outputStringbuilder = new StringBuilder();

//            // Export titles: 
//            StringBuilder headerStringBuilder = new StringBuilder();

//            for (int index = 0; index < dgvForCSV.Columns.Count; index++)
//            {
//                if (!hideColumns.Contains(index))
//                {
//                    headerStringBuilder.Append(Convert.ToString(dgvForCSV.Columns[index].HeaderText));
//                    headerStringBuilder.Append(",");
//                }
//            }

//            outputStringbuilder.Append(headerStringBuilder + "\r\n");

//            // Export data. 
//            for (int indexRow = 0; indexRow < dgvForCSV.RowCount; indexRow++)
//            {
//                StringBuilder rowStringBuilder = new StringBuilder();

//                for (int indexColumn = 0; indexColumn < dgvForCSV.Rows[indexRow].Cells.Count; indexColumn++)
//                {
//                    if (!hideColumns.Contains(indexColumn))
//                    {
//                        rowStringBuilder.Append(Convert.ToString(dgvForCSV.Rows[indexRow].Cells[indexColumn].Value));
//                        rowStringBuilder.Append(",");
//                    }
//                }

//                outputStringbuilder.Append(rowStringBuilder + "\r\n");
//            }

//            UTF8Encoding utf8 = new UTF8Encoding();
//            byte[] outputByte = utf8.GetBytes(outputStringbuilder.ToString());

//            FileStream fileStream = new FileStream(ConfigurationManager.AppSettings["CSVFilePath"] + fileName + ".csv", FileMode.Create);
//            BinaryWriter binaryWriter = new BinaryWriter(fileStream);

//            // write the encoded file
//            binaryWriter.Write(outputByte, 0, outputByte.Length);

//            binaryWriter.Flush();
//            binaryWriter.Close();
//            fileStream.Close();
//        }

//        #endregion

//        #region Public Methods
//        #endregion

//        #region Private Methods
//        #endregion
//    }
//}