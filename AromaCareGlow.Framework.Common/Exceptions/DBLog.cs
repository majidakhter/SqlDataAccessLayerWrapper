using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AromaCareGlow.Framework.Common.Exceptions
{
    public class DBLog
    {
        #region MessageType Enum

        /// <summary>
        /// Available message severities
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            /// Informational message
            /// </summary>
            Informational = 1,

            /// <summary>
            /// Failure audit message
            /// </summary>
            Failure = 2,

            /// <summary>
            /// Warning message
            /// </summary>
            Warning = 3,

            /// <summary>
            /// Error message
            /// </summary>
            Error = 4
        }

        #endregion

        #region Private members

        string _loggerStoredProcedure;
        string _dbConnectionString;

        #endregion

        #region Public Properties

        /// <summary>
        /// Stored procedure logging error.
        /// </summary>
        public string LoggerStoredProcedure
        {
            get { return _loggerStoredProcedure; }
            set { _loggerStoredProcedure = value; }
        }

        public string DBConnectionString
        {
            get { return _dbConnectionString; }
            set { _dbConnectionString = value; }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// To record the message in DB.
        /// </summary>
        /// <param name="sourceApplication">application Name</param>
        /// <param name="message">additional message</param>
        /// <param name="exception">exception</param>
        /// <param name="severity">severity</param>
        public void RecordMessage(string sourceApplication, string message, Exception exception, MessageType severity)
        {
            //Connection
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _dbConnectionString;

            //Create and configure command
            SqlCommand command = CreateCommand(sourceApplication, message, exception, severity);
            command.Connection = connection;

            try
            {
                //Open connection
                connection.Open();

                //Execute command
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                FileLog fileLog = new FileLog();
                fileLog.FileLocation = ConfigurationSettings.AppSettings["NetSuiteErrorLog"];
                fileLog.FileName = "GlobalTranzErrorLog.txt";
                fileLog.RecordMessage("---------------------------------------------------------", MessageType.Informational);
                fileLog.RecordMessage(ex, MessageType.Failure);
                fileLog.RecordMessage(message, MessageType.Informational);
                fileLog.RecordMessage(exception, MessageType.Error);
                fileLog.RecordMessage("---------------------------------------------------------", MessageType.Informational);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            if (exception.InnerException != null)
            {
                RecordMessage(exception.Source, "InnerException", exception.InnerException, MessageType.Informational);
            }

        }

        /// <summary>
        /// Create and add parameter to command object
        /// </summary>
        /// <param name="sourceApplication"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="severity"></param>
        /// <returns>command object</returns>
        private SqlCommand CreateCommand(string sourceApplicationName, string message, Exception exception, MessageType severity)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = _loggerStoredProcedure;

            List<SqlParameter> inputParams = new List<SqlParameter>
                    {
                        new SqlParameter
                        {
                           ParameterName = "@SourceApplication", SqlDbType = SqlDbType.VarChar, Size = 100, Value = sourceApplicationName
                        },

                        new SqlParameter
                        {
                            ParameterName = "@SourceClass", SqlDbType = SqlDbType.VarChar, Size = 200, Value = string.IsNullOrEmpty(exception.Source) ? "InnerException" : exception.Source
                        },

                        new SqlParameter
                        {
                            ParameterName = "@LogTime", SqlDbType = SqlDbType.DateTime, Value =  DateTime.Now
                        },
                        new SqlParameter
                        {
                            ParameterName = "@Severity", SqlDbType = SqlDbType.Int, Value =  severity
                        },
                        new SqlParameter
                        {
                            ParameterName = "@AdditionalMessage", SqlDbType = SqlDbType.VarChar, Size = 4000, Value =  message
                        },
                        new SqlParameter
                        {
                            ParameterName = "@ExceptionMessage", SqlDbType = SqlDbType.VarChar, Size = 4000, Value =  exception.Message
                        },
                        new SqlParameter
                        {
                            ParameterName = "@StackTrace", SqlDbType = SqlDbType.Text, Value =  string.IsNullOrEmpty(exception.StackTrace)? "" : exception.StackTrace
                        },
                    };

            command.Parameters.AddRange(inputParams.ToArray());

            return command;
        }

        #endregion
    }
}