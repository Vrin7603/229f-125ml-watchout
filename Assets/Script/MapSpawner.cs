using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    //public GameObject Plane; // แมพที่ใช้ *ไม่ใช้
    public GameObject Sky_big_color01;
    public GameObject obstaclePrefab; // Obstacle ที่จะ Spawn

    public float spawnDistance = 50f; // ระยะห่างของแมพใหม่
    private float nextSpawnX = 0f; // ตำแหน่ง Spawn แมพใหม่
    public float spawnInterval = 3f; // เวลาที่ใช้ในการ Spawn (3 วินาที)

    private float[] lanes = { -3f, 0f, 3f }; // เลนของ Obstacle
    private float[] offsets = { -1.5f, -9.9f, 1.5f }; // ค่าขยับซ้าย-ขวา (ใช้ Q/E หลบ)

    void Start()
    {
        InvokeRepeating("SpawnMap", 0f, spawnInterval); // เรียกใช้ฟังก์ชันซ้ำทุก 3 วินาที
    }

    void SpawnMap()
    {
        // สร้างแมพ
        /*Vector3 spawnPos = new Vector3(0, -10, nextSpawnX);
        Instantiate(Plane, spawnPos, Quaternion.identity);*/

        Vector3 spawnPos2 = new Vector3(0, 3, nextSpawnX);
        Instantiate(Sky_big_color01, spawnPos2, Quaternion.identity);

        // สร้าง Obstacle
        SpawnObstacle(nextSpawnX);

        // อัปเดตตำแหน่ง Spawn ถัดไป
        nextSpawnX += spawnDistance;
    }

    void SpawnObstacle(float spawnZ)
    {
       
        float randomX = lanes[Random.Range(0, lanes.Length)]; // เลือกเลน X
        float randomOffset = offsets[Random.Range(0, offsets.Length)]; // ขยับ Z
        Vector3 spawnPos = new Vector3(randomX, 3, spawnZ + randomOffset);

        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
