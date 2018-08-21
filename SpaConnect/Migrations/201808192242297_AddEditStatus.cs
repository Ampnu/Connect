namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEditStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operations", "editStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Steps", "editStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Steps", "editStatus");
            DropColumn("dbo.Operations", "editStatus");
        }
    }
}
