using UnityEngine;
using UnityEngine.InputSystem;

public class playerHover : MonoBehaviour
{
    public float interactDistance = 4f;
    public LayerMask interactMask;

    private Camera cam;
    private InteractableBase current;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        HandleRaycast();
        HandleInputs();
    }

    void HandleRaycast()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactMask))
        {
            InteractableBase interact = hit.collider.GetComponent<InteractableBase>();
            if (interact != null)
            {
                // If this is a new target
                if (interact != current)
                {
                    ClearCurrent();
                    current = interact;
                    current.ShowUI(cam.transform);
                }
                return;
            }
        }
        ClearCurrent();
    }

    void HandleInputs()
    {
        if (current == null) return;

        if (Keyboard.current.eKey.wasPressedThisFrame && current.interactionType == InteractionType.PickUp)
            current.Interact(gameObject);

        if (Keyboard.current.uKey.wasPressedThisFrame && current.interactionType == InteractionType.Use)
            current.Interact(gameObject);

        if (Keyboard.current.eKey.wasPressedThisFrame && current.interactionType == InteractionType.CustomerOrder)
            current.Interact(gameObject);
    }

    void ClearCurrent()
    {
        if (current != null)
        {
            current.HideUI();
            current = null;
        }
    }
}
