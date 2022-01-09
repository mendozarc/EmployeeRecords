using EmployeeRecords.Models;
using Newtonsoft.Json;

namespace EmployeeRecords.UI.Client
{
    public class EmployeeRecordsApiClient : IEmployeeRecordsApiClient
    {
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync("https://localhost:7184/api/Employee");
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
        }
    }
}
