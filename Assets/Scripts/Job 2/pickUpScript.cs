using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [Header("References")]
    public GameObject player;      // Your player object (with collider)
    public Transform playerBody;   // Use the player root transform (not the camera)

    [Header("Settings")]
    public float throwForce = 500f;
    public float pickUpRange = 5f;
    public int holdLayer = 8;

    private GameObject heldObj;
    private Rigidbody heldObjRb;

    public bool HDtrue;
    public bool Broomtrue;

    // Adjust for position offset — right side of player
    [SerializeField] private Vector3 sideOffset = new Vector3(0.5f, 0.5f, 0.0f);

    // Fixed world rotation for held items (so it never turns)
    private Quaternion fixedWorldRotation = Quaternion.identity;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
                TryPickUp();
            else
                DropObject();
        }

        if (heldObj != null && Input.GetMouseButtonDown(0))
            ThrowObject();
    }

    void TryPickUp()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, pickUpRange))
        {
            if (hit.collider.CompareTag("canPickUp") || hit.collider.CompareTag("hotDog") || hit.collider.CompareTag("Broom"))
            {
                PickUpObject(hit.collider.gameObject);

                if (hit.collider.CompareTag("hotDog")) HDtrue = true;
                if (hit.collider.CompareTag("Broom")) Broomtrue = true;
            }
        }
    }

    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            heldObj = pickUpObj;
            heldObjRb = rb;

            // Lock physics
            heldObjRb.useGravity = false;
            heldObjRb.isKinematic = true;
            heldObjRb.constraints = RigidbodyConstraints.FreezeAll;

            // Ignore player collision
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);

            // Move to custom layer
            heldObj.layer = holdLayer;

            // Save its current world rotation (so it never changes)
            fixedWorldRotation = heldObj.transform.rotation;
        }
    }

    void LateUpdate()
    {
        if (heldObj != null)
        {
            // Move relative to player position (not rotation)
            Vector3 rightOffset = playerBody.right * sideOffset.x;
            Vector3 upOffset = Vector3.up * sideOffset.y;
            Vector3 forwardOffset = Vector3.forward * sideOffset.z; // stays world-forward

            heldObj.transform.position = playerBody.position + rightOffset + upOffset + forwardOffset;

            // Keep the original rotation (never change)
            heldObj.transform.rotation = fixedWorldRotation;
        }
    }

    void DropObject()
    {
        ResetHeldObjectPhysics();
        heldObj = null;
        heldObjRb = null;
        HDtrue = false;
        Broomtrue = false;
    }

    void ThrowObject()
    {
        ResetHeldObjectPhysics();
        heldObjRb.AddForce(playerBody.forward * throwForce);
        heldObj = null;
        heldObjRb = null;
    }

    void ResetHeldObjectPhysics()
    {
        if (heldObj == null || heldObjRb == null) return;

        heldObjRb.useGravity = true;
        heldObjRb.isKinematic = false;
        heldObjRb.constraints = RigidbodyConstraints.None;

        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
    }
}
