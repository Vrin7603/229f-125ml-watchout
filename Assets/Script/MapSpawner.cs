using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject mapPrefab; // แมพที่ใช้
    public float spawnDistance = 50f; // ระยะห่างของแมพใหม่
    private float nextSpawnX = 0f; // ตำแหน่ง Spawn แมพใหม่

    void Start()
    {
        for (int i = 0; i < 3; i++) // เริ่มต้น Spawn 3 ชิ้น
        {
            SpawnMap();
        }
    }

    void Update()
    {
        if (transform.position.x > nextSpawnX - (spawnDistance * 2)) // เมื่อเดินไปใกล้จุด Spawn
        {
            SpawnMap();
        }
    }

    void SpawnMap()
    {
        Vector3 spawnPos = new Vector3(nextSpawnX, 0, 0);
        Instantiate(mapPrefab, spawnPos, Quaternion.identity);
        nextSpawnX += spawnDistance; // อัปเดตตำแหน่งแมพถัดไป
    }
}
