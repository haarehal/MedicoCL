namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationshipBetweenTestResultAndAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestResults", "AppointmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.TestResults", "AppointmentId");
            AddForeignKey("dbo.TestResults", "AppointmentId", "dbo.Appointments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "AppointmentId", "dbo.Appointments");
            DropIndex("dbo.TestResults", new[] { "AppointmentId" });
            DropColumn("dbo.TestResults", "AppointmentId");
        }
    }
}
