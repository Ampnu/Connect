namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operations", "DPNumber", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Operations", "DPNumber");
        }
    }
}
