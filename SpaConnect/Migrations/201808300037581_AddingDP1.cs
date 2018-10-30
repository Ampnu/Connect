namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDP1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Operations", "DPNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Operations", "DPNumber", c => c.Boolean(nullable: false));
        }
    }
}
