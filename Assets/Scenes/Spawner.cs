using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<GameObject> spawnableObjects;
    public Transform[] enemySpawnPoints;
    public Transform[] UfoSpawnPoints;
    public float timer;
    public float cooldown;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            timer = 0;
            SpawnObject(spawnableObjects[0]);
        }

        // Add Code for when to spawn Ufo.
    }
    public void SpawnObject(GameObject obj)
    {
        int random = Random.Range(0, enemySpawnPoints.Length);

        GameObject objectTospawn = Instantiate(obj);
        //if (objectTospawn.GetComponent<Enemy>().Id)
        //{
        //    objectTospawn.transform.position = enemySpawnPoints[random];
        //}
        //if (objectTospawn.GetComponent<Enemy>().Id)
        //{
        //    objectTospawn.transform.position = UfoSpawnPoints[random];
        //}
    }
    
}
