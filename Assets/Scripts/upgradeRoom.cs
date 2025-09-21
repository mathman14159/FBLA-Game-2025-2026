using UnityEngine;
using UnityEngine.SceneManagement;

public class upgradeRoom : MonoBehaviour
{
   public bool InSide;
    public int money;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = PlayerPrefs.GetInt("Money");
    }

    // Update is called once per frame
    void Update()
    {
        if (InSide)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (money >= 5)
                {
                    money -= 5;
                    PlayerPrefs.SetInt("Money", money);
                    SceneManager.LoadScene("Bedroom 2");
                }
                else
                {
                    Debug.Log("You can not afford this");
                }
                
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
