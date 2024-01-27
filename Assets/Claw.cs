using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    [Space]
    [Header("Floating behavior")]
    public float FloatingSpeed = 0.05f;
    public float FloatRangeRatio = 0.8f;
    public float PlayerOffsetX = -1f;

    public float PlayerOffsetRangeY = 1f;
    [Space]
    [Header("Grabbing animation")]
    public AnimationCurve GrabAnimation;
    public float AnimationLength = 2;
    public float Overshoot = 0.1f;
    [Space]
    [Header("General movement")]
    public float MaxStep = 0.3f;

    [Space]
    [Header("Player idling properties")]
    public float IdleDistance = 0.1f;
    public float IdleWaitInterval = 10f;
    public float MaxAttackYRange = 0.2f;

    Vector3 lastPlayerPosition;
    float timeSinceLastAttack = 0f;
    float idleCounter = 0f;
    bool isAttacking = false;
    float movementCounter = 0f;
    Transform transform;
    float startXPos;

    float stopMovingTime = 0f;

    float maxPlayerX;

    float playerPosX;

    bool caughtPlayer = false;

    bool lateInitComplete = false;
    // Start is called before the \first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        
    }


    void resetMaxX(Panel panel)
    {
        transform.position = new Vector3(panel.Bounds.min.x, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.parent.gameObject == Player.Instance.gameObject)
        {
            caughtPlayer = true;
            CameraFollower.Instance.FollowPlayer = false;
            Player.Instance.gameObject.GetComponent<Movement>().enabled = false;
            startXPos = transform.position.x;
            Player.Instance.gameObject.GetComponent<Movement>().rb.isKinematic = true;
            movementCounter = 0f;
        }
    }

    public void Restart()
    {
        caughtPlayer = false;
        isAttacking = false;
    }
    // Update is called once per frame
    void Update()
    {
        Player player = Player.Instance;
        Bounds bounds = player.CurrentPanel.Bounds;
        Vector3 goalPosition;
        if(!lateInitComplete)
        {
            Player.Instance.OnPanelChange += resetMaxX;
            lateInitComplete = true;
        }
        if(!caughtPlayer)
        {
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
                if((lastPlayerPosition - player.transform.position).magnitude < IdleDistance)
                {
                    idleCounter += Time.deltaTime;
                }
                else
                {
                    idleCounter = 0;
                }

                if (idleCounter > IdleWaitInterval && Mathf.Abs(player.transform.position.y - transform.position.y) < MaxAttackYRange)
                {
                    isAttacking = true;
                    playerPosX = player.transform.position.x;
                    timeSinceLastAttack = 0;
                    startXPos = transform.position.x;
                    stopMovingTime = movementCounter;
                    movementCounter = 0;
                }
                lastPlayerPosition = player.transform.position;
            }
            else
            {
                
                movementCounter += Time.deltaTime;
                var ratio = movementCounter / AnimationLength;
                var minX = Mathf.Max(startXPos, bounds.min.x, playerPosX + PlayerOffsetX);
                var maxX = Mathf.Min(bounds.max.x, playerPosX + Overshoot);
                var range = maxX - minX;
                
                goalPosition = new Vector3(minX + GrabAnimation.Evaluate(ratio) * range, transform.position.y, transform.position.z);
                if (movementCounter > AnimationLength)
                {
                    isAttacking = false;
                    movementCounter = stopMovingTime;
                }
            }
        }
        else
        {
            movementCounter += Time.deltaTime;
            var ratio = movementCounter / AnimationLength;
            var endPositionX = CameraFollower.Instance.mainCamera.transform.position.x - 15f;
            var currentPositionX = startXPos + Mathf.Pow(ratio, 1.5f) * (endPositionX - startXPos);
            goalPosition = new Vector3(currentPositionX, transform.position.y, transform.position.z);

            if(movementCounter > AnimationLength)
            {
                GameRestarter.Instance.Restart();
                Restart();
            }
        }
        var direction = (goalPosition - transform.position) * 0.9f;
        if(direction.magnitude > MaxStep)
        {
            direction = MaxStep * direction / direction.magnitude;
        }
        transform.position += direction;
        if(caughtPlayer)
        {
            direction = (transform.position - player.transform.position) * 0.9f;

            player.transform.position += direction;
        }
            

    }
}
