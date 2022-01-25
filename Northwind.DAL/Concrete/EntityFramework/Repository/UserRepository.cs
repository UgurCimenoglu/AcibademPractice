using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Abstract;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.DAL.Concrete.EntityFramework.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User CheckFromUserCode(DtoLogin login)
        {
            //var user = dbSet.Where(u => u.UserCode == login.UserCode && u.Password == login.Password);
            var user = dbSet.FirstOrDefault(u => u.UserCode == login.UserCode);
            return user;
        }
    }
}
