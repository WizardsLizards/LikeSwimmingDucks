using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeSwimmingDucks
{
    class ObjectPatches
    {
        public static IMonitor IMonitor;
        public static IModHelper IModHelper;

        internal static ModConfig Configuration;

        public static void Initialize(IMonitor IMonitor, IModHelper IHelper)
        {
            ObjectPatches.IMonitor = IMonitor;
            ObjectPatches.IModHelper = IHelper;

            Configuration = IHelper.ReadConfig<ModConfig>();
        }

        public static bool behaviors_Prefix(FarmAnimal __instance, GameTime time, GameLocation location)
        {
            //TODO: Reserved Tile in moddata?

            try
            {
                //TODO: If tile is reserved: move to it (And return false to prevent other logic from overwriting thiss)

                //TODO: Also check whether a grass tile is reserved?
                //If animal can actually swim, it is outdoors, not eating and not bedtime
                if (__instance.CanSwim() && 
                    location.IsOutdoors &&
                    __instance.isEating.Value == false &&
                    Game1.timeOfDay < 1700)
                {
                    //If not swimming
                    if (!__instance.IsActuallySwimming())
                    {
                        //Swim if petting config and fullness config match and chance is hit
                        if ((__instance.wasPet.Value || __instance.wasAutoPet.Value) == Configuration.SwimOnlyWhenPet || (__instance.wasPet.Value || __instance.wasAutoPet.Value) &&
                            __instance.fullness.Value > Configuration.FullnessToSwim &&
                            Game1.random.NextDouble() < Configuration.StartSwimmingChance)
                        {
                            //TODO: Search water tile, reserve it
                        }
                    }
                    //If swimming
                    else
                    {
                        //Swim more
                        //Swim if petting config and fullness config match and chance is hit
                        if ((__instance.wasPet.Value || __instance.wasAutoPet.Value) == Configuration.SwimOnlyWhenPet || (__instance.wasPet.Value || __instance.wasAutoPet.Value) &&
                            __instance.fullness.Value > Configuration.FullnessToSwim &&
                            Game1.random.NextDouble() < Configuration.StaySwimmingChance)
                        {
                            //TODO: Search water tile, reserve it
                        }
                        //Stop swimming
                        else if (Game1.random.NextDouble() < Configuration.StopSwimmingChance)
                        {
                            //TODO: Search land tile, reserve it
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IMonitor.Log($"Failed in {nameof(behaviors_Prefix)}:\n{ex}", LogLevel.Error);
            }
            return true;
        }

        public static searchWaterTile()
        {
            //Get all water tiles in radius that are not reserved yet, add to list (a number of times being 1 + neighboring water tiles)
            //get a random entry from list
        }

        public static getTilesInWaterRadius()
        {
            //Already check here if tiles are watertiles?
        }

        //Same logic for land
        public static searchLandTile()
        {

        }

        public static getTilesInLandRadius()
        {

        }
    }
}
