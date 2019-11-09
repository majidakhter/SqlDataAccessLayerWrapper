////------------------------------------------------------------------------------ 
//// <copyright file="GTMessageBox.cs" company="AromaCareGlow LLP">
////     Copyright (c) AromaCareGlow LLP.  All rights reserved.
//// </copyright>
////------------------------------------------------------------------------------ 
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows.Forms;

//namespace GlobalTranz.Common.Utils
//{
//    /// <summary>
//    ///     Types of messages shown on GT application.
//    /// </summary>
//    public enum GTMessageTypes
//    {
//        /// <summary>
//        ///     Message is related with error.
//        /// </summary>
//        Error,

//        /// <summary>
//        ///     Message is infomational message.
//        /// </summary>
//        Information,

//        /// <summary>
//        ///     Message is question to user.
//        /// </summary>
//        Question
//    }

//    /// <summary>
//    ///     A customized class to show messages for user notification. 
//    ///     Needs change in implementation here if new message type introduced.
//    ///     
//    ///     Created By : Amit verma       Created Date : 07/31/2008	
//    ///     Modified By : Name            Modified Date : mm/dd/yyyy
//    ///     ----------------------------------------------------------
//    ///     Change Comment
//    ///     ----------------------------------------------------------
//    /// </summary>
//    public static class GTMessageBox
//    {
//        #region Private Members
//        /// <summary>
//        ///     Message box title
//        /// </summary>
//        public const string MESSAGE_BOX_TITLE = "GlobalTranz Enterprise";
//        #endregion

//        #region Constructors
//        #endregion

//        #region Public Members
//        #endregion

//        #region Public Methods
//        /// <summary>
//        ///     Method to show messages.
//        /// </summary>
//        /// <param name="message">message string</param>
//        /// <param name="buttonType">buttons to put on message box</param>
//        /// <param name="messageType">message types (Error/Information/Question)</param>
//        public static DialogResult Show(string message, MessageBoxButtons buttonType, GTMessageTypes messageType)
//        {
//            DialogResult userAction = DialogResult.Cancel;
//            switch (messageType)
//            {
//                case GTMessageTypes.Error:
//                    userAction = MessageBox.Show(message, MESSAGE_BOX_TITLE, buttonType, MessageBoxIcon.Error);
//                    break;
//                case GTMessageTypes.Information:
//                    userAction = MessageBox.Show(message, MESSAGE_BOX_TITLE, buttonType, MessageBoxIcon.Information);
//                    break;
//                case GTMessageTypes.Question:
//                    userAction = MessageBox.Show(message, MESSAGE_BOX_TITLE, buttonType, MessageBoxIcon.Question);
//                    break;
//            }

//            return userAction;
//        }
//        #endregion

//        #region Private Methods
//        #endregion
//    }


//}