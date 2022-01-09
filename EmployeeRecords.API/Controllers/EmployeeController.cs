using EmployeeRecords.API.Utilities;
using EmployeeRecords.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecords.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        static readonly List<Employee> employeeList = new();

        readonly IEmployeeExcelReader _employeeExcelReader;

        public EmployeeController(IEmployeeExcelReader employeeExcelReader)
        {
            _employeeExcelReader = employeeExcelReader;
        }

        [HttpGet]
        public List<Employee> getEmployees()
        {
            return employeeList;
        }

        [Route("recordupload")]
        [HttpPost]
        public string RecordUpload()
        {
            try
            {
                var file = HttpContext.Request.Form.Files[0];
                employeeList.AddRange(_employeeExcelReader.GetEmployeesFromExcel(file));
                return "Success";
            }
            catch (Exception ex)
            {
                return "The application has encountered an error. Error: " + ex.Message;
            }
        }
    }
}
