using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour

{
    public UFO_tracking UFO_script;


    // Start is called before the first frame update
    void Start()
    {
        UFO_script = GameObject.FindFirstObjectByType<UFO_tracking>();
    }

    public void TakeDamage(int a)
    {
        UFO_script.health -= a;
    }

    void Update() 
    {
        Vector2 position = new Vector2(0, 3);
        transform.localPosition = position;
    }

}
