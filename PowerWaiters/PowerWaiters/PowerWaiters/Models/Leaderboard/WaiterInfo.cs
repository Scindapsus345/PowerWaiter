namespace PowerWaiters.Models
{
    class WaiterInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Scores { get; set; }
        public bool CurrentUser { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
