using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<GameObject> spawnableObjects;
    public Transform[] enemySpawnPoints;
    public Transform[] UfoSpawnPoints;
    public UFO_tracking enemy_count;
    public float timer;
    public float cooldown;
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemy_count = FindObjectOfType<UFO_tracking>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown && enemy_count.enemies > 0)
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
       
            objectTospawn.transform.position = enemySpawnPoints[random].position;
        
       
    }
    
}
