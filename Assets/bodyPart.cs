using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bodyPart : MonoBehaviour
{   Vector2 position = Vector2.zero;
    int randomX;
    int randomY;
    float force;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        transform.Rotate(Vector3.up);
        force = Random.Range(5, 10);
        randomX = Random.Range(0, 360);
        randomY = Random.Range(0, 360);
        rb = GetComponent<Rigidbody2D>();
       
        position = new Vector2(randomX, randomY);

        rb.AddForce(position * force, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
