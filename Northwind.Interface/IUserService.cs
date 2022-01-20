using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Interface
{
    public interface IUserService : IGenericService<User,DtoUser>
    {
        DtoUser Login(DtoLogin login);
    }
}
