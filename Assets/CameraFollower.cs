using UnityEngine;

class CameraFollower : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject Player;

    private Vector3 cameraPos;

    private void Start()
    {
        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    private void Update()
    {
        // Camera follow
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(Player.transform.position.x, cameraPos.y, cameraPos.z);
        }
    }
}
