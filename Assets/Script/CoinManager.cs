using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCount.ToString();
    }
}
