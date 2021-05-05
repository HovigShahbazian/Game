using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TownManager : MonoBehaviour
{

	private Dictionary<SiteName, Town> townDictionary;

	private Dictionary<SiteName, TownInteraction> townInteractions;


	public Town[] initialTowns;

	public TownInteraction[] initialInteraction;


	public TownGraph towngraph;


	public void EndEdit(string townName)
	{
		//TownName = townName;
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
			townDictionary = new Dictionary<SiteName, Town>();
			townInteractions = new Dictionary<SiteName, TownInteraction>();

			foreach (Town t in initialTowns)
			{
				townDictionary.Add(t.name, t);
			}

			foreach (TownInteraction t in initialInteraction)
			{
				townInteractions.Add(t.Effected, t);
			}


			//EventManager.StartListening("WorldUpdate", UpdateAllTowns);
			EventManager.StartListening("WorldUpdate", UpdateAllTownsInteractions);
		}
	}

    private void Awake()
    {
		Init();

	}




    public static void AddInteraction(SiteName townName, ref TownInteraction interaction)
	{
		
			instance.townInteractions.Add(townName, interaction);

	}

	public static void RemoveInteraction(SiteName townName, ref TownInteraction interaction)
	{
		if (!instance.townInteractions.TryGetValue(townName, out interaction))
		{
			instance.townInteractions.Remove(townName);
		}
	}

	public static void AddTown(SiteName townName, Town town)
	{
		instance.townDictionary.Add(townName, town);
	}

	public void AddTown(SiteName townName)
	{
		instance.townDictionary.Add(townName, new Town());
	}

	public  Town GetTown(SiteName townName)
	{
		return instance.townDictionary[townName];
	}


	public static void RemoveTown(SiteName townName, Town town)
	{
		if (townManager == null) return;

		if (instance.townDictionary.TryGetValue(townName, out town))
		{
			instance.townDictionary.Remove(townName);
		}
	}

	public static void TriggerEvent(SiteName townName)
	{
		Town town= null;
		if (instance.townDictionary.TryGetValue(townName, out town))
		{
			//townStatus.FdIncrease++;
		}
	}


	public static void UpdateAllTowns()
	{
		foreach (Town t in instance.townDictionary.Values)
		{
			t.food++;
		}
	}

	public static void UpdateAllTownsInteractions()
	{
		foreach( TownInteraction t in instance.townInteractions.Values)
		{
			Town town = null;
			if (instance.townDictionary.TryGetValue(t.Effected, out town))
			{
				switch (t.stat)
				{
					case SiteStats.Food:
						town.food += t.UpdateValue;
						break;
					case SiteStats.Population:
						town.Population += t.UpdateValue;
						break;						
					case SiteStats.Wealth:
						town.wealth += t.UpdateValue;
						break;
				}
				
			}
		}
	}
}
