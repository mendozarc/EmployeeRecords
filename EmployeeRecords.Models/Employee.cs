namespace EmployeeRecords.Models
{
    public class Employee
    {
        public string? EmployeeNumber { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public EmployeeStatus EmployeeStatus { get; set; }

        public virtual string Color { get { return "black"; } } // created this property just to demo polymorphism
    }
}
