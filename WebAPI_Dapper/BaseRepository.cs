using System;
using System.Data;
using System.Data.SqlClient;


namespace WebAPI_Dapper
{
    public class BaseRepository : IDisposable
    {
        protected IDbConnection con;
        public BaseRepository()
        {
            string connectionString = "Data Source=osasco;Initial Catalog=WebAPIDB;User Id=db_homolog;password=dat!@#homolog;";
            con = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}