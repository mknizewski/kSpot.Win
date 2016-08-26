using kSpot.Win.DAL.Dictionaries;
using System.Data.Entity;

namespace kSpot.Win.DAL.Context
{
    public class kSpotContext : DbContext
    {
        #region Tables
        #endregion

        private kSpotContext()
            :base(ContextDictionary.kSpotConnectionString)
        { }

        public static kSpotContext Create()
        { return new kSpotContext(); }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
