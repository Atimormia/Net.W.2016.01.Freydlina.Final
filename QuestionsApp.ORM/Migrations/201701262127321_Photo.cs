namespace QuestionsApp.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfile", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "Photo", c => c.Binary(storeType: "image"));
        }
    }
}
