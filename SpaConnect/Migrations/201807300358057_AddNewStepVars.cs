namespace SpaConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewStepVars : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Steps", "lessonPlan", c => c.String());
            AlterColumn("dbo.Steps", "tools", c => c.String());
            AlterColumn("dbo.Steps", "generalNotes", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Steps", "generalNotes", c => c.Int(nullable: false));
            AlterColumn("dbo.Steps", "tools", c => c.Int(nullable: false));
            AlterColumn("dbo.Steps", "lessonPlan", c => c.Int(nullable: false));
        }
    }
}
