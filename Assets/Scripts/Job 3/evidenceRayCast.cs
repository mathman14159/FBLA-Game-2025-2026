using UnityEngine;

public class evidenceRayCast : MonoBehaviour
{
    public float interactDistance = 4f;
    public LayerMask interactMask;
    public Camera cam;
    public GameObject evidence1;
    public GameObject evidence2;
    public GameObject evidence3;
    public GameObject evidence4;
    public GameObject evidence5;
    public GameObject evidence6;
    public GameObject sticky1;
    public GameObject sticky2;
    public GameObject sticky3;
    public GameObject sticky4;
    public GameObject sticky5;
    public GameObject sticky6;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactMask))
        {
            if (hit.collider.CompareTag("Evidence1"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    evidence1.SetActive(true);
                    sticky1.SetActive(false);
                    item1.SetActive(true);
                }
                
            }
            if (hit.collider.CompareTag("Evidence2"))
            {
                evidence2.SetActive(true);
                sticky2.SetActive(false);
                item2.SetActive(true);
            }
            if (hit.collider.CompareTag("Evidence3"))
            {
                evidence3.SetActive(true);
                sticky3.SetActive(false);
                item3.SetActive(true);
            }
            if (hit.collider.CompareTag("Evidence4"))
            {
                evidence4.SetActive(true);
                sticky4.SetActive(false);
                item4.SetActive(true);
            }
            if (hit.collider.CompareTag("Evidence5"))
            {
                evidence5.SetActive(true);
                sticky5.SetActive(false);
                item5.SetActive(true);
            }
            if (hit.collider.CompareTag("Evidence6"))
            {
                evidence6.SetActive(true);
                sticky6.SetActive(false);
                item6.SetActive(true);
            }
        }
    }
}
