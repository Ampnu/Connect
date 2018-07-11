namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeys1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Steps", "Operation_opID", "dbo.Operations");
            DropForeignKey("dbo.Operations", "Assy_assyID", "dbo.Assies");
            DropForeignKey("dbo.Assies", "Program_programID", "dbo.Programs");
            DropIndex("dbo.Assies", new[] { "Program_programID" });
            DropIndex("dbo.Operations", new[] { "Assy_assyID" });
            DropIndex("dbo.Steps", new[] { "Operation_opID" });
            DropPrimaryKey("dbo.Steps");
            DropColumn("dbo.Assies", "Program_programID");
            DropColumn("dbo.Operations", "Assy_assyID");
            DropColumn("dbo.Steps", "stepNumb");
            DropColumn("dbo.Steps", "Operation_opID");
            AddColumn("dbo.Assies", "op_FK_opID", c => c.Int());
            AddColumn("dbo.Steps", "stepID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Programs", "asmb_FK_assyID", c => c.Int());
            AddPrimaryKey("dbo.Steps", "stepID");
            CreateIndex("dbo.Assies", "op_FK_opID");
            CreateIndex("dbo.Programs", "asmb_FK_assyID");
            AddForeignKey("dbo.Assies", "op_FK_opID", "dbo.Operations", "opID");
            AddForeignKey("dbo.Programs", "asmb_FK_assyID", "dbo.Assies", "assyID");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Steps", "Operation_opID", c => c.Int());
            AddColumn("dbo.Steps", "stepNumb", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Operations", "Assy_assyID", c => c.Int());
            AddColumn("dbo.Assies", "Program_programID", c => c.Int());
            DropForeignKey("dbo.Programs", "asmb_FK_assyID", "dbo.Assies");
            DropForeignKey("dbo.Assies", "op_FK_opID", "dbo.Operations");
            DropIndex("dbo.Programs", new[] { "asmb_FK_assyID" });
            DropIndex("dbo.Assies", new[] { "op_FK_opID" });
            DropPrimaryKey("dbo.Steps");
            DropColumn("dbo.Programs", "asmb_FK_assyID");
            DropColumn("dbo.Steps", "stepID");
            DropColumn("dbo.Assies", "op_FK_opID");
            AddPrimaryKey("dbo.Steps", "stepNumb");
            CreateIndex("dbo.Steps", "Operation_opID");
            CreateIndex("dbo.Operations", "Assy_assyID");
            CreateIndex("dbo.Assies", "Program_programID");
            AddForeignKey("dbo.Assies", "Program_programID", "dbo.Programs", "programID");
            AddForeignKey("dbo.Operations", "Assy_assyID", "dbo.Assies", "assyID");
            AddForeignKey("dbo.Steps", "Operation_opID", "dbo.Operations", "opID");
        }
    }
}
