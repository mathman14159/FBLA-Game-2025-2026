using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class loadJobScript : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask jobItem;
    public float interactDistance = 3;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("rightclicked");
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, jobItem))
            {
                Debug.Log("raycastHit");
                if (hit.collider.TryGetComponent<JobIdentifier>(out JobIdentifier job))
                    {
                        Debug.Log("SceneOpen");
                        SceneManager.LoadScene("Job " + job.jobNumber);
                    }
            }
        }
    }
        
}