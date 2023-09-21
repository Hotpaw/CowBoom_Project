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
    
    
    // Start is called before the first frame update
    void Start()
    {
        ufo_script = GetComponent<UFO_tracking>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            PauseSpawner();
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
    public void PauseSpawner()
    {
        if(spawnerActive)
        {
            spawnerActive = false;
           
         
        }
        else if(!spawnerActive)
        {

            DayCycle d = FindObjectOfType<DayCycle>();
            d.ChangeDayTime();
            timer = 0;
            spawnerActive = true;
        }

       
       

        //ActivateUfo();
        


    }
    public void ActivateUfo()
    {
        
        if(Ufo.gameObject.activeInHierarchy)
        {
            Ufo.SetActive(false);
            DayCycle d = FindObjectOfType<DayCycle>();
           
        }
        else
        {
            Ufo.SetActive(true);
            //ufo_script.restore_health();
        }
    }
}
