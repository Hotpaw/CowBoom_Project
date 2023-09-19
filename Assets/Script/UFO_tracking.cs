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
    Vector2 target_position;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Cattle");
        child = GameObject.FindGameObjectWithTag("Cattle");
        cattle = FindAnyObjectByType<cattle_script>();
        speed = 0.8f;
    }


    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;


        if (!carrying_cattle)
        {
            target_position = target.transform.position;
        }

        if (transform.position == target.transform.position)
        {
            cattle.UFO_lifted = true;
            carrying_cattle = true;
            Invoke("Escape", 2.5f);

        }
        //if (transform.position == escape.transform.position)
        //{
        //    carried_check.carried = false;
        //    drop_check.dropped = true;
        //    carrying_cattle = false;
        //}

        transform.position = Vector2.MoveTowards(transform.position, target_position, step);
    }
    void Escape()
    {
        target_position = escape.transform.position;
    }
}
