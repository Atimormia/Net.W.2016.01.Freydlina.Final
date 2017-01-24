using System.Collections.Generic;
using System.Data.Entity;
using QuestionsApp.ORM.EF;
using QuestionsApp.ORM.Model;

namespace QuestionsApp.DR
{
    public class QuestionsAppSampleData:DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            new List<ReportType>
            {
                new ReportType { ReportTypeName = "Spam"},
                new ReportType { ReportTypeName = "Abuse"},
                new ReportType { ReportTypeName = "Flood"}

            }.ForEach(m => context.ReportTypes.Add(m));

            //new List<ApplicationRole>
            //{
            //    new ApplicationRole { Name = "User"},
            //    new ApplicationRole { Name = "Lector"},
            //    new ApplicationRole { Name = "Guest"},
            //    new ApplicationRole { Name = "Administrator"}
            //}.ForEach(m => context.Roles.Add(m));

            new List<LectionStatus>
            {
                new LectionStatus { StatusName = "Hidden"},
                new LectionStatus { StatusName = "Opened"},
                new LectionStatus { StatusName = "Closed"},
            }.ForEach(m => context.LectionStatus.Add(m));

            context.Commit();

        }

    }
}
