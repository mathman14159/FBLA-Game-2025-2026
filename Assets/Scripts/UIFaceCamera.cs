using UnityEngine;

public class UIFaceCamera : MonoBehaviour
{
    void LateUpdate()
    {
        if (Camera.main)
            transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
