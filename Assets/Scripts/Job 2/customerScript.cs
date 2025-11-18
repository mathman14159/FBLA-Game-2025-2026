using UnityEngine;

public class customerScript : MonoBehaviour
{
    public PlayerInteraction interaction;
    [Header("Tag Names")]
    public string customerTag = "Customer";
    public string itemTag = "Item";
    


    public bool inCustomerZone = false;
    
    

    void Update()
    {
        // Always log when G is pressed so we know input is registered.
        

        if (inCustomerZone)
        {
           
            if (Input.GetKeyDown(KeyCode.G))
            {
                DeleteHeldObject();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(customerTag))
        {
            inCustomerZone = true;
        }

        
    }
 void DeleteHeldObject()
    {
        if (interaction == null) return;
        if (interaction.heldObject == null)
        {
            Debug.Log("No held object to delete.");
            return;
        }

        // Get PickupObject → we must destroy the actual GameObject it belongs to
        PickupObject pickup = interaction.heldObject;

        // Get the Item script on the same object or parent
        Item item = pickup.GetComponent<Item>();

        if (item != null)
        {
            item.DestroySelf(1); // Adds money + deletes object
        }
        else
        {
            // If the object has no Item script, destroy anyway
            Destroy(pickup.gameObject);
        }

        // Clear state so pickup system resets cleanly
        interaction.heldObject = null;
        interaction.coffee = false;
        Debug.Log("Held item deleted successfully.");
    }
}
   
