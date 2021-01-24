namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyRequiredDataAnnotationToPatientName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "LastName", c => c.String());
            AlterColumn("dbo.Patients", "FirstName", c => c.String());
        }
    }
}
