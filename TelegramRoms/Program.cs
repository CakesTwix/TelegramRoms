using TelegramRoms.Data;
using TelegramRoms.Data.Repository;
using TelegramRoms.Extensions;
using TelegramRoms.Handlers;
using TelegramRoms.Helpers;
using TelegramRoms.Services;
using TelegramRoms.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;

namespace TelegramRoms
{
    public class Program 
    {
        public static async Task Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();

            using (var context = builder.Services.GetService<DataContext>())
            {
                context.Database.Migrate();
                context.Initialize();
            }

            await builder.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            {
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseSqlite(hostContext.Configuration.GetConnectionString("DefaultConnection"));
                });

                services.AddHttpClient();
                services.AddLogging(builder =>
                {
                    builder.AddConsole(); 
                });
                
                // register all handlers
                Assembly.GetEntryAssembly().GetTypesAssignableFrom<BaseHandler>().ForEach((t) =>
                {
                    services.AddScoped(t);
                });

                services.AddScoped<IMessageService, MessageService>();
                services.AddScoped<IChatService, ChatService>();
                services.AddScoped<IGlobalRepository, GlobalRepository>();
                services.AddSingleton<IHostedService, TelegramBot>();

                services.Configure<BotSettings>(hostContext.Configuration.GetSection("BotSettings"));
            });
    }
}
