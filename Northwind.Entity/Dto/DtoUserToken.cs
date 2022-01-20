using Northwind.Entity.Base;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Entity.Dto
{
    public class DtoUserToken : DtoBase
    {
        public User User { get; set; }
        public object AccessToken { get; set; }
    }
}
