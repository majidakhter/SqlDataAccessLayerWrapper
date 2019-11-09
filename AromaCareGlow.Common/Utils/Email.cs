//------------------------------------------------------------------------------ 
// <copyright file="Email.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

using AromaCareGlow.Common.Constants.Application;

namespace AromaCareGlow.Common.Utils
{
    /// <summary>
    ///     A class for sending quote details as an email. 
    ///     
    ///     Created By : Majid Akhter       Created Date : 08/13/2019	
    ///     Modified By : Majid Akhter            Modified Date : 26/Nov/2019
    ///     ----------------------------------------------------------
    ///     Change Comment
    ///     ----------------------------------------------------------
    /// </summary>
    public static class Email
    {
        #region Private Members
        #endregion

        #region Constructors

        #endregion

        #region Public Members

        /// <summary>
        ///  Send mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        /// <param name="attachments">Attachment files</param>
        public static void SendMailMessage(string fromAddress, string subject, string body, ArrayList recepientAddress, Attachment[] attachments)
        {
            SendMailMessage(fromAddress, null, subject, body, recepientAddress, attachments);
        }

        /// <summary>
        ///  Send mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        /// <param name="attachments">Attachment files</param>
        public static void SendMailMessage(string fromAddress, string subject, string body, ArrayList recepientAddress, Attachment[] attachments, bool isbodyhtml)
        {
            SendMailMessage(fromAddress, null, subject, body, recepientAddress, attachments, isbodyhtml);
        }

        /// <summary>
        ///  Send mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        /// <param name="attachments">Attachment files</param>
        public static void SendMailMessage(string fromAddress, string replyAddress, string subject, string body, ArrayList recepientAddress, Attachment[] attachments)
        {
            if (attachments == null)
            {
                // Send email without attachments.
                SendMailMessage(fromAddress, replyAddress, subject, body, recepientAddress);
            }
            else
            {
                // Instantiate a new instance of MailMessage
                MailMessage emailMessage = new MailMessage();

                // Set the sender address of the mail message
                emailMessage.From = new MailAddress(fromAddress);
                if (!string.IsNullOrEmpty(replyAddress))
                {
                    emailMessage.ReplyTo = new MailAddress(replyAddress);
                }

                // loop through the recepient addresses.
                foreach (string toAddress in recepientAddress)
                {
                    emailMessage.To.Add(new MailAddress(toAddress));
                }

                // Set the subject of the mail message
                emailMessage.Subject = subject;

                // Set the body of the mail message
                emailMessage.Body = body;

                // Attachements
                foreach (Attachment attachment in attachments)
                {
                    // This line modifed by Suneel Eduru on 26-Nov-2008.
                    if (attachment != null)
                    {
                        emailMessage.Attachments.Add(attachment);
                    }
                }

                // Set the format of the mail message body as HTML
                emailMessage.IsBodyHtml = true;

                // Set the priority of the mail message to normal
                emailMessage.Priority = MailPriority.Normal;

                // Instantiate a new instance of SmtpClient
                SmtpClient mailSmtpClient = new SmtpClient();
                mailSmtpClient.Host = ConfigurationManager.AppSettings[ApplicationConstants.SMTP_HOST].ToString();

                mailSmtpClient.Port = 25;

                // To send mails using IIS hosted SMTP server
                mailSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                mailSmtpClient.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings[ApplicationConstants.MAIL_ID_FOR_NETWORK_CREDENTIALS],
                    ConfigurationManager.AppSettings[ApplicationConstants.MAIL_PWD_FOR_NETWORK_CREDENTIALS]);

                try
                {
                    // Send the mail message
                    mailSmtpClient.Send(emailMessage);
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    //GTMessageBox.Show(ex.Message, System.Windows.Forms.MessageBoxButtons.OK, GTMessageTypes.Information);
                }
            }
        }

        /// <summary>
        ///  Send mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        /// <param name="attachments">Attachment files</param>
        public static void SendMailMessage(string fromAddress, string replyAddress, string subject, string body, ArrayList recepientAddress, Attachment[] attachments, bool isbodyhtml)
        {
            if (attachments == null)
            {
                // Send email without attachments.
                SendMailMessage(fromAddress, replyAddress, subject, body, recepientAddress, isbodyhtml);
            }
            else
            {
                // Instantiate a new instance of MailMessage
                MailMessage emailMessage = new MailMessage();

                // Set the sender address of the mail message
                emailMessage.From = new MailAddress(fromAddress);
                if (!string.IsNullOrEmpty(replyAddress))
                {
                    emailMessage.ReplyTo = new MailAddress(replyAddress);
                }

                // loop through the recepient addresses.
                foreach (string toAddress in recepientAddress)
                {
                    emailMessage.To.Add(new MailAddress(toAddress));
                }

                // Set the subject of the mail message
                emailMessage.Subject = subject;

                // Set the body of the mail message
                emailMessage.Body = body;

                // Attachements
                foreach (Attachment attachment in attachments)
                {
                    // This line modifed by Suneel Eduru on 26-Nov-2008.
                    if (attachment != null)
                    {
                        emailMessage.Attachments.Add(attachment);
                    }
                }

                // Set the format of the mail message body as HTML
                emailMessage.IsBodyHtml = isbodyhtml;

                // Set the priority of the mail message to normal
                emailMessage.Priority = MailPriority.Normal;

                // Instantiate a new instance of SmtpClient
                SmtpClient mailSmtpClient = new SmtpClient();
                mailSmtpClient.Host = ConfigurationManager.AppSettings[ApplicationConstants.SMTP_HOST].ToString();

                mailSmtpClient.Port = 25;

                // To send mails using IIS hosted SMTP server
                mailSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                mailSmtpClient.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings[ApplicationConstants.MAIL_ID_FOR_NETWORK_CREDENTIALS],
                    ConfigurationManager.AppSettings[ApplicationConstants.MAIL_PWD_FOR_NETWORK_CREDENTIALS]);

                try
                {
                    // Send the mail message
                    mailSmtpClient.Send(emailMessage);
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    //GTMessageBox.Show(ex.Message, System.Windows.Forms.MessageBoxButtons.OK, GTMessageTypes.Information);
                }
            }
        }

        /// <summary>
        ///  Send mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        private static void SendMailMessage(string fromAddress, string subject, string body, ArrayList recepientAddress)
        {
            SendMailMessage(fromAddress, null, subject, body, recepientAddress);
        }

        /// <summary>
        ///  Send mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        private static void SendMailMessage(string fromAddress, string replyAddress, string subject, string body, ArrayList recepientAddress)
        {
            // Instantiate a new instance of MailMessage
            MailMessage emailMessage = new MailMessage();

            // Set the sender address of the mail message
            emailMessage.From = new MailAddress(fromAddress);
            if (!string.IsNullOrEmpty(replyAddress))
            {
                emailMessage.ReplyTo = new MailAddress(replyAddress);
            }

            // loop through the recepient addresses.
            foreach (string toAddress in recepientAddress)
            {
                emailMessage.To.Add(new MailAddress(toAddress));
            }

            // Set the subject of the mail message
            emailMessage.Subject = subject;

            // Set the body of the mail message
            emailMessage.Body = body;

            // Set the format of the mail message body as HTML
            emailMessage.IsBodyHtml = true;

            // Set the priority of the mail message to normal
            emailMessage.Priority = MailPriority.Normal;

            // Instantiate a new instance of SmtpClient
            SmtpClient mailSmtpClient = new SmtpClient();
            mailSmtpClient.Host = ConfigurationManager.AppSettings[ApplicationConstants.SMTP_HOST].ToString();

            mailSmtpClient.Port = 25;

            // To send mails using IIS hosted SMTP server
            mailSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            // To Do's: Remove the hard coded values.
            mailSmtpClient.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings[ApplicationConstants.MAIL_ID_FOR_NETWORK_CREDENTIALS],
                ConfigurationManager.AppSettings[ApplicationConstants.MAIL_PWD_FOR_NETWORK_CREDENTIALS]);

            try
            {
                // Send the mail message
                mailSmtpClient.Send(emailMessage);
            }
            catch (SmtpFailedRecipientsException ex)
            {
                //GTMessageBox.Show(ex.Message, System.Windows.Forms.MessageBoxButtons.OK, GTMessageTypes.Information);
            }
        }

        /// <summary>
        ///  Send mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        private static void SendMailMessage(string fromAddress, string replyAddress, string subject, string body, ArrayList recepientAddress, bool isbodyhtml)
        {
            // Instantiate a new instance of MailMessage
            MailMessage emailMessage = new MailMessage();

            // Set the sender address of the mail message
            emailMessage.From = new MailAddress(fromAddress);
            if (!string.IsNullOrEmpty(replyAddress))
            {
                emailMessage.ReplyTo = new MailAddress(replyAddress);
            }

            // loop through the recepient addresses.
            foreach (string toAddress in recepientAddress)
            {
                emailMessage.To.Add(new MailAddress(toAddress));
            }

            // Set the subject of the mail message
            emailMessage.Subject = subject;

            // Set the body of the mail message
            emailMessage.Body = body;

            // Set the format of the mail message body as HTML
            emailMessage.IsBodyHtml = isbodyhtml;

            // Set the priority of the mail message to normal
            emailMessage.Priority = MailPriority.Normal;

            // Instantiate a new instance of SmtpClient
            SmtpClient mailSmtpClient = new SmtpClient();
            mailSmtpClient.Host = ConfigurationManager.AppSettings[ApplicationConstants.SMTP_HOST].ToString();

            mailSmtpClient.Port = 25;

            // To send mails using IIS hosted SMTP server
            mailSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            // To Do's: Remove the hard coded values.
            mailSmtpClient.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings[ApplicationConstants.MAIL_ID_FOR_NETWORK_CREDENTIALS],
                ConfigurationManager.AppSettings[ApplicationConstants.MAIL_PWD_FOR_NETWORK_CREDENTIALS]);

            try
            {
                // Send the mail message
                mailSmtpClient.Send(emailMessage);
            }
            catch (SmtpFailedRecipientsException ex)
            {
                //GTMessageBox.Show(ex.Message, System.Windows.Forms.MessageBoxButtons.OK, GTMessageTypes.Information);
            }
        }

        public static void SendAsynMailMessage(string fromAddress, string subject, string body, ArrayList recepientAddress, Attachment[] attachments)
        {
            SendAsynMailMessage(fromAddress, string.Empty, subject, body, recepientAddress, attachments);
        }

        /// <summary>
        ///  Send asyncronous mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        /// <param name="attachments">Attachment files</param>
        public static void SendAsynMailMessage(string fromAddress, string replyAddress, string subject, string body, ArrayList recepientAddress, Attachment[] attachments)
        {
            if (attachments == null)
            {
                // Send email without attachments.
                SendAsynMailMessage(fromAddress, replyAddress, subject, body, recepientAddress);
            }
            else
            {
                // Instantiate a new instance of MailMessage
                MailMessage emailMessage = new MailMessage();

                // Set the sender address of the mail message
                emailMessage.From = new MailAddress(fromAddress);
                if (!string.IsNullOrEmpty(replyAddress))
                {
                    emailMessage.ReplyTo = new MailAddress(replyAddress);
                }

                // loop through the recepient addresses.
                foreach (string toAddress in recepientAddress)
                {
                    emailMessage.To.Add(new MailAddress(toAddress));
                }

                // Set the subject of the mail message
                emailMessage.Subject = subject;

                // Set the body of the mail message
                emailMessage.Body = body;

                // Attachements
                foreach (Attachment attachment in attachments)
                {
                    // This line modifed by Suneel Eduru on 26-Nov-2008.
                    if (attachment != null)
                    {
                        emailMessage.Attachments.Add(attachment);
                    }
                }

                // Set the format of the mail message body as HTML
                emailMessage.IsBodyHtml = true;

                // Set the priority of the mail message to normal
                emailMessage.Priority = MailPriority.Normal;

                // Instantiate a new instance of SmtpClient
                SmtpClient mailSmtpClient = new SmtpClient();
                mailSmtpClient.Host = ConfigurationManager.AppSettings[ApplicationConstants.SMTP_HOST].ToString();

                mailSmtpClient.Port = 25;

                // To send mails using IIS hosted SMTP server
                mailSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                mailSmtpClient.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings[ApplicationConstants.MAIL_ID_FOR_NETWORK_CREDENTIALS],
                    ConfigurationManager.AppSettings[ApplicationConstants.MAIL_PWD_FOR_NETWORK_CREDENTIALS]);

                try
                {
                    // The userState can be any object that allows your callback 
                    // method to identify this send operation.
                    string userState = "GT mail message";


                    // Send the mail message
                    mailSmtpClient.SendAsync(emailMessage, userState);
                }
                catch (SmtpFailedRecipientsException ex)
                {
                   // GTMessageBox.Show(ex.Message, System.Windows.Forms.MessageBoxButtons.OK, GTMessageTypes.Information);
                }
            }
        }

        /// <summary>
        ///  Send mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        /// <param name="attachments">Attachment files</param>
        public static bool SendWebMailMessage(string fromAddress, string subject, string body, ArrayList recepientAddress, Attachment[] attachments)
        {
            return SendWebMailMessage(fromAddress, null, subject, body, recepientAddress, attachments);
        }

        /// <summary>
        ///  Send mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="replyAddress">Reply address of the mail</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        /// <param name="attachments">Attachment files</param>
        public static bool SendWebMailMessage(string fromAddress, string replyAddress, string subject, string body, ArrayList recepientAddress, Attachment[] attachments)
        {
            if (attachments == null)
            {
                // Send email without attachments.
                SendMailMessage(fromAddress, replyAddress, subject, body, recepientAddress);
            }
            else
            {
                // Instantiate a new instance of MailMessage
                MailMessage emailMessage = new MailMessage();

                // Set the sender address of the mail message
                emailMessage.From = new MailAddress(fromAddress);
                if (!string.IsNullOrEmpty(replyAddress))
                {
                    emailMessage.ReplyTo = new MailAddress(replyAddress);
                }

                // loop through the recepient addresses.
                foreach (string toAddress in recepientAddress)
                {
                    emailMessage.To.Add(new MailAddress(toAddress));
                }

                // Set the subject of the mail message
                emailMessage.Subject = subject;

                // Set the body of the mail message
                emailMessage.Body = body;

                // Attachements
                foreach (Attachment attachment in attachments)
                {
                    // This line modifed by Suneel Eduru on 26-Nov-2008.
                    if (attachment != null)
                    {
                        emailMessage.Attachments.Add(attachment);
                    }
                }

                // Set the format of the mail message body as HTML
                emailMessage.IsBodyHtml = true;

                // Set the priority of the mail message to normal
                emailMessage.Priority = MailPriority.Normal;

                // Instantiate a new instance of SmtpClient
                SmtpClient mailSmtpClient = new SmtpClient();
                mailSmtpClient.Host = ConfigurationManager.AppSettings[ApplicationConstants.SMTP_HOST].ToString();

                mailSmtpClient.Port = 25;

                // To send mails using IIS hosted SMTP server
                mailSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                mailSmtpClient.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings[ApplicationConstants.MAIL_ID_FOR_NETWORK_CREDENTIALS],
                    ConfigurationManager.AppSettings[ApplicationConstants.MAIL_PWD_FOR_NETWORK_CREDENTIALS]);

                try
                {
                    // Send the mail message
                    mailSmtpClient.Send(emailMessage);
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    //                    System.Web.HttpContext.Current.Response.Write("<script>alert('Unable to send Email'" + ex.Message + "Due to " + GTMessageTypes.Information + "')");
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        ///  Send asyncronous mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        private static void SendAsynMailMessage(string fromAddress, string subject, string body, ArrayList recepientAddress)
        {
            SendAsynMailMessage(fromAddress, null, subject, body, recepientAddress);
        }

        /// <summary>
        ///  Send asyncronous mail message
        /// </summary>
        /// <param name="fromAddress">Sender address</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        /// <param name="recepientAddress">Recepient address</param>
        private static void SendAsynMailMessage(string fromAddress, string replyAddress, string subject, string body, ArrayList recepientAddress)
        {
            // Instantiate a new instance of MailMessage
            MailMessage emailMessage = new MailMessage();

            // Set the sender address of the mail message
            emailMessage.From = new MailAddress(fromAddress);
            if (!string.IsNullOrEmpty(replyAddress))
            {
                emailMessage.ReplyTo = new MailAddress(replyAddress);
            }

            // loop through the recepient addresses.
            foreach (string toAddress in recepientAddress)
            {
                emailMessage.To.Add(new MailAddress(toAddress));
            }

            // Set the subject of the mail message
            emailMessage.Subject = subject;

            // Set the body of the mail message
            emailMessage.Body = body;

            // Set the format of the mail message body as HTML
            emailMessage.IsBodyHtml = true;

            // Set the priority of the mail message to normal
            emailMessage.Priority = MailPriority.Normal;

            // Instantiate a new instance of SmtpClient
            SmtpClient mailSmtpClient = new SmtpClient();
            mailSmtpClient.Host = ConfigurationManager.AppSettings[ApplicationConstants.SMTP_HOST].ToString();

            mailSmtpClient.Port = 25;

            // To send mails using IIS hosted SMTP server
            mailSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            // To Do's: Remove the hard coded values.
            mailSmtpClient.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings[ApplicationConstants.MAIL_ID_FOR_NETWORK_CREDENTIALS],
                ConfigurationManager.AppSettings[ApplicationConstants.MAIL_PWD_FOR_NETWORK_CREDENTIALS]);

            try
            {
                // The userState can be any object that allows your callback 
                // method to identify this send operation.
                string userState = "GT mail message";


                // Send the mail message
                mailSmtpClient.SendAsync(emailMessage, userState);
            }
            catch (SmtpFailedRecipientsException ex)
            {
                //GTMessageBox.Show(ex.Message, System.Windows.Forms.MessageBoxButtons.OK, GTMessageTypes.Information);
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}