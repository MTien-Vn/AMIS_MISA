using Dapper;
using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IDBConnector;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Misa.DL.DBConnectorImp
{
    public class DBConnectorImp : IDBConnector
    {
        protected string connectionString;
        protected IDbConnection dbConnection;
        readonly IConfiguration configuration;
        public DBConnectorImp(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("mariaDB").Value;
            dbConnection = new MySqlConnection(connectionString);
        }

        #region get entity
        public IEnumerable<T> GetData<T>(long page, long limmit, List<string> fieldNames = null, List<string> values = null)
        {
            long offSet;
            if (page == 1)
            {
                offSet = 0;
            }
            else
            {
                offSet = (page - 1) * limmit - 1;
            }
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@offSet", offSet);
            dynamicParameters.Add("@limmit", limmit);
            if (values == null)
            {
                var entities = dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
                return entities;
            }
            else
            {
                int index = 0;
                storeName += "By";
                Array _values = values.ToArray();
                foreach (var fieldName in fieldNames)
                {
                    storeName += $"{fieldName}";
                    dynamicParameters.Add($"@{fieldName}", _values.GetValue(index));
                    index++;
                }
                var entities = dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        public IEnumerable<T> GetData<T>(string sql)
        {
            var entity = dbConnection.Query<T>(sql);
            return entity;
        }
        #endregion

        public int Insert<T>(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Insert{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    if (propertyValue == null)
                    {
                        propertyValue = "";
                    }
                    else
                    {
                        propertyValue = propertyValue.ToString();
                    }
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affects = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affects;
        }

        
        public int Update<T>(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Update{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    propertyValue = propertyValue.ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affects = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affects;
        }

        public int Delete<T>(List<string> fieldNames, List<string> values)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Delete{tableName}By";
            var index = 0;
            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var fieldName in fieldNames)
            {
                storeName += fieldName;
                dynamicParameters.Add($"@{fieldName}", values[index]);
                index++;
            }
            var affect = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affect;
        }

        #region count entity
        public long Count<T>(List<string> fieldNames = null, List<string> values = null)
        {
            var tableName = typeof(T).Name;
            if (values == null)
            {
                var storeName = $"Proc_Count{tableName}";
                long total = (long)dbConnection.ExecuteScalar(storeName, commandType: CommandType.StoredProcedure);
                return total;
            }
            else
            {
                string storeName = $"Proc_Count{tableName}By";
                DynamicParameters dynamicParameters = new DynamicParameters();
                Array _values = values.ToArray();
                int index = 0;
                if (fieldNames.Any() == false)
                {
                    return -1;
                }
                else
                {
                    foreach (var fieldName in fieldNames)
                    {
                        storeName = storeName + $"{fieldName}";
                        dynamicParameters.Add($"@{fieldName}", _values.GetValue(index));
                        index++;
                    }
                }
                long total = (long)dbConnection.ExecuteScalar(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
                return total;
            }
        }

        public IDbConnection GetDBConnection()
        {
            return dbConnection;
        }
        #endregion
    }
}
