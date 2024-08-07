using HarmonyLib;
using UnityEngine;

namespace MalumMenu;

[HarmonyPatch(typeof(PlayerPhysics), nameof(PlayerPhysics.LateUpdate))]
public static class PlayerPhysics_LateUpdate
{
    public static void Postfix(PlayerPhysics __instance)
    {

        MalumESP.playerNametags(__instance);
        MalumESP.seeGhostsCheat(__instance);

        MalumCheats.noClipCheat();
        MalumCheats.speedBoostCheat();
        MalumCheats.murderAllCheat();
        MalumCheats.reviveAllCheat();
        MalumCheats.teleportCursorCheat();
        MalumCheats.completeMyTasksCheat();
        MalumCheats.ForceAumRpcCheat();

        MalumCheats.impostorHackCheat();

        MalumPPMCheats.spectatePPM();
        MalumPPMCheats.murderPlayerPPM();
        MalumPPMCheats.revivePlayerPPM();
        MalumPPMCheats.teleportPlayerPPM();
        MalumPPMCheats.changeRolePPM();

        TracersHandler.drawPlayerTracer(__instance);

        GameObject[] bodyObjects = GameObject.FindGameObjectsWithTag("DeadBody");
        foreach(GameObject bodyObject in bodyObjects) // Finds and loops through all dead bodies
        {
            DeadBody deadBody = bodyObject.GetComponent<DeadBody>();

            if (deadBody){
                if (!deadBody.Reported){ // Only draw tracers for unreported dead bodies
                    TracersHandler.drawBodyTracer(deadBody);
                }
            }
        }
    }
}