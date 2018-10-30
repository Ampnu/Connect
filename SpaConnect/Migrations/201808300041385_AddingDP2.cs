namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDP2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operations", "DP", c => c.String());
            DropColumn("dbo.Operations", "DPNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operations", "DPNumber", c => c.String());
            DropColumn("dbo.Operations", "DP");
        }
    }
}
