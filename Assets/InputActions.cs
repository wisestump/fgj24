using UnityEngine;

public class InputActions : MonoBehaviour
{
    public int Move { get; private set; }

    public bool IsJumpActive { get; private set; }

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
    }
}
