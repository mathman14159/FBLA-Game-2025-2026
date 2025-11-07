using UnityEngine;

public class setBroomPos : MonoBehaviour
{
public Transform player;      // Reference to player transform

    void Update()
    {
        transform.position = player.position;
    }
}
