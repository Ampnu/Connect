namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        assyName = c.String(),
                        programID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Programs", t => t.programID, cascadeDelete: true)
                .Index(t => t.programID);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        programName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        opID = c.Int(nullable: false, identity: true),
                        OPN = c.String(),
                        opTitle = c.String(),
                        opRev = c.String(),
                        asmb_FK_ID = c.Int(),
                    })
                .PrimaryKey(t => t.opID)
                .ForeignKey("dbo.Assies", t => t.asmb_FK_ID)
                .Index(t => t.asmb_FK_ID);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        stepID = c.Int(nullable: false, identity: true),
                        instructions = c.String(),
                        timeStart = c.Int(nullable: false),
                        timeEnd = c.Int(nullable: false),
                        op_FK_opID = c.Int(),
                    })
                .PrimaryKey(t => t.stepID)
                .ForeignKey("dbo.Operations", t => t.op_FK_opID)
                .Index(t => t.op_FK_opID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Steps", "op_FK_opID", "dbo.Operations");
            DropForeignKey("dbo.Operations", "asmb_FK_ID", "dbo.Assies");
            DropForeignKey("dbo.Assies", "programID", "dbo.Programs");
            DropIndex("dbo.Steps", new[] { "op_FK_opID" });
            DropIndex("dbo.Operations", new[] { "asmb_FK_ID" });
            DropIndex("dbo.Assies", new[] { "programID" });
            DropTable("dbo.Steps");
            DropTable("dbo.Operations");
            DropTable("dbo.Programs");
            DropTable("dbo.Assies");
        }
    }
}
