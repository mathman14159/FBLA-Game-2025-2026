using UnityEngine;

public class mirrorScript : MonoBehaviour
{


[RequireComponent(typeof(Renderer))]
public class MirrorReflection : MonoBehaviour
{
    [Header("Mirror Settings")]
    public Camera playerCamera;          // Assign your main camera
    public Camera mirrorCamera;          // Secondary camera (child of mirror if you like)
    public int textureResolution = 1024; // Reflection texture size

    private RenderTexture renderTexture;
    private Renderer mirrorRenderer;
    private Material mirrorMaterial;

    void Start()
    {
        // Set up RenderTexture
        renderTexture = new RenderTexture(textureResolution, textureResolution, 16, RenderTextureFormat.ARGB32);
        renderTexture.Create();

        // Apply RenderTexture to mirror camera
        if (mirrorCamera != null)
        {
            mirrorCamera.targetTexture = renderTexture;
        }

        // Apply RenderTexture to mirror material
        mirrorRenderer = GetComponent<Renderer>();
        mirrorMaterial = new Material(mirrorRenderer.sharedMaterial);
        mirrorMaterial.mainTexture = renderTexture;
        mirrorRenderer.material = mirrorMaterial;
    }

    void LateUpdate()
    {
        if (playerCamera == null || mirrorCamera == null) return;

        // Mirror plane
        Vector3 mirrorPos = transform.position;
        Vector3 mirrorNormal = transform.up; // assumes mirror's local Y is "forward"

        // Position reflection camera
        Vector3 camPos = playerCamera.transform.position;
        float dist = Vector3.Dot(mirrorNormal, mirrorPos - camPos);
        Vector3 reflectedPos = camPos + 2f * dist * mirrorNormal;
        mirrorCamera.transform.position = reflectedPos;

        // Rotation reflection
        Vector3 forward = playerCamera.transform.forward;
        Vector3 up = playerCamera.transform.up;
        Vector3 reflectedForward = Vector3.Reflect(forward, mirrorNormal);
        Vector3 reflectedUp = Vector3.Reflect(up, mirrorNormal);

        mirrorCamera.transform.rotation = Quaternion.LookRotation(reflectedForward, reflectedUp);

        // Make mirror camera match FOV & settings
        mirrorCamera.fieldOfView = playerCamera.fieldOfView;
        mirrorCamera.nearClipPlane = playerCamera.nearClipPlane;
        mirrorCamera.farClipPlane = playerCamera.farClipPlane;
    }

    void OnDisable()
    {
        if (renderTexture != null)
        {
            renderTexture.Release();
        }
    }
}

}


