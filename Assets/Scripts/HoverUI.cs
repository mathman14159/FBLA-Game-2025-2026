using UnityEngine;
using TMPro;

public class HoverUI : MonoBehaviour
{
    private TextMeshProUGUI hoverText;
    private Camera mainCamera;

    void Awake()
    {
        hoverText = GetComponentInChildren<TextMeshProUGUI>();
        mainCamera = Camera.main;
        gameObject.SetActive(false); // hidden by default
    }

    void LateUpdate()
    {
        if (mainCamera)
        {
            // Always face the camera
            transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);
        }
    }

    public void Show(bool state)
    {
        gameObject.SetActive(state);
    }
}
