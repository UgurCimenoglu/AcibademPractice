using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Entity.Dto
{
    public class DtoUser : DtoBase
    {

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserLastName { get; set; }

        public string UserCode { get; set; }

        public string Password { get; set; }
    }
}
