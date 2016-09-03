using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kSpot.Win.DAL.Tables
{
    [Table("users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime InsertTime { get; set; }

        [ForeignKey("DictAccountType")]
        public int AccountTypeId { get; set; }

        public virtual DictAccountTypes DictAccountType { get; set; }
    }
}