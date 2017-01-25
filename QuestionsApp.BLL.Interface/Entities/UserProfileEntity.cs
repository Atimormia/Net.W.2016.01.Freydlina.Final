namespace QuestionsApp.BLL.Interface.Entities
{
    public class UserProfileEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FamilyName { get; set; }
        public string PublicEmail { get; set; }
        public string PublicPhoneNumber { get; set; }
        public byte[] Photo { get; set; }
        public string About { get; set; }
        public string UserId { get; set; }
    }
}
