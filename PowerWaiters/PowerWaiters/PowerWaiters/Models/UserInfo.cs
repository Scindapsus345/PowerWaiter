using PowerWaiters.Extensions;

namespace PowerWaiters.Models
{
    class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmploymentDate { get; set; }
        public string Position { get; set; }
        public int TotalScores { get; set; }

        public UserDisplayModel ConvertToDisplayModel() => new UserDisplayModel
        {
            FullName = $"{FirstName} {LastName}",
            EmploymentDateString = $"Работает с {EmploymentDate}",
            TotalScoresString = TotalScores.ToXPString(),
            FirstSymbol = FirstName[0].ToString(),
            Post = Position
        };
    }
}
