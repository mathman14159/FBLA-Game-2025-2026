using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickupObject : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHeld = false;
    private Transform holdPoint;

    [Header("Physics Settings")]
    public float moveSpeed = 15f;
    public float rotateSpeed = 10f;
    public float throwForce = 3f;
    private HoverUI hoverUI;

    private Material originalMat;
    private Renderer rend;
    public Material highlightMat;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        hoverUI = GetComponentInChildren<HoverUI>();
        if (rend != null)
            originalMat = rend.material;
    }
    public void SetHover(bool isHovering)
    {
        if (rend == null) return;

        // Material highlight (optional)
        if (highlightMat != null)
            rend.material = isHovering ? highlightMat : originalMat;

        // Show or hide hover text
        if (hoverUI != null)
            hoverUI.Show(isHovering);
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        if (isHeld && holdPoint != null)
        {
            // Smoothly move toward hold point
            Vector3 moveDirection = (holdPoint.position - transform.position);
            rb.velocity = moveDirection * moveSpeed;

            // Smooth rotation to match hold orientation
            Quaternion targetRot = Quaternion.Lerp(transform.rotation, holdPoint.rotation, rotateSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(targetRot);
        }
    }

    [System.Obsolete]
    public void OnPickup(Transform newHoldPoint)
    {
        isHeld = true;
        holdPoint = newHoldPoint;
        rb.useGravity = false;
        rb.drag = 10f;
        rb.angularDrag = 10f;

         // clear highlight
    }

    [System.Obsolete]
    public void OnDrop(Vector3 forwardDir)
    {
        isHeld = false;
        holdPoint = null;
        rb.useGravity = true;
        rb.drag = 1f;
        rb.angularDrag = 0.05f;

        // Throw forward a bit for realism
        rb.AddForce(forwardDir * throwForce, ForceMode.Impulse);
    }

 
}
