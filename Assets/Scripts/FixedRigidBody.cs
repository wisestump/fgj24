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
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        // startPoint = FixedPoint.localPosition;
        rb2.drag = 0;
    }

    void FixedUpdate()
    {
        // if ((FixedPoint.position - transform.position).magnitude > 1.0f)
        //     transform.position = new Vector3(FixedPoint.position.x, FixedPoint.position.y, transform.position.z);
        // else
            rb2.velocity = Multiplier * (FixedPoint.position - transform.position) / Time.deltaTime;
    }
}
