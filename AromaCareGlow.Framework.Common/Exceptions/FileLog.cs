using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Resources;

namespace AromaCareGlow.Framework.Common.Exceptions
{
    public class FileLog
    {
        #region Member Variables

        // Internal log file name value
        private string _fileName = string.Empty;

        // Internal log file location value
        private string _fileLocation = string.Empty;

        #endregion Member Variables

        #region Constants

        private const string FILE_EXTENSION = ".txt";

        // base name of the resource file
        private const string BASE_NAME = "Messages";

        // if log path is not correct, this message is shown
        private const string MSG_BAD_PATH = "LogFolderNotFound";

        // the correct log files path
        private const string CORRECT_PATH = "CorrectPath";


        #endregion

        #region Properties

        /// <summary>
        /// Get or set the log file name
        /// </summary>
        public string FileName
        {
            get
            {
                return this._fileName;
            }
            set
            {
                // Builds file name with extension
                StringBuilder fileName = new StringBuilder();
                fileName.Append(value);
                fileName.Append(FILE_EXTENSION);

                // sets the log file name
                this._fileName = fileName.ToString();
            }
        }

        /// <summary>
        /// Get or set the log file directory location
        /// </summary>
        public string FileLocation
        {
            get
            {
                return _fileLocation;
            }
            set
            {
                _fileLocation = value;

                // retrieves the index position of the last occurrence of slash within  _fileLocation
                int lastSlashPostion = _fileLocation.LastIndexOf("\\");

                // Verify a '\' exists on the end of the location
                if (lastSlashPostion != (_fileLocation.Length - 1))
                {
                    _fileLocation = string.Concat(_fileLocation, "\\");
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Log an exception.
        /// </summary>
        /// <param name="Message">Exception to log. </param>
        /// <param name="Severity">Error severity level. </param>
        public void RecordMessage(Exception message, DBLog.MessageType severity)
        {
            // log message in log file
            this.RecordMessage(message.Message, severity);
            this.RecordMessage(message.StackTrace, severity);
        }

        /// <summary>
        /// Log a message.
        /// </summary>
        /// <param name="Message">Message to log. </param>
        /// <param name="Severity">Error severity level. </param>
        public void RecordMessage(string message, DBLog.MessageType severity)
        {
            FileStream fileStream = null;
            StreamWriter writer = null;
            StringBuilder filePath = new StringBuilder();

            // create a resource manager to read the error message from resource file
            ResourceManager resourceManager
                = new ResourceManager(BASE_NAME, Assembly.GetExecutingAssembly());

            try
            {
                // check if directory for log files exists or not
                if (!Directory.Exists(_fileLocation))
                {
                    // if not then show the error message from the resource file
                    string errorMessage = MSG_BAD_PATH;
                    string correctPath = CORRECT_PATH;
                    correctPath = string.Concat(correctPath, _fileLocation);
                    errorMessage = string.Concat(errorMessage, "\r\n", correctPath);
                }

                // Builds file path
                filePath.Append(this._fileLocation);
                filePath.Append(this._fileName);

                // creates a filestream for the specified file
                fileStream = new FileStream(filePath.ToString(), FileMode.OpenOrCreate, FileAccess.Write);

                // creates text writer for writing characters to a file stream
                writer = new StreamWriter(fileStream);

                // Set the file pointer to the end of the file
                writer.BaseStream.Seek(0, SeekOrigin.End);

                // Force the write to the underlying file
                writer.WriteLine(message);
                writer.Flush();
            }
            finally
            {
                // if writer is not null then close the writer
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        #endregion Methods

    }
}