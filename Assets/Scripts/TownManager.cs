using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TownManager : MonoBehaviour
{
	[SerializeField]
	private Dictionary<string, TownStatus> townDictionary;

	private Dictionary<string, TownInteraction> townInteractions;

	[SerializeField]
	public TownStatus[] initialTowns;

	public string TownName;

	//Town Graph

	public void EndEdit(string townName)
	{
		TownName = townName;
	}


	private static TownManager townManager;

	public static TownManager instance
	{
		get
		{
			if (!townManager)
			{
				townManager = FindObjectOfType(typeof(TownManager)) as TownManager;

				if (!townManager)
				{
					Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else
				{
					townManager.Init();
				}
			}

			return townManager;
		}
	}

	

	void Init()
	{
		if (townDictionary == null)
		{
			townDictionary = new Dictionary<string, TownStatus>();
			townInteractions = new Dictionary<string, TownInteraction>();

			foreach (TownStatus t in initialTowns)
			{
				townDictionary.Add(t.town.name, t);
				townInteractions.Add(t.town.name, t.townInteraction);
			}


			//EventManager.StartListening("WorldUpdate", UpdateAllTowns);
			EventManager.StartListening("WorldUpdate", UpdateAllTownsInteractions);
		}
	}

    private void Awake()
    {
		Init();

	}




    public static void AddInteraction(string townName, ref TownInteraction interaction)
	{
		
			instance.townInteractions.Add(townName, interaction);

	}

	public static void RemoveInteraction(string interactionName, ref TownInteraction interaction)
	{
		if (!instance.townInteractions.TryGetValue(interactionName, out interaction))
		{
			instance.townInteractions.Remove(interactionName);
		}
	}

	public static void AddTown(string townName, TownStatus townstatus)
	{
		instance.townDictionary.Add(townName, townstatus);
	}

	public void AddTown(string townName)
	{
		instance.townDictionary.Add(townName, new TownStatus());
	}

	public  Town GetTown(string townName)
	{
		return instance.townDictionary[townName].town;
	}


	public static void RemoveTown(string townName, TownStatus townstatus)
	{
		if (townManager == null) return;

		if (instance.townDictionary.TryGetValue(townName, out townstatus))
		{
			instance.townDictionary.Remove(townName);
		}
	}

	public static void TriggerEvent(string townName)
	{
		TownStatus townStatus = null;
		if (instance.townDictionary.TryGetValue(townName, out townStatus))
		{
			//townStatus.FdIncrease++;
		}
	}


	public static void UpdateAllTowns()
	{
		foreach (TownStatus t in instance.townDictionary.Values)
		{
			t.town.food++;
		}
	}

	public static void UpdateAllTownsInteractions()
	{
		foreach( TownInteraction t in instance.townInteractions.Values)
		{
			TownStatus townStatus = null;
			if (instance.townDictionary.TryGetValue(t.Effected, out townStatus))
			{
				switch (t.stat)
				{
					case TownStats.Food:
						townStatus.town.food += t.UpdateValue;
						break;
					case TownStats.Population:
						townStatus.town.Population += t.UpdateValue;
						break;						
					case TownStats.Wealth:
						townStatus.town.wealth += t.UpdateValue;
						break;
				}
				
			}
		}
	}
}
