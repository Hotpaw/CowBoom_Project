using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TakeDamage(int a)
    {
        health -= a;
        if(health < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
