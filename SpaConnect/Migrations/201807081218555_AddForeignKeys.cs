namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assies", "Program_programID", c => c.Int());
            AddColumn("dbo.Operations", "Assy_assyID", c => c.Int());
            AddColumn("dbo.Steps", "Operation_opID", c => c.Int());
            CreateIndex("dbo.Assies", "Program_programID");
            CreateIndex("dbo.Operations", "Assy_assyID");
            CreateIndex("dbo.Steps", "Operation_opID");
            AddForeignKey("dbo.Steps", "Operation_opID", "dbo.Operations", "opID");
            AddForeignKey("dbo.Operations", "Assy_assyID", "dbo.Assies", "assyID");
            AddForeignKey("dbo.Assies", "Program_programID", "dbo.Programs", "programID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assies", "Program_programID", "dbo.Programs");
            DropForeignKey("dbo.Operations", "Assy_assyID", "dbo.Assies");
            DropForeignKey("dbo.Steps", "Operation_opID", "dbo.Operations");
            DropIndex("dbo.Steps", new[] { "Operation_opID" });
            DropIndex("dbo.Operations", new[] { "Assy_assyID" });
            DropIndex("dbo.Assies", new[] { "Program_programID" });
            DropColumn("dbo.Steps", "Operation_opID");
            DropColumn("dbo.Operations", "Assy_assyID");
            DropColumn("dbo.Assies", "Program_programID");
        }
    }
}
