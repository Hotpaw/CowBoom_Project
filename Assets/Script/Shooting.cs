using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bullet;
    public GameObject Weapon;
    public GameObject shooting;
    public GameObject shooting2;
    public GameObject shooting3;
    public GameObject shooting4;
    public GameObject shooting5;

    public float fireRate = 3;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.up = position;


        if(Input.GetMouseButton(0) && timer > fireRate) 
        {
           
            Instantiate(bullet, shooting.transform.position, shooting.transform.rotation);

            Instantiate(bullet, shooting2.transform.position, shooting2.transform.rotation);

            Instantiate(bullet, shooting3.transform.position, shooting3.transform.rotation);

            Instantiate(bullet, shooting4.transform.position, shooting4.transform.rotation);

            Instantiate(bullet, shooting5.transform.position, shooting5.transform.rotation);



            timer = 0;
        }

            
       

        timer += Time.deltaTime;
    }
}
