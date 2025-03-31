using UnityEngine;
using UnityEngine.UIElements;

public class MapSpawner : MonoBehaviour
{
    public GameObject Plane; // แมพที่ใช้
    public GameObject Sky_big_color01;
    //public GameObject Sky_big_color02;
    //public GameObject Sky_small_color02;
    //public GameObject Chicken_Shop;
    //public GameObject Bakery;
    //public GameObject Sky_small_color03;
    //public GameObject Fast_Food;
    public float spawnDistance = 50f; // ระยะห่างของแมพใหม่
    private float nextSpawnX = 0f; // ตำแหน่ง Spawn แมพใหม่
    public float spawnInterval = 3f; // เวลาที่ใช้ในการ Spawn (3 วินาที)

    void Start()
    {
        InvokeRepeating("SpawnMap", 0f, spawnInterval); // เรียกใช้ฟังก์ชันซ้ำทุก 3 วินาที
        //for (int i = 0; i < 3; i++) // เริ่มต้น Spawn 3 ชิ้น
        //{
        //    SpawnMap();
        //}
        
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

        Vector3 spawnPos = new Vector3(0, -10, nextSpawnX);
        Instantiate(Plane, spawnPos, Quaternion.identity);
        nextSpawnX += spawnDistance; // อัปเดตตำแหน่งแมพถัดไป

        Vector3 spawnPos2 = new Vector3(0, -10, nextSpawnX);
        Instantiate(Sky_big_color01, spawnPos2, Quaternion.identity);
        nextSpawnX += spawnDistance; // อัปเดตตำแหน่งแมพถัดไป

        //Vector3 spawnPos3 = new Vector3(0, -1, nextSpawnX);
        //Instantiate(Sky_big_color02, spawnPos3, Quaternion.identity);
        //nextSpawnX += spawnDistance; // อัปเดตตำแหน่งแมพถัดไป

        //Vector3 spawnPos4 = new Vector3(0, -1, nextSpawnX);
        //Instantiate(Sky_small_color02, spawnPos, Quaternion.identity);
        //nextSpawnX += spawnDistance; // อัปเดตตำแหน่งแมพถัดไป

        //Vector3 spawnPos5 = new Vector3(0, -1, nextSpawnX);
        //Instantiate(Chicken_Shop, spawnPos, Quaternion.identity);
        //nextSpawnX += spawnDistance; // อัปเดตตำแหน่งแมพถัดไป

        //Vector3 spawnPos6 = new Vector3(0, -1, nextSpawnX);
        //Instantiate(Bakery, spawnPos, Quaternion.identity);
        //nextSpawnX += spawnDistance; // อัปเดตตำแหน่งแมพถัดไป

        //Vector3 spawnPos7 = new Vector3(0, -1, nextSpawnX);
        //Instantiate(Sky_small_color03, spawnPos, Quaternion.identity);
        //nextSpawnX += spawnDistance; // อัปเดตตำแหน่งแมพถัดไป

        //Vector3 spawnPos8 = new Vector3(0, -1, nextSpawnX);
        //Instantiate(Fast_Food, spawnPos, Quaternion.identity);
        //nextSpawnX += spawnDistance; // อัปเดตตำแหน่งแมพถัดไป
    }
}
