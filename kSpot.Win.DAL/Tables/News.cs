using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kSpot.Win.DAL.Tables
{
    [Table("news")]
    public class News
    {
        [Key]
        public int Id { get; set; }

        public string Header { get; set; }

        public string Content { get; set; }

        public DateTime InsertTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}