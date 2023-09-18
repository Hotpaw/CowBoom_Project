using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class cattle_tracking : MonoBehaviour
{

    public GameObject target;
    public GameObject escape;
    public GameObject child;
    public cattle_script drop_check;
    public cattle_script carried_check;
    public float speed;
    public int ID;
    bool carrying_cattle = false;
    bool dropped_cattle = false;
    bool catching = true;
    Vector2 target_position;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;


        if (!carrying_cattle && catching) 
        {
            target_position = target.transform.position;                     
        }

        if (transform.position ==  target.transform.position)
        {
            carried_check.carried = true;
            carrying_cattle = true;
            catching = false;
            target_position = escape.transform.position;

        }
        if (transform.position == escape.transform.position) 
        {
            carried_check.carried = false;
            drop_check.dropped = true;
            carrying_cattle=false;
            Invoke("retrack", 2);
        }

        transform.position = Vector2.MoveTowards(transform.position, target_position, step);
    }

    void retrack()
    {
        catching = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Cattle"))
            {
                // Insert code what happens when this object collides with a cattle
                // Note, You must have a 2dTriggerCollider on both objects AND might need a rigidbody on either the cattle or alien
            }
        }
    }



}
