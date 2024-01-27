using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Transform))]
public class FixedRigidBody : MonoBehaviour
{
    public float Multiplier = 1.0f;
    Rigidbody2D rb2;
    Transform transform;
    // Start is called before the first frame update
    public Transform FixedPoint;
    public Rigidbody2D MovingBody;
    [SerializeField]
    float minDistance = 1f;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        // startPoint = FixedPoint.localPosition;
        rb2.drag = 0;
    }

    void FixedUpdate()
    {
        var dir = (FixedPoint.position - transform.position);
        // // dir /= 2;
        // // rb2.transform.position += dir;
        var newVelocity = MovingBody.velocity + Multiplier * new Vector2(dir.x, dir.y) / Time.deltaTime;
        
        // newVelocity *= Mathf.Min(1f, maxVelocity/newVelocity.magnitude);
        float newVelocityRatio = 1f;
        rb2.velocity = rb2.velocity * (1 - newVelocityRatio) + newVelocity * newVelocityRatio;
        // rb2.MovePosition(FixedPoint.position);
        // rb2.transform.position = FixedPoint.position;
        // float minDistance = 1.5f;
        // if (Vector3.Distance(FixedPoint.position, rb2.transform.position) < minDistance)
        // {
        //     // rb2.transform.position = FixedPoint.position;
        //     // rb2.velocity *= 0.1f;
        //     rb2.velocity = dir;
        // }
        
        // Vector3 dir = (FixedPoint.position - rb2.transform.position).normalized;
        // // //Check if we need to follow object then do so 
        // float minDistance = 0.1f;
        // if (Vector3.Distance(FixedPoint.position, rb2.transform.position) > minDistance)
        // {
        //     rb2.MovePosition(rb2.transform.position + dir * Multiplier / Time.fixedDeltaTime);
        // }
    }
}
