using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using beyoy.Models; 

namespace beyoy.BackgroundWorker
{
public class SummaryUpdaterService : BackgroundService
{
    private readonly ILogger<SummaryUpdaterService> _logger;
    private readonly Random _random; 

    public SummaryUpdaterService(ILogger<SummaryUpdaterService> logger)
    {
        _logger = logger;
        _random = new Random(); 
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {

            RandomWordsProvider.GenerateRandomWord();
             AddRandomSummaryWord(); 
            _logger.LogInformation("Updated summaries with a random word at: {time}", DateTimeOffset.Now);
            await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
        }
    }

    public string AddRandomSummaryWord() 
    {
        var randomWord = RandomWordsProvider.RandomWordsForClient[_random.Next(RandomWordsProvider.RandomWordsForClient.Count)]; 
        return randomWord; 
    }
}
}