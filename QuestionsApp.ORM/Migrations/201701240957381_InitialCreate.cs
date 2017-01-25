namespace QuestionsApp.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LectionEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LectionStart = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LectionEnd = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Organization = c.String(),
                        Auditory = c.String(),
                        LectionHeaderId = c.Int(nullable: false),
                        LectionStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LectionHeader", t => t.LectionHeaderId, cascadeDelete: true)
                .ForeignKey("dbo.LectionStatus", t => t.LectionStatusId, cascadeDelete: true)
                .Index(t => t.LectionHeaderId)
                .Index(t => t.LectionStatusId);
            
            CreateTable(
                "dbo.LectionHeader",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LectionTitle = c.String(nullable: false),
                        LectionDescription = c.String(unicode: false, storeType: "text"),
                        LectionUrl = c.String(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserProfileId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        FamilyName = c.String(),
                        PublicEmail = c.String(),
                        PublicPhoneNumber = c.String(),
                        Photo = c.Binary(storeType: "image"),
                        About = c.String(unicode: false, storeType: "text"),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserProfileId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        QuestionDescription = c.String(nullable: false, unicode: false, storeType: "text"),
                        QuestionDateTime = c.DateTime(nullable: false),
                        Likes = c.Int(nullable: false),
                        IsAnswered = c.Boolean(nullable: false),
                        IsBanned = c.Boolean(nullable: false),
                        UserProfileId = c.Int(),
                        LectionEventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LectionEvent", t => t.LectionEventId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileId)
                .Index(t => t.UserProfileId)
                .Index(t => t.LectionEventId);
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, unicode: false, storeType: "text"),
                        ReportTypeId = c.Int(nullable: false),
                        AuthorProfileId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReportType", t => t.ReportTypeId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.AuthorProfileId, cascadeDelete: true)
                .Index(t => t.ReportTypeId)
                .Index(t => t.AuthorProfileId);
            
            CreateTable(
                "dbo.ReportType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserContact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        ContactContent = c.String(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.LectionStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LectionEvent", "LectionStatusId", "dbo.LectionStatus");
            DropForeignKey("dbo.UserContact", "UserProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.Report", "AuthorProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.Report", "ReportTypeId", "dbo.ReportType");
            DropForeignKey("dbo.Question", "UserProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.Question", "LectionEventId", "dbo.LectionEvent");
            DropForeignKey("dbo.LectionHeader", "UserProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.LectionEvent", "LectionHeaderId", "dbo.LectionHeader");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserContact", new[] { "UserProfileId" });
            DropIndex("dbo.Report", new[] { "AuthorProfileId" });
            DropIndex("dbo.Report", new[] { "ReportTypeId" });
            DropIndex("dbo.Question", new[] { "LectionEventId" });
            DropIndex("dbo.Question", new[] { "UserProfileId" });
            DropIndex("dbo.LectionHeader", new[] { "UserProfileId" });
            DropIndex("dbo.LectionEvent", new[] { "LectionStatusId" });
            DropIndex("dbo.LectionEvent", new[] { "LectionHeaderId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LectionStatus");
            DropTable("dbo.UserContact");
            DropTable("dbo.ReportType");
            DropTable("dbo.Report");
            DropTable("dbo.Question");
            DropTable("dbo.UserProfile");
            DropTable("dbo.LectionHeader");
            DropTable("dbo.LectionEvent");
        }
    }
}
