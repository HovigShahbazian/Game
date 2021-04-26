using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField]
	public float TimeSinceStarted;

	public float timeToWait;

	public delegate void TimerDelegate();

	public event TimerDelegate startedTime;

	public event TimerDelegate finishedTime;



	public void StartTimer()
	{
		startedTime.Invoke();
		Debug.Log("Time started");
		TimeSinceStarted = TimeManager.WorldTime;
		StartCoroutine("WaitTime");

	}

	IEnumerator WaitTime()
	{
		yield return new WaitForSeconds(timeToWait);
		var diff = TimeSinceStarted - TimeManager.WorldTime;
		Debug.Log("Time spent : " + diff);
		finishedTime.Invoke();
	}
}
