using kSpot.Win.DAL.Dictionaries;
using kSpot.Win.DAL.Tables;
using System;
using System.Data.Entity;

namespace kSpot.Win.DAL.Context
{
    public class kSpotContext : DbContext
    {
        #region Tables
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersProfilesBackup> UsersProfilesBackup { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<LogsExceptions> LogsExceptions { get; set; }
        public DbSet<DictAccountTypes> DictAccountTypes { get; set; }
        #endregion

        private kSpotContext()
            : base(ContextDictionary.kSpotConnectionString)
        { }

        public static kSpotContext Create()
        { return new kSpotContext(); }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DictAccountTypes>().HasKey(x => x.Id);

            modelBuilder.Entity<Users>().HasKey(x => x.Id);
            modelBuilder.Entity<Users>().HasRequired(x => x.DictAccountType);

            modelBuilder.Entity<News>().HasKey(x => x.Id);

            modelBuilder.Entity<LogsExceptions>().HasKey(x => x.Id);

            modelBuilder.Entity<UsersProfilesBackup>().HasKey(x => x.Id);
            modelBuilder.Entity<UsersProfilesBackup>().HasRequired(x => x.User);
        }
    }

    public class kSpotInicializer : CreateDatabaseIfNotExists<kSpotContext>
    {
        protected override void Seed(kSpotContext context)
        {
            base.Seed(context);

            var dictAccountTypeAdmin = new DictAccountTypes
            {
                Name = "Administrator",
                Ident = "Admin",
                InsertTime = DateTime.Now
            };

            var dictAccountTypeUser = new DictAccountTypes
            {
                Name = "Użytkownik",
                Ident = "User",
                InsertTime = DateTime.Now
            };

            context.DictAccountTypes.Add(dictAccountTypeAdmin);
            context.DictAccountTypes.Add(dictAccountTypeUser);
            context.SaveChanges();
        }
    }
}