using CrmService;
using System;
using System.Xml;
using System.Xml.Linq;
using TelecomRewardsApi.Data;
using TelecomRewardsApi.Models;

namespace TelecomRewardsApi.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CampaignContext _context;
        private readonly ISoapClientService _soapClientService;

        public CustomerService(CampaignContext context, ISoapClientService soapClientService)
        {
            _context = context;
            _soapClientService = soapClientService;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                var soapResponse = await _soapClientService.FindPersonAsync(id.ToString());
                customer = ParseCustomerFromSoapResponse(soapResponse);
                if (customer != null)
                {
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();
                }
            }
            return customer;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        private Customer ParseCustomerFromSoapResponse(string response)
        {
            var xml = XDocument.Parse(response);
            XNamespace ns = "http://tempuri.org";
            var result = xml.Descendants().FirstOrDefault(d => d.Name.LocalName == "FindPersonResult");

            if (result == null)
                return null;

            var customer = new Customer
            {
                Name = result.Element("Name")?.Value,
                SSN = result.Element("SSN")?.Value,
                DOB = DateTime.Parse(result.Element("DOB")?.Value ?? "1900-01-01"),
                Age = int.Parse(result.Element("Age")?.Value ?? "0")

            };

            return customer;
        }
    }
}
