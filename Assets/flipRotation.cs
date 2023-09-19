using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipRotation : MonoBehaviour
{
    public float a
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(transform.position.x < mouseWorldPos.x)
        {
            transform.rotation = Quaternion.Euler(transform.localRotation.x, 0, transform.localRotation.z);
        }
        else if(transform.position.x > mouseWorldPos.x)
        {
            transform.rotation = Quaternion.Euler(transform.localRotation.x, 180, transform.localRotation.z);
        }
    }
}
