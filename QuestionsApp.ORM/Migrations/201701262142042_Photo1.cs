namespace QuestionsApp.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "PhotoType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "PhotoType");
        }
    }
}
