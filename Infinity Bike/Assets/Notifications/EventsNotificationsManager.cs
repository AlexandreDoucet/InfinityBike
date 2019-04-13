using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsNotificationsManager : MonoBehaviour {
    public Mode mode;
    public TrainingEvent[] trainingEvents;
    public NotificationsManager notificationsManager;
    public IntensityBarManager iBM; 

    private int eventNum;  
	// Use this for initialization
	void Start () {
        eventNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (eventNum < trainingEvents.Length)
        {
            if (Time.time > trainingEvents[eventNum].GetEventTime())
            {

                notificationsManager.PushNotification(trainingEvents[eventNum].eventMessages,trainingEvents[eventNum].persistance);

                iBM.SetTargetPower(trainingEvents[eventNum].targetIntensity);

                eventNum++;
            }

        }


    }
}

[System.Serializable]
public class Mode
{
    public string modeName; 

}
[System.Serializable]
public class TrainingEvent
{
    public string eventName;
    public string eventMessages; 
    public float eventMinute;
    public float eventSecond;
    public float persistance;
    public int targetIntensity; 

    public float GetEventTime()
    {
        return eventMinute * 60f + eventSecond;
    }
}