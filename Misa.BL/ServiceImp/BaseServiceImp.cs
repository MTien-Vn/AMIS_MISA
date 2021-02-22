using Misa.BL.Enum;
using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Properties;
using Misa.BL.Service;
using Misa.BL.ValidateData;
using System.Collections.Generic;
using System.Linq;

namespace Misa.BL.ServiceImp
{
    public class BaseServiceImp<T> : IBaseService<T>
    {
        IBaseRepository<T> baseRepository;
        public BaseServiceImp(IBaseRepository<T> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public virtual long CountEntity(List<string> fieldNames = null, List<string> values = null)
        {
            return baseRepository.CountEntity(fieldNames, values);
        }

        public IEnumerable<T> GetEntity(long page, long limmit, List<string> fieldNames = null, List<string> values = null)
        {
            return baseRepository.GetData(page, limmit, fieldNames, values);
        }
        public T GetEntityById(string id)
        {
            var tableName = typeof(T).Name;
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add(tableName + "Id");
            values.Add(id);
            var entity = GetEntity(0, 1, fieldNames, values).FirstOrDefault();
            return entity;
        }

        public ServiceResult InsertT(T entity)
        {
            var validateObj = new ValidateObj<T>(baseRepository);
            var serviceResult = validateObj.ValidateObject(entity, null);
            if (serviceResult.MisaCode == MisaEmun.Scuccess)
            {
                var affect = baseRepository.InsertEntity(entity);
            }
            return serviceResult;

        }

        public ServiceResult UpdateT(T entity, string id)
        {
            var validateObj = new ValidateObj<T>(baseRepository);
            var serviceResult = validateObj.ValidateObject(entity, id);
            if (serviceResult.MisaCode == MisaEmun.Scuccess)
            {
                var affect = baseRepository.UpdateEntity(entity);
            }
            return serviceResult;
        }

        public ServiceResult DeleteT(List<string> fieldNames = null, List<string> values = null)
        {
            var serviceResult = new ServiceResult();
            var res = baseRepository.DeleteEntity(fieldNames, values);
            if (res == 0)
            {
                serviceResult.MisaCode = MisaEmun.False;
                serviceResult.Messenger.Add(Resources.Error_Delete);
            }
            return serviceResult;
        }
    }
}
