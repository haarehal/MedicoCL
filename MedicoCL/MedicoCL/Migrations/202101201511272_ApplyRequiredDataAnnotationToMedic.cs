namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyRequiredDataAnnotationToMedic : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Medics", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Medics", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Medics", "Code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Medics", "Code", c => c.String());
            AlterColumn("dbo.Medics", "LastName", c => c.String());
            AlterColumn("dbo.Medics", "FirstName", c => c.String());
        }
    }
}
