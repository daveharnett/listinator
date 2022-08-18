using ListinatorDomain;
using System.Data.Entity;

namespace ListinatorDal
{
    public class ListContext : DbContext
    {
        public ListContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<ListContext>(new Initializer());
        }
        public DbSet<List> Lists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { }
    }
}