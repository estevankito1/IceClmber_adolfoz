using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveDir;
    [SerializeField] float speed = 5f;

    [SerializeField] Transform raycastorigin;
    [SerializeField] LayerMask raycastMask;

    private bool pendingBuilderSwitch = false;
    [SerializeField] bool isBuilder;
    [SerializeField] bool willbeBuilder;

    
    [SerializeField] Transform spawnPoint;
    public int health = 100;
    public GameObject spawner;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = moveDir * speed;
        RaycastHit2D hit = Physics2D.Raycast(raycastorigin.position, Vector2.down, 1f, raycastMask);
        if (hit.transform == null)
        {
            FlipEnemy();
            return;
        }
        if (hit.transform.GetComponent<SpriteRenderer>().enabled) return;
        if (isBuilder == true)
        {
            isBuilder = false;
            hit.transform.GetComponent<SpriteRenderer>().enabled = true;
            hit.transform.GetComponent<Collider2D>().isTrigger = false;
        }
        else if (!willbeBuilder)
        {
            willbeBuilder = true;
        }
        if (pendingBuilderSwitch)
        {
            willbeBuilder = false;
            isBuilder = true;
            pendingBuilderSwitch = false;
        }

        FlipEnemy();
    }

    void Update()
    {
        rb.linearVelocityX = moveDir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        pendingBuilderSwitch = true;

        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Damage")) // Example: Check for a tag indicating damage
            {
                health -= 10; // Example damage

                if (health <= 0)
                {
                    // Call the OnEnemyDeath function
                    GetComponent<EnemySpawner>().OnEnemyDeath();
                    Destroy(gameObject);
                }
            }
            collision.gameObject.SetActive(false);
            // Nuevo: respawnear enemigo en el punto de spawn si existe
            if (spawnPoint != null)
            {
                transform.position = spawnPoint.position;
            }
            return;
        }
        if (!collision.gameObject.CompareTag("Bouncer")) return;
        if (willbeBuilder == true)
        {
            willbeBuilder = false;
            isBuilder = true;
        }

        FlipEnemy();
    }

    void FlipEnemy()
    {
        moveDir *= -1;
        Vector3 local = transform.localScale;
        local.x *= -1;
        transform.localScale = local;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    
    

}
