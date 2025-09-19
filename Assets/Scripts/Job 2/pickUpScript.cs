using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [Header("References")]
    public GameObject player;        // Reference to the player
    public Transform holdPos;        // Where items will be held

    [Header("Settings")]
    public float throwForce = 500f;  // Throw force
    public float pickUpRange = 5f;   // Pickup distance
    public int holdLayer = 8;        // Custom layer for held objects (set in Unity Layer Manager)

    private GameObject heldObj;      // Currently held object
    private Rigidbody heldObjRb;     // Rigidbody of held object
    public bool HDtrue;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // E to pick up / drop
        {
            if (heldObj == null)
            {
                TryPickUp();
            }
            else
            {
                DropObject();
            }
        }

        if (heldObj != null)
        {
            MoveObject(); // keep held object at holdPos

            if (Input.GetMouseButtonDown(0)) // Left click to throw
            {
                ThrowObject();
            }
        }
    }

    void TryPickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickUpRange))
        {
            if (hit.collider.CompareTag("canPickUp"))
            {
                PickUpObject(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("hotDog"))
            {
                PickUpObject(hit.collider.gameObject);
                HDtrue = true;
            }
        }
    }

    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            heldObj = pickUpObj;
            heldObjRb = rb;

            // Adjust physics while held
            heldObjRb.useGravity = false;
            heldObjRb.linearDamping = 10;
            heldObjRb.constraints = RigidbodyConstraints.FreezeRotation;

            heldObj.layer = holdLayer; // Move to hold layer
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void MoveObject()
    {
        // Smoothly move toward holdPos
        Vector3 moveDir = holdPos.position - heldObj.transform.position;
        heldObjRb.linearVelocity = moveDir * 10f; // Tweak multiplier for responsiveness
    }

    void DropObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; // Back to default layer

        // Reset physics
        heldObjRb.useGravity = true;
        heldObjRb.linearDamping = 1;
        heldObjRb.constraints = RigidbodyConstraints.None;

        heldObj = null;
        heldObjRb = null;

        HDtrue = false;
    }

    void ThrowObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;

        heldObjRb.useGravity = true;
        heldObjRb.linearDamping = 1;
        heldObjRb.constraints = RigidbodyConstraints.None;

        heldObjRb.AddForce(transform.forward * throwForce);

        heldObj = null;
        heldObjRb = null;
    }
}
