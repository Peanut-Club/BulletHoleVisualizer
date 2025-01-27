using Decals;
using HarmonyLib;
using InventorySystem.Items.Firearms.Modules;
using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NWAPIBulletHoleVisualizer
{
    [HarmonyPatch(typeof(ImpactEffectsModule), nameof(ImpactEffectsModule.ServerSendImpactDecal))]
    internal class BulletHolePatch
    {
        public static void Postfix(ImpactEffectsModule __instance, RaycastHit hit, DecalPoolType decalType)
        {
            //Player shooter = Player.Get(__instance.Hub);
            if (decalType == DecalPoolType.Bullet || decalType == DecalPoolType.Buckshot) {
                Utils.AddBulletHole(__instance.Firearm.Owner, hit.point);
            }
        }
    }
}
