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

        public async Task<MemoryStream> FileReceivedAsync(SocketMessage rawMessage)
        {
            if (rawMessage.Attachments.Count < 1) return null;
            if (!(rawMessage is SocketUserMessage message)) return null;
            if (message.Source != MessageSource.User) return null;

            var file = message.Attachments.ToArray()[0];

            return LoadFile(file.Url, file.Filename);
        }

        public MemoryStream  LoadFile(string URL, string filename)
        {
            MemoryStream memoryStream = new MemoryStream(_webClient.DownloadData(URL));
            return memoryStream;
        }
    }
}
