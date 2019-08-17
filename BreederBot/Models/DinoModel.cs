using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreederBot.Models
{
    public class DinoModel
    {
        public DinoModel()
        {
        }

        public DinoModel(int id1, int id2, string dinoNameTag, bool isFemale, string tamedBy, string impritedBy, int level, int dinoImprintQuality, bool isNeutered, StatModel stats)
        {
            Id1 = id1;
            Id2 = id2;
            DinoNameTag = dinoNameTag;
            IsFemale = isFemale;
            TamedBy = tamedBy;
            ImpritedBy = impritedBy;
            Level = level;
            DinoImprintQuality = dinoImprintQuality;
            IsNeutered = isNeutered;
            Stats = stats;
        }

        public int Id1{ get; set; }
        public int Id2 { get; set; }
        public string DinoNameTag { get; set; }
        public bool IsFemale { get; set; }
        public string TamedBy { get; set; }
        public string ImpritedBy { get; set; }
        public int Level { get; set; }
        public int DinoImprintQuality { get; set; }
        public bool IsNeutered { get; set; }
        public StatModel Stats { get; set; }

    }
}
