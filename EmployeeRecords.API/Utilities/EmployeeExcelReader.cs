using EmployeeRecords.Models;
using ExcelDataReader;

namespace EmployeeRecords.API.Utilities
{
    public class EmployeeExcelReader : IEmployeeExcelReader
    {
        public IEnumerable<Employee> GetEmployeesFromExcel(IFormFile file)
        {
            IExcelDataReader reader;
            List<Employee> employeeList = new();

            if (!file.FileName.EndsWith(".xlsx"))
            {
                return employeeList;
            }

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); // fix the encoding 1252
            using var fileStream = file.OpenReadStream();
            reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            reader.Read(); // skips header;
            while (reader.Read())
            {
                var e = new Employee
                {
                    EmployeeNumber = reader.GetString(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    EmployeeStatus = (EmployeeStatus)Enum.Parse(typeof(EmployeeStatus), reader.GetString(3))
                };

                employeeList.Add(e);
            }

            return employeeList;
        }
    }
}
