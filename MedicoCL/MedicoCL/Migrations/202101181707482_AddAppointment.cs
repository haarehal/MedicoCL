namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAndTime = c.DateTime(nullable: false),
                        MedicId = c.Int(nullable: false),
                        IsUrgent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medics", t => t.MedicId, cascadeDelete: true)
                .Index(t => t.MedicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "MedicId", "dbo.Medics");
            DropIndex("dbo.Appointments", new[] { "MedicId" });
            DropTable("dbo.Appointments");
        }
    }
}
