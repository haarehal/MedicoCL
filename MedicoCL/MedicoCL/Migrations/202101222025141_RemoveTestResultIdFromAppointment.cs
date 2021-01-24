namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTestResultIdFromAppointment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "TestResultId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "TestResultId", c => c.Int());
        }
    }
}
