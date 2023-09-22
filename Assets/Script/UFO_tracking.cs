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
    public int stage;
    public int max_health;
   
    Spawner spawner;
    UIManager UI;
    float step;

    bool a = true;
  
    private Animation anim;
    UFO ufo;

    AudioSource ufoSound;

    public AudioClip[] UfogetHit;
    Vector2 target_position;
  
  

    // Start is called before the first frame update
    void Start()
    {
        ufo = FindAnyObjectByType<UFO>();
        target = GameObject.FindGameObjectWithTag("Cattle");
        child = GameObject.FindGameObjectWithTag("Cattle");
        cattle = FindAnyObjectByType<cattle_script>();
        damage_threshold = 0;
        speed = 0.8f;
        UI = FindFirstObjectByType<UIManager>();
        spawner = FindObjectOfType<Spawner>();
        ufoSound = GetComponent<AudioSource>();
        max_health = 20;
        anim = GetComponent<Animation>();
        

        //health = 90;
    }


    private void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("Cattle");
        child = GameObject.FindGameObjectWithTag("Cattle");
        cattle = FindAnyObjectByType<cattle_script>();
        restore_health();
        healthy = true;
        a = true;
    }

    void Update()
    {
     
            step = speed * Time.deltaTime;
     

        if (transform.position == escape.transform.position)
        {
            Debug.Log("escaped");
        }

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
           
         
            if (a == true)
            {
                stage++;
                if (stage == 1)
                {
                    Debug.Log("STAGE 1");
                   
                    ufo.ChangeSprite(0);
                }
                if (stage == 2)
                {
                    Debug.Log("STAGE 2");
                    GameObject ufosprite = GameObject.FindGameObjectWithTag("UFOSPAWN");
                    ufo.Hurt();
                    
                }if(stage == 3)
                {
                    Debug.Log("STAGE 3");
                    UIManager um = FindAnyObjectByType<UIManager>();
                    um.WinGame();
                }
                a = false;
               

            }
            cattle.UFO_dropped = true;
            cattle.UFO_lifted = false;
            Invoke("Resume_escape", 3.5f);

        }
        
        if (transform.position == escape.transform.position && health <= damage_threshold)
        {
            
          
            Debug.Log("deactivating ufo");
            DayCycle d = FindAnyObjectByType<DayCycle>();
            d.ChangeTimeInvoke(0, true);
            spawner.startTimer = 0;
            spawner.gameStarted = false;
            spawner.InactivateUfo();
          
        }

        if (transform.position == escape.transform.position && cattle.UFO_lifted)
        {

            UI.LoseGame();

        }

        transform.position = Vector2.MoveTowards(transform.position, target_position, step);

    }
    
    void Escape()
    {
       
        target_position = escape.transform.position;
       
        
    }

    void spawn_activate()
    {
        spawner.StartSpawner();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            cattle.UFO_lifted = true;
            carrying_cattle = false;

            int rndIndex = Random.Range(0, UfogetHit.Length);
            ufoSound.clip = UfogetHit[rndIndex];
            ufoSound.Play();

            Debug.Log("UFOOO");
        }

    }

    public void restore_health()
    {
        health = max_health;
    }

    void Resume_escape()
    {
             
        cattle_dropped = true;
        target_position = escape.transform.position;
    }


}
