using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using TelecomRewardsApi.Data;

namespace TelecomRewardsApi.Service
{
    public class CsvService : ICsvService
    {
        private readonly CampaignContext _context;

        public CsvService(CampaignContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateCsvReportAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CustomerId,Name,SSN,DOB,Age");

            foreach (var customer in customers)
            {
                csvBuilder.AppendLine($"{customer.Id},{customer.Name},{customer.SSN},{customer.DOB.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)},{customer.Age}");
            }

            return csvBuilder.ToString();
        }
    }
}
