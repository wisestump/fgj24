using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float Speed = 1f;
    public List<Transform> endPoints;

    public Vector2 velocity;

    int currentIndex = 1;
    float currentRatio = 0f;

    bool touchPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = endPoints[0].position;
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject == Player.Instance.gameObject)
    //     {
    //         touchPlayer = true;
    //     }
    // }

    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject == Player.Instance.gameObject)
    //     {
    //         touchPlayer = false;
    //     }
    // }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentRatio += Speed * Time.fixedDeltaTime;
        var nextIndex = (currentIndex + 1) % endPoints.Count;
        if (currentRatio > 1)
        {
            currentRatio = 0f;
            currentIndex = nextIndex;
        }
        var goalPosition = endPoints[currentIndex].position + (endPoints[nextIndex].position - endPoints[currentIndex].position) * currentRatio;

        Vector3 direction = (goalPosition - transform.position) * 0.9f;
        // if(direction.magnitude > MaxStep)
        // {
        //     direction = MaxStep * direction / direction.magnitude;
        // }
        transform.position += direction;
        velocity = direction;
        
    }
}
