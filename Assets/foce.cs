using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;


public class foce : MonoBehaviour
{
    private Rigidbody rb;
    private Transform player;  // ������
    const float G = 0.006674f;

    public static List<foce> coinsList;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (CompareTag("Player"))  // ����繼�����
        {
            player = transform;
        }

        if (coinsList == null)
        {
            coinsList = new List<foce>();
        }

        // ������������� �������ŧ���ʵ�����­
        if (!CompareTag("Player"))
        {
            coinsList.Add(this);
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        foreach (foce coin in coinsList)
        {
            Attract(coin);
        }
    }

    void Attract(foce coin)
    {
        Rigidbody coinRb = coin.rb;

        Vector3 direction = player.position - coinRb.position;  // �ٴ����­����Ҽ�����
        float distance = direction.magnitude;

        if (distance == 0f)
        {
            return;
        }

        float forceMagnitude = G * (rb.mass * coinRb.mass) / Mathf.Pow(distance, 2);
        Vector3 gravityForce = forceMagnitude * direction.normalized;

        coinRb.AddForce(gravityForce);
    }
}
