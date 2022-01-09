using EmployeeRecords.Models;

namespace EmployeeRecords.UI.Client
{
    public interface IEmployeeRecordsApiClient
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
