using AutoMapper;
using Northwind.Entity.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.BLL
{
    internal class ObjectMapper
    {
        static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}
