using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // Example: "HotDog", "Mop", "Soda"

    public static Item instance;

    void Awake()
    {
        instance = this;
    }

    public void DestroySelf(int v)
    {
        moneyCounter.instance.IncreaseMoney(1);
        Destroy(gameObject);
    }
}
