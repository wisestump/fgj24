using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{

    public float FloatingSpeed = 0.05f;
    public float FloatRangeRatio = 0.8f;
    public float PlayerOffsetX = -1f;

    public float PlayerOffsetRangeY = 1f;

    public float AttackInterval = 10f;
    float timeSinceLastAttack = 0f;

    bool isAttacking = false;
    float movementCounter = 0f;
    Transform transform;
    float startXPos;
    public AnimationCurve GrabAnimation;

    float stopMovingTime = 0f;

    public float AnimationLength = 2;
    float maxPlayerX;
    // Start is called before the \first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Player player = Player.Instance;
        Bounds bounds = player.CurrentPanel.Bounds;
        Vector3 goalPosition;
        if (!isAttacking)
        {
            // float y = bounds.center.y + FloatingSpeed * Mathf.Sin(Time.time) * bounds.extents.y * player.CurrentPanel.Size.y * FloatRangeRatio;
            var minLimit = Mathf.Max(bounds.center.y - bounds.extents.y * FloatRangeRatio, player.transform.position.y - PlayerOffsetRangeY);
            var maxLimit = Mathf.Min(bounds.center.y + bounds.extents.y * FloatRangeRatio, player.transform.position.y + PlayerOffsetRangeY);
            var center = 0.5f * (minLimit + maxLimit);
            var range = 0.5f * (maxLimit - minLimit);
            movementCounter += Time.deltaTime;
            float y = center + Mathf.Sin(FloatingSpeed * movementCounter) * range;
            goalPosition = new Vector3(Mathf.Max(transform.position.x, bounds.min.x, player.transform.position.x + PlayerOffsetX), y, transform.position.z);
            timeSinceLastAttack += Time.deltaTime;
            if (timeSinceLastAttack > AttackInterval)
            {
                isAttacking = true;
                timeSinceLastAttack = 0;
                startXPos = transform.position.x;
                stopMovingTime = movementCounter;
                movementCounter = 0;
            }
        }
        else
        {
            
            movementCounter += Time.deltaTime;
            var ratio = movementCounter / AnimationLength;
            var minX = Mathf.Max(startXPos, bounds.min.x, player.transform.position.x + PlayerOffsetX);
            var maxX = Mathf.Min(bounds.max.x, player.transform.position.x);
            var range = maxX - minX;
            
            goalPosition = new Vector3(minX + GrabAnimation.Evaluate(ratio) * range, transform.position.y, transform.position.z);
            if (movementCounter > AnimationLength)
            {
                isAttacking = false;
                movementCounter = stopMovingTime;
            }

        }
        var direction = (goalPosition - transform.position) * 0.9f;
        if(direction.magnitude > 1)
        {
            direction = direction / direction.magnitude;
        }
        transform.position += direction;
            

    }
}
