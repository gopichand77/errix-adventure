using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    public GameObject[] mosters;
    public Transform[] spawnPoints;
    int randomMonster,randomSpawn;
    float randX;
    Vector2 spawnPos;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public bool spwanPoint = false;
    private GameObject[] Turns;
    public GameObject[] TurnPoints;
    IEnumerable<GameObject> except;
    // private string Turn =  "Turn";
    // Start is called before the first frame update
    void Start()
    {
        Turns =  GameObject.FindGameObjectsWithTag("Turn");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Turns =  GameObject.FindGameObjectsWithTag("Turn");
        foreach (GameObject trn in Turns)
        {
            if(trn.name == "Turn" || trn.name == "Turn1")
            {
                trn.SetActive(false);

            }
            
        }
        

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-12f, 12f);
            randomMonster = Random.Range(0, mosters.Length);
            spawnPos = new Vector2(randX, transform.position.y);
            Instantiate(mosters[randomMonster], spawnPos, Quaternion.identity);
            if(spwanPoint)
            {
                if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            // randX = Random.Range(-12f, 12f);
            randomSpawn = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, mosters.Length);
            spawnPos = new Vector2(spawnPoints[randomSpawn].position.x, transform.position.y);
            Instantiate(mosters[randomMonster], spawnPos, Quaternion.identity);

        }
            }
            
        
    

        }
    }
}
