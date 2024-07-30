using Microsoft.AspNetCore.Mvc;
using System.Text;
using TelecomRewardsApi.Service;

namespace TelecomRewardsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private readonly ICsvService _csvService;

        public CsvController(ICsvService csvService)
        {
            _csvService = csvService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCsvReport()
        {
            var csv = await _csvService.GenerateCsvReportAsync();
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "report.csv");
        }
    }
}
