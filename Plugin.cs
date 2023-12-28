using System;
using BepInEx;
using UnityEngine;
using Utilla;

namespace LegMod
{
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;
		

		void Start()
		{
			Utilla.Events.GameInitialized += OnGameInitialized;
		}

		void OnEnable()
		{
			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			HarmonyPatches.RemoveHarmonyPatches();
		}

		void OnGameInitialized(object sender, EventArgs e)
		{

		}

		void Update()
		{

		}

		/* This attribute tells Utilla to call this method when a modded room is joined */
		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{

				GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

				Transform leftarmtrans = leftarm.transform;

				leftarmtrans.position += new Vector3(0f, -0.2f, 0f); 
				Debug.Log(leftarm, leftarmtrans);
				GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

	            Transform rightarmtrans = rightarm.transform;

	            rightarmtrans.position += new Vector3(0f, -0.2f, 0f);
			inRoom = true;
		}

		/* This attribute tells Utilla to call this method when a modded room is left */
		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
				GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

				Transform leftarmtrans = leftarm.transform;

				leftarmtrans.position += new Vector3(0f, 0.2f, 0f); 
				Debug.Log(leftarm, leftarmtrans);
				GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

				Transform rightarmtrans = rightarm.transform;

				rightarmtrans.position += new Vector3(0f, 0.2f, 0f);
			inRoom = false;
		}
	}
}
