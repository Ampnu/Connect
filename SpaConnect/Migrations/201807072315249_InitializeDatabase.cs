namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assies",
                c => new
                    {
                        assyID = c.Int(nullable: false, identity: true),
                        assyName = c.String(),
                    })
                .PrimaryKey(t => t.assyID);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        opID = c.Int(nullable: false, identity: true),
                        OPN = c.String(),
                        opTitle = c.String(),
                        opRev = c.String(),
                    })
                .PrimaryKey(t => t.opID);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        programID = c.Int(nullable: false, identity: true),
                        programName = c.String(),
                    })
                .PrimaryKey(t => t.programID);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        stepNumb = c.Int(nullable: false, identity: true),
                        instructions = c.String(),
                        timeStart = c.Int(nullable: false),
                        timeEnd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.stepNumb);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Steps");
            DropTable("dbo.Programs");
            DropTable("dbo.Operations");
            DropTable("dbo.Assies");
        }
    }
}
