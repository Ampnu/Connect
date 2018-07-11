namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeys2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assies", "op_FK_opID", "dbo.Operations");
            DropForeignKey("dbo.Programs", "asmb_FK_assyID", "dbo.Assies");
            DropIndex("dbo.Assies", new[] { "op_FK_opID" });
            DropIndex("dbo.Programs", new[] { "asmb_FK_assyID" });
            AddColumn("dbo.Assies", "program_FK_programID", c => c.Int());
            AddColumn("dbo.Operations", "asmb_FK_assyID", c => c.Int());
            AddColumn("dbo.Steps", "op_FK_opID", c => c.Int());
            CreateIndex("dbo.Assies", "program_FK_programID");
            CreateIndex("dbo.Operations", "asmb_FK_assyID");
            CreateIndex("dbo.Steps", "op_FK_opID");
            AddForeignKey("dbo.Assies", "program_FK_programID", "dbo.Programs", "programID");
            AddForeignKey("dbo.Operations", "asmb_FK_assyID", "dbo.Assies", "assyID");
            AddForeignKey("dbo.Steps", "op_FK_opID", "dbo.Operations", "opID");
            DropColumn("dbo.Assies", "op_FK_opID");
            DropColumn("dbo.Programs", "asmb_FK_assyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programs", "asmb_FK_assyID", c => c.Int());
            AddColumn("dbo.Assies", "op_FK_opID", c => c.Int());
            DropForeignKey("dbo.Steps", "op_FK_opID", "dbo.Operations");
            DropForeignKey("dbo.Operations", "asmb_FK_assyID", "dbo.Assies");
            DropForeignKey("dbo.Assies", "program_FK_programID", "dbo.Programs");
            DropIndex("dbo.Steps", new[] { "op_FK_opID" });
            DropIndex("dbo.Operations", new[] { "asmb_FK_assyID" });
            DropIndex("dbo.Assies", new[] { "program_FK_programID" });
            DropColumn("dbo.Steps", "op_FK_opID");
            DropColumn("dbo.Operations", "asmb_FK_assyID");
            DropColumn("dbo.Assies", "program_FK_programID");
            CreateIndex("dbo.Programs", "asmb_FK_assyID");
            CreateIndex("dbo.Assies", "op_FK_opID");
            AddForeignKey("dbo.Programs", "asmb_FK_assyID", "dbo.Assies", "assyID");
            AddForeignKey("dbo.Assies", "op_FK_opID", "dbo.Operations", "opID");
        }
    }
}
