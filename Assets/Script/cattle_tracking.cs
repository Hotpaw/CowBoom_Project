using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class cattle_tracking : MonoBehaviour
{

    public GameObject target;
    public Transform escape;
    public GameObject child;
    public GameObject farmer;
    public cattle_script cattle;
    public float speed;
    public int ID;
    bool carrying_cattle = false;
    bool catching = true;
    Vector2 target_position;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Cattle");
        farmer = GameObject.FindGameObjectWithTag("Player");
        child = GameObject.FindGameObjectWithTag("Cattle");
        cattle = FindObjectOfType<cattle_script>();
        int random = Random.Range(0,FindAnyObjectByType<Spawner>().enemySpawnPoints.Length);
        escape = FindAnyObjectByType<Spawner>().enemySpawnPoints[random];
    }


    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;


        if (!carrying_cattle && catching) 
        {
            target_position = target.transform.position;
            
        }


        if (transform.position == target.transform.position && !carrying_cattle)
        {
            cattle.carried = true;
            carrying_cattle = true;
            catching = false;
            target_position = escape.transform.position;
            target.transform.parent = transform.transform;
            animator.SetBool("Carry", false);
            animator.SetBool("Walk", true);


        }

        if (carrying_cattle)
        {
            animator.SetBool("Carry", true);
            animator.SetBool("Walk", false);

            //Vector2 relative_position = new Vector2(0, 1);
            //target.transform.localPosition = relative_position;



        }


        if (transform.position == escape.transform.position) 
        {
            cattle.carried = false;
            cattle.dropped = true;
            carrying_cattle=false;
            Invoke("retrack", 2);
        }

        if (cattle.carried && !carrying_cattle)
        {
            transform.position = Vector2.MoveTowards(transform.position, farmer.transform.position, step * 0.5f);

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target_position, step);
        }
    }


    void retrack()
    {
        catching = true;
    }




}
