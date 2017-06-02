namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullBirthdateInCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Customers ALTER COLUMN Birthdate DATETIME NULL");
        }
        
        public override void Down()
        {
        }
    }
}
