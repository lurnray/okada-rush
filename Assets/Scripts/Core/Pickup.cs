using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType { Coin, Fuel }
    public PickupType type;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (type == PickupType.Coin)
            {
                // Increase score or coins
            }
            else if (type == PickupType.Fuel)
            {
                // Refill fuel
            }
            Destroy(gameObject);
        }
    }
}
