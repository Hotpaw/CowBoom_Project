using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class UFO_tracking : MonoBehaviour
{

    public GameObject target;
    public GameObject escape;
    public GameObject child;
    public cattle_script cattle;
    public float speed;
    public int ID;
    bool carrying_cattle = false;
    public bool healthy = true;
    bool cattle_dropped;
    public int health;
    public int enemies;
    float step;
    Vector2 target_position;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Cattle");
        child = GameObject.FindGameObjectWithTag("Cattle");
        cattle = FindAnyObjectByType<cattle_script>();
        speed = 0.8f;
        enemies = 20;
        //health = 90;
    }


    // Update is called once per frame
    void Update()
    {
        if (enemies <= 10)
        {
            step = speed * Time.deltaTime;
        }
        if (enemies > 10)
        {
            step = 0;
        }


        if (!carrying_cattle && healthy)
        {
            target_position = target.transform.position;
        }

        if (transform.position == target.transform.position && healthy)
        {
            cattle.UFO_lifted = true;
            carrying_cattle = true;
            Invoke("Escape", 2.5f);
        }

        if (health <= 60)
        {
            if (!cattle_dropped) 
            { 
                target_position = transform.position;
            }
            healthy = false;
            cattle.UFO_dropped = true;
            cattle.UFO_lifted = false;
            Invoke("Resume_escape", 3.5f);

        }
        
        transform.position = Vector2.MoveTowards(transform.position, target_position, step);

    }
    void Escape()
    {
        target_position = escape.transform.position;
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            cattle.UFO_lifted = true;
            carrying_cattle = false;
        }
    }



    void Resume_escape()
    {
        cattle_dropped = true;
        target_position = escape.transform.position;
    }


}
