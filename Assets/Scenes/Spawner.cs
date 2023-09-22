using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<GameObject> spawnableObjects;
    public Transform[] enemySpawnPoints;
    public Transform[] UfoSpawnPoints;
    public GameObject Ufo;
    UFO_tracking ufo_script;
    public float timer;
    public float cooldown;
    public bool spawnerActive = true;
    public int DeathCounter;
    public int UfoDeathsToSpawn;
    public float startTimer;
    public float GameStart;
    public bool gameStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ufo_script = GetComponent<UFO_tracking>();
    }

    // Update is called once per frame
    void Update()

    {
        startTimer += Time.deltaTime;
        if(startTimer > GameStart && gameStarted == false)
        {
            gameStarted = true;
            StartSpawner();
            DayCycle dayCycle = FindAnyObjectByType<DayCycle>();
            dayCycle.ChangeTimeInvoke(0, false);
        }

       
        timer += Time.deltaTime;
        if (timer >= cooldown && spawnerActive)
        {
           
            timer = 0;
            SpawnObject(spawnableObjects[0]);
        }
        if(DeathCounter > UfoDeathsToSpawn)
        {
            DeathCounter = 0;
            PauseSpawner();
            cattle_tracking[] alien = FindObjectsOfType<cattle_tracking>();
            foreach(cattle_tracking aliens in alien)
            {
                aliens.Die();
               
            }
            ActivateUfo();
        }

        // Add Code for when to spawn Ufo.
    }
    public void SpawnObject(GameObject obj)
    {
        int random = Random.Range(0, enemySpawnPoints.Length);

        GameObject objectTospawn = Instantiate(obj);
       
            objectTospawn.transform.position = enemySpawnPoints[random].position;
        
       
    }
    public void StartSpawner()
    {

        spawnerActive = true;
        timer = 0;
    }
    public void PauseSpawner()
    {
     
        spawnerActive = false;
    }
    public void ActivateUfo()
    {
      
         
   
            Ufo.SetActive(true);
  
    }
    public void InactivateUfo()
    {

            Ufo.SetActive(false);
         
      
    }
}
