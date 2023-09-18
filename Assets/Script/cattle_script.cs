using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cattle_script : MonoBehaviour
{
    public bool carried = false;
    public bool dropped = false;
    public bool UFO_lifted = false;
    public Transform alien;
    public Transform grass;
    public Transform UFO;
    public float y_offset;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;


        if (carried)
        {
            transform.parent = alien.transform;
            float pos_x = alien.position.x;
            float pos_y = alien.position.y;
            Vector2 relative_position = new Vector2(0, pos_y + y_offset);
            transform.localPosition = relative_position;

        }

        if (!carried)
        {
            if (dropped)
            {
                float pos_x = alien.position.x;
                float pos_y = alien.position.y;
                Vector2 relative_position = new Vector2(pos_x, pos_y);
                transform.position = relative_position;
                dropped = false;
            }

            transform.SetParent(null);
        }

        if (UFO_lifted)
        {
            transform.position = Vector2.MoveTowards(transform.position, UFO.position, step);
        }


        if(!UFO_lifted && !carried)
        {
            transform.position = Vector2.MoveTowards(transform.position, grass.position, step);
        }

    }
}
