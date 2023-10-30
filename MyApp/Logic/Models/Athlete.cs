namespace MyApp.Logic.Models
{
    public class Athlete
    {
        public Guid AthleteID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Event { get; set; }
    }
}
