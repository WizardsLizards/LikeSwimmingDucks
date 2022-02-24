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

        public static void behaviors_Prefix(FarmAnimal __instance, GameTime time, GameLocation location)
        {
            try
            {
                //TODO: If tile is reserved: move to it

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
        }

        public static searchWaterTile()
        {

        }

        public static searchLandTile()
        {

        }

        public static getTilesInWaterRadius()
        {

        }

        public static getTilesInLandRadius()
        {

        }
    }
}
