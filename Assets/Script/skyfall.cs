using UnityEngine;

public class skyfall : MonoBehaviour
{
    public GameObject[] spawnPoints;  // Array of spawn points
    public GameObject[] gameObjects;  // Array of game objects to spawn
    [SerializeField]public float minSpawnTime = 1f;   // Minimum time interval between spawns
    [SerializeField]public float maxSpawnTime = 5f;
    public float moveSpeed = 5f;  // Maximum time interval between spawns

    private void Start()
    {
        // Start the spawn process
        InvokeRepeating("SpawnRandomObject", 0f, Random.Range(minSpawnTime, maxSpawnTime));
    }
    void Update()
    {
        // เคลื่อนที่ spawn points ทุกตัวไปข้างหน้า
        foreach (GameObject spawnPoint in spawnPoints)
        {
            spawnPoint.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    void SpawnRandomObject()
    {
        // Select a random spawn point from the spawnPoints array
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        GameObject spawnPoint = spawnPoints[randomSpawnIndex];

        // Select a random game object from the gameObjects array
        int randomObjectIndex = Random.Range(0, gameObjects.Length);
        GameObject gameObjectToSpawn = gameObjects[randomObjectIndex];

        // Instantiate the selected game object at the selected spawn point
        Instantiate(gameObjectToSpawn, spawnPoint.transform.position, Quaternion.identity);
    }
}
