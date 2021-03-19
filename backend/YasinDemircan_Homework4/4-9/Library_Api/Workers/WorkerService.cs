using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Library_Api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Library_Api.Workers
{
    public class WorkerService : BackgroundService
    {
        private LibraryDbContext _dbContext;
        private IServiceScopeFactory _scopeFactory;
          private ILogger<WorkerService> _logger;
        public WorkerService(IServiceScopeFactory scopeFactory, ILogger<WorkerService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = _scopeFactory.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
            _logger.LogInformation("Worker service started.");
             await Task.CompletedTask;
           
        }
        
           public override async Task StopAsync(CancellationToken cancellationToken)
        {
             _logger.LogWarning("Worker service Stopped.");
              await sendMessage("--CHAT ID--","Service Stopped");
            await Task.CompletedTask;
         
        }
   
public async Task sendMessage(string destID, string text)
{
    try
    {
         var bot = new Telegram.Bot.TelegramBotClient("--TOKEN--");
         await bot.SendTextMessageAsync(destID, text);
    }
    catch (Exception e)
    {
        Console.WriteLine("err");
    }
}
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
          
           while(!stoppingToken.IsCancellationRequested){
        
              _logger.LogWarning("Worker service runn.");
          
            await Task.Delay(9000, stoppingToken);
           } 

        }

     
    }
}
