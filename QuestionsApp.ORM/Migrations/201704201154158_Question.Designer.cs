// <auto-generated />
namespace QuestionsApp.ORM.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class Question : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Question));
        
        string IMigrationMetadata.Id
        {
            get { return "201704201154158_Question"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
