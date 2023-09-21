using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;

public class DayCycle : MonoBehaviour
{
    public GameObject ScreenColor;
    
    public bool day;
    public float a;
    SpriteRenderer sr;
    public Color night;
    // Start is called before the first frame update
    void Start()
    {
        sr = ScreenColor.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      
        DayToNight();
    }
    public  void DayToNight()
    {
        if(day == false)
        {
            if (a < 0.7)
            {
                a += Time.deltaTime;
            }
            else
            {
                return;
            }
        
        }else if(day == true)
        {
            if (a > 0)
            {
                a -= Time.deltaTime;
            }
            else
            {
                return;
            }
        }
        night.a = a;
        sr.color = night;
    }
    public void ChangeDayTime()
    {
        if (day)
        {
            day = false;
        }
        else
        {
            day = true;
        }
    }
      
}
