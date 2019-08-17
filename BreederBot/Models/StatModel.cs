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

        public StatModel(float health, float stamina, float torp, float oxygen, float food, float water, float weight,
                         float melee, float movement, float fortitude, float craftingSkill, int dinoAncestorCount,
                         int maleMutations, int femaleMutations)
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

        public float Health { get; set; }
        public float Stamina { get; set; }
        public float Torp { get; set; }
        public float Oxygen { get; set; }
        public float Food { get; set; }
        public float Water { get; set; }
        public float Weight { get; set; }
        public float Melee { get; set; }
        public float Movement { get; set; }
        public float Fortitude { get; set; }
        public float CraftingSkill { get; set; }
        public int DinoAncestorCount { get; set; }
        public int MaleMutations { get; set; }
        public int FemaleMutations { get; set; }
    }
}
