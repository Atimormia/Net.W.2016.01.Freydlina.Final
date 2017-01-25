namespace QuestionsApp.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Header : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LectionHeader", "LectionUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LectionHeader", "LectionUrl", c => c.String(nullable: false));
        }
    }
}
