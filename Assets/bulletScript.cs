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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<cattle_tracking>().TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("UFO"))
        {
            collision.gameObject.GetComponent<UFO>().TakeDamage(1);
            Destroy(gameObject);
        }
    }


}
