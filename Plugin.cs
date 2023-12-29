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
		bool isEnabled;
		bool isBean;
		bool isChimp;
		bool isWarned;

		public void GetConfigs()
        {
			bool BeanMode = Config.Bind("Bean", "Bean", false, "makes you a bean, simple.").Value;
			bool ChimpMode = Config.Bind("Chimp", "Chimp", false, "Makes you look like a chimpanzee!").Value;
			if (!isChimp)
			{
				isBean = BeanMode;
			}
			if (!isBean)
			{
				isChimp = ChimpMode;
			}
			if(isChimp && isBean)
            {
				isWarned = true;
            }
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
