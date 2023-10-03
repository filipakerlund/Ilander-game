using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    public GameObject boost;
    [SerializeField] private float yRange = 2;
    [SerializeField] private float xRange = 5;
    [SerializeField] private int numberOfBoosters = 2;

    void Start()
    {
        for (int i = 0; i < numberOfBoosters; i++)
        {
            SpawnBoost();
        }
    }
    void SpawnBoost()
    {
        float lowLimit = transform.position.y - yRange;
        float highLimit = transform.position.y + yRange;
        float rightLimit = transform.position.x - xRange;
        float leftLimit = transform.position.x + xRange;

        Instantiate(boost, new Vector2(Random.Range(rightLimit, leftLimit), Random.Range(lowLimit, highLimit)), transform.rotation);
      
    }
}
