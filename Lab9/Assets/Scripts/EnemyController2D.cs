using UnityEngine;
using UnityEngine.Events;

public class EnemyController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 350f;                          // Amount of force added when the player jumps.
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private float m_delayGroundCheck = 0.25f;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private GameObject gracz;

    public Animator animator;

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    private float timeBeforeGroundCheck = 0f;

    public Transform showEnemyRadius;
    public float enemyRadius = 2.0f;

    [SerializeField] private Transform playerCheck;

    [SerializeField]
    private Transform[] points;

    public int currentPoint = 0;


    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void Update()
    {
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] detectPlayer = Physics2D.OverlapCircleAll(playerCheck.position, enemyRadius, whatIsEnemy);

        for (int i = 0; i < detectPlayer.Length; i++)
        {
            if(detectPlayer[i].gameObject == gracz)
            {
                MoveToPlayer(-3f * Time.fixedDeltaTime);
                animator.SetFloat("Speed", Mathf.Abs(3.0f));
                Debug.Log("wykrywa");
                return;
            }
        }


        Move(-3f * Time.fixedDeltaTime);
        animator.SetFloat("Speed", Mathf.Abs(3.0f));
    }

    private void FixedUpdate()
    {
       
    }

    public void Move(float move)
    {
        //Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
        //m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (currentPoint == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[currentPoint].transform.position, 3.0f * Time.deltaTime);
            if (transform.position.x <= points[currentPoint].transform.position.x)
            {
                m_FacingRight = !m_FacingRight;
                currentPoint = 1;
            }
                

        }

        if(currentPoint == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[currentPoint].transform.position, 3.0f * Time.deltaTime);
            if (transform.position.x >= points[currentPoint].transform.position.x)
            {
                m_FacingRight = !m_FacingRight;
                currentPoint = 0;
            }
        }

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    public void MoveToPlayer(float move)
    {
        transform.position = Vector2.MoveTowards(transform.position, gracz.transform.position, 3.0f * Time.deltaTime);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(showEnemyRadius.position, enemyRadius);
    }
}