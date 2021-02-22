using Misa.BL.Interface.IDBConnector;
using Misa.BL.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Misa.DL.RepositoryImp
{
    public class BaseRepositoryImp<T> : IBaseRepository<T>
    {
        IDBConnector _iDbConnector;
        public BaseRepositoryImp(IDBConnector iDBConnector)
        {
            _iDbConnector = iDBConnector;
        }

        public IEnumerable<T> GEtDataBySQL(string sql)
        {
            return _iDbConnector.GetData<T>(sql);
        }

        public IEnumerable<T> GetData(long page, long limmit, List<string> fieldNames = null, List<string> values = null)
        {
            return _iDbConnector.GetData<T>(page, limmit, fieldNames, values);
        }

        public int InsertEntity(T entity)
        {
            return _iDbConnector.Insert<T>(entity);
        }

        public int UpdateEntity(T entity)
        {
            return _iDbConnector.Update<T>(entity);
        }

        public long CountEntity(List<string> fieldNames = null, List<string> values = null)
        {
            return _iDbConnector.Count<T>(fieldNames, values);
        }

        public int DeleteEntity(List<string> fieldNames = null, List<string> values = null)
        {
            return _iDbConnector.Delete<T>(fieldNames, values);
        }

        public IDbConnection GetDBConnection()
        {
            return _iDbConnector.GetDBConnection();
        }
    }
}
