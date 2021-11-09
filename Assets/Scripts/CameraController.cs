using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    float cameraSpeed = 1f;
    [SerializeField]
    Transform topWall;          //transform of top wall
    [SerializeField]
    Transform rightWall;        //transform of right wall

    void Update()
    {
        //taking positions of our walls relative to the camera
        Vector3 viewTopWallPos = Camera.main.WorldToViewportPoint(topWall.position);
        Vector3 viewRightWallPos = Camera.main.WorldToViewportPoint(rightWall.position);

        if (viewTopWallPos.y >= 1 || viewRightWallPos.x >= 1)
        {
            //moving camera up
            this.transform.position += Vector3.up * cameraSpeed * Time.deltaTime;
        }
    }
}
