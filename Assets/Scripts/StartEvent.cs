using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent : MonoBehaviour
{
    public string StartEventName = "StartEvent";

    // Start is called before the first frame update
    void Start()
    {
        if(StartEventName != "")
            EventManager.TriggerEvent(StartEventName);
    }
}
