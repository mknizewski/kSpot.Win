using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace kSpot.Win.DAL.Tables
{
    [Table("users_profiles_backup")]
    public class UsersProfilesBackup
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Column(TypeName = "XML")]
        public string XMLFile { get; set; }

        public DateTime InsertTime { get; set; }

        [NotMapped]
        public XDocument Profiles
        {
            get { return XDocument.Parse(XMLFile); }
            set { XMLFile = value.ToString(); }
        }

        public virtual Users User { get; set; }
    }
}