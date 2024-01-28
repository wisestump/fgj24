using UnityEngine;

public class InputActions : MonoBehaviour
{
    public static InputActions Instance { get; private set; }

    public int Move { get; private set; }
    public bool IsJumpActive { get; private set; }
    public bool IsJumpHeld { get; private set; }
    public bool IsRestartActive { get; private set; }

    private void Awake()
    {
        Debug.Assert(Instance == null);
        Instance = this;
    }

    private void Update()
    {
        // Movement controls
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Move = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else
        {
            Move = 0;
        }
         
        IsJumpActive = Input.GetKeyDown(KeyCode.Space);
        IsJumpHeld = Input.GetKey(KeyCode.Space);
        IsRestartActive = Input.GetKeyDown(KeyCode.R);
    }
}
