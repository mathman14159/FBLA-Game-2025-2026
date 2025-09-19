using UnityEngine;

public class customerScript : MonoBehaviour
{
    public bool InRange;
void Update()
    {
        if (InRange)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Item.instance.DestroySelf(1);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hotDog"))
        {
            
            InRange = true;
        }
        
        
    }
    void OnTriggerExit(Collider other)
    {
       // InRange = false;
    }
}
