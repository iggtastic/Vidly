namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBirthdatesForExistingCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate='1980-1-1' WHERE Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
