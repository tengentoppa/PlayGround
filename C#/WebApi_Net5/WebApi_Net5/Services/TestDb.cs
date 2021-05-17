using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebApi_Net5.Services.Interface;
using Newtonsoft.Json;

namespace WebApi_Net5.Services
{
    public class TestDb : IDbHelper
    {
        private readonly IConfiguration _config;
        private readonly string _connectionKey = "TestDb";
        private IDbConnection _dbConnection;

        IDbConnection DbConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    _dbConnection = new SqlConnection(_config.GetConnectionString(_connectionKey));
                }
                return _dbConnection;
            }
        }

        public TestDb(IConfiguration config)
        {
            _config = config;
        }
        public Dictionary<string, object> C_Test(string CmdString, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            var reader = DbConnection.QueryMultiple(CmdString, parameters, commandType: commandType);
            var tableIndex = 1;
            var result = new Dictionary<string, object>();
            while (!reader.IsConsumed)
            {
                result.Add($"Table{tableIndex++}", reader.Read());
            }
            if (parameters != null)
            {
                var code = parameters.Get<int>("RtnCode");
                var msg = parameters.Get<string>("RtnMsg");
                var totalCounts = parameters.Get<int>("TotalCounts");
            }

            return result;
        }
        public T Get<T>(string sp, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            return DbConnection.Query<T>(sp, param, commandType: commandType).FirstOrDefault();
        }

        public IEnumerable<T> GetAll<T>(string sp, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            return DbConnection.Query<T>(sp, param, commandType: commandType);
        }

        public int Execute<T>(string sp, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public T Insert<T>(string sp, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public T Update<T>(string sp, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_dbConnection != null)
            {
                _dbConnection.Close();
                _dbConnection.Dispose();
            }
        }
    }
}
