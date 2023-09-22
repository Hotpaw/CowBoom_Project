using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        if (day)
        {
            TurnToDay();
        }
     
        if (!day)
        {
            TurnToNight();

        }
        night.a = a;
        sr.color = night;
    }


    public void TurnToNight()
    {
       
            if (a < 0.8)
            {
                a += Time.deltaTime / 3;
            }
            else
            {
                return;
            }
      
    }
    public void TurnToDay()
    {
        if (a > 0)
        {
            a -= Time.deltaTime / 3;
        }
        else
        {
            return;
        }
    }
    public void ChangeDayTime(float a, bool b)
    {
        switch (b)
        {
            case true:
                day = true;
                break;
            case false:
                day = false;
                break;
        }

    }
    public void ChangeTimeInvoke(float a, bool b)
    {
        
       
        switch (b)
        {
            case true: day = true;
                break;
            case false: day = false;
                break;
        }
     
    }
      
}
