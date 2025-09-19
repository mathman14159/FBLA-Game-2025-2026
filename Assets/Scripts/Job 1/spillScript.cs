using UnityEditor;
using UnityEngine;

public class spillScript : MonoBehaviour
{
    public bool InSide;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if (InSide)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                moneyCounter.instance.IncreaseMoney(1);
                Destroy(gameObject);
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
