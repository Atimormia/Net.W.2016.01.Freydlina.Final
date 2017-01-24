namespace QuestionsApp.BLL.Interface.Entities
{
    public class UserContactEntity
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string ContactContent { get; set; }
        public int UserProfileId { get; set; }
    }
}
