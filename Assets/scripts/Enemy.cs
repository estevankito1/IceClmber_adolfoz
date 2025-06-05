using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveDir;
    [SerializeField] float speed = 5f;

    [SerializeField] Transform raycastorigin;
    [SerializeField] LayerMask raycastMask;

    [SerializeField] bool isBuilder;
    [SerializeField] bool willbeBuilder;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX=moveDir * speed;
        RaycastHit2D hit = Physics2D.Raycast(raycastorigin.position, Vector2.down, 1f, raycastMask);
        if (hit.transform == null)
        {
            FlipEnemy();
            return;
        }
        if (hit.transform.GetComponent<SpriteRenderer>().enabled) return;
        if (isBuilder == true) { 
            isBuilder = false;
            hit.transform.GetComponent<SpriteRenderer>().enabled = true;
            hit.transform.GetComponent<Collider2D>().isTrigger = false;
        }
        else if (!willbeBuilder) { 
            willbeBuilder = true;
        }
       
        FlipEnemy();
    }

    void Update()
    {
        rb.linearVelocityX = moveDir * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))  { 
            collision.gameObject.SetActive(false);
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

    

}
