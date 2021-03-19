using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using hotels.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace hotels.API.Workers
{
    public class RoomWorkerService: BackgroundService
    {
        private ILogger<RoomWorkerService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        
        private HotelApiDbContext _dbContext;

        public RoomWorkerService(ILogger<RoomWorkerService> logger, IServiceScopeFactory scopeFactory){
            _logger = logger;
            _scopeFactory = scopeFactory;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = _scopeFactory.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<HotelApiDbContext>();
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // definitions
            while(!stoppingToken.IsCancellationRequested){
                if(_dbContext == null){
                    var scope = _scopeFactory.CreateScope();
                    _dbContext = scope.ServiceProvider.GetRequiredService<HotelApiDbContext>();
                }
                var migratingrecords = await _dbContext.Rooms.Where(room => !room.IsMigrate).ToListAsync();

             // Task.Run(() => 
                // {
                //     Thread.Sleep(5000);
                //     Console.WriteLine("Sub Task Runing");
                // });
                foreach(var record in migratingrecords){
                    // do work
                    record.IsMigrate = true;
                }
                if(_dbContext.ChangeTracker.HasChanges())
                    await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Worker Running");

                await Task.Delay(3000, stoppingToken);


            }
        }
    }
}
