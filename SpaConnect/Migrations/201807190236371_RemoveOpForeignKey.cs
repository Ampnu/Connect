namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOpForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Operations", "assembly_ID", "dbo.Assies");
            DropIndex("dbo.Operations", new[] { "assembly_ID" });
            DropColumn("dbo.Operations", "asmbID");
            DropColumn("dbo.Operations", "assembly_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operations", "assembly_ID", c => c.Int());
            AddColumn("dbo.Operations", "asmbID", c => c.Int(nullable: false));
            CreateIndex("dbo.Operations", "assembly_ID");
            AddForeignKey("dbo.Operations", "assembly_ID", "dbo.Assies", "ID");
        }
    }
}
