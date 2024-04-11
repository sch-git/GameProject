
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    public uint coinVal = 1;
    public CoinUI coinUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            coinUI.InsertCoinQuantity(coinVal);
            Destroy(gameObject);
        }
    }
}
