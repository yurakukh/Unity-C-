using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public abstract class EnemyControllerBase : MonoBehaviour
{
    protected Rigidbody2D enemyRB;
    protected Animator enemyAnimator;
    protected Vector2 startPoint;
    protected EnemyState currentState;


    //for random
    protected float lastStateChange;
    protected float timeToNextChange;

    
    [SerializeField] private float maxStateTime;
    [SerializeField] private float minStateTime;
    [SerializeField] private EnemyState[] availableStates;
    [SerializeField] private DamageType collisionDamageType;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] protected int collisionDamage;
    [SerializeField] protected float collisionTimeDelay;
    private float lastDamageTime;

    protected bool faceRight = true;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        startPoint = transform.position;
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if (IsGroundEnding())
            Flip();
        
        if(currentState == EnemyState.Move)
            Move();
    }

    protected virtual void Update()
    {
        if(Time.time - lastStateChange > timeToNextChange)
        {
            GetRandomState();
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        TryToDamage(collision.collider);
    }

    protected void TryToDamage(Collider2D enemy)
    {
        if (Time.time - lastDamageTime < collisionTimeDelay)
            return;

        PlayerController player = enemy.GetComponent<PlayerController>();
        if(player != null)
        {
            player.TakeDamage(collisionDamage, collisionDamageType, transform);       }

    }

    protected virtual void Move()
    {
        enemyRB.velocity = transform.right * new Vector2(speed, enemyRB.velocity.y);
    }
    
    protected void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(range * 2, 0.5f, 0));
    }

    private bool IsGroundEnding()
    {
        return !Physics2D.OverlapPoint(groundCheck.position, whatIsGround);
    }

    protected void GetRandomState()
    {
        int state = Random.Range(0, availableStates.Length);
        
        if(currentState == EnemyState.Idle && availableStates[state] == EnemyState.Idle)
        {
            GetRandomState();
        }
        
       
        timeToNextChange = Random.Range(minStateTime, maxStateTime);
        ChangeState(availableStates[state]);
    }

    protected virtual void ChangeState(EnemyState state)
    {
        if(currentState != EnemyState.Idle) 
            enemyAnimator.SetBool(currentState.ToString(), false);
        
        if(state != EnemyState.Idle)
            enemyAnimator.SetBool(state.ToString(), true);


        currentState = state;
        lastStateChange = Time.time; 
    }

}

public enum EnemyState
{
    Idle, 
    Move,
    Shoot, 
}
