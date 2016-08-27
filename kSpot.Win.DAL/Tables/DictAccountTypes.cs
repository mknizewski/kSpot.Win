using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace kSpot.Win.DAL.Tables
{
    [Table("_dict_account_types")]
    public class DictAccountTypes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ident { get; set; }

        public DateTime InsertTime { get; set; }
    }
}