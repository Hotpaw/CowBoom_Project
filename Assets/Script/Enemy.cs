using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public cattle_script cattle;
    public GameObject[] bodyParts;
    public UFO_tracking kill_count;
    // Start is called before the first frame update
    void Start()
    {
        cattle = FindObjectOfType<cattle_script>();
        kill_count = FindObjectOfType<UFO_tracking>();
    }

    // Update is called once per frame
    public void TakeDamage(int a)
    {
        health -= a;
        if(health < 0)
        {
            kill_count.enemies--;
            cattle.carried = false;
            Invoke("kill_alien", 0.1f);
            Invoke("BodyParts", 0.1f);
        }
    }
    public void BodyParts()
    {
        foreach(var part in bodyParts)
        {
            Instantiate(part, transform.position, Quaternion.identity);
        }
    }

    void kill_alien() 
    {
        gameObject.SetActive(false);
    }

}
