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
     if(night.a != 195)
        {
            night.a += Time.deltaTime / 2;
            sr.color = night;
        }
        else if(night.a == 195) {
            night.a = 195;
            sr.color = night;
        }
    }
}
