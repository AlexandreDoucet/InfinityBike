using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntensityBarManager : MonoBehaviour {
    public ArduinoThread storageValue;
    public Image[] bars;
    public int maxSpeed = 100;
    public int target;
    public int powerInt; 
    private Blinker blinker; 

    private int numBar;
    private int speed;
    public  Color[] colors;


	// Use this for initialization
	void Start () {
        numBar = bars.Length;
        blinker = GetComponent<Blinker>();

       //colors = new Color[numBar];
       // for (int i = 0; i < numBar; i++)
        //{
            ///colors[i] = b
        //}
	}
    public void SetTargetPower(int targetValue)
    {
        target = targetValue;
    }
   

    // Update is called once per frame
    void Update () {
        speed = storageValue.arduinoInfo.arduinoValueStorage.rawSpeed;

        powerInt = 0; 
        for (int i = 0; i < numBar; i++)
        {
            int j = numBar - i - 1;
            Image bar = bars[i];
            float alpha = 0.1f;

            if ((float) speed /(float) maxSpeed > (float)(j + 1) /(float) numBar){
                alpha = 1f;
                if (j > powerInt)
                {
                    powerInt = j;
                }

            }




            bar.color = new Color(colors[j].r,colors[j].g, colors[j].b, alpha);

        }
        powerInt++;
        Debug.Log(powerInt);
        UpdateTargetPower();


		
	}
    public void UpdateTargetPower()
    {
        for(int j = 0; j<bars.Length; j++)
        {
            if (j < target)

            {
                if (powerInt > j)
                {
                    blinker.restState[j] = true;
                    blinker.isBlinking[j] = false;
                }
                else
                {
                    blinker.isBlinking[j] = true;
                    blinker.restState[j] = false;
                }


            }
            else
            {
                blinker.restState[j] = false;
                blinker.isBlinking[j] = false;
            }

        }


    }

}
