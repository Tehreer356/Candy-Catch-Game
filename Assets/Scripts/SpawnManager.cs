using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject [] candies;
    [SerializeField]float xRange;
    [SerializeField]float yPos;
    [SerializeField]float spawnInterval;

    public static SpawnManager instance;

    private void Awake()
    {
        if (instance == null)
        { 
        instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSpawningCandies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnCandy() 
    {
        int randomCandy = Random.Range(0, candies.Length);
        Vector3 spawnPos = new Vector3(Random.Range(xRange, -xRange), yPos, 0);
        Instantiate(candies[randomCandy], spawnPos, candies[randomCandy].transform.rotation);
    }
    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);
        while (true) 
        {
            SpawnCandy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void StartSpawningCandies() 
    {
        StartCoroutine("SpawnCandies");
    }
    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
