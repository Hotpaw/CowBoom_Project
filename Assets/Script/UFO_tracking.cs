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
    public bool healthy = true;
    bool cattle_dropped;
    public int health;
    public int damage_threshold;
    int stage;
    Spawner spawner;
    UIManager UI;
    float step;

    AudioSource ufoSound;

    public AudioClip[] UfogetHit;
    Vector2 target_position;
  
  

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Cattle");
        child = GameObject.FindGameObjectWithTag("Cattle");
        cattle = FindAnyObjectByType<cattle_script>();
        damage_threshold = 0;
        speed = 0.8f;
        UI = FindFirstObjectByType<UIManager>();
        spawner = FindObjectOfType<Spawner>();
        ufoSound = GetComponent<AudioSource>();
        //health = 90;
    }


    // Update is called once per frame
    void Update()
    {

        

      
            step = speed * Time.deltaTime;
     
      


        if (!carrying_cattle && healthy)
        {
            target_position = target.transform.position;
        }

        if (transform.position == target.transform.position && healthy)
        {
            Debug.Log("Lyfterrrr");
            ufoSound.Play();
            cattle.UFO_lifted = true;
            carrying_cattle = true;
            Invoke("Escape", 2.5f);
        }

        if (health <= damage_threshold)
        {
            if (!cattle_dropped) 
            { 
                target_position = transform.position;
            }
            healthy = false;

            UFO ufo = FindObjectOfType<UFO>();
            
            if (stage == 1)
            {
                ufo.ChangeSprite(0);
            }
            else if (stage == 2)
            {
                ufo.ChangeSprite(1);
            }
            else if (stage == 3) 
            {
                ufo.ChangeSprite(2);
            }
            cattle.UFO_dropped = true;
            cattle.UFO_lifted = false;
            Invoke("Resume_escape", 3.5f);

        }
        
        if (transform.position == escape.transform.position && health < damage_threshold)
        {
            if (cattle.UFO_lifted)
            {
                UI.LoseGame();
            }
            if (stage == 1)
            {
                stage = 2;
            }
            else if (stage == 2)
            {
                stage = 3;
            }
            spawner.ActivateUfo();
        }

        transform.position = Vector2.MoveTowards(transform.position, target_position, step);

    }
    void Escape()
    {
        target_position = escape.transform.position;
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            cattle.UFO_lifted = true;
            carrying_cattle = false;

            int rndIndex = Random.Range(0, UfogetHit.Length);
            ufoSound.clip = UfogetHit[rndIndex];
            ufoSound.Play();

            Debug.Log("UFOOO");
        }
    }



    void Resume_escape()
    {
        cattle_dropped = true;
        target_position = escape.transform.position;
    }


}
