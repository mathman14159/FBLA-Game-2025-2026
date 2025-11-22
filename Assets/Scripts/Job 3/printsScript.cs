using UnityEngine;

public class printsScript : MonoBehaviour
{
    public GameObject prints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
public void OnTriggerEnter(Collider other)
{

    if (other.gameObject.CompareTag("Flashlight"))
    {
        prints.SetActive(true);
    }
}

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Flashlight"))
        {
            prints.SetActive(false);
        }
    }
}
