using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AromaCareGlow.Framework.Common.Exceptions
{
    public class ExceptionLogger
    {
        #region LogType Enum

        /// <summary>
        /// Available log types
        /// </summary>
        public enum LogTypes
        {
            /// <summary>
            /// Log to a file location
            /// </summary>
            File = 1,

            /// <summary>
            /// Log to database table
            /// </summary>
            DB = 2
        }

        #endregion LogType Enum

        #region Member Variables

        // Internal logging object
        private DBLog _dbLogger;

        // Internal logging object
        private FileLog _fileLogger;

        // Internal log type
        private LogTypes _logType = LogTypes.File;

        // Name of the log
        private string _logName = string.Empty;

        // Location of the log
        private string _logLocation = string.Empty;

        #endregion Member Variables

        #region Properties

        /// <summary>
        /// Gets and sets type of logging
        /// </summary>
        public LogTypes LogType
        {
            get { return this._logType; }
            set
            {
                this._logType = value;

                // Set the Logger to the appropriate log when the type changes.
                switch (value)
                {
                    //// Right now only file logging is available
                    case LogTypes.File:
                        FileLog fileLog = new FileLog();

                        // sets the log file name
                        fileLog.FileName = _logName;

                        // sets the log file location
                        fileLog.FileLocation = _logLocation;
                        this._fileLogger = fileLog;
                        break;
                    case LogTypes.DB:
                        DBLog dbLog = new DBLog();

                        // sets the log file name
                        dbLog.DBConnectionString = _logLocation;

                        // sets the log file location
                        dbLog.LoggerStoredProcedure = _logName;
                        this._dbLogger = dbLog;
                        break;
                }
            }
        }

        /// <summary>
        /// LogTypes.File 
        ///     LogName should be name of file.
        /// LogTypes.DB 
        ///     LogName should be name of stored procedure inserting log information.
        /// </summary>
        public string LogName
        {
            get { return _logName; }
            set { _logName = value; }
        }

        /// <summary>
        /// LogTypes.File 
        ///    LogLocation should be location of file.
        /// LogTypes.DB 
        ///    LogLocation should be connection string to DB.
        /// </summary>
        public string LogLocation
        {
            get { return _logLocation; }
            set { _logLocation = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Log an exception.
        /// </summary>
        /// <param name="Message">Exception thrown by process.</param>
        /// <param name="Severity">Error severity level.</param>
        public void RecordMessage(Exception message, DBLog.MessageType severity)
        {
            // Log type is again set to assign the log name and location to the 
            // logger if it was not assigned earlier
            this.LogType = this._logType;

            this._fileLogger.RecordMessage(message, severity);
        }

        /// <summary>
        /// Log a message.
        /// </summary>
        /// <param name="Message">Message to log.</param>
        /// <param name="Severity">Error severity level.</param>
        public void RecordMessage(string message, DBLog.MessageType severity)
        {
            // Log type is again set to assign the log name and location to the 
            // logger if it was not assigned earlier
            this.LogType = this._logType;

            this._fileLogger.RecordMessage(message, severity);
        }

        /// <summary>
        /// Log an exception. 
        /// This method also collects additional information about running process or application to store along with error.  
        /// </summary>
        /// <param name="sourceApplication">Application/Process using logger.</param>
        /// <param name="message">Extra information regarding the process running.</param>
        /// <param name="exception">Exception thrown by process.</param>
        /// <param name="Severity">Error severity level.</param>
        public void RecordMessage(string sourceApplication, string message, Exception exception, DBLog.MessageType severity)
        {
            // Log type is again set to assign the log name and location to the 
            // logger if it was not assigned earlier
            this.LogType = this._logType;

            this._dbLogger.RecordMessage(sourceApplication, message, exception, severity);
        }

        #endregion Methods
    }
}