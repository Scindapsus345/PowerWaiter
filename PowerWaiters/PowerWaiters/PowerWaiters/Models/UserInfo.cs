namespace PowerWaiters.Models
{
    class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string EmploymentDate { get; set; }
        public string Post { get; set; }
        public int Scores { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string EmploymentDateString => $"Работает с {EmploymentDate}";
    }
}
