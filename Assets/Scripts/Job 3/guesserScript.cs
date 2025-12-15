using UnityEngine;

public class guesserScript : MonoBehaviour
{
     private Camera playerCamera;
    [SerializeField] public float interactDistance = 3f;
    [SerializeField] public LayerMask interactableMask;
    [SerializeField] public Transform holdPoint;
    public GameObject Suspect1;
    public GameObject Suspect2;
    public GameObject Suspect3;
    public GameObject Suspect4;
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
            if (hit.collider.CompareTag("Suspect1"))
            {
                Suspect1.SetActive(true);
            }
            else if(hit.collider.CompareTag("Suspect2"))
            {
                Suspect2.SetActive(true);
            }
            else if (hit.collider.CompareTag("Suspect3"))
            {
                Suspect3.SetActive(true);
            }
            else if(hit.collider.CompareTag("Suspect4"))
            {
                Suspect4.SetActive(true);
            }
        }
    }
}
