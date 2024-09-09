using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
//using UnityEditor.Callbacks;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public GameObject asteroid;
    public GameObject player;
    public float asteroidSpeed = 3;
    public int asteroidNum = 60;
    public float asteroidSpawnRange = 50f;

    void Start()
    {
        //InvokeRepeating("SpawnAsteroidField",0,asteroidSpawnInterval);
        SpawnAsteroidField();
    }

    void SpawnAsteroidField(){

        for(int i = 0; i < asteroidNum; i++){
            Vector3 newPos = new Vector3(UnityEngine.Random.Range(-asteroidSpawnRange, asteroidSpawnRange), UnityEngine.Random.Range(-asteroidSpawnRange, asteroidSpawnRange), 0);
            GameObject newAsteroid = Instantiate(asteroid, newPos, Quaternion.identity);
            Debug.Log("Spawned Asteroid at: " + newPos);
            Rigidbody2D rb = newAsteroid.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2 (asteroidSpeed*UnityEngine.Random.Range(0f,1f),asteroidSpeed*UnityEngine.Random.Range(0f,1f)));
        }
    }

}
