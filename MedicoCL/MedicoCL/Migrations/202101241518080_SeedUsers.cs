namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'afd48a7c-19a1-4fe0-9671-ba2682b3dfca', N'haris.alikadic@medico.com', 0, N'AOknAbVc+dP7dnF63y8Am/f/g5uqbsgeSOHMDxhvfTMJnye6vlIQvDg+dzV2yUl7yA==', N'eedc415e-7da2-45a7-bf5b-055fcc171f8f', NULL, 0, 0, NULL, 1, 0, N'haris.alikadic@medico.com')");

            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'58aea032-9bcf-491e-b6c7-2a1d369f374d', N'CanManageData')");

            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'afd48a7c-19a1-4fe0-9671-ba2682b3dfca', N'58aea032-9bcf-491e-b6c7-2a1d369f374d')");
        }
        
        public override void Down()
        {
        }
    }
}
