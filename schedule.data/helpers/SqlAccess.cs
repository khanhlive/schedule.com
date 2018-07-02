namespace schedule.data.helpers
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;

    public class SqlAccess
    {
        private OleDbConnection _myConn;
        private OleDbTransaction _OleDbTrans;
        private string _strConn;

        public SqlAccess()
        {
            if (ConfigurationManager.AppSettings["connectionString"] == null)
            {
                throw new ArgumentNullException("Kh\x00f4ng thể đọc được chuỗi \"ConnectString\" trong tập tin .Config.");
            }
            this._strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ConfigurationManager.AppSettings["ConnectionString"].ToString();
            this._myConn = new OleDbConnection();
        }

        public SqlAccess(string sDBName)
        {
            this._strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sDBName + ";Persist Security Info=False;Jet OLEDB:Database Password=";
            this._myConn = new OleDbConnection();
        }

        public SqlAccess(string sDBName, string sPassword)
        {
            this._strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sDBName + ";Persist Security Info=False;Jet OLEDB:Database Password=" + sPassword;
            this._myConn = new OleDbConnection();
        }

        public SqlAccess(string sLocation, string sDBName, string sPassword)
        {
            this._strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sLocation + sDBName + ";Persist Security Info=False;Jet OLEDB:Database Password=" + sPassword;
            this._myConn = new OleDbConnection();
        }

        public void Close()
        {
            if (this._myConn.State == ConnectionState.Open)
            {
                this._myConn.Close();
                this._myConn.Dispose();
                this._myConn = null;
            }
        }

        public string Commit()
        {
            string str2;
            try
            {
                this._OleDbTrans.Commit();
                str2 = "OK";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return str2;
        }

        public DataTable ExecuteDataTable(string commandText) =>
            this.ExecuteDataTable(commandText, null, null);

        public DataTable ExecuteDataTable(OleDbTransaction myTransaction, string commandText)
        {
            DataTable dataTable = new DataTable();
            try
            {
                OleDbCommand selectCommand = new OleDbCommand(commandText, myTransaction.Connection, myTransaction);
                new OleDbDataAdapter(selectCommand).Fill(dataTable);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return dataTable;
        }

        public DataTable ExecuteDataTable(string commandText, string[] myPara, object[] myValue)
        {
            DataTable dataTable = new DataTable();
            if (this.Open() == "OK")
            {
                try
                {
                    OleDbCommand selectCommand = new OleDbCommand
                    {
                        CommandText = commandText,
                        Connection = this._myConn
                    };
                    if (myPara != null)
                    {
                        selectCommand.CommandType = CommandType.StoredProcedure;
                        for (int i = 0; i < myPara.Length; i++)
                        {
                            OleDbParameter parameter = new OleDbParameter(myPara[i], myValue[i]);
                            selectCommand.Parameters.Add(parameter);
                        }
                    }
                    new OleDbDataAdapter(selectCommand).Fill(dataTable);
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    this.Close();
                }
            }
            return dataTable;
        }

        public string ExecuteNonQuery(string commandText) =>
            this.ExecuteNonQuery(commandText, null, null);

        public string ExecuteNonQuery(OleDbTransaction myTransaction, string commandText) =>
            this.ExecuteNonQuery(myTransaction, commandText, null, null);

        public string ExecuteNonQuery(string commandText, string[] myPara, object[] myValue)
        {
            string message = string.Empty;
            message = this.Open();
            if (message == "OK")
            {
                try
                {
                    OleDbCommand command = new OleDbCommand
                    {
                        CommandText = commandText,
                        Connection = this._myConn
                    };
                    if (myPara != null)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        for (int i = 0; i < myPara.Length; i++)
                        {
                            OleDbParameter parameter = new OleDbParameter(myPara[i], myValue[i]);
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();
                    message = "OK";
                }
                catch (Exception exception)
                {
                    message = exception.Message;
                    throw new Exception(message);
                }
                finally
                {
                    this.Close();
                }
            }
            return message;
        }

        public string ExecuteNonQuery(OleDbTransaction myTransaction, string commandText, string[] myPara, object[] myValue)
        {
            string message = string.Empty;
            try
            {
                OleDbCommand command = new OleDbCommand
                {
                    CommandText = commandText,
                    Connection = myTransaction.Connection,
                    Transaction = myTransaction
                };
                if (myPara != null)
                {
                    command.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < myPara.Length; i++)
                    {
                        OleDbParameter parameter = new OleDbParameter(myPara[i], myValue[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                command.ExecuteNonQuery();
                message = "OK";
            }
            catch (Exception exception)
            {
                message = exception.Message;
                this.Rollback();
                throw new Exception(message);
            }
            return message;
        }

        public OleDbDataReader ExecuteReader(string commandText)
        {
            OleDbDataReader reader = null;
            if (this.Open() == "OK")
            {
                reader = this.ExecuteReader(this._myConn, commandText);
            }
            return reader;
        }

        public OleDbDataReader ExecuteReader(OleDbConnection myConnection, string commandText)
        {
            OleDbDataReader reader = null;
            try
            {
                reader = new OleDbCommand(commandText, myConnection).ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exception)
            {
                throw new ArgumentException(exception.Message);
            }
            return reader;
        }

        public OleDbDataReader ExecuteReader(OleDbTransaction myTransaction, string commandText)
        {
            OleDbDataReader reader = null;
            try
            {
                reader = new OleDbCommand(commandText, myTransaction.Connection, myTransaction).ExecuteReader();
            }
            catch (Exception exception)
            {
                throw new ArgumentException(exception.Message);
            }
            return reader;
        }

        public object ExecuteScalar(string commandText) =>
            this.ExecuteScalar(commandText, null, null);

        public object ExecuteScalar(string commandText, string[] myPara, object[] myValue)
        {
            object obj2 = null;
            if (this.Open() == "OK")
            {
                try
                {
                    OleDbCommand command = new OleDbCommand
                    {
                        CommandText = commandText,
                        Connection = this._myConn
                    };
                    if (myPara != null)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        for (int i = 0; i < myPara.Length; i++)
                        {
                            OleDbParameter parameter = new OleDbParameter(myPara[i], myValue[i]);
                            command.Parameters.Add(parameter);
                        }
                    }
                    obj2 = command.ExecuteScalar();
                }
                catch (Exception exception)
                {
                    obj2 = null;
                    throw new Exception(exception.Message);
                }
                finally
                {
                    this.Close();
                }
            }
            return obj2;
        }

        ~SqlAccess()
        {
            this._myConn = null;
        }

        public string Open()
        {
            string str;
            if (this._myConn == null)
            {
                throw new Exception("Connect is null");
            }
            try
            {
                this._myConn.ConnectionString = this._strConn;
                if (this._myConn.State == ConnectionState.Closed)
                {
                    this._myConn.Open();
                }
                str = "OK";
            }
            catch (OleDbException exception)
            {
                string message = exception.Message;
                throw new Exception(exception.Message);
            }
            return str;
        }

        public string Rollback()
        {
            string message = string.Empty;
            try
            {
                this._OleDbTrans.Rollback();
                return "OK";
            }
            catch (Exception exception)
            {
                message = exception.Message;
            }
            return message;
        }

        public string Start()
        {
            string str2;
            string str = this.Open();
            if (str != "OK")
            {
                return str;
            }
            try
            {
                this._OleDbTrans = this._myConn.BeginTransaction();
                str2 = "OK";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return str2;
        }

        public OleDbConnection Connection =>
            this._myConn;

        public string ConnectString
        {
            get =>
                this._strConn;
            set
            {
                this._strConn = value;
            }
        }

        public OleDbTransaction Transaction =>
            this._OleDbTrans;
    }
}

