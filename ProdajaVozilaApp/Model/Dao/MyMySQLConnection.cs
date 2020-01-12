using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ProdajaVozilaApp.Model.Dao
{
    class MyMySQLConnection : IDisposable
    {
        private static string ConnectionString { get; } =
            $@"Server=127.0.0.1;Database=prodajaprepisvozila;Uid=root;Pwd={Environment.GetEnvironmentVariable("MYSQL_PASS", EnvironmentVariableTarget.User)};Allow User Variables=True";

        public MySqlConnection Connection { get; set; }

        public MyMySQLConnection()
        {
            Connection = new MySqlConnection(ConnectionString);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Connection.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~MyMySQLConnection()
        {
            Dispose(false);
        }
    }
}
