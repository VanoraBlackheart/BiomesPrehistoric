﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;

namespace BiomesPrehistoric
{
    [HarmonyPatch(typeof(BiomeDef), "CommonalityOfAnimal")]
    public static class AnimalSpawnPatch
    {
        static bool Prefix(PawnKindDef animalDef, List<BiomeAnimalRecord> ___wildAnimals, ref float __result)
        {
            if(BiomesPrehistoricMod.mod.settings.dinoOnly)
            {
                if(___wildAnimals.Any(d => d.animal.modContentPack.Name == "Biomes! Prehistoric"))
                {
                    if (animalDef.modContentPack.Name != "Biomes! Prehistoric")
                    {
                        __result = 0f;
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
