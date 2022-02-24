using StardewModdingAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeSwimmingDucks
{
    class ModConfig
    {
        //Conditions:
        //If true: Extra logic only triggers when the animal has been pet this day
        public bool SwimOnlyWhenPet { get; set; } = true;
        //How full has the animal to be to go swimming? (max fullness: 255)
        public int FullnessToSwim { get; set; } = byte.MaxValue / 2;

        //Chances:
        //Chance animal searches for water when out of water
        public double StartSwimmingChance { get; set; } = 0.005;
        //Chance animal stays in water
        public double StaySwimmingChance { get; set; } = 0.01;
        //Chance animal gets out of the water
        public double StopSwimmingChance { get; set; } = 0.005;

        //Other:
        //Radius in which to search for water fields if swimming chance is hit
        public int SearchWaterRadius { get; set; } = 15;
        //Radius in which to search for water fields if stop-swimming chance is hit
        public int SearchLandRadius { get; set; } = 15;

        //TODO: Settings for preferring tiles near water when getting out and tiles near land when getting in?
    }
}