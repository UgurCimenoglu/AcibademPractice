using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Entity.Dto
{
    public class DtoLogin : DtoBase
    {
        public string UserCode { get; set; }
        public string Password { get; set; }
    }
}
