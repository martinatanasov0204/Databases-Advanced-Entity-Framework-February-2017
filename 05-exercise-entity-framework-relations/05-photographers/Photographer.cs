using System;

namespace _05_photographers
{
    public class Photographer
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
