using kSpot.Win.DAL.Tables;
using System;
using System.Data.Entity;

namespace kSpot.Win.DAL.Interfaces
{
    public interface IkSpotContext : IDisposable
    {
        DbSet<Users> Users { get; set; }
        DbSet<UsersProfilesBackup> UsersProfilesBackup { get; set; }
        DbSet<News> News { get; set; }
        DbSet<LogsExceptions> LogsExceptions { get; set; }
        DbSet<DictAccountTypes> DictAccountTypes { get; set; }
    }
}