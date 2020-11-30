using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    public event Action<bool> OnGetHurt = delegate { };
    private Rigidbody2D playerRB;
    private Animator playerAnimator;
    private PlayerController playerController;


    [Header("Horizontal movement")]
    [SerializeField] private float speed;
    private bool faceRight = true;
    private bool canMove = true;

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float radius;
    [SerializeField] private bool airControll;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform cellCheck;
    [SerializeField] private LayerMask whatIsGround;
    private bool grounded;
    private bool canDoubleJump;


    [Header("Crawling")]
    [SerializeField] private Collider2D headCollider;
    private bool canStand;

    [Header("Casting")]
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireBallSpeed;
    [SerializeField] private int castManaCost;
    private bool isCasting;

    [Header("Strike")]
    [SerializeField] private Transform strikePoint;
    [SerializeField] private int damage;
    [SerializeField] private float strikeRange;
    [SerializeField] private LayerMask enemies;
    private bool isStriking;

    [SerializeField] private float pushForce;
    private float lastHurtTime;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);

        if (playerAnimator.GetBool("Hurt") && grounded && Time.time - lastHurtTime > 0.5f)
            EndHurt();
    }

    public void Move(float move, bool jump, bool crawling)
    {
        if (!canMove)
            return;

        #region Movement


        if (move != 0 && (grounded || airControll))
        {
            playerRB.velocity = new Vector2(speed * move, playerRB.velocity.y);
        }

        if (move > 0 && !faceRight)
            Flip();
        else if (move < 0 && faceRight)
            Flip();
        #endregion

        #region Jumping
        //checking ground
        if (jump)
        {
            if (grounded)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                canDoubleJump = true;
            } else if(canDoubleJump){
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                canDoubleJump = false;

            }
        }
    

        
        #endregion

        #region Crouching
        //make unable to stand up while under collider
        canStand = !Physics2D.OverlapCircle(cellCheck.position, radius, whatIsGround);
        //turn off head collider while crawling
        if (crawling) 
        {
            headCollider.enabled = false;
        }
        else if(!crawling && canStand)
        {
            headCollider.enabled = true;
        }
        #endregion

        #region Animation
        playerAnimator.SetFloat("Speed", Mathf.Abs(move));
        playerAnimator.SetBool("Jump", !grounded);
        playerAnimator.SetBool("Crouch", !headCollider.enabled);
        #endregion

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(cellCheck.position, radius);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(strikePoint.position, strikeRange);
    }

    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }

    public void StartCasting()
    {
        if (isCasting || !playerController.ChangeMP(-castManaCost))
            return;

        isCasting = true;
        playerAnimator.SetBool("Casting", true);
    }

    private void CastFire()
    {
         GameObject _fireBall = Instantiate(fireBall, firePoint.position, Quaternion.identity);
        _fireBall.GetComponent<Rigidbody2D>().velocity = transform.right * fireBallSpeed;
        _fireBall.GetComponent<SpriteRenderer>().flipX = !faceRight;
        Destroy(_fireBall, 5F);
    }

    private void EndCasting()
    {
        isCasting = false;
        playerAnimator.SetBool("Casting", false);
    }

    //for attack
    public void StartStrike()
    {
        if (isStriking)
            return;
        playerAnimator.SetBool("Strike", true);
        isStriking = true;
    }

    private void EndAnimations()
    {
        playerAnimator.SetBool("Strike", false);
        playerAnimator.SetBool("Casting", false);
        playerAnimator.SetBool("Strike", false);
    }

    public void GetHurt(Vector2 position)
    {
        lastHurtTime = Time.time;
        canMove = false;
        OnGetHurt(false);
        Vector2 pushDirection = new Vector2();

        pushDirection.x = position.x > transform.position.x ? -1
                                                            : 1;
        pushDirection.y = 1;

        playerAnimator.SetBool("Hurt", true);
        //EndAnimations();
        playerRB.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
    }

    private void EndHurt()
    {
        canMove = true;
        playerAnimator.SetBool("Hurt", false);
        OnGetHurt(true);
    }

    private void ResetPlayer()
    {
        playerAnimator.SetBool("Strike", false);
        playerAnimator.SetBool("Casting", false);
        playerAnimator.SetBool("Hurt", false);
        isCasting = false;
        isStriking = false;
        canMove = false;
    }

    private void Strike()
    {
        Collider2D[] _enemies = Physics2D.OverlapCircleAll(strikePoint.position, strikeRange, enemies);
        for (int i = 0; i < _enemies.Length; i++)
        {
            EnemiesController enemy = _enemies[i].GetComponent<EnemiesController>();
            enemy.TakeDamage(damage);
        }
    }

    private void EndStrike()
    {
        playerAnimator.SetBool("Strike", false);
        isStriking = false;
    }
}

