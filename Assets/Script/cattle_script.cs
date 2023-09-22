using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cattle_script : MonoBehaviour
{
    public bool carried = false;
    public bool dropped = false;
    public bool UFO_lifted = false;
    public bool UFO_dropped;
    bool released;
    public Transform alien;
    public Transform grass;
    public Transform UFO;
    public Transform UFO_beam;
    public float y_offset;
    public float speed;
    bool in_ufo;

    // Start is called before the first frame update
    void Start()
    {
        dropped = true;
        UFO_dropped = false;
        released = true;
        in_ufo = false;
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;


        if (carried)
        {
            float parent_y = transform.parent.position.y;
            Vector2 Parent_pos = new Vector2(0,2f);
            transform.localPosition = Parent_pos;
        }



        if (UFO_lifted)
        {
            if (!in_ufo)
            {
                transform.position = Vector2.MoveTowards(transform.position, UFO.position, step * 0.3f);
                released = false;
                Invoke("inside_ufo", 2f);
            }
            if (in_ufo)
            {
                transform.position = Vector2.MoveTowards(transform.position, UFO.position, step * 1.5f);
            }
        }

        if (UFO_dropped && !released)
        {
            in_ufo = false;
            transform.position = Vector2.MoveTowards(transform.position, UFO_beam.position, step * 0.3f);
            Invoke("dropped_complete", 3f);
        }


        if(!UFO_lifted && !carried && released)
        {
            transform.position = Vector2.MoveTowards(transform.position, grass.position, step);
        }

    }

    void dropped_complete()
    {
        UFO_dropped = false;
        UFO_lifted = false;
        carried = false;
        released = true;
    }

    public void remove_parent()
    {
        transform.SetParent(null);
    }
    void inside_ufo()
    {
        in_ufo = true;
    }
}
