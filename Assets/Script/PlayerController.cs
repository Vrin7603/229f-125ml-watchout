using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 5f;          // ความเร็วเดินหน้า
    public float laneDistance = 3f;   // ระยะห่างของเลน
    public float tiltAngle = 20f;     // องศาการเอียง
    public float tiltSpeed = 5f;      // ความเร็วการเอียง
    private int currentLane = 1;      // เลนเริ่มต้น (0=ซ้าย, 1=กลาง, 2=ขวา)
    private Quaternion targetTilt;    // การเอียงตัว
    public int maxHealth = 3;         // จำนวนหัวใจสูงสุด
    private int currentHealth;        // หัวใจปัจจุบัน
    [SerializeField]public TMP_Text Hp;

    public CoinManager coinManager;

    void Start()
    {
        targetTilt = transform.rotation; // ตั้งค่าการเอียงเริ่มต้น
        currentHealth = maxHealth; // ตั้งค่าเริ่มต้น
    }

    void Update()
    {
        Hp.text = "HP: " + currentHealth.ToString();
        MoveForward();    // ตัวละครเดินหน้า
        HandleLaneChange();  // ย้ายเลน
        HandleTilting();  // เอียงตัว
    }

    void MoveForward()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime; // Z = เดินหน้า
    }

    void HandleLaneChange()
    {
        if (Input.GetKeyDown(KeyCode.D) && currentLane > 0) // D = ไปขวา 
        {
            currentLane--;
            MoveToLane();
        }
        else if (Input.GetKeyDown(KeyCode.A) && currentLane < 2) //  A = ไปซ้าย
        {
            currentLane++;
            MoveToLane();
        }
    }

    void MoveToLane()
    {
        float newX = (1 - currentLane) * laneDistance; // ซ้ายเป็น +, ขวาเป็น -
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }

    void HandleTilting()
    {
        if (Input.GetKey(KeyCode.E)) // กด E เอียงซ้าย
        {
            targetTilt = Quaternion.Euler(-tiltAngle, 0, -tiltAngle); // เปลี่ยนจาก Z เป็น X
        }
        else if (Input.GetKey(KeyCode.Q)) // กด Q เอียงขวา
        {
            targetTilt = Quaternion.Euler(tiltAngle, 0, tiltAngle);
        }
        else // ปล่อยปุ่ม กลับมาตรง
        {
            targetTilt = Quaternion.Euler(0, 0, 0);
        }

        // ทำ Smooth Rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetTilt, Time.deltaTime * tiltSpeed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) // ถ้าโดน Obstacle
        {
            TakeDamage(1); // ลดหัวใจ 1 ดวง
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // ถ้าหัวใจหมด
        }
    }

    void Die()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("Restart");
         
    }

}
