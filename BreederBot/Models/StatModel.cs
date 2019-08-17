using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreederBot.Models
{
    public class StatModel
    {
        public StatModel()
        {
        }

        public StatModel(ulong health, uint stamina, uint torp, uint oxygen, uint food, uint water, uint weight, uint melee, uint movement, uint fortitude, uint craftingSkill, uint dinoAncestorCount, uint maleMutations, uint femaleMutations)
        {
            Health = health;
            Stamina = stamina;
            Torp = torp;
            Oxygen = oxygen;
            Food = food;
            Water = water;
            Weight = weight;
            Melee = melee;
            Movement = movement;
            Fortitude = fortitude;
            CraftingSkill = craftingSkill;
            DinoAncestorCount = dinoAncestorCount;
            MaleMutations = maleMutations;
            FemaleMutations = femaleMutations;
        }

        public ulong Health { get; set; }
        public uint Stamina { get; set; }
        public uint Torp { get; set; }
        public uint Oxygen { get; set; }
        public uint Food { get; set; }
        public uint Weight { get; set; }
        public uint Melee { get; set; }
        public uint Movement { get; set; }
        public uint Fortitude { get; set; }
        public uint CraftingSkill { get; set; }
        public uint DinoAncestorCount { get; set; }
        public uint MaleMutations { get; set; }
        public uint FemaleMutations { get; set; }
    }
}
