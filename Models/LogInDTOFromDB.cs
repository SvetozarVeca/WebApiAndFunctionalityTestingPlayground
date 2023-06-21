namespace Models
{
    public class LogInDTOFromDB
    {
        public User user { get; set; }
        public string token { get; set; }
    }

    public class User
    {
        public string _id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int __v { get; set; }
    }
}
