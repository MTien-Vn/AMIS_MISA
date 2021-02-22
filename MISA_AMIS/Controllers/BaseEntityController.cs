using Microsoft.AspNetCore.Mvc;
using Misa.BL.Interface.IService;
using Misa.BL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        IBaseService<T> baseService;
        public BaseEntityController(IBaseService<T> _baseService)
        {
            this.baseService = _baseService;
        }
        // GET: api/<BaseController>
        [HttpGet("{page}/{limmit}")]
        public IEnumerable<T> Get(long page, long limmit)
        {
            return baseService.GetEntity(page, limmit);
        }

        [HttpGet("numberEntity")]
        public long NumberEntity()
        {
            return baseService.CountEntity();
        }

        // POST api/<BaseController>
        [HttpPost]
        public ServiceResult Post([FromBody] T entity)
        {
            return baseService.InsertT(entity);
        }

        // PUT api/<BaseController>/5
        [HttpPut("{id}")]
        public ServiceResult Put(string id, [FromBody] T entity)
        {
            return baseService.UpdateT(entity, id);
        }

    }
}
