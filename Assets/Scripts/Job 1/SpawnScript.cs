using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float spawnDelay = 5;
    public float spawnInterval = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnSpill", spawnDelay, spawnInterval);
    }

    void spawnSpill()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(0, 50), 0.85f, Random.Range(0, 50));
        Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length)], spawnLocation, objectPrefabs[Random.Range(0, objectPrefabs.Length)].transform.rotation);
  }
}
