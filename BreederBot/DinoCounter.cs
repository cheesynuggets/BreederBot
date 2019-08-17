using BreederBot.Models;
using BreederBot.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreederBot
{
   public class DinoCounter
   {
        private readonly DinoExportParser _parser;
        private readonly DataHandlingService _dataHandler;

        public DinoCounter(DinoExportParser dinoParser, DataHandlingService dataHandler)
        {
            _parser = dinoParser;
            _dataHandler = dataHandler;
        }

        public Task AddDino(MemoryStream fileStream, ulong serverId)
        {
           var obj = _parser.ParseDinoExport(fileStream);

            Console.WriteLine("Adding dino");
            _dataHandler.AddDinoAsync(serverId, obj);

            return Task.CompletedTask;
        }
   }
}
