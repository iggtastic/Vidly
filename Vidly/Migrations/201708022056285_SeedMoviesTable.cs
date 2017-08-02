namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Id, Name, GenreId) VALUES (1, 'Hangover', 1)");
            Sql("INSERT INTO Movies (Id, Name, GenreId) VALUES (2, 'Die Hard', 2)");
            Sql("INSERT INTO Movies (Id, Name, GenreId) VALUES (3, 'The Terminator', 2)");
            Sql("INSERT INTO Movies (Id, Name, GenreId) VALUES (4, 'Toy Story', 3)");
            Sql("INSERT INTO Movies (Id, Name, GenreId) VALUES (5, 'Titanic', 4)");
            Sql("SET IDENTITY_INSERT Movies OFF");
        }
        
        public override void Down()
        {
        }
    }
}
