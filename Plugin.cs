using System;
using BepInEx;
using UnityEngine;
using Utilla;
using GorillaNetworking;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using HarmonyLib;

namespace LegMod
{
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;
		bool isEnabled;
		bool isBean;
		bool isChimp;
		bool isWarned;

		public void GetConfigs()
        {
			bool BeanMode = Config.Bind("Leg Modes", "Bean", false, "makes you a bean, simple.").Value;
			bool ChimpMode = Config.Bind("Leg Modes", "Chimp", false, "Makes you look like a chimpanzee!").Value;
			bool Enable = Config.Bind("Extra Settings", "Enabled", true, "Enable the mod, simple.").Value;
			if (!isChimp)
			{
				isBean = BeanMode;
			}
			if (!isBean)
			{
				isChimp = ChimpMode;
			}
			if (isChimp && isBean)
            {
				isWarned = true;
            }
			if(Enable)
            {
				isEnabled = Enable;
            }
			// Unused
			//if(ConstUpdate)
            //{
				//isConstant = ConstUpdate;
			//
		}

		void OnEnable()
		{
			if(inRoom)
            {
				if (!isBean)
				{
					if (!isChimp)
					{
						GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

						Transform leftarmtrans = leftarm.transform;

						leftarmtrans.position += new Vector3(0f, -0.3f, 0f);
						Debug.Log(leftarm, leftarmtrans);
						GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

						Transform rightarmtrans = rightarm.transform;

						rightarmtrans.position += new Vector3(0f, -0.3f, 0f);
					}
					else
					{
						GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

						Transform leftarmtrans = leftarm.transform;

						leftarmtrans.position += new Vector3(0f, 0.1f, 0f);
						Debug.Log(leftarm, leftarmtrans);
						GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

						Transform rightarmtrans = rightarm.transform;

						rightarmtrans.position += new Vector3(0f, 0.1f, 0f);
					}
				}
				else
				{
					GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

					Transform leftarmtrans = leftarm.transform;

					leftarmtrans.position += new Vector3(0f, -999f, 0f);
					Debug.Log(leftarm, leftarmtrans);
					GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

					Transform rightarmtrans = rightarm.transform;

					rightarmtrans.position += new Vector3(0f, -999f, 0f);

				}
			}
			isEnabled = true;
			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			if (inRoom)
			{
				if (!isBean)
				{
					if (!isChimp)
					{
						GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

						Transform leftarmtrans = leftarm.transform;

						leftarmtrans.position += new Vector3(0f, 0.3f, 0f);
						Debug.Log(leftarm, leftarmtrans);
						GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

						Transform rightarmtrans = rightarm.transform;

						rightarmtrans.position += new Vector3(0f, 0.3f, 0f);
					}
					else
					{
						GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

						Transform leftarmtrans = leftarm.transform;

						leftarmtrans.position += new Vector3(0f, -0.1f, 0f);
						Debug.Log(leftarm, leftarmtrans);
						GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

						Transform rightarmtrans = rightarm.transform;

						rightarmtrans.position += new Vector3(0f, -0.1f, 0f);
					}
				}
				else
                {
					GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

					Transform leftarmtrans = leftarm.transform;

					leftarmtrans.position += new Vector3(0f, 999f, 0f);
					Debug.Log(leftarm, leftarmtrans);
					GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

					Transform rightarmtrans = rightarm.transform;

					rightarmtrans.position += new Vector3(0f, 999f, 0f);
				}
			}
			isEnabled = false;
			HarmonyPatches.RemoveHarmonyPatches();
		}

		void Start()
        {
			GetConfigs();
			HideGameManagerObject();
		}
		void Update()
        {	
			// Unused
			/*
			if (isButtonModeChange)
			{
				if (ControllerInputPoller.instance.rightControllerPrimaryButton)
				{
					isBean = !isBean;
				}
				if (ControllerInputPoller.instance.leftControllerPrimaryButton)
				{
					isChimp = !isChimp;
				}
			}
			
			
			if (inRoom)
			{
				GetConfigs();
			}*/
		}

		void HideGameManagerObject()
        {
			string path = Paths.ConfigPath + "/BepInEx.cfg";
			string text = File.ReadAllText(path);
			text = Regex.Replace(text, "HideManagerGameObject = .+", "HideManagerGameObject = true");
			File.WriteAllText(path, text);
		}

		/* This attribute tells Utilla to call this method when a modded room is joined */
		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{
			if (isEnabled)
			{
				if (!isBean)
				{
					if(!isChimp)
                    {
						GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

						Transform leftarmtrans = leftarm.transform;

						leftarmtrans.position += new Vector3(0f, -0.3f, 0f);
						Debug.Log(leftarm, leftarmtrans);
						GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

						Transform rightarmtrans = rightarm.transform;

						rightarmtrans.position += new Vector3(0f, -0.3f, 0f);
                    }
					else
                    {
						GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

						Transform leftarmtrans = leftarm.transform;

						leftarmtrans.position += new Vector3(0f, 0.1f, 0f);
						Debug.Log(leftarm, leftarmtrans);
						GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

						Transform rightarmtrans = rightarm.transform;

						rightarmtrans.position += new Vector3(0f, 0.1f, 0f);
					}
				}
				else
				{
					GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

					Transform leftarmtrans = leftarm.transform;

					leftarmtrans.position += new Vector3(0f, -999f, 0f);
					Debug.Log(leftarm, leftarmtrans);
					GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

					Transform rightarmtrans = rightarm.transform;

					rightarmtrans.position += new Vector3(0f, -999f, 0f);

				}
			}
			inRoom = true;
		}

		/* This attribute tells Utilla to call this method when a modded room is left */
		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
			if (isEnabled)
			{
				if (!isBean)
				{
					if (!isChimp)
					{
						GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

						Transform leftarmtrans = leftarm.transform;

						leftarmtrans.position += new Vector3(0f, 0.3f, 0f);
						Debug.Log(leftarm, leftarmtrans);
						GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

						Transform rightarmtrans = rightarm.transform;

						rightarmtrans.position += new Vector3(0f, 0.3f, 0f);
					}
					else
					{
						GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

						Transform leftarmtrans = leftarm.transform;

						leftarmtrans.position += new Vector3(0f, -0.1f, 0f);
						Debug.Log(leftarm, leftarmtrans);
						GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

						Transform rightarmtrans = rightarm.transform;

						rightarmtrans.position += new Vector3(0f, -0.1f, 0f);
					}
				}
				else
				{
					GameObject leftarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/");

					Transform leftarmtrans = leftarm.transform;

					leftarmtrans.position += new Vector3(0f, 999f, 0f);
					Debug.Log(leftarm, leftarmtrans);
					GameObject rightarm = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/");

					Transform rightarmtrans = rightarm.transform;

					rightarmtrans.position += new Vector3(0f, 999f, 0f);
				}
			}
			inRoom = false;
		}
		void OnGUI()
		{
			// If chimp and bean are on at the same time, give them a warning.
			if (isWarned)
			{
				GUI.color = Color.red;
				GUI.Label(new Rect(0, 0, 200, 200), "WARNING: You cannot use Bean and Chimp at the same time!");
			}
		}
	}
}
