using BreederBot.Services;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BreederBot
{
    public class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
               var services = ConfigureServices();
           
                var client = services.GetRequiredService<DiscordSocketClient>();

                client.Log += LogAsync;
                services.GetRequiredService<CommandService>().Log += LogAsync;
                client.JoinedGuild += Client_JoinedGuild;

                var fileHandlingService = services.GetRequiredService<FileHandlingService>();

                await client.LoginAsync(TokenType.Bot, PrivateConfig.Token);
                await client.StartAsync();

                
                await services.GetRequiredService<CommandHandlingService>().InitializeAsync();
                
                await Task.Delay(-1);
                
        }
        private Task Client_JoinedGuild(SocketGuild arg)
        {
            arg.CreateRoleAsync("Breeder", color: Color.Green);
            return Task.CompletedTask;
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());

            return Task.CompletedTask;
        }



        private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .AddSingleton<DinoExportParser>()
                .AddSingleton<WebClient>()
                .AddSingleton<FileHandlingService>()
                .BuildServiceProvider();
        }

    }
}
