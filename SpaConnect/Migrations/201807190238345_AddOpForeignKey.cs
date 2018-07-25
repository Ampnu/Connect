namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOpForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operations", "asmbID", c => c.Int(nullable: false));
            AddColumn("dbo.Operations", "assembly_ID", c => c.Int());
            CreateIndex("dbo.Operations", "assembly_ID");
            AddForeignKey("dbo.Operations", "assembly_ID", "dbo.Assies", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operations", "assembly_ID", "dbo.Assies");
            DropIndex("dbo.Operations", new[] { "assembly_ID" });
            DropColumn("dbo.Operations", "assembly_ID");
            DropColumn("dbo.Operations", "asmbID");
        }
    }
}
