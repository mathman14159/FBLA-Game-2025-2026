using UnityEngine;

public class useMachine : MonoBehaviour
{
    public GameObject item;
    public Camera playerCamera;
    [SerializeField] public float interactDistance = 3f;
    [SerializeField] public LayerMask interactableMask;
    public float useRange = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactableMask))
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                Transform machine = hit.collider.transform;

        // Spawn position = in front of machine + a little upward
                Vector3 spawnPos = machine.position 
                           + machine.forward * 0.5f   // forward
                           + Vector3.up * 0.3f;       // slight upward height

        // Spawn rotation matches the machine's rotation
                Quaternion spawnRot = machine.rotation;

        // Instantiate the item
                Instantiate(item, spawnPos, spawnRot);
            }
        
        }
        
    }
    
    
}
