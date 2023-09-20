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
        dropped = false;
  
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;


        if (carried)
        {


            float parent_y = transform.parent.position.y;
            Vector2 Parent_pos = new Vector2(0,1);
            transform.localPosition = Parent_pos;




        }

        if (!carried)
        {
            //if (dropped)
            //{


            //    dropped = false;
            //    carried = false;
            //}
            Debug.Log("dropped");
            transform.SetParent(null);
        }

        if (UFO_lifted)
        {
            transform.position = Vector2.MoveTowards(transform.position, UFO.position, step * 0.3f);
        }


        if(!UFO_lifted && !carried)
        {
            transform.position = Vector2.MoveTowards(transform.position, grass.position, step);
        }

    }
}
