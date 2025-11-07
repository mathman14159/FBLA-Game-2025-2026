using UnityEngine;
using UnityEngine.InputSystem; // for new Input System
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    public Image crosshairImage;
    public Color defaultColor = Color.white;
    public Color hoverColor = Color.green;
    [SerializeField] public float interactDistance = 3f;
    [SerializeField] public LayerMask interactableMask;
    [SerializeField] public Transform holdPoint;

    private Camera playerCamera;
    private PickupObject heldObject;

    private PlayerInput playerInput;
    private InputAction grabAction;

    void Awake()
    {
        playerCamera = GetComponent<Camera>();
        playerInput = GetComponent<PlayerInput>();

        // Make sure you have an action map called "Player" with a "Grab" action
        grabAction = playerInput.actions["Grab"];
    }

    [System.Obsolete]
    void Update()
    {
        if (grabAction.WasPressedThisFrame())
        {
            if (heldObject != null)
            {
                DropObject();
            }
        }
        // Raycast to find interactable objects
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactableMask))
        {
            PickupObject pickup = hit.collider.GetComponent<PickupObject>();

            // Hover highlight
            if (pickup != null && heldObject == null)
                pickup.SetHover(true);

            // Pick up or drop
            if (grabAction.WasPressedThisFrame())
            {
                if (heldObject == null)
                {
                    if (pickup != null)
                        PickUpObject(pickup);
                }
                else
                {
                    DropObject();
                }
            }
        }
        else if (heldObject == null)
        {
            // Clear hover if not looking at anything
            ClearHover();
        }
        
    }

    [System.Obsolete]
    private void PickUpObject(PickupObject pickup)
    {
        heldObject = pickup;
        heldObject.OnPickup(holdPoint);
    }

    [System.Obsolete]
    private void DropObject()
    {
        heldObject.OnDrop(playerCamera.transform.forward);
        heldObject = null;
    }

    [System.Obsolete]
    private void ClearHover()
    {
        // Disable hover visuals on all pickup objects
        // You can make this more efficient later with event-based highlight
        foreach (PickupObject p in FindObjectsOfType<PickupObject>())
            p.SetHover(false);
    }
}

