using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BreederBot.Services
{
    public class FileHandlingService
    {
        public event Func<MemoryStream, ulong, Task> FileReceived;
        private readonly IServiceProvider _services;
        private readonly DiscordSocketClient _client;
        private readonly WebClient _webClient;

        public FileHandlingService(IServiceProvider services, WebClient webClient)
        {
            _services = services;
            _client = _services.GetRequiredService<DiscordSocketClient>();
            _client.MessageReceived += FileReceivedAsync;

            _webClient = webClient;
        }

        public async Task FileReceivedAsync(SocketMessage rawMessage)
        {
            if (rawMessage.Attachments.Count < 1) return;
            if (!(rawMessage is SocketUserMessage message)) return;
            if (message.Source != MessageSource.User) return;

            var channel = message.Channel as SocketGuildChannel;

            if (!channel.GetUser(rawMessage.Author.Id).Roles.ToList().Exists(c => c.Name.ToLower() == "breeder"))
            {
                return;
            }

            var file = message.Attachments.ToArray()[0];

            if (!file.Filename.EndsWith(".ini"))
            {
                return; 
            }

            var memStream = LoadFile(file.Url, file.Filename);

            await FileReceived(memStream, channel.Guild.Id);      
        }

        public MemoryStream LoadFile(string URL, string filename)
        {
            MemoryStream memoryStream = new MemoryStream(_webClient.DownloadData(URL));
            return memoryStream;
        }
    }
}
