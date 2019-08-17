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

        public DinoModel(int id, string dinoNameTag, bool isFemale, string tamedBy, string impritedBy, int level, float dinoImprintQuality, bool isNeutered, StatModel stats)
        {
            Id = id;
            DinoNameTag = dinoNameTag;
            IsFemale = isFemale;
            TamedBy = tamedBy;
            ImpritedBy = impritedBy;
            Level = level;
            DinoImprintQuality = dinoImprintQuality;
            IsNeutered = isNeutered;
            Stats = stats;
        }

        public int Id{ get; set; }
        public string DinoNameTag { get; set; }
        public bool IsFemale { get; set; }
        public string TamedBy { get; set; }
        public string ImpritedBy { get; set; }
        public int Level { get; set; }
        public float DinoImprintQuality { get; set; }
        public bool IsNeutered { get; set; }
        public StatModel Stats { get; set; }

    }
}
