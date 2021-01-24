namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectRelationBetweenTestResultAndAppointment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestResults", "AppointmentId", "dbo.Appointments");
            DropIndex("dbo.TestResults", new[] { "AppointmentId" });
            DropPrimaryKey("dbo.TestResults");
            AddColumn("dbo.Appointments", "TestResultId", c => c.Int());
            AddColumn("dbo.TestResults", "TestResultId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TestResults", "TestResultId");
            CreateIndex("dbo.TestResults", "TestResultId");
            AddForeignKey("dbo.TestResults", "TestResultId", "dbo.Appointments", "Id");
            DropColumn("dbo.TestResults", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestResults", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.TestResults", "TestResultId", "dbo.Appointments");
            DropIndex("dbo.TestResults", new[] { "TestResultId" });
            DropPrimaryKey("dbo.TestResults");
            DropColumn("dbo.TestResults", "TestResultId");
            DropColumn("dbo.Appointments", "TestResultId");
            AddPrimaryKey("dbo.TestResults", "Id");
            CreateIndex("dbo.TestResults", "AppointmentId");
            AddForeignKey("dbo.TestResults", "AppointmentId", "dbo.Appointments", "Id", cascadeDelete: true);
        }
    }
}
