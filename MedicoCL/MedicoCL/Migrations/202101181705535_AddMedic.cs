namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        TitleId = c.Int(nullable: false),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .Index(t => t.TitleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medics", "TitleId", "dbo.Titles");
            DropIndex("dbo.Medics", new[] { "TitleId" });
            DropTable("dbo.Medics");
        }
    }
}
