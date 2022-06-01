namespace SunBaby.DA.Models
{
    public class User : BaseUser
    {
        public long TelegramId { get; set; }

        public string FirstNameTelegram { get; set; }

        public string LastNameTelegram { get; set; }

        public string LoginTelegram { get; set; }
    }
}
