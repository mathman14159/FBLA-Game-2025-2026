using UnityEngine;

public class mirrorScript : MonoBehaviour
{

    public Transform playerCamera; // Assign your main camera
    public Transform mirrorPlane;  // Assign the mirror plane
    public Camera mirrorCamera;    // Assign the secondary camera

    void LateUpdate()
    {
        // Mirror position
        Vector3 pos = playerCamera.position;
        Vector3 normal = mirrorPlane.up; // assuming plane is flat

        float d = Vector3.Dot(normal, mirrorPlane.position - pos);
        Vector3 mirroredPos = pos + 2 * d * normal;

        mirrorCamera.transform.position = mirroredPos;

        // Mirror rotation
        Vector3 forward = Vector3.Reflect(playerCamera.forward, normal);
        Vector3 up = Vector3.Reflect(playerCamera.up, normal);
        mirrorCamera.transform.rotation = Quaternion.LookRotation(forward, up);
    }
}


