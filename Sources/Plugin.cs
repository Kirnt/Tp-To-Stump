using BepInEx;
using System;
using UnityEngine;
using Utilla;

namespace Tp_To_Stump
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;

        void Start()
        {
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */

            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            /* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
        }

        void Update()
        {
            /* Code here runs every frame when the mod is enabled */
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            //Theres a thingy here that i dont remember how it looks, something like [moddedGamemode] or something
            void OnLeave() //code here runs when leaving a modded lobby
            {
                //You can add code here if needed
                inRoom = true;
            } // This part is already in the graic mod template
              //Theres a thingy here that i dont remember how it looks, something like [moddedGamemode] or something 
            void OnJoin() // checks if the player joins a modded room(the thing behind is required)
            {
                // Feel free to add code here
                inRoom = true;
            } // This is also built in the modding template 

            //Now you can do checks with 
            if (inRoom)

            {
                // Put code here 
            }
            //And
            if (!inRoom)
            {
                // Put code here
            }

            //This is mainly useful in
            void Update()
            {
                if (inRoom)
                {
                    //Code here will run every frame when in a room
                }
            }

            inRoom = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            /* Deactivate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = false;
        }
    }
}
