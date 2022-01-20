using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Abstract
{
    public interface IUserRepository
    {
        User Login(DtoLogin login);
    }
}
