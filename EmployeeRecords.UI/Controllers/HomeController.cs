using EmployeeRecords.Models;
using EmployeeRecords.UI.Client;
using EmployeeRecords.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeRecords.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRecordsApiClient _employeeApiClient;

        public HomeController(ILogger<HomeController> logger, IEmployeeRecordsApiClient employeeApiClient)
        {
            _logger = logger;
            _employeeApiClient = employeeApiClient;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var employees = await _employeeApiClient.GetEmployees();
                var derivedEmployees = new List<Employee>();
                foreach (var employee in employees)
                {
                    Employee de = CreateDerivedEmployee(employee);
                    derivedEmployees.Add(de);
                }
                return View(derivedEmployees);
            } 
            catch (Exception ex)
            {
                // log error
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Factory method
        private Employee CreateDerivedEmployee(Employee employee)
        {
            return employee.EmployeeStatus == EmployeeStatus.Contractor
                ? new ContractorEmployee()
                {
                    EmployeeStatus = employee.EmployeeStatus,
                    EmployeeNumber = employee.EmployeeNumber,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                }
                : new RegularEmployee()
                {
                    EmployeeStatus = employee.EmployeeStatus,
                    EmployeeNumber = employee.EmployeeNumber,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                };
        }
    }
}