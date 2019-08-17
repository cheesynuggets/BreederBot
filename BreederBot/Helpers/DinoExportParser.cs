using BreederBot.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreederBot
{
   public class DinoExportParser
   {
       public DinoModel ParseDinoExport(MemoryStream memoryStream)
       {
            DinoModel dino = new DinoModel();

            using (var reader = new StreamReader(memoryStream, Encoding.UTF8))
            {
                string line;

                while((line = reader.ReadLine()) != null)
                {
                    if(line.StartsWith("["))
                    {
                        continue;
                    }

                    if(!line.Contains("="))
                    {
                        continue;
                    }

                    var keyVal = line.Split('=');

                    if(keyVal[0] == "DinoNameTag")
                    {
                        dino.DinoNameTag = keyVal[1];
                    }
                    else if (keyVal[0] == "bIsFemale")
                    {
                       dino.IsFemale = Convert.ToBoolean(keyVal[1]);
                    }
                }  
            }
            return dino;
       }

   }
}
