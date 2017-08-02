namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMoviesTableForNewFields : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET ReleaseDate='" + new DateTime(2009, 6, 5) + "', DateAdded='" + DateTime.Today + "', NumberInStock=5 WHERE Id=1");
            Sql("UPDATE Movies SET ReleaseDate='" + new DateTime(1988, 7, 20) + "', DateAdded='" + DateTime.Today + "', NumberInStock=7 WHERE Id=2");
            Sql("UPDATE Movies SET ReleaseDate='" + new DateTime(1984, 10, 26) + "', DateAdded='" + DateTime.Today + "', NumberInStock=11 WHERE Id=3");
            Sql("UPDATE Movies SET ReleaseDate='" + new DateTime(1995, 11, 22) + "', DateAdded='" + DateTime.Today + "', NumberInStock=15 WHERE Id=4");
            Sql("UPDATE Movies SET ReleaseDate='" + new DateTime(1997, 12, 19) + "', DateAdded='" + DateTime.Today + "', NumberInStock=8 WHERE Id=5");
        }
        
        public override void Down()
        {
        }
    }
}
