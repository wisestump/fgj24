using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private void Awake()
    {
        Debug.Assert(Instance == null);
        Instance = this;
    }
}