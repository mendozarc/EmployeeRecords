using EmployeeRecords.Models;

namespace EmployeeRecords.API.Utilities
{
    public interface IEmployeeExcelReader
    {
        IEnumerable<Employee> GetEmployeesFromExcel(IFormFile file);
    }
}
