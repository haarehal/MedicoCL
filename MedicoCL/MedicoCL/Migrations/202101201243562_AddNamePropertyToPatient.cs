namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNamePropertyToPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "FirstName", c => c.String());
            AddColumn("dbo.Patients", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "LastName");
            DropColumn("dbo.Patients", "FirstName");
        }
    }
}
