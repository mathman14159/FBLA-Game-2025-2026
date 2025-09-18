using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class loadJobScript : MonoBehaviour
{
    public bool InSide;
    public int JobNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InSide)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Job " + JobNumber);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        InSide = true;
    }
    void OnTriggerExit(Collider other)
    {
        InSide = false;
    }
}
