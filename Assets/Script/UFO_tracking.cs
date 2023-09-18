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
    public cattle_script cattle_script;
    public float speed;
    public int ID;
    bool carrying_cattle = false;
    Vector2 target_position;

    // Start is called before the first frame update
    void Start()
    {

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
            cattle_script.UFO_lifted = true;
            carrying_cattle = true;
            Invoke("Escape", 1.2f);

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
