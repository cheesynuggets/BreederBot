using BreederBot.Utils;
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

        public DinoModel(int id1, int id2, string dinoNameTag, bool isFemale, string tamedBy, string impritedBy, int level, float dinoImprintQuality, bool isNeutered, StatModel stats)
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
        [LiteDB.BsonId]
        public int uniqueID => new CantorGenerator(Id1, Id2).CantorPair;
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
