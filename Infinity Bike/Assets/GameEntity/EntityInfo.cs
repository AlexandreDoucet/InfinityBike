using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityInfo : MonoBehaviour
{
    public enum ENTITYTYPE{PLAYER = 1, NPC_RIDER = 2 };
    public ENTITYTYPE type;

    private new Transform transform;

    // Start is called before the first frame update
    void Start()
    {
       

        transform = GetComponent<Transform>();
        EntityManager.EntityInfoList.Add(this);
    }   

    // Update is called once per frame
    void Update()
    {   
        FindClosest(ENTITYTYPE.NPC_RIDER);
    }   


    void FindClosest(ENTITYTYPE type)
    {


        if (EntityManager.entityDistanceList.ContainsKey(this))
        {
            bool first = true;
            bool found = false;
            KeyValuePair<EntityInfo, double> closest;


            foreach (KeyValuePair<EntityInfo, double> item in EntityManager.entityDistanceList[this])
            {
                if (first || item.Value < closest.Value)
                {
                    closest = item;
                    found = true;
                }

                first = false;
            }

            if (found)
            {   
             //   Debug.DrawLine(transform.position, closest.Key.transform.position);
            }   
        }



    }   



}
