namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedVariables : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Operations", "opRev");
            DropColumn("dbo.Steps", "timeStart");
            DropColumn("dbo.Steps", "timeEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Steps", "timeEnd", c => c.Int(nullable: false));
            AddColumn("dbo.Steps", "timeStart", c => c.Int(nullable: false));
            AddColumn("dbo.Operations", "opRev", c => c.String());
        }
    }
}
