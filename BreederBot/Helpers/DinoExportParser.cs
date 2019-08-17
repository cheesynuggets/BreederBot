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
            dino.Stats = new StatModel();

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
                    if(keyVal.Length < 2) { continue; }

                    if (keyVal[0] == "DinoID1")
                    {
                        dino.Id1 = Convert.ToInt32 (keyVal[1]);
                    }
                    else if (keyVal[0] == "DinoID2")
                    {
                        dino.Id2 = Convert.ToInt32(keyVal[1]);
                    }

                    else if (keyVal[0] == "DinoNameTag")
                    {
                        dino.DinoNameTag = keyVal[1];
                    }
                    else if (keyVal[0] == "bIsFemale")
                    {
                       dino.IsFemale = Convert.ToBoolean(keyVal[1]);
                    }
                    else if (keyVal[0] == "bNeutered")
                    {
                        dino.IsNeutered = Convert.ToBoolean(keyVal[1]);
                    } else if (keyVal[0] == "TamerString")
                    {
                        dino.TamedBy = keyVal[1];
                    } else if (keyVal[0] == "ImprinterName")
                    {
                        dino.ImpritedBy = keyVal[1];
                    } else if (keyVal[0] == "CharacterLevel")
                    {
                        dino.Level = int.Parse(keyVal[1]);
                    }
                    else if (keyVal[0] == "DinoImprintingQuality")
                    {
                        dino.DinoImprintQuality = float.Parse(keyVal[1]);
                    } else if (keyVal[0] == "Health")
                    {
                        dino.Stats.Health = float.Parse(keyVal[1]);
                    } else if (keyVal[0] == "Stamina")
                    {
                        dino.Stats.Stamina = float.Parse(keyVal[1]);
                    }
                    else if (keyVal[0] == "Torpidity")
                    {
                        dino.Stats.Torp = float.Parse(keyVal[1]);
                    }
                    else if (keyVal[0] == "Oxygen")
                    {
                        dino.Stats.Oxygen = float.Parse(keyVal[1]);
                    }
                    else if (keyVal[0] == "food")
                    {
                        dino.Stats.Food = float.Parse(keyVal[1]);
                    }
                    else if (keyVal[0] == "Weight")
                    {
                        dino.Stats.Weight = float.Parse(keyVal[1]);
                    }
                    else if (keyVal[0] == "Melee Damage")
                    {
                        dino.Stats.Melee = float.Parse(keyVal[1]);
                    }
                    else if (keyVal[0] == "Crafting Skill")
                    {
                        dino.Stats.CraftingSkill = float.Parse(keyVal[1]);
                    }

                }  
            }
            return dino;
       }

   }
}
