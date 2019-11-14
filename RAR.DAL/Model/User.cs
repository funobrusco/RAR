namespace RAR.DAL.Model
{
    public class User
    {
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Username { get; set; }
        //public string Password { get; set; }
        public string token { get; set; }

        public User(string userName)
        {
            this.Username = userName;
        }
        public User()
        {
            
        }
    }
}
