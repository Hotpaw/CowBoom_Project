using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float bulletSpeed = 30;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
       
        Destroy(gameObject, 1);
    }

    
}
