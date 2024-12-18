using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] float cameraSpeed;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    void Start()
    {
        transform.position = playerPosition.position;
    }

    void Update()
    {
        //Blocks the camera X and Y limits
        float clampedX = Mathf.Clamp(playerPosition.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(playerPosition.position.y, minY, maxY);
        //Lerp is making a smooth camera follow
        transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), cameraSpeed);
    }
}
