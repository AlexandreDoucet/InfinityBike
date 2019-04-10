using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static Dictionary<EntityInfo, Dictionary<EntityInfo, double>> entityDistanceList = new Dictionary<EntityInfo, Dictionary<EntityInfo, double>>();
    private static List<EntityInfo> entityInfoList = new List<EntityInfo>();
    public static List<EntityInfo> EntityInfoList
    {
        get {return entityInfoList; }
        set
        {   
            entityInfoList.Clear();
            entityInfoList = value;
            UpdateDistanceList();
        }   
    }
 

    private static void UpdateDistanceList()
    {

        foreach (Dictionary<EntityInfo, double> item in entityDistanceList.Values)
        {item.Clear();}
        entityDistanceList.Clear();

        for (int i = 0; i < entityInfoList.Count; i++)
        {

            if(!entityDistanceList.ContainsKey(entityInfoList[i]))
            entityDistanceList.Add(entityInfoList[i], new Dictionary<EntityInfo, double>());

            for (int j = i + 1; j < entityInfoList.Count; j++)
            {

                double distance = Vector3.Distance(entityInfoList[i].transform.position, entityInfoList[j].transform.position);

                entityDistanceList[entityInfoList[i]].Add(entityInfoList[j], distance);

                if (!entityDistanceList.ContainsKey(entityInfoList[j]))
                entityDistanceList.Add(entityInfoList[j], new Dictionary<EntityInfo, double>());

                entityDistanceList[entityInfoList[j]].Add(entityInfoList[i], distance);

            }
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if(!TimedUpdateBlocker)
        {
            StartCoroutine(TimedUpdate());
        }


    }

    bool TimedUpdateBlocker = false;
    IEnumerator TimedUpdate()
    {
        TimedUpdateBlocker = true;
        UpdateDistanceList();
        yield return new WaitForSeconds(2);
        TimedUpdateBlocker = false;

    }

}


