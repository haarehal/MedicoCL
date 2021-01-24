namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenders : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genders ON");

            Sql("INSERT INTO Genders (Id, Name) VALUES (1, 'Male')");
            Sql("INSERT INTO Genders (Id, Name) VALUES (2, 'Female')");
            Sql("INSERT INTO Genders (Id, Name) VALUES (3, 'Unknown')");

            Sql("SET IDENTITY_INSERT Genders OFF");
        }
        
        public override void Down()
        {
        }
    }
}
