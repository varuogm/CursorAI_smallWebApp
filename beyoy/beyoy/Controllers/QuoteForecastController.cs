using Microsoft.AspNetCore.Mvc;
using beyoy.Models; // Ensure to include the namespace for Quote
using beyoy.BackgroundWorker; // Include the namespace for RandomWordsProvider
using System.Collections.Generic;
using System.Linq;

namespace beyoy.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    private readonly ILogger<QuotesController> _logger;

    public QuotesController(ILogger<QuotesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetQuotes")]
    public IEnumerable<QuoteModel> Get()
    {
        return RandomWordsProvider.RandomWordsForClient.Select(word => new QuoteModel
        {
            Summary = word
        }).ToArray();
    }

    [HttpDelete("ClearQuotes")] // Define the DELETE endpoint
    public IActionResult ClearQuotes()
    {
        RandomWordsProvider.ClearRandomWords(); // Call the method to clear the list
        return Ok("Quotes cleared successfully");
    }
}