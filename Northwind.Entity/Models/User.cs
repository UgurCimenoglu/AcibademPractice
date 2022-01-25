using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Northwind.Entity.Models
{
    public class User : EntityBase 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage ="User ID is required.")]
        public int UserID { get; set; }
        [MaxLength(30)]
        public string UserName { get; set; }
        [MaxLength(30)]
        public string UserLastName { get; set; }
        [MaxLength(40)]
        [Required(ErrorMessage = "UserCode is required.")]
        public string UserCode { get; set; }
        [MaxLength(60)]
        [Required(ErrorMessage = "Password is required.")]
        public byte[] PasswordHash { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public byte[] PasswordSalt { get; set; }

    }
}
