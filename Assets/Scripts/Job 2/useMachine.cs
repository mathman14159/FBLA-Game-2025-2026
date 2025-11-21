using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using KinematicCharacterController.Examples;



public class useMachine : MonoBehaviour
{
    public ExamplePlayer examplePlayer;
    public static bool machineOpen = false;
    public PlayerInput playerInput;


    public Camera playerCamera;
    [SerializeField] public float interactDistance = 3f;
    [SerializeField] public LayerMask interactableMask;
    [SerializeField] GameObject coffeeMachine;


    
    public float useRange = 50f;
    private Quaternion spawnRot= quaternion.Euler(0f, 0f, 0f);
    private Vector3 spawnPos = new Vector3(-15, 1, -1.5f);

    public GameObject Coffee1;
    public GameObject Coffee2;
    public GameObject Coffee3;
    public GameObject Coffee4;
    public GameObject Coffee5;
    public GameObject Coffee6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (machineOpen)
        {
            return;
        }

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactableMask))
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                openMachine();


            }
        
        }
        
    }
        public void spawnCoffee1()
    {
        Debug.Log("should spawn");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Instantiate(Coffee1, spawnPos, spawnRot);
    }
            public void spawnCoffee2()
    {
        Instantiate(Coffee2, spawnPos, spawnRot);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
            public void spawnCoffee3()
    {
        Instantiate(Coffee3, spawnPos, spawnRot);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
            public void spawnCoffee4()
    {
        Instantiate(Coffee4, spawnPos, spawnRot);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
            public void spawnCoffee5()
    {
        Instantiate(Coffee5, spawnPos, spawnRot);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
            public void spawnCoffee6()
    {
        Instantiate(Coffee6, spawnPos, spawnRot);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void openMachine()
    {
        examplePlayer.enabled = false;
        machineOpen = true;
        coffeeMachine.SetActive(true);
        playerInput.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
    public void closeMachine()
    {
        examplePlayer.enabled = true;
        machineOpen = false;
        coffeeMachine.SetActive(false);
        playerInput.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    
    
}
