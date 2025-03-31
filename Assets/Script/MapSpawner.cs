using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class MapSpawner : MonoBehaviour
{
    public GameObject Sky_big_color01;
    public GameObject[] obstaclePrefabs; // Obstacle ที่จะ Spawn
    
   

    public float spawnDistance = 50f; // ระยะห่างของแมพใหม่
    private float nextSpawnX = 0f; // ตำแหน่ง Spawn แมพใหม่
    [SerializeField] public float spawnInterval = 3f; // เวลาที่ใช้ในการ Spawn 

    private float[] lanes = { -3f, 0f, 3f }; // เลนของ Obstacle
    private float[] offsets = { -1.5f, -9.9f, 1.5f }; // ค่าขยับซ้าย-ขวา (ใช้ Q/E หลบ)

    void Start()
    {
        StartCoroutine(SpawnLoop()); // เริ่มการ Spawn แบบไม่มีที่สิ้นสุด
    }

    IEnumerator SpawnLoop()
    {
        while (true) // วนลูปไปเรื่อย ๆ 
        {
            SpawnMap(); // เรียกให้แมพและ Object ต่าง ๆ Spawn ออกมา
            yield return new WaitForSeconds(spawnInterval); // รอ `spawnInterval` วินาที
        }
    }

    void SpawnMap()
    {
        // สร้างแมพพื้นหลัง
        Vector3 spawnPos2 = new Vector3(0, 3, nextSpawnX);
        Instantiate(Sky_big_color01, spawnPos2, Quaternion.identity);

        // สร้าง Obstacle ตามแมพใหม่
        SpawnObstacle(nextSpawnX);


        // อัปเดตตำแหน่ง Spawn ถัดไป
        nextSpawnX += spawnDistance;
    }

    void SpawnObstacle(float spawnZ)
    {
        float randomX = lanes[UnityEngine.Random.Range(0, lanes.Length)];
        float randomOffset = offsets[UnityEngine.Random.Range(0, offsets.Length)];
        Vector3 spawnPos = new Vector3(randomX, 3, spawnZ + randomOffset);

        // สุ่มเลือก Obstacle จาก Array
        GameObject randomObstacle = obstaclePrefabs[UnityEngine.Random.Range(0, obstaclePrefabs.Length)];
        Instantiate(randomObstacle, spawnPos, Quaternion.identity);
    }

    
}

