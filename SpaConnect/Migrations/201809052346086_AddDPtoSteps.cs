namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDPtoSteps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Steps", "DP", c => c.String());
            DropColumn("dbo.Operations", "DP");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operations", "DP", c => c.String());
            DropColumn("dbo.Steps", "DP");
        }
    }
}
