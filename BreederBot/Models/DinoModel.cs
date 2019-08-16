using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreederBot.Models
{
    public class DinoModel
    {
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
