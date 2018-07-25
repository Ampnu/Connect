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
                        ID = c.Int(nullable: false, identity: true),
                        OPN = c.String(),
                        opTitle = c.String(),
                        opRev = c.String(),
                        asmbID = c.Int(nullable: false),
                        assembly_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Assies", t => t.asmbID)
                .Index(t => t.asmbID);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        instructions = c.String(),
                        timeStart = c.Int(nullable: false),
                        timeEnd = c.Int(nullable: false),
                        operationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Operations", t => t.operationID, cascadeDelete: true)
                .Index(t => t.operationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Steps", "operationID", "dbo.Operations");
            DropForeignKey("dbo.Operations", "assembly_ID", "dbo.Assies");
            DropForeignKey("dbo.Assies", "programID", "dbo.Programs");
            DropIndex("dbo.Steps", new[] { "operationID" });
            DropIndex("dbo.Operations", new[] { "assembly_ID" });
            DropIndex("dbo.Assies", new[] { "programID" });
            DropTable("dbo.Steps");
            DropTable("dbo.Operations");
            DropTable("dbo.Programs");
            DropTable("dbo.Assies");
        }
    }
}
