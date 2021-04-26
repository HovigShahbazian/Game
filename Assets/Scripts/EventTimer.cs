using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTimer : MonoBehaviour {

	
	private float TimeSinceStarted;

	public bool IsRepeating = false;

	public float timeToWait;

	public string StartTimerEvent = "StartEvent";

	public string TimerStartedEvent;

	public string TimerFinishedEvent;


	void Start () {
		if (StartTimerEvent != "")
			EventManager.StartListening(StartTimerEvent, StartTimer);
		else
			StartTimer();
	}
	

	public void StartTimer()
	{
		Debug.Log("Time started");
		if (TimerStartedEvent != "")
			EventManager.TriggerEvent(TimerStartedEvent);
		TimeSinceStarted = TimeManager.WorldTime;
		StartCoroutine("WaitTime");
		
	}
	
	void Update () {
		
	}

	IEnumerator WaitTime()
	{
		do
		{
			yield return new WaitForSeconds(timeToWait);
			var diff = TimeSinceStarted - TimeManager.WorldTime;
			if (TimerFinishedEvent != "")
				EventManager.TriggerEvent(TimerFinishedEvent);
		}
		while (IsRepeating);
	}
}
