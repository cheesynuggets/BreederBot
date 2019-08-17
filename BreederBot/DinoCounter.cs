using BreederBot.Models;
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

        public DinoCounter(DinoExportParser dinoParser)
        {
            _parser = dinoParser;
        }

        public Task AddDino(MemoryStream fileStream)
        {
           var obj = _parser.ParseDinoExport(fileStream);

            Console.WriteLine(obj.uniqueID);

            return Task.CompletedTask;
        }
   }
}
