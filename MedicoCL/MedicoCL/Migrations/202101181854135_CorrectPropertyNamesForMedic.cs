namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectPropertyNamesForMedic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medics", "FirstName", c => c.String());
            AddColumn("dbo.Medics", "LastName", c => c.String());
            DropColumn("dbo.Medics", "Name");
            DropColumn("dbo.Medics", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medics", "Surname", c => c.String());
            AddColumn("dbo.Medics", "Name", c => c.String());
            DropColumn("dbo.Medics", "LastName");
            DropColumn("dbo.Medics", "FirstName");
        }
    }
}
