using UnityEngine;

public class Controller : MonoBehaviour
{
    public float tiltAmount = 10f;
    public float turnSpeed = 2f;

    void Update()
    {
        float tilt = Input.GetAxis("Horizontal") * tiltAmount;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        // Tilt animation (Z-axis rotation)
        transform.rotation = Quaternion.Euler(0, 0, -tilt);

        // Slight movement left-right
        transform.position += new Vector3(turn, 0, 0);
    }
}
