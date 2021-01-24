namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyRequiredAnnotationToDescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TestResults", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestResults", "Description", c => c.String());
        }
    }
}
