using HarmonyLib;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System;

namespace LikeSwimmingDucks
{
    public class ModEntry : StardewModdingAPI.Mod
    {
        public override void Entry(IModHelper IHelper)
        {
            #region Setup
            var csHarmony = new Harmony(this.ModManifest.UniqueID);

            ObjectPatches.Initialize(this.Monitor, IHelper);
            #endregion Setup

            #region Harmony Patches
            csHarmony.Patch(
               original: AccessTools.Method(typeof(FarmAnimal), "behaviors"),
               prefix: new HarmonyMethod(typeof(ObjectPatches), nameof(ObjectPatches.behaviors_Prefix))
            );
            #endregion Harmony Patches

            #region Events

            #endregion Events
        }
    }
}
