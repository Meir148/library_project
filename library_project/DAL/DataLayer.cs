using Microsoft.EntityFrameworkCore;
using library_project.Models;
using library_pr;


namespace library_project.DAL
{
    public class DataLayer : DbContext
    {
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();

            Seed();
            //Seed2();

        }

        private void Seed()
        {
            if (Bookcases.Count() > 0) { return; }

            Bookcase firstBookcase = new Bookcase();

            firstBookcase.Name = "תורה";

            Bookcases.Add(firstBookcase);
            SaveChanges();
           
        }
        //private void Seed2()
        //{
        //    if (shelves.Count() > 0) { return; }

        //    shelf firstShelf = new shelf();

        //    firstShelf.Hight = 5;
        //    firstShelf.Id = 1;

        //    shelves.Add(firstShelf);
        //    SaveChanges();
        //}

        public DbSet<Bookcase> Bookcases { get; set; }

        public DbSet<shelf> shelves { get; set; }

        public DbSet<book> books { get; set; }


        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(),
                connectionString).Options;
        }

    }
}
