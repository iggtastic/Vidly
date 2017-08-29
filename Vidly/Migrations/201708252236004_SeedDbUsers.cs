namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDbUsers : DbMigration
    {
        public override void Up()
        {
            // copied the scripts from the database table data and then deleted the data
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'39645bf6-8407-4a4e-9855-0cbd2c10dcc0', N'guest@vidly.com', 0, N'AAIeYV5vSoTSa9v/rT+hZnzBRVMgOsbdcYQdeftuDoUkBnM7b+Fv3bncSoIuJcskpg==', N'365a436e-4226-4814-858f-d596c932c21b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e28c38ac-ad62-4547-a7b0-253d6250e9d8', N'admin@vidly.com', 0, N'AHXRoqi912C+3SxoisAx3fk5XU6uklMSab6sMjXQM+XqF9XV4vyTAtUQxKjU4j89BQ==', N'99e811da-d599-475f-be8c-e36f05bbbdd0', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'50ab3114-c8b4-4fb6-beda-fe8e7ba69462', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e28c38ac-ad62-4547-a7b0-253d6250e9d8', N'50ab3114-c8b4-4fb6-beda-fe8e7ba69462')
");
        }
        
        public override void Down()
        {
        }
    }
}
