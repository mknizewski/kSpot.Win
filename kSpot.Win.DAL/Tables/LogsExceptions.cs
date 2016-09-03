using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kSpot.Win.DAL.Tables
{
    [Table("_logs_exceptions")]
    public class LogsExceptions
    {
        [Key]
        public int Id { get; set; }

        public DateTime InsertTime { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public string InnerMessage { get; set; }

        public string InnnerSource { get; set; }
    }
}