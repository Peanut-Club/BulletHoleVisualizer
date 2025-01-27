using HarmonyLib;
using MapGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static HarmonyLib.AccessTools;

namespace NWAPIBulletHoleVisualizer
{
    /*
    [HarmonyPatch(typeof(SeedSynchronizer), nameof(SeedSynchronizer.Start))]
    public class MapGenPatch
    {
        public static int GetSeed() 
        { 
            if (Utils.NextSeed != -1)
            {
                return Utils.NextSeed;
            }
            return UnityEngine.Random.Range(1, int.MaxValue);
        }

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            var newInstructions = instructions.ToList();
            var offsetIndex = newInstructions.FindIndex(x => x.opcode == OpCodes.Bge_S) + 1;

            newInstructions.RemoveRange(offsetIndex, 3);
            newInstructions.Insert(offsetIndex, new CodeInstruction(OpCodes.Call, Method(typeof(MapGenPatch), nameof(MapGenPatch.GetSeed))));

            foreach (var code in newInstructions)
                yield return code;
        }
    }
    */
}
