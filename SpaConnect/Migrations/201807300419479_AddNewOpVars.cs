namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewOpVars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operations", "lessonPlan", c => c.String());
            AddColumn("dbo.Operations", "tools", c => c.String());
            AddColumn("dbo.Operations", "generalNotes", c => c.String());
            DropColumn("dbo.Steps", "lessonPlan");
            DropColumn("dbo.Steps", "tools");
            DropColumn("dbo.Steps", "generalNotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Steps", "generalNotes", c => c.String());
            AddColumn("dbo.Steps", "tools", c => c.String());
            AddColumn("dbo.Steps", "lessonPlan", c => c.String());
            DropColumn("dbo.Operations", "generalNotes");
            DropColumn("dbo.Operations", "tools");
            DropColumn("dbo.Operations", "lessonPlan");
        }
    }
}
