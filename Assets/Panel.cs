using UnityEngine;

class Panel : MonoBehaviour
{
    [SerializeField]
    private Transform playerStartingPoint;
    [SerializeField]
    private BoxCollider2D boxCollider2D;

    public Vector2 Size => transform.localScale;
    public Bounds Bounds => boxCollider2D.bounds;

    public Vector3 PlayerStartingPoint => playerStartingPoint.position;
}
