using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private Collision coll;
    public Rigidbody2D rb;
    public Transform BodyTransform;
    public Transform LeftEyeFix;
    public Transform RightEyeFix;
    public Transform LeftArmFix;
    public Transform RightArmFix;
    public Animator PlayerAnimator;
    //private AnimationScript anim;

    [Space]
    [Header("Stats")]
    public float speed = 10;
    public float jumpForce = 50;
    public float jetpackJumpForce = 10;
    public float slideSpeed = 5;
    public float wallJumpLerp = 10;
    public float dashSpeed = 20;
    public float normalGravityScale = 3;
    public float jetpackGravityScale = 1;

    [Space]
    [Header("Booleans")]
    public bool canMove;
    public bool wallGrab;
    public bool wallJumped;
    public bool wallSlide;
    public bool isDashing;

    [Space]

    private bool groundTouch;
    private bool hasDashed;
    private bool jetpackActive;
    private Vector2 movementVector;
    public int side = 1;

    [Space]
    [Header("Polish")]
    public ParticleSystem dashParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem wallJumpParticle;
    public ParticleSystem slideParticle;

    Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collision>();
        transform = GetComponent<Transform>();
        //rb = GetComponent<Rigidbody2D>();
        //anim = GetComponentInChildren<AnimationScript>();
    }

    public void EnableJetpack() => jetpackActive = true;
    public void DisableJetpack() => jetpackActive = false;
    
    void SwapPositions(Transform t1, Transform t2)
    {
        var p1 = t1.position;
        t1.position = t2.position;
        t2.position = p1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.gravityScale = jetpackActive ? jetpackGravityScale : normalGravityScale;
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        //float xRaw = Input.GetAxisRaw("Horizontal");
        //float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(InputActions.Instance.Move, 0);
        
        if(InputActions.Instance.Move != 0)
        {
            if(!PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                PlayerAnimator.Play("Run");
            bool swap = Mathf.Sign(BodyTransform.localScale.x) != Mathf.Sign(InputActions.Instance.Move);
            BodyTransform.localScale = new Vector3(Mathf.Abs(BodyTransform.localScale.x) * Mathf.Sign(InputActions.Instance.Move),
                                    BodyTransform.localScale.y, BodyTransform.localScale.z);
            if (swap)
            {
                SwapPositions(LeftArmFix, RightArmFix);
                SwapPositions(LeftEyeFix, RightEyeFix);
            }
        }
        else if (!PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            PlayerAnimator.Play("Stand");

        Walk(dir);
        //anim.SetHorizontalMovement(x, y, rb.velocity.y);

        //if (coll.onWall && Input.GetButton("Fire3") && canMove)
        //{
        //    if (side != coll.wallSide)
        //        anim.Flip(side * -1);
        //    wallGrab = true;
        //    wallSlide = false;
        //}

        //if (Input.GetButtonUp("Fire3") || !coll.onWall || !canMove)
        //{
        //    wallGrab = false;
        //    wallSlide = false;
        //}

        //if (coll.onGround && !isDashing)
        //{
        //    wallJumped = false;
        //    GetComponent<BetterJumping>().enabled = true;
        //}

        //if (wallGrab && !isDashing)
        //{
        //    rb.gravityScale = 0;
        //    if (x > .2f || x < -.2f)
        //        rb.velocity = new Vector2(rb.velocity.x, 0);

        //    float speedModifier = y > 0 ? .5f : 1;

        //    rb.velocity = new Vector2(rb.velocity.x, y * (speed * speedModifier));
        //}
        //else
        //{
        //    rb.gravityScale = 3;
        //}

        //if (coll.onWall && !coll.onGround)
        //{
        //    if (x != 0 && !wallGrab)
        //    {
        //        wallSlide = true;
        //        WallSlide();
        //    }
        //}

        if (!coll.onWall || coll.onGround)
            wallSlide = false;

        if (InputActions.Instance.IsJumpActive)
        {
            //anim.SetTrigger("jump");

            if (coll.onGround)
                Jump(Vector2.up, false);
            //if (coll.onWall && !coll.onGround)
            //    WallJump();
        }

        //if (Input.GetButtonDown("Fire1") && !hasDashed)
        //{
        //    if (xRaw != 0 || yRaw != 0)
        //        Dash(xRaw, yRaw);
        //}

        if (coll.onGround && !groundTouch)
        {
            GroundTouch();
            groundTouch = true;
        }

        if (!coll.onGround && groundTouch)
        {
            groundTouch = false;
        }

        //WallParticle(y);

        if (wallGrab || wallSlide || !canMove)
            return;
        
        // Debug.Log(coll.onGround);
        
        rb.velocity = movementVector;
        // rb.MovePosition(rb.position + movementVector);
        // rb.transform.position = rb.position + movementVector;
        // if (dir.x > 0)
        // {
        //    side = 1;
        //    anim.Flip(side);
        // }
        // if (dir.x < 0)
        // {
        //    side = -1;
        //    anim.Flip(side);
        // }
    }
    void FixedUpdate()
    {
        foreach(Collider2D collider in coll.GroundCollisions)
        {
            var movingPlatform = collider.gameObject.GetComponent<MovingPlatform>();
            if (movingPlatform != null)
            {
                // movementVector += 100*movingPlatform.velocity;
                // rb.MovePosition(rb.position + movingPlatform.velocity);
                rb.transform.position = rb.position + movingPlatform.velocity;
            }
        }
        // Debug.Log(rb.velocity);
        // rb.velocity = movementVector;
    }
    void GroundTouch()
    {
        hasDashed = false;
        isDashing = false;

        //side = anim.sr.flipX ? -1 : 1;

        //jumpParticle.Play();
    }

    private void Dash(float x, float y)
    {
        //Camera.main.transform.DOComplete();
        //Camera.main.transform.DOShakePosition(.2f, .5f, 14, 90, false, true);
        //FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));

        //hasDashed = true;

        //anim.SetTrigger("dash");

        //rb.velocity = Vector2.zero;
        //Vector2 dir = new Vector2(x, y);

        //rb.velocity += dir.normalized * dashSpeed;
        //StartCoroutine(DashWait());
    }

    //IEnumerator DashWait()
    //{
    //    FindObjectOfType<GhostTrail>().ShowGhost();
    //    StartCoroutine(GroundDash());
    //    DOVirtual.Float(14, 0, .8f, RigidbodyDrag);

    //    dashParticle.Play();
    //    rb.gravityScale = 0;
    //    GetComponent<BetterJumping>().enabled = false;
    //    wallJumped = true;
    //    isDashing = true;

    //    yield return new WaitForSeconds(.3f);

    //    dashParticle.Stop();
    //    rb.gravityScale = 3;
    //    GetComponent<BetterJumping>().enabled = true;
    //    wallJumped = false;
    //    isDashing = false;
    //}

    //IEnumerator GroundDash()
    //{
    //    yield return new WaitForSeconds(.15f);
    //    if (coll.onGround)
    //        hasDashed = false;
    //}

    //private void WallJump()
    //{
    //    if ((side == 1 && coll.onRightWall) || side == -1 && !coll.onRightWall)
    //    {
    //        side *= -1;
    //        anim.Flip(side);
    //    }

    //    StopCoroutine(DisableMovement(0));
    //    StartCoroutine(DisableMovement(.1f));

    //    Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;

    //    Jump((Vector2.up / 1.5f + wallDir / 1.5f), true);

    //    wallJumped = true;
    //}

    //private void WallSlide()
    //{
    //    if (coll.wallSide != side)
    //        anim.Flip(side * -1);

    //    if (!canMove)
    //        return;

    //    bool pushingWall = false;
    //    if ((rb.velocity.x > 0 && coll.onRightWall) || (rb.velocity.x < 0 && coll.onLeftWall))
    //    {
    //        pushingWall = true;
    //    }
    //    float push = pushingWall ? 0 : rb.velocity.x;

    //    rb.velocity = new Vector2(push, -slideSpeed);
    //}

    private void Walk(Vector2 dir)
    {
        if (!canMove)
            return;

        if (wallGrab)
            return;

        if (!wallJumped)
        {
            movementVector = new Vector2(dir.x * speed, rb.velocity.y);
        }
        else
        {
            movementVector = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
        }
    }

    private void Jump(Vector2 dir, bool wall)
    {
        //slideParticle.transform.parent.localScale = new Vector3(ParticleSide(), 1, 1);
        ParticleSystem particle = wall ? wallJumpParticle : jumpParticle;

        movementVector= new Vector2(rb.velocity.x, 0);
        movementVector += dir * (jetpackActive ? jetpackJumpForce : jumpForce);

        //particle.Play();
    }

    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    void RigidbodyDrag(float x)
    {
        rb.drag = x;
    }

    void WallParticle(float vertical)
    {
        var main = slideParticle.main;

        if (wallSlide || (wallGrab && vertical < 0))
        {
            slideParticle.transform.parent.localScale = new Vector3(ParticleSide(), 1, 1);
            main.startColor = Color.white;
        }
        else
        {
            main.startColor = Color.clear;
        }
    }

    int ParticleSide()
    {
        int particleSide = coll.onRightWall ? 1 : -1;
        return particleSide;
    }

    public void ResetAnimation()
    {
        if (!PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            PlayerAnimator.Play("Stand");
    }
}
