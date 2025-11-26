using UnityEngine;

public enum InteractionType { PickUp, Use, CustomerOrder }

public class InteractableBase : MonoBehaviour
{
    public InteractionType interactionType;
    public string promptText;
    public GameObject hoverUIPrefab;

    private GameObject spawnedUI;

    // Spawn UI when player looks at it
    public void ShowUI(Transform playerCam)
    {
        if (spawnedUI == null && hoverUIPrefab != null)
        {
            spawnedUI = Instantiate(hoverUIPrefab, transform.position + Vector3.up * 1.2f, Quaternion.identity);
            spawnedUI.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = promptText;
        }
    }

    // Remove UI when not looked at
    public void HideUI()
    {
        if (spawnedUI != null)
            Destroy(spawnedUI);
    }

    // Called from PlayerInteraction when key is pressed
    public void Interact(GameObject player)
    {
        switch (interactionType)
        {
            case InteractionType.PickUp:
                Debug.Log("Picked up item!");
                // Add your pickup logic here
                break;

            case InteractionType.Use:
                Debug.Log("Used machine!");
                // Add machine action here (spawn coffee, etc.)
                break;

            case InteractionType.CustomerOrder:
                Debug.Log("Customer order shown!");
                // If needed you can open a bigger panel/UI here
                break;
        }
    }
}
