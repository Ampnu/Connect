namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewStepVars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Steps", "lessonPlan", c => c.Int(nullable: false));
            AddColumn("dbo.Steps", "tools", c => c.Int(nullable: false));
            AddColumn("dbo.Steps", "generalNotes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Steps", "generalNotes");
            DropColumn("dbo.Steps", "tools");
            DropColumn("dbo.Steps", "lessonPlan");
        }
    }
}
