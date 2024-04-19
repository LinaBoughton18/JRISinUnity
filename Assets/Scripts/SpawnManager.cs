using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //PUBLIC

    //The list of components
    public GameObject[ ] componentPrefabs;

    //PRIVATE

    //Sets the spawn interval timer
    private float startDelay = 0;
    private float spawnInterval = 1f;

    //Sets the range at which we can spawn the components
    private float lowerSpawnRangeX = -30;
    private float upperSpawnRangeX = 129;
    private float lowerSpawnRangeY = -20;
    private float upperSpawnRangeY = 18;

    //Spawns in a random component at a random map location
    void SpawnRandomComponent() {
        //Sets the type of component to spawn
        int componentIndex = Random.Range(0, componentPrefabs.Length);

        //Sets the location of the component
        Vector3 spawnPosition = new Vector3(Random.Range(lowerSpawnRangeX, upperSpawnRangeX),
        Random.Range(lowerSpawnRangeY, upperSpawnRangeY), 0);

        //Spawns the component
        Instantiate(componentPrefabs[componentIndex], spawnPosition,
        componentPrefabs[componentIndex].transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomComponent", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
}