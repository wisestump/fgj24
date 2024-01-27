using UnityEngine;

class CameraFollower : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject Player;

    private Vector3 cameraPos;

    public Panel RestrictingPanel;
    bool isLatched;

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
            var newPos = new Vector3(Player.transform.position.x, Player.transform.position.y, cameraPos.z);
            var v = newPos - mainCamera.transform.position;
            if (v.sqrMagnitude > 1f)
                isLatched = false;
            if (isLatched)
                mainCamera.transform.position = newPos;
            else
            {
                mainCamera.transform.position += v / 50;
                isLatched = v.sqrMagnitude < 0.05f;
            }
        }
    }
}
