﻿namespace QuestionsApp.BLL.Interface.Entities
{
    public class LectionHeaderEntity
    {
        public int Id { get; set; }
        public string LectionTitle { get; set; }
        public string LectionDescription { get; set; }
        public string LectionUrl { get; set; }
        public int UserProfileId { get; set; }
    }
}
