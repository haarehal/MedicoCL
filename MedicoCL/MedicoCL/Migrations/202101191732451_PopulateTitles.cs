namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTitles : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Titles ON");

            Sql("INSERT INTO Titles (Id, Name) VALUES (1, 'Specialist')");
            Sql("INSERT INTO Titles (Id, Name) VALUES (2, 'Resident')");
            Sql("INSERT INTO Titles (Id, Name) VALUES (3, 'Nurse')");

            Sql("SET IDENTITY_INSERT Titles OFF");
        }
        
        public override void Down()
        {
        }
    }
}
