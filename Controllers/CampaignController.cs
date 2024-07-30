using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelecomRewardsApi.Models;
using TelecomRewardsApi.Service;

namespace TelecomRewardsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        private readonly ICsvService _csvService;

        public CampaignController(ICampaignService campaignService, ICsvService csvService)
        {
            _campaignService = campaignService;
            _csvService = csvService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campaign>>> GetAllCampaigns()
        {
            var campaigns = await _campaignService.GetAllCampaignsAsync();
            return Ok(campaigns);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Campaign>> GetCampaignById(int id)
        {
            var campaign = await _campaignService.GetCampaignByIdAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }
            return Ok(campaign);
        }

        [HttpPost]
        public async Task<ActionResult<Campaign>> CreateCampaign(Campaign campaign)
        {
            var createdCampaign = await _campaignService.CreateCampaignAsync(campaign);
            return CreatedAtAction(nameof(GetCampaignById), new { id = createdCampaign.Id }, createdCampaign);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCampaign(int id, Campaign campaign)
        {
            if (id != campaign.Id)
            {
                return BadRequest();
            }

            var updatedCampaign = await _campaignService.UpdateCampaignAsync(campaign);
            return Ok(updatedCampaign);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampaign(int id)
        {
            await _campaignService.DeleteCampaignAsync(id);
            return NoContent();
        }

        [HttpGet("report")]
        public async Task<IActionResult> GenerateCsvReport()
        {
            var csvReport = await _csvService.GenerateCsvReportAsync();
            var bytes = System.Text.Encoding.UTF8.GetBytes(csvReport);
            var result = new FileContentResult(bytes, "text/csv")
            {
                FileDownloadName = "CustomerReport.csv"
            };

            return result;
        }
    }
}
