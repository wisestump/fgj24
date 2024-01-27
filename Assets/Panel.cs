using UnityEngine;

class Panel : MonoBehaviour
{
    [SerializeField]
    private Transform playerStartingPoint;

    public Vector2 Size => transform.localScale;

    public Vector3 PlayerStartingPoint => playerStartingPoint.position;
}
