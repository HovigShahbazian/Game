using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager: MonoBehaviour {

   public static float WorldTime = 0;

	private static TimeManager eventManager;

	public static TimeManager instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = FindObjectOfType(typeof(TimeManager)) as TimeManager;

				if (!eventManager)
				{
					Debug.LogError("There needs to be one active Time Manager script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init();
				}
			}

			return eventManager;
		}
	}

    private void Update()
    {
		AddWorldTime(Time.deltaTime);

	}



    void Init()
	{
		
	}


	public static void AddWorldTime(float time)
    {
        WorldTime += time;
    }

    private void OnGUI()
    {
		GUI.TextArea(new Rect(50, 50, 200, 100), WorldTime.ToString());
    }



}
