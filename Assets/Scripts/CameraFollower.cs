using UnityEngine;

class CameraFollower : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject Player;

    private Vector3 cameraPos;

    public Panel RestrictingPanel;
    bool isLatched;

    public float LatchMagnitude = 0.05f;

    public float Speed = 0.9f;

    public bool FollowPlayer = true;

    public static CameraFollower Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        cameraPos = mainCamera.transform.position;
    }

    private void Update()
    {
        // Camera follow
        if (mainCamera)
        {
            if (FollowPlayer)
            {
                var newPos = new Vector3(Player.transform.position.x, Player.transform.position.y, cameraPos.z);
                var v = newPos - mainCamera.transform.position;
                if (v.sqrMagnitude > 1f)
                    isLatched = false;
                if (isLatched)
                    mainCamera.transform.position = newPos;
                else
                {
                    mainCamera.transform.position += v * Speed;
                    isLatched = v.sqrMagnitude < LatchMagnitude;
                }
            }
        }
    }
}
