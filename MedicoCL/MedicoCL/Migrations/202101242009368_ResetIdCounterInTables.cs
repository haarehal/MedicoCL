namespace MedicoCL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetIdCounterInTables : DbMigration
    {
        public override void Up()
        {
            Sql(@"DBCC CHECKIDENT ('Medics', RESEED, 0);
                GO ");

            Sql(@"DBCC CHECKIDENT ('Patients', RESEED, 0);
                GO ");

            Sql(@"DBCC CHECKIDENT ('Appointments', RESEED, 0);
                GO ");
        }
        
        public override void Down()
        {
        }
    }
}
