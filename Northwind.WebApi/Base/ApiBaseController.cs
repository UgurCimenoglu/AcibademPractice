using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entity.Base;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController<TInterface,T,TDto> : ControllerBase where TInterface : IGenericService<T,TDto> where T : EntityBase where TDto : DtoBase
    {
        private TInterface service;

        public ApiBaseController(TInterface service)
        {
            this.service = service;
        }
    }
}
