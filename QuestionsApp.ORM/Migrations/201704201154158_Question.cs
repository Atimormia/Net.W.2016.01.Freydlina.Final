namespace QuestionsApp.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Question : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "IdOnClient", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Question", "IdOnClient");
        }
    }
}
