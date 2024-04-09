using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer background;
    public float zoomSpeed = 10f; // Speed of zooming in and out
    public float minZoom = 1f; // Minimum orthographic size (maximum zoom-in)
    public float maxZoom = 3f; // Maximum orthographic size (maximum zoom-out)

    private Camera cam;
    private Vector2 backgroundMin;
    private Vector2 backgroundMax;

    void Start()
    {
        cam = Camera.main; // Get the main camera
    }

    void Update()
    {
        // Adjust the orthographic size of the camera based on input to zoom in or out
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.orthographicSize -= scroll * zoomSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);

        // Calculate the camera extents
        float camVertExtent = cam.orthographicSize;
        float camHorzExtent = cam.aspect * camVertExtent;

        // Calculate the background bounds
        backgroundMin = background.bounds.min;
        backgroundMax = background.bounds.max;

        // Follow the player with an offset
        Vector3 camPosition = player.position + new Vector3(0, 1, -10);

        // Clamp the camera's position to not go outside the background
        float clampedX = Mathf.Clamp(camPosition.x, backgroundMin.x + camHorzExtent, backgroundMax.x - camHorzExtent);
        float clampedY = Mathf.Clamp(camPosition.y, backgroundMin.y + camVertExtent, backgroundMax.y - camVertExtent);

        // Update the camera's position
        transform.position = new Vector3(clampedX, clampedY, camPosition.z);
    }
}
