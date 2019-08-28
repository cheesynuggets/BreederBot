using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BreederBot.Models
{
    public class StatModel
    {
        public StatModel()
        {
        }
        public float Health { get; set; }
        public float Stamina { get; set; }
        public float Torp { get; set; }
        public float Oxygen { get; set; }
        public float Food { get; set; }
        public float Weight { get; set; }
        public float Melee { get; set; }
        public float Movement { get; set; }
        public float Fortitude { get; set; }
        public float CraftingSkill { get; set; }
        public float DinoAncestorCount { get; set; }
        public float MaleMutations { get; set; }
        public float FemaleMutations { get; set; }
    }
}
