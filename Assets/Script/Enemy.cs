using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public cattle_script cattle;
    public GameObject[] bodyParts;
    // Start is called before the first frame update
    void Start()
    {
        cattle = FindObjectOfType<cattle_script>();
    }

    // Update is called once per frame
    public void TakeDamage(int a)
    {
        health -= a;
        if(health < 0)
        {
            cattle.carried = false;
            BodyParts();
            gameObject.SetActive(false);
        }
    }
    public void BodyParts()
    {
        foreach(var part in bodyParts)
        {
            Instantiate(part, transform.position, Quaternion.identity);
        }
    }

}
