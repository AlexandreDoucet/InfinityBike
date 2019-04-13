using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    public Image[] barIms; 
    private float lastToggleTime;
    public float togglePeriod = 0.2f;
    private bool barState = false;
    public bool[] isBlinking;
    public bool[] restState; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastToggleTime + togglePeriod)
        {
            ToggleBarState();
            lastToggleTime = Time.time;
        }

    }
    void ToggleBarState()
    {
        barState = !barState;
        UpdateBar();

    }
    public void SetBlinkingPeriod(float period)
    {
        togglePeriod = period;
    }
    void UpdateBar()
    {
        for (int i =0; i < barIms.Length; i++)
        {
            if (isBlinking[i])
            {
                barIms[i].enabled = barState;
            }
            else
            {
                barIms[i].enabled = restState[i];
            }

        }

    }

}
